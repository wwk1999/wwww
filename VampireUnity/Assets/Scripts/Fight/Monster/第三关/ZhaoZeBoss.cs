using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;

public class ZhaoZeBoss : MonsterBase
{
   public ZhaoZeBoss() : base(MonsterType.Boss, "ZhaoZeBoss", 1, 10000, 0.3f, 10, 5, 10, 10, 0)
    {
    }
    public Transform attackTrans;
    private float skill1Time=5;
    private float skill2Time=10;
    private float skill3Time=15;
    private float currentSkill1Time=0;
    private float currentSkill2Time=0;
    private float currentSkill3Time=0;
    public Collider2D skill1Collider;
    public Collider2D skill3Collider;
    public Transform skill1trans;
    public Transform skill3trans;


    public void Awake()
    {
        base.Awake();
        MonsterSpineName.AttackName = "attack1";
        MonsterSpineName.HitName = "injured";
        MonsterSpineName.MoveName = "move";
        MonsterSpineName.DieName = "fail";
        MonsterSpineName.Skill1Name = "skill1";
        MonsterSpineName.Skill2Name = "skill2";
        MonsterSpineName.Skill3Name = "skill3";


    }

    

    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Blue, 10));
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
        int randomDelay = UnityEngine.Random.Range(0, 10);
        StartCoroutine(RandomDelayDie(randomDelay));
    }

    private IEnumerator RandomDelayDie(int delay)
    {
        for (int i = 0; i < delay; i++)
        {
            yield return null;
        }

        AudioController.S.PlaySnotDie();
        GeneralDie();
        GetEx();
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy, 1);
        CreateBloodEnergy();
        CreateEquip();
        CreateProp();

        // gameObject.SetActive(false);
        // GameController.S.SnotMonsterQueue.Enqueue(this);
    }

    private void Start()
    {
        base.Start();
        size = 0.9f;
        AddMonsterEquip();
        AddMonsterProp();
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
        monsterSkeletonAnimation.AnimationState.Complete += Complete;
    }
    
    public void Complete(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "appear"||trackEntry.Animation.Name == "skill1"||trackEntry.Animation.Name == "skill2"||trackEntry.Animation.Name == "skill3")
        {
            IsSkill=false;
        }

        if (trackEntry.Animation.Name == "skill1")
        {
            monsterSkeletonAnimation.timeScale = 1;
        }
        
        if (isSkill1)
        {
            IsSkill=true;
            isSkill1=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill1", false);
            monsterSkeletonAnimation.timeScale = 2;
        }else if (isSkill2)
        {
            IsSkill=true;
            isSkill2=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill2", false);
        }else if (isSkill3)
        {
            IsSkill=true;
            isSkill3=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill3", false);
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
        if (e.Data.Name == "damage"&&trackEntry.Animation.Name=="attack1")
        {
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) <= size)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,false);
            }
        }
        if (e.Data.Name == "damage"&&trackEntry.Animation.Name=="skill1")
        {
            CheckSkill1Damage();
        }
        if (e.Data.Name == "damage"&&trackEntry.Animation.Name=="skill3")
        {
            CheckSkill3Damage();
        }
    }

    public void CheckSkill1Damage()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        skill1Collider.OverlapCollider(filter, results);
    
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
    
    public void CheckSkill3Damage()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        skill3Collider.OverlapCollider(filter, results);
    
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
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,1),100));
    }
    
    public void MonsterMove1()
    {
        Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "move")
        {
            GetComponent<Rigidbody2D>().velocity = direction.normalized * Speed; 
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = direction.normalized * 0; 
        }
    }
    
    public void SpriteFlipX1(bool isRight)
    {
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name != "move")
        {
            return;
        }
        float dis=Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position);
        if(dis<0.2f)
        {
            //如果距离小于0.2f，则不翻转
            return;
        }
        //翻转精灵
        if (isRight)
        {
            if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
            {
                parent.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                parent.transform.localScale = new Vector3(-1, 1, 1);
            }
        }else
        {
            if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
            {
                parent.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                parent.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        
    }


    void Update()
    {
        if (IsDead) return;
        base.Update();
        currentSkill1Time+=Time.deltaTime;
        currentSkill2Time+=Time.deltaTime;
        currentSkill3Time+=Time.deltaTime;
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < size)
        {
            isAttack=true;
        }
        else
        {
            isAttack=false;
        }

        if (currentSkill1Time > skill1Time &&
            Vector2.Distance(skill1trans.position, GameController.S.gamePlayer.transform.position) < 1.5)
        {
            currentSkill1Time = 0;
            isSkill1 = true;
        }

        if (currentSkill3Time > skill3Time &&Math.Abs(skill3trans.position.x - GameController.S.gamePlayer.transform.position.x) < 3.5&&Math.Abs(skill3trans.position.y - GameController.S.gamePlayer.transform.position.y) < 2)
        {
            currentSkill3Time = 0;
            isSkill3 = true;
        }
        if (!IsDead)
        {
            MonsterMove1();
            SpriteFlipX1(false);
        }
    }
}
