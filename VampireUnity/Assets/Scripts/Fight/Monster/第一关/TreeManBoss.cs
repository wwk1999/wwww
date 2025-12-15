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
   [NonSerialized]public float GroundFissureSkillTime = 10f;
   [NonSerialized]public float GroundFissureSkillCurrentTime = 0f;
   [NonSerialized]public Vector2 Dashdirection = Vector2.zero;
   [NonSerialized]public Vector2 GroundFissurepos = Vector2.zero;
   [NonSerialized]public Vector2 BaoZhapos = Vector2.zero;
   

   public Transform AttackTrans;
   //[NonSerialized] public bool HaveCircleAttack = false;

    public  void Awake()
    {
        CurrentHp = MaxHp;
        size = 1.5f;
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
        if (trackEntry.Animation.Name == "Exit")
        {
            IsSkill=false;
        }

        if (isSkill1)
        {
            IsSkill=true;
            isSkill1=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_01", false);
            GroundFissurepos=GameController.S.gamePlayer.transform.position;
            GameController.S.CreateCircleAttack(GroundFissurepos);
        }
        else
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", false);
        }
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

        // 根据事件名称处理逻辑
        if (e.Data.Name == "chong")
        {
            Debug.Log("执行攻击逻辑");
           
        }
        else if (e.Data.Name == "tiao")
        {
            Jump(0.8f, GroundFissurepos);
        }else if (e.Data.Name == "baozha")
        {
            Debug.Log("执行跳跃逻辑");
            //FightBGController.S.PlayGroundFissure(BaoZhapos);
        }
    }

    public void Jump(float time, Vector2 target)
    {
        StartCoroutine(JumpRoutine(time, target));
    }

    private IEnumerator JumpRoutine(float time, Vector2 target)
    {
        Vector2 startPos = rigidbody2D.position;
        Vector2 endPos   = target;

        float elapsed = 0f;
        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);

            // 线性插值移动刚体
            Vector2 newPos = Vector2.Lerp(startPos, endPos, t);
            rigidbody2D.MovePosition(newPos);

            yield return null;
        }

        // 确保最后到达精确位置
        rigidbody2D.MovePosition(endPos);
        IsSkill=false;
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
    

    private void Update()
    {
        if (IsDead) return;
        DashSkillCurrentTime+=Time.deltaTime;
        FireSkillCurrentTime+=Time.deltaTime;
        GroundFissureSkillCurrentTime += Time.deltaTime;
        if (GroundFissureSkillCurrentTime > GroundFissureSkillTime)
        {
            GroundFissureSkillCurrentTime = 0;
            isSkill1 = true;
        }
        if (FireSkillCurrentTime > FireSkillTime)
        {
            FireSkillCurrentTime = 0;
            isSkill2 = true;
        }
        if (DashSkillCurrentTime > DashSkillTime)
        {
            DashSkillCurrentTime = 0;
            isSkill3 = true;
        }
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
