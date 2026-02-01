using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Spine;
using Spine.Unity;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Animation = UnityEngine.Animation;
using Random = UnityEngine.Random;
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
    PuTong3,
    JianQi
}
public class Player : MonoBehaviour
{
    public GameObject arrow;
    public GunBase currentGun;
    private float _gunDistance = 0.3f;
    public SkeletonAnimation playerSkeleton;
    public float size = 0.28f;
    [NonSerialized] public bool IsWuDi = false;//红闪的时候无敌
    
    // 移动攻击力加成标志位
    [NonSerialized] private bool isMoveBonusApplied = false;
    
    // 延迟伤害相关变量
    [NonSerialized] private Queue<DelayedDamageInfo> delayedDamageQueue = new Queue<DelayedDamageInfo>();
    [NonSerialized] private Coroutine delayedDamageCoroutine = null;
    
    [NonSerialized] public bool MoveJian = false;
    [NonSerialized] public bool MouseDown = false;

    public Animator whiteChiBang;
    public Animator greenChiBang;
    public Animator blueChiBang;
    public Animator purpleChiBang;
    public Animator orangeChiBang;
    public Animator redChiBang;

    public GameObject IceBall4;
    public GameObject IceBall5;

    
    
    
    public GameObject Level5Title;
    public GameObject Level15Title;
    public GameObject Level30Title;
    public GameObject Level50Title;
    public GameObject Level75Title;
    public GameObject Level100Title;
    public GameObject MonsterCount1Title;
    public GameObject MonsterCount2Title;
    public GameObject MonsterCount3Title;
    public GameObject MonsterCount4Title;
    public GameObject MonsterCount5Title;
    public GameObject MonsterCount6Title;
    public GameObject LinHunTitle;
    public GameObject BaoShiTitle;
    public GameObject GuanKa3Title;
    public GameObject GuanKa4Title;
    public GameObject GuanKa5Title;
    public GameObject HunQi3Title;
    public GameObject HunQi4Title;
    public GameObject HunQi5Title;
    public GameObject DiaoLuoTitle;
    public GameObject ChiBang4Title;
    public GameObject ChiBang5Title;

    public void ShowTitle()
    {
        Level5Title.gameObject.SetActive(false);
        Level15Title.gameObject.SetActive(false);
        Level30Title.gameObject.SetActive(false);
        Level50Title.gameObject.SetActive(false);
        Level75Title.gameObject.SetActive(false);
        Level100Title.gameObject.SetActive(false);
        MonsterCount1Title.gameObject.SetActive(false);
        MonsterCount2Title.gameObject.SetActive(false);
        MonsterCount3Title.gameObject.SetActive(false);
        MonsterCount4Title.gameObject.SetActive(false);
        MonsterCount5Title.gameObject.SetActive(false);
        MonsterCount6Title.gameObject.SetActive(false);
        LinHunTitle.gameObject.SetActive(false);
        BaoShiTitle.gameObject.SetActive(false);
        GuanKa3Title.gameObject.SetActive(false);
        GuanKa4Title.gameObject.SetActive(false);
        GuanKa5Title.gameObject.SetActive(false);
        HunQi3Title.gameObject.SetActive(false);
        HunQi4Title.gameObject.SetActive(false);
        HunQi5Title.gameObject.SetActive(false);
        DiaoLuoTitle.gameObject.SetActive(false);
        ChiBang4Title.gameObject.SetActive(false);
        ChiBang5Title.gameObject.SetActive(false);

        switch (PlayerData.S.CurrentInstallTitle)
        {
            case TitleType.Level5:
                Level5Title.gameObject.SetActive(true);
                break;
            case TitleType.Level15:
                Level15Title.gameObject.SetActive(true);
                break;
            case TitleType.Level30:
                Level30Title.gameObject.SetActive(true);
                break;
            case TitleType.Level50:
                Level50Title.gameObject.SetActive(true);
                break;
            case TitleType.Level75:
                Level75Title.gameObject.SetActive(true);
                break;
            case TitleType.Level100:
                Level100Title.gameObject.SetActive(true);
                break;
            case TitleType.MonsterCount1:
                MonsterCount1Title.gameObject.SetActive(true);
                break;
            case TitleType.MonsterCount2:
                MonsterCount2Title.gameObject.SetActive(true);
                break;
            case TitleType.MonsterCount3:
                MonsterCount3Title.gameObject.SetActive(true);
                break;
            case TitleType.MonsterCount4:
                MonsterCount4Title.gameObject.SetActive(true);
                break;
            case TitleType.MonsterCount5:
                MonsterCount5Title.gameObject.SetActive(true);
                break;
            case TitleType.MonsterCount6:
                MonsterCount6Title.gameObject.SetActive(true);
                break;
            case TitleType.LinHun:
                LinHunTitle.gameObject.SetActive(true);
                break;
            case TitleType.BaoShi:
                BaoShiTitle.gameObject.SetActive(true);
                break;
            case TitleType.GuanKa3:
                GuanKa3Title.gameObject.SetActive(true);
                break;
            case TitleType.GuanKa4:
                GuanKa4Title.gameObject.SetActive(true);
                break;
            case TitleType.GuanKa5:
                GuanKa5Title.gameObject.SetActive(true);
                break;
            case TitleType.HunQi3:
                HunQi3Title.gameObject.SetActive(true);
                break;
            case TitleType.HunQi4:
                HunQi4Title.gameObject.SetActive(true);
                break;
            case TitleType.HunQi5:
                HunQi5Title.gameObject.SetActive(true);
                break;
            case TitleType.ChiBang4:
                ChiBang4Title.gameObject.SetActive(true);
                break;
            case TitleType.ChiBang5:
                ChiBang5Title.gameObject.SetActive(true);
                break;
            case TitleType.DiaoLuo:
                DiaoLuoTitle.gameObject.SetActive(true);
                break;
        }
    }

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
        playerSkeleton.AnimationState.Event += OnSpineEvent;
        ObserverModuleManager.S.RegisterEvent(ConstKeys.LevelUpAnim, PlayLevelUpAnim);
        ShowTitle();
    }
    
    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "attack"&&GlobalPlayerAttribute.TotalAttackSpeed<3)
        {
            SkillController.S.ShotBulletInvoke();
        }
    }

    private void OnDestroy()
    {
        playerSkeleton.AnimationState.Complete -= OnAnimationComplete;
        playerSkeleton.AnimationState.Event -= OnSpineEvent;
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

    public void OnAnimationComplete(TrackEntry trackEntry)
    {

        if (trackEntry.Animation.Name == "attack" &&GlobalPlayerAttribute.TotalAttackSpeed>=3)
        {
            SkillController.S.ShotBulletInvoke();
        }
        if (MouseDown)
        {
            if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.Skill1ReplaceNormalAttack))
            {
                return;
            }
            playerSkeleton.timeScale = GlobalPlayerAttribute.TotalAttackSpeed;
            playerSkeleton.AnimationState.SetAnimation(0, "attack", false);
        }
        else if(MoveJian)
        {
            playerSkeleton.timeScale = 1;
            playerSkeleton.AnimationState.SetAnimation(0, "walk", false);
        }
        else
        {
            playerSkeleton.timeScale = 1;
            playerSkeleton.AnimationState.SetAnimation(0, "idle", false);
        }
       
    }
    /// <summary>
    /// 主角动画
    /// </summary>
    public void SetBianLiang()
    {
        //获得输入
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal == 0 && vertical == 0)
        {
            if (MoveJian&& MouseDown == false)
            {
                playerSkeleton.AnimationState.SetAnimation(0, "idle", false);
            }
            MoveJian = false;
        }
        else
        {
            if (MoveJian == false && MouseDown == false)
            {
                playerSkeleton.timeScale = 1;
                playerSkeleton.AnimationState.SetAnimation(0, "walk", false);
            }
            MoveJian = true;
        }

        if (Input.GetMouseButton(0))
        {
            MouseDown = true;
        }
        else
        {
            MouseDown = false;
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
        
        // 判断是否在移动（考虑键盘和摇杆输入）
        bool isMoving = !(horizontal == 0 && vertical == 0);
        
        // 处理移动状态变化时的攻击力加成
        if (isMoving && !isMoveBonusApplied)
        {
            // 从静止变为移动：应用加成
            if (GlobalPlayerAttribute.MoveAddAttackNum > 0)
            {
                GameController.S.MoveAddAttackCount = 1;
                isMoveBonusApplied = true;
            }
        }
        else if (!isMoving && isMoveBonusApplied)
        {
            // 从移动变为静止：移除加成
            if (GlobalPlayerAttribute.MoveAddAttackNum > 0)
            {
                GameController.S.MoveAddAttackCount = 0;
                isMoveBonusApplied = false;
            }
        }
        
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        
        // 使用 ScaleX 的正负来表示翻转（新版 Spine runtime 移除了 FlipX 属性）
        float currentScaleX = playerSkeleton.Skeleton.ScaleX;
        float absScaleX = Mathf.Abs(currentScaleX);
        playerSkeleton.Skeleton.ScaleX = (worldPos.x > transform.position.x) ? absScaleX : -absScaleX;

        if (!MouseDown)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal, vertical).normalized * GlobalPlayerAttribute.PlayerMoveSpeed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
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
    
    public void ShowHurtText(float damage)
    {
        MonsterHurtText monsterHpGameObject = GameController.S.MonsterHurtTextQueue.Dequeue();
        monsterHpGameObject.isPlayer=true;
        monsterHpGameObject.transform.position = transform.position;
        monsterHpGameObject.playerText.text =FloatToSpriteString(damage);
        float offsetX=Random.Range(-0.6f,0.2f);
        float offsetY=Random.Range(-0.2f,0.2f);
        monsterHpGameObject.transform.position = new Vector3(transform.position.x + 0.2f+offsetX,
            transform.position.y + 0.5f+offsetY, transform.position.z);
        monsterHpGameObject.gameObject.SetActive(true);
    }
    
    public static string FloatToSpriteString(float value)
    {
        long intPart = (long)Math.Abs(Math.Truncate(value));
        // 特判 0
        if (intPart == 0) return "<sprite=0>";

        string digits = intPart.ToString();
        var sb = new StringBuilder(digits.Length * 10);
        foreach (char c in digits)
        {
            if (c >= '0' && c <= '9')
            {
                int index = c - '0';
                sb.Append("<sprite=").Append(index).Append('>');
            }
        }
        return sb.ToString();
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

        GameController.S.HitCount++;
        GameController.S.HitCount=Math.Min(10, GameController.S.HitCount);
        GlobalPlayerAttribute.CDTeXiao5Time = 5;

        var playerHurt=GameController.S.PlayerHurtQueue.Dequeue();
        playerHurt.transform.position = transform.position;
        playerHurt.gameObject.SetActive(true);

        damage -= GameController.S.GameDefense;
        float realDamage = 0;
        if (isBoss)
        {
            realDamage = damage*(1-GlobalPlayerAttribute.DamageReductionPercentForBoss/100f);
        }
        else
        {
            realDamage = damage*(1-GlobalPlayerAttribute.DamageReductionPercentForNormal/100f);
        }
        realDamage *= (1 - GlobalPlayerAttribute.DamageReductionPercent/100f);
        
        
        realDamage=GetPlayerHurtDamageByOrangeEntry(realDamage);
        realDamage=Math.Max(0,realDamage);
        if (GlobalPlayerAttribute.HH5Count > 0 && realDamage >= GameController.S.GameCurrentHp * 0.5f)
        {
            realDamage = GameController.S.GameCurrentHp * 0.5f;
        }
        // 检查是否有DelayDamage词条
        bool hasDelayDamage = GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DelayDamage);
        ShowHurtText(Mathf.RoundToInt(realDamage));
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
        //CameraContraller.S.CameraShake(0.1f, 0.005f);
        var playerhit = FightBGController.S.PlayerHitQueue.Dequeue();
        playerhit.gameObject.SetActive(true);
        StartCoroutine(DelayCancelWuDi(0.2f));
        if (playerSkeleton.AnimationState.GetCurrent(0).Animation.Name == "idle" ||
            playerSkeleton.AnimationState.GetCurrent(0).Animation.Name == "walk")
        {
            playerSkeleton.timeScale = 1;
            playerSkeleton.AnimationState.SetAnimation(0, "hit", false);
        }
    }

    public void PlayerDie()
    {
        playerSkeleton.timeScale = 1;
        playerSkeleton.AnimationState.SetAnimation(0, "die", false);
        FightBGController.S.SetHp();
        StartCoroutine(DelayShowPanel());
    }

    IEnumerator DelayShowPanel()
    {
        yield return new WaitForSeconds(0.5f);
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
        float updateInterval = 0.1f; // 每0.1秒更新一次
        
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
                // 使用 remainingTime 而不是 totalTime，确保所有伤害都能被结算完
                float damageThisFrame = (info.damage / info.remainingTime) * updateInterval;
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

    public void ShowArrow()
    {
        arrow.SetActive(true);
    }

    public void HideArrow()
    {
        arrow.SetActive(false);
    }

    private void Update()
    {
        Vector2 dir = (Vector2.zero - new Vector2(transform.position.x, transform.position.y)).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        //主角操作
        PlayerMove();
        if (Input.GetMouseButtonDown(0))
        {
            if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.Skill1ReplaceNormalAttack))
            {
                return;
            }
            MouseDown = true;
            playerSkeleton.timeScale = GlobalPlayerAttribute.TotalAttackSpeed;
            playerSkeleton.AnimationState.SetAnimation(0, "attack", false);
        }
        SetBianLiang();
        SetGunRotate(GameController.S.nearMonsterPosition);
    }
}

