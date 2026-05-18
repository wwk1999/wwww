using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Config;
using Equip;
using Fight.Monster.秘境.盔甲boss;
using Fight.Monster.秘境.豹子;
using Fight.Monster.秘境.雷兽;
using Mysql;
using Prop.BaoShi;
using Skill.NormalAttack.Primary;
using Spine.Unity;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class GameController : XSingleton<GameController>
{
    [NonSerialized] public MonsterTypeByName EliteMonster = MonsterTypeByName.None;
    [NonSerialized] public List<MonsterTypeByName> NormalMonster = new List<MonsterTypeByName>();
    [NonSerialized] public MonsterTypeByName Boss = MonsterTypeByName.None;

    [NonSerialized]public HashSet<EquipBase> EquipBaseSet = new HashSet<EquipBase>();
    [NonSerialized]public HashSet<PropBase> PropBaseSet = new HashSet<PropBase>();

    
    [NonSerialized] public int[] MonsterList = new int[2];
    [NonSerialized] public float GameMaxHp = 0;
    [NonSerialized] public float GameCurrentHp = 0;
    public float GameDefense =>GetGameDefense();
    public float GameAttack =>GetGameAttack();
    [NonSerialized] public float GameCrit = 0;
    

    private int CritCount = 0;
    private int AddAttackForTimeCount=0;
    private int AddDefenseForTimeCount=0;

    [NonSerialized]public int HitCount = 0;
    [NonSerialized]public int MoveAddAttackCount = 0;

    public float GetGameDefense()
    {
        float value = GlobalPlayerAttribute.TotalDefense;
        value += (GlobalPlayerAttribute.TotalDefense * 0.03f * HitCount * GlobalPlayerAttribute.DD5Count);
        value += GlobalPlayerAttribute.TotalDefense  * MoveAddAttackCount;
        value += GlobalPlayerAttribute.TotalDefense*(AddDefenseForTimeCount * 0.02f );

        return value;
    }

    public float GetGameAttack()
    {
        float value = GlobalPlayerAttribute.TotalDamage;
        value += GlobalPlayerAttribute.TotalDamage*(CritCount * 0.03f * GlobalPlayerAttribute.AC5Count);
        value += GlobalPlayerAttribute.TotalDamage*(AddAttackForTimeCount * 0.03f );
        value += GlobalPlayerAttribute.TotalDamage*MoveAddAttackCount;

        return value;
    }
    
    
    [NonSerialized] public float OrangeEntryTime = 5f;
    [NonSerialized] public float CurrentOrangeEntryTime = 0f;
    [NonSerialized] public bool isFuHuo = true;
    
    [NonSerialized] public  float TotalAddHp = 0;
    

    //碰撞字典
    [NonSerialized] public Dictionary<Collider2D, MonsterBase> MonsterColliderDic = new Dictionary<Collider2D, MonsterBase>();

    public Vector2 GetRandomMonsterPos()
    {
        List<MonsterBase> monsters = new List<MonsterBase>(MonsterColliderDic.Values);
        
        int n = monsters.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            // 交换元素
            (monsters[j], monsters[i]) = (monsters[i], monsters[j]);
        }

        foreach (var item in monsters)
        {
            if (item.gameObject.activeSelf &&
                Vector2.Distance(gamePlayer.transform.position, item.transform.position) < 6)
            {
                return item.transform.position;
            }
        }

        float x = Random.Range(-0.5f, 0.5f);
        float y = Random.Range(-0.5f, 0.5f);
        Vector3 dir = new Vector3(x, y,0);
        return gamePlayer.transform.position+dir * 6;
    }
    
    
    [NonSerialized]public Player gamePlayer;

    
    [NonSerialized] public Queue<PlayerHurt> PlayerHurtQueue = new Queue<PlayerHurt>();
    
    //Boss攻击提示对象池
    [NonSerialized] public Queue<CircleAttack> CircleQueue = new Queue<CircleAttack>();
    [NonSerialized] public Queue<SqrtAttack> SqrtQueue = new Queue<SqrtAttack>();

    //小怪
    [NonSerialized] public Queue<DanMu> DanMuQueue = new Queue<DanMu>();

    [NonSerialized] public Queue<BaoXue> BaoXueQueue = new Queue<BaoXue>();

    [NonSerialized] public Queue<banrenma1> banrenma1Queue = new Queue<banrenma1>();
    [NonSerialized] public Queue<banrenma2> banrenma2Queue = new Queue<banrenma2>();
    [NonSerialized] public Queue<banrenma3> banrenma3Queue = new Queue<banrenma3>();
    [NonSerialized] public Queue<cat> catQueue = new Queue<cat>();
    [NonSerialized] public Queue<egg> eggQueue = new Queue<egg>();
    [NonSerialized] public Queue<lang> langQueue = new Queue<lang>();
    [NonSerialized] public Queue<mogu> moguQueue = new Queue<mogu>();
    [NonSerialized] public Queue<niguai1> niguai1Queue = new Queue<niguai1>();
    [NonSerialized] public Queue<niguai2> niguai2Queue = new Queue<niguai2>();
    [NonSerialized] public Queue<niguai3> niguai3Queue = new Queue<niguai3>();
    [NonSerialized] public Queue<onyx> onyxQueue = new Queue<onyx>();
    [NonSerialized] public Queue<paopao> paopaoQueue = new Queue<paopao>();
    [NonSerialized] public Queue<queen> queenQueue = new Queue<queen>();
    [NonSerialized] public Queue<rongyanboss> rongyanbossQueue = new Queue<rongyanboss>();
    [NonSerialized] public Queue<shanyang> shanyangQueue = new Queue<shanyang>();
    [NonSerialized] public Queue<she> sheQueue = new Queue<she>();
    [NonSerialized] public Queue<woniu> woniuQueue = new Queue<woniu>();
    [NonSerialized] public Queue<xiaohuoling> xiaohuolingQueue = new Queue<xiaohuoling>();
    [NonSerialized] public Queue<xiaoshuguai> xiaoshuguaiQueue = new Queue<xiaoshuguai>();
    [NonSerialized] public Queue<xiaozhizhu> xiaozhizhuQueue = new Queue<xiaozhizhu>();
    [NonSerialized] public Queue<xiezi1> xiezi1Queue = new Queue<xiezi1>();
    [NonSerialized] public Queue<xiezi2> xiezi2Queue = new Queue<xiezi2>();
    [NonSerialized] public Queue<xiongbuou> xiongbuouQueue = new Queue<xiongbuou>();
    [NonSerialized] public Queue<xuelaoshu> xuelaoshuQueue = new Queue<xuelaoshu>();
    [NonSerialized] public Queue<yanshu> yanshuQueue = new Queue<yanshu>();
    [NonSerialized] public Queue<yezhu> yezhuQueue = new Queue<yezhu>();
    [NonSerialized] public Queue<zhumodaocaoren> zhumodaocaorenQueue = new Queue<zhumodaocaoren>();
    [NonSerialized] public Queue<zibaolaoshu> zibaolaoshuQueue = new Queue<zibaolaoshu>();

    
    
    [NonSerialized] public Queue<dazongxiong> dazongxiongQueue = new Queue<dazongxiong>();
    [NonSerialized] public Queue<fengheguai> fengheguaiQueue = new Queue<fengheguai>();
    [NonSerialized] public Queue<kuangshimuzhu> kuangshimuzhuQueue = new Queue<kuangshimuzhu>();
    [NonSerialized] public Queue<lujiaodoushi> lujiaodoushiQueue = new Queue<lujiaodoushi>();
    [NonSerialized] public Queue<shuangtouren> shuangtourenQueue = new Queue<shuangtouren>();

    [NonSerialized] public Queue<cizhu> cizhuQueue = new Queue<cizhu>();
    [NonSerialized] public Queue<daocaoren> daocaorenQueue = new Queue<daocaoren>();

    [NonSerialized] public Queue<chailangren1> chailangren1Queue = new Queue<chailangren1>();
[NonSerialized] public Queue<chailangren2> chailangren2Queue = new Queue<chailangren2>();
[NonSerialized] public Queue<chailangren3> chailangren3Queue = new Queue<chailangren3>();
[NonSerialized] public Queue<chailangren4> chailangren4Queue = new Queue<chailangren4>();
[NonSerialized] public Queue<YeShouZhanShi> YeShouZhanShiQueue = new Queue<YeShouZhanShi>();
[NonSerialized] public Queue<ZhiZhuNvWang> ZhiZhuNvWangQueue = new Queue<ZhiZhuNvWang>();
[NonSerialized] public Queue<dijing2> dijing2Queue = new Queue<dijing2>();
[NonSerialized] public Queue<dijing3> dijing3Queue = new Queue<dijing3>();
[NonSerialized] public Queue<dijingshouwei1> dijingshouwei1Queue = new Queue<dijingshouwei1>();
[NonSerialized] public Queue<dijingshouwei2> dijingshouwei2Queue = new Queue<dijingshouwei2>();
[NonSerialized] public Queue<dijingshouwei3> dijingshouwei3Queue = new Queue<dijingshouwei3>();
[NonSerialized] public Queue<heixiong> heixiongQueue = new Queue<heixiong>();
[NonSerialized] public Queue<jianchizhu> jianchizhuQueue = new Queue<jianchizhu>();
[NonSerialized] public Queue<kulou1> kulou1Queue = new Queue<kulou1>();
[NonSerialized] public Queue<kulou2> kulou2Queue = new Queue<kulou2>();
[NonSerialized] public Queue<kulou3> kulou3Queue = new Queue<kulou3>();
[NonSerialized] public Queue<kulou4> kulou4Queue = new Queue<kulou4>();
[NonSerialized] public Queue<kulou5> kulou5Queue = new Queue<kulou5>();
[NonSerialized] public Queue<kulou6> kulou6Queue = new Queue<kulou6>();
[NonSerialized] public Queue<lujiaocike> lujiaocikeQueue = new Queue<lujiaocike>();
[NonSerialized] public Queue<lujiaocike2> lujiaocike2Queue = new Queue<lujiaocike2>();
[NonSerialized] public Queue<niutouren1> niutouren1Queue = new Queue<niutouren1>();
[NonSerialized] public Queue<niutouren2> niutouren2Queue = new Queue<niutouren2>();
[NonSerialized] public Queue<niutouren3> niutouren3Queue = new Queue<niutouren3>();
[NonSerialized] public Queue<shanzei3> shanzei3Queue = new Queue<shanzei3>();
[NonSerialized] public Queue<shijiachong> shijiachongQueue = new Queue<shijiachong>();
[NonSerialized] public Queue<shishigui> shishiguiQueue = new Queue<shishigui>();
[NonSerialized] public Queue<shixianggui> shixiangguiQueue = new Queue<shixianggui>();
[NonSerialized] public Queue<shouren1> shouren1Queue = new Queue<shouren1>();
[NonSerialized] public Queue<shouren2> shouren2Queue = new Queue<shouren2>();
[NonSerialized] public Queue<shouren3> shouren3Queue = new Queue<shouren3>();
[NonSerialized] public Queue<shuangtoulong> shuangtoulongQueue = new Queue<shuangtoulong>();
[NonSerialized] public Queue<shuangtoulong2> shuangtoulong2Queue = new Queue<shuangtoulong2>();
[NonSerialized] public Queue<shuangtoulong3> shuangtoulong3Queue = new Queue<shuangtoulong3>();
[NonSerialized] public Queue<tujiu> tujiuQueue = new Queue<tujiu>();
[NonSerialized] public Queue<wuya> wuyaQueue = new Queue<wuya>();
[NonSerialized] public Queue<youhunlingzhu> youhunlingzhuQueue = new Queue<youhunlingzhu>();
[NonSerialized] public Queue<youlang> youlangQueue = new Queue<youlang>();
[NonSerialized] public Queue<youling> youlingQueue = new Queue<youling>();
[NonSerialized] public Queue<youling2> youling2Queue = new Queue<youling2>();
[NonSerialized] public Queue<yuren1> yuren1Queue = new Queue<yuren1>();
[NonSerialized] public Queue<yuren2> yuren2Queue = new Queue<yuren2>();
[NonSerialized] public Queue<yuren3> yuren3Queue = new Queue<yuren3>();

//精英怪，暂时没写
[NonSerialized] public Queue<dijingzhanglao> DijingzhanglaoQueue = new Queue<dijingzhanglao>();
[NonSerialized] public Queue<rongyanguai> rongyanguaiQueue = new Queue<rongyanguai>();
[NonSerialized] public Queue<shifuboss> shifubossQueue = new Queue<shifuboss>();
[NonSerialized] public Queue<wuyaozhiwang> wuyaozhiwangQueue = new Queue<wuyaozhiwang>();
[NonSerialized] public Queue<wuyaozhiwang2> wuyaozhiwang2Queue = new Queue<wuyaozhiwang2>();

    //第一关怪
    [NonSerialized] public Queue<SnotMonster> SnotMonsterQueue = new Queue<SnotMonster>();
    [NonSerialized] public Queue<EliteBeeMonster> EliteBeeMonsterQueue = new Queue<EliteBeeMonster>();
    [NonSerialized] public Queue<BatMonster> BatMonsterQueue = new Queue<BatMonster>();
    [NonSerialized] public Queue<SpiderMonster> SpiderMonsterQueue = new Queue<SpiderMonster>();
    [NonSerialized] public Queue<TreeManSkill> TreeManSkillQueue = new Queue<TreeManSkill>();
    [NonSerialized] public Queue<TreeManDiLie> TreeManDiLieQueue = new Queue<TreeManDiLie>();
    [NonSerialized] public Queue<BeeBullet> BeeBulletQueue = new Queue<BeeBullet>();
    [NonReorderable]public Queue<TreeManDanMu>TreeManDanMuQueue = new Queue<TreeManDanMu>();


    
    //第二关怪
    [NonSerialized] public Queue<ChongZiMonster> ChongZiMonsterQueue = new Queue<ChongZiMonster>();
    [NonSerialized] public Queue<DunDiMonster> DunDiMonsterQueue = new Queue<DunDiMonster>();
    [NonSerialized] public Queue<XiaoHuoMonster> XiaoHuoMonsterQueue = new Queue<XiaoHuoMonster>();
    [NonSerialized] public Queue<EliteDaZuiMonster> EliteDaZuiMonsterQueue = new Queue<EliteDaZuiMonster>();
    [NonSerialized] public Queue<XiNiuMonster> XiNiuMonsterQueue = new Queue<XiNiuMonster>();

  
    [NonSerialized] public Queue<HuoShanJianQi> HuoShanJianQiQueue = new Queue<HuoShanJianQi>();
    [NonSerialized] public Queue<HuoShanSkill2> HuoShanSkill2QiQueue = new Queue<HuoShanSkill2>();


    
    
    //第三关怪
    [NonSerialized] public Queue<JiaChongMonster> JiaChongMonsterQueue = new Queue<JiaChongMonster>();
    [NonSerialized] public Queue<WenZiMonster> WenZiMonsterQueue = new Queue<WenZiMonster>();
    [NonSerialized] public Queue<QingWaMonster> QingWaMonsterQueue = new Queue<QingWaMonster>();
    [NonSerialized] public Queue<ShiRenHuaMonster> ShiRenHuaMonsterQueue = new Queue<ShiRenHuaMonster>();
    
    [NonSerialized] public Queue<ZhaoZeSkill> ZhaoZeSkillQueue = new Queue<ZhaoZeSkill>();



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
    [NonSerialized] public Queue<XieZiSkill4> XieZiSkill4Queue = new Queue<XieZiSkill4>();


    //第五关怪
    [NonSerialized] public Queue<XueQiE> XueQiEQueue = new Queue<XueQiE>();
    [NonSerialized] public Queue<XueZhangLang> XueZhangLangQueue = new Queue<XueZhangLang>();
    [NonSerialized] public Queue<XueRen> XueRenQueue = new Queue<XueRen>();
    [NonSerialized] public Queue<XueRenJian> XueRenJianQueue = new Queue<XueRenJian>();
    [NonSerialized] public Queue<XueRenBossSkill1> XueRenBossSkill1Queue = new Queue<XueRenBossSkill1>();
    [NonSerialized] public Queue<YingShu> YingShuQueue = new Queue<YingShu>();
    
    //秘境怪物
    [NonSerialized] public Queue<DaLong> DaLongQueue = new Queue<DaLong>();
    [NonSerialized] public Queue<EMo1> EMo1Queue = new Queue<EMo1>();
    [NonSerialized] public Queue<EMo2> EMo2Queue = new Queue<EMo2>();
    [NonSerialized] public Queue<EMo3> EMo3Queue = new Queue<EMo3>();
    [NonSerialized] public Queue<HongLong1> HongLong1Queue = new Queue<HongLong1>();
    [NonSerialized] public Queue<HongLong2> HongLong2Queue = new Queue<HongLong2>();
    [NonSerialized] public Queue<HongLong3> HongLong3Queue = new Queue<HongLong3>();
    [NonSerialized] public Queue<LanLong1> LanLong1Queue = new Queue<LanLong1>();
    [NonSerialized] public Queue<LanLong2> LanLong2Queue = new Queue<LanLong2>();
    [NonSerialized] public Queue<LanLong3> LanLong3Queue = new Queue<LanLong3>();
    [NonSerialized] public Queue<LvLang> LvLangQueue = new Queue<LvLang>();
    [NonSerialized] public Queue<LvLong1> LvLong1Queue = new Queue<LvLong1>();
    [NonSerialized] public Queue<LvLong2> LvLong2Queue = new Queue<LvLong2>();
    [NonSerialized] public Queue<LvLong3> LvLong3Queue = new Queue<LvLong3>();
    
    [NonSerialized] public Queue<LeiShouSkill3> LeiShouSkill3Queue = new Queue<LeiShouSkill3>();
    [NonSerialized] public Queue<HeiXuanFen> HeiXuanFenQueue = new Queue<HeiXuanFen>();
    [NonSerialized] public Queue<LvZhuiZong> LvZhuiZongQueue = new Queue<LvZhuiZong>();
    [NonSerialized] public Queue<LvXuanFen> LvXuanFenQueue = new Queue<LvXuanFen>();
    [NonSerialized] public Queue<BaoZiSkill2> BaoZiSkill2Queue = new Queue<BaoZiSkill2>();

    [NonSerialized] public Queue<HuoLangSkill2> HuoLangSkill2Queue = new Queue<HuoLangSkill2>();
    [NonSerialized] public Queue<ShuangDaoSkill2> ShuangDaoSkill2Queue = new Queue<ShuangDaoSkill2>();
    [NonSerialized] public Queue<ShuangDaoSkill3> ShuangDaoSkill3Queue = new Queue<ShuangDaoSkill3>();







    
    
    
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
    [NonReorderable]public Queue<GameObject>PrimaryQueue = new Queue<GameObject>();

    [NonReorderable]public Queue<GameObject>PuTong3Queue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PuTong3PengQueue = new Queue<GameObject>();
    
    
    [NonReorderable]public Queue<GameObject>FireBaoZha1Queue = new Queue<GameObject>();
    
    [NonReorderable]public Queue<PlayerJianQi>PlayerJianQiQueue = new Queue<PlayerJianQi>();
    [NonReorderable]public Queue<GameObject>ZiBaoZhaQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>IcePengQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HeiAnPengQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HuoPengQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>DianPengQueue = new Queue<GameObject>();

    [NonReorderable]public Queue<Huo7Item>Huo7Queue = new Queue<Huo7Item>();
    [NonReorderable]public Queue<Ice7Item>Ice7Queue = new Queue<Ice7Item>();
    [NonReorderable]public Queue<IcePen>IcePenQueue = new Queue<IcePen>();
    [NonReorderable]public Queue<PrimaryDian>PrimaryDianQueue = new Queue<PrimaryDian>();
    [NonReorderable]public Queue<PrimaryHuo>PrimaryHuoQueue = new Queue<PrimaryHuo>();
    [NonReorderable]public Queue<PrimaryHeiAn>PrimaryHeiAnQueue = new Queue<PrimaryHeiAn>();


    [NonReorderable]public Queue<DianLuoLei>DianLuoLeiQueue = new Queue<DianLuoLei>();
    [NonReorderable]public Queue<DianLuoLeiNext>DianLuoLeiNextQueue = new Queue<DianLuoLeiNext>();


    [NonReorderable]public Queue<HuoFenLie>HuoFenLieQueue = new Queue<HuoFenLie>();
    [NonReorderable]public Queue<HuoFenLieDan>HuoFenLieDanQueue = new Queue<HuoFenLieDan>();
    [NonReorderable]public Queue<HuoFenLieBaoZha>HuoFenLieBaoZhaQueue = new Queue<HuoFenLieBaoZha>();

    [NonReorderable]public Queue<Ice4BaoZhaItem>Ice4BaoZhaItemQueue = new Queue<Ice4BaoZhaItem>();
    [NonReorderable]public Queue<Ice4BaoZha>Ice4BaoZhaQueue = new Queue<Ice4BaoZha>();
    [NonReorderable]public Queue<DianJiSu>DianJiSuQueue = new Queue<DianJiSu>();
    [NonReorderable]public Queue<HeiAnHuiXuan>HeiAnHuiXuanQueue = new Queue<HeiAnHuiXuan>();
    [NonReorderable]public Queue<HuoQuXian>HeiAnQuXianQueue = new Queue<HuoQuXian>();

    [NonReorderable]public Queue<HuoDiPen>HuoDiPenQueue = new Queue<HuoDiPen>();
    [NonReorderable]public Queue<HuoBaoZha>HuoBaoZhaQueue = new Queue<HuoBaoZha>();
    [NonReorderable]public Queue<HuoYanBaoZhaNext>HuoYanBaoZhaNextQueue = new Queue<HuoYanBaoZhaNext>();
    [NonReorderable]public Queue<DianBaoZha>DianBaoZhaQueue = new Queue<DianBaoZha>();
    [NonReorderable]public Queue<DianBaoZhaNext>DianBaoZhaNextQueue = new Queue<DianBaoZhaNext>();
    [NonReorderable]public Queue<IceBaoZha>IceBaoZhaQueue = new Queue<IceBaoZha>();
    [NonReorderable]public Queue<IceBaoZhaNext>IceBaoZhaNextQueue = new Queue<IceBaoZhaNext>();

    
    
    [NonReorderable]public Queue<GameObject>HeiAnBaoZhaQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>HeiAnBaoZhaNextQueue = new Queue<GameObject>();



    
    
    //技能队列
    [NonReorderable]public Queue<GameObject>DianQuanQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>DianQuanPengQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<IceExplosion>IceExQueue = new Queue<IceExplosion>();
    [NonReorderable]public Queue<HuoSkill1>HuoSkill1Queue = new Queue<HuoSkill1>();
    [NonReorderable]public Queue<DianSkill2>DianSkill2Queue = new Queue<DianSkill2>();
    [NonReorderable]public Queue<HeiAnSkill3>HeiAnSkill3Queue = new Queue<HeiAnSkill3>();
    [NonReorderable]public Queue<HeiAnSkill1>HeiAnSkill1Queue = new Queue<HeiAnSkill1>();
    [NonReorderable]public Queue<DianSkill3>DianSkill3Queue = new Queue<DianSkill3>();
    [NonReorderable]public Queue<HuoSkill3>HuoSkill3Queue = new Queue<HuoSkill3>();
    [NonReorderable]public Queue<IceSkill1>IceSkill1Queue = new Queue<IceSkill1>();
    [NonReorderable]public Queue<IceSkill4>IceSkill4Queue = new Queue<IceSkill4>();
    [NonReorderable]public Queue<IceSkill5>IceSkill5Queue = new Queue<IceSkill5>();
    [NonReorderable]public Queue<HuoSkill4>HuoSkill4Queue = new Queue<HuoSkill4>();
    [NonReorderable]public Queue<HuoSkill5>HuoSkill5Queue = new Queue<HuoSkill5>();
    [NonReorderable]public Queue<DianSkill4>DianSkill4Queue = new Queue<DianSkill4>();
    [NonReorderable]public Queue<DianSkill5>DianSkill5Queue = new Queue<DianSkill5>();
    [NonReorderable]public Queue<HeiAnSkill4>HeiAnSkill4Queue = new Queue<HeiAnSkill4>();
    [NonReorderable]public Queue<HeiAnSkill5>HeiAnSkill5Queue = new Queue<HeiAnSkill5>();



    
    
    //血能对象池队列
    [NonReorderable]public Queue<GameObject>BloodEnergyQueue = new Queue<GameObject>();
    //怪物伤害文本对象池队列
    [NonReorderable]public Queue<MonsterHurtText>MonsterHurtTextQueue = new Queue<MonsterHurtText>();

    //翅膀对象池
    [NonReorderable]public Queue<ChiBangFight>ChiBangFightQueue = new Queue<ChiBangFight>();

    
    //武器碎片对象池
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
    
    [NonReorderable]public Queue<GameObject>ZhaoZeCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ZhaoZeClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ZhaoZeRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ZhaoZeHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ZhaoZeNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ZhaoZeShoeQueue = new Queue<GameObject>();
    
    [NonReorderable]public Queue<GameObject>Purple1CloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>Purple1ClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>Purple1RingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>Purple1HelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>Purple1NecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>Purple1ShoeQueue = new Queue<GameObject>();
    
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
    
    [NonReorderable]public Queue<GameObject>XieZiCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>XieZiClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>XieZiRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>XieZiHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>XieZiNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>XieZiShoeQueue = new Queue<GameObject>();

    
    [NonReorderable]public Queue<GameObject>XueRenCloakQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>XueRenClothQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>XueRenRingQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>XueRenHelmetQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>XueRenNecklaceQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>XueRenShoeQueue = new Queue<GameObject>();

    
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

    [NonReorderable]public Queue<BaoShi>BaoShiQueue = new Queue<BaoShi>();


    //神话材料
    [NonReorderable]public Queue<GameObject>JuDaYaChiQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>FuMoZhiGuQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>GoldBloodQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>ZuiEYanZhuQueue = new Queue<GameObject>();
    
    
    //宠物蛋
    [NonReorderable]public Queue<ChongWuDanFight>ChongWuDanQueue = new Queue<ChongWuDanFight>();
    [NonReorderable]public Queue<XiSuiYeFight>XiSuiYeQueue = new Queue<XiSuiYeFight>();
    [NonReorderable]public Queue<XueMaiDanFight>XueMaiDanQueue = new Queue<XueMaiDanFight>();
    [NonReorderable]public Queue<ChongWuSkillShuFight>ChongWuSkillShuQueue = new Queue<ChongWuSkillShuFight>();
    [NonReorderable]public Queue<ChongWuShiWuFight>ChongWuShiWuQueue = new Queue<ChongWuShiWuFight>();
    [NonReorderable]public Queue<DaKongShiFight>DaKongShiQueue = new Queue<DaKongShiFight>();
    [NonReorderable]public Queue<ShenHuaCaiLiaoFight>ShenHuaCaiLiaoQueue = new Queue<ShenHuaCaiLiaoFight>();

    //羽毛
    [NonReorderable]public Queue<GameObject>WhiteChiBangQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>GreenChiBangQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>BlueChiBangQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>PurpleChiBangQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>OrangeChiBangQueue = new Queue<GameObject>();
    [NonReorderable]public Queue<GameObject>RedChiBangQueue = new Queue<GameObject>();


   
    //怪物数量
    [NonSerialized]public int NormalMonsterCount=0;
    [NonSerialized]public int EliteMonsterCount=0;
    [NonSerialized]public int TotalMonsterCount=0;
    [NonSerialized]public int DieNormalMonsterCount=0;
    [NonSerialized]public int DieEliteMonsterCount=0;



    public float monsterBirthTimeScale => LevelInfoConfig.LevelMonsterCreateSpeedDic[LevelInfoConfig.CurrentGameLevel]; //间隔一秒钟生成一个怪物
    public float currentTime = 0f;
    public GameObject fightBG;
    [NonSerialized]public Transform[] MonsterBirthPoints1;
    [NonSerialized]public Transform[] MonsterBirthPoints2;
    [NonSerialized]public Transform[] MonsterBirthPoints3;
    [NonSerialized]public Transform[] PlayerBirthPoints;

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


    public void CreateDiLie(Vector2 pos,float damage)
    {
        var dilie = TreeManDiLieQueue.Dequeue();
        dilie.transform.position = pos;
        dilie.GetComponent<TreeManDiLie>().damage = damage;
        dilie.gameObject.SetActive(true);
    }

    public void CreateCircleAttack(Vector2 pos,float scale)
    {
        var circle=CircleQueue.Dequeue();
        circle.transform.position = pos;
        circle.transform.localScale = new Vector3(scale, scale, scale);
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
            case PropConfig.PropType.ChiBangFight:
                ChiBangType chiBangType = ChiBangConfig.GetRandomChiBangType(prop.Quality);
                ChiBangFight chiBangFight = ChiBangFightQueue.Dequeue();
                chiBangFight.ChiBangType=chiBangType;
                return chiBangFight.gameObject;
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
            case PropConfig.PropType.ShenHuaCaiLiao:
                switch (prop.Quality)
                {
                    case 1:
                        return FuMoZhiGuQueue.Dequeue();
                    case 2:
                        return GoldBloodQueue.Dequeue();
                    case 3:
                        return JuDaYaChiQueue.Dequeue();
                    case 4:
                        return ZuiEYanZhuQueue.Dequeue();
                }
                break;
            
            case PropConfig.PropType.ChiBang:
                switch (prop.Quality)
                {
                    case 1:
                        return WhiteChiBangQueue.Dequeue();
                    case 2:
                        return GreenChiBangQueue.Dequeue();
                    case 3:
                        return BlueChiBangQueue.Dequeue();
                    case 4:
                        return PurpleChiBangQueue.Dequeue();
                    case 5:
                        return OrangeChiBangQueue.Dequeue();
                    case 6:
                        return RedChiBangQueue.Dequeue();
                }
                break;
            case PropConfig.PropType.AA:
                BaoShi baoshi=BaoShiQueue.Dequeue();
                switch (prop.Quality)
                {
                    case 1:
                        baoshi.propTables.PropType=PropConfig.PropType.AA;
                        baoshi.propTables.Quality = 1;
                        baoshi.propTables.EquipName = "AA1";
                        break;
                    case 2:
                        baoshi.propTables.PropType=PropConfig.PropType.AA;
                        baoshi.propTables.Quality = 2;
                        baoshi.propTables.EquipName = "AA2";
                        break;                   
                    case 3:
                        baoshi.propTables.PropType=PropConfig.PropType.AA;
                        baoshi.propTables.Quality = 3;
                        baoshi.propTables.EquipName = "AA3";
                        break;
                    case 4:
                        baoshi.propTables.PropType=PropConfig.PropType.AA;
                        baoshi.propTables.Quality = 4;
                        baoshi.propTables.EquipName = "AA4";
                        break;
                    case 5:
                        baoshi.propTables.PropType=PropConfig.PropType.AA;
                        baoshi.propTables.Quality = 5;
                        baoshi.propTables.EquipName = "AA5";
                        break;
                    case 6:
                        baoshi.propTables.PropType=PropConfig.PropType.AA;
                        baoshi.propTables.Quality = 6;
                        baoshi.propTables.EquipName = "AA6";
                        break;
                }

                return baoshi.gameObject;
            
            case PropConfig.PropType.AC:
                BaoShi baoshi9=BaoShiQueue.Dequeue();
                switch (prop.Quality)
                {
                    case 1:
                        baoshi9.propTables.PropType=PropConfig.PropType.AC;
                        baoshi9.propTables.Quality = 1;
                        baoshi9.propTables.EquipName = "AC1";
                        break;
                    case 2:
                        baoshi9.propTables.PropType=PropConfig.PropType.AC;
                        baoshi9.propTables.Quality = 2;
                        baoshi9.propTables.EquipName = "AC2";
                        break;                   
                    case 3:
                        baoshi9.propTables.PropType=PropConfig.PropType.AC;
                        baoshi9.propTables.Quality = 3;
                        baoshi9.propTables.EquipName = "AC3";
                        break;
                    case 4:
                        baoshi9.propTables.PropType=PropConfig.PropType.AC;
                        baoshi9.propTables.Quality = 4;
                        baoshi9.propTables.EquipName = "AC4";
                        break;
                    case 5:
                        baoshi9.propTables.PropType=PropConfig.PropType.AC;
                        baoshi9.propTables.Quality = 5;
                        baoshi9.propTables.EquipName = "AC5";
                        break;
                    case 6:
                        baoshi9.propTables.PropType=PropConfig.PropType.AC;
                        baoshi9.propTables.Quality = 6;
                        baoshi9.propTables.EquipName = "AC6";
                        break;
                }

                return baoshi9.gameObject;
            
            case PropConfig.PropType.AD:
                BaoShi baoshi8=BaoShiQueue.Dequeue();
                switch (prop.Quality)
                {
                    case 1:
                        baoshi8.propTables.PropType=PropConfig.PropType.AD;
                        baoshi8.propTables.Quality = 1;
                        baoshi8.propTables.EquipName = "AD1";
                        break;
                    case 2:
                        baoshi8.propTables.PropType=PropConfig.PropType.AD;
                        baoshi8.propTables.Quality = 2;
                        baoshi8.propTables.EquipName = "AD2";
                        break;                   
                    case 3:
                        baoshi8.propTables.PropType=PropConfig.PropType.AD;
                        baoshi8.propTables.Quality = 3;
                        baoshi8.propTables.EquipName = "AD3";
                        break;
                    case 4:
                        baoshi8.propTables.PropType=PropConfig.PropType.AD;
                        baoshi8.propTables.Quality = 4;
                        baoshi8.propTables.EquipName = "AD4";
                        break;
                    case 5:
                        baoshi8.propTables.PropType=PropConfig.PropType.AD;
                        baoshi8.propTables.Quality = 5;
                        baoshi8.propTables.EquipName = "AD5";
                        break;
                    case 6:
                        baoshi8.propTables.PropType=PropConfig.PropType.AD;
                        baoshi8.propTables.Quality = 6;
                        baoshi8.propTables.EquipName = "AD6";
                        break;
                }

                return baoshi8.gameObject;
            
            case PropConfig.PropType.HH:
                BaoShi baoshi7=BaoShiQueue.Dequeue();
                switch (prop.Quality)
                {
                    case 1:
                        baoshi7.propTables.PropType=PropConfig.PropType.HH;
                        baoshi7.propTables.Quality = 1;
                        baoshi7.propTables.EquipName = "HH1";
                        break;
                    case 2:
                        baoshi7.propTables.PropType=PropConfig.PropType.HH;
                        baoshi7.propTables.Quality = 2;
                        baoshi7.propTables.EquipName = "HH2";
                        break;                   
                    case 3:
                        baoshi7.propTables.PropType=PropConfig.PropType.HH;
                        baoshi7.propTables.Quality = 3;
                        baoshi7.propTables.EquipName = "HH3";
                        break;
                    case 4:
                        baoshi7.propTables.PropType=PropConfig.PropType.HH;
                        baoshi7.propTables.Quality = 4;
                        baoshi7.propTables.EquipName = "HH4";
                        break;
                    case 5:
                        baoshi7.propTables.PropType=PropConfig.PropType.HH;
                        baoshi7.propTables.Quality = 5;
                        baoshi7.propTables.EquipName = "HH5";
                        break;
                    case 6:
                        baoshi7.propTables.PropType=PropConfig.PropType.HH;
                        baoshi7.propTables.Quality = 6;
                        baoshi7.propTables.EquipName = "HH6";
                        break;
                }

                return baoshi7.gameObject;
            
            case PropConfig.PropType.HA:
                BaoShi baoshi6=BaoShiQueue.Dequeue();
                switch (prop.Quality)
                {
                    case 1:
                        baoshi6.propTables.PropType=PropConfig.PropType.HA;
                        baoshi6.propTables.Quality = 1;
                        baoshi6.propTables.EquipName = "HA1";
                        break;
                    case 2:
                        baoshi6.propTables.PropType=PropConfig.PropType.HA;
                        baoshi6.propTables.Quality = 2;
                        baoshi6.propTables.EquipName = "HA2";
                        break;                   
                    case 3:
                        baoshi6.propTables.PropType=PropConfig.PropType.HA;
                        baoshi6.propTables.Quality = 3;
                        baoshi6.propTables.EquipName = "HA3";
                        break;
                    case 4:
                        baoshi6.propTables.PropType=PropConfig.PropType.HA;
                        baoshi6.propTables.Quality = 4;
                        baoshi6.propTables.EquipName = "HA4";
                        break;
                    case 5:
                        baoshi6.propTables.PropType=PropConfig.PropType.HA;
                        baoshi6.propTables.Quality = 5;
                        baoshi6.propTables.EquipName = "HA5";
                        break;
                    case 6:
                        baoshi6.propTables.PropType=PropConfig.PropType.HA;
                        baoshi6.propTables.Quality = 6;
                        baoshi6.propTables.EquipName = "HA6";
                        break;
                }

                return baoshi6.gameObject;
            
            case PropConfig.PropType.HC:
                BaoShi baoshi5=BaoShiQueue.Dequeue();
                switch (prop.Quality)
                {
                    case 1:
                        baoshi5.propTables.PropType=PropConfig.PropType.HC;
                        baoshi5.propTables.Quality = 1;
                        baoshi5.propTables.EquipName = "HC1";
                        break;
                    case 2:
                        baoshi5.propTables.PropType=PropConfig.PropType.HC;
                        baoshi5.propTables.Quality = 2;
                        baoshi5.propTables.EquipName = "HC2";
                        break;                   
                    case 3:
                        baoshi5.propTables.PropType=PropConfig.PropType.HC;
                        baoshi5.propTables.Quality = 3;
                        baoshi5.propTables.EquipName = "HC3";
                        break;
                    case 4:
                        baoshi5.propTables.PropType=PropConfig.PropType.HC;
                        baoshi5.propTables.Quality = 4;
                        baoshi5.propTables.EquipName = "HC4";
                        break;
                    case 5:
                        baoshi5.propTables.PropType=PropConfig.PropType.HC;
                        baoshi5.propTables.Quality = 5;
                        baoshi5.propTables.EquipName = "HC5";
                        break;
                    case 6:
                        baoshi5.propTables.PropType=PropConfig.PropType.HC;
                        baoshi5.propTables.Quality = 6;
                        baoshi5.propTables.EquipName = "HC6";
                        break;
                }

                return baoshi5.gameObject;
            
            case PropConfig.PropType.HD:
                BaoShi baoshi4=BaoShiQueue.Dequeue();
                switch (prop.Quality)
                {
                    case 1:
                        baoshi4.propTables.PropType=PropConfig.PropType.HD;
                        baoshi4.propTables.Quality = 1;
                        baoshi4.propTables.EquipName = "HD1";
                        break;
                    case 2:
                        baoshi4.propTables.PropType=PropConfig.PropType.HD;
                        baoshi4.propTables.Quality = 2;
                        baoshi4.propTables.EquipName = "HD2";
                        break;                   
                    case 3:
                        baoshi4.propTables.PropType=PropConfig.PropType.HD;
                        baoshi4.propTables.Quality = 3;
                        baoshi4.propTables.EquipName = "HD3";
                        break;
                    case 4:
                        baoshi4.propTables.PropType=PropConfig.PropType.HD;
                        baoshi4.propTables.Quality = 4;
                        baoshi4.propTables.EquipName = "HD4";
                        break;
                    case 5:
                        baoshi4.propTables.PropType=PropConfig.PropType.HD;
                        baoshi4.propTables.Quality = 5;
                        baoshi4.propTables.EquipName = "HD5";
                        break;
                    case 6:
                        baoshi4.propTables.PropType=PropConfig.PropType.HD;
                        baoshi4.propTables.Quality = 6;
                        baoshi4.propTables.EquipName = "HD6";
                        break;
                }

                return baoshi4.gameObject;
            
            case PropConfig.PropType.CC:
                BaoShi baoshi3=BaoShiQueue.Dequeue();
                switch (prop.Quality)
                {
                    case 1:
                        baoshi3.propTables.PropType=PropConfig.PropType.CC;
                        baoshi3.propTables.Quality = 1;
                        baoshi3.propTables.EquipName = "CC1";
                        break;
                    case 2:
                        baoshi3.propTables.PropType=PropConfig.PropType.CC;
                        baoshi3.propTables.Quality = 2;
                        baoshi3.propTables.EquipName = "CC2";
                        break;                   
                    case 3:
                        baoshi3.propTables.PropType=PropConfig.PropType.CC;
                        baoshi3.propTables.Quality = 3;
                        baoshi3.propTables.EquipName = "CC3";
                        break;
                    case 4:
                        baoshi3.propTables.PropType=PropConfig.PropType.CC;
                        baoshi3.propTables.Quality = 4;
                        baoshi3.propTables.EquipName = "CC4";
                        break;
                    case 5:
                        baoshi3.propTables.PropType=PropConfig.PropType.CC;
                        baoshi3.propTables.Quality = 5;
                        baoshi3.propTables.EquipName = "CC5";
                        break;
                    case 6:
                        baoshi3.propTables.PropType=PropConfig.PropType.CC;
                        baoshi3.propTables.Quality = 6;
                        baoshi3.propTables.EquipName = "CC6";
                        break;
                }

                return baoshi3.gameObject;
            
            case PropConfig.PropType.CD:
                BaoShi baoshi2=BaoShiQueue.Dequeue();
                switch (prop.Quality)
                {
                    case 1:
                        baoshi2.propTables.PropType=PropConfig.PropType.CD;
                        baoshi2.propTables.Quality = 1;
                        baoshi2.propTables.EquipName = "CD1";
                        break;
                    case 2:
                        baoshi2.propTables.PropType=PropConfig.PropType.CD;
                        baoshi2.propTables.Quality = 2;
                        baoshi2.propTables.EquipName = "CD2";
                        break;                   
                    case 3:
                        baoshi2.propTables.PropType=PropConfig.PropType.CD;
                        baoshi2.propTables.Quality = 3;
                        baoshi2.propTables.EquipName = "CD3";
                        break;
                    case 4:
                        baoshi2.propTables.PropType=PropConfig.PropType.CD;
                        baoshi2.propTables.Quality = 4;
                        baoshi2.propTables.EquipName = "CD4";
                        break;
                    case 5:
                        baoshi2.propTables.PropType=PropConfig.PropType.CD;
                        baoshi2.propTables.Quality = 5;
                        baoshi2.propTables.EquipName = "CD5";
                        break;
                    case 6:
                        baoshi2.propTables.PropType=PropConfig.PropType.CD;
                        baoshi2.propTables.Quality = 6;
                        baoshi2.propTables.EquipName = "CD6";
                        break;
                }

                return baoshi2.gameObject;
            
            case PropConfig.PropType.DD:
                BaoShi baoshi1=BaoShiQueue.Dequeue();
                switch (prop.Quality)
                {
                    case 1:
                        baoshi1.propTables.PropType=PropConfig.PropType.DD;
                        baoshi1.propTables.Quality = 1;
                        baoshi1.propTables.EquipName = "DD1";
                        break;
                    case 2:
                        baoshi1.propTables.PropType=PropConfig.PropType.DD;
                        baoshi1.propTables.Quality = 2;
                        baoshi1.propTables.EquipName = "DD2";
                        break;                   
                    case 3:
                        baoshi1.propTables.PropType=PropConfig.PropType.DD;
                        baoshi1.propTables.Quality = 3;
                        baoshi1.propTables.EquipName = "DD3";
                        break;
                    case 4:
                        baoshi1.propTables.PropType=PropConfig.PropType.DD;
                        baoshi1.propTables.Quality = 4;
                        baoshi1.propTables.EquipName = "DD4";
                        break;
                    case 5:
                        baoshi1.propTables.PropType=PropConfig.PropType.DD;
                        baoshi1.propTables.Quality = 5;
                        baoshi1.propTables.EquipName = "DD5";
                        break;
                    case 6:
                        baoshi1.propTables.PropType=PropConfig.PropType.DD;
                        baoshi1.propTables.Quality = 6;
                        baoshi1.propTables.EquipName = "DD6";
                        break;
                }
                return baoshi1.gameObject;
                case PropConfig.PropType.ChongWuDan:
                switch (prop.Quality)
                {
                    case 3:
                        var chongwudan = ChongWuDanQueue.Dequeue();
                        chongwudan.quality = 3;
                        return chongwudan.gameObject;
                    case 5:
                        var chongwudan1 = ChongWuDanQueue.Dequeue();
                        chongwudan1.quality = 5;
                        return chongwudan1.gameObject;
                }
                break;
                
                
            case PropConfig.PropType.ChongWuShiWu:
                switch (prop.Quality)
                {
                    case 1:
                        var chongwushiwu1 = ChongWuShiWuQueue.Dequeue();
                        chongwushiwu1.quality = 1;
                        return chongwushiwu1.gameObject;
                    case 2:
                        var chongwushiwu2 = ChongWuShiWuQueue.Dequeue();
                        chongwushiwu2.quality = 2;
                        return chongwushiwu2.gameObject;
                    case 3:
                        var chongwushiwu3 = ChongWuShiWuQueue.Dequeue();
                        chongwushiwu3.quality = 3;
                        return chongwushiwu3.gameObject;
                    case 4:
                        var chongwushiwu4 = ChongWuShiWuQueue.Dequeue();
                        chongwushiwu4.quality = 4;
                        return chongwushiwu4.gameObject;
                    case 5:
                        var chongwushiwu5 = ChongWuShiWuQueue.Dequeue();
                        chongwushiwu5.quality = 5;
                        return chongwushiwu5.gameObject;
                    case 6:
                        var chongwushiwu6 = ChongWuShiWuQueue.Dequeue();
                        chongwushiwu6.quality = 6;
                        return chongwushiwu6.gameObject;
                }
                break;
            
            
            case PropConfig.PropType.SkillShu:
                switch (prop.Quality)
                {
                    case 1:
                        var chongwuSkillShu1 = ChongWuSkillShuQueue.Dequeue();
                        chongwuSkillShu1.quality = 1;
                        return chongwuSkillShu1.gameObject;
                    case 2:
                        var chongwuSkillShu2 = ChongWuSkillShuQueue.Dequeue();
                        chongwuSkillShu2.quality = 2;
                        return chongwuSkillShu2.gameObject;
                    case 3:
                        var chongwuSkillShu3 = ChongWuSkillShuQueue.Dequeue();
                        chongwuSkillShu3.quality = 3;
                        return chongwuSkillShu3.gameObject;
                    case 4:
                        var chongwuSkillShu4 = ChongWuSkillShuQueue.Dequeue();
                        chongwuSkillShu4.quality = 4;
                        return chongwuSkillShu4.gameObject;
                    case 5:
                        var chongwuSkillShu5 = ChongWuSkillShuQueue.Dequeue();
                        chongwuSkillShu5.quality = 5;
                        return chongwuSkillShu5.gameObject;
                    case 6:
                        var chongwuSkillShu6 = ChongWuSkillShuQueue.Dequeue();
                        chongwuSkillShu6.quality = 6;
                        return chongwuSkillShu6.gameObject;
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
    public OrangeEquipType GetRandomOrangeEquip()
    {
        Array values = Enum.GetValues(typeof(OrangeEquipType));
        return (OrangeEquipType)values.GetValue(Random.Range(1, values.Length));
    }

       public GameObject GetOrangeEquip(OrangeEquipType type)
    {
        switch (type)
        {
            case OrangeEquipType.BuWangChuXin:
                return BuWangChuXinQueue.Dequeue();
            case OrangeEquipType.CloakFortureAdd:
                return CloakFortureAddQueue.Dequeue();
            case OrangeEquipType.DuAddDuQuan:
                return DuAddDuQuanQueue.Dequeue();
            case OrangeEquipType.FireBaoZha:
                return FireBaoZhaQueue.Dequeue();
            case OrangeEquipType.HeiDongAddSpeed:
                return HeiDongAddSpeedQueue.Dequeue();
            case OrangeEquipType.LvQuanAddScale:
                return LvQuanAddScaleQueue.Dequeue();
            case OrangeEquipType.PuTong3ChuanTou:
                return PuTong3ChuanTouQueue.Dequeue();
            case OrangeEquipType.XuKongAdd2Dan:
                return XuKongAdd2DanQueue.Dequeue();
            case OrangeEquipType.AddDefenseForTime:
                return AddDefenseForTimeQueue.Dequeue();
            case OrangeEquipType.AllReplyAddPercent:
                return AllReplyAddPercentQueue.Dequeue();
            case OrangeEquipType.ClothFortureAdd:
                return ClothFortureAddQueue.Dequeue();
            case OrangeEquipType.FinalDamageReductionFixed:
                return FinalDamageReductionFixedQueue.Dequeue();
            case OrangeEquipType.HpReductionReplyAdd50:
                return HpReductionReplyAdd50Queue.Dequeue();
            case OrangeEquipType.ReplyDeath:
                return ReplyDeathQueue.Dequeue();
            case OrangeEquipType.AddHpForTime:
                return AddHpForTimeQueue.Dequeue();
            case OrangeEquipType.DelayDamage:
                return DelayDamageQueue.Dequeue();
            case OrangeEquipType.FinalDamageReductionPercent:
                return FinalDamageReductionPercentQueue.Dequeue();
            case OrangeEquipType.HelmetFortureAdd:
                return HelmetFortureAddQueue.Dequeue();
            case OrangeEquipType.HpReductionAddDefense:
                return HpReductionAddDefenseQueue.Dequeue();
            case OrangeEquipType.Skill1AddRange:
                return Skill1AddRangeQueue.Dequeue();
            case OrangeEquipType.Skill2AddRange:
                return Skill2AddRangeQueue.Dequeue();
            case OrangeEquipType.FinalDamageAddPercent:
                return FinalDamageAddPercentQueue.Dequeue();
            case OrangeEquipType.NecklaceFortureAdd:
                return NecklaceFortureAddQueue.Dequeue();
            case OrangeEquipType.NormalAddDamage:
                return NormalAddDamageQueue.Dequeue();
            case OrangeEquipType.NoSkill:
                return NoSkillQueue.Dequeue();
            case OrangeEquipType.RecudeHpAddAttack:
                return RecudeHpAddAttackQueue.Dequeue();
            case OrangeEquipType.Skill1ReplaceNormalAttack:
                return Skill1ReplaceNormalAttackQueue.Dequeue();
            case OrangeEquipType.Skill2AddDan:
                return Skill2AddDanQueue.Dequeue();
            case OrangeEquipType.Skill3Bian3:
                return Skill3Bian3Queue.Dequeue();
            case OrangeEquipType.AddAttackForTime:
                return AddAttackForTimeQueue.Dequeue();
            case OrangeEquipType.FanPuGuiZhen:
                return FanPuGuiZhenQueue.Dequeue();
            case OrangeEquipType.KillNormal:
                return KillNormalQueue.Dequeue();
            case OrangeEquipType.RingFortureAdd:
                return RingFortureAddQueue.Dequeue();
            case OrangeEquipType.Skill1YiDianDouble:
                return Skill1YiDianDoubleQueue.Dequeue();
            case OrangeEquipType.Skill2RotateAdd:
                return Skill2RotateAddQueue.Dequeue();
            case OrangeEquipType.Skill3AddRange:
                return Skill3AddRangeQueue.Dequeue();
            case OrangeEquipType.DashCd:
                return DashCdQueue.Dequeue();
            case OrangeEquipType.DashRange:
                return DashRangeQueue.Dequeue();
            case OrangeEquipType.ExAdd:
                return ExAddQueue.Dequeue();
            case OrangeEquipType.JianSuAddAttack:
                return JianSuAddAttackQueue.Dequeue();
            case OrangeEquipType.MoveSpeedAdd:
                return MoveSpeedAddQueue.Dequeue();
            case OrangeEquipType.ShoeFortureAdd:
                return ShoeFortureAddQueue.Dequeue();
            default:
                return null;
        }
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
            
            case PlayerEquipConfig.EquipLevel.ZhaoZe:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return ZhaoZeCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return ZhaoZeClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return ZhaoZeRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return ZhaoZeShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return ZhaoZeHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return ZhaoZeNecklaceQueue.Dequeue();
                }
                break;
            
            
            
            case PlayerEquipConfig.EquipLevel.XueRen:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return XueRenCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return XueRenClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return XueRenRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return XueRenShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return XueRenHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return XueRenNecklaceQueue.Dequeue();
                }
                break;
            
            
            
            case PlayerEquipConfig.EquipLevel.XieZi:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return XieZiCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return XieZiClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return XieZiRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return XieZiShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return XieZiHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return XieZiNecklaceQueue.Dequeue();
                }
                break;
            
            case PlayerEquipConfig.EquipLevel.Purple1:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return Purple1CloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return Purple1ClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return Purple1RingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return Purple1ShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return Purple1HelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return Purple1NecklaceQueue.Dequeue();
                }
                break;
        }

        return equip;
    }
    
    private void Awake()
    {
        RegisterEvent();
        GameOver = false;
        DontDestroyOnLoad(gameObject);
        var _ = SkillController.S;//激活SkillController
    }

    public int[] SelectTwoUniqueNumbers()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 ,10,11,12,13,14};
        int[] selected = new int[2];
        
        for (int i = 0; i < 2; i++)
        {
            int randomIndex = Random.Range(0, numbers.Count);
            selected[i] = numbers[randomIndex];
            numbers.RemoveAt(randomIndex);
        }
        
        return selected;
    }
    

    public void ShowChuanSongZhen()
    {
        fightBG.GetComponent<FightBg>().ChuanSongZhen.SetActive(true);
    }

    public void JiHuoChuanSongZhen()
    {
        fightBG.GetComponent<FightBg>().ChuanSongZhenAnimator.Play("NewSequenceAnim");
    }
    private void Start()
    {
        KillMonsterCount = 0;
        //初始化地图
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

        if (LevelInfoConfig.CurrentGameLevel > 15)
        {
            var random = new System.Random();
            var index= random.Next(1, 3);
            switch (index)
            {
                case 1:
                    transform.Find("FightBG(Clone)/MiJing1").gameObject.SetActive(true);
                    break;
                case 2:
                    transform.Find("FightBG(Clone)/MiJing2").gameObject.SetActive(true);
                    break;
            }
        }
        
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
        //按钮冰爆技能
        FightBGController.S.iceExButton.onClick.AddListener(() =>
        {
            if (SkillController.S.IceExplosionCoolingtime > SkillController.S.IceExplosiontime)
            {
                AudioController.S.PlayIceEx();
                SkillController.S.IceExplosionCoolingtime=0;
                SkillController.S.IceExTrigger.gameObject.SetActive(true);
            }
        });
        //按钮冰球
        FightBGController.S.iceBallButton.onClick.AddListener(() =>
        {
            if (SkillController.S.IceBallCoolingtime > SkillController.S.IceBalltime)
            {
                AudioController.S.PlayIceBall();
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
        //召唤BOSS，激活BOSS，bosswarning动画
        if (KillMonsterCount>=LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel]/2 && HaveBossWarning == false&&(LevelInfoConfig.CurrentGameLevelType==LevelType.Normal||LevelInfoConfig.CurrentGameLevelType==LevelType.MJ))
        {
            gamePlayer.ShowArrow();
            HaveBossWarning=true;
            BossJiHuo = true;
            ShowChuanSongZhen();
            Instantiate(Resources.Load("Prefabs/Tool/Warning"));
        }
    }
    
     //创建boss
    public void CreateBoss()
    {
        HaveBoss = true;
        if (LevelInfoConfig.CurrentGameLevel == 3)
        {
            TreeManBoss treeManBoss=Instantiate(Resources.Load<TreeManBoss>("Prefabs/Monster/Level1/TreeManBOSS")); treeManBoss.transform.position = new Vector3(0 ,0, 0f);
              treeManBoss.gameObject.SetActive(true);
             SkeletonAnimation sk=treeManBoss.transform.Find("parent/TreeManSkeleton").GetComponent<SkeletonAnimation>();
             treeManBoss.IsSkill = true;
             sk.AnimationState.SetAnimation(0,"Exit",false);
             treeManBoss.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
             MonsterColliderDic.Add(treeManBoss.collider2D,treeManBoss);
        }
        if (LevelInfoConfig.CurrentGameLevel == 6)
        {
            HuoShanBoss huoShanBoss = Instantiate(Resources.Load<HuoShanBoss>("Prefabs/Monster/Level2/HuoShanBOSS"));
            huoShanBoss.gameObject.SetActive(true);
            huoShanBoss.IsSkill = true;
            huoShanBoss.transform.position = new Vector3(0, 0, 0f);
            SkeletonAnimation sk = huoShanBoss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>();
            sk.AnimationState.SetAnimation(0,"Exit",false);
            huoShanBoss.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            MonsterColliderDic.Add(huoShanBoss.collider2D,huoShanBoss);
        }
        if (LevelInfoConfig.CurrentGameLevel == 9)
        {
            ZhaoZeBoss ZhaoZeboss = Instantiate(Resources.Load<ZhaoZeBoss>("Prefabs/Monster/Level3/ZhaoZeBOSS"));
            ZhaoZeboss.gameObject.SetActive(true);
            ZhaoZeboss.IsSkill = true;
            ZhaoZeboss.transform.position = new Vector3(0, 0, 0f);
            SkeletonAnimation sk = ZhaoZeboss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>();
            sk.AnimationState.SetAnimation(0,"appear",false);
            ZhaoZeboss.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            MonsterColliderDic.Add(ZhaoZeboss.collider2D,ZhaoZeboss);
        }
        
        if (LevelInfoConfig.CurrentGameLevel == 12)
        {
            XieZi xieZiboss = Instantiate(Resources.Load<XieZi>("Prefabs/Monster/Level4/XieZi"));
            xieZiboss.gameObject.SetActive(true);
            xieZiboss.IsSkill = true;
            xieZiboss.transform.position = new Vector3(0, 0, 0f);
            SkeletonAnimation sk = xieZiboss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>();
            sk.AnimationState.SetAnimation(0,"chuchang",false);
            xieZiboss.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            MonsterColliderDic.Add(xieZiboss.collider2D,xieZiboss);

        }
        
        if (LevelInfoConfig.CurrentGameLevel == 15)
        {
            XueRenBoss XueRenBoss = Instantiate(Resources.Load<XueRenBoss>("Prefabs/Monster/Level5/XueRenBoss"));
            XueRenBoss.gameObject.SetActive(true);
            XueRenBoss.IsSkill = true;
            XueRenBoss.transform.position = new Vector3(0, 0, 0f);
            SkeletonAnimation sk = XueRenBoss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>();
            sk.AnimationState.SetAnimation(0,"appear",false);
            XueRenBoss.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            MonsterColliderDic.Add(XueRenBoss.collider2D,XueRenBoss);
        }

        if (LevelInfoConfig.CurrentGameLevel > 15)
        {
            
            switch (PlayerData.S.mJShowLevel)
            {
                case MJLevel.White:
                    LeiShouBoss LeiShouBoss = Instantiate(Resources.Load<LeiShouBoss>("Prefabs/Monster/MJ/LeiShou/LeiShouBoss"));
                    LeiShouBoss.gameObject.SetActive(true);
                    LeiShouBoss.IsSkill = true;
                    LeiShouBoss.transform.position = new Vector3(0, 0, 0f);
                    SkeletonAnimation sk = LeiShouBoss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>();
                    sk.AnimationState.SetAnimation(0,"skill2",false);
                    LeiShouBoss.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    MonsterColliderDic.Add(LeiShouBoss.collider2D,LeiShouBoss);
                    break;
                case MJLevel.Green:
                    KuiJiaBoss KuiJiaBoss = Instantiate(Resources.Load<KuiJiaBoss>("Prefabs/Monster/MJ/KuiJia/KuiJiaBoss"));
                    KuiJiaBoss.gameObject.SetActive(true);
                    KuiJiaBoss.IsSkill = true;
                    KuiJiaBoss.transform.position = new Vector3(0, 0, 0f);
                    SkeletonAnimation sk1 = KuiJiaBoss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>();
                    sk1.AnimationState.SetAnimation(0,"skill2",false);
                    KuiJiaBoss.KuiJiaSkillType = KuiJiaSkillType.ChuChang;
                    KuiJiaBoss.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    MonsterColliderDic.Add(KuiJiaBoss.collider2D,KuiJiaBoss);
                    break;
                
                case MJLevel.Blue:
                    BaoZiBoss BaoZiBoss = Instantiate(Resources.Load<BaoZiBoss>("Prefabs/Monster/MJ/BaoZi/BaoZiBoss"));
                    BaoZiBoss.gameObject.SetActive(true);
                    BaoZiBoss.IsSkill = true;
                    BaoZiBoss.transform.position = new Vector3(0, 0, 0f);
                    SkeletonAnimation sk2 = BaoZiBoss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>();
                    sk2.AnimationState.SetAnimation(0,"skill1",false);
                    BaoZiBoss.BaoZiSkillType = BaoZiSkillType.ChuChang;
                    BaoZiBoss.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    MonsterColliderDic.Add(BaoZiBoss.collider2D,BaoZiBoss);
                    break;
                
                case MJLevel.Purple:
                    HuoLangBoss HuoLangBoss = Instantiate(Resources.Load<HuoLangBoss>("Prefabs/Monster/MJ/HuoLang/HuoLangBoss"));
                    HuoLangBoss.gameObject.SetActive(true);
                    HuoLangBoss.IsSkill = true;
                    HuoLangBoss.transform.position = new Vector3(0, 0, 0f);
                    SkeletonAnimation sk3 = HuoLangBoss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>();
                    sk3.AnimationState.SetAnimation(0,"skill2",false);
                    HuoLangBoss.HuoLangSkill2Type = HuoLangSkill2Type.ChuChang;
                    HuoLangBoss.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    MonsterColliderDic.Add(HuoLangBoss.collider2D,HuoLangBoss);
                    break;
                
                case MJLevel.Orange:
                    ShuangDaoBoss ShuangDaoBoss = Instantiate(Resources.Load<ShuangDaoBoss>("Prefabs/Monster/MJ/ShuangDao/ShuangDaoBoss"));
                    ShuangDaoBoss.gameObject.SetActive(true);
                    ShuangDaoBoss.IsSkill = true;
                    ShuangDaoBoss.transform.position = new Vector3(0, 0, 0f);
                    SkeletonAnimation sk4 = ShuangDaoBoss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>();
                    sk4.AnimationState.SetAnimation(0,"chuchang",false);
                    ShuangDaoBoss.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    MonsterColliderDic.Add(ShuangDaoBoss.collider2D,ShuangDaoBoss);
                    break;
            }
        }
    }

    public bool GetIsCrit()
    {
        var random=Random.Range(0,10000);
        if(GlobalPlayerAttribute.TotalCRIT>=random)
        {
            CritCount++;
            CritCount=Math.Min(10,CritCount);
            return true;
        }
        return false;
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
        Vector2 pos = Vector2.zero;
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        pos=(Vector2)gamePlayer.transform.position + randomDirection * radius;
        while (pos.x <= CameraContraller.S.LeftLimit + 2 || pos.x > CameraContraller.S.RightLimit - 2 ||
               pos.y > CameraContraller.S.UpLimit - 2 || pos.y < CameraContraller.S.ButtomLimit + 2)
        {
            randomDirection = Random.insideUnitCircle.normalized;
            pos=(Vector2)gamePlayer.transform.position + randomDirection * radius;
        }
        // 乘以半径并加上玩家位置
        return pos;
    }

    public void CreateEliteMonster()
    {
        if (GameOver)
            return;
        Vector2 monsterRandomPoint = GetRandomPointOnCircle(10);

        List<MonsterTypeByName> monsterList = null;
        monsterList = LevelInfoConfig.LevelMonsterDic[LevelInfoConfig.CurrentGameLevel];
        if (EliteMonster == MonsterTypeByName.None)
        {
            foreach (var item in monsterList)
            {
                if (MonsterConfig.MonsterTypeDic[item] == MonsterType.Elite)
                {
                    EliteMonster = item;
                    break;
                }
            }
        }

        MonsterBase monster = LevelInfoConfig.GetMonster(EliteMonster);
        monster.gameObject.SetActive(true);
        monster.CurrentHp = monster.MaxHp;
        monster.transform.position = monsterRandomPoint;
        monster.monsterSkeletonAnimation.AnimationState.SetAnimation(0, monster.MonsterSpineName.MoveName, true);
        monster.hpSliderCanvas.sortingOrder = 2000 + EliteMonsterCount;
        TotalMonsterCount++;
        EliteMonsterCount++;
    }

    //生成怪物
    public void CreateMonster()
    {
        if (GameOver||HaveBoss)
            return;
        //控制同屏怪物数量
        if (TotalMonsterCount - KillMonsterCount >= LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel] / 2)
        {
            return;
        }

        if (TotalMonsterCount > LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel])
        {
            return;
        }
        Vector2 monsterRandomPoint = GetRandomPointOnCircle(10);
        MonsterBase monsterBase=null;
        //宠物关卡
        if (NormalMonster.Count==0)
        {
            List<MonsterTypeByName> monsterList=LevelInfoConfig.LevelMonsterDic[LevelInfoConfig.CurrentGameLevel];
            foreach (var item in monsterList)
            {
                if (MonsterConfig.MonsterTypeDic[item] == MonsterType.Normal)
                {
                    NormalMonster.Add(item);
                }
            }
        }

        var random = Random.Range(0, NormalMonster.Count);
        monsterBase=LevelInfoConfig.GetMonster(NormalMonster[random]);
        if (monsterBase == null)
        {
            return;
        }
        monsterBase.gameObject.SetActive(true);
        monsterBase.transform.position = monsterRandomPoint;
        monsterBase.CurrentHp = monsterBase.MaxHp;
        monsterBase.hpSliderCanvas.sortingOrder = 1000+NormalMonsterCount;
        if (monsterBase.monsterSkeletonAnimation != null)
        {
            monsterBase.monsterSkeletonAnimation.AnimationState.SetAnimation(0, monsterBase.MonsterSpineName.MoveName, true);
        }
      
        TotalMonsterCount++;
        NormalMonsterCount++;

        if(NormalMonsterCount%10==0&& NormalMonsterCount!=0)
         {
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
            if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.AddDefenseForTime))
            {
                AddDefenseForTimeCount++;
                AddDefenseForTimeCount = Math.Min(10, AddDefenseForTimeCount);
            }
            
            if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.AddAttackForTime))
            {
                AddAttackForTimeCount++;
                AddAttackForTimeCount = Math.Min(10, AddAttackForTimeCount);
            }
    }

    //收集装备
    public void CollectEquip()
    {
        foreach (var item in EquipBaseSet)
        {
            item.speed = 4;
            item.isPickUp = true;
        }
        foreach (var item in PropBaseSet)
        {
            item.speed = 4;
            item.isPickUp = true;
        }
    }

    private void Update()
    {
        if (GlobalPlayerAttribute.IsGame == false)
            return;
        if (GlobalPlayerAttribute.CDTeXiao5Time > 0)
        {
            GlobalPlayerAttribute.CDTeXiao5Time-= Time.deltaTime;
        }
        
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
        if (currentTime >= monsterBirthTimeScale)
        {
            CreateMonster();
            currentTime = 0f;
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