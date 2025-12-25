using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;
using Random = UnityEngine.Random;

public class HuoShanBoss : MonsterBase
{
    public HuoShanBoss() : base(MonsterType.Boss, "TreeManBoss", 1, 2000, 0.5f, 10, 5, 10, 10, 0) { }
    public Transform attackTrans;
    [NonSerialized]public float Skill1Time= 8f;
    [NonSerialized]public float Skill1CurrentTime = 0f;
    [NonSerialized]public float Skill2Time = 20f;
    [NonSerialized]public float Skill2CurrentTime = 0f;
    [NonSerialized]public float Skill3Time = 15f;
    [NonSerialized]public float Skill3CurrentTime = 0f;
    [NonSerialized]public State CurrentState = State.Move;


    public void Start()
    {
        base.Start();
        size = 1f;
        AddMonsterEquip();
        AddMonsterSourceStone();
        AddMonsterProp();
    }
    
    public  void Awake()
    {
        base.Awake();
        size = 1.2f;
        MonsterSpineName.AttackName = "attack";
        MonsterSpineName.HitName = "hit";
        MonsterSpineName.MoveName = "walk";
        MonsterSpineName.DieName = "die";
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
        monsterSkeletonAnimation.AnimationState.Complete += Complete;

    }
    
    public void Complete(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "Exit")
        {
            IsSkill=false;
        }

        if (isSkill1)
        {
           
        }else if (isSkill2)
        {
          
        }else if (isSkill3)
        {
           
        } else if(isAttack)
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.AttackName, false);
        }
        else
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.MoveName, false);
        }
    }
    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {

        if (e.Data.Name == "huoyan")
        {
          
        }
    }
    
    public override void Skill() { }
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Green, 10));
        
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.HuoShan, 10));
    }
    
    public override void AddMonsterSourceStone()
    {
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Penetrate,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Division,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.ExtremeSpeed,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Explosion,10));
    }
    
    public override void Die()
    {
        GeneralDie();
        GetEx();
        CreateBloodEnergy();
        CreateEquip();
        CreateWeaponSourceStone();
        CreateProp();
    }
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,1),100));
    }

    void Update()
    {
        if(IsDead) return;
        base.Update();
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
