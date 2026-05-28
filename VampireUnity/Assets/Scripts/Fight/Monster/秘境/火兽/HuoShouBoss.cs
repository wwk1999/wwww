using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using Random = UnityEngine.Random;

public class HuoShouBoss : MonsterBase
{
    public HuoShouBoss() : base(MonsterTypeByName.HuoShou){
    }

    public Transform attackTrans;
    private float skill1Time = 12;
    private float skill2Time = 15;
    private float skill3Time = 8;
    private float skill4Time = 10;

    private float currentSkill1Time = 5;
    private float currentSkill2Time = 3;
    private float currentSkill3Time = 0;
    private float currentSkill4Time = 4;

    [NonSerialized]public bool IsCiTri=false;
    public Collider2D CiTri;
    
    private Vector2 Skill4Pos;
    public Transform skill3Trans;
    [NonSerialized]public Vector2 Skill3Pos;
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
            trackEntry.Animation.Name == "skill3"||trackEntry.Animation.Name == "skill4")
        {
            IsSkill = false;
        }

        if (isSkill1)
        {
            IsSkill = true;
            isSkill1 = false;
            monsterSkeletonAnimation.timeScale = 1.4f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill1", false);
        }
        else if (isSkill2)
        {
            IsSkill = true;
            isSkill2 = false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill2", false);
            monsterSkeletonAnimation.timeScale = 1.2f;
        }
        else if (isSkill3)
        {
            IsSkill = true;
            isSkill3 = false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill3", false);
            monsterSkeletonAnimation.timeScale = 1.2f;
        }else if (isSkill4)
        {
            IsSkill = true;
            isSkill4 = false;
            monsterSkeletonAnimation.timeScale = 2f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill4", false);
            Skill4Pos=QueueController.S.gamePlayer.transform.position;
            GameController.S.CreateCircleAttack(Skill4Pos,0.8f);
        }
        else if (isAttack)
        {
            monsterSkeletonAnimation.timeScale = 1.5f;
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

    private IEnumerator JumpRoutine(float time, Vector2 target)
    {
        Vector2 startPos = rigidbody2D.position;
        Vector2 endPos = target;

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
        IsSkill = false;
    }

    public void CheckCollisionWithMonsters()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;

        CiTri.OverlapCollider(filter, results);

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

        
        if (e.Data.Name == "damage" && trackEntry.Animation.Name == "skill1")
        {
            CheckCollisionWithMonsters();
        }

        if (e.Data.Name == "skill4_1")
        {
            StartCoroutine(JumpRoutine(0.8f, Skill4Pos));
        }
        
        if (e.Data.Name == "skill3_1")
        {
            var huoshoudan = QueueController.S.HuoShouDanQueue.Dequeue();
            huoshoudan.transform.position = skill3Trans.position;
            Skill3Pos=QueueController.S.gamePlayer.transform.position;
            GameController.S.CreateCircleAttack(Skill3Pos, 0.8f);
            huoshoudan.pos = Skill3Pos;
            huoshoudan.damage = Attack;
            huoshoudan.gameObject.SetActive(true);
        }

        if (e.Data.Name == "draw" && trackEntry.Animation.Name == "skill2")
        {
            StartCoroutine(Skill2Coroutine(Vector2.zero, 10, 0.05f, 50));
        }
        
    }
    
    private IEnumerator Skill2Coroutine(Vector2 pos, float dis, float time, int count)
    {
        for (int i = 0; i < count; i++)
        {
            // 随机点：Random.insideUnitCircle 返回单位圆内随机点，乘以 dis 后移到指定半径范围
            Vector2 randomOffset = Random.insideUnitCircle * dis;
            Vector2 spawnPos = pos + randomOffset;

            // 调用创建方法（假设 CreateCircleAttack 接受 Vector2 位置）
            GameController.S.CreateCircleAttack(spawnPos,0.5f);
            HuoShouDiPen huoyan=QueueController.S.HuoShouDiPenQueue.Dequeue();
            huoyan.transform.position = spawnPos;
            huoyan.damage = Attack;
            huoyan.gameObject.SetActive(true);
            // 等待下一个生成
            if (time > 0f)
                yield return new WaitForSeconds(time);
            else
                yield return null;
        }
    }


    

    public void MonsterMove1()
    {
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
        if (IsDead) return;
        base.Update();
        if (!IsSkill)
        {
            currentSkill1Time += Time.deltaTime;
            currentSkill2Time += Time.deltaTime;
            currentSkill3Time += Time.deltaTime;
            currentSkill4Time += Time.deltaTime;

        }

        if (currentSkill1Time > skill1Time&&IsCiTri)
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
