using System;
using System.Collections;
using Equip;
using NUnit.Framework;
using Spine;
using UnityEngine;


public class SnotMonster : MonsterBase
{
   public Transform attackTrans;

    public SnotMonster() : base(MonsterType.Normal, "SnotMonster", 1, 100, 0.7f, 10, 5, 10, 10, 0) { }
    void Start()
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
    public void Awake()
    {
        base.Awake();
        MonsterSpineName.AttackName = "attack";
        MonsterSpineName.HitName = "hit";
        MonsterSpineName.MoveName = "walk";
        MonsterSpineName.DieName = "die";
    }
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,1),100));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,2),100));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,3),100));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,4),100));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,5),100));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,6),100));
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
    
    
   
    public override void Skill()
    {
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "zhiwnag", false);
        IsSkill= true;
    }

    // Update is called once per frame
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
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Primary, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Primary, 10));
    }
    
   public override void Hurt(float damage,bool isCrit,DamageFrom damageFrom)
    {
        base.Hurt(damage,isCrit,damageFrom);
        if (!IsDead)
        {
            AudioController.S.PlayBatHit();
        }
    }
}