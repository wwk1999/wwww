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
   



    public EliteBeeMonster() : base(MonsterTypeByName.Bee) { }
   
    public void Start()
    {
        base.Start();
        monsterSkeletonAnimation.timeScale = 1.5f;
        size = 0.5f;
        
       
        
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

        if (isBingDong)
        {
            rigidbody2D.velocity = Vector2.zero;
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
