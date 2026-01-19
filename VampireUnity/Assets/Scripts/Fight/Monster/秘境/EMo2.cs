using System.Collections;
using System.Collections.Generic;
using Config;
using Equip;
using Spine;
using UnityEngine;

public class EMo2 : MonsterBase
{
    public EMo2() : base(MonsterType.Normal, "EMo2", 1, MJConfig.BaseMonsterAttribute.hp*MJConfig.MonsterAttributeDic[MJLevel.Purple].hp, 0.8f, MJConfig.BaseMonsterAttribute.atk*MJConfig.MonsterAttributeDic[MJLevel.Purple].atk, MJConfig.BaseMonsterAttribute.def*MJConfig.MonsterAttributeDic[MJLevel.Purple].def, MJConfig.BaseMonsterAttribute.ex*MJConfig.PlayerAttributeDic[MJLevel.Purple].ex, MJConfig.BaseMonsterAttribute.linhun*MJConfig.PlayerAttributeDic[MJLevel.Purple].linhun, 0)
    {
    }
    public Transform attackTrans;
    
    
    public void Awake()
    {
        base.Awake();
        MaxHp /= 100;
        Attack /= 100;
        Defense/= 100;
        Exp/= 100;
        BloodEnergy/= 100;
        MonsterSpineName.AttackName = "attack";
        MonsterSpineName.HitName = "hit";
        MonsterSpineName.MoveName = "walking";
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
        if (e.Data.Name == "attack"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "attack")
        {
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < 1.2f)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,false);
            }
        }
    }
    
    void Update()
    {
        if (IsDead) return;
        base.Update();
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < 1.2f)
        {
            isAttack=true;
            monsterSkeletonAnimation.timeScale = 1.5f;
        }
        else
        {
            isAttack=false;
            monsterSkeletonAnimation.timeScale = 1f;
        }
        
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(true);
        }
    }
}
