using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class HuoShanBoss : MonsterBase
{
    public HuoShanBoss() : base(MonsterTypeByName.HuoShanBoss) { }
    public Transform attackTrans;
    public Collider2D skill3Collider;
    [NonSerialized]public float Skill1Time= 3f;
    [NonSerialized]public float Skill1CurrentTime = 0f;
    [NonSerialized]public float Skill2Time = 10f;
    [NonSerialized]public float Skill2CurrentTime = 0f;
    [NonSerialized]public float Skill3Time = 8f;
    [NonSerialized]public float Skill3CurrentTime = 0f;
    [NonSerialized]public State CurrentState = State.Move;


    public void Start()
    {
        base.Start();
        
       
    }
    
    public  void Awake()
    {
        base.Awake();
        size = 1.2f;
        MonsterSpineName.IdleName = "idle";

        MonsterSpineName.AttackName = "attack";
        MonsterSpineName.HitName = "hit";
        MonsterSpineName.MoveName = "walk";
        MonsterSpineName.DieName = "die";
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
        monsterSkeletonAnimation.AnimationState.Complete += Complete;
    }

    public void CheckCollider()
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
    
    public void Complete(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "Exit"||trackEntry.Animation.Name == "skill_01"||trackEntry.Animation.Name == "skill_02"||trackEntry.Animation.Name == "skill_03")
        {
            IsSkill=false;
        }
        
        if (isSkill1)
        {
            IsSkill=true;
            isSkill1=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_01", false);
        }else if (isSkill2)
        {
            IsSkill=true;
            isSkill2=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_02", false);
        }else if (isSkill3)
        {
            IsSkill=true;
            isSkill3=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_03", false);
        } else if(isAttack)
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.AttackName, false);
        }
        else
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.MoveName, false);
        }
    }

    public void Skill2(Vector2 pos,float dis,float  time,int count)
    {
        StartCoroutine(Skill2Coroutine(pos, dis, time, count));
    }

    private IEnumerator Skill2Coroutine(Vector2 pos, float dis, float time, int count)
    {
        for (int i = 0; i < count; i++)
        {
            // 随机点：Random.insideUnitCircle 返回单位圆内随机点，乘以 dis 后移到指定半径范围
            Vector2 randomOffset = Random.insideUnitCircle * dis;
            Vector2 spawnPos = pos + randomOffset;

            // 调用创建方法（假设 CreateCircleAttack 接受 Vector2 位置）
            GameController.S.CreateCircleAttack(spawnPos,0.6f);
            HuoShanSkill2 huoyan=GameController.S.HuoShanSkill2QiQueue.Dequeue();
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

    public void ShotJianQi()
    {
        var jianqi = GameController.S.HuoShanJianQiQueue.Dequeue();
        jianqi.damage = Attack;
        jianqi.transform.position = attackTrans.position;
        jianqi.gameObject.SetActive(true);
    }
    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "huoyan"&&trackEntry.Animation.Name == "skill_01")
        {
            ShotJianQi();
        }
        if (e.Data.Name == "huoyan"&&trackEntry.Animation.Name == "skill_02")
        {
            Skill2(GameController.S.gamePlayer.transform.position,10,0.05f,50);
        }
        if (e.Data.Name == "huoyan"&&trackEntry.Animation.Name == "skill_03")
        {
            CheckCollider();
        }
    }
    
    public override void Skill() { }
    
    public override void Die()
    {
        GeneralDie();
        GetEx();
        //CreateBloodEnergy();
        CreateEquip();
        CreateProp();
        FightBGController.S.PlaySuccessAnim();
        
        GameController.S.StartCoroutine(DelayChuanSongMen());

    }
    IEnumerator DelayChuanSongMen()
    {
        yield return new WaitForSeconds(1f);
        var chuansongmen = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChuanSongMen"));
        chuansongmen.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    
   
    void Update()
    {
        if(IsDead) return;
        base.Update();
        Skill1CurrentTime+=Time.deltaTime;
        Skill2CurrentTime+=Time.deltaTime;
        Skill3CurrentTime+=Time.deltaTime;
        if (Skill1CurrentTime > Skill1Time&&Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position) > 3)
        {
            Skill1CurrentTime = 0;
            isSkill1 = true;
        }
        if (Skill2CurrentTime > Skill2Time)
        {
            Skill2CurrentTime = 0;
            isSkill2 = true;
        }
        if (Skill3CurrentTime > Skill3Time&&Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position) < 5)
        {
            Skill3CurrentTime = 0;
            isSkill3 = true;
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
