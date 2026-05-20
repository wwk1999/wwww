using System.Collections;
using System.Collections.Generic;
using Config;
using Equip;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace Fight.Monster.秘境.雷兽
{
    public class LeiShouBoss:MonsterBase
    {
        public LeiShouBoss() : base(MonsterTypeByName.LeiShou)        {
        }
    
        public Transform attackTrans;
        private float skill1Time = 13;
        private float skill2Time = 17;
        private float skill3Time = 16;
        private float currentSkill1Time = 10;
        private float currentSkill2Time = 6;
        private float currentSkill3Time = 7;

        public GameObject skill1;
        public SkeletonAnimation skill1ske;
        public Collider2D Skill1Collider2D;
        public GameObject skill1parent;
        
        
         public  void Awake()
    {
        MaxHp /= 100;
        Attack /= 100;
        Defense/= 100;
        Exp/= 100;
        BloodEnergy/= 100;
        base.Awake();
        MonsterSpineName.AttackName = "attack1";
        MonsterSpineName.HitName = "injured";
        MonsterSpineName.MoveName = "move";
        MonsterSpineName.DieName = "fail";
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
        monsterSkeletonAnimation.AnimationState.Complete += Complete;
        skill1ske.AnimationState.Event += Skill1OnSpineEvent;
        skill1ske.AnimationState.Complete += Skill1Complete;
    }
         
        
    public void ShowSkill1()
    {
        skill1.SetActive(true);
        var dir=(QueueController.S.gamePlayer.transform.position-transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        skill1parent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        skill1parent.transform.localScale=parent.transform.localScale;
        skill1ske.AnimationState.SetAnimation(0, "heihuo", false);
        skill1ske.timeScale = 2.2f;
    }

    public void Skill1Complete(TrackEntry trackEntry)
    {
        skill1.gameObject.SetActive(false);
    }

    IEnumerator Skill3(float delay,Vector2 spawnPos)
    {
         GameController.S.CreateCircleAttack(spawnPos,1f);
         yield return new WaitForSeconds(delay);
         LeiShouSkill3 huoyan=QueueController.S.LeiShouSkill3Queue.Dequeue();
         huoyan.transform.position = spawnPos;
         huoyan.damage = Attack;
         huoyan.gameObject.SetActive(true);
    }
    
    private IEnumerator Skill3Coroutine(float delay,Vector2 pos, float dis, float time, int count)
    {
        yield return  new WaitForSeconds(delay);
        for (int i = 0; i < count; i++)
        {
            // 随机点：Random.insideUnitCircle 返回单位圆内随机点，乘以 dis 后移到指定半径范围
            Vector2 randomOffset = Random.insideUnitCircle * dis;
            Vector2 spawnPos = pos + randomOffset;
            StartCoroutine(Skill3(0.5f,spawnPos));
            if (time > 0f)
                yield return new WaitForSeconds(time);
            else
                yield return null;
        }
    }
    

    IEnumerator ShunYiNext()
    {
        yield return new WaitForSeconds(2f);
        var pos = QueueController.S.gamePlayer.transform.position;
        GameController.S.CreateCircleAttack(pos,1);
        yield return new WaitForSeconds(0.5f);
        transform.position = pos;
        collider2D.tag = "Boss";
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill5", false);
    }
    
     public void Complete(TrackEntry trackEntry)
    {
        monsterSkeletonAnimation.timeScale = 1f;
        if (trackEntry.Animation.Name == "skill1"||trackEntry.Animation.Name == "skill2"||trackEntry.Animation.Name == "skill3"||trackEntry.Animation.Name == "skill4"||trackEntry.Animation.Name == "skill5")
        {
            IsSkill=false;
        }

        if (trackEntry.Animation.Name == "skill4")
        {
            collider2D.tag = "Bullet";
            StartCoroutine(ShunYiNext());
            return;
        }
        
        if (isSkill1)
        {
            IsSkill=true;
            isSkill1=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill1", false);
            monsterSkeletonAnimation.timeScale = 1.5f;
            Invoke(nameof(ShowSkill1),1.5f);
        }else if (isSkill2)
        {
            IsSkill=true;
            isSkill2=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill4", false);
            monsterSkeletonAnimation.timeScale = 1f;
        }
        else if(isSkill3)
        {
            IsSkill=true;
            isSkill3=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill3", false);
            monsterSkeletonAnimation.timeScale = 2f;
            StartCoroutine(Skill3Coroutine(1f,transform.position,8f,0.3f,25));
        }
        else if(isAttack)
        {
            monsterSkeletonAnimation.timeScale = 1.5f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.AttackName, false);
        }
        else
        {
            monsterSkeletonAnimation.timeScale = 1.5f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.MoveName, false);
        }
    }
    

   public override void Hurt(float damage,bool isCrit,DamageFrom damageFrom,YuanSuType yuanSuType)
    {
        base.Hurt(damage,isCrit,damageFrom,yuanSuType);
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
        //CreateBloodEnergy();
        CreateEquip();
        CreateProp();
        FightBGController.S.PlaySuccessAnim();
        QueueController.S.StartCoroutine(DelayChuanSongMen());
    }
    IEnumerator DelayChuanSongMen()
    {
        yield return new WaitForSeconds(1f);
        var chuansongmen = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChuanSongMen"));
        chuansongmen.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    
     private void Start()
    {
        base.Start();
        size = 1.2f;
        
       
    }
    
    private void OnDestroy()
    {
        monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
    }

    public void Skill1Collider()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        Skill1Collider2D.OverlapCollider(filter, results);
    
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Player"))
            {
               QueueController.S.gamePlayer.PlayerHurt(Attack*0.7f,true);
            }
        }
    }

    public void Skill1OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "huoyan")
        {
            Skill1Collider();
        }
    }
    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "lightning")
        {
            LeiShouShunYi light=Instantiate(Resources.Load<GameObject>("Prefabs/Monster/MJ/LeiShou/LeiShouShunYi")).GetComponent<LeiShouShunYi>();
            light.damage = Attack;
            light.transform.position = transform.position;
            light.gameObject.SetActive(true);
        }

        if (e.Data.Name == "draw" && trackEntry.Animation.Name == "attack1")
        {
            if (Vector2.Distance(attackTrans.position, QueueController.S.gamePlayer.transform.position) < size ||
                Vector2.Distance(transform.position, QueueController.S.gamePlayer.transform.position) < 1.5f)
            {
                QueueController.S.gamePlayer.PlayerHurt(Attack,true);
            }
        }
    }
    
    
    
    
    public void MonsterMove1()
    {
        Vector3 direction = QueueController.S.gamePlayer.transform.position - transform.position;
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "move"||IsDash)
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
        float dis=Vector2.Distance(transform.position,QueueController.S.gamePlayer.transform.position);
        if(dis<0.2f)
        {
            //如果距离小于0.2f，则不翻转
            return;
        }
        //翻转精灵
        if (isRight)
        {
            if (QueueController.S.gamePlayer.transform.position.x > transform.position.x)
            {
                parent.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                parent.transform.localScale = new Vector3(-1, 1, 1);
            }
        }else
        {
            if (QueueController.S.gamePlayer.transform.position.x > transform.position.x)
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
       
        if (!IsSkill)  // 添加这个条件
        {
            currentSkill1Time += Time.deltaTime;
            currentSkill2Time += Time.deltaTime;
            currentSkill3Time += Time.deltaTime;
        }
        

        if (currentSkill1Time > skill1Time)
        {
            if (parent.transform.localScale.x > 0&&transform.position.x-QueueController.S.gamePlayer.transform.position.x>1)
            {
                currentSkill1Time = 0;
                isSkill1 = true;
            }
            if (parent.transform.localScale.x < 0&&QueueController.S.gamePlayer.transform.position.x-transform.position.x>1)
            {
                currentSkill1Time = 0;
                isSkill1 = true;
            }
        }
        
        if (currentSkill2Time > skill2Time)
        {
            currentSkill2Time = 0;
            isSkill2 = true;
        }

        if (currentSkill3Time > skill3Time)
        {
            currentSkill3Time = 0;
            isSkill3 = true;
        }
        
        if (Vector2.Distance(attackTrans.position, QueueController.S.gamePlayer.transform.position) < size||Vector2.Distance(transform.position, QueueController.S.gamePlayer.transform.position) < 1.5f)
        {
            isAttack=true;
        }
        else
        {
            isAttack=false;
        }
        
        
        if (!IsDead)
        {
            MonsterMove1();
            SpriteFlipX1(false);
        }
    }
    }
}