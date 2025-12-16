using System;
using System.Collections.Generic;
using System.Diagnostics;
using Equip;
using Mysql;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class GameController : XSingleton<GameController>
{
    [NonSerialized] public float GameMaxHp = 0;
    [NonSerialized] public float GameCurrentHp = 0;
    [NonSerialized] public float GameDefense = 0;
    [NonSerialized] public float GameAttack = 0;
    [NonSerialized] public float GameCrit = 0;
    [NonSerialized] public float OrangeEntryTime = 5f;
    [NonSerialized] public float CurrentOrangeEntryTime = 0f;
    [NonSerialized] public bool isFuHuo = true;
    
    [NonSerialized] public  float TotalAddHp = 0;
    [NonSerialized] public  float TotalAddDefense = 0;
    [NonSerialized] public  float TotalAddAttack = 0;
    

    //碰撞字典
    [NonSerialized] public Dictionary<Collider2D, MonsterBase> MonsterColliderDic = new Dictionary<Collider2D, MonsterBase>();

    
    //怪物数量排行榜相关
    [NonSerialized] public int NormalCount = 0;
    [NonSerialized] public int EliteCount = 0;
    [NonSerialized] public int BossCount = 0;
    
    
    
    
    private float distanceUpdateTimer = 0f;
    [NonSerialized]public Player gamePlayer;
    [NonSerialized]public GameObject MonsterBirthPoint1;
    [NonSerialized]public GameObject MonsterBirthPoint2;
    [NonSerialized]public GameObject MonsterBirthPoint3;
    [NonSerialized]public GameObject PlayerBirthPoint1;
    [NonSerialized]public GameObject PlayerBirthPoint2;
    //怪物相关
    public SnotMonster snotMonster;
    public BatMonster batMonster;
    public SpiderMonster spiderMonster;
    public EliteBeeMonster elitebeeMonster;
    
    //Boss攻击提示对象池
    [NonSerialized] public Queue<CircleAttack> CircleQueue = new Queue<CircleAttack>();
    [NonSerialized] public Queue<SqrtAttack> SqrtQueue = new Queue<SqrtAttack>();

    //第一关怪
    [NonSerialized] public Queue<SnotMonster> SnotMonsterQueue = new Queue<SnotMonster>();
    [NonSerialized] public Queue<EliteBeeMonster> EliteBeeMonsterQueue = new Queue<EliteBeeMonster>();
    [NonSerialized] public Queue<BatMonster> BatMonsterQueue = new Queue<BatMonster>();
    [NonSerialized] public Queue<SpiderMonster> SpiderMonsterQueue = new Queue<SpiderMonster>();
    //[NonSerialized]public Queue<BatAttackTrigger> BatAttackTriggerQueue = new Queue<BatAttackTrigger>();
    [NonSerialized]public Queue<BeeMonsterSkillTrigger> BeeMonsterSkillTriggerQueue = new Queue<BeeMonsterSkillTrigger>();
    
    //第二关怪
    [NonSerialized] public Queue<ChongZiMonster> ChongZiMonsterQueue = new Queue<ChongZiMonster>();
    [NonSerialized] public Queue<DunDiMonster> DunDiMonsterQueue = new Queue<DunDiMonster>();
    [NonSerialized] public Queue<XiaoHuoMonster> XiaoHuoMonsterQueue = new Queue<XiaoHuoMonster>();
    [NonSerialized] public Queue<EliteDaZuiMonster> EliteDaZuiMonsterQueue = new Queue<EliteDaZuiMonster>();
    [NonSerialized] public Queue<XiNiuMonster> XiNiuMonsterQueue = new Queue<XiNiuMonster>();

  
    [NonSerialized]public Queue<DaZuiSkillTriggerLeft> DaZuiSkillTriggerQueueLeft = new Queue<DaZuiSkillTriggerLeft>();
    [NonSerialized]public Queue<DaZuiSkillTriggerRight> DaZuiSkillTriggerQueueRight = new Queue<DaZuiSkillTriggerRight>();
    
    
    //第三关怪
    [NonSerialized] public Queue<JiaChongMonster> JiaChongMonsterQueue = new Queue<JiaChongMonster>();
    [NonSerialized] public Queue<WenZiMonster> WenZiMonsterQueue = new Queue<WenZiMonster>();
    [NonSerialized] public Queue<QingWaMonster> QingWaMonsterQueue = new Queue<QingWaMonster>();
    [NonSerialized] public Queue<ShiRenHuaMonster> ShiRenHuaMonsterQueue = new Queue<ShiRenHuaMonster>();


    //第四关怪
    [NonSerialized] public Queue<Huangzhu> HuangZhuQueue = new Queue<Huangzhu>();
    [NonSerialized] public Queue<HuangShu> HuangShuQueue = new Queue<HuangShu>();
    [NonSerialized] public Queue<KuLou> KuLouQueue = new Queue<KuLou>();
    [NonSerialized] public Queue<ShaMoElite> ShaMoEliteQueue = new Queue<ShaMoElite>();
    
    [NonSerialized] public Queue<ShaChong> ShaChongQueue = new Queue<ShaChong>();
    [NonSerialized] public Queue<ShaNiao> ShaNiaoQueue = new Queue<ShaNiao>();
    [NonSerialized] public Queue<ShaXiYi> ShaXiYiQueue = new Queue<ShaXiYi>();
    [NonSerialized] public Queue<XianRenZhang> XianRenZhangQueue = new Queue<XianRenZhang>();
    [NonSerialized] public Queue<XieZiSkill1> XieZiSkill1Queue = new Queue<XieZiSkill1>();


    //第五关怪
    [NonSerialized] public Queue<XueQiE> XueQiEQueue = new Queue<XueQiE>();
    [NonSerialized] public Queue<YingShu> YingShuQueue = new Queue<YingShu>();

    
    
    
    //子弹队列
    [NonReorderable]public Queue<GameObject>ThreeNormalAttackQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ThreeNormalAttackHitQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>FourNormalAttackQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>FourNormalAttackHitQueue = new Queue<GameObject>();
    
    
    [NonReorderable]public Queue<GameObject>FirePengQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>FireQueue = new Queue<GameObject>();
    
    [NonReorderable]public Queue<GameObject>XuKongPengQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>XuKongQueue = new Queue<GameObject>();

    [NonReorderable]public Queue<GameObject>LvQuanQueue = new Queue<GameObject>();

    [NonReorderable]public Queue<GameObject>HeiDongQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HeiDongNextQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HeiDongPengQueue = new Queue<GameObject>();
    
    [NonReorderable]public Queue<GameObject>DuQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>DuPengQueue = new Queue<GameObject>();


    [NonReorderable]public Queue<GameObject>LuoLeiQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>LuoLeiPengQueue = new Queue<GameObject>();

    [NonReorderable]public Queue<GameObject>PuTong3Queue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PuTong3PengQueue = new Queue<GameObject>();
    
    
    //技能队列
    [NonReorderable]public Queue<GameObject>DianQuanQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>DianQuanPengQueue = new Queue<GameObject>();

    
    
    
    //血能对象池队列
    [NonReorderable]public Queue<GameObject>BloodEnergyQueue = new Queue<GameObject>();
    //怪物伤害文本对象池队列
    [NonReorderable]public Queue<MonsterHurtText>MonsterHurtTextQueue = new Queue<MonsterHurtText>();

    
    
    //武器对象池
    [NonReorderable]public Queue<GameObject>WhiteWeaponFragmengQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>GreenWeaponFragmengQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>BlueWeaponFragmengQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PurpleWeaponFragmengQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>OrangeWeaponFragmengQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>RedWeaponFragmengQueue = new Queue<GameObject>();
    
    
    
    //装备对象池
    [NonReorderable]public Queue<GameObject>PrimaryCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PrimaryClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PrimaryRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PrimaryHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PrimaryNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PrimaryShoeQueue = new Queue<GameObject>();
    
    [NonReorderable]public Queue<GameObject>GreenCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>GreenClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>GreenRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>GreenHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>GreenNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>GreenShoeQueue = new Queue<GameObject>();
    
    [NonReorderable]public Queue<GameObject>BlueCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>BlueClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>BlueRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>BlueHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>BlueNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>BlueShoeQueue = new Queue<GameObject>();
    
    [NonReorderable]public Queue<GameObject>TreeManCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>TreeManClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>TreeManRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>TreeManHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>TreeManNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>TreeManShoeQueue = new Queue<GameObject>();
    
    [NonReorderable]public Queue<GameObject>HuoShanCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HuoShanClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HuoShanRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HuoShanHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HuoShanNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HuoShanShoeQueue = new Queue<GameObject>();
    
    [NonReorderable]public Queue<GameObject>PurpleCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PurpleClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PurpleRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PurpleHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PurpleNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PurpleShoeQueue = new Queue<GameObject>();
    
    [NonReorderable]public Queue<GameObject>OrangeCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>OrangeClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>OrangeRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>OrangeHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>OrangeNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>OrangeShoeQueue = new Queue<GameObject>();
    
    //传说装备
  
    [NonReorderable]public Queue<GameObject>FinalDamageReductionFixedQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>FinalDamageReductionPercentQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>AllReplyAddPercentQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>AddHpForTimeQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>AddDefenseForTimeQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ReplyDeathQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>DelayDamageQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HpReductionReplyAdd50Queue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HpReductionAddDefenseQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>FinalDamageAddPercentQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>KillNormalQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>AddAttackForTimeQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>NormalAddDamageQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>RecudeHpAddAttackQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>JianSuAddAttackQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>FanPuGuiZhenQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>NoSkillQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>BuWangChuXinQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HeiDongAddSpeedQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>DuAddDuQuanQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>LvQuanAddScaleQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>XuKongAdd2DanQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PuTong3ChuanTouQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>FireBaoZhaQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>Skill1ReplaceNormalAttackQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>Skill1YiDianDoubleQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>Skill1AddRangeQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>Skill2AddDanQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>Skill2RotateAddQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>Skill2AddRangeQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>Skill3Bian3Queue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>Skill3AddRangeQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>DashCdQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>DashRangeQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>MoveSpeedAddQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ExAddQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ClothFortureAddQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ShoeFortureAddQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>CloakFortureAddQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>NecklaceFortureAddQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>RingFortureAddQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HelmetFortureAddQueue = new Queue<GameObject>();





   
    //怪物数量
    [NonSerialized]public int NormalMonsterCount=0;
    [NonSerialized]public int EliteMonsterCount=0;
    [NonSerialized]public int TotalMonsterCount=0;
    [NonSerialized]public int DieNormalMonsterCount=0;
    [NonSerialized]public int DieEliteMonsterCount=0;

    
    
    [NonSerialized] public List<MonsterBase> FirstlevelMonsterList= new List<MonsterBase>();
    
    
    public float monsterBirthTimeScale = 1f; //间隔一秒钟生成一个怪物
    public float currentTime = 0f;
    public GameObject fightBG;
    [NonSerialized]public Transform[] MonsterBirthPoints1;
    [NonSerialized]public Transform[] MonsterBirthPoints2;
    [NonSerialized]public Transform[] MonsterBirthPoints3;
    [NonSerialized]public Transform[] PlayerBirthPoints;
    //怪物探测器，检测最近的怪物
    public HashSet<MonsterBase> monsterDetetor1 = new HashSet<MonsterBase>();
    public HashSet<MonsterBase> monsterDetetor2 = new HashSet<MonsterBase>();
    public HashSet<MonsterBase> monsterDetetor3 = new HashSet<MonsterBase>();
    public HashSet<MonsterBase> monsterDetetor4 = new HashSet<MonsterBase>();

    //最近怪物位置
    public Vector3 nearMonsterPosition;
    //怪物血条
    public GameObject monsterHpSliderPrefabs;
    //战斗时间文本
    public float fightTime;//秒为单位
    public GameObject fightTimeTextPrefab;
    public Text fightTimeText;
    //Boss相关
    [NonSerialized]public int BossEnergyNum=0;
    [NonSerialized]public int MaxBossEnergyNum;//Boss能量
    [NonSerialized]public bool HaveBoss=false;
    [NonSerialized]public bool BossJiHuo=false;
    [NonSerialized]public bool HaveBossWarning=false;
    [NonSerialized]public MonsterBase CurrentBoss;
    [NonSerialized]public bool GameOver=false;
    
    //武器源石列表
    [NonSerialized]public List<SourceStoneTable> WeaponSourceStoneList = new List<SourceStoneTable>();
    
    //杀死怪物数量
    [NonSerialized]public int KillMonsterCount=0;


    public void CreateCircleAttack(Vector2 pos)
    {
        var circle=CircleQueue.Dequeue();
        circle.transform.position = pos;
        circle.gameObject.SetActive(true);
    }
    
    public void CreateSqrtAttack(Vector2 pos, Vector2 dir)
    {
        var sqrt = SqrtQueue.Dequeue();
        sqrt.transform.position = pos;
        sqrt.gameObject.SetActive(true);
        if (dir.sqrMagnitude > 0.0001f)
        {
            dir = dir.normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; 
            sqrt.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
    
    public void RegisterEvent()
    {
        ObserverModuleManager.S.RegisterEvent(ConstKeys.BossEnergy,BossEnergy);
        ObserverModuleManager.S.RegisterEvent(ConstKeys.BossWarning, ShowBossWarning);
        ObserverModuleManager.S.RegisterEvent(ConstKeys.ResumePlayerCamera, ResumePlayerCamera);
    }

    public GameObject GetProp(PropItem prop)
    {
        switch (prop.PropType)
        {
            case PropConfig.PropType.WeaponFragment:
                switch (prop.Quality)
                {
                    case 1:
                        return WhiteWeaponFragmengQueue.Dequeue();
                    case 2:
                        return GreenWeaponFragmengQueue.Dequeue();
                    case 3:
                        return BlueWeaponFragmengQueue.Dequeue();
                    case 4:
                        return PurpleWeaponFragmengQueue.Dequeue();
                    case 5:
                        return OrangeWeaponFragmengQueue.Dequeue();
                    case 6:
                        return RedWeaponFragmengQueue.Dequeue();
                }
                break;
        }

        return null;
    }

    public GameObject GetOrangeEntryEquip(MonsterOrangeEntryEquip equip)
    {
        switch (equip.OrangeEntry)
        {
            case EntryConfig.OrangeEntry.FinalDamageReductionFixed:
                return FinalDamageReductionFixedQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.FinalDamageReductionPercent:
                return FinalDamageReductionPercentQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.AllReplyAddPercent:
                return AllReplyAddPercentQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.AddHpForTime:
                return AddHpForTimeQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.AddDefenseForTime:
                return AddDefenseForTimeQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.ReplyDeath:
                return ReplyDeathQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.DelayDamage:
                return DelayDamageQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.HpReductionReplyAdd50:
                return HpReductionReplyAdd50Queue.Dequeue();
            
            case EntryConfig.OrangeEntry.HpReductionAddDefense:
                return HpReductionAddDefenseQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.FinalDamageAddPercent:
                return FinalDamageAddPercentQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.KillNormal:
                return KillNormalQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.AddAttackForTime:
                return AddAttackForTimeQueue.Dequeue();
            
            
            case EntryConfig.OrangeEntry.NormalAddDamage:
                return NormalAddDamageQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.RecudeHpAddAttack:
                return RecudeHpAddAttackQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.JianSuAddAttack:
                return JianSuAddAttackQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.FanPuGuiZhen:
                return FanPuGuiZhenQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.NoSkill:
                return NoSkillQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.BuWangChuXin:
                return BuWangChuXinQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.HeiDongAddSpeed:
                return HeiDongAddSpeedQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.DuAddDuQuan:
                return DuAddDuQuanQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.LvQuanAddScale:
                return LvQuanAddScaleQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.XuKongAdd2Dan:
                return XuKongAdd2DanQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.PuTong3ChuanTou:
                return PuTong3ChuanTouQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.FireBaoZha:
                return FireBaoZhaQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.Skill1ReplaceNormalAttack:
                return Skill1ReplaceNormalAttackQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.Skill1YiDianDouble:
                return Skill1YiDianDoubleQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.Skill1AddRange:
                return Skill1AddRangeQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.Skill2AddDan:
                return Skill2AddDanQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.Skill2RotateAdd:
                return Skill2RotateAddQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.Skill2AddRange:
                return Skill2AddRangeQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.Skill3Bian3:
                return Skill3Bian3Queue.Dequeue();
            
            case EntryConfig.OrangeEntry.Skill3AddRange:
                return Skill3AddRangeQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.DashCd:
                return DashCdQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.DashRange:
                return DashRangeQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.MoveSpeedAdd:
                return MoveSpeedAddQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.ExAdd:
                return ExAddQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.ClothFortureAdd:
                return ClothFortureAddQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.ShoeFortureAdd:
                return ShoeFortureAddQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.CloakFortureAdd:
                return CloakFortureAddQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.NecklaceFortureAdd:
                return NecklaceFortureAddQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.RingFortureAdd:
                return RingFortureAddQueue.Dequeue();
            
            case EntryConfig.OrangeEntry.HelmetFortureAdd:
                return HelmetFortureAddQueue.Dequeue();
        }

        return null;
    }
    
    
    public GameObject GetEquip(MonsterEquip monsterEquip)
    {
        GameObject equip = null;
        switch (monsterEquip.EquipLevel)
        {
            case PlayerEquipConfig.EquipLevel.Primary:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return PrimaryCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return PrimaryClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return PrimaryRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return PrimaryShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return PrimaryHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return PrimaryNecklaceQueue.Dequeue();
                }
                break;
            case PlayerEquipConfig.EquipLevel.Green:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return GreenCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return GreenClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return GreenRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return GreenShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return GreenHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return GreenNecklaceQueue.Dequeue();
                }
                break;
            case PlayerEquipConfig.EquipLevel.Blue:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return BlueCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return BlueClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return BlueRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return BlueShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return BlueHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return BlueNecklaceQueue.Dequeue();
                }
                break;
            case PlayerEquipConfig.EquipLevel.TreeMan:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return TreeManCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return TreeManClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return TreeManRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return TreeManShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return TreeManHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return TreeManNecklaceQueue.Dequeue();
                }
                break;
           case PlayerEquipConfig.EquipLevel.HuoShan:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return HuoShanCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return HuoShanClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return HuoShanRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return HuoShanShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return HuoShanHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return HuoShanNecklaceQueue.Dequeue();
                }
               break;
           
            case PlayerEquipConfig.EquipLevel.Purple:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return PurpleCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return PurpleClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return PurpleRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return PurpleShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return PurpleHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return PurpleNecklaceQueue.Dequeue();
                }
                break;
            
            case PlayerEquipConfig.EquipLevel.Orange:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return OrangeCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return OrangeClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return OrangeRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return OrangeShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return OrangeHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return OrangeNecklaceQueue.Dequeue();
                }
                break;
        }

        return equip;
    }
    
    private void Awake()
    {
        RegisterEvent();
        GameOver = false;
        var _ = SkillController.S;//激活SkillController
        
        
        
        
        //实例化UI
        // Instantiate(Resources.Load<GameObject>("Prefabs/UI/RoleInfoFight"), transform);
        
        
    }

    private void Start()
    {
        KillMonsterCount = 0;
        if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 ||
            LevelInfoConfig.CurrentGameLevel == 3)
        {
            transform.Find("FightBG(Clone)/Level1").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 4 || LevelInfoConfig.CurrentGameLevel == 5 ||
            LevelInfoConfig.CurrentGameLevel == 6)
        {
            transform.Find("FightBG(Clone)/Level2").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 7 || LevelInfoConfig.CurrentGameLevel == 8 ||
            LevelInfoConfig.CurrentGameLevel == 9)
        {
            transform.Find("FightBG(Clone)/Level3").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 10 || LevelInfoConfig.CurrentGameLevel == 11 ||
            LevelInfoConfig.CurrentGameLevel == 12)
        {
            transform.Find("FightBG(Clone)/Level4").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 13 || LevelInfoConfig.CurrentGameLevel == 14 ||
            LevelInfoConfig.CurrentGameLevel == 15)
        {
            transform.Find("FightBG(Clone)/Level5").gameObject.SetActive(true);
        }
        
        
        //赋值
        FightBGController.S.WeaponButton= fightBG.GetComponent<FightBg>().weaponButton;
        FightBGController.S.joystick=fightBG.GetComponent<FightBg>().joystick;
        FightBGController.S.normalAttackButton=fightBG.GetComponent<FightBg>().normalAttackButton;
        FightBGController.S.FightStopButton=fightBG.GetComponent<FightBg>().fightStopButton;
        FightBGController.S.dashButton=fightBG.GetComponent<FightBg>().dashButton;
        FightBGController.S.rageButton=fightBG.GetComponent<FightBg>().rageButton;
        FightBGController.S.shieldButton=fightBG.GetComponent<FightBg>().shieldButton;
        FightBGController.S.iceArrowButton=fightBG.GetComponent<FightBg>().iceArrowButton;
        FightBGController.S.iceExButton=fightBG.GetComponent<FightBg>().iceExButton;
        FightBGController.S.iceBallButton=fightBG.GetComponent<FightBg>().iceBallButton;
        FightBGController.S.IceExYellowCd=fightBG.GetComponent<FightBg>().iceExYellowCd;
        FightBGController.S.IceBallYellowCd=fightBG.GetComponent<FightBg>().iceBallYellowCd;
        FightBGController.S.IceArrowYellowCd=fightBG.GetComponent<FightBg>().iceArrowYellowCd;
        FightBGController.S.BossEnergySlider=fightBG.GetComponent<FightBg>().bossEnergySlider;


        FightBGController.S.playerHpSlider=fightBG.GetComponent<FightBg>().playerHpSlider;
        FightBGController.S.playerExSlider=fightBG.GetComponent<FightBg>().playerExSlider;
        FightBGController.S.playerLevelText=fightBG.GetComponent<FightBg>().playerLevelText;
        FightBGController.S.GameMaxHp=fightBG.GetComponent<FightBg>().GameMaxHp;
        FightBGController.S.GameCurrentHp=fightBG.GetComponent<FightBg>().GameCurrentHp;
        
        fightTimeText = fightBG.GetComponent<FightBg>().fightTimeText;

        
        //战斗暂停按钮点击事件
        FightBGController.S.FightStopButton.onClick.AddListener(() =>
        {
            Instantiate(Resources.Load("Prefabs/Window/FightExitPanel"));
            Time.timeScale=0;
        });
        
         // EquipController.S.GetMaxEquipId();
         
        FightBGController.S.WeaponButton.onClick.AddListener(() =>
        {
            Time.timeScale = 0;
            Instantiate(Resources.Load("Prefabs/Window/WeaponWindow"));
        });
        //普通攻击按钮
        FightBGController.S.normalAttackButton.onClick.AddListener(() =>
        {
                gamePlayer.isAttack = true;
                gamePlayer.playerState= PlayerState.Attack;
        });
        //冲击技能
        FightBGController.S.dashButton.onClick.AddListener(() =>
        {
            SkillController.S. IsDash = true;
        });
        //怒气技能
        FightBGController.S.rageButton.onClick.AddListener(() =>
        {
            gamePlayer.transform.Find("Rage").gameObject.SetActive(true);
        });
        //护盾技能
        FightBGController.S.shieldButton.onClick.AddListener(() =>
        {
            gamePlayer.transform.Find("Shield").gameObject.SetActive(true);
        });
        //按钮冰箭技能
        FightBGController.S.iceArrowButton.onClick.AddListener(() =>
        {
            if (SkillController.S.IceArrowCoolingtime > SkillController.S.IceArrowtime)
            {
                AudioController.S.PlayIceArrow();
                SkillController.S.IceArrowUIFX.Play();
                SkillController.S.IceArrowCoolingtime = 0;
                SkillController.S.IceArrow.Play();
                SkillController.S.IceArrow.transform.Find("Trail").gameObject.SetActive(true);
            }
        });
        //按钮冰爆技能
        FightBGController.S.iceExButton.onClick.AddListener(() =>
        {
            if (SkillController.S.IceExplosionCoolingtime > SkillController.S.IceExplosiontime)
            {
                SkillController.S.IceExUIFX.Play();
                AudioController.S.PlayIceEx();
                SkillController.S.IceExplosionCoolingtime=0;
                SkillController.S.IceExplosion1.Play();
                SkillController.S.IceExplosion2.Play();
                SkillController.S.IceExplosion3.Play();
                SkillController.S.IceExTrigger.gameObject.SetActive(true);
            }
        });
        //按钮冰球
        FightBGController.S.iceBallButton.onClick.AddListener(() =>
        {
            if (SkillController.S.IceBallCoolingtime > SkillController.S.IceBalltime)
            {
                AudioController.S.PlayIceBall();
                SkillController.S.IceBallUIFX.Play();
                SkillController.S.IceBallCoolingtime=0;
                SkillController.S.StartIceBallSkill(1);
            }
        });
    }

    public void BossEnergy(object[] args)
    {
        switch (args[0])
        {
            case 1:
                BossEnergyNum += 1;
                break;
            case 2:
                BossEnergyNum += 10;
                break;
        }

        FightBGController.S.BossEnergySlider.maxValue = MaxBossEnergyNum;
        FightBGController.S.BossEnergySlider.value = BossEnergyNum;
        Debug.Log("最大能量值："+MaxBossEnergyNum);
        Debug.Log("当前能量值："+BossEnergyNum);
        //召唤BOSS
        if (BossEnergyNum > 1 && HaveBossWarning == false&&LevelInfoConfig.CurrentGameLevelType==LevelType.Boss)
        {
            HaveBossWarning=true;
            BossJiHuo = true;
            Instantiate(Resources.Load("Prefabs/Tool/Warning"));
        }
    }
    
     //创建boss
    public void CreateBoss()
    {
        HaveBoss = true;
        if (LevelInfoConfig.CurrentGameLevel == 3)
        {
            TreeManBoss treeManBoss=Instantiate(Resources.Load<TreeManBoss>("Prefabs/Monster/Level1/TreeManBOSS"));
              treeManBoss.transform.position = new Vector3(0 ,0, 0f);
              treeManBoss.gameObject.SetActive(true);
             SkeletonAnimation sk=treeManBoss.transform.Find("parent/TreeManSkeleton").GetComponent<SkeletonAnimation>();
             treeManBoss.IsSkill = true;
             sk.AnimationState.SetAnimation(0,"Exit",false);
             treeManBoss.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
             treeManBoss.meshRenderer.sortingOrder = 3000;
             MonsterColliderDic.Add(treeManBoss.collider2D,treeManBoss);
        }
        if (LevelInfoConfig.CurrentGameLevel == 6)
        {
            ObserverModuleManager.S.SendEvent(ConstKeys.Resumemonster,null);
            HuoShanBoss huoShanBoss = Instantiate(Resources.Load<HuoShanBoss>("Prefabs/Monster/Level2/HuoShanBOSS"));
            huoShanBoss.transform.position = new Vector3(0, 0, 0f);
            huoShanBoss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0,"walk",true);
            MonsterColliderDic.Add(huoShanBoss.collider2D,huoShanBoss);
            huoShanBoss.meshRenderer.sortingOrder = 3000;

        }
        if (LevelInfoConfig.CurrentGameLevel == 9)
        {
            ObserverModuleManager.S.SendEvent(ConstKeys.Resumemonster,null);
            ZhaoZeBoss ZhaoZeboss = Instantiate(Resources.Load<ZhaoZeBoss>("Prefabs/Monster/Level3/ZhaoZeBOSS"));
            ZhaoZeboss.transform.position = new Vector3(0, 0, 0f);
            MonsterColliderDic.Add(ZhaoZeboss.collider2D,ZhaoZeboss);
            ZhaoZeboss.meshRenderer.sortingOrder = 3000;

            ZhaoZeboss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>().AnimationState.SetAnimation(0,"move",true);
        }
        
        if (LevelInfoConfig.CurrentGameLevel == 12)
        {
            ObserverModuleManager.S.SendEvent(ConstKeys.Resumemonster,null);
            XieZi xieZiboss = Instantiate(Resources.Load<XieZi>("Prefabs/Monster/Level4/XieZi"));
            xieZiboss.transform.position = new Vector3(0, 0, 0f);
            xieZiboss.monsterSkeletonAnimation.AnimationState.SetAnimation(0,"move",false);           
            MonsterColliderDic.Add(xieZiboss.collider2D,xieZiboss);
            xieZiboss.meshRenderer.sortingOrder = 3000;

        }
       
    }

    public bool GetIsCrit()
    {
        var random=Random.Range(0,10000);
        if(GlobalPlayerAttribute.TotalCRIT>=random)
        {
            return true;
        }
        return true;
    }

    public void ResumePlayerCamera(object[] args)
    {
        ResumePlayer();
        ResumeAllMonster();
    }

    //冻结怪物
    public void FreezeAllMonster()
    {
        MonsterBase[] monsters = FindObjectsByType<MonsterBase>(FindObjectsSortMode.None);
        foreach (var monster in monsters)
        {
            if (monster != null && !monster.IsDead)
            {
                monster.Speed=0f; //将怪物速度设置为0，冻结怪物
                //暂停骨骼动画
                monster.monsterSkeletonAnimation.timeScale = 0f; //暂停骨骼动画
            }
        }
    }

    //冻结人物
    public void FreezePlayer()
    {
        GlobalPlayerAttribute.PlayerMoveSpeed = 0;
        gamePlayer.playerSkeleton.timeScale = 0f;
    }
    
    //恢复怪物速度
    public void ResumeAllMonster()
    {
        MonsterBase[] monsters = FindObjectsByType<MonsterBase>(FindObjectsSortMode.None);
        foreach (var monster in monsters)
        {
            if (monster != null && !monster.IsDead)
            {
                monster.Speed=0.3f; //将怪物速度设置为0，冻结怪物
                //暂停骨骼动画
                monster.monsterSkeletonAnimation.timeScale = 1f; //暂停骨骼动画
            }
        }
    }

    //恢复人物速度
    public void  ResumePlayer()
    {
        GlobalPlayerAttribute.PlayerMoveSpeed = 3;
        gamePlayer.playerSkeleton.timeScale = 1f;
    }


    public void CreatePlayer()
    {
        gamePlayer = Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"),transform).GetComponent<Player>();
        gamePlayer.playerSkeleton.AnimationState.SetAnimation(0, "idle", false);
        gamePlayer.transform.position = Vector2.zero;
    }

    // 获取距离玩家10单位的圆周上随机一点
    Vector2 GetRandomPointOnCircle(float radius = 10f)
    {
        // 获取单位圆内的随机点，然后归一化到圆周上
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
    
        // 乘以半径并加上玩家位置
        return (Vector2)GameController.S.gamePlayer.transform.position + randomDirection * radius;
    }
    
    public void CreateEliteMonster()
    {
        if (GameOver)
            return;
        Vector2 monsterRandomPoint = GetRandomPointOnCircle(10);
        MonsterBase eliteMonster = null;

        
        if ( LevelInfoConfig.CurrentGameLevel == 2|| LevelInfoConfig.CurrentGameLevel ==3)
        {
            eliteMonster = EliteBeeMonsterQueue.Dequeue();
            
            BeeMonsterSkillTrigger beeMonsterSkillTrigger = BeeMonsterSkillTriggerQueue.Dequeue();
            beeMonsterSkillTrigger.BeeMonster = eliteMonster as EliteBeeMonster;
            beeMonsterSkillTrigger.gameObject.SetActive(true);
        }
        if ( LevelInfoConfig.CurrentGameLevel ==5 || LevelInfoConfig.CurrentGameLevel ==6)
        {
            eliteMonster = EliteDaZuiMonsterQueue.Dequeue();
           
            
            DaZuiSkillTriggerLeft daZuiSkillTriggerLeft = DaZuiSkillTriggerQueueLeft.Dequeue();
            daZuiSkillTriggerLeft.DaZuiMonster = eliteMonster as EliteDaZuiMonster;
            daZuiSkillTriggerLeft.gameObject.SetActive(true);
            
            DaZuiSkillTriggerRight daZuiSkillTriggerRight = DaZuiSkillTriggerQueueRight.Dequeue();
            daZuiSkillTriggerRight.DaZuiMonster = eliteMonster as EliteDaZuiMonster;
            daZuiSkillTriggerRight.gameObject.SetActive(true);
        }

        if (LevelInfoConfig.CurrentGameLevel == 8 || LevelInfoConfig.CurrentGameLevel == 9 )
        {
            eliteMonster = ShiRenHuaMonsterQueue.Dequeue();
        }
        
        if (LevelInfoConfig.CurrentGameLevel == 11 || LevelInfoConfig.CurrentGameLevel == 12 )
        {
            eliteMonster = ShaXiYiQueue.Dequeue();
        }
        
        if (LevelInfoConfig.CurrentGameLevel == 14 || LevelInfoConfig.CurrentGameLevel == 15 )
        {
            eliteMonster = YingShuQueue.Dequeue();
        }
        
        eliteMonster.gameObject.SetActive(true);
        eliteMonster.CurrentHp = eliteMonster.MaxHp;
        eliteMonster.transform.position = monsterRandomPoint;
        eliteMonster.monsterSkeletonAnimation.AnimationState.SetAnimation(0, eliteMonster.MonsterSpineName.MoveName, true);
        eliteMonster.meshRenderer.sortingOrder = 2000+EliteMonsterCount;
        eliteMonster.hpSliderCanvas.sortingOrder = 2000+EliteMonsterCount;
        TotalMonsterCount++;
        EliteMonsterCount++;
    }

    //生成怪物
    public void CreateMonster()
    {
        if (GameOver)
            return;
        Vector2 monsterRandomPoint = GetRandomPointOnCircle(10);
        MonsterBase monsterBase=null;
        if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 || LevelInfoConfig.CurrentGameLevel == 3)
        {
            if (NormalMonsterCount < LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel])
            {
                if (NormalMonsterCount % 3 == 0)
                {
                    monsterBase = SnotMonsterQueue.Dequeue();
                }
                else if (NormalMonsterCount % 3 == 1)
                {
                    monsterBase = BatMonsterQueue.Dequeue();
                }
                else
                {
                    monsterBase = SpiderMonsterQueue.Dequeue();
                }
            }
            else
            {
                return;
            }
        }

        else if (LevelInfoConfig.CurrentGameLevel == 4 || LevelInfoConfig.CurrentGameLevel == 5 || LevelInfoConfig.CurrentGameLevel == 6)
        {
            if (NormalMonsterCount < LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel])
            {
                if (NormalMonsterCount % 3 == 0)
                {
                    monsterBase = ChongZiMonsterQueue.Dequeue();
                }
                else if (NormalMonsterCount % 3 == 1)
                {
                    monsterBase = XiaoHuoMonsterQueue.Dequeue();
                }
                else
                {
                    monsterBase = HuangZhuQueue.Dequeue();
                }
            }
            else
            {
                return;
            }
        }
        
        
        else if (LevelInfoConfig.CurrentGameLevel == 7 || LevelInfoConfig.CurrentGameLevel == 8 || LevelInfoConfig.CurrentGameLevel == 9)
        {
            if (NormalMonsterCount < LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel])
            {
                if (NormalMonsterCount % 3 == 0)
                {
                    monsterBase = WenZiMonsterQueue.Dequeue();
                }
                else if (NormalMonsterCount % 3 == 1)
                {
                    monsterBase = QingWaMonsterQueue.Dequeue();
                }
                else
                {
                    monsterBase = JiaChongMonsterQueue.Dequeue();
                }
            }
            else
            {
                return;
            }
        }
        
        else if (LevelInfoConfig.CurrentGameLevel == 10 || LevelInfoConfig.CurrentGameLevel == 11 || LevelInfoConfig.CurrentGameLevel == 12)
        {
            if (NormalMonsterCount < LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel])
            {
                if (NormalMonsterCount % 3 == 0)
                {
                    monsterBase = ShaChongQueue.Dequeue();
                }
                else if (NormalMonsterCount % 3 == 1)
                {
                    monsterBase = ShaNiaoQueue.Dequeue();
                }
                else
                {
                    monsterBase =XianRenZhangQueue.Dequeue();
                }
            }
            else
            {
                return;
            }
        }
        
        
        else if (LevelInfoConfig.CurrentGameLevel == 13 || LevelInfoConfig.CurrentGameLevel == 14 || LevelInfoConfig.CurrentGameLevel == 15)
        {
            if (NormalMonsterCount < LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel])
            {
                if (NormalMonsterCount % 3 == 0)
                {
                    monsterBase = XueQiEQueue.Dequeue();
                }
                else if (NormalMonsterCount % 3 == 1)
                {
                    monsterBase = XueQiEQueue.Dequeue();
                }
                else
                {
                    monsterBase =XueQiEQueue.Dequeue();
                }
            }
            else
            {
                return;
            }
        }
        monsterBase.gameObject.SetActive(true);
        monsterBase.transform.position = monsterRandomPoint;
        monsterBase.CurrentHp = monsterBase.MaxHp;
        monsterBase.meshRenderer.sortingOrder = 1000+NormalMonsterCount;
        monsterBase.hpSliderCanvas.sortingOrder = 1000+NormalMonsterCount;
        if (monsterBase.monsterSkeletonAnimation != null)
        {
            monsterBase.monsterSkeletonAnimation.AnimationState.SetAnimation(0, monsterBase.MonsterSpineName.MoveName, true);
        }
        else
        {
            monsterBase.monsterAnimator.Play("move");
        }
        TotalMonsterCount++;
        NormalMonsterCount++;

        if(NormalMonsterCount%10==0&& NormalMonsterCount!=0)
         {
             Debug.Log("生成精英怪:"+NormalMonsterCount);
           CreateEliteMonster();
         }
    }
    
    public void ShowBossWarning(object[] args)
    {
        HaveBossWarning = true;
        Instantiate(Resources.Load("Prefabs/Tool/Warning"));
        FreezePlayer();
        FreezeAllMonster();
    }

    public void RefreshOrangeEntry()
    {
         CurrentOrangeEntryTime = 0;
            if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.AddHpForTime)&&TotalAddHp<GlobalPlayerAttribute.TotalMaxHp)
            {
                TotalAddHp+=0.03f * GlobalPlayerAttribute.TotalMaxHp;
                if (TotalAddHp < GlobalPlayerAttribute.TotalMaxHp)
                {
                    GameMaxHp += 0.03f * GlobalPlayerAttribute.TotalMaxHp;
                    GameCurrentHp+= 0.03f * GlobalPlayerAttribute.TotalMaxHp;
                }
                else
                {
                    GameMaxHp += (GlobalPlayerAttribute.TotalMaxHp -
                                  (TotalAddHp - 0.03f * GlobalPlayerAttribute.TotalMaxHp));
                    GameCurrentHp += (GlobalPlayerAttribute.TotalMaxHp -
                                      (TotalAddHp - 0.03f * GlobalPlayerAttribute.TotalMaxHp));
                }
            }
            if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.AddDefenseForTime)&&TotalAddDefense<GlobalPlayerAttribute.TotalDefense*0.6f)
            {
                TotalAddDefense+=0.02f * GlobalPlayerAttribute.TotalDefense;
                if (TotalAddDefense < GlobalPlayerAttribute.TotalDefense * 0.6f)
                {
                    GameDefense += 0.02f * GlobalPlayerAttribute.TotalDefense;
                }
                else
                {
                    GameDefense += (GlobalPlayerAttribute.TotalDefense -
                                    (TotalAddHp - 0.02f * GlobalPlayerAttribute.TotalDefense));
                }
            }
            
            if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.AddAttackForTime)&&TotalAddAttack<GlobalPlayerAttribute.TotalDamage)
            {
                TotalAddAttack+=0.03f * GlobalPlayerAttribute.TotalDamage;
                if (TotalAddAttack < GlobalPlayerAttribute.TotalDamage)
                {
                    GameAttack += 0.03f * GlobalPlayerAttribute.TotalDamage;
                }
                else
                {
                    GameAttack += (GlobalPlayerAttribute.TotalDamage -
                                  (TotalAddAttack - 0.03f * GlobalPlayerAttribute.TotalDamage));
                  
                }
            }
    }

    private void Update()
    {
        if (GlobalPlayerAttribute.IsGame == false)
            return;
        
        CurrentOrangeEntryTime+=Time.deltaTime;
        if (CurrentOrangeEntryTime > OrangeEntryTime)
        {
            RefreshOrangeEntry();
        }

        if (BossJiHuo && Vector2.Distance(gamePlayer.transform.position, Vector2.zero) < 2)
        {
            FightBGController.S.IsBossJiHuo = true;

        }
        else
        {
            FightBGController.S.IsBossJiHuo = false;
        }
        //更新战斗时间,以秒为单位
        fightTime += Time.deltaTime;
        var minute=(int)fightTime/60;
        var second=(int)fightTime%60;
        fightTimeText.text = "战斗时间：" + minute.ToString("F0") + " 分 " + second.ToString("F0") + " 秒";
        
        //生成怪物
        currentTime += Time.deltaTime;
        distanceUpdateTimer+=Time.deltaTime;
        if (currentTime >= monsterBirthTimeScale)
        {
            CreateMonster();
            currentTime = 0f;
        }
        //获得距离最近的怪物位置
        // 在排序之前清理无效的怪物引用
        // 在排序之前清理无效的怪物引用
// 1. 在Update中添加对IsDead的检查
        if (distanceUpdateTimer > 0.2f)
        {
            distanceUpdateTimer = 0;
            // 清理无效的怪物引用
            monsterDetetor1.RemoveWhere(monster =>
                monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead);
            monsterDetetor2.RemoveWhere(monster =>
                monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead);
            monsterDetetor3.RemoveWhere(monster =>
                monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead);
            monsterDetetor4.RemoveWhere(monster =>
                monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead);

            // 直接找到最近的怪物，不需要排序
            MonsterBase nearestMonster = FindNearestMonster(monsterDetetor1);
            if (nearestMonster == null)
                nearestMonster = FindNearestMonster(monsterDetetor2);
            if (nearestMonster == null)
                nearestMonster = FindNearestMonster(monsterDetetor3);
            if (nearestMonster == null)
                nearestMonster = FindNearestMonster(monsterDetetor4);

            if (nearestMonster != null)
            {
                nearMonsterPosition = nearestMonster.transform.position;
            }
            else
            {
                //朝向player的右边
                if (gamePlayer.playerSkeleton.Skeleton.FlipX)
                    nearMonsterPosition = gamePlayer.transform.position + new Vector3(-10, 0, 0);
                else
                    nearMonsterPosition = gamePlayer.transform.position + new Vector3(10, 0, 0);
            }
        }

    }
    

    private MonsterBase FindNearestMonster(HashSet<MonsterBase> monsters)
    {
        MonsterBase nearestMonster = null;
        float nearestDistance = float.MaxValue;

        foreach (var monster in monsters)
        {
            // 跳过无效的怪物
            if (monster == null || monster.gameObject == null || !monster.gameObject.activeSelf || monster.IsDead)
                continue;

            float distance = Vector3.Distance(gamePlayer.transform.position, monster.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestMonster = monster;
            }
        }

        return nearestMonster;
    }
}