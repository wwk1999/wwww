using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;

public class ShaXiYi : MonsterBase
{
    public ShaXiYi() : base(MonsterType.Elite, "ShaXiYi", 1, 15000, 1.3f, 1000, 300, 200, 20, 0)
    {
    }
    public Transform attackTrans;
    private float attackRange = 1f;
    
    private float skill1Time ;
    private float currentSkill1Time = 0f;
    public float hideTime = 0; 

    public void Awake()
    {
        base.Awake();
        skill1Time = Random.Range(8, 12);
        MonsterSpineName.AttackName = "attack1";
        MonsterSpineName.HitName = "injured";
        MonsterSpineName.MoveName = "move";
        MonsterSpineName.DieName = "fail";
        MonsterSpineName.Skill1Name = "stealth";
    }
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.ZhaoZe, 3));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.ZhaoZe, 3));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.ZhaoZe, 3));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.ZhaoZe, 3));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.ZhaoZe, 3));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.ZhaoZe, 3));
    }
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,3),10));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,3),10));
    }

   public override void Hurt(float damage,bool isCrit,DamageFrom damageFrom)
    {
        base.Hurt(damage,isCrit,damageFrom);
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
        AddMonsterEquip();
        AddMonsterProp();

        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
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
    }

    void Update()
    {
        if (IsDead) return;
        hideTime-=Time.deltaTime;
        currentSkill1Time+=Time.deltaTime;

        if (currentSkill1Time > skill1Time)
        {
            currentSkill1Time = 0;
            isSkill1=true;
        }
        base.Update();
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < attackRange)
        {
            monsterSkeletonAnimation.timeScale = 1.5f;
            isAttack=true;
        }
        else
        {
            monsterSkeletonAnimation.timeScale = 1.2f;
            isAttack=false;
        }
        
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(true);
        }
    }
}
