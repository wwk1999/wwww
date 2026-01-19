using System.Collections;
using System.Collections.Generic;
using Config;
using Equip;
using Spine;
using UnityEngine;

public class EMo3 : MonsterBase
{
    public EMo3() : base(MonsterType.Normal, "EMo3", 1, MJConfig.BaseMonsterAttribute.hp*MJConfig.MonsterAttributeDic[MJLevel.Red2].hp, 0.8f, MJConfig.BaseMonsterAttribute.atk*MJConfig.MonsterAttributeDic[MJLevel.Red2].atk, MJConfig.BaseMonsterAttribute.def*MJConfig.MonsterAttributeDic[MJLevel.Red2].def, MJConfig.BaseMonsterAttribute.ex*MJConfig.PlayerAttributeDic[MJLevel.Red2].ex, MJConfig.BaseMonsterAttribute.linhun*MJConfig.PlayerAttributeDic[MJLevel.Red2].linhun, 0)
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
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.ZhaoZe, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.ZhaoZe, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.ZhaoZe, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.ZhaoZe, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.ZhaoZe, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.ZhaoZe, 2));
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
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,3),5));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,3),5));

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
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) <1.2f)
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
