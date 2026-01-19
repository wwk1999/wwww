using System.Collections;
using System.Collections.Generic;
using Config;
using Equip;
using Spine;
using UnityEngine;

public class LanLong1 : MonsterBase
{
    public LanLong1() : base(MonsterType.Normal, "LanLong1", 1, MJConfig.BaseMonsterAttribute.hp*MJConfig.MonsterAttributeDic[MJLevel.Green].hp, 1f, MJConfig.BaseMonsterAttribute.atk*MJConfig.MonsterAttributeDic[MJLevel.Green].atk, MJConfig.BaseMonsterAttribute.def*MJConfig.MonsterAttributeDic[MJLevel.Green].def, MJConfig.BaseMonsterAttribute.ex*MJConfig.PlayerAttributeDic[MJLevel.Green].ex, MJConfig.BaseMonsterAttribute.linhun*MJConfig.PlayerAttributeDic[MJLevel.Green].linhun, 0)
    {
    }
    public Transform attackTrans;
    
    
    public void Awake()
    {
        MaxHp /= 100;
        Attack /= 100;
        Defense/= 100;
        Exp/= 100;
        BloodEnergy/= 100;
        base.Awake();
        MonsterSpineName.AttackName = "dragon_Spatk_1";
        MonsterSpineName.HitName = "hit";
        MonsterSpineName.MoveName = "dragon_walk";
        MonsterSpineName.DieName = "die";

    }
    public override void AddMonsterEquip()
    {
       
    }
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,4),3));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,4),3));
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

    public override void Die()
    {
        float randomDelay = UnityEngine.Random.Range(0, 20) * 0.02f;
        Invoke(nameof(RandomDelayDie),randomDelay);
    }

    private void  RandomDelayDie()
    {
        AudioController.S.PlaySnotDie();
        GeneralDie();
        GetEx();
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy, 1);
        CreateEquip();
        CreateProp();
    }
    
    private void Start()
    {
        base.Start();
        isBeatback = false;
        size = 0.5f;
        AddMonsterEquip();
        AddMonsterProp();

        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
    }
    
    private void OnDestroy()
    {
        monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
    }
    
    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "attack"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == MonsterSpineName.AttackName)
        {
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < 0.9f||Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 0.9f)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,false);
            }
        }
    }
    
    void Update()
    {
        if (IsDead) return;
        base.Update();
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < 0.9f||Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 0.9f)
        {
            monsterSkeletonAnimation.timeScale = 1.7f;
            isAttack=true;
        }
        else
        {
            monsterSkeletonAnimation.timeScale = 1.3f;
            isAttack=false;
        }
        
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(true);
        }
    }
}
