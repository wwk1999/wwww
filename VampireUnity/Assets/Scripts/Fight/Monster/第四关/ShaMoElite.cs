using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;

public class ShaMoElite : MonsterBase
{
    public ShaMoElite() : base(MonsterTypeByName.ShaChong)
    {
    }
    public Transform skillTrans1;
    public Transform skillTrans2;
    public Transform skillTrans3;
    public Transform attackTrans;

    private float SkillTime = 5;
    private float CurrentSkillTime = 0;
    
    
    
    public void Awake()
    {
        base.Awake();
        MonsterSpineName.AttackName = "attack1";
        MonsterSpineName.HitName = "injured";
        MonsterSpineName.MoveName = "move";
        MonsterSpineName.DieName = "fail";
        MonsterSpineName.Skill1Name = "skill1";

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
        float randomDelay = UnityEngine.Random.Range(0, 20) * 0.02f;
        Invoke(nameof(RandomDelayDie),randomDelay);
    }

    private void RandomDelayDie()
    {
        AudioController.S.PlaySnotDie();
        GeneralDie();
        GetEx();
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy, 2);
        CreateEquip();
        CreateProp();
    }
    
   
    
    private void Start()
    {
        base.Start();
        size = 1f;
        isBeatback = false;
        
       

        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;

    } private void OnDestroy()
    {
        monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
    }
    
    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "damage"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "attack1")
        {
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < 0.8f)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,false);
            }
        }
    }


    void Update()
    {
        if (IsDead) return;
        base.Update();
        CurrentSkillTime += Time.deltaTime;
        if (CurrentSkillTime >= SkillTime&&(Vector2.Distance(GameController.S.gamePlayer.transform.position,skillTrans1.position)<0.6f||Vector2.Distance(GameController.S.gamePlayer.transform.position,skillTrans2.position)<0.6f||Vector2.Distance(GameController.S.gamePlayer.transform.position,skillTrans3.position)<0.6f))
        {
            CurrentSkillTime = 0;
            isSkill1=true;
        }
        else if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < 0.8f)
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
            SpriteFlipX(false);
        }
    }

    public void CheckSkill()
    {
        Invoke(nameof(CheckSkill1),1.1f);
        Invoke(nameof(CheckSkill2),1.3f);
        Invoke(nameof(CheckSkill3),1.5f);
    }

    public void CheckSkill1()
    {
        if (Vector2.Distance(GameController.S.gamePlayer.transform.position, skillTrans1.position) < 0.6f)
        {
            GameController.S.gamePlayer.PlayerHurt(Attack,false);
        }
    }
    
    public void CheckSkill2()
    {
        if (Vector2.Distance(GameController.S.gamePlayer.transform.position, skillTrans2.position) < 0.6f)
        {
            GameController.S.gamePlayer.PlayerHurt(Attack,false);
        }
    }
    
    public void CheckSkill3()
    {
        if (Vector2.Distance(GameController.S.gamePlayer.transform.position, skillTrans3.position) < 0.6f)
        {
            GameController.S.gamePlayer.PlayerHurt(Attack,false);
        }
    }
}
