using System;
using System.Collections;
using Equip;
using Spine;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;
public class TreeManBoss : MonsterBase
{
    public TreeManBoss() : base(MonsterType.Boss, "TreeManBoss", 1, 1000, 0.5f, 10, 5, 10, 10, 0) { }
   [NonSerialized]public float FireSkillTime = 30f;
   [NonSerialized]public float FireSkillCurrentTime = 0f;
   [NonSerialized]public float DashSkillTime = 10f;
   [NonSerialized]public float DashSkillCurrentTime = 0f;
   [NonSerialized]public float GroundFissureSkillTime = 20f;
   [NonSerialized]public float GroundFissureSkillCurrentTime = 0f;
   [NonSerialized]public Vector2 Dashdirection = Vector2.zero;
   [NonSerialized]public Vector2 GroundFissurepos = Vector2.zero;
   [NonSerialized]public Vector2 BaoZhapos = Vector2.zero;
   

   public Transform AttackTrans;
   //[NonSerialized] public bool HaveCircleAttack = false;

    public  void Awake()
    {
        size = 1.5f;
        // 获取 SkeletonAnimation
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
        monsterSkeletonAnimation.AnimationState.Complete += Complete;
       
       MonsterSpineName.AttackName = "attack";
       MonsterSpineName.HitName = "hit";
       MonsterSpineName.MoveName = "walk";
       MonsterSpineName.DieName = "die_02";
       MonsterSpineName.AppearName = "Exit";
       MonsterSpineName.Skill1Name = "skill_01";
       MonsterSpineName.Skill2Name = "skill_02";
       MonsterSpineName.Skill3Name = "skill_03";
    }

    public void Complete(TrackEntry trackEntry)
    {
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", false);
    }

    public void Start()
    {
        size = 1.5f;
        AddMonsterEquip();
        AddMonsterSourceStone();
        AddMonsterProp();
    }
    
    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        Debug.Log($"触发事件帧！动画名称: {trackEntry.Animation.Name}, 事件名称: {e.Data.Name}, 事件值: {e.String}");

        // 根据事件名称处理逻辑
        if (e.Data.Name == "chong")
        {
            Debug.Log("执行攻击逻辑");
           
        }
        else if (e.Data.Name == "tiao")
        {
            Debug.Log("执行跳跃逻辑");
            StartCoroutine(MoveToTarget(GroundFissurepos, 5f)); // 移动速度：5f
        }else if (e.Data.Name == "baozha")
        {
            Debug.Log("执行跳跃逻辑");
            //FightBGController.S.PlayGroundFissure(BaoZhapos);
        }
    }

   
    public override void Die()
    {
        GeneralDie();
        GetEx();
        CreateBloodEnergy();
        CreateEquip();
        CreateWeaponSourceStone();
        FightBGController.S.PlaySuccessAnim();
        CreateProp();
    }
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,1),100));
    }

    

    private IEnumerator MoveToTarget(Vector3 targetPosition, float speed)
    {
       
        Rigidbody2D rb = GetComponent<Rigidbody2D>(); // 获取刚体组件

        // 持续移动，直到达到目标位置
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f) // 阈值
        {
            // 计算移动方向
            Vector3 direction = (targetPosition - transform.position).normalized;
            //计算targetPosition和transform.position的距离
            float distance = Vector3.Distance(targetPosition, transform.position);

            // 设置刚体速度
            rb.velocity = direction * speed*distance;

            // 等待下一帧
            yield return null;
        }
        BaoZhapos = targetPosition;
        // 到达目标位置后，停止刚体运动
        rb.velocity = Vector2.zero;
        FightBGController.S.PlayGroundFissure(targetPosition);
        yield break; // 退出协程
    }

    private void Update()
    {
        if (IsDead) return;
        if (Vector2.Distance(AttackTrans.position, GameController.S.gamePlayer.transform.position) < size&&!IsSkill)
        {
            isAttack = true;
            if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name != "attack")
            {
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, "attack", false);
            }
        }

        BossMove();
        SpriteFlipX(true);
    }

    public void BossMove()
    {
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "walk" ||
            monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "hit")
        {
            Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
            rigidbody2D.velocity = direction.normalized * Speed; 
        }
    }

    public override void Skill() { }
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Primary, 10));
        
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.TreeMan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.TreeMan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.TreeMan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.TreeMan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.TreeMan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.TreeMan, 10));
    }

    // public override void Hurt(int damage)
    // {
    //     base.Hurt(damage);
    //     hpSlider.value -= damage;
    // }

    public override void AddMonsterSourceStone()
    {
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Penetrate,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Division,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.ExtremeSpeed,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Explosion,10));
    }
}
