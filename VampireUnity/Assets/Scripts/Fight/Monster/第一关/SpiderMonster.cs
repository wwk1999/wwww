using System;
using System.Collections;
using Equip;
using Spine;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpiderMonster : MonsterBase
{
    [NonSerialized]public float attackTime = 60f;
    [NonSerialized]public float currentTime = 0f;
    public SpiderWeb spiderWeb;
    public Transform attackTrans;

    public SpiderMonster() : base(MonsterTypeByName.Spider) { }
    void Start()
    {
        base.Start();
        monsterSkeletonAnimation.timeScale = 1.5f;

        size = 0.6f;
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
        var randomSpeed=Random.Range(-0.1f,0.1f);
        Speed+=randomSpeed;
        MonsterSpineName.AttackName = "attack";
        MonsterSpineName.HitName = "hit";
        MonsterSpineName.MoveName = "walk";
        MonsterSpineName.DieName = "die";
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
        if (monsterSkeletonAnimation != null)
        {
            DelayDestroy();
            var baoxue = GameController.S.BaoXueQueue.Dequeue();
            baoxue.transform.position=transform.position;
            baoxue.gameObject.SetActive(true);
        }
        float randomDelay = Random.Range(0, 20) * 0.02f;
        Invoke(nameof(RandomDelayDie), randomDelay);
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
        currentTime+= Time.deltaTime;
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(false);
        }
    }
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,1),3));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,1),3));
    }

    public override void AddMonsterEquip()
    {
    
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Primary, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Primary, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Primary, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Primary, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Primary, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Primary, 1));
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
