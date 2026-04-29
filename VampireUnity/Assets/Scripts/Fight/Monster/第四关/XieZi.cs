using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;

public class XieZi : MonsterBase
{
    public XieZi() : base(MonsterTypeByName.XieZi)
    {
    }
    
     public GameObject parent;
     public Transform attackTrans;
     public Transform skill1Trans;
     private float attackRange = 1.5f;
     private float skill1Time = 12;
     private float skill2Time = 20;
     private float skill4Time = 10;
     private float currentSkill1Time = 0;
     private float currentSkill2Time = 0;
     private float currentSkill4Time = 0;
     public Collider2D collider2D;
     private bool IsSkill4 = false;

    
    public  void Awake()
    {
        base.Awake();
        MonsterSpineName.IdleName = "idle";

        MonsterSpineName.AttackName = "attack1";
        MonsterSpineName.HitName = "injured";
        MonsterSpineName.MoveName = "move";
        MonsterSpineName.DieName = "fail";
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
        monsterSkeletonAnimation.AnimationState.Complete += Complete;
    }

    IEnumerator DelayShow(float time,Vector2 pos)
    {
        yield return new WaitForSeconds(time);
        transform.position = pos;
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill3", false);
    }
    
    public void Complete(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "skill2")
        {
            collider2D.tag = "Bullet"; 
            var pos = GameController.S.gamePlayer.transform.position;
            GameController.S.CreateCircleAttack(pos,1);
            StartCoroutine(DelayShow(1, pos));
            return;
        }
        if (trackEntry.Animation.Name == "chuchang"||trackEntry.Animation.Name == "skill1"||trackEntry.Animation.Name == "skill2"||trackEntry.Animation.Name == "skill3")
        {
            IsSkill=false;
        }
        
        if (isSkill1)
        {
            IsSkill=true;
            isSkill1=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill1", false);
        }else if (isSkill2)
        {
            IsSkill=true;
            isSkill2=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill2", false);
        }
        else if(IsSkill4)
        {
            IsSkill=true;
            IsSkill4=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill4", false);
        }
        else if(isAttack)
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.AttackName, false);
        }
        else
        {
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
        GameController.S.StartCoroutine(DelayChuanSongMen());
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
        size = 1.4f;
        
       
    }
    
    private void OnDestroy()
    {
        monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
    }

    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "attack_attack1"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "attack1")
        {
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < attackRange)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,false);
            }
        }
        if (e.Data.Name == "attack_skill1"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "skill1")
        {
            float waveOffset = Random.Range(0, 30);
            int bulletCount = 10;
            float angleStep = 360f / bulletCount; 
            
            for (int i = 0; i < bulletCount; i++)
            {
                var xieZiSkill1 = GameController.S.XieZiSkill1Queue.Dequeue();
                float angle = i * angleStep + waveOffset;
                float angleRad = angle * Mathf.Deg2Rad;
                Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
                xieZiSkill1.transform.position = skill1Trans.position;
                xieZiSkill1.MoveDirection = direction;
                xieZiSkill1.Damage = Attack;
                xieZiSkill1.gameObject.SetActive(true);
            }
        }
        
        if (e.Data.Name == "attack_skill3"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "skill3")
        {
            collider2D.tag="Monster";
            if (Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 2)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,true);
            }
        }
        
        if (e.Data.Name == "attack_skill4"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "skill4")
        {
            StartCoroutine(ShuiSkill());
        }
    }
    
    IEnumerator ShuiSkill()
    {
        StartCoroutine(DelayShui(GameController.S.gamePlayer.transform.position));
        yield return  new WaitForSeconds(1f);
        StartCoroutine(DelayShui(GameController.S.gamePlayer.transform.position));
        yield return  new WaitForSeconds(1f);
        StartCoroutine(DelayShui(GameController.S.gamePlayer.transform.position));
    }

    IEnumerator DelayShui(Vector2 pos)
    {
        GameController.S.CreateCircleAttack(pos,0.7f);
        yield return  new WaitForSeconds(1f);
        var shui = GameController.S.XieZiSkill4Queue.Dequeue();
        shui.transform.position = pos;
        shui.gameObject.SetActive(true);
        shui.damage = Attack;
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
        currentSkill4Time+=Time.deltaTime;
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

        if (currentSkill4Time > skill4Time)
        {
            currentSkill4Time = 0;
            IsSkill4 = true;
        }
        
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < attackRange)
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
            SpriteFlipX1(true);
        }
    }
}
