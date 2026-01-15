using System;
using System.Collections;
using Equip;
using UnityEngine;
using Random = UnityEngine.Random;

public class EliteBeeMonster : MonsterBase
{
    [NonSerialized] public float SkillTime = 5f;
    [NonSerialized] public float SkillColingTime = 0f;
    //public GameObject skillRangeTrigger;
   



    public EliteBeeMonster() : base(MonsterType.Elite, "EliteBeeMonster", 1, 1000, 0.5f, 30, 5, 50, 5, 10) { }
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Primary, 3));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Primary, 3));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Primary, 3));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Primary, 3));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Primary, 3));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Primary, 3));
        
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Green, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Green, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Green, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Green, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Green, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Green, 1));
    }
    

    public void Start()
    {
        base.Start();
        monsterSkeletonAnimation.timeScale = 1.5f;
        size = 0.5f;
        AddMonsterEquip();
        AddMonsterProp();
        
    }
    public void Awake()
    {
        base.Awake();
        var randomSpeed=Random.Range(-0.1f,0.1f);
        Speed+=randomSpeed;
        MonsterSpineName.AttackName = "attack";
        MonsterSpineName.HitName = "hit";
        MonsterSpineName.MoveName = "walk";
        MonsterSpineName.DieName = "die";
        MonsterSpineName.Skill1Name = "skill";
    }
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,1),5));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),2));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,1),5));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,2),2));
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

    public override void Die()
    {
        //生成随机数
        float randomDelay = UnityEngine.Random.Range(0, 20) * 0.02f;
        Invoke(nameof(RandomDelayDie),randomDelay);
    }
    
    

    public override void Skill()
    {
        var bullet=GameController.S.BeeBulletQueue.Dequeue();
        bullet.damage = Attack;
        bullet.transform.position = transform.position;
        bullet.gameObject.SetActive(true);
        AudioController.S.PlayBeeSkill();
    }
    void Update()
    {
        if (IsDead) return;
        base.Update();
        
        SkillColingTime+= Time.deltaTime;
        if(SkillColingTime>=SkillTime&&Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position)<8f&& !IsDead)
        {
            SkillColingTime = 0;
            isSkill1 = true;
        }
        if (!IsDead)
        {
            SpriteFlipX(false);
            //SpriteFlipX(false);
        }

        if (!IsDead && Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position)>8f)
        {
             MonsterMove();
        }
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
