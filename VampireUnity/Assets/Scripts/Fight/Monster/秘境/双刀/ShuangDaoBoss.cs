using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Equip;
using Spine;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShuangDaoBoss : MonsterBase
{
    public ShuangDaoBoss() : base(MonsterTypeByName.ShuangDao){
    }
    
    public Transform attackTrans;
    private float skill1Time = 8;
    private float skill2Time = 8;
    private float skill3Time = 10;
    private float currentSkill1Time = 5;
    private float currentSkill2Time = 5;
    private float currentSkill3Time = 5;

    public Collider2D attackCollider;
    public Collider2D Skill1Collider1;
    public Collider2D Skill1Collider2;
    public Collider2D Skill1Collider3;
    public Collider2D Skill3Collider;

    private Vector2 ShortJumpPos = Vector2.zero;

    
    
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
    
    public void Skill2(Vector2 pos,float dis,float  time,float delayTime,int count)
    {
        StartCoroutine(Skill2Coroutine(pos, dis, time, delayTime,count));
    }

    private IEnumerator Skill2Coroutine(Vector2 pos, float dis, float time, float delayTime,int count)
    {
        for (int i = 0; i < count; i++)
        {
            StartCoroutine(Skill2Item(pos, dis, delayTime));
            // 等待下一个生成
            if (time > 0f)
                yield return new WaitForSeconds(time);
            else
                yield return null;
        }
    }

    IEnumerator Skill2Item(Vector2 pos, float dis, float time)
    {
        Vector2 randomOffset = Random.insideUnitCircle * dis;
        Vector2 spawnPos = pos + randomOffset;

        // 调用创建方法（假设 CreateCircleAttack 接受 Vector2 位置）
        GameController.S.CreateCircleAttack(spawnPos,1f);
        yield return new WaitForSeconds(time);
        ShuangDaoSkill2 huoyan=GameController.S.ShuangDaoSkill2Queue.Dequeue();
        huoyan.transform.position = spawnPos;
        huoyan.damage = Attack;
        huoyan.gameObject.SetActive(true);
    }
    
    
    public void Complete(TrackEntry trackEntry)
    {
        monsterSkeletonAnimation.timeScale = 1f;
        if (trackEntry.Animation.Name == "short jump")
        {
            monsterSkeletonAnimation.timeScale = 2f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill1", false);
            return;
        }
        if (trackEntry.Animation.Name == "skill1" || trackEntry.Animation.Name == "skill2" ||
            trackEntry.Animation.Name == "skill3"|| trackEntry.Animation.Name == "chuchang"|| trackEntry.Animation.Name == "skill4")
        {
            IsSkill = false;
        }

        if (isSkill1)
        {
            IsSkill = true;
            isSkill1 = false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "short jump", false);
            ShortJumpPos=GameController.S.gamePlayer.transform.position;
            GameController.S.CreateCircleAttack(ShortJumpPos,1f);
            monsterSkeletonAnimation.timeScale = 1.5f;
        }
        else if (isSkill2)
        {
            IsSkill = true;
            isSkill2 = false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill2", false);
            Vector2 pos = new Vector2(GameController.S.gamePlayer.transform.position.x,
                GameController.S.gamePlayer.transform.position.y);
            Skill2(pos,8f,0.15f,0.7f,15);
            monsterSkeletonAnimation.timeScale = 1.2f;
        }
        else if (isSkill3)
        {
            IsSkill = true;
            isSkill3 = false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill4", false);
            monsterSkeletonAnimation.timeScale = 1.5f;
        }
        else if (isAttack)
        {
            monsterSkeletonAnimation.timeScale = 2.5f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.AttackName, false);
        }
        else
        {
            monsterSkeletonAnimation.timeScale = 1.3f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.MoveName, false);
        }
    }

    

    public override void Hurt(float damage, bool isCrit, DamageFrom damageFrom)
    {
        base.Hurt(damage, isCrit, damageFrom);
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
       // CreateBloodEnergy();
        CreateEquip();
        CreateProp();
        FightBGController.S.PlaySuccessAnim();
        GameController.S.StartCoroutine(DelayChuanSongMen());
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
        size = 2f;
        
       
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
                GameController.S.gamePlayer.PlayerHurt(Attack, true);
            }
        }
    }

    public void Skill3()
    {
        float waveOffset = Random.Range(0, 30);
        int bulletCount = 12;
        float angleStep = 360f / bulletCount; 
            
        for (int i = 0; i < bulletCount; i++)
        {
            var xieZiSkill1 = GameController.S.ShuangDaoSkill3Queue.Dequeue();
            float angle = i * angleStep + waveOffset;
            float angleRad = angle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
            xieZiSkill1.transform.position = transform.position;
            xieZiSkill1.dir = direction;
            xieZiSkill1.damage = Attack;
            xieZiSkill1.gameObject.SetActive(true);
        }
    }

    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "attack" && trackEntry.Animation.Name == "attack1")
        {
            CheckCollisionWithMonsters(attackCollider);
        }

        if (e.Data.Name == "short jump" && trackEntry.Animation.Name == "short jump")
        {
            StartCoroutine(JumpRoutine(0.4f,ShortJumpPos));
        }

        if (e.Data.Name == "skill1_1" && trackEntry.Animation.Name == "skill1")
        {
            CheckCollisionWithMonsters(Skill1Collider1);
        }
        
        if (e.Data.Name == "skill1_2" && trackEntry.Animation.Name == "skill1")
        {
            CheckCollisionWithMonsters(Skill1Collider2);
        }
        
        if (e.Data.Name == "skill1_3" && trackEntry.Animation.Name == "skill1")
        {
            CheckCollisionWithMonsters(Skill1Collider3);
        }
        
        if (e.Data.Name == "skill4" && trackEntry.Animation.Name == "skill4")
        {
            CheckCollisionWithMonsters(Skill3Collider);
            Skill3();
        }
    }
    

    public void MonsterMove1()
    {
        Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
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

        float dis = Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position);
        if (dis < 0.2f)
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
        }
        else
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
        if (!IsSkill)
        {
            currentSkill1Time += Time.deltaTime;
            currentSkill2Time += Time.deltaTime;
            currentSkill3Time += Time.deltaTime;
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

        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < size ||
            Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 1.2f)
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
