using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public enum PlayerState
{
    None,
    Idle,
    Walk,
    Attack,
    Hurt,
    Dead
}
public enum WeaponType
{
    None,
    Primary,
    LanBao,
    Fire,
    XuKong,
    LvQuan,
    HeiDong,
    Du,
    LuoLei,
    PuTong3
}
public class Player : MonoBehaviour
{
    //public Animator animator;
    public WeaponType weaponType = WeaponType.Primary;
    public GunBase currentGun;
    private float _gunDistance = 0.3f;
    public GameObject iceBall;
    public SkeletonAnimation playerSkeleton;
    public PlayerState playerState= PlayerState.None;
    public bool isAttack=false;
    public Slider hpSlider;
    public Slider exSlider;
    public Text levelText;
    public float size = 0.28f;
    [NonSerialized] public bool IsWuDi = false;//红闪的时候无敌
    
    // 延迟伤害相关变量
    [NonSerialized] private Queue<DelayedDamageInfo> delayedDamageQueue = new Queue<DelayedDamageInfo>();
    [NonSerialized] private Coroutine delayedDamageCoroutine = null;
    
    // 延迟伤害信息结构
    private struct DelayedDamageInfo
    {
        public float damage;      // 伤害值
        public float remainingTime; // 剩余时间
        public float totalTime;    // 总时间（3秒）
        
        public DelayedDamageInfo(float dmg, float time)
        {
            damage = dmg;
            remainingTime = time;
            totalTime = time;
        }
    }

    public Animation levelUpAnim;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI denfenseText;


    public GameObject LevelUp;
    public ParticleSystem LevelUpParticle;
    private void Awake()
    {
        currentGun = Instantiate(Resources.Load<GameObject>("Prefabs/Gun/Pistol").GetComponent<GunBase>(),transform);
        playerSkeleton.AnimationState.Complete += OnAnimationComplete;
        ObserverModuleManager.S.RegisterEvent(ConstKeys.LevelUpAnim, PlayLevelUpAnim);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent(ConstKeys.LevelUpAnim, PlayLevelUpAnim);
    }

    public void PlayLevelUpAnim(object obj)
    {
        levelUpAnim.gameObject.SetActive(true);
        attackText.text=PlayerInfoConfig.AttackDic[GlobalPlayerAttribute.Level].ToString();
        hpText.text=PlayerInfoConfig.HpDic[GlobalPlayerAttribute.Level].ToString();
        denfenseText.text=PlayerInfoConfig.DenfenseDic[GlobalPlayerAttribute.Level].ToString();
        levelUpAnim.Play("LevelUpTextAnim");
    }
    
    public void TempChangePlayerMoveSpeed(float speed,float time)
    {
        float t = GlobalPlayerAttribute.PlayerMoveSpeed;
        GlobalPlayerAttribute.PlayerMoveSpeed = speed;
        StartCoroutine(ResumeSpeed(time,t));
    }
    //携程等待1s
    private IEnumerator ResumeSpeed(float seconds,float speed)
    {
        yield return new WaitForSeconds(seconds);
        GlobalPlayerAttribute.PlayerMoveSpeed = speed;

    }

    public void OnAnimationComplete(Spine.TrackEntry trackEntry)
    {
        playerSkeleton.AnimationState.SetAnimation(0, "walk", false);
        if (trackEntry.Animation.Name == "attack")
        {
            isAttack = false;
            SkillController.S.ShotBulletInvoke();
            GameController.S.gamePlayer.playerState= PlayerState.None;
        }
        if (trackEntry.Animation.Name == "hit")
        {
            GameController.S.gamePlayer.playerState= PlayerState.None;
        }
    }
    /// <summary>
    /// 主角动画
    /// </summary>
    public void PlayerMoveAnimation()
    {
        //获得输入
        Vector2 joydir = FightBGController.S.joystick.input.normalized;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (!isAttack)
        {
            if (joydir == Vector2.zero)
            {
                if (horizontal == 0 && vertical == 0)
                {
                    if (playerState != PlayerState.Idle)
                    {
                        playerSkeleton.AnimationState.SetAnimation(0, "idle", true);
                    }

                    //player播放idle动画，player是spine动画
                    playerState = PlayerState.Idle;
                }
                else
                {
                    if (playerSkeleton.AnimationState.GetCurrent(0).Animation.Name=="idle")
                    {
                        playerSkeleton.AnimationState.SetAnimation(0, "walk", true);
                    }

                    playerState = PlayerState.Walk;
                }
            }
            else
            {
                if (playerState != PlayerState.Walk)
                {
                    playerSkeleton.AnimationState.SetAnimation(0, "walk", true);
                }

                playerState = PlayerState.Walk;
            }
        }
    }
    
    /// <summary>
    /// 主角移动
    /// </summary>
    public void PlayerMove()
    {
        //获得输入
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal == 0 && vertical == 0)
        {
            GlobalPlayerAttribute.isMove = false;
            GameController.S.GameAttack *= (1 + GlobalPlayerAttribute.MoveAddAttackNum);
        }
        else
        {
            GlobalPlayerAttribute.isMove = true;
        }
        Vector2 joydir = FightBGController.S.joystick.input.normalized;
        if (joydir.x > 0)
        {
           // spriteRenderer.flipX = false;
           playerSkeleton.Skeleton.FlipX = false;
        } else if (joydir.x < 0)
        {
            playerSkeleton.Skeleton.FlipX = true;
        }
        if (joydir == Vector2.zero)//设置pc和安卓的移动
        {
            if(horizontal>0)
            {
                playerSkeleton.Skeleton.FlipX = false;
            }
            else if(horizontal<0)
            {
                playerSkeleton.Skeleton.FlipX = true;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal, vertical).normalized * GlobalPlayerAttribute.PlayerMoveSpeed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = joydir * GlobalPlayerAttribute.PlayerMoveSpeed;
        }
            
    }
    
    
    public void SetGunRotate(Vector3 nearMonsterPosition)
    {
        //主角朝最近怪物的方向
        Vector3 direction = (nearMonsterPosition - transform.position).normalized;
        //设置枪的位置
        //currentGun.transform.position = transform.position + direction * _gunDistance;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //如果角度在90-270之间
        if (angle > 90 || angle <-90)
        {
            currentGun.transform.localPosition = new Vector3(-2.54f,
                currentGun.transform.localPosition.y, currentGun.transform.localPosition.z);

            //currentGun.gunSpriteRender.flipY = true;
        }
        else
        {
            currentGun.transform.localPosition = new Vector3(2.54f,
                currentGun.transform.localPosition.y, currentGun.transform.localPosition.z);        
        }
        currentGun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    

    public float GetPlayerHurtDamageByOrangeEntry(float damage)
    {
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.FinalDamageReductionPercent))
        {
            damage *= 0.9f;
        }
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.FinalDamageReductionFixed))
        {
            damage -= 300;
        }

        return damage;
    }

    /// <summary>
    /// 统一的死亡检查方法
    /// </summary>
    private void CheckDeath()
    {
        if (GameController.S.GameCurrentHp <= 0)
        {
            // 停止延迟伤害协程（如果还在运行）
            if (delayedDamageCoroutine != null)
            {
                StopCoroutine(delayedDamageCoroutine);
                delayedDamageCoroutine = null;
                delayedDamageQueue.Clear(); // 清空延迟伤害队列
            }
            
            // 检查复活
            if (GameController.S.isFuHuo &&
                GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.ReplyDeath))
            {
                Debug.LogError("触发复活");
                GameController.S.GameCurrentHp = GameController.S.GameMaxHp * 0.3f;
            }
            else
            {
                PlayerDie();
            }
        }
    }

    public void DelayDamage(float realDamage)
    {
        // 有DelayDamage词条：70%立即生效，30%延迟生效
        float immediateDamage = realDamage * 0.7f; // 70%立即生效
        float delayedDamage = realDamage * 0.3f;   // 30%延迟生效
            
        // 立即施加70%的伤害
        GameController.S.GameCurrentHp -= Mathf.RoundToInt(immediateDamage);
            
        // 统一死亡检查（立即伤害后）
        CheckDeath();
        
        // 将30%的伤害加入延迟伤害队列
        if (delayedDamage > 0)
        {
            delayedDamageQueue.Enqueue(new DelayedDamageInfo(delayedDamage, 3f));
                
            // 如果协程没有运行，启动它
            if (delayedDamageCoroutine == null)
            {
                delayedDamageCoroutine = StartCoroutine(ApplyDelayedDamage());
            }
        }
    }

    /// <summary>
    /// 主角受伤
    /// </summary>
    /// <param name="damage"></param>
    public void PlayerHurt(float damage,bool isBoss)
    {
        if (GlobalPlayerAttribute.CurrentHp <= 0)
        {
            return;
        }

        damage -= GameController.S.GameDefense;
        float realDamage = 0;
        if (isBoss)
        {
            realDamage = damage*(1-GlobalPlayerAttribute.DamageReductionPercentForBoss);
        }
        else
        {
            realDamage = damage*(1-GlobalPlayerAttribute.DamageReductionPercentForNormal);
        }

        float mianshangValue = GlobalPlayerAttribute.DamageReductionPercent;
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HpReductionAddDefense))
        {
            mianshangValue += 0.15f;
        }
        realDamage *= (1 - mianshangValue);//免伤
        
        
        realDamage=GetPlayerHurtDamageByOrangeEntry(realDamage);
        
        // 检查是否有DelayDamage词条
        bool hasDelayDamage = GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DelayDamage);
        
        if (hasDelayDamage)
        {
            DelayDamage(realDamage);
        }
        else
        {
            // 没有DelayDamage词条：100%立即生效（原逻辑）
            GameController.S.GameCurrentHp -= Mathf.RoundToInt(realDamage);
            
            // 统一死亡检查
            CheckDeath();
            
            // 如果已经死亡，不再处理后续逻辑
            if (GameController.S.GameCurrentHp <= 0)
            {
                return;
            }
        }
        if (IsWuDi)
        {
            return;
        }
        //打印调用这个方法的脚本name
        AudioController.S.PlayPlayerHurt();
        CameraContraller.S.CameraShake(0.1f, 0.005f);
        var playerhit = FightBGController.S.PlayerHitQueue.Dequeue();
        playerhit.gameObject.SetActive(true);
        StartCoroutine(DelayCancelWuDi(0.2f));
        playerSkeleton.AnimationState.SetAnimation(0, "hit", false);
    }

    public void PlayerDie()
    {
        playerSkeleton.AnimationState.SetAnimation(0, "die", false);
        StartCoroutine(DelayShowPanel());
    }

    IEnumerator DelayShowPanel()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        Instantiate(Resources.Load("Prefabs/Window/FailPanel") as GameObject);
    }

    IEnumerator DelayCancelWuDi(float time)
    {
        yield return new WaitForSeconds(time);
        GameController.S.gamePlayer.IsWuDi = false;
    }

    /// <summary>
    /// 持续处理延迟伤害队列
    /// </summary>
    private IEnumerator ApplyDelayedDamage()
    {
        float updateInterval = 1f; // 每0.1秒更新一次
        
        while (delayedDamageQueue.Count > 0)
        {
            // 如果玩家已死亡，停止施加延迟伤害
            if (GameController.S.GameCurrentHp <= 0)
            {
                break;
            }
            
            float totalDamageThisFrame = 0f;
            int count = delayedDamageQueue.Count;
            
            // 遍历队列中的所有延迟伤害，计算本次应该施加的伤害
            for (int i = 0; i < count; i++)
            {
                DelayedDamageInfo info = delayedDamageQueue.Dequeue();
                
                // 计算本次应该施加的伤害（按剩余时间比例）
                float damageThisFrame = (info.damage / info.totalTime) * updateInterval;
                totalDamageThisFrame += damageThisFrame;
                
                // 更新剩余时间和剩余伤害
                info.remainingTime -= updateInterval;
                info.damage -= damageThisFrame;
                
                // 如果还有剩余时间，重新加入队列
                if (info.remainingTime > 0.01f && info.damage > 0.01f)
                {
                    delayedDamageQueue.Enqueue(info);
                }
                else
                {
                    // 如果时间快到了，施加剩余的伤害（避免浮点数误差）
                    if (info.damage > 0.01f)
                    {
                        totalDamageThisFrame += info.damage;
                    }
                }
            }
            
            // 施加本次计算的总伤害
            if (totalDamageThisFrame > 0)
            {
                int finalDamage = Mathf.RoundToInt(totalDamageThisFrame);
                GameController.S.GameCurrentHp -= finalDamage;
                
                // 统一死亡检查（延迟伤害后）
                CheckDeath();
                
                // 如果死亡，退出协程
                if (GameController.S.GameCurrentHp <= 0)
                {
                    break;
                }
            }
            
            yield return new WaitForSeconds(updateInterval);
        }
        
        // 协程结束，重置引用
        delayedDamageCoroutine = null;
    }

    private void Update()
    {
        //主角操作
        PlayerMove();
        PlayerMoveAnimation();
//        Debug.Log("枪的方向：" + GameController.S.nearMonsterPosition);
        SetGunRotate(GameController.S.nearMonsterPosition);
    }
}
