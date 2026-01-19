using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;

public class XueRen : MonsterBase
{
     public XueRen() : base(MonsterType.Normal, "XueRen", 1, 7000, 0.6f, 800, 200, 50, 5, 0)
    {
    }
    
    public Transform skillTransform;

    private float currentAttackTime = 0;
    private float attackTime = 3;
    
    
    public void Awake()
    {
        base.Awake();
        var randomSpeed=Random.Range(-0.1f,0.1f);
        Speed+=randomSpeed;
        MonsterSpineName.AttackName = "attack1";
        MonsterSpineName.HitName = "injured";
        MonsterSpineName.MoveName = "move";
        MonsterSpineName.DieName = "fail";
    }

    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.ZhaoZe, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.ZhaoZe, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.ZhaoZe, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.ZhaoZe, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.ZhaoZe, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.ZhaoZe, 1));
    }
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,3),5));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,3),5));
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

    private void  RandomDelayDie()
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
        isBeatback = false;
        size = 4f;
        AddMonsterEquip();
        AddMonsterProp();
        monsterSkeletonAnimation.AnimationState.Complete += OnAnimationComplete1;
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
    }

    public void OnAnimationComplete1(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name ==MonsterSpineName.DieName)
        {
            gameObject.SetActive(false);
            return;
        }

        if (isAttack)
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.AttackName, false);
            isAttack=false;
        }
        else if(Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < size)
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "idle", false);
        }
        else
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.MoveName, false);
        }
    }
    
    private void OnDestroy()
    {
        monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
    }
    
    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "attack_attack1"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "attack1")
        {
            var xuerenjian=GameController.S.XueRenJianQueue.Dequeue();
            xuerenjian.damage = Attack;
            xuerenjian.transform.position = skillTransform.position;
            xuerenjian.gameObject.SetActive(true);
        }
    }
    
    public void MonsterMove1()
    {
        if (Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < size)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
        Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == MonsterSpineName.MoveName||IsDash)
        {
            GetComponent<Rigidbody2D>().velocity = direction.normalized * Speed; 
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = direction.normalized * 0; 
        }
    }

    void Update()
    {
        if (IsDead) return;
        base.Update();
        currentAttackTime+=Time.deltaTime;
        if (currentAttackTime>attackTime&&Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) <= size)
        {
            currentAttackTime = 0;
            isAttack=true;
        }
       
        
        if (!IsDead)
        {
            MonsterMove1();
            SpriteFlipX(false);
        }
    }
}
