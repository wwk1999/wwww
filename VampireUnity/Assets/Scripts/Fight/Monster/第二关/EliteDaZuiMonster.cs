using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;

public class EliteDaZuiMonster : MonsterBase
{
    [NonSerialized]public float skillTime = 5f;
    [NonSerialized]public float currentTime = 0f;
    public EliteDaZuiMonster() : base(MonsterType.Elite, "EliteDaZuiMonster", 1, 1000, 0.3f, 20, 5, 50, 100, 10) { }

    public SkeletonAnimation fireSke;
    public Transform attackTrans;
    public void Awake()
    {
        base.Awake();
        MonsterSpineName.AttackName = "attack";
        MonsterSpineName.HitName = "hit";
        MonsterSpineName.MoveName = "walk";
        MonsterSpineName.DieName = "die";
        MonsterSpineName.Skill1Name = "skill";
    }
    
    public override void AddMonsterSourceStone()
    {
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Penetrate,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Division,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.ExtremeSpeed,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Explosion,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Scale,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Duration,2));
    }
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Green, 10));
    }
    
   public override void Hurt(float damage,bool isCrit,DamageFrom damageFrom)
    {
        base.Hurt(damage,isCrit,damageFrom);
        if (!IsDead)
        {
            AudioController.S.PlayBatHit();
        }
    }
    
    public override void Skill()
    {
        // Implement the skill logic here
    }
    
    private void RandomDelayDie()
    {
        AudioController.S.PlaySnotDie();
        GeneralDie();
        GetEx();
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy,2);
        CreateEquip();
        CreateProp();
    }
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,1),100));
    }

    public override void Die()
    {
        //生成随机数
        float randomDelay = UnityEngine.Random.Range(0, 20) * 0.02f;
        Invoke(nameof(RandomDelayDie),randomDelay);
    }
    
    private void Start()
    {
        base.Start();
        size = 0.7f;
        AddMonsterEquip();
        AddMonsterSourceStone();
        AddMonsterProp();
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
        monsterSkeletonAnimation.AnimationState.Complete += Complete;
    }

    public void Complete(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "skill")
        {
            IsSkill = false;
        }
        
        if(isSkill1)
        {
            IsSkill=true;
            isSkill1=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill", false);
        }else if (isAttack)
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "attack", false);
        }
        else
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "walk", false);
        }
    }

    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "akill")
        {
            fireSke.gameObject.SetActive(true);
            fireSke.AnimationState.SetAnimation(0, "animation", false);
        }
    }
    
    void Update()
    {
        if (IsDead) return;
        base.Update();
        currentTime+= Time.deltaTime;
        if (currentTime > skillTime && Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 3)
        {
            currentTime = 0;
            isSkill1 = true;
        }
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < size)
        {
            isAttack=true;
        }
        else
        {
            isAttack=false;
        }
        
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(true);
        }
    }
}
