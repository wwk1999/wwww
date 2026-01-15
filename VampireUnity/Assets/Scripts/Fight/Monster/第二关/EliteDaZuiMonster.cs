using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EliteDaZuiMonster : MonsterBase
{
    [NonSerialized]public float skillTime = 5f;
    [NonSerialized]public float currentTime = 0f;
    public EliteDaZuiMonster() : base(MonsterType.Elite, "EliteDaZuiMonster", 1, 5000, 0.8f, 100, 30, 100, 10, 10) { }

    public SkeletonAnimation fireSke;
    public GameObject fireParent;
    public Transform attackTrans;
    private bool isfire=false;
    private float fireTime = 0.2f;
    private float currentFireTime = 0f;
    public Collider2D fireCollider;
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
    
   
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Green, 5));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Green, 5));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Green, 5));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Green, 5));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Green, 5));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Green, 5));
    }
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),10));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,2),10));
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
        AddMonsterProp();
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
        monsterSkeletonAnimation.AnimationState.Complete += Complete;
        fireSke.AnimationState.Event += FireOnSpineEvent;
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

    private void FireOnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "E-SHAKE")
        {
            isfire = !isfire;
        }
    }
    
    
    public void CheckCollider()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        fireCollider.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Player"))
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,true);
            }
        }
    }

   

    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "akill")
        {
            var MoveDirection=(GameController.S.gamePlayer.transform.position-transform.position).normalized;
            float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
            fireParent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            fireParent.gameObject.SetActive(true);
            fireSke.AnimationState.SetAnimation(0, "animation", false);
        }
    }
    
    void Update()
    {
        if (IsDead) return;
        base.Update();
        currentTime+= Time.deltaTime;
        if (isfire)
        {
            currentFireTime+=Time.deltaTime;
        }

        if (currentFireTime > fireTime)
        {
            currentFireTime = 0;
            CheckCollider();
        }
       float yabs=Math.Abs(transform.position.y-GameController.S.gamePlayer.transform.position.y);
       float xabs=Math.Abs(transform.position.x-GameController.S.gamePlayer.transform.position.x);
       float bili = yabs / xabs;
        if (currentTime > skillTime && Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 3&&bili<1.5)
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
