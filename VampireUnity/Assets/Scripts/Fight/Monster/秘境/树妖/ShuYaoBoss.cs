using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShuYaoBoss : MonsterBase
{
    public ShuYaoBoss() : base(MonsterTypeByName.ShuYao){
    }

    public Transform attackTrans;
    private float skill1Time = 8;
    private float skill2Time = 20;
    private float skill3Time = 12;
    private float skill4Time = 15;

    private float currentSkill1Time = 5;
    private float currentSkill2Time = 0;
    private float currentSkill3Time = 5;
    private float currentSkill4Time = 7;

    [NonSerialized] public bool IsCiTri1=false;
    [NonSerialized] public bool IsCiTri2=false;

    public Collider2D CiTriCollider1;
    public Collider2D CiTriCollider2;
    [NonSerialized]public bool IsStand=false;
    [NonSerialized]public HashSet<Vector2>Skill4Pos=new HashSet<Vector2>();

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

   


    public IEnumerator CreateSkill4Pos(int count, int dis)
    {
        Skill4Pos.Clear();
        for (int i = 0; i < count; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle * dis;
            Skill4Pos.Add(randomOffset);
        }
        yield return new  WaitForSeconds(1f);
        foreach (var pos in Skill4Pos)
        {
            GameController.S.CreateCircleAttack(pos,0.7f);
        }
    }
    
   
    public void Complete(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == MonsterSpineName.DieName)
        {
            gameObject.SetActive(false);
        }

        if (trackEntry.Animation.Name == "skill3"||trackEntry.Animation.Name == "skill5")
        {
            IsStand=false;
        }
        if (IsDead)
        {
            return;
        }
        monsterSkeletonAnimation.timeScale = 1f;
        if (trackEntry.Animation.Name == "skill1" || trackEntry.Animation.Name == "skill2" ||
            trackEntry.Animation.Name == "skill3"||trackEntry.Animation.Name == "skill4"||trackEntry.Animation.Name == "skill5")
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
            monsterSkeletonAnimation.timeScale = 1.5f;
        }
        else if (isSkill3)
        {
            IsSkill = true;
            isSkill3 = false;
            IsStand = true;
            rigidbody2D.velocity = Vector2.zero;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill3", false);
            monsterSkeletonAnimation.timeScale = 1.2f;
        }else if (isSkill4)
        {
            IsSkill = true;
            isSkill4 = false;
            IsStand = true;
            rigidbody2D.velocity = Vector2.zero;
            StartCoroutine(CreateSkill4Pos(20,10));
            monsterSkeletonAnimation.timeScale = 1.6f;
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

        
        if (e.Data.Name == "skill1_1" && trackEntry.Animation.Name == "skill1")
        {
            CheckCollisionWithMonsters(CiTriCollider1);
        }
        
        if (e.Data.Name == "skill1_2" && trackEntry.Animation.Name == "skill1")
        {
            CheckCollisionWithMonsters(CiTriCollider2);
        }

        if (e.Data.Name == "skill"&& trackEntry.Animation.Name == "skill5")
        {
            StartCoroutine(Skill4(3));
        }
        
        if (e.Data.Name == "skill3_1")
        {
            StartCoroutine(Skill3DanMu(50, 0.03f));
        }

        if (e.Data.Name == "damage" && trackEntry.Animation.Name == "skill2")
        {
            CurrentHp += MaxHp*0.15f;
            CurrentHp=MathF.Min(CurrentHp, MaxHp);
            hpSlider.maxValue = MaxHp;
            hpSlider.value = CurrentHp;
        }
        
    }

    public IEnumerator Skill4(int fream)
    {
        int count = 0;
        foreach (var pos in Skill4Pos)
        {
            count++;
            var item = QueueController.S.TreeManSkillQueue.Dequeue();
            item.transform.position = pos;
            item.damage = Attack;
            item.gameObject.SetActive(true);
            if (count >= fream)
            {
                count = 0;
                yield return null;
            }
        }
    }


    public IEnumerator Skill3DanMu(int count, float time)
    {
        for (int i = 0; i < count; i++)
        {
            // 生成 0 到 360 度的随机角度（弧度制）
            float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            Vector2 randomDir = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

            ShotDanMu(transform.position, ResourcesConfig.DanMu9, Attack, randomDir, true,0.9f);
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

        if (currentSkill1Time > skill1Time&&(IsCiTri1||IsCiTri2))
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
