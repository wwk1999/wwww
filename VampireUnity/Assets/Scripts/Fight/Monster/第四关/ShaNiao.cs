using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;

public class ShaNiao : MonsterBase
{
    public ShaNiao() : base(MonsterType.Normal, "ShaNiao", 1, 5000, 0.8f, 500, 150, 40, 4, 0)
    {
    }
    public Transform attackTrans;
    private float attackRange = 0.7f;
    public void Awake()
    {
        base.Awake();
        MonsterSpineName.AttackName = "attack1";
        MonsterSpineName.HitName = "injured";
        MonsterSpineName.MoveName = "move";
        MonsterSpineName.DieName = "fail";
        MonsterSpineName.Skill1Name = "skill1";

    }

   

    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Blue, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Blue, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Blue, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Blue, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Blue, 2));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Blue, 2));
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
        if (monsterSkeletonAnimation != null)
        {
            DelayDestroy();
            var baoxue = GameController.S.BaoXueQueue.Dequeue();
            baoxue.transform.position=transform.position;
            baoxue.gameObject.SetActive(true);
        }
        float randomDelay = Random.Range(0, 20) * 0.02f;
        Invoke(nameof(RandomDelayDie), randomDelay);
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
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),5));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,2),5));
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
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < attackRange||Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 0.2f)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,false);
            }
        }
    }

    void Update()
    {
        if (IsDead) return;
        base.Update();
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < attackRange||Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 0.2f)
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
