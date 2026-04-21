using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Equip;
using Spine;
using UnityEngine;

public enum HuoLangSkill2Type
{
    None,
    ChuChang,
    Skill2
}
public class HuoLangBoss : MonsterBase
{
    public HuoLangBoss() : base(MonsterTypeByName.HuoLang){
    }

    public Transform attackTrans;
    private float skill1Time = 12;
    private float skill2Time = 15;
    private float skill3Time = 8;
    private float currentSkill1Time = 5;
    private float currentSkill2Time = 5;
    private float currentSkill3Time = 5;
    public Transform skill3pos;
    public Vector2 skill1Pos = Vector2.zero;
    [NonSerialized]public HuoLangSkill2Type HuoLangSkill2Type=HuoLangSkill2Type.None;

    public Collider2D Skill1Collider2D;
    private List<Vector2> skill2PosList = new List<Vector2>();

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
    
    public void Skill2Pro()
    {
        skill2PosList.Clear();
        Vector2 center = GameController.S.gamePlayer.transform.position;   // (0,0)
        float radius = 10f;

        for (int i = 0; i < 15; i++)
        {
            // 在单位圆内随机一个点，再乘以半径 -> 半径为 12 的圆内
            Vector2 randomInCircle = UnityEngine.Random.insideUnitCircle * radius;
            Vector3 pos = new Vector3(center.x + randomInCircle.x, center.y + randomInCircle.y, 0f);
            skill2PosList.Add(pos);
            GameController.S.CreateCircleAttack(pos,1f);
        }
    }

    public void Skill2Next()
    {
        foreach (var pos in skill2PosList)
        {
            var skill2 = GameController.S.HuoLangSkill2Queue.Dequeue();
            skill2.transform.position = pos;
            skill2.damage = Attack;
            skill2.gameObject.SetActive(true);
        }
    }

    public void Complete(TrackEntry trackEntry)
    {
        monsterSkeletonAnimation.timeScale = 1f;
        if (trackEntry.Animation.Name == "skill1" || trackEntry.Animation.Name == "skill2" ||
            trackEntry.Animation.Name == "skill3")
        {
            IsSkill = false;
        }

        if (isSkill1)
        {
            IsSkill = true;
            isSkill1 = false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill1", false);
            skill1Pos = GameController.S.gamePlayer.transform.position;
            GameController.S.CreateCircleAttack(skill1Pos,1f);
        }
        else if (isSkill2)
        {
            IsSkill = true;
            isSkill2 = false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill2", false);
            Skill2Pro();
            monsterSkeletonAnimation.timeScale = 1.2f;
        }
        else if (isSkill3)
        {
            IsSkill = true;
            isSkill3 = false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill3", false);
            monsterSkeletonAnimation.timeScale = 1.2f;
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

        Skill1Collider2D.OverlapCollider(filter, results);

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

    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "damage" && trackEntry.Animation.Name == "attack1")
        {
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < size ||
                Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 1.2f)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack, true);
            }
        }

        if (e.Data.Name == "damage" && trackEntry.Animation.Name == "skill3")
        {
            HuoLangSkill3Dan HuoLangSkill3Dan=Instantiate(Resources.Load<GameObject>("Prefabs/Monster/MJ/HuoLang/HuoLangSkill3Dan").GetComponent<HuoLangSkill3Dan>());
            HuoLangSkill3Dan.transform.position = skill3pos.position;
            HuoLangSkill3Dan.damage = Attack;
            Vector2 dir=(GameController.S.gamePlayer.transform.position-transform.position).normalized;
            HuoLangSkill3Dan.pos=GameController.S.gamePlayer.transform.position;
            GameController.S.CreateCircleAttack(GameController.S.gamePlayer.transform.position,1f);
        }

        if (e.Data.Name == "damage" && trackEntry.Animation.Name == "skill1")
        {
            StartCoroutine(JumpRoutine(0.4f, skill1Pos));
        }

        if (e.Data.Name == "damage3" && trackEntry.Animation.Name == "skill1")
        {
            CheckCollisionWithMonsters();
        }
        
        if (e.Data.Name == "damage" && trackEntry.Animation.Name == "skill2")
        {
            Skill2Next();
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
