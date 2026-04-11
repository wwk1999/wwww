using System.Collections;
using System.Collections.Generic;
using Config;
using Equip;
using Spine;
using UnityEngine;

public class HuangShu : MonsterBase
{
    public HuangShu() : base(MonsterTypeByName.ChaiLangRen2)
    {
    }
    
    public Transform attackTrans;

    
    
    public void Awake()
    {
        base.Awake();
        var randomSpeed=Random.Range(-0.1f,0.1f);
        Speed+=randomSpeed;
        MonsterSpineName.AttackName = "attack1";
        MonsterSpineName.HitName = "injured";
        MonsterSpineName.MoveName = "move";
        MonsterSpineName.DieName = "fail";
        MonsterSpineName.Skill1Name = "skill1";

    }

    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Green, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Green, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Green, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Green, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Green, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Green, 2));
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

        //生成随机数
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
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,2),5));    }
    
    private void OnDestroy()
    {
        monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
    }
    
    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "damage"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "attack1")
        {
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < 0.4f||Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 0.4f)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,false);
            }
        }
    }

    void Update()
    {
        if (IsDead) return;
        base.Update();
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < 0.4f||Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 0.4f)
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
            SpriteFlipX(false);
        }
    }
}
