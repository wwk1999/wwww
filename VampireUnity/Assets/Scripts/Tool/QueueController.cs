using System;
using System.Collections;
using System.Collections.Generic;
using Prop.BaoShi;
using Skill.NormalAttack.Primary;
using UnityEngine;

public class QueueController : XSingleton<QueueController>
{
    public GameObject fightBG;
    
    [NonSerialized] public float GameMaxHp = 0;
    [NonSerialized] public float GameCurrentHp = 0;
    public float GameDefense =>GameController.S.GetGameDefense();
    public float GameAttack =>GameController.S.GetGameAttack();
    [NonSerialized] public float GameCrit = 0;
    public Dictionary<Collider2D, MonsterBase> MonsterColliderDic = new Dictionary<Collider2D, MonsterBase>();

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



    [NonSerialized] public Queue<HuoShouDan> HuoShouDanQueue = new Queue<HuoShouDan>();
    [NonSerialized] public Queue<HuoShouBaoZha> HuoShouBaoZhaQueue = new Queue<HuoShouBaoZha>();
    [NonSerialized] public Queue<HuoShouDiPen> HuoShouDiPenQueue = new Queue<HuoShouDiPen>();


    [NonSerialized] public Queue<DaEYuShuiPen> DaEYuShuiPenQueue = new Queue<DaEYuShuiPen>();
    [NonSerialized] public Queue<DaEYuDanXiao> DaEYuDanXiaoQueue = new Queue<DaEYuDanXiao>();
    [NonSerialized] public Queue<DaEYuDan> DaEYuDanQueue = new Queue<DaEYuDan>();
    [NonSerialized] public Queue<DaEYuBaoZha> DaEYuBaoZhaQueue = new Queue<DaEYuBaoZha>();


    
    
    
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

    [NonSerialized]public Player gamePlayer;
    
    [NonSerialized]public HashSet<EquipBase> EquipBaseSet = new HashSet<EquipBase>();
    [NonSerialized]public HashSet<PropBase> PropBaseSet = new HashSet<PropBase>();
    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void FightAgain()
    {
        fightBG.SetActive(true);
        foreach (var item in MonsterColliderDic.Values)
        {
            if (item != null)
            {
                item.gameObject.SetActive(false);
            }
        }
        gamePlayer.gameObject.SetActive(false);
        foreach (var item in EquipBaseSet)
        {
            item.gameObject.SetActive(false);
        }
        EquipBaseSet.Clear();
        foreach (var item in PropBaseSet)
        {
            item.gameObject.SetActive(false);
        }
        PropBaseSet.Clear();
    }

    public void FightExit()
    {
        fightBG.SetActive(false);
        foreach (var item in MonsterColliderDic.Values)
        {
            if (item != null)
            {
                item.gameObject.SetActive(false);
            }
        }
        gamePlayer.gameObject.SetActive(false);
        foreach (var item in EquipBaseSet)
        {
            item.gameObject.SetActive(false);
        }
        EquipBaseSet.Clear();
        foreach (var item in PropBaseSet)
        {
            item.gameObject.SetActive(false);
        }
        PropBaseSet.Clear();
        AudioController.S.BGAudioSource.clip = Resources.Load<AudioClip>("Audio/BG/UIBG");
        AudioController.S.BGAudioSource.loop = true;
    }
    
}
