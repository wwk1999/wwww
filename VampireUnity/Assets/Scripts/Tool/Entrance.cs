using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Config;
using Equip;
using Mysql;
using Prop.BaoShi;
using Skill.NormalAttack.Primary;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Entrance : MonoBehaviour
{
    public static void InitOrangeQueue()
    {
        for (int i = 0; i < 15; i++)
        {
            //传说装备

            EquipBase Orange =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Orange"),QueueController.S.transform).GetComponent<EquipBase>();
            Orange.gameObject.SetActive(false);
            QueueController.S.OrangeEquipQueue.Enqueue(Orange);
        }
    }


    public static void InitMonster(MonsterTypeByName type)
{
    // Level 3: TreeManDanMu（技能对象，使用普通怪物容量）
    if (LevelInfoConfig.CurrentGameLevel == 3)
    {
        int limitSkill = LevelInfoConfig.NormalMonsterQueueCount;
        if (QueueController.S.TreeManDanMuQueue.Count <= limitSkill)
        {
            var TreeManDanMu = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level1/TreeManDanMu").GetComponent<TreeManDanMu>(),
                QueueController.S.transform);
            TreeManDanMu.gameObject.SetActive(false);
            QueueController.S.TreeManDanMuQueue.Enqueue(TreeManDanMu);
        }
    }

    // Level 12: XieZiSkill1 和 XieZiSkill4（技能对象）
    if (LevelInfoConfig.CurrentGameLevel == 12)
    {
        int limitSkill = LevelInfoConfig.NormalMonsterQueueCount;
        if (QueueController.S.XieZiSkill1Queue.Count <= limitSkill)
        {
            var xieziskill1 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level4/XieZiSkill1").GetComponent<XieZiSkill1>(),
                QueueController.S.transform);
            xieziskill1.gameObject.SetActive(false);
            QueueController.S.XieZiSkill1Queue.Enqueue(xieziskill1);
        }
        if (QueueController.S.XieZiSkill4Queue.Count <= limitSkill)
        {
            var xieziskill4 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level4/XieZiSkill4").GetComponent<XieZiSkill4>(),
                QueueController.S.transform);
            xieziskill4.gameObject.SetActive(false);
            QueueController.S.XieZiSkill4Queue.Enqueue(xieziskill4);
        }
    }

    switch (type)
    {
        case MonsterTypeByName.Snot:
            int limitSnot = MonsterConfig.MonsterTypeDic[MonsterTypeByName.Snot] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.SnotMonsterQueue.Count > limitSnot) break;
            var snotMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level1/SnotMonster").GetComponent<SnotMonster>(),
                QueueController.S.transform);
            snotMonster.gameObject.SetActive(false);
            QueueController.S.SnotMonsterQueue.Enqueue(snotMonster);
            QueueController.S.MonsterColliderDic.Add(snotMonster.collider2D, snotMonster);
            break;

        case MonsterTypeByName.Bat:
            int limitBat = MonsterConfig.MonsterTypeDic[MonsterTypeByName.Bat] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.BatMonsterQueue.Count > limitBat) break;
            var BatMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level1/BatMonster").GetComponent<BatMonster>(),
                QueueController.S.transform);
            BatMonster.gameObject.SetActive(false);
            QueueController.S.BatMonsterQueue.Enqueue(BatMonster);
            QueueController.S.MonsterColliderDic.Add(BatMonster.collider2D, BatMonster);
            break;

        case MonsterTypeByName.Bee:
            int limitBee = MonsterConfig.MonsterTypeDic[MonsterTypeByName.Bee] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.EliteBeeMonsterQueue.Count <= limitBee)
            {
                var BeeMonster = Instantiate(
                    Resources.Load<GameObject>("Prefabs/Monster/Level1/EliteBeeMonster").GetComponent<EliteBeeMonster>(),
                    QueueController.S.transform);
                BeeMonster.gameObject.SetActive(false);
                QueueController.S.EliteBeeMonsterQueue.Enqueue(BeeMonster);
                QueueController.S.MonsterColliderDic.Add(BeeMonster.collider2D, BeeMonster);
            }
            int limitBullet = LevelInfoConfig.NormalMonsterQueueCount; // 子弹队列容量（可单独配置）
            if (QueueController.S.BeeBulletQueue.Count <= limitBullet)
            {
                var BeeBullet = Instantiate(
                    Resources.Load<GameObject>("Prefabs/Monster/Level1/BeeBullet").GetComponent<BeeBullet>(),
                    QueueController.S.transform);
                BeeBullet.gameObject.SetActive(false);
                QueueController.S.BeeBulletQueue.Enqueue(BeeBullet);
            }
            break;

        case MonsterTypeByName.Spider:
            int limitSpider = MonsterConfig.MonsterTypeDic[MonsterTypeByName.Spider] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.SpiderMonsterQueue.Count > limitSpider) break;
            var SpiderMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level1/SpiderMonster").GetComponent<SpiderMonster>(),
                QueueController.S.transform);
            SpiderMonster.gameObject.SetActive(false);
            QueueController.S.SpiderMonsterQueue.Enqueue(SpiderMonster);
            QueueController.S.MonsterColliderDic.Add(SpiderMonster.collider2D, SpiderMonster);
            break;

        case MonsterTypeByName.XiaoHuo:
            int limitXiaoHuo = MonsterConfig.MonsterTypeDic[MonsterTypeByName.XiaoHuo] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.XiaoHuoMonsterQueue.Count > limitXiaoHuo) break;
            var XiaoHuoMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level2/XiaoHuoMonster").GetComponent<XiaoHuoMonster>(),
                QueueController.S.transform);
            XiaoHuoMonster.gameObject.SetActive(false);
            QueueController.S.XiaoHuoMonsterQueue.Enqueue(XiaoHuoMonster);
            QueueController.S.MonsterColliderDic.Add(XiaoHuoMonster.collider2D, XiaoHuoMonster);
            break;

        case MonsterTypeByName.ChongZi:
            int limitChongZi = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ChongZi] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.ChongZiMonsterQueue.Count > limitChongZi) break;
            var ChongZiMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level2/ChongZiMonster").GetComponent<ChongZiMonster>(),
                QueueController.S.transform);
            ChongZiMonster.gameObject.SetActive(false);
            QueueController.S.ChongZiMonsterQueue.Enqueue(ChongZiMonster);
            QueueController.S.MonsterColliderDic.Add(ChongZiMonster.collider2D, ChongZiMonster);
            break;

        case MonsterTypeByName.DaZui:
            int limitDaZui = MonsterConfig.MonsterTypeDic[MonsterTypeByName.DaZui] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.EliteDaZuiMonsterQueue.Count > limitDaZui) break;
            var DaZuiMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level2/EliteDaZuiMonster").GetComponent<EliteDaZuiMonster>(),
                QueueController.S.transform);
            DaZuiMonster.gameObject.SetActive(false);
            QueueController.S.EliteDaZuiMonsterQueue.Enqueue(DaZuiMonster);
            QueueController.S.MonsterColliderDic.Add(DaZuiMonster.collider2D, DaZuiMonster);
            break;

        case MonsterTypeByName.DunDi:
            int limitDunDi = MonsterConfig.MonsterTypeDic[MonsterTypeByName.DunDi] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.DunDiMonsterQueue.Count > limitDunDi) break;
            var DunDiMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level2/DunDiMonster").GetComponent<DunDiMonster>(),
                QueueController.S.transform);
            DunDiMonster.gameObject.SetActive(false);
            QueueController.S.DunDiMonsterQueue.Enqueue(DunDiMonster);
            QueueController.S.MonsterColliderDic.Add(DunDiMonster.collider2D, DunDiMonster);
            break;

        case MonsterTypeByName.JiaChong:
            int limitJiaChong = MonsterConfig.MonsterTypeDic[MonsterTypeByName.JiaChong] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.JiaChongMonsterQueue.Count > limitJiaChong) break;
            var JiaChongMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level3/JiaChongMonster").GetComponent<JiaChongMonster>(),
                QueueController.S.transform);
            JiaChongMonster.gameObject.SetActive(false);
            QueueController.S.JiaChongMonsterQueue.Enqueue(JiaChongMonster);
            QueueController.S.MonsterColliderDic.Add(JiaChongMonster.collider2D, JiaChongMonster);
            break;

        case MonsterTypeByName.QingWa:
            int limitQingWa = MonsterConfig.MonsterTypeDic[MonsterTypeByName.QingWa] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.QingWaMonsterQueue.Count > limitQingWa) break;
            var QingWaMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level3/QingWaMonster").GetComponent<QingWaMonster>(),
                QueueController.S.transform);
            QingWaMonster.gameObject.SetActive(false);
            QueueController.S.QingWaMonsterQueue.Enqueue(QingWaMonster);
            QueueController.S.MonsterColliderDic.Add(QingWaMonster.collider2D, QingWaMonster);
            break;

        case MonsterTypeByName.ShiRenHua:
            int limitShiRenHua = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShiRenHua] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.ShiRenHuaMonsterQueue.Count > limitShiRenHua) break;
            var ShiRenHuaMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level3/ShiRenHuaMonster").GetComponent<ShiRenHuaMonster>(),
                QueueController.S.transform);
            ShiRenHuaMonster.gameObject.SetActive(false);
            QueueController.S.ShiRenHuaMonsterQueue.Enqueue(ShiRenHuaMonster);
            QueueController.S.MonsterColliderDic.Add(ShiRenHuaMonster.collider2D, ShiRenHuaMonster);
            break;

        case MonsterTypeByName.WenZi:
            int limitWenZi = MonsterConfig.MonsterTypeDic[MonsterTypeByName.WenZi] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.WenZiMonsterQueue.Count > limitWenZi) break;
            var WenZiMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level3/WenZiMonster").GetComponent<WenZiMonster>(),
                QueueController.S.transform);
            WenZiMonster.gameObject.SetActive(false);
            QueueController.S.WenZiMonsterQueue.Enqueue(WenZiMonster);
            QueueController.S.MonsterColliderDic.Add(WenZiMonster.collider2D, WenZiMonster);
            break;

        case MonsterTypeByName.XueQiE:
            int limitXueQiE = MonsterConfig.MonsterTypeDic[MonsterTypeByName.XueQiE] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.XueQiEQueue.Count > limitXueQiE) break;
            var XueQiEMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level5/XueQiE").GetComponent<XueQiE>(),
                QueueController.S.transform);
            XueQiEMonster.gameObject.SetActive(false);
            QueueController.S.XueQiEQueue.Enqueue(XueQiEMonster);
            QueueController.S.MonsterColliderDic.Add(XueQiEMonster.collider2D, XueQiEMonster);
            break;

        case MonsterTypeByName.XueZhangLang:
            int limitXueZhangLang = MonsterConfig.MonsterTypeDic[MonsterTypeByName.XueZhangLang] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.XueZhangLangQueue.Count > limitXueZhangLang) break;
            var XueZhangLangMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level5/XueZhangLang").GetComponent<XueZhangLang>(),
                QueueController.S.transform);
            XueZhangLangMonster.gameObject.SetActive(false);
            QueueController.S.XueZhangLangQueue.Enqueue(XueZhangLangMonster);
            QueueController.S.MonsterColliderDic.Add(XueZhangLangMonster.collider2D, XueZhangLangMonster);
            break;

        case MonsterTypeByName.YingShu:
            int limitYingShu = MonsterConfig.MonsterTypeDic[MonsterTypeByName.YingShu] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.YingShuQueue.Count > limitYingShu) break;
            var YingShuMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level5/YingShu").GetComponent<YingShu>(),
                QueueController.S.transform);
            YingShuMonster.gameObject.SetActive(false);
            QueueController.S.YingShuQueue.Enqueue(YingShuMonster);
            QueueController.S.MonsterColliderDic.Add(YingShuMonster.collider2D, YingShuMonster);
            break;

        case MonsterTypeByName.XueRen:
            int limitXueRen = MonsterConfig.MonsterTypeDic[MonsterTypeByName.XueRen] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.XueRenQueue.Count > limitXueRen) break;
            var XueRenMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level5/XueRen").GetComponent<XueRen>(),
                QueueController.S.transform);
            XueRenMonster.gameObject.SetActive(false);
            QueueController.S.XueRenQueue.Enqueue(XueRenMonster);
            QueueController.S.MonsterColliderDic.Add(XueRenMonster.collider2D, XueRenMonster);
            break;

        case MonsterTypeByName.ShaXiYi:
            int limitShaXiYi = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShaXiYi] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.ShaXiYiQueue.Count > limitShaXiYi) break;
            var ShaXiYiMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level4/ShaXiYi").GetComponent<ShaXiYi>(),
                QueueController.S.transform);
            ShaXiYiMonster.gameObject.SetActive(false);
            QueueController.S.ShaXiYiQueue.Enqueue(ShaXiYiMonster);
            QueueController.S.MonsterColliderDic.Add(ShaXiYiMonster.collider2D, ShaXiYiMonster);
            break;

        case MonsterTypeByName.XianRenZhang:
            int limitXianRenZhang = MonsterConfig.MonsterTypeDic[MonsterTypeByName.XianRenZhang] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.XianRenZhangQueue.Count > limitXianRenZhang) break;
            var XianRenZhangMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level4/XianRenZhang").GetComponent<XianRenZhang>(),
                QueueController.S.transform);
            XianRenZhangMonster.gameObject.SetActive(false);
            QueueController.S.XianRenZhangQueue.Enqueue(XianRenZhangMonster);
            QueueController.S.MonsterColliderDic.Add(XianRenZhangMonster.collider2D, XianRenZhangMonster);
            break;

        case MonsterTypeByName.ShaChong:
            int limitShaChong = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShaChong] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.ShaChongQueue.Count > limitShaChong) break;
            var ShaChongMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level4/ShaChong").GetComponent<ShaChong>(),
                QueueController.S.transform);
            ShaChongMonster.gameObject.SetActive(false);
            QueueController.S.ShaChongQueue.Enqueue(ShaChongMonster);
            QueueController.S.MonsterColliderDic.Add(ShaChongMonster.collider2D, ShaChongMonster);
            break;

        case MonsterTypeByName.ShaNiao:
            int limitShaNiao = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShaNiao] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.ShaNiaoQueue.Count > limitShaNiao) break;
            var ShaNiaoMonster = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/Level4/ShaNiao").GetComponent<ShaNiao>(),
                QueueController.S.transform);
            ShaNiaoMonster.gameObject.SetActive(false);
            QueueController.S.ShaNiaoQueue.Enqueue(ShaNiaoMonster);
            QueueController.S.MonsterColliderDic.Add(ShaNiaoMonster.collider2D, ShaNiaoMonster);
            break;

        case MonsterTypeByName.banrenma1:
            int limitbanrenma1 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.banrenma1] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.banrenma1Queue.Count > limitbanrenma1) break;
            var banrenma1 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/banrenma1").GetComponent<banrenma1>(),
                QueueController.S.transform);
            banrenma1.gameObject.SetActive(false);
            QueueController.S.banrenma1Queue.Enqueue(banrenma1);
            MonsterBase banrenma1monsterBase = banrenma1.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(banrenma1monsterBase.collider2D, banrenma1monsterBase);
            break;

        case MonsterTypeByName.banrenma2:
            int limitbanrenma2 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.banrenma2] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.banrenma2Queue.Count > limitbanrenma2) break;
            var banrenma2 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/banrenma2").GetComponent<banrenma2>(),
                QueueController.S.transform);
            banrenma2.gameObject.SetActive(false);
            QueueController.S.banrenma2Queue.Enqueue(banrenma2);
            MonsterBase banrenma2monsterBase = banrenma2.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(banrenma2monsterBase.collider2D, banrenma2monsterBase);
            break;

        case MonsterTypeByName.banrenma3:
            int limitbanrenma3 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.banrenma3] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.banrenma3Queue.Count > limitbanrenma3) break;
            var banrenma3 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/banrenma3").GetComponent<banrenma3>(),
                QueueController.S.transform);
            banrenma3.gameObject.SetActive(false);
            QueueController.S.banrenma3Queue.Enqueue(banrenma3);
            MonsterBase banrenma3monsterBase = banrenma3.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(banrenma3monsterBase.collider2D, banrenma3monsterBase);
            break;

        case MonsterTypeByName.she:
            int limitshe = MonsterConfig.MonsterTypeDic[MonsterTypeByName.she] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.sheQueue.Count > limitshe) break;
            var she = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/she").GetComponent<she>(),
                QueueController.S.transform);
            she.gameObject.SetActive(false);
            QueueController.S.sheQueue.Enqueue(she);
            MonsterBase shemonsterBase = she.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(shemonsterBase.collider2D, shemonsterBase);
            break;

        case MonsterTypeByName.zibaolaoshu:
            int limitzibaolaoshu = MonsterConfig.MonsterTypeDic[MonsterTypeByName.zibaolaoshu] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.zibaolaoshuQueue.Count > limitzibaolaoshu) break;
            var zibaolaoshu = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/zibaolaoshu").GetComponent<zibaolaoshu>(),
                QueueController.S.transform);
            zibaolaoshu.gameObject.SetActive(false);
            QueueController.S.zibaolaoshuQueue.Enqueue(zibaolaoshu);
            MonsterBase zibaolaoshumonsterBase = zibaolaoshu.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(zibaolaoshumonsterBase.collider2D, zibaolaoshumonsterBase);
            break;

        case MonsterTypeByName.zhumodaocaoren:
            int limitzhumodaocaoren = MonsterConfig.MonsterTypeDic[MonsterTypeByName.zhumodaocaoren] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.zhumodaocaorenQueue.Count > limitzhumodaocaoren) break;
            var zhumodaocaoren = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/zhumodaocaoren").GetComponent<zhumodaocaoren>(),
                QueueController.S.transform);
            zhumodaocaoren.gameObject.SetActive(false);
            QueueController.S.zhumodaocaorenQueue.Enqueue(zhumodaocaoren);
            MonsterBase zhumodaocaorenmonsterBase = zhumodaocaoren.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(zhumodaocaorenmonsterBase.collider2D, zhumodaocaorenmonsterBase);
            break;

        case MonsterTypeByName.yezhu:
            int limityezhu = MonsterConfig.MonsterTypeDic[MonsterTypeByName.yezhu] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.yezhuQueue.Count > limityezhu) break;
            var yezhu = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/yezhu").GetComponent<yezhu>(),
                QueueController.S.transform);
            yezhu.gameObject.SetActive(false);
            QueueController.S.yezhuQueue.Enqueue(yezhu);
            MonsterBase yezhumonsterBase = yezhu.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(yezhumonsterBase.collider2D, yezhumonsterBase);
            break;

        case MonsterTypeByName.yanshu:
            int limityanshu = MonsterConfig.MonsterTypeDic[MonsterTypeByName.yanshu] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.yanshuQueue.Count > limityanshu) break;
            var yanshu = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/yanshu").GetComponent<yanshu>(),
                QueueController.S.transform);
            yanshu.gameObject.SetActive(false);
            QueueController.S.yanshuQueue.Enqueue(yanshu);
            MonsterBase yanshumonsterBase = yanshu.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(yanshumonsterBase.collider2D, yanshumonsterBase);
            break;

        case MonsterTypeByName.xuelaoshu:
            int limitxuelaoshu = MonsterConfig.MonsterTypeDic[MonsterTypeByName.xuelaoshu] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.xuelaoshuQueue.Count > limitxuelaoshu) break;
            var xuelaoshu = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/xuelaoshu").GetComponent<xuelaoshu>(),
                QueueController.S.transform);
            xuelaoshu.gameObject.SetActive(false);
            QueueController.S.xuelaoshuQueue.Enqueue(xuelaoshu);
            MonsterBase xuelaoshumonsterBase = xuelaoshu.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(xuelaoshumonsterBase.collider2D, xuelaoshumonsterBase);
            break;

        case MonsterTypeByName.xiongbuou:
            int limitxiongbuou = MonsterConfig.MonsterTypeDic[MonsterTypeByName.xiongbuou] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.xiongbuouQueue.Count > limitxiongbuou) break;
            var xiongbuou = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/xiongbuou").GetComponent<xiongbuou>(),
                QueueController.S.transform);
            xiongbuou.gameObject.SetActive(false);
            QueueController.S.xiongbuouQueue.Enqueue(xiongbuou);
            MonsterBase xiongbuoumonsterBase = xiongbuou.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(xiongbuoumonsterBase.collider2D, xiongbuoumonsterBase);
            break;

        case MonsterTypeByName.xiezi2:
            int limitxiezi2 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.xiezi2] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.xiezi2Queue.Count > limitxiezi2) break;
            var xiezi2 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/xiezi2").GetComponent<xiezi2>(),
                QueueController.S.transform);
            xiezi2.gameObject.SetActive(false);
            QueueController.S.xiezi2Queue.Enqueue(xiezi2);
            MonsterBase xiezi2monsterBase = xiezi2.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(xiezi2monsterBase.collider2D, xiezi2monsterBase);
            break;

        case MonsterTypeByName.xiezi1:
            int limitxiezi1 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.xiezi1] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.xiezi1Queue.Count > limitxiezi1) break;
            var xiezi1 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/xiezi1").GetComponent<xiezi1>(),
                QueueController.S.transform);
            xiezi1.gameObject.SetActive(false);
            QueueController.S.xiezi1Queue.Enqueue(xiezi1);
            MonsterBase xiezi1monsterBase = xiezi1.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(xiezi1monsterBase.collider2D, xiezi1monsterBase);
            break;

        case MonsterTypeByName.xiaoshuguai:
            int limitxiaoshuguai = MonsterConfig.MonsterTypeDic[MonsterTypeByName.xiaoshuguai] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.xiaoshuguaiQueue.Count > limitxiaoshuguai) break;
            var xiaoshuguai = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/xiaoshuguai").GetComponent<xiaoshuguai>(),
                QueueController.S.transform);
            xiaoshuguai.gameObject.SetActive(false);
            QueueController.S.xiaoshuguaiQueue.Enqueue(xiaoshuguai);
            MonsterBase xiaoshuguaimonsterBase = xiaoshuguai.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(xiaoshuguaimonsterBase.collider2D, xiaoshuguaimonsterBase);
            break;

        case MonsterTypeByName.xiaozhizhu:
            int limitxiaozhizhu = MonsterConfig.MonsterTypeDic[MonsterTypeByName.xiaozhizhu] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.xiaozhizhuQueue.Count > limitxiaozhizhu) break;
            var xiaozhizhu = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/xiaozhizhu").GetComponent<xiaozhizhu>(),
                QueueController.S.transform);
            xiaozhizhu.gameObject.SetActive(false);
            QueueController.S.xiaozhizhuQueue.Enqueue(xiaozhizhu);
            MonsterBase xiaozhizhumonsterBase = xiaozhizhu.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(xiaozhizhumonsterBase.collider2D, xiaozhizhumonsterBase);
            break;

        case MonsterTypeByName.xiaohuoling:
            int limitxiaohuoling = MonsterConfig.MonsterTypeDic[MonsterTypeByName.xiaohuoling] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.xiaohuolingQueue.Count > limitxiaohuoling) break;
            var xiaohuoling = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/xiaohuoling").GetComponent<xiaohuoling>(),
                QueueController.S.transform);
            xiaohuoling.gameObject.SetActive(false);
            QueueController.S.xiaohuolingQueue.Enqueue(xiaohuoling);
            MonsterBase xiaohuolingmonsterBase = xiaohuoling.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(xiaohuolingmonsterBase.collider2D, xiaohuolingmonsterBase);
            break;

        case MonsterTypeByName.woniu:
            int limitwoniu = MonsterConfig.MonsterTypeDic[MonsterTypeByName.woniu] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.woniuQueue.Count > limitwoniu) break;
            var woniu = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/woniu").GetComponent<woniu>(),
                QueueController.S.transform);
            woniu.gameObject.SetActive(false);
            QueueController.S.woniuQueue.Enqueue(woniu);
            MonsterBase woniumonsterBase = woniu.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(woniumonsterBase.collider2D, woniumonsterBase);
            break;

        case MonsterTypeByName.shanyang:
            int limitshanyang = MonsterConfig.MonsterTypeDic[MonsterTypeByName.shanyang] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.shanyangQueue.Count > limitshanyang) break;
            var shanyang = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shanyang").GetComponent<shanyang>(),
                QueueController.S.transform);
            shanyang.gameObject.SetActive(false);
            QueueController.S.shanyangQueue.Enqueue(shanyang);
            MonsterBase shanyangmonsterBase = shanyang.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(shanyangmonsterBase.collider2D, shanyangmonsterBase);
            break;

        case MonsterTypeByName.rongyanboss:
            int limitrongyanboss = MonsterConfig.MonsterTypeDic[MonsterTypeByName.rongyanboss] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.rongyanbossQueue.Count > limitrongyanboss) break;
            var rongyanboss = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/rongyanboss").GetComponent<rongyanboss>(),
                QueueController.S.transform);
            rongyanboss.gameObject.SetActive(false);
            QueueController.S.rongyanbossQueue.Enqueue(rongyanboss);
            MonsterBase rongyanbossmonsterBase = rongyanboss.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(rongyanbossmonsterBase.collider2D, rongyanbossmonsterBase);
            break;

        case MonsterTypeByName.queen:
            int limitqueen = MonsterConfig.MonsterTypeDic[MonsterTypeByName.queen] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.queenQueue.Count > limitqueen) break;
            var queen = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/queen").GetComponent<queen>(),
                QueueController.S.transform);
            queen.gameObject.SetActive(false);
            QueueController.S.queenQueue.Enqueue(queen);
            MonsterBase queenmonsterBase = queen.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(queenmonsterBase.collider2D, queenmonsterBase);
            break;

        case MonsterTypeByName.paopao:
            int limitpaopao = MonsterConfig.MonsterTypeDic[MonsterTypeByName.paopao] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.paopaoQueue.Count > limitpaopao) break;
            var paopao = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/paopao").GetComponent<paopao>(),
                QueueController.S.transform);
            paopao.gameObject.SetActive(false);
            QueueController.S.paopaoQueue.Enqueue(paopao);
            MonsterBase paopaomonsterBase = paopao.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(paopaomonsterBase.collider2D, paopaomonsterBase);
            break;

        case MonsterTypeByName.onyx:
            int limitonyx = MonsterConfig.MonsterTypeDic[MonsterTypeByName.onyx] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.onyxQueue.Count > limitonyx) break;
            var onyx = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/onyx").GetComponent<onyx>(),
                QueueController.S.transform);
            onyx.gameObject.SetActive(false);
            QueueController.S.onyxQueue.Enqueue(onyx);
            MonsterBase onyxmonsterBase = onyx.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(onyxmonsterBase.collider2D, onyxmonsterBase);
            break;

        case MonsterTypeByName.niguai3:
            int limitniguai3 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.niguai3] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.niguai3Queue.Count > limitniguai3) break;
            var niguai3 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/niguai3").GetComponent<niguai3>(),
                QueueController.S.transform);
            niguai3.gameObject.SetActive(false);
            QueueController.S.niguai3Queue.Enqueue(niguai3);
            MonsterBase niguai3monsterBase = niguai3.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(niguai3monsterBase.collider2D, niguai3monsterBase);
            break;

        case MonsterTypeByName.niguai2:
            int limitniguai2 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.niguai2] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.niguai2Queue.Count > limitniguai2) break;
            var niguai2 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/niguai2").GetComponent<niguai2>(),
                QueueController.S.transform);
            niguai2.gameObject.SetActive(false);
            QueueController.S.niguai2Queue.Enqueue(niguai2);
            MonsterBase niguai2monsterBase = niguai2.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(niguai2monsterBase.collider2D, niguai2monsterBase);
            break;

        case MonsterTypeByName.niguai1:
            int limitniguai1 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.niguai1] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.niguai1Queue.Count > limitniguai1) break;
            var niguai1 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/niguai1").GetComponent<niguai1>(),
                QueueController.S.transform);
            niguai1.gameObject.SetActive(false);
            QueueController.S.niguai1Queue.Enqueue(niguai1);
            MonsterBase niguai1monsterBase = niguai1.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(niguai1monsterBase.collider2D, niguai1monsterBase);
            break;

        case MonsterTypeByName.lang:
            int limitlang = MonsterConfig.MonsterTypeDic[MonsterTypeByName.lang] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.langQueue.Count > limitlang) break;
            var lang = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/lang").GetComponent<lang>(),
                QueueController.S.transform);
            lang.gameObject.SetActive(false);
            QueueController.S.langQueue.Enqueue(lang);
            MonsterBase langmonsterBase = lang.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(langmonsterBase.collider2D, langmonsterBase);
            break;

        case MonsterTypeByName.egg:
            int limitegg = MonsterConfig.MonsterTypeDic[MonsterTypeByName.egg] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.eggQueue.Count > limitegg) break;
            var egg = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/egg").GetComponent<egg>(),
                QueueController.S.transform);
            egg.gameObject.SetActive(false);
            QueueController.S.eggQueue.Enqueue(egg);
            MonsterBase eggmonsterBase = egg.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(eggmonsterBase.collider2D, eggmonsterBase);
            break;

        case MonsterTypeByName.mogu:
            int limitmogu = MonsterConfig.MonsterTypeDic[MonsterTypeByName.mogu] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.moguQueue.Count > limitmogu) break;
            var mogu = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/mogu").GetComponent<mogu>(),
                QueueController.S.transform);
            mogu.gameObject.SetActive(false);
            QueueController.S.moguQueue.Enqueue(mogu);
            MonsterBase mogumonsterBase = mogu.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(mogumonsterBase.collider2D, mogumonsterBase);
            break;

        case MonsterTypeByName.cat:
            int limitcat = MonsterConfig.MonsterTypeDic[MonsterTypeByName.cat] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.catQueue.Count > limitcat) break;
            var cat = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/cat").GetComponent<cat>(),
                QueueController.S.transform);
            cat.gameObject.SetActive(false);
            QueueController.S.catQueue.Enqueue(cat);
            MonsterBase catmonsterBase = cat.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(catmonsterBase.collider2D, catmonsterBase);
            break;

        case MonsterTypeByName.DaZongXiong:
            int limitDaZongXiong = MonsterConfig.MonsterTypeDic[MonsterTypeByName.DaZongXiong] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.dazongxiongQueue.Count > limitDaZongXiong) break;
            var dazongxiong = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/dazongxiong").GetComponent<dazongxiong>(),
                QueueController.S.transform);
            dazongxiong.gameObject.SetActive(false);
            QueueController.S.dazongxiongQueue.Enqueue(dazongxiong);
            MonsterBase dazongxiongmonsterBase = dazongxiong.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(dazongxiongmonsterBase.collider2D, dazongxiongmonsterBase);
            break;

        case MonsterTypeByName.LuJiaoDouShi:
            int limitLuJiaoDouShi = MonsterConfig.MonsterTypeDic[MonsterTypeByName.LuJiaoDouShi] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.lujiaodoushiQueue.Count > limitLuJiaoDouShi) break;
            var lujiaodoushi = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/lujiaodoushi").GetComponent<lujiaodoushi>(),
                QueueController.S.transform);
            lujiaodoushi.gameObject.SetActive(false);
            QueueController.S.lujiaodoushiQueue.Enqueue(lujiaodoushi);
            MonsterBase lujiaodoushimonsterBase = lujiaodoushi.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(lujiaodoushimonsterBase.collider2D, lujiaodoushimonsterBase);
            break;

        case MonsterTypeByName.KuangShiMuZhu:
            int limitKuangShiMuZhu = MonsterConfig.MonsterTypeDic[MonsterTypeByName.KuangShiMuZhu] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.kuangshimuzhuQueue.Count > limitKuangShiMuZhu) break;
            var kuangshimuzhu = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/kuangshimuzhu").GetComponent<kuangshimuzhu>(),
                QueueController.S.transform);
            kuangshimuzhu.gameObject.SetActive(false);
            QueueController.S.kuangshimuzhuQueue.Enqueue(kuangshimuzhu);
            MonsterBase kuangshimuzhumonsterBase = kuangshimuzhu.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(kuangshimuzhumonsterBase.collider2D, kuangshimuzhumonsterBase);
            break;

        case MonsterTypeByName.FengHeGuai:
            int limitFengHeGuai = MonsterConfig.MonsterTypeDic[MonsterTypeByName.FengHeGuai] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.fengheguaiQueue.Count > limitFengHeGuai) break;
            var fengheguai = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/fengheguai").GetComponent<fengheguai>(),
                QueueController.S.transform);
            fengheguai.gameObject.SetActive(false);
            QueueController.S.fengheguaiQueue.Enqueue(fengheguai);
            MonsterBase fengheguaimonsterBase = fengheguai.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(fengheguaimonsterBase.collider2D, fengheguaimonsterBase);
            break;

        case MonsterTypeByName.ShuangTouRen:
            int limitShuangTouRen = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShuangTouRen] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.shuangtourenQueue.Count > limitShuangTouRen) break;
            var shuangtouren = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/shuangtouren").GetComponent<shuangtouren>(),
                QueueController.S.transform);
            shuangtouren.gameObject.SetActive(false);
            QueueController.S.shuangtourenQueue.Enqueue(shuangtouren);
            MonsterBase shuangtourenmonsterBase = shuangtouren.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(shuangtourenmonsterBase.collider2D, shuangtourenmonsterBase);
            break;

        case MonsterTypeByName.DaoCaoRen:
            int limitDaoCaoRen = MonsterConfig.MonsterTypeDic[MonsterTypeByName.DaoCaoRen] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.daocaorenQueue.Count > limitDaoCaoRen) break;
            var daocaoren = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/daocaoren").GetComponent<daocaoren>(),
                QueueController.S.transform);
            daocaoren.gameObject.SetActive(false);
            QueueController.S.daocaorenQueue.Enqueue(daocaoren);
            MonsterBase daocaorenmonsterBase = daocaoren.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(daocaorenmonsterBase.collider2D, daocaorenmonsterBase);
            break;

        case MonsterTypeByName.CiZhu:
            int limitCiZhu = MonsterConfig.MonsterTypeDic[MonsterTypeByName.CiZhu] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.cizhuQueue.Count > limitCiZhu) break;
            var cizhu = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/cizhu").GetComponent<cizhu>(),
                QueueController.S.transform);
            cizhu.gameObject.SetActive(false);
            QueueController.S.cizhuQueue.Enqueue(cizhu);
            MonsterBase cizhumonsterBase = cizhu.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(cizhumonsterBase.collider2D, cizhumonsterBase);
            break;

        case MonsterTypeByName.ChaiLangRen1:
            int limitChaiLangRen1 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ChaiLangRen1] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.chailangren1Queue.Count > limitChaiLangRen1) break;
            var chailangren1 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/chailangren1").GetComponent<chailangren1>(),
                QueueController.S.transform);
            chailangren1.gameObject.SetActive(false);
            QueueController.S.chailangren1Queue.Enqueue(chailangren1);
            MonsterBase chailangren1monsterBase = chailangren1.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(chailangren1monsterBase.collider2D, chailangren1monsterBase);
            break;

        case MonsterTypeByName.ChaiLangRen2:
            int limitChaiLangRen2 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ChaiLangRen2] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.chailangren2Queue.Count > limitChaiLangRen2) break;
            var chailangren2 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/chailangren2").GetComponent<chailangren2>(),
                QueueController.S.transform);
            chailangren2.gameObject.SetActive(false);
            QueueController.S.chailangren2Queue.Enqueue(chailangren2);
            MonsterBase chailangren2monsterBase = chailangren2.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(chailangren2monsterBase.collider2D, chailangren2monsterBase);
            break;

        case MonsterTypeByName.ChaiLangRen3:
            int limitChaiLangRen3 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ChaiLangRen3] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.chailangren3Queue.Count > limitChaiLangRen3) break;
            var chailangren3 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/chailangren3").GetComponent<chailangren3>(),
                QueueController.S.transform);
            chailangren3.gameObject.SetActive(false);
            QueueController.S.chailangren3Queue.Enqueue(chailangren3);
            MonsterBase chailangren3monsterBase = chailangren3.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(chailangren3monsterBase.collider2D, chailangren3monsterBase);
            break;

        case MonsterTypeByName.ChaiLangRen4:
            int limitChaiLangRen4 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ChaiLangRen4] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.chailangren4Queue.Count > limitChaiLangRen4) break;
            var chailangren4 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/chailangren4").GetComponent<chailangren4>(),
                QueueController.S.transform);
            chailangren4.gameObject.SetActive(false);
            QueueController.S.chailangren4Queue.Enqueue(chailangren4);
            MonsterBase chailangren4monsterBase = chailangren4.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(chailangren4monsterBase.collider2D, chailangren4monsterBase);
            break;

        case MonsterTypeByName.YeShouZhanShi:
            int limitYeShouZhanShi = MonsterConfig.MonsterTypeDic[MonsterTypeByName.YeShouZhanShi] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.YeShouZhanShiQueue.Count > limitYeShouZhanShi) break;
            var YeShouZhanShi = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/YeShouZhanShi").GetComponent<YeShouZhanShi>(),
                QueueController.S.transform);
            YeShouZhanShi.gameObject.SetActive(false);
            QueueController.S.YeShouZhanShiQueue.Enqueue(YeShouZhanShi);
            MonsterBase YeShouZhanShimonsterBase = YeShouZhanShi.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(YeShouZhanShimonsterBase.collider2D, YeShouZhanShimonsterBase);
            break;

        case MonsterTypeByName.ZhiZhuNvWang:
            int limitZhiZhuNvWang = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ZhiZhuNvWang] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.ZhiZhuNvWangQueue.Count > limitZhiZhuNvWang) break;
            var ZhiZhuNvWang = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/ZhiZhuNvWang").GetComponent<ZhiZhuNvWang>(),
                QueueController.S.transform);
            ZhiZhuNvWang.gameObject.SetActive(false);
            QueueController.S.ZhiZhuNvWangQueue.Enqueue(ZhiZhuNvWang);
            MonsterBase ZhiZhuNvWangmonsterBase = ZhiZhuNvWang.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(ZhiZhuNvWangmonsterBase.collider2D, ZhiZhuNvWangmonsterBase);
            break;

        case MonsterTypeByName.DiJing2:
            int limitDiJing2 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.DiJing2] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.dijing2Queue.Count > limitDiJing2) break;
            var dijing2 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijing2").GetComponent<dijing2>(),
                QueueController.S.transform);
            dijing2.gameObject.SetActive(false);
            QueueController.S.dijing2Queue.Enqueue(dijing2);
            MonsterBase dijing2monsterBase = dijing2.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(dijing2monsterBase.collider2D, dijing2monsterBase);
            break;

        case MonsterTypeByName.DiJing3:
            int limitDiJing3 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.DiJing3] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.dijing3Queue.Count > limitDiJing3) break;
            var dijing3 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijing3").GetComponent<dijing3>(),
                QueueController.S.transform);
            dijing3.gameObject.SetActive(false);
            QueueController.S.dijing3Queue.Enqueue(dijing3);
            MonsterBase dijing3monsterBase = dijing3.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(dijing3monsterBase.collider2D, dijing3monsterBase);
            break;

        case MonsterTypeByName.DiJingShouWei1:
            int limitDiJingShouWei1 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.DiJingShouWei1] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.dijingshouwei1Queue.Count > limitDiJingShouWei1) break;
            var dijingshouwei1 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijingshouwei1").GetComponent<dijingshouwei1>(),
                QueueController.S.transform);
            dijingshouwei1.gameObject.SetActive(false);
            QueueController.S.dijingshouwei1Queue.Enqueue(dijingshouwei1);
            MonsterBase dijingshouwei1monsterBase = dijingshouwei1.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(dijingshouwei1monsterBase.collider2D, dijingshouwei1monsterBase);
            break;

        case MonsterTypeByName.DiJingShouWei2:
            int limitDiJingShouWei2 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.DiJingShouWei2] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.dijingshouwei2Queue.Count > limitDiJingShouWei2) break;
            var dijingshouwei2 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijingshouwei2").GetComponent<dijingshouwei2>(),
                QueueController.S.transform);
            dijingshouwei2.gameObject.SetActive(false);
            QueueController.S.dijingshouwei2Queue.Enqueue(dijingshouwei2);
            MonsterBase dijingshouwei2monsterBase = dijingshouwei2.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(dijingshouwei2monsterBase.collider2D, dijingshouwei2monsterBase);
            break;

        case MonsterTypeByName.DiJingShouWei3:
            int limitDiJingShouWei3 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.DiJingShouWei3] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.dijingshouwei3Queue.Count > limitDiJingShouWei3) break;
            var dijingshouwei3 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijingshouwei3").GetComponent<dijingshouwei3>(),
                QueueController.S.transform);
            dijingshouwei3.gameObject.SetActive(false);
            QueueController.S.dijingshouwei3Queue.Enqueue(dijingshouwei3);
            MonsterBase dijingshouwei3monsterBase = dijingshouwei3.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(dijingshouwei3monsterBase.collider2D, dijingshouwei3monsterBase);
            break;

        case MonsterTypeByName.HeiXiong:
            int limitHeiXiong = MonsterConfig.MonsterTypeDic[MonsterTypeByName.HeiXiong] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.heixiongQueue.Count > limitHeiXiong) break;
            var heixiong = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/heixiong").GetComponent<heixiong>(),
                QueueController.S.transform);
            heixiong.gameObject.SetActive(false);
            QueueController.S.heixiongQueue.Enqueue(heixiong);
            MonsterBase heixiongmonsterBase = heixiong.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(heixiongmonsterBase.collider2D, heixiongmonsterBase);
            break;

        case MonsterTypeByName.JianChiZhu:
            int limitJianChiZhu = MonsterConfig.MonsterTypeDic[MonsterTypeByName.JianChiZhu] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.jianchizhuQueue.Count > limitJianChiZhu) break;
            var jianchizhu = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/jianchizhu").GetComponent<jianchizhu>(),
                QueueController.S.transform);
            jianchizhu.gameObject.SetActive(false);
            QueueController.S.jianchizhuQueue.Enqueue(jianchizhu);
            MonsterBase jianchizhumonsterBase = jianchizhu.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(jianchizhumonsterBase.collider2D, jianchizhumonsterBase);
            break;

        case MonsterTypeByName.KuLou1:
            int limitKuLou1 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.KuLou1] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.kulou1Queue.Count > limitKuLou1) break;
            var kulou1 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou1").GetComponent<kulou1>(),
                QueueController.S.transform);
            kulou1.gameObject.SetActive(false);
            QueueController.S.kulou1Queue.Enqueue(kulou1);
            MonsterBase kulou1monsterBase = kulou1.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(kulou1monsterBase.collider2D, kulou1monsterBase);
            break;

        case MonsterTypeByName.KuLou2:
            int limitKuLou2 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.KuLou2] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.kulou2Queue.Count > limitKuLou2) break;
            var kulou2 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou2").GetComponent<kulou2>(),
                QueueController.S.transform);
            kulou2.gameObject.SetActive(false);
            QueueController.S.kulou2Queue.Enqueue(kulou2);
            MonsterBase kulou2monsterBase = kulou2.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(kulou2monsterBase.collider2D, kulou2monsterBase);
            break;

        case MonsterTypeByName.KuLou3:
            int limitKuLou3 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.KuLou3] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.kulou3Queue.Count > limitKuLou3) break;
            var kulou3 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou3").GetComponent<kulou3>(),
                QueueController.S.transform);
            kulou3.gameObject.SetActive(false);
            QueueController.S.kulou3Queue.Enqueue(kulou3);
            MonsterBase kulou3monsterBase = kulou3.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(kulou3monsterBase.collider2D, kulou3monsterBase);
            break;

        case MonsterTypeByName.KuLou4:
            int limitKuLou4 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.KuLou4] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.kulou4Queue.Count > limitKuLou4) break;
            var kulou4 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou4").GetComponent<kulou4>(),
                QueueController.S.transform);
            kulou4.gameObject.SetActive(false);
            QueueController.S.kulou4Queue.Enqueue(kulou4);
            MonsterBase kulou4monsterBase = kulou4.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(kulou4monsterBase.collider2D, kulou4monsterBase);
            break;

        case MonsterTypeByName.KuLou5:
            int limitKuLou5 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.KuLou5] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.kulou5Queue.Count > limitKuLou5) break;
            var kulou5 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou5").GetComponent<kulou5>(),
                QueueController.S.transform);
            kulou5.gameObject.SetActive(false);
            QueueController.S.kulou5Queue.Enqueue(kulou5);
            MonsterBase kulou5monsterBase = kulou5.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(kulou5monsterBase.collider2D, kulou5monsterBase);
            break;

        case MonsterTypeByName.KuLou6:
            int limitKuLou6 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.KuLou6] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.kulou6Queue.Count > limitKuLou6) break;
            var kulou6 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou6").GetComponent<kulou6>(),
                QueueController.S.transform);
            kulou6.gameObject.SetActive(false);
            QueueController.S.kulou6Queue.Enqueue(kulou6);
            MonsterBase kulou6monsterBase = kulou6.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(kulou6monsterBase.collider2D, kulou6monsterBase);
            break;

        case MonsterTypeByName.LuJiaoCiKe1:
            int limitLuJiaoCiKe1 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.LuJiaoCiKe1] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.lujiaocikeQueue.Count > limitLuJiaoCiKe1) break;
            var lujiaocike = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/lujiaocike").GetComponent<lujiaocike>(),
                QueueController.S.transform);
            lujiaocike.gameObject.SetActive(false);
            QueueController.S.lujiaocikeQueue.Enqueue(lujiaocike);
            MonsterBase lujiaocikemonsterBase = lujiaocike.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(lujiaocikemonsterBase.collider2D, lujiaocikemonsterBase);
            break;

        case MonsterTypeByName.LuJiaoCiKe2:
            int limitLuJiaoCiKe2 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.LuJiaoCiKe2] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.lujiaocike2Queue.Count > limitLuJiaoCiKe2) break;
            var lujiaocike2 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/lujiaocike2").GetComponent<lujiaocike2>(),
                QueueController.S.transform);
            lujiaocike2.gameObject.SetActive(false);
            QueueController.S.lujiaocike2Queue.Enqueue(lujiaocike2);
            MonsterBase lujiaocike2monsterBase = lujiaocike2.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(lujiaocike2monsterBase.collider2D, lujiaocike2monsterBase);
            break;

        case MonsterTypeByName.NiuTouRen1:
            int limitNiuTouRen1 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.NiuTouRen1] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.niutouren1Queue.Count > limitNiuTouRen1) break;
            var niutouren1 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/niutouren1").GetComponent<niutouren1>(),
                QueueController.S.transform);
            niutouren1.gameObject.SetActive(false);
            QueueController.S.niutouren1Queue.Enqueue(niutouren1);
            MonsterBase niutouren1monsterBase = niutouren1.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(niutouren1monsterBase.collider2D, niutouren1monsterBase);
            break;

        case MonsterTypeByName.NiuTouRen2:
            int limitNiuTouRen2 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.NiuTouRen2] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.niutouren2Queue.Count > limitNiuTouRen2) break;
            var niutouren2 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/niutouren2").GetComponent<niutouren2>(),
                QueueController.S.transform);
            niutouren2.gameObject.SetActive(false);
            QueueController.S.niutouren2Queue.Enqueue(niutouren2);
            MonsterBase niutouren2monsterBase = niutouren2.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(niutouren2monsterBase.collider2D, niutouren2monsterBase);
            break;

        case MonsterTypeByName.NiuTouRen3:
            int limitNiuTouRen3 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.NiuTouRen3] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.niutouren3Queue.Count > limitNiuTouRen3) break;
            var niutouren3 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/niutouren3").GetComponent<niutouren3>(),
                QueueController.S.transform);
            niutouren3.gameObject.SetActive(false);
            QueueController.S.niutouren3Queue.Enqueue(niutouren3);
            MonsterBase niutouren3monsterBase = niutouren3.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(niutouren3monsterBase.collider2D, niutouren3monsterBase);
            break;

        case MonsterTypeByName.ShanZei3:
            int limitShanZei3 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShanZei3] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.shanzei3Queue.Count > limitShanZei3) break;
            var shanzei3 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shanzei3").GetComponent<shanzei3>(),
                QueueController.S.transform);
            shanzei3.gameObject.SetActive(false);
            QueueController.S.shanzei3Queue.Enqueue(shanzei3);
            MonsterBase shanzei3monsterBase = shanzei3.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(shanzei3monsterBase.collider2D, shanzei3monsterBase);
            break;

        case MonsterTypeByName.ShiJiaChong:
            int limitShiJiaChong = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShiJiaChong] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.shijiachongQueue.Count > limitShiJiaChong) break;
            var shijiachong = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shijiachong").GetComponent<shijiachong>(),
                QueueController.S.transform);
            shijiachong.gameObject.SetActive(false);
            QueueController.S.shijiachongQueue.Enqueue(shijiachong);
            MonsterBase shijiachongmonsterBase = shijiachong.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(shijiachongmonsterBase.collider2D, shijiachongmonsterBase);
            break;

        case MonsterTypeByName.ShiShiGui:
            int limitShiShiGui = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShiShiGui] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.shishiguiQueue.Count > limitShiShiGui) break;
            var shishigui = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shishigui").GetComponent<shishigui>(),
                QueueController.S.transform);
            shishigui.gameObject.SetActive(false);
            QueueController.S.shishiguiQueue.Enqueue(shishigui);
            MonsterBase shishiguimonsterBase = shishigui.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(shishiguimonsterBase.collider2D, shishiguimonsterBase);
            break;

        case MonsterTypeByName.ShiXiangGui:
            int limitShiXiangGui = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShiXiangGui] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.shixiangguiQueue.Count > limitShiXiangGui) break;
            var shixianggui = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shixianggui").GetComponent<shixianggui>(),
                QueueController.S.transform);
            shixianggui.gameObject.SetActive(false);
            QueueController.S.shixiangguiQueue.Enqueue(shixianggui);
            MonsterBase shixiangguimonsterBase = shixianggui.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(shixiangguimonsterBase.collider2D, shixiangguimonsterBase);
            break;

        case MonsterTypeByName.ShouRen1:
            int limitShouRen1 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShouRen1] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.shouren1Queue.Count > limitShouRen1) break;
            var shouren1 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/shouren1").GetComponent<shouren1>(),
                QueueController.S.transform);
            shouren1.gameObject.SetActive(false);
            QueueController.S.shouren1Queue.Enqueue(shouren1);
            MonsterBase shouren1monsterBase = shouren1.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(shouren1monsterBase.collider2D, shouren1monsterBase);
            break;

        case MonsterTypeByName.ShouRen2:
            int limitShouRen2 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShouRen2] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.shouren2Queue.Count > limitShouRen2) break;
            var shouren2 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/shouren2").GetComponent<shouren2>(),
                QueueController.S.transform);
            shouren2.gameObject.SetActive(false);
            QueueController.S.shouren2Queue.Enqueue(shouren2);
            MonsterBase shouren2monsterBase = shouren2.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(shouren2monsterBase.collider2D, shouren2monsterBase);
            break;

        case MonsterTypeByName.ShouRen3:
            int limitShouRen3 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShouRen3] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.shouren3Queue.Count > limitShouRen3) break;
            var shouren3 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/shouren3").GetComponent<shouren3>(),
                QueueController.S.transform);
            shouren3.gameObject.SetActive(false);
            QueueController.S.shouren3Queue.Enqueue(shouren3);
            MonsterBase shouren3monsterBase = shouren3.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(shouren3monsterBase.collider2D, shouren3monsterBase);
            break;

        case MonsterTypeByName.ShuangTouLong1:
            int limitShuangTouLong1 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShuangTouLong1] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.shuangtoulongQueue.Count > limitShuangTouLong1) break;
            var shuangtoulong = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shuangtoulong").GetComponent<shuangtoulong>(),
                QueueController.S.transform);
            shuangtoulong.gameObject.SetActive(false);
            QueueController.S.shuangtoulongQueue.Enqueue(shuangtoulong);
            MonsterBase shuangtoulongmonsterBase = shuangtoulong.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(shuangtoulongmonsterBase.collider2D, shuangtoulongmonsterBase);
            break;

        case MonsterTypeByName.ShuangTouLong2:
            int limitShuangTouLong2 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShuangTouLong2] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.shuangtoulong2Queue.Count > limitShuangTouLong2) break;
            var shuangtoulong2 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shuangtoulong2").GetComponent<shuangtoulong2>(),
                QueueController.S.transform);
            shuangtoulong2.gameObject.SetActive(false);
            QueueController.S.shuangtoulong2Queue.Enqueue(shuangtoulong2);
            MonsterBase shuangtoulong2monsterBase = shuangtoulong2.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(shuangtoulong2monsterBase.collider2D, shuangtoulong2monsterBase);
            break;

        case MonsterTypeByName.ShuangTouLong3:
            int limitShuangTouLong3 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.ShuangTouLong3] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.shuangtoulong3Queue.Count > limitShuangTouLong3) break;
            var shuangtoulong3 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shuangtoulong3").GetComponent<shuangtoulong3>(),
                QueueController.S.transform);
            shuangtoulong3.gameObject.SetActive(false);
            QueueController.S.shuangtoulong3Queue.Enqueue(shuangtoulong3);
            MonsterBase shuangtoulong3monsterBase = shuangtoulong3.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(shuangtoulong3monsterBase.collider2D, shuangtoulong3monsterBase);
            break;

        case MonsterTypeByName.TuJiu:
            int limitTuJiu = MonsterConfig.MonsterTypeDic[MonsterTypeByName.TuJiu] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.tujiuQueue.Count > limitTuJiu) break;
            var tujiu = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/tujiu").GetComponent<tujiu>(),
                QueueController.S.transform);
            tujiu.gameObject.SetActive(false);
            QueueController.S.tujiuQueue.Enqueue(tujiu);
            MonsterBase tujiumonsterBase = tujiu.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(tujiumonsterBase.collider2D, tujiumonsterBase);
            break;

        case MonsterTypeByName.WuYa:
            int limitWuYa = MonsterConfig.MonsterTypeDic[MonsterTypeByName.WuYa] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.wuyaQueue.Count > limitWuYa) break;
            var wuya = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/wuya").GetComponent<wuya>(),
                QueueController.S.transform);
            wuya.gameObject.SetActive(false);
            QueueController.S.wuyaQueue.Enqueue(wuya);
            MonsterBase wuyamonsterBase = wuya.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(wuyamonsterBase.collider2D, wuyamonsterBase);
            break;

        case MonsterTypeByName.YouHunLingZhu:
            int limitYouHunLingZhu = MonsterConfig.MonsterTypeDic[MonsterTypeByName.YouHunLingZhu] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.youhunlingzhuQueue.Count > limitYouHunLingZhu) break;
            var youhunlingzhu = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/youhunlingzhu").GetComponent<youhunlingzhu>(),
                QueueController.S.transform);
            youhunlingzhu.gameObject.SetActive(false);
            QueueController.S.youhunlingzhuQueue.Enqueue(youhunlingzhu);
            MonsterBase youhunlingzhumonsterBase = youhunlingzhu.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(youhunlingzhumonsterBase.collider2D, youhunlingzhumonsterBase);
            break;

        case MonsterTypeByName.YouLang:
            int limitYouLang = MonsterConfig.MonsterTypeDic[MonsterTypeByName.YouLang] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.youlangQueue.Count > limitYouLang) break;
            var youlang = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/youlang").GetComponent<youlang>(),
                QueueController.S.transform);
            youlang.gameObject.SetActive(false);
            QueueController.S.youlangQueue.Enqueue(youlang);
            MonsterBase youlangmonsterBase = youlang.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(youlangmonsterBase.collider2D, youlangmonsterBase);
            break;

        case MonsterTypeByName.YouLing1:
            int limitYouLing1 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.YouLing1] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.youlingQueue.Count > limitYouLing1) break;
            var youling = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/youling").GetComponent<youling>(),
                QueueController.S.transform);
            youling.gameObject.SetActive(false);
            QueueController.S.youlingQueue.Enqueue(youling);
            MonsterBase youlingmonsterBase = youling.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(youlingmonsterBase.collider2D, youlingmonsterBase);
            break;

        case MonsterTypeByName.YouLing2:
            int limitYouLing2 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.YouLing2] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.youling2Queue.Count > limitYouLing2) break;
            var youling2 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/youling2").GetComponent<youling2>(),
                QueueController.S.transform);
            youling2.gameObject.SetActive(false);
            QueueController.S.youling2Queue.Enqueue(youling2);
            MonsterBase youling2monsterBase = youling2.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(youling2monsterBase.collider2D, youling2monsterBase);
            break;

        case MonsterTypeByName.YuRen1:
            int limitYuRen1 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.YuRen1] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.yuren1Queue.Count > limitYuRen1) break;
            var yuren1 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/yuren1").GetComponent<yuren1>(),
                QueueController.S.transform);
            yuren1.gameObject.SetActive(false);
            QueueController.S.yuren1Queue.Enqueue(yuren1);
            MonsterBase yuren1monsterBase = yuren1.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(yuren1monsterBase.collider2D, yuren1monsterBase);
            break;

        case MonsterTypeByName.YuRen2:
            int limitYuRen2 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.YuRen2] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.yuren2Queue.Count > limitYuRen2) break;
            var yuren2 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/yuren2").GetComponent<yuren2>(),
                QueueController.S.transform);
            yuren2.gameObject.SetActive(false);
            QueueController.S.yuren2Queue.Enqueue(yuren2);
            MonsterBase yuren2monsterBase = yuren2.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(yuren2monsterBase.collider2D, yuren2monsterBase);
            break;

        case MonsterTypeByName.YuRen3:
            int limitYuRen3 = MonsterConfig.MonsterTypeDic[MonsterTypeByName.YuRen3] == MonsterType.Elite
                ? LevelInfoConfig.EliteMonsterQueueCount
                : LevelInfoConfig.NormalMonsterQueueCount;
            if (QueueController.S.yuren3Queue.Count > limitYuRen3) break;
            var yuren3 = Instantiate(
                Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/yuren3").GetComponent<yuren3>(),
                QueueController.S.transform);
            yuren3.gameObject.SetActive(false);
            QueueController.S.yuren3Queue.Enqueue(yuren3);
            MonsterBase yuren3monsterBase = yuren3.GetComponent<MonsterBase>();
            QueueController.S.MonsterColliderDic.Add(yuren3monsterBase.collider2D, yuren3monsterBase);
            break;
    }
}

    public static void InitProp(MonsterProp info)
{
    switch (info.PropItem.PropType)
    {
        case PropConfig.PropType.ChiBangFight:
            if (QueueController.S.ChiBangFightQueue.Count >20) break;
            ChiBangFight chibang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChiBang"), QueueController.S.transform).GetComponent<ChiBangFight>();
            chibang.gameObject.SetActive(false);
            QueueController.S.ChiBangFightQueue.Enqueue(chibang);
            break;

        case PropConfig.PropType.WeaponFragment:
            switch (info.PropItem.Quality)
            {
                case 1:
                    if (QueueController.S.WhiteWeaponFragmengQueue.Count >20) break;
                    GameObject whiteWeaponFragmeng = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/WhiteWeaponFragmeng"), QueueController.S.transform);
                    whiteWeaponFragmeng.gameObject.SetActive(false);
                    QueueController.S.WhiteWeaponFragmengQueue.Enqueue(whiteWeaponFragmeng);
                    break;
                case 2:
                    if (QueueController.S.GreenWeaponFragmengQueue.Count >20) break;
                    GameObject GreenWeaponFragmeng = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/GreenWeaponFragmeng"), QueueController.S.transform);
                    GreenWeaponFragmeng.gameObject.SetActive(false);
                    QueueController.S.GreenWeaponFragmengQueue.Enqueue(GreenWeaponFragmeng);
                    break;
                case 3:
                    if (QueueController.S.BlueWeaponFragmengQueue.Count >20) break;
                    GameObject BlueWeaponFragmeng = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/BlueWeaponFragmeng"), QueueController.S.transform);
                    BlueWeaponFragmeng.gameObject.SetActive(false);
                    QueueController.S.BlueWeaponFragmengQueue.Enqueue(BlueWeaponFragmeng);
                    break;
                case 4:
                    if (QueueController.S.PurpleWeaponFragmengQueue.Count >20) break;
                    GameObject PurpleWeaponFragmeng = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/PurpleWeaponFragmeng"), QueueController.S.transform);
                    PurpleWeaponFragmeng.gameObject.SetActive(false);
                    QueueController.S.PurpleWeaponFragmengQueue.Enqueue(PurpleWeaponFragmeng);
                    break;
                case 5:
                    if (QueueController.S.OrangeWeaponFragmengQueue.Count >20) break;
                    GameObject OrangeWeaponFragmeng = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/OrangeWeaponFragmeng"), QueueController.S.transform);
                    OrangeWeaponFragmeng.gameObject.SetActive(false);
                    QueueController.S.OrangeWeaponFragmengQueue.Enqueue(OrangeWeaponFragmeng);
                    break;
                case 6:
                    if (QueueController.S.RedWeaponFragmengQueue.Count >20) break;
                    GameObject RedWeaponFragmeng = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/RedWeaponFragmeng"), QueueController.S.transform);
                    RedWeaponFragmeng.gameObject.SetActive(false);
                    QueueController.S.RedWeaponFragmengQueue.Enqueue(RedWeaponFragmeng);
                    break;
            }
            break;

        case PropConfig.PropType.ChiBang:
            switch (info.PropItem.Quality)
            {
                case 1:
                    if (QueueController.S.WhiteChiBangQueue.Count >20) break;
                    GameObject whiteChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/WhiteChiBang"), QueueController.S.transform);
                    whiteChiBang.gameObject.SetActive(false);
                    QueueController.S.WhiteChiBangQueue.Enqueue(whiteChiBang);
                    break;
                case 2:
                    if (QueueController.S.GreenChiBangQueue.Count >20) break;
                    GameObject GreenChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/GreenChiBang"), QueueController.S.transform);
                    GreenChiBang.gameObject.SetActive(false);
                    QueueController.S.GreenChiBangQueue.Enqueue(GreenChiBang);
                    break;
                case 3:
                    if (QueueController.S.BlueChiBangQueue.Count >20) break;
                    GameObject BlueChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/BlueChiBang"), QueueController.S.transform);
                    BlueChiBang.gameObject.SetActive(false);
                    QueueController.S.BlueChiBangQueue.Enqueue(BlueChiBang);
                    break;
                case 4:
                    if (QueueController.S.PurpleChiBangQueue.Count >20) break;
                    GameObject PurpleChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/PurpleChiBang"), QueueController.S.transform);
                    PurpleChiBang.gameObject.SetActive(false);
                    QueueController.S.PurpleChiBangQueue.Enqueue(PurpleChiBang);
                    break;
                case 5:
                    if (QueueController.S.OrangeChiBangQueue.Count >20) break;
                    GameObject OrangeChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/OrangeChiBang"), QueueController.S.transform);
                    OrangeChiBang.gameObject.SetActive(false);
                    QueueController.S.OrangeChiBangQueue.Enqueue(OrangeChiBang);
                    break;
                case 6:
                    if (QueueController.S.RedChiBangQueue.Count >20) break;
                    GameObject RedChiBang = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/RedChiBang"), QueueController.S.transform);
                    RedChiBang.gameObject.SetActive(false);
                    QueueController.S.RedChiBangQueue.Enqueue(RedChiBang);
                    break;
            }
            break;

        case PropConfig.PropType.ChongWuDan:
            if (QueueController.S.ChongWuDanQueue.Count >20) break;
            ChongWuDanFight ChongWuDan = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChongWuDan"), QueueController.S.transform).GetComponent<ChongWuDanFight>();
            ChongWuDan.gameObject.SetActive(false);
            switch (info.PropItem.Quality)
            {
                case 3:
                    ChongWuDan.quality = 3;
                    break;
                case 5:
                    ChongWuDan.quality = 5;
                    break;
            }
            QueueController.S.ChongWuDanQueue.Enqueue(ChongWuDan);
            break;

        case PropConfig.PropType.XiSuiYe:
            if (QueueController.S.XiSuiYeQueue.Count >20) break;
            XiSuiYeFight XiSuiYe = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/XiSuiYe"), QueueController.S.transform).GetComponent<XiSuiYeFight>();
            XiSuiYe.gameObject.SetActive(false);
            switch (info.PropItem.Quality)
            {
                case 3:
                    XiSuiYe.quality = 3;
                    break;
                case 5:
                    XiSuiYe.quality = 5;
                    break;
            }
            QueueController.S.XiSuiYeQueue.Enqueue(XiSuiYe);
            break;

        case PropConfig.PropType.XueMaiDan:
            if (QueueController.S.XueMaiDanQueue.Count >20) break;
            XueMaiDanFight XueMaiDan = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/XueMaiDan"), QueueController.S.transform).GetComponent<XueMaiDanFight>();
            XueMaiDan.gameObject.SetActive(false);
            switch (info.PropItem.Quality)
            {
                case 3:
                    XueMaiDan.quality = 3;
                    break;
                case 5:
                    XueMaiDan.quality = 5;
                    break;
            }
            QueueController.S.XueMaiDanQueue.Enqueue(XueMaiDan);
            break;

        case PropConfig.PropType.SkillShu:
            if (QueueController.S.ChongWuSkillShuQueue.Count >20) break;
            ChongWuSkillShuFight ChongWuSkillShu = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChongWuSkillShu"), QueueController.S.transform)
                .GetComponent<ChongWuSkillShuFight>();
            ChongWuSkillShu.gameObject.SetActive(false);
            switch (info.PropItem.Quality)
            {
                case 1:
                    ChongWuSkillShu.quality = 1;
                    break;
                case 2:
                    ChongWuSkillShu.quality = 2;
                    break;
                case 3:
                    ChongWuSkillShu.quality = 3;
                    break;
                case 4:
                    ChongWuSkillShu.quality = 4;
                    break;
                case 5:
                    ChongWuSkillShu.quality = 5;
                    break;
                case 6:
                    ChongWuSkillShu.quality = 6;
                    break;
            }
            QueueController.S.ChongWuSkillShuQueue.Enqueue(ChongWuSkillShu);
            break;

        case PropConfig.PropType.ChongWuShiWu:
            if (QueueController.S.ChongWuShiWuQueue.Count >20) break;
            ChongWuShiWuFight ChongWuShiWu = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChongWuShiWu"), QueueController.S.transform)
                .GetComponent<ChongWuShiWuFight>();
            ChongWuShiWu.gameObject.SetActive(false);
            switch (info.PropItem.Quality)
            {
                case 1:
                    ChongWuShiWu.quality = 1;
                    break;
                case 2:
                    ChongWuShiWu.quality = 2;
                    break;
                case 3:
                    ChongWuShiWu.quality = 3;
                    break;
                case 4:
                    ChongWuShiWu.quality = 4;
                    break;
                case 5:
                    ChongWuShiWu.quality = 5;
                    break;
                case 6:
                    ChongWuShiWu.quality = 6;
                    break;
            }
            QueueController.S.ChongWuShiWuQueue.Enqueue(ChongWuShiWu);
            break;

        case PropConfig.PropType.DaKongShi:
            if (QueueController.S.DaKongShiQueue.Count >20) break;
            DaKongShiFight DaKongShi = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/DaKongShi"), QueueController.S.transform).GetComponent<DaKongShiFight>();
            DaKongShi.gameObject.SetActive(false);
            QueueController.S.DaKongShiQueue.Enqueue(DaKongShi);
            break;

        case PropConfig.PropType.ShenHuaCaiLiao:
            if (QueueController.S.ShenHuaCaiLiaoQueue.Count >20) break;
            ShenHuaCaiLiaoFight ShenHuaCaiLiao = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ShenHuaCaiLiao"), QueueController.S.transform)
                .GetComponent<ShenHuaCaiLiaoFight>();
            ShenHuaCaiLiao.gameObject.SetActive(false);
            switch (info.PropItem.Quality)
            {
                case 1:
                    ShenHuaCaiLiao.quality = 1;
                    break;
                case 2:
                    ShenHuaCaiLiao.quality = 2;
                    break;
                case 3:
                    ShenHuaCaiLiao.quality = 3;
                    break;
                case 4:
                    ShenHuaCaiLiao.quality = 4;
                    break;
            }
            QueueController.S.ShenHuaCaiLiaoQueue.Enqueue(ShenHuaCaiLiao);
            break;
    }
}
    

    public static void InitEquip(MonsterEquip info)
{
    switch (info.EquipLevel)
    {
        case PlayerEquipConfig.EquipLevel.Primary:
            switch (info.EquipType)
            {
                case PlayerEquipConfig.EquipType.Cloak:
                    if (QueueController.S.PrimaryCloakQueue.Count >20) break;
                    GameObject primaryCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryCloakFight"), QueueController.S.transform);
                    primaryCloakFight.gameObject.SetActive(false);
                    QueueController.S.PrimaryCloakQueue.Enqueue(primaryCloakFight);
                    break;
                case PlayerEquipConfig.EquipType.Necklace:
                    if (QueueController.S.PrimaryNecklaceQueue.Count >20) break;
                    GameObject primaryNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryNecklaceFight"), QueueController.S.transform);
                    primaryNecklaceFight.gameObject.SetActive(false);
                    QueueController.S.PrimaryNecklaceQueue.Enqueue(primaryNecklaceFight);
                    break;
                case PlayerEquipConfig.EquipType.Cloth:
                    if (QueueController.S.PrimaryClothQueue.Count >20) break;
                    GameObject primaryClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryClothFight"), QueueController.S.transform);
                    primaryClothFight.gameObject.SetActive(false);
                    QueueController.S.PrimaryClothQueue.Enqueue(primaryClothFight);
                    break;
                case PlayerEquipConfig.EquipType.Helmet:
                    if (QueueController.S.PrimaryHelmetQueue.Count >20) break;
                    GameObject primaryHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryHelmetFight"), QueueController.S.transform);
                    primaryHelmetFight.gameObject.SetActive(false);
                    QueueController.S.PrimaryHelmetQueue.Enqueue(primaryHelmetFight);
                    break;
                case PlayerEquipConfig.EquipType.Shoe:
                    if (QueueController.S.PrimaryShoeQueue.Count >20) break;
                    GameObject primaryShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryShoeFight"), QueueController.S.transform);
                    primaryShoeFight.gameObject.SetActive(false);
                    QueueController.S.PrimaryShoeQueue.Enqueue(primaryShoeFight);
                    break;
                case PlayerEquipConfig.EquipType.Ring:
                    if (QueueController.S.PrimaryRingQueue.Count >20) break;
                    GameObject primaryRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryRingFight"), QueueController.S.transform);
                    primaryRingFight.gameObject.SetActive(false);
                    QueueController.S.PrimaryRingQueue.Enqueue(primaryRingFight);
                    break;
            }
            break;

        case PlayerEquipConfig.EquipLevel.Green:
            switch (info.EquipType)
            {
                case PlayerEquipConfig.EquipType.Cloak:
                    if (QueueController.S.GreenCloakQueue.Count >20) break;
                    GameObject GreenCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenCloakFight"), QueueController.S.transform);
                    GreenCloakFight.gameObject.SetActive(false);
                    QueueController.S.GreenCloakQueue.Enqueue(GreenCloakFight);
                    break;
                case PlayerEquipConfig.EquipType.Necklace:
                    if (QueueController.S.GreenNecklaceQueue.Count >20) break;
                    GameObject GreenNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenNecklaceFight"), QueueController.S.transform);
                    GreenNecklaceFight.gameObject.SetActive(false);
                    QueueController.S.GreenNecklaceQueue.Enqueue(GreenNecklaceFight);
                    break;
                case PlayerEquipConfig.EquipType.Cloth:
                    if (QueueController.S.GreenClothQueue.Count >20) break;
                    GameObject GreenClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenClothFight"), QueueController.S.transform);
                    GreenClothFight.gameObject.SetActive(false);
                    QueueController.S.GreenClothQueue.Enqueue(GreenClothFight);
                    break;
                case PlayerEquipConfig.EquipType.Helmet:
                    if (QueueController.S.GreenHelmetQueue.Count >20) break;
                    GameObject GreenHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenHelmetFight"), QueueController.S.transform);
                    GreenHelmetFight.gameObject.SetActive(false);
                    QueueController.S.GreenHelmetQueue.Enqueue(GreenHelmetFight);
                    break;
                case PlayerEquipConfig.EquipType.Shoe:
                    if (QueueController.S.GreenShoeQueue.Count >20) break;
                    GameObject GreenShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenShoeFight"), QueueController.S.transform);
                    GreenShoeFight.gameObject.SetActive(false);
                    QueueController.S.GreenShoeQueue.Enqueue(GreenShoeFight);
                    break;
                case PlayerEquipConfig.EquipType.Ring:
                    if (QueueController.S.GreenRingQueue.Count >20) break;
                    GameObject GreenRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenRingFight"), QueueController.S.transform);
                    GreenRingFight.gameObject.SetActive(false);
                    QueueController.S.GreenRingQueue.Enqueue(GreenRingFight);
                    break;
            }
            break;

        case PlayerEquipConfig.EquipLevel.Blue:
            switch (info.EquipType)
            {
                case PlayerEquipConfig.EquipType.Cloak:
                    if (QueueController.S.BlueCloakQueue.Count >20) break;
                    GameObject BlueCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueCloakFight"), QueueController.S.transform);
                    BlueCloakFight.gameObject.SetActive(false);
                    QueueController.S.BlueCloakQueue.Enqueue(BlueCloakFight);
                    break;
                case PlayerEquipConfig.EquipType.Necklace:
                    if (QueueController.S.BlueNecklaceQueue.Count >20) break;
                    GameObject BlueNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueNecklaceFight"), QueueController.S.transform);
                    BlueNecklaceFight.gameObject.SetActive(false);
                    QueueController.S.BlueNecklaceQueue.Enqueue(BlueNecklaceFight);
                    break;
                case PlayerEquipConfig.EquipType.Cloth:
                    if (QueueController.S.BlueClothQueue.Count >20) break;
                    GameObject BlueClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueClothFight"), QueueController.S.transform);
                    BlueClothFight.gameObject.SetActive(false);
                    QueueController.S.BlueClothQueue.Enqueue(BlueClothFight);
                    break;
                case PlayerEquipConfig.EquipType.Helmet:
                    if (QueueController.S.BlueHelmetQueue.Count >20) break;
                    GameObject BlueHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueHelmetFight"), QueueController.S.transform);
                    BlueHelmetFight.gameObject.SetActive(false);
                    QueueController.S.BlueHelmetQueue.Enqueue(BlueHelmetFight);
                    break;
                case PlayerEquipConfig.EquipType.Shoe:
                    if (QueueController.S.BlueShoeQueue.Count >20) break;
                    GameObject BlueShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueShoeFight"), QueueController.S.transform);
                    BlueShoeFight.gameObject.SetActive(false);
                    QueueController.S.BlueShoeQueue.Enqueue(BlueShoeFight);
                    break;
                case PlayerEquipConfig.EquipType.Ring:
                    if (QueueController.S.BlueRingQueue.Count >20) break;
                    GameObject BlueRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueRingFight"), QueueController.S.transform);
                    BlueRingFight.gameObject.SetActive(false);
                    QueueController.S.BlueRingQueue.Enqueue(BlueRingFight);
                    break;
            }
            break;

        case PlayerEquipConfig.EquipLevel.Purple:
            switch (info.EquipType)
            {
                case PlayerEquipConfig.EquipType.Cloak:
                    if (QueueController.S.PurpleCloakQueue.Count >20) break;
                    GameObject PurpleCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleCloakFight"), QueueController.S.transform);
                    PurpleCloakFight.gameObject.SetActive(false);
                    QueueController.S.PurpleCloakQueue.Enqueue(PurpleCloakFight);
                    break;
                case PlayerEquipConfig.EquipType.Necklace:
                    if (QueueController.S.PurpleNecklaceQueue.Count >20) break;
                    GameObject PurpleNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleNecklaceFight"), QueueController.S.transform);
                    PurpleNecklaceFight.gameObject.SetActive(false);
                    QueueController.S.PurpleNecklaceQueue.Enqueue(PurpleNecklaceFight);
                    break;
                case PlayerEquipConfig.EquipType.Cloth:
                    if (QueueController.S.PurpleClothQueue.Count >20) break;
                    GameObject PurpleClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleClothFight"), QueueController.S.transform);
                    PurpleClothFight.gameObject.SetActive(false);
                    QueueController.S.PurpleClothQueue.Enqueue(PurpleClothFight);
                    break;
                case PlayerEquipConfig.EquipType.Helmet:
                    if (QueueController.S.PurpleHelmetQueue.Count >20) break;
                    GameObject PurpleHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleHelmetFight"), QueueController.S.transform);
                    PurpleHelmetFight.gameObject.SetActive(false);
                    QueueController.S.PurpleHelmetQueue.Enqueue(PurpleHelmetFight);
                    break;
                case PlayerEquipConfig.EquipType.Shoe:
                    if (QueueController.S.PurpleShoeQueue.Count >20) break;
                    GameObject PurpleShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleShoeFight"), QueueController.S.transform);
                    PurpleShoeFight.gameObject.SetActive(false);
                    QueueController.S.PurpleShoeQueue.Enqueue(PurpleShoeFight);
                    break;
                case PlayerEquipConfig.EquipType.Ring:
                    if (QueueController.S.PurpleRingQueue.Count >20) break;
                    GameObject PurpleRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleRingFight"), QueueController.S.transform);
                    PurpleRingFight.gameObject.SetActive(false);
                    QueueController.S.PurpleRingQueue.Enqueue(PurpleRingFight);
                    break;
            }
            break;

        case PlayerEquipConfig.EquipLevel.Purple1:
            switch (info.EquipType)
            {
                case PlayerEquipConfig.EquipType.Cloak:
                    if (QueueController.S.Purple1CloakQueue.Count >20) break;
                    GameObject Purple1CloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/Purple1CloakFight"), QueueController.S.transform);
                    Purple1CloakFight.gameObject.SetActive(false);
                    QueueController.S.Purple1CloakQueue.Enqueue(Purple1CloakFight);
                    break;
                case PlayerEquipConfig.EquipType.Necklace:
                    if (QueueController.S.Purple1NecklaceQueue.Count >20) break;
                    GameObject Purple1NecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/Purple1NecklaceFight"), QueueController.S.transform);
                    Purple1NecklaceFight.gameObject.SetActive(false);
                    QueueController.S.Purple1NecklaceQueue.Enqueue(Purple1NecklaceFight);
                    break;
                case PlayerEquipConfig.EquipType.Cloth:
                    if (QueueController.S.Purple1ClothQueue.Count >20) break;
                    GameObject Purple1ClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/Purple1ClothFight"), QueueController.S.transform);
                    Purple1ClothFight.gameObject.SetActive(false);
                    QueueController.S.Purple1ClothQueue.Enqueue(Purple1ClothFight);
                    break;
                case PlayerEquipConfig.EquipType.Helmet:
                    if (QueueController.S.Purple1HelmetQueue.Count >20) break;
                    GameObject Purple1HelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/Purple1HelmetFight"), QueueController.S.transform);
                    Purple1HelmetFight.gameObject.SetActive(false);
                    QueueController.S.Purple1HelmetQueue.Enqueue(Purple1HelmetFight);
                    break;
                case PlayerEquipConfig.EquipType.Shoe:
                    if (QueueController.S.Purple1ShoeQueue.Count >20) break;
                    GameObject Purple1ShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/Purple1ShoeFight"), QueueController.S.transform);
                    Purple1ShoeFight.gameObject.SetActive(false);
                    QueueController.S.Purple1ShoeQueue.Enqueue(Purple1ShoeFight);
                    break;
                case PlayerEquipConfig.EquipType.Ring:
                    if (QueueController.S.Purple1RingQueue.Count >20) break;
                    GameObject Purple1RingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/Purple1RingFight"), QueueController.S.transform);
                    Purple1RingFight.gameObject.SetActive(false);
                    QueueController.S.Purple1RingQueue.Enqueue(Purple1RingFight);
                    break;
            }
            break;

        case PlayerEquipConfig.EquipLevel.TreeMan:
            switch (info.EquipType)
            {
                case PlayerEquipConfig.EquipType.Cloak:
                    if (QueueController.S.TreeManCloakQueue.Count >20) break;
                    GameObject TreeManCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManCloakFight"), QueueController.S.transform);
                    TreeManCloakFight.gameObject.SetActive(false);
                    QueueController.S.TreeManCloakQueue.Enqueue(TreeManCloakFight);
                    break;
                case PlayerEquipConfig.EquipType.Necklace:
                    if (QueueController.S.TreeManNecklaceQueue.Count >20) break;
                    GameObject TreeManNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManNecklaceFight"), QueueController.S.transform);
                    TreeManNecklaceFight.gameObject.SetActive(false);
                    QueueController.S.TreeManNecklaceQueue.Enqueue(TreeManNecklaceFight);
                    break;
                case PlayerEquipConfig.EquipType.Cloth:
                    if (QueueController.S.TreeManClothQueue.Count >20) break;
                    GameObject TreeManClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManClothFight"), QueueController.S.transform);
                    TreeManClothFight.gameObject.SetActive(false);
                    QueueController.S.TreeManClothQueue.Enqueue(TreeManClothFight);
                    break;
                case PlayerEquipConfig.EquipType.Helmet:
                    if (QueueController.S.TreeManHelmetQueue.Count >20) break;
                    GameObject TreeManHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManHelmetFight"), QueueController.S.transform);
                    TreeManHelmetFight.gameObject.SetActive(false);
                    QueueController.S.TreeManHelmetQueue.Enqueue(TreeManHelmetFight);
                    break;
                case PlayerEquipConfig.EquipType.Shoe:
                    if (QueueController.S.TreeManShoeQueue.Count >20) break;
                    GameObject TreeManShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManShoeFight"), QueueController.S.transform);
                    TreeManShoeFight.gameObject.SetActive(false);
                    QueueController.S.TreeManShoeQueue.Enqueue(TreeManShoeFight);
                    break;
                case PlayerEquipConfig.EquipType.Ring:
                    if (QueueController.S.TreeManRingQueue.Count >20) break;
                    GameObject TreeManRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManRingFight"), QueueController.S.transform);
                    TreeManRingFight.gameObject.SetActive(false);
                    QueueController.S.TreeManRingQueue.Enqueue(TreeManRingFight);
                    break;
            }
            break;

        case PlayerEquipConfig.EquipLevel.HuoShan:
            switch (info.EquipType)
            {
                case PlayerEquipConfig.EquipType.Cloak:
                    if (QueueController.S.HuoShanCloakQueue.Count >20) break;
                    GameObject HuoShanBossCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanCloakFight"), QueueController.S.transform);
                    HuoShanBossCloakFight.gameObject.SetActive(false);
                    QueueController.S.HuoShanCloakQueue.Enqueue(HuoShanBossCloakFight);
                    break;
                case PlayerEquipConfig.EquipType.Necklace:
                    if (QueueController.S.HuoShanNecklaceQueue.Count >20) break;
                    GameObject HuoShanBossNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanNecklaceFight"), QueueController.S.transform);
                    HuoShanBossNecklaceFight.gameObject.SetActive(false);
                    QueueController.S.HuoShanNecklaceQueue.Enqueue(HuoShanBossNecklaceFight);
                    break;
                case PlayerEquipConfig.EquipType.Cloth:
                    if (QueueController.S.HuoShanClothQueue.Count >20) break;
                    GameObject HuoShanBossClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanClothFight"), QueueController.S.transform);
                    HuoShanBossClothFight.gameObject.SetActive(false);
                    QueueController.S.HuoShanClothQueue.Enqueue(HuoShanBossClothFight);
                    break;
                case PlayerEquipConfig.EquipType.Helmet:
                    if (QueueController.S.HuoShanHelmetQueue.Count >20) break;
                    GameObject HuoShanBossHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanHelmetFight"), QueueController.S.transform);
                    HuoShanBossHelmetFight.gameObject.SetActive(false);
                    QueueController.S.HuoShanHelmetQueue.Enqueue(HuoShanBossHelmetFight);
                    break;
                case PlayerEquipConfig.EquipType.Shoe:
                    if (QueueController.S.HuoShanShoeQueue.Count >20) break;
                    GameObject HuoShanBossShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanShoeFight"), QueueController.S.transform);
                    HuoShanBossShoeFight.gameObject.SetActive(false);
                    QueueController.S.HuoShanShoeQueue.Enqueue(HuoShanBossShoeFight);
                    break;
                case PlayerEquipConfig.EquipType.Ring:
                    if (QueueController.S.HuoShanRingQueue.Count >20) break;
                    GameObject HuoShanBossRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanRingFight"), QueueController.S.transform);
                    HuoShanBossRingFight.gameObject.SetActive(false);
                    QueueController.S.HuoShanRingQueue.Enqueue(HuoShanBossRingFight);
                    break;
            }
            break;

        case PlayerEquipConfig.EquipLevel.ZhaoZe:
            switch (info.EquipType)
            {
                case PlayerEquipConfig.EquipType.Cloak:
                    if (QueueController.S.ZhaoZeCloakQueue.Count >20) break;
                    GameObject ZhaoZeCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeCloakFight"), QueueController.S.transform);
                    ZhaoZeCloakFight.gameObject.SetActive(false);
                    QueueController.S.ZhaoZeCloakQueue.Enqueue(ZhaoZeCloakFight);
                    break;
                case PlayerEquipConfig.EquipType.Necklace:
                    if (QueueController.S.ZhaoZeNecklaceQueue.Count >20) break;
                    GameObject ZhaoZeNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeNecklaceFight"), QueueController.S.transform);
                    ZhaoZeNecklaceFight.gameObject.SetActive(false);
                    QueueController.S.ZhaoZeNecklaceQueue.Enqueue(ZhaoZeNecklaceFight);
                    break;
                case PlayerEquipConfig.EquipType.Cloth:
                    if (QueueController.S.ZhaoZeClothQueue.Count >20) break;
                    GameObject ZhaoZeClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeClothFight"), QueueController.S.transform);
                    ZhaoZeClothFight.gameObject.SetActive(false);
                    QueueController.S.ZhaoZeClothQueue.Enqueue(ZhaoZeClothFight);
                    break;
                case PlayerEquipConfig.EquipType.Helmet:
                    if (QueueController.S.ZhaoZeHelmetQueue.Count >20) break;
                    GameObject ZhaoZeHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeHelmetFight"), QueueController.S.transform);
                    ZhaoZeHelmetFight.gameObject.SetActive(false);
                    QueueController.S.ZhaoZeHelmetQueue.Enqueue(ZhaoZeHelmetFight);
                    break;
                case PlayerEquipConfig.EquipType.Shoe:
                    if (QueueController.S.ZhaoZeShoeQueue.Count >20) break;
                    GameObject ZhaoZeShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeShoeFight"), QueueController.S.transform);
                    ZhaoZeShoeFight.gameObject.SetActive(false);
                    QueueController.S.ZhaoZeShoeQueue.Enqueue(ZhaoZeShoeFight);
                    break;
                case PlayerEquipConfig.EquipType.Ring:
                    if (QueueController.S.ZhaoZeRingQueue.Count >20) break;
                    GameObject ZhaoZeRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeRingFight"), QueueController.S.transform);
                    ZhaoZeRingFight.gameObject.SetActive(false);
                    QueueController.S.ZhaoZeRingQueue.Enqueue(ZhaoZeRingFight);
                    break;
            }
            break;

        case PlayerEquipConfig.EquipLevel.XieZi:
            switch (info.EquipType)
            {
                case PlayerEquipConfig.EquipType.Cloak:
                    if (QueueController.S.XieZiCloakQueue.Count >20) break;
                    GameObject XieZiCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XieZi/XieZiCloakFight"), QueueController.S.transform);
                    XieZiCloakFight.gameObject.SetActive(false);
                    QueueController.S.XieZiCloakQueue.Enqueue(XieZiCloakFight);
                    break;
                case PlayerEquipConfig.EquipType.Necklace:
                    if (QueueController.S.XieZiNecklaceQueue.Count >20) break;
                    GameObject XieZiNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XieZi/XieZiNecklaceFight"), QueueController.S.transform);
                    XieZiNecklaceFight.gameObject.SetActive(false);
                    QueueController.S.XieZiNecklaceQueue.Enqueue(XieZiNecklaceFight);
                    break;
                case PlayerEquipConfig.EquipType.Cloth:
                    if (QueueController.S.XieZiClothQueue.Count >20) break;
                    GameObject XieZiClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XieZi/XieZiClothFight"), QueueController.S.transform);
                    XieZiClothFight.gameObject.SetActive(false);
                    QueueController.S.XieZiClothQueue.Enqueue(XieZiClothFight);
                    break;
                case PlayerEquipConfig.EquipType.Helmet:
                    if (QueueController.S.XieZiHelmetQueue.Count >20) break;
                    GameObject XieZiHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XieZi/XieZiHelmetFight"), QueueController.S.transform);
                    XieZiHelmetFight.gameObject.SetActive(false);
                    QueueController.S.XieZiHelmetQueue.Enqueue(XieZiHelmetFight);
                    break;
                case PlayerEquipConfig.EquipType.Shoe:
                    if (QueueController.S.XieZiShoeQueue.Count >20) break;
                    GameObject XieZiShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XieZi/XieZiShoeFight"), QueueController.S.transform);
                    XieZiShoeFight.gameObject.SetActive(false);
                    QueueController.S.XieZiShoeQueue.Enqueue(XieZiShoeFight);
                    break;
                case PlayerEquipConfig.EquipType.Ring:
                    if (QueueController.S.XieZiRingQueue.Count >20) break;
                    GameObject XieZiRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XieZi/XieZiRingFight"), QueueController.S.transform);
                    XieZiRingFight.gameObject.SetActive(false);
                    QueueController.S.XieZiRingQueue.Enqueue(XieZiRingFight);
                    break;
            }
            break;

        case PlayerEquipConfig.EquipLevel.XueRen:
            switch (info.EquipType)
            {
                case PlayerEquipConfig.EquipType.Cloak:
                    if (QueueController.S.XueRenCloakQueue.Count >20) break;
                    GameObject XueRenCloakFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XueRen/XueRenCloakFight"), QueueController.S.transform);
                    XueRenCloakFight.gameObject.SetActive(false);
                    QueueController.S.XueRenCloakQueue.Enqueue(XueRenCloakFight);
                    break;
                case PlayerEquipConfig.EquipType.Necklace:
                    if (QueueController.S.XueRenNecklaceQueue.Count >20) break;
                    GameObject XueRenNecklaceFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XueRen/XueRenNecklaceFight"), QueueController.S.transform);
                    XueRenNecklaceFight.gameObject.SetActive(false);
                    QueueController.S.XueRenNecklaceQueue.Enqueue(XueRenNecklaceFight);
                    break;
                case PlayerEquipConfig.EquipType.Cloth:
                    if (QueueController.S.XueRenClothQueue.Count >20) break;
                    GameObject XueRenClothFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XueRen/XueRenClothFight"), QueueController.S.transform);
                    XueRenClothFight.gameObject.SetActive(false);
                    QueueController.S.XueRenClothQueue.Enqueue(XueRenClothFight);
                    break;
                case PlayerEquipConfig.EquipType.Helmet:
                    if (QueueController.S.XueRenHelmetQueue.Count >20) break;
                    GameObject XueRenHelmetFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XueRen/XueRenHelmetFight"), QueueController.S.transform);
                    XueRenHelmetFight.gameObject.SetActive(false);
                    QueueController.S.XueRenHelmetQueue.Enqueue(XueRenHelmetFight);
                    break;
                case PlayerEquipConfig.EquipType.Shoe:
                    if (QueueController.S.XueRenShoeQueue.Count >20) break;
                    GameObject XueRenShoeFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XueRen/XueRenShoeFight"), QueueController.S.transform);
                    XueRenShoeFight.gameObject.SetActive(false);
                    QueueController.S.XueRenShoeQueue.Enqueue(XueRenShoeFight);
                    break;
                case PlayerEquipConfig.EquipType.Ring:
                    if (QueueController.S.XueRenRingQueue.Count >20) break;
                    GameObject XueRenRingFight = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XueRen/XueRenRingFight"), QueueController.S.transform);
                    XueRenRingFight.gameObject.SetActive(false);
                    QueueController.S.XueRenRingQueue.Enqueue(XueRenRingFight);
                    break;
            }
            break;
    }
}
    private void Awake()
    {
        FightBGController.S.isShowAgain = false;
        QueueController.S.transform.Find("FightBG(Clone)").gameObject.SetActive(true);
        QueueController.S.transform.Find("FightBG(Clone)/ChuanSongZhen").gameObject.SetActive(false);

        QueueController.S.transform.Find("FightBG(Clone)/Level1").gameObject.SetActive(false);
        QueueController.S.transform.Find("FightBG(Clone)/Level2").gameObject.SetActive(false);
        QueueController.S.transform.Find("FightBG(Clone)/Level3").gameObject.SetActive(false);
        QueueController.S.transform.Find("FightBG(Clone)/Level4").gameObject.SetActive(false);
        QueueController.S.transform.Find("FightBG(Clone)/Level5").gameObject.SetActive(false);
        QueueController.S.transform.Find("FightBG(Clone)/MiJing1").gameObject.SetActive(false);
        QueueController.S.transform.Find("FightBG(Clone)/MiJing2").gameObject.SetActive(false);
        QueueController.S.transform.Find("FightBG(Clone)/MiJing3").gameObject.SetActive(false);
        QueueController.S.transform.Find("FightBG(Clone)/MiJing4").gameObject.SetActive(false);
        QueueController.S.transform.Find("FightBG(Clone)/MiJing5").gameObject.SetActive(false);

        
        
        if (LevelInfoConfig.CurrentGameLevel > 100 && LevelInfoConfig.CurrentGameLevel < 200)
        {
            QueueController.S.transform.Find("FightBG(Clone)/MiJing3").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel > 200 && LevelInfoConfig.CurrentGameLevel < 300)
        {
            QueueController.S.transform.Find("FightBG(Clone)/MiJing4").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel > 300 && LevelInfoConfig.CurrentGameLevel < 400)
        {
            QueueController.S.transform.Find("FightBG(Clone)/MiJing5").gameObject.SetActive(true);
        }
        //初始化地图
        if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 ||
            LevelInfoConfig.CurrentGameLevel == 3)
        {
            QueueController.S.transform.Find("FightBG(Clone)/Level1").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 4 || LevelInfoConfig.CurrentGameLevel == 5 ||
            LevelInfoConfig.CurrentGameLevel == 6)
        {
            QueueController.S.transform.Find("FightBG(Clone)/Level2").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 7 || LevelInfoConfig.CurrentGameLevel == 8 ||
            LevelInfoConfig.CurrentGameLevel == 9)
        {
            QueueController.S.transform.Find("FightBG(Clone)/Level3").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 10 || LevelInfoConfig.CurrentGameLevel == 11 ||
            LevelInfoConfig.CurrentGameLevel == 12)
        {
            QueueController.S.transform.Find("FightBG(Clone)/Level4").gameObject.SetActive(true);
        }
        if (LevelInfoConfig.CurrentGameLevel == 13 || LevelInfoConfig.CurrentGameLevel == 14 ||
            LevelInfoConfig.CurrentGameLevel == 15)
        {
            QueueController.S.transform.Find("FightBG(Clone)/Level5").gameObject.SetActive(true);
        }

        if (LevelInfoConfig.CurrentGameLevel > 15)
        {
            var random = new System.Random();
            var index= random.Next(1, 3);
            switch (index)
            {
                case 1:
                    QueueController.S.transform.Find("FightBG(Clone)/MiJing1").gameObject.SetActive(true);
                    break;
                case 2:
                    QueueController.S.transform.Find("FightBG(Clone)/MiJing2").gameObject.SetActive(true);
                    break;
            }
        }
    }
}
