using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HuoQuXian : MonoBehaviour
{
    [NonSerialized] public float speed;
    public TrailRenderer trailRenderer;
    public SpriteRenderer spriteRenderer;


    
    // 飞行状态
    private enum FlyState
    {
        Curved,     // 曲线阶段
        Straight    // 直线阶段
    }
    private FlyState currentState = FlyState.Curved;
    private Vector2 straightDirection; // 直线飞行方向
    private float straightFlyTime = 0f; // 直线飞行时间
    
    // 添加一个标志来控制协程
    private bool isMoving = false;
    private Coroutine moveCoroutine;
    
    // 使用单个协程完成整个运动
    private IEnumerator Move(Vector2 start, Vector2 mid, Vector2 target)
    {
        // 等待一帧确保物体已经完全激活
        yield return null;
        
        // 重置状态
        currentState = FlyState.Curved;
        straightFlyTime = 0f;
        isMoving = true;
        
        // 计算曲线总长度（近似值）
        float curveLength = EstimateCurveLength(start, mid, target);
        
        // 计算曲线阶段需要的时间
        float curveDuration = curveLength / speed;
        float elapsedTime = 0f;
        
        // 确保起始位置正确
        transform.position = start;
        
        // 立即设置初始方向（指向第一个目标点）
        Vector2 firstDirection = (mid - start).normalized;
        SetRotationFromDirection(firstDirection);
        
        // 记录上一帧位置用于计算方向
        Vector2 previousPos = start;
        
        // 曲线飞行阶段
        while (elapsedTime < curveDuration && isMoving && gameObject.activeInHierarchy)
        {
            // 计算进度 (0-1)
            float t = elapsedTime / curveDuration;
            
            // 正确的二次贝塞尔曲线公式
            Vector2 p1 = Vector2.Lerp(start, mid, t);
            Vector2 p2 = Vector2.Lerp(mid, target, t);
            Vector2 p = Vector2.Lerp(p1, p2, t);
            
            // 计算移动方向（使用当前位置和上一帧位置）
            Vector2 moveDirection = (p - previousPos).normalized;
            
            // 如果移动方向有效，更新旋转
            if (moveDirection.magnitude > 0.01f)
            {
                SetRotationFromDirection(moveDirection);
            }
            
            // 设置位置
            transform.position = p;
            previousPos = p;
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        // 检查是否被中断
        if (!isMoving || !gameObject.activeInHierarchy) yield break;
        
        // 到达目标点，记录直线飞行方向
        transform.position = target;
        straightDirection = (target - mid).normalized; // 使用曲线结束时的方向
        
        // 确保直线方向有效
        if (straightDirection.magnitude <= 0.01f)
        {
            straightDirection = (target - start).normalized;
        }
        
        SetRotationFromDirection(straightDirection);
        currentState = FlyState.Straight;
        
        // 直线飞行阶段（继续飞行，直到被Hide）
        while (isMoving && gameObject.activeInHierarchy)
        {
            // 直线移动（使用恒定速度）
            Vector2 newPos = (Vector2)transform.position + straightDirection * speed * Time.deltaTime;
            
            // 直线飞行时方向不变，不需要每帧重新计算
            transform.position = newPos;
            
            straightFlyTime += Time.deltaTime;
            
            // 每帧等待
            yield return null;
        }
    }
    
    // 估算贝塞尔曲线的长度
    private float EstimateCurveLength(Vector2 start, Vector2 mid, Vector2 target)
    {
        int segments = 10;
        float length = 0f;
        Vector2 previousPoint = start;
        
        for (int i = 1; i <= segments; i++)
        {
            float t = i / (float)segments;
            
            Vector2 p1 = Vector2.Lerp(start, mid, t);
            Vector2 p2 = Vector2.Lerp(mid, target, t);
            Vector2 currentPoint = Vector2.Lerp(p1, p2, t);
            
            length += Vector2.Distance(previousPoint, currentPoint);
            previousPoint = currentPoint;
        }
        
        return length;
    }
    
    // 通过方向设置物体的旋转（使用Z轴）
    void SetRotationFromDirection(Vector2 direction)
    {
        if (direction.magnitude > 0.01f)
        {
            // 计算角度：方向向量与X轴正方向的夹角
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            // 设置物体的Z轴旋转
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    
    private void OnEnable()
    {
        spriteRenderer.sortingOrder = 3000 + Random.Range(0, 1000);
        // 确保speed有默认值
        if (speed <= 0)
        {
            speed = 5f; // 设置一个默认速度
        }
        
        // 2秒后自动隐藏（无论什么状态）
        Invoke(nameof(Hide), 2f);
    }
    
    public void Hide()
    {
        // 取消Invoke，防止重复调用
        CancelInvoke(nameof(Hide));
        
        // 停止移动标志
        isMoving = false;
        
        // 停止协程
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
        
        StopAllCoroutines(); // 停止所有协程
        
        // 确保对象被正确回收
        if (GameController.S != null)
        {
            QueueController.S.HeiAnQuXianQueue.Enqueue(this);
        }
        
        gameObject.SetActive(false);
    }
    
    // 新的公共方法来启动移动
    public void StartMove(Vector2 start, Vector2 mid, Vector2 target)
    {
        // 先停止所有正在运行的协程
        StopAllCoroutines();
    
        // 先设置初始位置（重要！）
        transform.position = start;
    
        // 重置Trail Renderer - 现在是在新位置清除
        if (trailRenderer != null)
        {
            trailRenderer.Clear(); // 清除拖尾历史
            // 强制重置拖尾
            trailRenderer.enabled = false;
            trailRenderer.enabled = true;
        }
    
        // 重置状态
        isMoving = true;
    
        // 立即设置初始方向（指向控制点）
        Vector2 initialDirection = (mid - start).normalized;
        if (initialDirection.magnitude > 0.01f)
        {
            SetRotationFromDirection(initialDirection);
        }
    
        // 启动新的协程
        moveCoroutine = StartCoroutine(Move(start, mid, target));
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 添加一个标志防止重复触发
        if (!gameObject.activeInHierarchy || !isMoving) return;
        
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        Debug.Log("碰撞点世界坐标: " + closestPoint);
        
        if (other.CompareTag("Monster") || other.CompareTag("Boss"))
        {
            if (QueueController.S.HeiAnPengQueue.Count > 0)
            {
                var hit = QueueController.S.HeiAnPengQueue.Dequeue();
                hit.transform.position = closestPoint;
                
                bool isCrit = GameController.S.GetIsCrit();
                
                if (QueueController.S.MonsterColliderDic != null && 
                    QueueController.S.MonsterColliderDic.TryGetValue(other, out var monster))
                {
                    monster.Hurt(
                        QueueController.S.GameAttack * SkillController.S.HuoYuanSuDamage,
                        isCrit,
                        DamageFrom.NormalAttack,YuanSuType.Huo
                    );
                }
                
                hit.SetActive(true);
            }
            
            // 立即隐藏当前魔法弹
            Hide();
        }
    }
    
    // 当对象被禁用时，确保协程停止
    private void OnDisable()
    {
        isMoving = false;
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
        StopAllCoroutines();
        CancelInvoke();
    }
}