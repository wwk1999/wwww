using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;
using Random = UnityEngine.Random;

public class XiaoHuoMonster : MonsterBase
{
    public XiaoHuoMonster() : base(MonsterType.Normal, "XiaoHuoMonster", 1, 500, 0.7f, 100, 20, 20, 2, 0)
    {
    }

    public Transform attackTrans;
   
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Green, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Green, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Green, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Green, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Green, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Green, 1));
    }
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,1),5));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,1),5));
    }
    
    public void Awake()
    {
        base.Awake();
        var randomSpeed=Random.Range(-0.1f, 0.1f);
        Speed+=randomSpeed;
        MonsterSpineName.AttackName = "attack";
        MonsterSpineName.HitName = "hit";
        MonsterSpineName.MoveName = "walk";
        MonsterSpineName.DieName = "die";
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
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy,1);
        CreateEquip();
        CreateProp();
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
        size = 0.5f;
        AddMonsterEquip();
        AddMonsterProp();
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;

    }
    
    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "attack")
        {
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) <= size)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,false);
            }
        }
    }
    
    void Update()
    {
        if(IsDead) return;
        base.Update();
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < size)
        {
            monsterSkeletonAnimation.timeScale = 1.5f;
            isAttack=true;
        }
        else
        {
            monsterSkeletonAnimation.timeScale = 1;
            isAttack=false;
        }
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(true);
        }
    }
}
