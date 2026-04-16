using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;

public class kulou2 : MonsterBase
{
   public Transform attackTrans;

    public kulou2() : base(MonsterTypeByName.KuLou2)
    {
    }

    void Start()
    {
        base.Start();
        monsterSkeletonAnimation.timeScale = 1.5f;

        size = 5f;
        AddMonsterEquip();
        AddMonsterProp();
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;

    }

    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "attack")
        {
            var dir=(GameController.S.gamePlayer.transform.position - transform.position).normalized;
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
            var baoxue = GameController.S.BaoXueQueue.Dequeue();
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
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < size)
        {
            if (NormalYuanChenCurrentTime >= NormalYuanChenTime)
            {
                isAttack = true;
                NormalYuanChenCurrentTime = 0;
            }
        }
        else
        {
            isAttack = false;
        }

        if (!IsDead)
        {
            SpriteFlipX(true);
        }
        
        if (!IsDead && Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < size)
        {
            MonsterMove();
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }

    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment, 1), 3));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang, 1), 3));
    }

    public override void AddMonsterEquip()
    {

        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak, PlayerEquipConfig.EquipLevel.Primary,
            1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth, PlayerEquipConfig.EquipLevel.Primary,
            1));
        MonsterEquipList.Add(
            new MonsterEquip(PlayerEquipConfig.EquipType.Ring, PlayerEquipConfig.EquipLevel.Primary, 1));
        MonsterEquipList.Add(
            new MonsterEquip(PlayerEquipConfig.EquipType.Shoe, PlayerEquipConfig.EquipLevel.Primary, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,
            PlayerEquipConfig.EquipLevel.Primary, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet, PlayerEquipConfig.EquipLevel.Primary,
            1));
    }

    public override void Hurt(float damage, bool isCrit, DamageFrom damageFrom)
    {
        base.Hurt(damage, isCrit, damageFrom);
        if (!IsDead)
        {
            AudioController.S.PlayBatHit();
        }
    }
}
