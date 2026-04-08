using System;
using System.Collections;
using Equip;
using Spine;
using UnityEngine;
using Random = UnityEngine.Random;

public class BatMonster : MonsterBase
{
    //[NonSerialized]public bool IsTrigger;
    [NonSerialized]public float attackTime = 3f;
    [NonSerialized]public float currentTime = 0f;
    public Transform attackTrans;

    public BatMonster() : base(MonsterType.Normal, "BatMonster", 1, 100, 0.6f, 15, 5, 10, 1, 0) { }
    void Start()
    {
        base.Start();
        monsterSkeletonAnimation.timeScale = 1.5f;
        size = 0.5f;
        AddMonsterEquip();
        AddMonsterProp();
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;

    }
    
    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "attack")
        {
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) <= size)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,false);
            }
        }
    }

    public void Awake()
    {
        base.Awake();
        var randomSpeed=Random.Range(-0.1f,0.1f);
        Speed+=randomSpeed;
        MonsterSpineName.AttackName = "attack";
        MonsterSpineName.HitName = "hit";
        MonsterSpineName.MoveName = "walk";
        MonsterSpineName.DieName = "die";
    }
   
    public override void Skill()
    {
        // Implement the skill logic here
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead) return;
        base.Update();
        if (Speed == 8&&Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position)<0.6f)
        {
            GameController.S.gamePlayer.PlayerHurt(Attack,false);
        }
        
        
        float distance = Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position);
        currentTime+= Time.deltaTime;
        if(currentTime>= attackTime&&distance<2.6f)
        {
            AttackBegin();
            currentTime = 0f;
        }
        if (!IsDead&&!IsDash)
        {
            MonsterMove();
            SpriteFlipX(false);
        }
    }

    

    public void AttackBegin()
    {
        transform.Find("MonsterWarning").gameObject.SetActive(true);
        transform.Find("MonsterWarning").GetComponent<Animator>().Play("MonsterWarning");
        IsDash = true;
         Speed = 0;
    }

    private void RandomDelayDie()
    {
        AudioController.S.PlaySnotDie();
        GeneralDie();
        GetEx();
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy,1);
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
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,1),3));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,1),3));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.HH,1),100));

    }

    public override void AddMonsterEquip()
{
    
    MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Purple, 100));
    MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Primary, 1));
    MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Primary, 1));
    MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Primary, 1));
    MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Primary, 1));
    MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Primary, 1));
    
    MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Primary, 2));
    MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Primary, 2));
    MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Primary, 2));
    MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Primary, 2));
    MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Primary, 2));
    MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Primary, 2));
    
    // 防御词条

    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.FinalDamageReductionFixed, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.FinalDamageReductionPercent, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.AllReplyAddPercent, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.AddHpForTime, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.AddDefenseForTime, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.ReplyDeath, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.DelayDamage, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.HpReductionReplyAdd50, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.HpReductionAddDefense, 100));
    
     /*
    // 攻击词条
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.FinalDamageAddPercent, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.KillNormal, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.AddAttackForTime, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.NormalAddDamage, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.RecudeHpAddAttack, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.JianSuAddAttack, 100));
    
    // 普通攻击
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.FanPuGuiZhen, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.NoSkill, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.BuWangChuXin, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.HeiDongAddSpeed, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.DuAddDuQuan, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.LvQuanAddScale, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.XuKongAdd2Dan, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.PuTong3ChuanTou, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.FireBaoZha, 100));
    
    // Skill1
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill1ReplaceNormalAttack, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill1YiDianDouble, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill1AddRange, 100));
    
    // Skill2
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill2AddDan, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill2RotateAdd, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill2AddRange, 100));
    
    // Skill3
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill3Bian3, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.Skill3AddRange, 100));
    
    // Dash
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.DashCd, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.DashRange, 100));
    
    // 特殊词条
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.MoveSpeedAdd, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.ExAdd, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.ClothFortureAdd, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.ShoeFortureAdd, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.CloakFortureAdd, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.NecklaceFortureAdd, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.RingFortureAdd, 100));
    MonsterOrangeEntryEquip.Add(new MonsterOrangeEntryEquip(EntryConfig.OrangeEntry.HelmetFortureAdd, 100));
    */
}
    
   public override void Hurt(float damage,bool isCrit,DamageFrom damageFrom)
    {
        base.Hurt(damage,isCrit,damageFrom);
        if (!IsDead)
        {
            AudioController.S.PlayBatHit();
        }
    }
}
