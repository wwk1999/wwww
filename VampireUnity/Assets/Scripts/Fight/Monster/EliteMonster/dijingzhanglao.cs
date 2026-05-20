using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;

public class dijingzhanglao : MonsterBase
{
   public Transform attackTrans;

    public dijingzhanglao() : base(MonsterTypeByName.DiJingZhangLao)
    {
    }

    void Start()
    {
        base.Start();
        monsterSkeletonAnimation.timeScale = 1.5f;

        size = EliteYuanChenSize;
        
       
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;

    }

    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "attack")
        {
            NormalYuanChenCurrentTime = 0;
            var dir=(QueueController.S.gamePlayer.transform.position - transform.position).normalized;
            ShotDanMu(attackTrans.position,ResourcesConfig.DanMu1,Attack,dir,false);
        }
    }

    public void Awake()
    {
        base.Awake();
        var randomSpeed = Random.Range(-0.1f, 0.1f);
        Speed += randomSpeed;
        MonsterSpineName.AttackName = "attack";
        MonsterSpineName.HitName = "hurt";
        MonsterSpineName.MoveName = "walk";
        MonsterSpineName.DieName = "die";
        MonsterSpineName.IdleName = "stand";

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

    public override void Die()
    {
        if (monsterSkeletonAnimation != null)
        {
            DelayDestroy();
            var baoxue = QueueController.S.BaoXueQueue.Dequeue();
            baoxue.transform.position=transform.position;
            baoxue.gameObject.SetActive(true);
        }
        float randomDelay = Random.Range(0, 20) * 0.02f;
        Invoke(nameof(RandomDelayDie), randomDelay);
    }



    public override void Skill()
    {
        monsterSkeletonAnimation.AnimationState.SetAnimation(0, "zhiwnag", false);
        IsSkill = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead) return;
        base.Update();
        if (Vector2.Distance(attackTrans.position, QueueController.S.gamePlayer.transform.position) < size&&NormalYuanChenCurrentTime >= NormalYuanChenTime)
        {
            isAttack = true;
        }
        else
        {
            isAttack = false;
        }

        if (!IsDead)
        {
            SpriteFlipX(true);
            MonsterMove();
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
}
