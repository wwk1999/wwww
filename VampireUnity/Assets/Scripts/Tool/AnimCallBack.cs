using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCallBack : MonoBehaviour
{
    public Animator monsterAnimator;
    public MonsterBase monsterBase;
    
    // 用于记录上一帧的动画状态，避免重复触发
    private string lastAnimationName = "";
    private float lastNormalizedTime = 0f;
    private int lastStateHash = 0;
    
    private void Update()
    {
        if (monsterAnimator == null || monsterBase == null) return;
        
        // 获取当前动画状态信息
        AnimatorStateInfo stateInfo = monsterAnimator.GetCurrentAnimatorStateInfo(0);
        
        // 如果正在过渡，不处理
        if (monsterAnimator.IsInTransition(0))
        {
            return;
        }
        
        // 获取当前动画名
        string currentAnimationName = GetCurrentAnimationName(stateInfo);
        int currentStateHash = stateInfo.fullPathHash;
        
        // 检查是否是我们要监听的动画
        if (IsTargetAnimation(currentAnimationName))
        {
            // 检查动画是否刚结束（normalizedTime >= 1.0 且上一帧 < 1.0）
            // 或者状态切换了（说明上一个动画结束了）
            bool animationJustEnded = false;
            
            if (currentStateHash != lastStateHash)
            {
                // 状态切换了，说明上一个动画结束了
                if (IsTargetAnimation(lastAnimationName))
                {
                    animationJustEnded = true;
                    currentAnimationName = lastAnimationName; // 使用上一个动画名
                }
            }
            else if (stateInfo.normalizedTime >= 1.0f && lastNormalizedTime < 1.0f)
            {
                // 动画播放完成（normalizedTime 从 < 1.0 变为 >= 1.0）
                animationJustEnded = true;
            }
            
            if (animationJustEnded)
            {
                OnAnimationEnd(currentAnimationName);
            }
        }
        
        // 更新记录
        lastAnimationName = currentAnimationName;
        lastNormalizedTime = stateInfo.normalizedTime;
        lastStateHash = currentStateHash;
    }
    
    /// <summary>
    /// 获取当前动画名
    /// </summary>
    private string GetCurrentAnimationName(AnimatorStateInfo stateInfo)
    {
        if (stateInfo.IsName("attack1"))
            return "attack1";
        else if (stateInfo.IsName("fail"))
            return "fail";
        else if (stateInfo.IsName("beatback"))
            return "beatback";
        else
            return "unknown";
    }
    
    /// <summary>
    /// 判断是否是目标动画
    /// </summary>
    private bool IsTargetAnimation(string animationName)
    {
        return animationName == "attack1" || 
               animationName == "fail" || 
               animationName == "beatback";
    }
    
    /// <summary>
    /// 动画结束时的处理逻辑
    /// </summary>
    private void OnAnimationEnd(string animationName)
    {
        Debug.Log($"AnimCallBack: {animationName} 动画结束");
        
        switch (animationName)
        {
            case "attack1":
                OnAttack1End();
                break;
            case "fail":
                OnFailEnd();
                break;
            case "beatback":
                OnBeatbackEnd();
                break;
        }
    }
    
    /// <summary>
    /// attack1 动画结束的回调
    /// </summary>
    private void OnAttack1End()
    {
        if (monsterBase != null)
        {
            Debug.Log("AnimCallBack: attack1 动画结束，恢复移动");
        }
    }
    
    /// <summary>
    /// fail 动画结束的回调
    /// </summary>
    private void OnFailEnd()
    {
        if (monsterBase != null)
        {
            monsterAnimator.Play("move");
            monsterBase.isMove = true;
            Debug.Log("AnimCallBack: fail 动画结束，恢复移动");
        }
    }
    
    /// <summary>
    /// beatback 动画结束的回调
    /// </summary>
    private void OnBeatbackEnd()
    {
        if (monsterBase != null)
        {
            monsterAnimator.Play("move");
            monsterBase.isMove = true;
            Debug.Log("AnimCallBack: beatback 动画结束，恢复移动");
        }
    }
    
    /// <summary>
    /// Unity Animator 的回调方法（备用方案，如果 Update 方法不工作可以用这个）
    /// </summary>
    private void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator != monsterAnimator) return;
        
        string animationName = GetCurrentAnimationName(stateInfo);
        
        // 只在动画完整播放结束时触发（normalizedTime >= 1.0）
        if (stateInfo.normalizedTime >= 1.0f && IsTargetAnimation(animationName))
        {
            OnAnimationEnd(animationName);
        }
    }
}
