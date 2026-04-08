using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;

public class YingShu : MonsterBase
{
    public YingShu() : base(MonsterType.Normal, "YingShu", 1, 30000, 1.2f, 800, 500, 250, 25, 0)
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

    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Purple, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Purple, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Purple, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Purple, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Purple, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Purple, 1));
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

    private void  RandomDelayDie()
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
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,3),10));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.JingCui,3),10));
    }
    
    private void Start()
    {
        base.Start();
        isBeatback = false;
        size = 0.5f;
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
        if (e.Data.Name == "damage"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "skill1")
        {
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < 1f)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,false);
            }
        }
    }
    
    void Update()
    {
        if (IsDead) return;
        base.Update();
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < 1f)
        {
            isSkill1=true;
        }
        else
        {
            isSkill1=false;
        }
        
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(false);
        }
    }
}
