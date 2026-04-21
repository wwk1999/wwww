using System;
using System.Collections;
using Equip;
using Spine;
using UnityEngine;
using Random = UnityEngine.Random;

public class BatMonster : MonsterBase
{
    //[NonSerialized]public bool IsTrigger;
    [NonSerialized]public float attackTime = 3f;
    [NonSerialized]public float currentTime = 0f;
    public Transform attackTrans;

    public BatMonster() : base(MonsterTypeByName.Bat) { }
    void Start()
    {
        base.Start();
        monsterSkeletonAnimation.timeScale = 1.5f;
        size = 0.5f;
        
       
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
   
    public override void Skill()
    {
        // Implement the skill logic here
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead) return;
        base.Update();
        if (Speed == 8&&Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position)<0.6f)
        {
            GameController.S.gamePlayer.PlayerHurt(Attack,false);
        }
        
        
        float distance = Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position);
        currentTime+= Time.deltaTime;
        if(currentTime>= attackTime&&distance<2.6f)
        {
            AttackBegin();
            currentTime = 0f;
        }
        if (!IsDead&&!IsDash)
        {
            MonsterMove();
            SpriteFlipX(false);
        }
    }

    

    public void AttackBegin()
    {
        transform.Find("MonsterWarning").gameObject.SetActive(true);
        transform.Find("MonsterWarning").GetComponent<Animator>().Play("MonsterWarning");
        IsDash = true;
         Speed = 0;
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
    
   public override void Hurt(float damage,bool isCrit,DamageFrom damageFrom)
    {
        base.Hurt(damage,isCrit,damageFrom);
        if (!IsDead)
        {
            AudioController.S.PlayBatHit();
        }
    }
}
