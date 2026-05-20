using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;

public class KuLou : MonsterBase
{
    public KuLou() : base(MonsterTypeByName.ChaiLangRen2)
    {
    }
    public Transform attackTrans;

   
    
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
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy, 1);
        CreateEquip();
        CreateProp();
    }
    
    private void Start()
    {
        base.Start();
        size = 0.5f;
        isBeatback = false;
        
       

        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
    }
    
    

    private void OnDestroy()
    {
        monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
    }

    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "damage"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "attack1")
        {
            if (Vector2.Distance(attackTrans.position, QueueController.S.gamePlayer.transform.position) < 0.4f||Vector2.Distance(transform.position, QueueController.S.gamePlayer.transform.position) < 0.4f)
            {
                QueueController.S.gamePlayer.PlayerHurt(Attack,false);
            }
        }
    }

    void Update()
    {
        if (IsDead) return;
        base.Update();
        if (Vector2.Distance(attackTrans.position, QueueController.S.gamePlayer.transform.position) < 0.4f||Vector2.Distance(transform.position, QueueController.S.gamePlayer.transform.position) < 0.4f)
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
}
