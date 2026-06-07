using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using Random = UnityEngine.Random;

public class NiRenBoss : MonsterBase
{
    public NiRenBoss() : base(MonsterTypeByName.NiRen){
    }

    public Transform attackTrans;
    private float skill1Time = 12;
    private float skill2Time = 15;
    private float skill3Time = 20;
    private float skill4Time = 10;

    private float currentSkill1Time = 5;
    private float currentSkill2Time = 0;
    private float currentSkill3Time = 5;
    private float currentSkill4Time = 7;

    public Collider2D skill1Tri;
    [NonSerialized] public bool IsStand;
    public void Awake()
    {
        MaxHp /= 100;
        Attack /= 100;
        Defense /= 100;
        Exp /= 100;
        BloodEnergy /= 100;
        base.Awake();
        MonsterSpineName.AttackName = "attack1";
        MonsterSpineName.HitName = "injured";
        MonsterSpineName.MoveName = "move";
        MonsterSpineName.DieName = "fail";
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
        monsterSkeletonAnimation.AnimationState.Complete += Complete;
    }

   


  
    
   
    public void Complete(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == MonsterSpineName.DieName)
        {
            gameObject.SetActive(false);
        }
        
        if (IsDead)
        {
            return;
        }
        monsterSkeletonAnimation.timeScale = 1f;
        if (trackEntry.Animation.Name == "skill1" || trackEntry.Animation.Name == "skill2" ||
            trackEntry.Animation.Name == "skill3"||trackEntry.Animation.Name == "skill4"||trackEntry.Animation.Name == "skill5")
        {
            IsStand = false;
            IsSkill = false;
        }

        if (isSkill1)
        {
            rigidbody2D.velocity = Vector2.zero;
            IsStand = true;
            IsSkill = true;
            isSkill1 = false;
            monsterSkeletonAnimation.timeScale = 1.4f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill1", false);
        }
        else if (isSkill2)
        {
            rigidbody2D.velocity = Vector2.zero;
            IsStand = true;
            IsSkill = true;
            isSkill2 = false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill2", false);
            monsterSkeletonAnimation.timeScale = 1.5f;
        }
        else if (isSkill3)
        {
            IsSkill = true;
            isSkill3 = false;
            IsStand = true;
            rigidbody2D.velocity = Vector2.zero;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill3", false);
            monsterSkeletonAnimation.timeScale = 1.4f;
        }else if (isSkill4)
        {
            IsSkill = true;
            isSkill4 = false;
            IsStand = true;
            rigidbody2D.velocity = Vector2.zero;
            monsterSkeletonAnimation.timeScale = 1.2f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill5", false);
        }
        else if (isAttack)
        {
            monsterSkeletonAnimation.timeScale = 1.3f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.AttackName, false);
        }
        else
        {
            monsterSkeletonAnimation.timeScale = 1f;
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
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.DieName, false);
        rigidbody2D.velocity = Vector2.zero;
        GeneralDie();
        GetEx();
        //CreateBloodEnergy();
        CreateEquip();
        FightBGController.S.PlaySuccessAnim();
        CreateProp();

        QueueController.S.StartCoroutine(DelayChuanSongMen());
    }
    

    IEnumerator DelayChuanSongMen()
    {
        yield return new WaitForSeconds(1f);
        var chuansongmen = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChuanSongMen"));
        chuansongmen.transform.position =
            new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void Start()
    {
        base.Start();
        size = 1.5f;
        
       
    }

    private void OnDestroy()
    {
        monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
    }

    
    public void CheckCollisionWithMonsters(Collider2D collider2D)
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;

        collider2D.OverlapCollider(filter, results);

        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;

            if (col.CompareTag("Player"))
            {
                QueueController.S.gamePlayer.PlayerHurt(Attack, true);
            }
        }
    }

    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "damage" && trackEntry.Animation.Name == "attack1")
        {
            if (Vector2.Distance(attackTrans.position, QueueController.S.gamePlayer.transform.position) < size ||
                Vector2.Distance(transform.position, QueueController.S.gamePlayer.transform.position) < 1.2f)
            {
                QueueController.S.gamePlayer.PlayerHurt(Attack, true);
            }
        }

        if (e.Data.Name == "damage"&&trackEntry.Animation.Name == "skill2")
        {
            StartCoroutine(DiPen(0.5f, QueueController.S.gamePlayer.transform.position));
        }
        
        if (e.Data.Name == "damage"&&trackEntry.Animation.Name == "skill1")
        {
            CheckCollisionWithMonsters(skill1Tri);
        }
        
        
        if (e.Data.Name == "skill5")
        {
            var pos= QueueController.S.gamePlayer.transform.position;
            GameController.S.CreateCircleAttack(pos,0.8f);
            StartCoroutine(JumpRoutine(0.5f,pos));
        }
        
        if (e.Data.Name == "draw"&&trackEntry.Animation.Name == "skill3")
        {
            //加血
            CurrentHp += MaxHp*0.1f;
            CurrentHp=MathF.Min(CurrentHp, MaxHp);
            hpSlider.maxValue = MaxHp;
            hpSlider.value = CurrentHp;
        }
    }

    private IEnumerator DiPen(float time, Vector2 pos)
    {
        GameController.S.CreateCircleAttack(pos,0.8f);
        yield return new WaitForSeconds(time);
        var dipen = QueueController.S.NiRenDiPenQueue.Dequeue();
        dipen.transform.position = pos;
        dipen.damage = Attack;
        dipen.gameObject.SetActive(true);
    }
    
    
    private IEnumerator JumpRoutine(float time, Vector2 target)
    {
        Vector2 startPos = rigidbody2D.position;
        Vector2 endPos   = target;

        float elapsed = 0f;
        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);

            // 线性插值移动刚体
            Vector2 newPos = Vector2.Lerp(startPos, endPos, t);
            rigidbody2D.MovePosition(newPos);

            yield return null;
        }

        // 确保最后到达精确位置
        rigidbody2D.MovePosition(endPos);
        IsSkill=false;
    }


    public IEnumerator Skill4Dan(int count, float time)
    {
        for (int i = 0; i < count; i++)
        {
            // 生成 0 到 360 度的随机角度（弧度制）
            float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            Vector2 randomDir = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

            var lurendan = QueueController.S.LuRenDanQueue.Dequeue();
            lurendan.transform.position = transform.position;
            lurendan.Damage = Attack*0.8f;
            lurendan.MoveDirection = randomDir;
            lurendan.gameObject.SetActive(true);
            yield return new WaitForSeconds(time);
        }
    }
    

    public void MonsterMove1()
    {
        if (IsStand)
        {
            return;
        }
        Vector3 direction = QueueController.S.gamePlayer.transform.position - transform.position;
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "move" || IsDash)
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

        float dis = Vector2.Distance(transform.position, QueueController.S.gamePlayer.transform.position);
        if (dis < 0.2f)
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
        }
        else
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
        if (IsDead) 
            return;
        base.Update();
        if (!IsSkill)
        {
            currentSkill1Time += Time.deltaTime;
            currentSkill2Time += Time.deltaTime;
            currentSkill3Time += Time.deltaTime;
            currentSkill4Time += Time.deltaTime;

        }

        if (currentSkill1Time > skill1Time)
        {
            currentSkill1Time = 0;
            isSkill1 = true;
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
        
        if (currentSkill4Time > skill4Time)
        {
            currentSkill4Time = 0;
            isSkill4 = true;
        }

        if (Vector2.Distance(attackTrans.position, QueueController.S.gamePlayer.transform.position) < size ||
            Vector2.Distance(transform.position, QueueController.S.gamePlayer.transform.position) < 1.2f)
        {
            isAttack = true;
        }
        else
        {
            isAttack = false;
        }


        if (!IsDead)
        {
            MonsterMove1();
            SpriteFlipX1(false);
        }
    }

}
