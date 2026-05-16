using System;
using System.Collections.Generic;
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
        for (int i = 0; i < 5; i++)
        {
            //传说装备

            GameObject FinalDamageReductionFixed =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/FinalDamageReductionFixed"));
            FinalDamageReductionFixed.gameObject.SetActive(false);
            GameController.S.FinalDamageReductionFixedQueue.Enqueue(FinalDamageReductionFixed);

            GameObject FinalDamageReductionPercent =
                Instantiate(
                    Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/FinalDamageReductionPercent"));
            FinalDamageReductionPercent.gameObject.SetActive(false);
            GameController.S.FinalDamageReductionPercentQueue.Enqueue(FinalDamageReductionPercent);

            GameObject AllReplyAddPercent =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/AllReplyAddPercent"));
            AllReplyAddPercent.gameObject.SetActive(false);
            GameController.S.AllReplyAddPercentQueue.Enqueue(AllReplyAddPercent);

            GameObject AddHpForTime =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/AddHpForTime"));
            AddHpForTime.gameObject.SetActive(false);
            GameController.S.AddHpForTimeQueue.Enqueue(AddHpForTime);

            GameObject AddDefenseForTime =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/AddDefenseForTime"));
            AddDefenseForTime.gameObject.SetActive(false);
            GameController.S.AddDefenseForTimeQueue.Enqueue(AddDefenseForTime);

            GameObject ReplyDeath =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/ReplyDeath"));
            ReplyDeath.gameObject.SetActive(false);
            GameController.S.ReplyDeathQueue.Enqueue(ReplyDeath);

            GameObject DelayDamage =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/DelayDamage"));
            DelayDamage.gameObject.SetActive(false);
            GameController.S.DelayDamageQueue.Enqueue(DelayDamage);

            GameObject HpReductionReplyAdd50 =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/HpReductionReplyAdd50"));
            HpReductionReplyAdd50.gameObject.SetActive(false);
            GameController.S.HpReductionReplyAdd50Queue.Enqueue(HpReductionReplyAdd50);

            GameObject HpReductionAddDefense =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/HpReductionAddDefense"));
            HpReductionAddDefense.gameObject.SetActive(false);
            GameController.S.HpReductionAddDefenseQueue.Enqueue(HpReductionAddDefense);

            GameObject FinalDamageAddPercent =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/FinalDamageAddPercent"));
            FinalDamageAddPercent.gameObject.SetActive(false);
            GameController.S.FinalDamageAddPercentQueue.Enqueue(FinalDamageAddPercent);

            GameObject KillNormal =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/KillNormal"));
            KillNormal.gameObject.SetActive(false);
            GameController.S.KillNormalQueue.Enqueue(KillNormal);

            GameObject AddAttackForTime =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/AddAttackForTime"));
            AddAttackForTime.gameObject.SetActive(false);
            GameController.S.AddAttackForTimeQueue.Enqueue(AddAttackForTime);

            GameObject NormalAddDamage =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/NormalAddDamage"));
            NormalAddDamage.gameObject.SetActive(false);
            GameController.S.NormalAddDamageQueue.Enqueue(NormalAddDamage);

            GameObject RecudeHpAddAttack =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/RecudeHpAddAttack"));
            RecudeHpAddAttack.gameObject.SetActive(false);
            GameController.S.RecudeHpAddAttackQueue.Enqueue(RecudeHpAddAttack);

            GameObject JianSuAddAttack =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/JianSuAddAttack"));
            JianSuAddAttack.gameObject.SetActive(false);
            GameController.S.JianSuAddAttackQueue.Enqueue(JianSuAddAttack);

            GameObject FanPuGuiZhen =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/FanPuGuiZhen"));
            FanPuGuiZhen.gameObject.SetActive(false);
            GameController.S.FanPuGuiZhenQueue.Enqueue(FanPuGuiZhen);

            GameObject NoSkill =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/NoSkill"));
            NoSkill.gameObject.SetActive(false);
            GameController.S.NoSkillQueue.Enqueue(NoSkill);

            GameObject BuWangChuXin =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/BuWangChuXin"));
            BuWangChuXin.gameObject.SetActive(false);
            GameController.S.BuWangChuXinQueue.Enqueue(BuWangChuXin);

            GameObject HeiDongAddSpeed =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/HeiDongAddSpeed"));
            HeiDongAddSpeed.gameObject.SetActive(false);
            GameController.S.HeiDongAddSpeedQueue.Enqueue(HeiDongAddSpeed);

            GameObject DuAddDuQuan =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/DuAddDuQuan"));
            DuAddDuQuan.gameObject.SetActive(false);
            GameController.S.DuAddDuQuanQueue.Enqueue(DuAddDuQuan);

            GameObject LvQuanAddScale =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/LvQuanAddScale"));
            LvQuanAddScale.gameObject.SetActive(false);
            GameController.S.LvQuanAddScaleQueue.Enqueue(LvQuanAddScale);

            GameObject XuKongAdd2Dan =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/XuKongAdd2Dan"));
            XuKongAdd2Dan.gameObject.SetActive(false);
            GameController.S.XuKongAdd2DanQueue.Enqueue(XuKongAdd2Dan);

            GameObject PuTong3ChuanTou =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/PuTong3ChuanTou"));
            PuTong3ChuanTou.gameObject.SetActive(false);
            GameController.S.PuTong3ChuanTouQueue.Enqueue(PuTong3ChuanTou);

            GameObject FireBaoZha1 =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/FireBaoZha"));
            FireBaoZha1.gameObject.SetActive(false);
            GameController.S.FireBaoZhaQueue.Enqueue(FireBaoZha1);

            GameObject Skill1ReplaceNormalAttack =
                Instantiate(
                    Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/Skill1ReplaceNormalAttack"));
            Skill1ReplaceNormalAttack.gameObject.SetActive(false);
            GameController.S.Skill1ReplaceNormalAttackQueue.Enqueue(Skill1ReplaceNormalAttack);

            GameObject Skill1YiDianDouble =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/Skill1YiDianDouble"));
            Skill1YiDianDouble.gameObject.SetActive(false);
            GameController.S.Skill1YiDianDoubleQueue.Enqueue(Skill1YiDianDouble);

            GameObject Skill1AddRange =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/Skill1AddRange"));
            Skill1AddRange.gameObject.SetActive(false);
            GameController.S.Skill1AddRangeQueue.Enqueue(Skill1AddRange);

            GameObject Skill2AddDan =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/Skill2AddDan"));
            Skill2AddDan.gameObject.SetActive(false);
            GameController.S.Skill2AddDanQueue.Enqueue(Skill2AddDan);

            GameObject Skill2RotateAdd =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/Skill2RotateAdd"));
            Skill2RotateAdd.gameObject.SetActive(false);
            GameController.S.Skill2RotateAddQueue.Enqueue(Skill2RotateAdd);

            GameObject Skill2AddRange =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/Skill2AddRange"));
            Skill2AddRange.gameObject.SetActive(false);
            GameController.S.Skill2AddRangeQueue.Enqueue(Skill2AddRange);

            GameObject Skill3Bian3 =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/Skill3Bian3"));
            Skill3Bian3.gameObject.SetActive(false);
            GameController.S.Skill3Bian3Queue.Enqueue(Skill3Bian3);

            GameObject Skill3AddRange =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/Skill3AddRange"));
            Skill3AddRange.gameObject.SetActive(false);
            GameController.S.Skill3AddRangeQueue.Enqueue(Skill3AddRange);

            GameObject DashCd = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/DashCd"));
            DashCd.gameObject.SetActive(false);
            GameController.S.DashCdQueue.Enqueue(DashCd);

            GameObject DashRange =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/DashRange"));
            DashRange.gameObject.SetActive(false);
            GameController.S.DashRangeQueue.Enqueue(DashRange);

            GameObject MoveSpeedAdd =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/MoveSpeedAdd"));
            MoveSpeedAdd.gameObject.SetActive(false);
            GameController.S.MoveSpeedAddQueue.Enqueue(MoveSpeedAdd);

            GameObject ExAdd = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/ExAdd"));
            ExAdd.gameObject.SetActive(false);
            GameController.S.ExAddQueue.Enqueue(ExAdd);

            GameObject ClothFortureAdd =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloth/ClothFortureAdd"));
            ClothFortureAdd.gameObject.SetActive(false);
            GameController.S.ClothFortureAddQueue.Enqueue(ClothFortureAdd);

            GameObject ShoeFortureAdd =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Shoe/ShoeFortureAdd"));
            ShoeFortureAdd.gameObject.SetActive(false);
            GameController.S.ShoeFortureAddQueue.Enqueue(ShoeFortureAdd);

            GameObject CloakFortureAdd =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Cloak/CloakFortureAdd"));
            CloakFortureAdd.gameObject.SetActive(false);
            GameController.S.CloakFortureAddQueue.Enqueue(CloakFortureAdd);

            GameObject NecklaceFortureAdd =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Necklace/NecklaceFortureAdd"));
            NecklaceFortureAdd.gameObject.SetActive(false);
            GameController.S.NecklaceFortureAddQueue.Enqueue(NecklaceFortureAdd);

            GameObject RingFortureAdd =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Ring/RingFortureAdd"));
            RingFortureAdd.gameObject.SetActive(false);
            GameController.S.RingFortureAddQueue.Enqueue(RingFortureAdd);

            GameObject HelmetFortureAdd =
                Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Orange/Helmet/HelmetFortureAdd"));
            HelmetFortureAdd.gameObject.SetActive(false);
            GameController.S.HelmetFortureAddQueue.Enqueue(HelmetFortureAdd);

        }
    }


    public static void InitMonster(MonsterTypeByName type)
    {

        if (LevelInfoConfig.CurrentGameLevel == 3)
        {
            for (int i = 0; i < 30; i++)
            {
                var TreeManDanMu = Instantiate(
                    Resources.Load<GameObject>("Prefabs/Monster/Level1/TreeManDanMu").GetComponent<TreeManDanMu>(),
                    GameController.S.transform);
                TreeManDanMu.gameObject.SetActive(false);
                GameController.S.TreeManDanMuQueue.Enqueue(TreeManDanMu);
            }
        }

        switch (type)
        {
            case MonsterTypeByName.Snot:
                var snotMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level1/SnotMonster")
                            .GetComponent<SnotMonster>(), GameController.S.transform);
                snotMonster.gameObject.SetActive(false);
                GameController.S.SnotMonsterQueue.Enqueue(snotMonster);
                Collider2D Snot2D = snotMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(Snot2D, snotMonster);
                break;
            case MonsterTypeByName.Bat:
                var BatMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level1/BatMonster")
                            .GetComponent<BatMonster>(), GameController.S.transform);
                BatMonster.gameObject.SetActive(false);
                GameController.S.BatMonsterQueue.Enqueue(BatMonster);
                Collider2D Bat2D = BatMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(Bat2D, BatMonster);
                break;
            case MonsterTypeByName.Bee:
                var BeeMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level1/EliteBeeMonster")
                            .GetComponent<EliteBeeMonster>(), GameController.S.transform);
                BeeMonster.gameObject.SetActive(false);
                GameController.S.EliteBeeMonsterQueue.Enqueue(BeeMonster);
                Collider2D Bee2D = BeeMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(Bee2D, BeeMonster);
                
                var BeeBullet = Instantiate(
                    Resources.Load<GameObject>("Prefabs/Monster/Level1/BeeBullet").GetComponent<BeeBullet>(),
                    GameController.S.transform);
                BeeBullet.gameObject.SetActive(false);
                GameController.S.BeeBulletQueue.Enqueue(BeeBullet);
                break;
            case MonsterTypeByName.Spider:
                var SpiderMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level1/SpiderMonster")
                            .GetComponent<SpiderMonster>(), GameController.S.transform);
                SpiderMonster.gameObject.SetActive(false);
                GameController.S.SpiderMonsterQueue.Enqueue(SpiderMonster);
                Collider2D Spider2D = SpiderMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(Spider2D, SpiderMonster);
                break;
            
            
            case MonsterTypeByName.XiaoHuo:
                var XiaoHuoMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level2/XiaoHuoMonster")
                            .GetComponent<XiaoHuoMonster>(), GameController.S.transform);
                XiaoHuoMonster.gameObject.SetActive(false);
                GameController.S.XiaoHuoMonsterQueue.Enqueue(XiaoHuoMonster);
                Collider2D XiaoHuo2D = XiaoHuoMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(XiaoHuo2D, XiaoHuoMonster);
                break;
            
            case MonsterTypeByName.ChongZi:
                var ChongZiMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level2/ChongZiMonster")
                            .GetComponent<ChongZiMonster>(), GameController.S.transform);
                ChongZiMonster.gameObject.SetActive(false);
                GameController.S.ChongZiMonsterQueue.Enqueue(ChongZiMonster);
                Collider2D ChongZi2D = ChongZiMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(ChongZi2D, ChongZiMonster);
                break;
            
            
            case MonsterTypeByName.DaZui:
                var DaZuiMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level2/EliteDaZuiMonster")
                            .GetComponent<EliteDaZuiMonster>(), GameController.S.transform);
                DaZuiMonster.gameObject.SetActive(false);
                GameController.S.EliteDaZuiMonsterQueue.Enqueue(DaZuiMonster);
                Collider2D DaZui2D = DaZuiMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(DaZui2D, DaZuiMonster);
                break;
            
            
            case MonsterTypeByName.DunDi:
                var DunDiMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level2/DunDiMonster")
                            .GetComponent<DunDiMonster>(), GameController.S.transform);
                DunDiMonster.gameObject.SetActive(false);
                GameController.S.DunDiMonsterQueue.Enqueue(DunDiMonster);
                Collider2D DunDi2D = DunDiMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(DunDi2D, DunDiMonster);
                break;
            
            
            
            case MonsterTypeByName.JiaChong:
                var JiaChongMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level3/JiaChongMonster")
                            .GetComponent<JiaChongMonster>(), GameController.S.transform);
                JiaChongMonster.gameObject.SetActive(false);
                GameController.S.JiaChongMonsterQueue.Enqueue(JiaChongMonster);
                Collider2D JiaChong2D = JiaChongMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(JiaChong2D, JiaChongMonster);
                break;
            
            
            case MonsterTypeByName.QingWa:
                var QingWaMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level3/QingWaMonster")
                            .GetComponent<QingWaMonster>(), GameController.S.transform);
                QingWaMonster.gameObject.SetActive(false);
                GameController.S.QingWaMonsterQueue.Enqueue(QingWaMonster);
                Collider2D QingWa2D = QingWaMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(QingWa2D, QingWaMonster);
                break;
            
            case MonsterTypeByName.ShiRenHua:
                var ShiRenHuaMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level3/ShiRenHuaMonster")
                            .GetComponent<ShiRenHuaMonster>(), GameController.S.transform);
                ShiRenHuaMonster.gameObject.SetActive(false);
                GameController.S.ShiRenHuaMonsterQueue.Enqueue(ShiRenHuaMonster);
                Collider2D ShiRenHua2D = ShiRenHuaMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(ShiRenHua2D, ShiRenHuaMonster);
                break;
            
            case MonsterTypeByName.WenZi:
                var WenZiMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level3/WenZiMonster")
                            .GetComponent<WenZiMonster>(), GameController.S.transform);
                WenZiMonster.gameObject.SetActive(false);
                GameController.S.WenZiMonsterQueue.Enqueue(WenZiMonster);
                Collider2D WenZi2D = WenZiMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(WenZi2D, WenZiMonster);
                break;
            
            
            case MonsterTypeByName.XueQiE:
                var XueQiEMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level5/XueQiE")
                            .GetComponent<XueQiE>(), GameController.S.transform);
                XueQiEMonster.gameObject.SetActive(false);
                GameController.S.XueQiEQueue.Enqueue(XueQiEMonster);
                Collider2D XueQiE2D = XueQiEMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(XueQiE2D, XueQiEMonster);
                break;
            
            
            
            case MonsterTypeByName.XueZhangLang:
                var XueZhangLangMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level5/XueZhangLang")
                            .GetComponent<XueZhangLang>(), GameController.S.transform);
                XueZhangLangMonster.gameObject.SetActive(false);
                GameController.S.XueZhangLangQueue.Enqueue(XueZhangLangMonster);
                Collider2D XueZhangLang2D = XueZhangLangMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(XueZhangLang2D, XueZhangLangMonster);
                break;
            
            
            case MonsterTypeByName.YingShu:
                var YingShuMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level5/YingShu")
                            .GetComponent<YingShu>(), GameController.S.transform);
                YingShuMonster.gameObject.SetActive(false);
                GameController.S.YingShuQueue.Enqueue(YingShuMonster);
                Collider2D YingShu2D = YingShuMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(YingShu2D, YingShuMonster);
                break;
            
            
            case MonsterTypeByName.XueRen:
                var XueRenMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level5/XueRen")
                            .GetComponent<XueRen>(), GameController.S.transform);
                XueRenMonster.gameObject.SetActive(false);
                GameController.S.XueRenQueue.Enqueue(XueRenMonster);
                Collider2D XueRen2D = XueRenMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(XueRen2D, XueRenMonster);
                break;
            
            
            
            case MonsterTypeByName.ShaXiYi:
                var ShaXiYiMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level4/ShaXiYi")
                            .GetComponent<ShaXiYi>(), GameController.S.transform);
                ShaXiYiMonster.gameObject.SetActive(false);
                GameController.S.ShaXiYiQueue.Enqueue(ShaXiYiMonster);
                Collider2D ShaXiYi2D = ShaXiYiMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(ShaXiYi2D, ShaXiYiMonster);
                break;
            
            case MonsterTypeByName.XianRenZhang:
                var XianRenZhangMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level4/XianRenZhang")
                            .GetComponent<XianRenZhang>(), GameController.S.transform);
                XianRenZhangMonster.gameObject.SetActive(false);
                GameController.S.XianRenZhangQueue.Enqueue(XianRenZhangMonster);
                Collider2D XianRenZhang2D = XianRenZhangMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(XianRenZhang2D, XianRenZhangMonster);
                break;
            
            
            case MonsterTypeByName.ShaChong:
                var ShaChongMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level4/ShaChong")
                            .GetComponent<ShaChong>(), GameController.S.transform);
                ShaChongMonster.gameObject.SetActive(false);
                GameController.S.ShaChongQueue.Enqueue(ShaChongMonster);
                Collider2D ShaChong2D = ShaChongMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(ShaChong2D, ShaChongMonster);
                break;
            
            
            case MonsterTypeByName.ShaNiao:
                var ShaNiaoMonster =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level4/ShaNiao")
                            .GetComponent<ShaNiao>(), GameController.S.transform);
                ShaNiaoMonster.gameObject.SetActive(false);
                GameController.S.ShaNiaoQueue.Enqueue(ShaNiaoMonster);
                Collider2D ShaNiao2D = ShaNiaoMonster.collider2D;
                GameController.S.MonsterColliderDic.Add(ShaNiao2D, ShaNiaoMonster);
                break;
            
            
            case MonsterTypeByName.banrenma1:
                var banrenma1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/banrenma1")
                            .GetComponent<banrenma1>(), GameController.S.transform);
                banrenma1.gameObject.SetActive(false);
                GameController.S.banrenma1Queue.Enqueue(banrenma1);
                MonsterBase banrenma1monsterBase = banrenma1.GetComponent<MonsterBase>();
                Collider2D banrenma12D = banrenma1monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(banrenma12D, banrenma1monsterBase);
                break;
            
            case MonsterTypeByName.banrenma2:
                var banrenma2 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/banrenma2")
                            .GetComponent<banrenma2>(), GameController.S.transform);
                banrenma2.gameObject.SetActive(false);
                GameController.S.banrenma2Queue.Enqueue(banrenma2);
                MonsterBase banrenma2monsterBase = banrenma2.GetComponent<MonsterBase>();
                Collider2D banrenma22D = banrenma2monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(banrenma22D, banrenma2monsterBase);
                break;
            
            
            case MonsterTypeByName.banrenma3:
                var banrenma3 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/banrenma3")
                            .GetComponent<banrenma3>(), GameController.S.transform);
                banrenma3.gameObject.SetActive(false);
                GameController.S.banrenma3Queue.Enqueue(banrenma3);
                MonsterBase banrenma3monsterBase = banrenma3.GetComponent<MonsterBase>();
                Collider2D banrenma32D = banrenma3monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(banrenma32D, banrenma3monsterBase);
                break;
            
            
            case MonsterTypeByName.she:
                var she =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/she")
                            .GetComponent<she>(), GameController.S.transform);
                she.gameObject.SetActive(false);
                GameController.S.sheQueue.Enqueue(she);
                MonsterBase shemonsterBase = she.GetComponent<MonsterBase>();
                Collider2D she2D = shemonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(she2D, shemonsterBase);
                break;
            
            
            case MonsterTypeByName.zibaolaoshu:
                var zibaolaoshu =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/zibaolaoshu")
                            .GetComponent<zibaolaoshu>(), GameController.S.transform);
                zibaolaoshu.gameObject.SetActive(false);
                GameController.S.zibaolaoshuQueue.Enqueue(zibaolaoshu);
                MonsterBase zibaolaoshumonsterBase = zibaolaoshu.GetComponent<MonsterBase>();
                Collider2D zibaolaoshu2D = zibaolaoshumonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(zibaolaoshu2D, zibaolaoshumonsterBase);
                break;
            
            
            case MonsterTypeByName.zhumodaocaoren:
                var zhumodaocaoren =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/zhumodaocaoren")
                            .GetComponent<zhumodaocaoren>(), GameController.S.transform);
                zhumodaocaoren.gameObject.SetActive(false);
                GameController.S.zhumodaocaorenQueue.Enqueue(zhumodaocaoren);
                MonsterBase zhumodaocaorenmonsterBase = zhumodaocaoren.GetComponent<MonsterBase>();
                Collider2D zhumodaocaoren2D = zhumodaocaorenmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(zhumodaocaoren2D, zhumodaocaorenmonsterBase);
                break;
            
            
            case MonsterTypeByName.yezhu:
                var yezhu =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/yezhu")
                            .GetComponent<yezhu>(), GameController.S.transform);
                yezhu.gameObject.SetActive(false);
                GameController.S.yezhuQueue.Enqueue(yezhu);
                MonsterBase yezhumonsterBase = yezhu.GetComponent<MonsterBase>();
                Collider2D yezhu2D = yezhumonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(yezhu2D, yezhumonsterBase);
                break;
            
            
            case MonsterTypeByName.yanshu:
                var yanshu =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/yanshu")
                            .GetComponent<yanshu>(), GameController.S.transform);
                yanshu.gameObject.SetActive(false);
                GameController.S.yanshuQueue.Enqueue(yanshu);
                MonsterBase yanshumonsterBase = yanshu.GetComponent<MonsterBase>();
                Collider2D yanshu2D = yanshumonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(yanshu2D, yanshumonsterBase);
                break;
            
            
            case MonsterTypeByName.xuelaoshu:
                var xuelaoshu =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/xuelaoshu")
                            .GetComponent<xuelaoshu>(), GameController.S.transform);
                xuelaoshu.gameObject.SetActive(false);
                GameController.S.xuelaoshuQueue.Enqueue(xuelaoshu);
                MonsterBase xuelaoshumonsterBase = xuelaoshu.GetComponent<MonsterBase>();
                Collider2D xuelaoshu2D = xuelaoshumonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(xuelaoshu2D, xuelaoshumonsterBase);
                break;
            
            
            case MonsterTypeByName.xiongbuou:
                var xiongbuou =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/xiongbuou")
                            .GetComponent<xiongbuou>(), GameController.S.transform);
                xiongbuou.gameObject.SetActive(false);
                GameController.S.xiongbuouQueue.Enqueue(xiongbuou);
                MonsterBase xiongbuoumonsterBase = xiongbuou.GetComponent<MonsterBase>();
                Collider2D xiongbuou2D = xiongbuoumonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(xiongbuou2D, xiongbuoumonsterBase);
                break;
            
            
            case MonsterTypeByName.xiezi2:
                var xiezi2 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/xiezi2")
                            .GetComponent<xiezi2>(), GameController.S.transform);
                xiezi2.gameObject.SetActive(false);
                GameController.S.xiezi2Queue.Enqueue(xiezi2);
                MonsterBase xiezi2monsterBase = xiezi2.GetComponent<MonsterBase>();
                Collider2D xiezi22D = xiezi2monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(xiezi22D, xiezi2monsterBase);
                break;
            
            
            case MonsterTypeByName.xiezi1:
                var xiezi1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/xiezi1")
                            .GetComponent<xiezi1>(), GameController.S.transform);
                xiezi1.gameObject.SetActive(false);
                GameController.S.xiezi1Queue.Enqueue(xiezi1);
                MonsterBase xiezi1monsterBase = xiezi1.GetComponent<MonsterBase>();
                Collider2D xiezi12D = xiezi1monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(xiezi12D, xiezi1monsterBase);
                break;
            
            
            case MonsterTypeByName.xiaoshuguai:
                var xiaoshuguai =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/xiaoshuguai")
                            .GetComponent<xiaoshuguai>(), GameController.S.transform);
                xiaoshuguai.gameObject.SetActive(false);
                GameController.S.xiaoshuguaiQueue.Enqueue(xiaoshuguai);
                MonsterBase xiaoshuguaimonsterBase = xiaoshuguai.GetComponent<MonsterBase>();
                Collider2D xiaoshuguai2D = xiaoshuguaimonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(xiaoshuguai2D, xiaoshuguaimonsterBase);
                break;
            
            
            case MonsterTypeByName.xiaozhizhu:
                var xiaozhizhu =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/xiaozhizhu")
                            .GetComponent<xiaozhizhu>(), GameController.S.transform);
                xiaozhizhu.gameObject.SetActive(false);
                GameController.S.xiaozhizhuQueue.Enqueue(xiaozhizhu);
                MonsterBase xiaozhizhumonsterBase = xiaozhizhu.GetComponent<MonsterBase>();
                Collider2D xiaozhizhu2D = xiaozhizhumonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(xiaozhizhu2D, xiaozhizhumonsterBase);
                break;
            
            
            case MonsterTypeByName.xiaohuoling:
                var xiaohuoling =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/xiaohuoling")
                            .GetComponent<xiaohuoling>(), GameController.S.transform);
                xiaohuoling.gameObject.SetActive(false);
                GameController.S.xiaohuolingQueue.Enqueue(xiaohuoling);
                MonsterBase xiaohuolingmonsterBase = xiaohuoling.GetComponent<MonsterBase>();
                Collider2D xiaohuoling2D = xiaohuolingmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(xiaohuoling2D, xiaohuolingmonsterBase);
                break;
            
            case MonsterTypeByName.woniu:
                var woniu =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/woniu")
                            .GetComponent<woniu>(), GameController.S.transform);
                woniu.gameObject.SetActive(false);
                GameController.S.woniuQueue.Enqueue(woniu);
                MonsterBase woniumonsterBase = woniu.GetComponent<MonsterBase>();
                Collider2D woniu2D = woniumonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(woniu2D, woniumonsterBase);
                break;
            
            
            case MonsterTypeByName.shanyang:
                var shanyang =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shanyang")
                            .GetComponent<shanyang>(), GameController.S.transform);
                shanyang.gameObject.SetActive(false);
                GameController.S.shanyangQueue.Enqueue(shanyang);
                MonsterBase shanyangmonsterBase = shanyang.GetComponent<MonsterBase>();
                Collider2D shanyang2D = shanyangmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(shanyang2D, shanyangmonsterBase);
                break;
            
            
            case MonsterTypeByName.rongyanboss:
                var rongyanboss =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/rongyanboss")
                            .GetComponent<rongyanboss>(), GameController.S.transform);
                rongyanboss.gameObject.SetActive(false);
                GameController.S.rongyanbossQueue.Enqueue(rongyanboss);
                MonsterBase rongyanbossmonsterBase = rongyanboss.GetComponent<MonsterBase>();
                Collider2D rongyanboss2D = rongyanbossmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(rongyanboss2D, rongyanbossmonsterBase);
                break;
            
            
            case MonsterTypeByName.queen:
                var queen =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/queen")
                            .GetComponent<queen>(), GameController.S.transform);
                queen.gameObject.SetActive(false);
                GameController.S.queenQueue.Enqueue(queen);
                MonsterBase queenmonsterBase = queen.GetComponent<MonsterBase>();
                Collider2D queen2D = queenmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(queen2D, queenmonsterBase);
                break;
            
            
            
            case MonsterTypeByName.paopao:
                var paopao =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/paopao")
                            .GetComponent<paopao>(), GameController.S.transform);
                paopao.gameObject.SetActive(false);
                GameController.S.paopaoQueue.Enqueue(paopao);
                MonsterBase paopaomonsterBase = paopao.GetComponent<MonsterBase>();
                Collider2D paopao2D = paopaomonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(paopao2D, paopaomonsterBase);
                break;
            
            
            case MonsterTypeByName.onyx:
                var onyx =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/onyx")
                            .GetComponent<onyx>(), GameController.S.transform);
                onyx.gameObject.SetActive(false);
                GameController.S.onyxQueue.Enqueue(onyx);
                MonsterBase onyxmonsterBase = onyx.GetComponent<MonsterBase>();
                Collider2D onyx2D = onyxmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(onyx2D, onyxmonsterBase);
                break;
            
            
            
            case MonsterTypeByName.niguai3:
                var niguai3 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/niguai3")
                            .GetComponent<niguai3>(), GameController.S.transform);
                niguai3.gameObject.SetActive(false);
                GameController.S.niguai3Queue.Enqueue(niguai3);
                MonsterBase niguai3monsterBase = niguai3.GetComponent<MonsterBase>();
                Collider2D niguai32D = niguai3monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(niguai32D, niguai3monsterBase);
                break;
            
            
            case MonsterTypeByName.niguai2:
                var niguai2 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/niguai2")
                            .GetComponent<niguai2>(), GameController.S.transform);
                niguai2.gameObject.SetActive(false);
                GameController.S.niguai2Queue.Enqueue(niguai2);
                MonsterBase niguai2monsterBase = niguai2.GetComponent<MonsterBase>();
                Collider2D niguai22D = niguai2monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(niguai22D, niguai2monsterBase);
                break;
            
            
            case MonsterTypeByName.niguai1:
                var niguai1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/niguai1")
                            .GetComponent<niguai1>(), GameController.S.transform);
                niguai1.gameObject.SetActive(false);
                GameController.S.niguai1Queue.Enqueue(niguai1);
                MonsterBase niguai1monsterBase = niguai1.GetComponent<MonsterBase>();
                Collider2D niguai12D = niguai1monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(niguai12D, niguai1monsterBase);
                break;
            
            
            case MonsterTypeByName.lang:
                var lang =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/lang")
                            .GetComponent<lang>(), GameController.S.transform);
                lang.gameObject.SetActive(false);
                GameController.S.langQueue.Enqueue(lang);
                MonsterBase langmonsterBase = lang.GetComponent<MonsterBase>();
                Collider2D lang2D = langmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(lang2D, langmonsterBase);
                break;
            
            
            case MonsterTypeByName.egg:
                var egg =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/egg")
                            .GetComponent<egg>(), GameController.S.transform);
                egg.gameObject.SetActive(false);
                GameController.S.eggQueue.Enqueue(egg);
                MonsterBase eggmonsterBase = egg.GetComponent<MonsterBase>();
                Collider2D egg2D = eggmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(egg2D, eggmonsterBase);
                break;
            
            
            case MonsterTypeByName.mogu:
                var mogu =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/mogu")
                            .GetComponent<mogu>(), GameController.S.transform);
                mogu.gameObject.SetActive(false);
                GameController.S.moguQueue.Enqueue(mogu);
                MonsterBase mogumonsterBase = mogu.GetComponent<MonsterBase>();
                Collider2D mogu2D = mogumonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(mogu2D, mogumonsterBase);
                break;
            
            
            case MonsterTypeByName.cat:
                var cat =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/cat")
                            .GetComponent<cat>(), GameController.S.transform);
                cat.gameObject.SetActive(false);
                GameController.S.catQueue.Enqueue(cat);
                MonsterBase catmonsterBase = cat.GetComponent<MonsterBase>();
                Collider2D cat2D = catmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(cat2D, catmonsterBase);
                break;
            
            case MonsterTypeByName.DaZongXiong:
            var dazongxiong =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/dazongxiong")
                            .GetComponent<dazongxiong>(), GameController.S.transform);
                dazongxiong.gameObject.SetActive(false);
                GameController.S.dazongxiongQueue.Enqueue(dazongxiong);
                MonsterBase dazongxiongmonsterBase = dazongxiong.GetComponent<MonsterBase>();
                Collider2D dazongxiong2D = dazongxiongmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(dazongxiong2D, dazongxiongmonsterBase);
                break;
            
            case MonsterTypeByName.LuJiaoDouShi:

                var lujiaodoushi =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/lujiaodoushi")
                            .GetComponent<lujiaodoushi>(), GameController.S.transform);
                lujiaodoushi.gameObject.SetActive(false);
                GameController.S.lujiaodoushiQueue.Enqueue(lujiaodoushi);
                MonsterBase lujiaodoushimonsterBase = lujiaodoushi.GetComponent<MonsterBase>();
                Collider2D lujiaodoushi2D = lujiaodoushimonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(lujiaodoushi2D, lujiaodoushimonsterBase);
                break;
                
            case MonsterTypeByName.KuangShiMuZhu:

                var kuangshimuzhu =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/kuangshimuzhu")
                            .GetComponent<kuangshimuzhu>(), GameController.S.transform);
                kuangshimuzhu.gameObject.SetActive(false);
                GameController.S.kuangshimuzhuQueue.Enqueue(kuangshimuzhu);
                MonsterBase kuangshimuzhumonsterBase = kuangshimuzhu.GetComponent<MonsterBase>();
                Collider2D kuangshimuzhu2D = kuangshimuzhumonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(kuangshimuzhu2D, kuangshimuzhumonsterBase);
                break;
                
            case MonsterTypeByName.FengHeGuai:

                var fengheguai =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/fengheguai")
                            .GetComponent<fengheguai>(), GameController.S.transform);
                fengheguai.gameObject.SetActive(false);
                GameController.S.fengheguaiQueue.Enqueue(fengheguai);
                MonsterBase fengheguaimonsterBase = fengheguai.GetComponent<MonsterBase>();
                Collider2D fengheguai2D = fengheguaimonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(fengheguai2D, fengheguaimonsterBase);

                break;
                
            case MonsterTypeByName.ShuangTouRen:

                var shuangtouren =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/shuangtouren")
                            .GetComponent<shuangtouren>(), GameController.S.transform);
                shuangtouren.gameObject.SetActive(false);
                GameController.S.shuangtourenQueue.Enqueue(shuangtouren);
                MonsterBase shuangtourenmonsterBase = shuangtouren.GetComponent<MonsterBase>();
                Collider2D shuangtouren2D = shuangtourenmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(shuangtouren2D, shuangtourenmonsterBase);

                break;
                
            case MonsterTypeByName.DaoCaoRen:

                var daocaoren =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/daocaoren").GetComponent<daocaoren>(),
                        GameController.S.transform);
                daocaoren.gameObject.SetActive(false);
                GameController.S.daocaorenQueue.Enqueue(daocaoren);
                MonsterBase daocaorenmonsterBase = daocaoren.GetComponent<MonsterBase>();
                Collider2D daocaoren2D = daocaorenmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(daocaoren2D, daocaorenmonsterBase);

                break;
                
            case MonsterTypeByName.CiZhu:

                var cizhu = Instantiate(
                    Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/cizhu").GetComponent<cizhu>(),
                    GameController.S.transform);
                cizhu.gameObject.SetActive(false);
                GameController.S.cizhuQueue.Enqueue(cizhu);
                MonsterBase cizhumonsterBase = cizhu.GetComponent<MonsterBase>();
                Collider2D cizhu2D = cizhumonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(cizhu2D, cizhumonsterBase);
                break;
                
            case MonsterTypeByName.ChaiLangRen1:


                var chailangren1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/chailangren1")
                            .GetComponent<chailangren1>(), GameController.S.transform);
                chailangren1.gameObject.SetActive(false);
                GameController.S.chailangren1Queue.Enqueue(chailangren1);
                MonsterBase chailangren1monsterBase = chailangren1.GetComponent<MonsterBase>();
                Collider2D chailangren12D = chailangren1monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(chailangren12D, chailangren1monsterBase);

                break;
                
            case MonsterTypeByName.ChaiLangRen2:

                var chailangren2 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/chailangren2")
                            .GetComponent<chailangren2>(), GameController.S.transform);
                chailangren2.gameObject.SetActive(false);
                GameController.S.chailangren2Queue.Enqueue(chailangren2);
                MonsterBase chailangren2monsterBase = chailangren2.GetComponent<MonsterBase>();
                Collider2D chailangren22D = chailangren2monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(chailangren22D, chailangren2monsterBase);

                break;
                
            case MonsterTypeByName.ChaiLangRen3:

                var chailangren3 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/chailangren3")
                            .GetComponent<chailangren3>(), GameController.S.transform);
                chailangren3.gameObject.SetActive(false);
                GameController.S.chailangren3Queue.Enqueue(chailangren3);
                MonsterBase chailangren3monsterBase = chailangren3.GetComponent<MonsterBase>();
                Collider2D chailangren32D = chailangren3monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(chailangren32D, chailangren3monsterBase);

                break;
                
            case MonsterTypeByName.ChaiLangRen4:

                var chailangren4 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/chailangren4")
                            .GetComponent<chailangren4>(), GameController.S.transform);
                chailangren4.gameObject.SetActive(false);
                GameController.S.chailangren4Queue.Enqueue(chailangren4);
                MonsterBase chailangren4monsterBase = chailangren4.GetComponent<MonsterBase>();
                Collider2D chailangren42D = chailangren4monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(chailangren42D, chailangren4monsterBase);

                break;
                
            case MonsterTypeByName.YeShouZhanShi:

                var YeShouZhanShi =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/YeShouZhanShi")
                            .GetComponent<YeShouZhanShi>(), GameController.S.transform);
                YeShouZhanShi.gameObject.SetActive(false);
                GameController.S.YeShouZhanShiQueue.Enqueue(YeShouZhanShi);
                MonsterBase YeShouZhanShimonsterBase = YeShouZhanShi.GetComponent<MonsterBase>();
                Collider2D YeShouZhanShi2D = YeShouZhanShimonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(YeShouZhanShi2D, YeShouZhanShimonsterBase);

                break;
                
            case MonsterTypeByName.ZhiZhuNvWang:

                var ZhiZhuNvWang =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/ZhiZhuNvWang")
                            .GetComponent<ZhiZhuNvWang>(), GameController.S.transform);
                ZhiZhuNvWang.gameObject.SetActive(false);
                GameController.S.ZhiZhuNvWangQueue.Enqueue(ZhiZhuNvWang);
                MonsterBase ZhiZhuNvWangmonsterBase = ZhiZhuNvWang.GetComponent<MonsterBase>();
                Collider2D ZhiZhuNvWang2D = ZhiZhuNvWangmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(ZhiZhuNvWang2D, ZhiZhuNvWangmonsterBase);
                break;
                
            case MonsterTypeByName.DiJing2:

                var dijing2 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijing2").GetComponent<dijing2>(),
                        GameController.S.transform);
                dijing2.gameObject.SetActive(false);
                GameController.S.dijing2Queue.Enqueue(dijing2);
                MonsterBase dijing2monsterBase = dijing2.GetComponent<MonsterBase>();
                Collider2D dijing22D = dijing2monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(dijing22D, dijing2monsterBase);

                break;
            case MonsterTypeByName.DiJing3:

                var dijing3 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijing3").GetComponent<dijing3>(),
                        GameController.S.transform);
                dijing3.gameObject.SetActive(false);
                GameController.S.dijing3Queue.Enqueue(dijing3);
                MonsterBase dijing3monsterBase = dijing3.GetComponent<MonsterBase>();
                Collider2D dijing32D = dijing3monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(dijing32D, dijing3monsterBase);
                break;
                
            case MonsterTypeByName.DiJingShouWei1:

                var dijingshouwei1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijingshouwei1")
                            .GetComponent<dijingshouwei1>(), GameController.S.transform);
                dijingshouwei1.gameObject.SetActive(false);
                GameController.S.dijingshouwei1Queue.Enqueue(dijingshouwei1);
                MonsterBase dijingshouwei1monsterBase = dijingshouwei1.GetComponent<MonsterBase>();
                Collider2D dijingshouwei12D = dijingshouwei1monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(dijingshouwei12D, dijingshouwei1monsterBase);
                break;
                
            case MonsterTypeByName.DiJingShouWei2:

                var dijingshouwei2 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijingshouwei2")
                            .GetComponent<dijingshouwei2>(), GameController.S.transform);
                dijingshouwei2.gameObject.SetActive(false);
                GameController.S.dijingshouwei2Queue.Enqueue(dijingshouwei2);
                MonsterBase dijingshouwei2monsterBase = dijingshouwei2.GetComponent<MonsterBase>();
                Collider2D dijingshouwei22D = dijingshouwei2monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(dijingshouwei22D, dijingshouwei2monsterBase);
                break;
            case MonsterTypeByName.DiJingShouWei3:

                var dijingshouwei3 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/dijingshouwei3")
                            .GetComponent<dijingshouwei3>(), GameController.S.transform);
                dijingshouwei3.gameObject.SetActive(false);
                GameController.S.dijingshouwei3Queue.Enqueue(dijingshouwei3);
                MonsterBase dijingshouwei3monsterBase = dijingshouwei3.GetComponent<MonsterBase>();
                Collider2D dijingshouwei32D = dijingshouwei3monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(dijingshouwei32D, dijingshouwei3monsterBase);
                break;
                
            case MonsterTypeByName.HeiXiong:

                var heixiong =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/heixiong").GetComponent<heixiong>(),
                        GameController.S.transform);
                heixiong.gameObject.SetActive(false);
                GameController.S.heixiongQueue.Enqueue(heixiong);
                MonsterBase heixiongmonsterBase = heixiong.GetComponent<MonsterBase>();
                Collider2D heixiong2D = heixiongmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(heixiong2D, heixiongmonsterBase);
                break;
                
            case MonsterTypeByName.JianChiZhu:

                var jianchizhu =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/jianchizhu")
                            .GetComponent<jianchizhu>(), GameController.S.transform);
                jianchizhu.gameObject.SetActive(false);
                GameController.S.jianchizhuQueue.Enqueue(jianchizhu);
                MonsterBase jianchizhumonsterBase = jianchizhu.GetComponent<MonsterBase>();
                Collider2D jianchizhu2D = jianchizhumonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(jianchizhu2D, jianchizhumonsterBase);

                break;
                
            case MonsterTypeByName.KuLou1:

                var kulou1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou1").GetComponent<kulou1>(),
                        GameController.S.transform);
                kulou1.gameObject.SetActive(false);
                GameController.S.kulou1Queue.Enqueue(kulou1);
                MonsterBase kulou1monsterBase = kulou1.GetComponent<MonsterBase>();
                Collider2D kulou12D = kulou1monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(kulou12D, kulou1monsterBase);

                break;
                
            case MonsterTypeByName.KuLou2:

                var kulou2 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou2").GetComponent<kulou2>(),
                        GameController.S.transform);
                kulou2.gameObject.SetActive(false);
                GameController.S.kulou2Queue.Enqueue(kulou2);
                MonsterBase kulou2monsterBase = kulou2.GetComponent<MonsterBase>();
                Collider2D kulou22D = kulou2monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(kulou22D, kulou2monsterBase);

                break;
                
            case MonsterTypeByName.KuLou3:

                var kulou3 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou3").GetComponent<kulou3>(),
                        GameController.S.transform);
                kulou3.gameObject.SetActive(false);
                GameController.S.kulou3Queue.Enqueue(kulou3);
                MonsterBase kulou3monsterBase = kulou3.GetComponent<MonsterBase>();
                Collider2D kulou32D = kulou3monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(kulou32D, kulou3monsterBase);
                break;
                
            case MonsterTypeByName.KuLou4:

                var kulou4 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou4").GetComponent<kulou4>(),
                        GameController.S.transform);
                kulou4.gameObject.SetActive(false);
                GameController.S.kulou4Queue.Enqueue(kulou4);
                MonsterBase kulou4monsterBase = kulou4.GetComponent<MonsterBase>();
                Collider2D kulou42D = kulou4monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(kulou42D, kulou4monsterBase);

                break;
                
            case MonsterTypeByName.KuLou5:

                var kulou5 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou5").GetComponent<kulou5>(),
                        GameController.S.transform);
                kulou5.gameObject.SetActive(false);
                GameController.S.kulou5Queue.Enqueue(kulou5);
                MonsterBase kulou5monsterBase = kulou5.GetComponent<MonsterBase>();
                Collider2D kulou52D = kulou5monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(kulou52D, kulou5monsterBase);

                break;
                
            case MonsterTypeByName.KuLou6:

                var kulou6 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/kulou6").GetComponent<kulou6>(),
                        GameController.S.transform);
                kulou6.gameObject.SetActive(false);
                GameController.S.kulou6Queue.Enqueue(kulou6);
                MonsterBase kulou6monsterBase = kulou6.GetComponent<MonsterBase>();
                Collider2D kulou62D = kulou6monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(kulou62D, kulou6monsterBase);

                break;
                
            case MonsterTypeByName.LuJiaoCiKe1:

                var lujiaocike =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/lujiaocike")
                            .GetComponent<lujiaocike>(), GameController.S.transform);
                lujiaocike.gameObject.SetActive(false);
                GameController.S.lujiaocikeQueue.Enqueue(lujiaocike);
                MonsterBase lujiaocikemonsterBase = lujiaocike.GetComponent<MonsterBase>();
                Collider2D lujiaocike2D = lujiaocikemonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(lujiaocike2D, lujiaocikemonsterBase);

                break;
                
            case MonsterTypeByName.LuJiaoCiKe2:

                var lujiaocike2 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/lujiaocike2")
                            .GetComponent<lujiaocike2>(), GameController.S.transform);
                lujiaocike2.gameObject.SetActive(false);
                GameController.S.lujiaocike2Queue.Enqueue(lujiaocike2);
                MonsterBase lujiaocike2monsterBase = lujiaocike2.GetComponent<MonsterBase>();
                Collider2D lujiaocike22D = lujiaocike2monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(lujiaocike22D, lujiaocike2monsterBase);

                break;
                
            case MonsterTypeByName.NiuTouRen1:

                var niutouren1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/niutouren1")
                            .GetComponent<niutouren1>(), GameController.S.transform);
                niutouren1.gameObject.SetActive(false);
                GameController.S.niutouren1Queue.Enqueue(niutouren1);
                MonsterBase niutouren1monsterBase = niutouren1.GetComponent<MonsterBase>();
                Collider2D niutouren12D = niutouren1monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(niutouren12D, niutouren1monsterBase);
                break;
                
            case MonsterTypeByName.NiuTouRen2:

                var niutouren2 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/niutouren2")
                            .GetComponent<niutouren2>(), GameController.S.transform);
                niutouren2.gameObject.SetActive(false);
                GameController.S.niutouren2Queue.Enqueue(niutouren2);
                MonsterBase niutouren2monsterBase = niutouren2.GetComponent<MonsterBase>();
                Collider2D niutouren22D = niutouren2monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(niutouren22D, niutouren2monsterBase);
                break;
                
            case MonsterTypeByName.NiuTouRen3:

                var niutouren3 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/niutouren3")
                            .GetComponent<niutouren3>(), GameController.S.transform);
                niutouren3.gameObject.SetActive(false);
                GameController.S.niutouren3Queue.Enqueue(niutouren3);
                MonsterBase niutouren3monsterBase = niutouren3.GetComponent<MonsterBase>();
                Collider2D niutouren32D = niutouren3monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(niutouren32D, niutouren3monsterBase);
                break;
                
            case MonsterTypeByName.ShanZei3:

                var shanzei3 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shanzei3").GetComponent<shanzei3>(),
                        GameController.S.transform);
                shanzei3.gameObject.SetActive(false);
                GameController.S.shanzei3Queue.Enqueue(shanzei3);
                MonsterBase shanzei3monsterBase = shanzei3.GetComponent<MonsterBase>();
                Collider2D shanzei32D = shanzei3monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(shanzei32D, shanzei3monsterBase);

                break;
                
            case MonsterTypeByName.ShiJiaChong:

                var shijiachong =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shijiachong")
                            .GetComponent<shijiachong>(), GameController.S.transform);
                shijiachong.gameObject.SetActive(false);
                GameController.S.shijiachongQueue.Enqueue(shijiachong);
                MonsterBase shijiachongmonsterBase = shijiachong.GetComponent<MonsterBase>();
                Collider2D shijiachong2D = shijiachongmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(shijiachong2D, shijiachongmonsterBase);
                break;
                
            case MonsterTypeByName.ShiShiGui:

                var shishigui =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shishigui").GetComponent<shishigui>(),
                        GameController.S.transform);
                shishigui.gameObject.SetActive(false);
                GameController.S.shishiguiQueue.Enqueue(shishigui);
                MonsterBase shishiguimonsterBase = shishigui.GetComponent<MonsterBase>();
                Collider2D shishigui2D = shishiguimonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(shishigui2D, shishiguimonsterBase);
                break;
                
            case MonsterTypeByName.ShiXiangGui:

                var shixianggui =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shixianggui")
                            .GetComponent<shixianggui>(), GameController.S.transform);
                shixianggui.gameObject.SetActive(false);
                GameController.S.shixiangguiQueue.Enqueue(shixianggui);
                MonsterBase shixiangguimonsterBase = shixianggui.GetComponent<MonsterBase>();
                Collider2D shixianggui2D = shixiangguimonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(shixianggui2D, shixiangguimonsterBase);

                break;
            case MonsterTypeByName.ShouRen1:

                var shouren1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/shouren1").GetComponent<shouren1>(),
                        GameController.S.transform);
                shouren1.gameObject.SetActive(false);
                GameController.S.shouren1Queue.Enqueue(shouren1);
                MonsterBase shouren1monsterBase = shouren1.GetComponent<MonsterBase>();
                Collider2D shouren12D = shouren1monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(shouren12D, shouren1monsterBase);

                break;
                
            case MonsterTypeByName.ShouRen2:

                var shouren2 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/shouren2").GetComponent<shouren2>(),
                        GameController.S.transform);
                shouren2.gameObject.SetActive(false);
                GameController.S.shouren2Queue.Enqueue(shouren2);
                MonsterBase shouren2monsterBase = shouren2.GetComponent<MonsterBase>();
                Collider2D shouren22D = shouren2monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(shouren22D, shouren2monsterBase);

                break;
                
            case MonsterTypeByName.ShouRen3:

                var shouren3 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/shouren3").GetComponent<shouren3>(),
                        GameController.S.transform);
                shouren3.gameObject.SetActive(false);
                GameController.S.shouren3Queue.Enqueue(shouren3);
                MonsterBase shouren3monsterBase = shouren3.GetComponent<MonsterBase>();
                Collider2D shouren32D = shouren3monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(shouren32D, shouren3monsterBase);
                break;
                
            case MonsterTypeByName.ShuangTouLong1:

                var shuangtoulong =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shuangtoulong")
                            .GetComponent<shuangtoulong>(), GameController.S.transform);
                shuangtoulong.gameObject.SetActive(false);
                GameController.S.shuangtoulongQueue.Enqueue(shuangtoulong);
                MonsterBase shuangtoulongmonsterBase = shuangtoulong.GetComponent<MonsterBase>();
                Collider2D shuangtoulong2D = shuangtoulongmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(shuangtoulong2D, shuangtoulongmonsterBase);

                break;
                
            case MonsterTypeByName.ShuangTouLong2:

                var shuangtoulong2 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shuangtoulong2")
                            .GetComponent<shuangtoulong2>(), GameController.S.transform);
                shuangtoulong2.gameObject.SetActive(false);
                GameController.S.shuangtoulong2Queue.Enqueue(shuangtoulong2);
                MonsterBase shuangtoulong2monsterBase = shuangtoulong2.GetComponent<MonsterBase>();
                Collider2D shuangtoulong22D = shuangtoulong2monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(shuangtoulong22D, shuangtoulong2monsterBase);

                break;
                
            case MonsterTypeByName.ShuangTouLong3:

                var shuangtoulong3 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/shuangtoulong3")
                            .GetComponent<shuangtoulong3>(), GameController.S.transform);
                shuangtoulong3.gameObject.SetActive(false);
                GameController.S.shuangtoulong3Queue.Enqueue(shuangtoulong3);
                MonsterBase shuangtoulong3monsterBase = shuangtoulong3.GetComponent<MonsterBase>();
                Collider2D shuangtoulong32D = shuangtoulong3monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(shuangtoulong32D, shuangtoulong3monsterBase);

                break;
                
            case MonsterTypeByName.TuJiu:

                var tujiu = Instantiate(
                    Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/tujiu").GetComponent<tujiu>(),
                    GameController.S.transform);
                tujiu.gameObject.SetActive(false);
                GameController.S.tujiuQueue.Enqueue(tujiu);
                MonsterBase tujiumonsterBase = tujiu.GetComponent<MonsterBase>();
                Collider2D tujiu2D = tujiumonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(tujiu2D, tujiumonsterBase);

                break;
                
            case MonsterTypeByName.WuYa:

                var wuya = Instantiate(
                    Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/wuya").GetComponent<wuya>(),
                    GameController.S.transform);
                wuya.gameObject.SetActive(false);
                GameController.S.wuyaQueue.Enqueue(wuya);
                MonsterBase wuyamonsterBase = wuya.GetComponent<MonsterBase>();
                Collider2D wuya2D = wuyamonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(wuya2D, wuyamonsterBase);
                break;
                
            case MonsterTypeByName.YouHunLingZhu:

                var youhunlingzhu =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/EliteMonster/youhunlingzhu")
                            .GetComponent<youhunlingzhu>(), GameController.S.transform);
                youhunlingzhu.gameObject.SetActive(false);
                GameController.S.youhunlingzhuQueue.Enqueue(youhunlingzhu);
                MonsterBase youhunlingzhumonsterBase = youhunlingzhu.GetComponent<MonsterBase>();
                Collider2D youhunlingzhu2D = youhunlingzhumonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(youhunlingzhu2D, youhunlingzhumonsterBase);

                break;
            case MonsterTypeByName.YouLang:

                var youlang =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/youlang").GetComponent<youlang>(),
                        GameController.S.transform);
                youlang.gameObject.SetActive(false);
                GameController.S.youlangQueue.Enqueue(youlang);
                MonsterBase youlangmonsterBase = youlang.GetComponent<MonsterBase>();
                Collider2D youlang2D = youlangmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(youlang2D, youlangmonsterBase);

                break;
            case MonsterTypeByName.YouLing1:

                var youling =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/youling").GetComponent<youling>(),
                        GameController.S.transform);
                youling.gameObject.SetActive(false);
                GameController.S.youlingQueue.Enqueue(youling);
                MonsterBase youlingmonsterBase = youling.GetComponent<MonsterBase>();
                Collider2D youling2D = youlingmonsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(youling2D, youlingmonsterBase);

                break;
                
            case MonsterTypeByName.YouLing2:

                var youling2 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/youling2").GetComponent<youling2>(),
                        GameController.S.transform);
                youling2.gameObject.SetActive(false);
                GameController.S.youling2Queue.Enqueue(youling2);
                MonsterBase youling2monsterBase = youling2.GetComponent<MonsterBase>();
                Collider2D youling22D = youling2monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(youling22D, youling2monsterBase);

                break;
                
            case MonsterTypeByName.YuRen1:

                var yuren1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/yuren1").GetComponent<yuren1>(),
                        GameController.S.transform);
                yuren1.gameObject.SetActive(false);
                GameController.S.yuren1Queue.Enqueue(yuren1);
                MonsterBase yuren1monsterBase = yuren1.GetComponent<MonsterBase>();
                Collider2D yuren12D = yuren1monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(yuren12D, yuren1monsterBase);

                break;
                
            case MonsterTypeByName.YuRen2:

                var yuren2 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/yuren2").GetComponent<yuren2>(),
                        GameController.S.transform);
                yuren2.gameObject.SetActive(false);
                GameController.S.yuren2Queue.Enqueue(yuren2);
                MonsterBase yuren2monsterBase = yuren2.GetComponent<MonsterBase>();
                Collider2D yuren22D = yuren2monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(yuren22D, yuren2monsterBase);

                break;
                
            case MonsterTypeByName.YuRen3:

                var yuren3 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/NormalMonster/yuren3").GetComponent<yuren3>(),
                        GameController.S.transform);
                yuren3.gameObject.SetActive(false);
                GameController.S.yuren3Queue.Enqueue(yuren3);
                MonsterBase yuren3monsterBase = yuren3.GetComponent<MonsterBase>();
                Collider2D yuren32D = yuren3monsterBase.collider2D;
                GameController.S.MonsterColliderDic.Add(yuren32D, yuren3monsterBase);
                break;
        }
    }

    public static void InitProp(MonsterProp info)
    {
        switch (info.PropItem.PropType)
        {
            case PropConfig.PropType.ChiBangFight:
                ChiBangFight chibang =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChiBang")).GetComponent<ChiBangFight>();
                chibang.gameObject.SetActive(false);
                GameController.S.ChiBangFightQueue.Enqueue(chibang);
                break;
            case PropConfig.PropType.WeaponFragment:
                switch (info.PropItem.Quality)
                {
                    case 1:
                        GameObject whiteWeaponFragmeng =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Prop/WhiteWeaponFragmeng"));
                        whiteWeaponFragmeng.gameObject.SetActive(false);
                        GameController.S.WhiteWeaponFragmengQueue.Enqueue(whiteWeaponFragmeng);
                        break;
                    case 2:
                        GameObject GreenWeaponFragmeng =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Prop/GreenWeaponFragmeng"));
                        GreenWeaponFragmeng.gameObject.SetActive(false);
                        GameController.S.GreenWeaponFragmengQueue.Enqueue(GreenWeaponFragmeng);
                        break;
                    case 3:
                        GameObject BlueWeaponFragmeng =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Prop/BlueWeaponFragmeng"));
                        BlueWeaponFragmeng.gameObject.SetActive(false);
                        GameController.S.BlueWeaponFragmengQueue.Enqueue(BlueWeaponFragmeng);
                        break;
                    case 4:
                        GameObject PurpleWeaponFragmeng =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Prop/PurpleWeaponFragmeng"));
                        PurpleWeaponFragmeng.gameObject.SetActive(false);
                        GameController.S.PurpleWeaponFragmengQueue.Enqueue(PurpleWeaponFragmeng);
                        break;
                    case 5:
                        GameObject OrangeWeaponFragmeng =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Prop/OrangeWeaponFragmeng"));
                        OrangeWeaponFragmeng.gameObject.SetActive(false);
                        GameController.S.OrangeWeaponFragmengQueue.Enqueue(OrangeWeaponFragmeng);
                        break;
                    case 6:
                        GameObject RedWeaponFragmeng =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Prop/RedWeaponFragmeng"));
                        RedWeaponFragmeng.gameObject.SetActive(false);
                        GameController.S.RedWeaponFragmengQueue.Enqueue(RedWeaponFragmeng);
                        break;
                }
                break;
            
            
            
            case PropConfig.PropType.ChiBang:
                switch (info.PropItem.Quality)
                {
                    case 1:
                        GameObject whiteChiBang =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Prop/WhiteChiBang"));
                        whiteChiBang.gameObject.SetActive(false);
                        GameController.S.WhiteChiBangQueue.Enqueue(whiteChiBang);
                        break;
                    case 2:
                        GameObject GreenChiBang =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Prop/GreenChiBang"));
                        GreenChiBang.gameObject.SetActive(false);
                        GameController.S.GreenChiBangQueue.Enqueue(GreenChiBang);
                        break;
                    case 3:
                        GameObject BlueChiBang =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Prop/BlueChiBang"));
                        BlueChiBang.gameObject.SetActive(false);
                        GameController.S.BlueChiBangQueue.Enqueue(BlueChiBang);
                        break;
                    case 4:
                        GameObject PurpleChiBang =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Prop/PurpleChiBang"));
                        PurpleChiBang.gameObject.SetActive(false);
                        GameController.S.PurpleChiBangQueue.Enqueue(PurpleChiBang);
                        break;
                    case 5:
                        GameObject OrangeChiBang =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Prop/OrangeChiBang"));
                        OrangeChiBang.gameObject.SetActive(false);
                        GameController.S.OrangeChiBangQueue.Enqueue(OrangeChiBang);
                        break;
                    case 6:
                        GameObject RedChiBang =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Prop/RedChiBang"));
                        RedChiBang.gameObject.SetActive(false);
                        GameController.S.RedChiBangQueue.Enqueue(RedChiBang);
                        break;
                }
                break;
            
            
            case PropConfig.PropType.ChongWuDan:
                ChongWuDanFight ChongWuDan =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChongWuDan")).GetComponent<ChongWuDanFight>();
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
                GameController.S.ChongWuDanQueue.Enqueue(ChongWuDan);
                break;
            
            case PropConfig.PropType.XiSuiYe:
                XiSuiYeFight XiSuiYe =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Prop/XiSuiYe")).GetComponent<XiSuiYeFight>();
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
                GameController.S.XiSuiYeQueue.Enqueue(XiSuiYe);
                break;
            
            
            case PropConfig.PropType.XueMaiDan:
                XueMaiDanFight XueMaiDan =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Prop/XueMaiDan")).GetComponent<XueMaiDanFight>();
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
                GameController.S.XueMaiDanQueue.Enqueue(XueMaiDan);
                break;
            
            
            case PropConfig.PropType.SkillShu:
                ChongWuSkillShuFight ChongWuSkillShu =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChongWuSkillShu")).GetComponent<ChongWuSkillShuFight>();
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
                GameController.S.ChongWuSkillShuQueue.Enqueue(ChongWuSkillShu);
                break;
            
            
            case PropConfig.PropType.ChongWuShiWu:
                ChongWuShiWuFight ChongWuShiWu =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ChongWuShiWu")).GetComponent<ChongWuShiWuFight>();
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
                GameController.S.ChongWuShiWuQueue.Enqueue(ChongWuShiWu);
                break;
            
            case PropConfig.PropType.DaKongShi:
                DaKongShiFight DaKongShi =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Prop/DaKongShi")).GetComponent<DaKongShiFight>();
                DaKongShi.gameObject.SetActive(false);
                GameController.S.DaKongShiQueue.Enqueue(DaKongShi);
                break;
            
            case PropConfig.PropType.ShenHuaCaiLiao:
                ShenHuaCaiLiaoFight ShenHuaCaiLiao =
                    Instantiate(Resources.Load<GameObject>("Prefabs/Prop/ShenHuaCaiLiao")).GetComponent<ShenHuaCaiLiaoFight>();
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
                GameController.S.ShenHuaCaiLiaoQueue.Enqueue(ShenHuaCaiLiao);
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
                    GameObject primaryCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryCloakFight"));
                    primaryCloakFight.gameObject.SetActive(false);
                    GameController.S.PrimaryCloakQueue.Enqueue(primaryCloakFight);
                    break;
                    case PlayerEquipConfig.EquipType.Necklace:
                        GameObject primaryNecklaceFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryNecklaceFight"));
                        primaryNecklaceFight.gameObject.SetActive(false);
                        GameController.S.PrimaryNecklaceQueue.Enqueue(primaryNecklaceFight);
                        break;
                    case PlayerEquipConfig.EquipType.Cloth:
                        GameObject primaryClothFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryClothFight"));
                        primaryClothFight.gameObject.SetActive(false);
                        GameController.S.PrimaryClothQueue.Enqueue(primaryClothFight);
                        break;
                    case PlayerEquipConfig.EquipType.Helmet:
                        GameObject primaryHelmetFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryHelmetFight"));
                        primaryHelmetFight.gameObject.SetActive(false);
                        GameController.S.PrimaryHelmetQueue.Enqueue(primaryHelmetFight);
                        break;
                    case PlayerEquipConfig.EquipType.Shoe:
                        GameObject primaryShoeFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryShoeFight"));
                        primaryShoeFight.gameObject.SetActive(false);
                        GameController.S.PrimaryShoeQueue.Enqueue(primaryShoeFight);
                        break;
                    case PlayerEquipConfig.EquipType.Ring:
                        GameObject primaryRingFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Primary/PrimaryRingFight"));
                        primaryRingFight.gameObject.SetActive(false);
                        GameController.S.PrimaryRingQueue.Enqueue(primaryRingFight);
                        break;
                }
                break;
            
            
            
            
            case PlayerEquipConfig.EquipLevel.Green:
                switch (info.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                    GameObject GreenCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenCloakFight"));
                    GreenCloakFight.gameObject.SetActive(false);
                    GameController.S.GreenCloakQueue.Enqueue(GreenCloakFight);
                    break;
                    case PlayerEquipConfig.EquipType.Necklace:
                        GameObject GreenNecklaceFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenNecklaceFight"));
                        GreenNecklaceFight.gameObject.SetActive(false);
                        GameController.S.GreenNecklaceQueue.Enqueue(GreenNecklaceFight);
                        break;
                    case PlayerEquipConfig.EquipType.Cloth:
                        GameObject GreenClothFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenClothFight"));
                        GreenClothFight.gameObject.SetActive(false);
                        GameController.S.GreenClothQueue.Enqueue(GreenClothFight);
                        break;
                    case PlayerEquipConfig.EquipType.Helmet:
                        GameObject GreenHelmetFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenHelmetFight"));
                        GreenHelmetFight.gameObject.SetActive(false);
                        GameController.S.GreenHelmetQueue.Enqueue(GreenHelmetFight);
                        break;
                    case PlayerEquipConfig.EquipType.Shoe:
                        GameObject GreenShoeFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenShoeFight"));
                        GreenShoeFight.gameObject.SetActive(false);
                        GameController.S.GreenShoeQueue.Enqueue(GreenShoeFight);
                        break;
                    case PlayerEquipConfig.EquipType.Ring:
                        GameObject GreenRingFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Green/GreenRingFight"));
                        GreenRingFight.gameObject.SetActive(false);
                        GameController.S.GreenRingQueue.Enqueue(GreenRingFight);
                        break;
                }
                break;
            
            
            
            
            
            case PlayerEquipConfig.EquipLevel.Blue:
                switch (info.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                    GameObject BlueCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueCloakFight"));
                    BlueCloakFight.gameObject.SetActive(false);
                    GameController.S.BlueCloakQueue.Enqueue(BlueCloakFight);
                    break;
                    case PlayerEquipConfig.EquipType.Necklace:
                        GameObject BlueNecklaceFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueNecklaceFight"));
                        BlueNecklaceFight.gameObject.SetActive(false);
                        GameController.S.BlueNecklaceQueue.Enqueue(BlueNecklaceFight);
                        break;
                    case PlayerEquipConfig.EquipType.Cloth:
                        GameObject BlueClothFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueClothFight"));
                        BlueClothFight.gameObject.SetActive(false);
                        GameController.S.BlueClothQueue.Enqueue(BlueClothFight);
                        break;
                    case PlayerEquipConfig.EquipType.Helmet:
                        GameObject BlueHelmetFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueHelmetFight"));
                        BlueHelmetFight.gameObject.SetActive(false);
                        GameController.S.BlueHelmetQueue.Enqueue(BlueHelmetFight);
                        break;
                    case PlayerEquipConfig.EquipType.Shoe:
                        GameObject BlueShoeFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueShoeFight"));
                        BlueShoeFight.gameObject.SetActive(false);
                        GameController.S.BlueShoeQueue.Enqueue(BlueShoeFight);
                        break;
                    case PlayerEquipConfig.EquipType.Ring:
                        GameObject BlueRingFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Blue/BlueRingFight"));
                        BlueRingFight.gameObject.SetActive(false);
                        GameController.S.BlueRingQueue.Enqueue(BlueRingFight);
                        break;
                }
                break;
            
            
            
            
            case PlayerEquipConfig.EquipLevel.Purple:
                switch (info.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                    GameObject PurpleCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleCloakFight"));
                    PurpleCloakFight.gameObject.SetActive(false);
                    GameController.S.PurpleCloakQueue.Enqueue(PurpleCloakFight);
                    break;
                    case PlayerEquipConfig.EquipType.Necklace:
                        GameObject PurpleNecklaceFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleNecklaceFight"));
                        PurpleNecklaceFight.gameObject.SetActive(false);
                        GameController.S.PurpleNecklaceQueue.Enqueue(PurpleNecklaceFight);
                        break;
                    case PlayerEquipConfig.EquipType.Cloth:
                        GameObject PurpleClothFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleClothFight"));
                        PurpleClothFight.gameObject.SetActive(false);
                        GameController.S.PurpleClothQueue.Enqueue(PurpleClothFight);
                        break;
                    case PlayerEquipConfig.EquipType.Helmet:
                        GameObject PurpleHelmetFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleHelmetFight"));
                        PurpleHelmetFight.gameObject.SetActive(false);
                        GameController.S.PurpleHelmetQueue.Enqueue(PurpleHelmetFight);
                        break;
                    case PlayerEquipConfig.EquipType.Shoe:
                        GameObject PurpleShoeFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleShoeFight"));
                        PurpleShoeFight.gameObject.SetActive(false);
                        GameController.S.PurpleShoeQueue.Enqueue(PurpleShoeFight);
                        break;
                    case PlayerEquipConfig.EquipType.Ring:
                        GameObject PurpleRingFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple/PurpleRingFight"));
                        PurpleRingFight.gameObject.SetActive(false);
                        GameController.S.PurpleRingQueue.Enqueue(PurpleRingFight);
                        break;
                }
                break;
            
            
            
            
            case PlayerEquipConfig.EquipLevel.Purple1:
                switch (info.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                    GameObject Purple1CloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/Purple1CloakFight"));
                    Purple1CloakFight.gameObject.SetActive(false);
                    GameController.S.Purple1CloakQueue.Enqueue(Purple1CloakFight);
                    break;
                    case PlayerEquipConfig.EquipType.Necklace:
                        GameObject Purple1NecklaceFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/Purple1NecklaceFight"));
                        Purple1NecklaceFight.gameObject.SetActive(false);
                        GameController.S.Purple1NecklaceQueue.Enqueue(Purple1NecklaceFight);
                        break;
                    case PlayerEquipConfig.EquipType.Cloth:
                        GameObject Purple1ClothFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/Purple1ClothFight"));
                        Purple1ClothFight.gameObject.SetActive(false);
                        GameController.S.Purple1ClothQueue.Enqueue(Purple1ClothFight);
                        break;
                    case PlayerEquipConfig.EquipType.Helmet:
                        GameObject Purple1HelmetFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/Purple1HelmetFight"));
                        Purple1HelmetFight.gameObject.SetActive(false);
                        GameController.S.Purple1HelmetQueue.Enqueue(Purple1HelmetFight);
                        break;
                    case PlayerEquipConfig.EquipType.Shoe:
                        GameObject Purple1ShoeFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/Purple1ShoeFight"));
                        Purple1ShoeFight.gameObject.SetActive(false);
                        GameController.S.Purple1ShoeQueue.Enqueue(Purple1ShoeFight);
                        break;
                    case PlayerEquipConfig.EquipType.Ring:
                        GameObject Purple1RingFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/Purple1/Purple1RingFight"));
                        Purple1RingFight.gameObject.SetActive(false);
                        GameController.S.Purple1RingQueue.Enqueue(Purple1RingFight);
                        break;
                }
                break;
            
            
            
            
            case PlayerEquipConfig.EquipLevel.TreeMan:
                switch (info.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                    GameObject TreeManCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManCloakFight"));
                    TreeManCloakFight.gameObject.SetActive(false);
                    GameController.S.TreeManCloakQueue.Enqueue(TreeManCloakFight);
                    break;
                    case PlayerEquipConfig.EquipType.Necklace:
                        GameObject TreeManNecklaceFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManNecklaceFight"));
                        TreeManNecklaceFight.gameObject.SetActive(false);
                        GameController.S.TreeManNecklaceQueue.Enqueue(TreeManNecklaceFight);
                        break;
                    case PlayerEquipConfig.EquipType.Cloth:
                        GameObject TreeManClothFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManClothFight"));
                        TreeManClothFight.gameObject.SetActive(false);
                        GameController.S.TreeManClothQueue.Enqueue(TreeManClothFight);
                        break;
                    case PlayerEquipConfig.EquipType.Helmet:
                        GameObject TreeManHelmetFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManHelmetFight"));
                        TreeManHelmetFight.gameObject.SetActive(false);
                        GameController.S.TreeManHelmetQueue.Enqueue(TreeManHelmetFight);
                        break;
                    case PlayerEquipConfig.EquipType.Shoe:
                        GameObject TreeManShoeFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManShoeFight"));
                        TreeManShoeFight.gameObject.SetActive(false);
                        GameController.S.TreeManShoeQueue.Enqueue(TreeManShoeFight);
                        break;
                    case PlayerEquipConfig.EquipType.Ring:
                        GameObject TreeManRingFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/TreeMan/TreeManRingFight"));
                        TreeManRingFight.gameObject.SetActive(false);
                        GameController.S.TreeManRingQueue.Enqueue(TreeManRingFight);
                        break;
                }
                break;
            
            
            
            
            
            case PlayerEquipConfig.EquipLevel.HuoShan:
                switch (info.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                    GameObject HuoShanBossCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanCloakFight"));
                    HuoShanBossCloakFight.gameObject.SetActive(false);
                    GameController.S.HuoShanCloakQueue.Enqueue(HuoShanBossCloakFight);
                    break;
                    case PlayerEquipConfig.EquipType.Necklace:
                        GameObject HuoShanBossNecklaceFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanNecklaceFight"));
                        HuoShanBossNecklaceFight.gameObject.SetActive(false);
                        GameController.S.HuoShanNecklaceQueue.Enqueue(HuoShanBossNecklaceFight);
                        break;
                    case PlayerEquipConfig.EquipType.Cloth:
                        GameObject HuoShanBossClothFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanClothFight"));
                        HuoShanBossClothFight.gameObject.SetActive(false);
                        GameController.S.HuoShanClothQueue.Enqueue(HuoShanBossClothFight);
                        break;
                    case PlayerEquipConfig.EquipType.Helmet:
                        GameObject HuoShanBossHelmetFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanHelmetFight"));
                        HuoShanBossHelmetFight.gameObject.SetActive(false);
                        GameController.S.HuoShanHelmetQueue.Enqueue(HuoShanBossHelmetFight);
                        break;
                    case PlayerEquipConfig.EquipType.Shoe:
                        GameObject HuoShanBossShoeFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanShoeFight"));
                        HuoShanBossShoeFight.gameObject.SetActive(false);
                        GameController.S.HuoShanShoeQueue.Enqueue(HuoShanBossShoeFight);
                        break;
                    case PlayerEquipConfig.EquipType.Ring:
                        GameObject HuoShanBossRingFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/HuoShan/HuoShanRingFight"));
                        HuoShanBossRingFight.gameObject.SetActive(false);
                        GameController.S.HuoShanRingQueue.Enqueue(HuoShanBossRingFight);
                        break;
                }
                break;
            
            
            
            
            
            case PlayerEquipConfig.EquipLevel.ZhaoZe:
                switch (info.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                    GameObject ZhaoZeCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeCloakFight"));
                    ZhaoZeCloakFight.gameObject.SetActive(false);
                    GameController.S.ZhaoZeCloakQueue.Enqueue(ZhaoZeCloakFight);
                    break;
                    case PlayerEquipConfig.EquipType.Necklace:
                        GameObject ZhaoZeNecklaceFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeNecklaceFight"));
                        ZhaoZeNecklaceFight.gameObject.SetActive(false);
                        GameController.S.ZhaoZeNecklaceQueue.Enqueue(ZhaoZeNecklaceFight);
                        break;
                    case PlayerEquipConfig.EquipType.Cloth:
                        GameObject ZhaoZeClothFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeClothFight"));
                        ZhaoZeClothFight.gameObject.SetActive(false);
                        GameController.S.ZhaoZeClothQueue.Enqueue(ZhaoZeClothFight);
                        break;
                    case PlayerEquipConfig.EquipType.Helmet:
                        GameObject ZhaoZeHelmetFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeHelmetFight"));
                        ZhaoZeHelmetFight.gameObject.SetActive(false);
                        GameController.S.ZhaoZeHelmetQueue.Enqueue(ZhaoZeHelmetFight);
                        break;
                    case PlayerEquipConfig.EquipType.Shoe:
                        GameObject ZhaoZeShoeFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeShoeFight"));
                        ZhaoZeShoeFight.gameObject.SetActive(false);
                        GameController.S.ZhaoZeShoeQueue.Enqueue(ZhaoZeShoeFight);
                        break;
                    case PlayerEquipConfig.EquipType.Ring:
                        GameObject ZhaoZeRingFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ZhaoZe/ZhaoZeRingFight"));
                        ZhaoZeRingFight.gameObject.SetActive(false);
                        GameController.S.ZhaoZeRingQueue.Enqueue(ZhaoZeRingFight);
                        break;
                }
                break;
            
            
            
             case PlayerEquipConfig.EquipLevel.XieZi:
                switch (info.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                    GameObject XieZiCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XieZi/XieZiCloakFight"));
                    XieZiCloakFight.gameObject.SetActive(false);
                    GameController.S.XieZiCloakQueue.Enqueue(XieZiCloakFight);
                    break;
                    case PlayerEquipConfig.EquipType.Necklace:
                        GameObject XieZiNecklaceFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XieZi/XieZiNecklaceFight"));
                        XieZiNecklaceFight.gameObject.SetActive(false);
                        GameController.S.XieZiNecklaceQueue.Enqueue(XieZiNecklaceFight);
                        break;
                    case PlayerEquipConfig.EquipType.Cloth:
                        GameObject XieZiClothFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XieZi/XieZiClothFight"));
                        XieZiClothFight.gameObject.SetActive(false);
                        GameController.S.XieZiClothQueue.Enqueue(XieZiClothFight);
                        break;
                    case PlayerEquipConfig.EquipType.Helmet:
                        GameObject XieZiHelmetFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XieZi/XieZiHelmetFight"));
                        XieZiHelmetFight.gameObject.SetActive(false);
                        GameController.S.XieZiHelmetQueue.Enqueue(XieZiHelmetFight);
                        break;
                    case PlayerEquipConfig.EquipType.Shoe:
                        GameObject XieZiShoeFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XieZi/XieZiShoeFight"));
                        XieZiShoeFight.gameObject.SetActive(false);
                        GameController.S.XieZiShoeQueue.Enqueue(XieZiShoeFight);
                        break;
                    case PlayerEquipConfig.EquipType.Ring:
                        GameObject XieZiRingFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XieZi/XieZiRingFight"));
                        XieZiRingFight.gameObject.SetActive(false);
                        GameController.S.XieZiRingQueue.Enqueue(XieZiRingFight);
                        break;
                }
                break;
             
             
              case PlayerEquipConfig.EquipLevel.XueRen:
                switch (info.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                    GameObject XueRenCloakFight =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XueRen/XueRenCloakFight"));
                    XueRenCloakFight.gameObject.SetActive(false);
                    GameController.S.XueRenCloakQueue.Enqueue(XueRenCloakFight);
                    break;
                    case PlayerEquipConfig.EquipType.Necklace:
                        GameObject XueRenNecklaceFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XueRen/XueRenNecklaceFight"));
                        XueRenNecklaceFight.gameObject.SetActive(false);
                        GameController.S.XueRenNecklaceQueue.Enqueue(XueRenNecklaceFight);
                        break;
                    case PlayerEquipConfig.EquipType.Cloth:
                        GameObject XueRenClothFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XueRen/XueRenClothFight"));
                        XueRenClothFight.gameObject.SetActive(false);
                        GameController.S.XueRenClothQueue.Enqueue(XueRenClothFight);
                        break;
                    case PlayerEquipConfig.EquipType.Helmet:
                        GameObject XueRenHelmetFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XueRen/XueRenHelmetFight"));
                        XueRenHelmetFight.gameObject.SetActive(false);
                        GameController.S.XueRenHelmetQueue.Enqueue(XueRenHelmetFight);
                        break;
                    case PlayerEquipConfig.EquipType.Shoe:
                        GameObject XueRenShoeFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XueRen/XueRenShoeFight"));
                        XueRenShoeFight.gameObject.SetActive(false);
                        GameController.S.XueRenShoeQueue.Enqueue(XueRenShoeFight);
                        break;
                    case PlayerEquipConfig.EquipType.Ring:
                        GameObject XueRenRingFight =
                            Instantiate(Resources.Load<GameObject>("Prefabs/Equip/XueRen/XueRenRingFight"));
                        XueRenRingFight.gameObject.SetActive(false);
                        GameController.S.XueRenRingQueue.Enqueue(XueRenRingFight);
                        break;
                }
                break;
            
        }
    }

    private void Awake()
    {
        GameController.S.MonsterList = GameController.S.SelectTwoUniqueNumbers();
        GameController.S.MonsterColliderDic.Clear();
        Application.targetFrameRate = 30;
        GlobalPlayerAttribute.CurrentHp = GlobalPlayerAttribute.TotalMaxHp;
        LevelInfoConfig.IsOneGame = false;

        AudioController.S.BGAudioSource.clip = Resources.Load<AudioClip>("Audio/BG/Level1BG");
        AudioController.S.BGAudioSource.Play();

        GameController.S.GameMaxHp = GlobalPlayerAttribute.TotalMaxHp;
        GameController.S.GameCurrentHp = GlobalPlayerAttribute.TotalMaxHp;
        //GameController.S.GameDefense = GlobalPlayerAttribute.TotalDefense;
        //GameController.S.GameAttack = GlobalPlayerAttribute.TotalDamage;
        GameController.S.GameCrit = GlobalPlayerAttribute.TotalCRIT;
        GameController.S.isFuHuo = true;
        GameController.S.TotalAddHp = 0;



        //初始化最大boss能量值
        GameController.S.MaxBossEnergyNum =
            LevelInfoConfig.LevelMonsterCount[LevelInfoConfig.CurrentGameLevel] *
            2; //这时小怪数量，精英不算数量，每10只普通怪出一只精英，所以正好是2倍
        GameController.S.MaxBossEnergyNum = 10;

        if (SkillJiaDian.S.Alpha1 == SkillType.Ice3 || SkillJiaDian.S.Alpha2 == SkillType.Ice3 ||
            SkillJiaDian.S.Alpha3 == SkillType.Ice3 || SkillJiaDian.S.Alpha4 == SkillType.Ice3 || SkillJiaDian.S.Alpha5 == SkillType.Ice3)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/IceExplosion").GetComponent<IceExplosion>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.IceExQueue.Enqueue(Monster1);
            }
        }

        if (SkillJiaDian.S.Alpha1 == SkillType.Huo1 || SkillJiaDian.S.Alpha2 == SkillType.Huo1 ||
            SkillJiaDian.S.Alpha3 == SkillType.Huo1|| SkillJiaDian.S.Alpha4 == SkillType.Huo1|| SkillJiaDian.S.Alpha5 == SkillType.Huo1)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HuoSkill/HuoSkill1").GetComponent<HuoSkill1>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HuoSkill1Queue.Enqueue(Monster1);
            }
        }

        if (SkillJiaDian.S.Alpha1 == SkillType.Dian2 || SkillJiaDian.S.Alpha2 == SkillType.Dian2 ||
            SkillJiaDian.S.Alpha3 == SkillType.Dian2|| SkillJiaDian.S.Alpha4 == SkillType.Dian2|| SkillJiaDian.S.Alpha5 == SkillType.Dian2)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/DianSkill/DianSkill2").GetComponent<DianSkill2>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.DianSkill2Queue.Enqueue(Monster1);
            }
        }

        if (SkillJiaDian.S.Alpha1 == SkillType.HeiAn3 || SkillJiaDian.S.Alpha2 == SkillType.HeiAn3 ||
            SkillJiaDian.S.Alpha3 == SkillType.HeiAn3|| SkillJiaDian.S.Alpha4 == SkillType.HeiAn3|| SkillJiaDian.S.Alpha5 == SkillType.HeiAn3)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HeiAnSkill/HeiAnSkill3")
                            .GetComponent<HeiAnSkill3>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HeiAnSkill3Queue.Enqueue(Monster1);
            }
        }

        if (SkillJiaDian.S.Alpha1 == SkillType.HeiAn1 || SkillJiaDian.S.Alpha2 == SkillType.HeiAn1 ||
            SkillJiaDian.S.Alpha3 == SkillType.HeiAn1|| SkillJiaDian.S.Alpha4 == SkillType.HeiAn1|| SkillJiaDian.S.Alpha5 == SkillType.HeiAn1)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HeiAnSkill/HeiAnSkill1")
                            .GetComponent<HeiAnSkill1>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HeiAnSkill1Queue.Enqueue(Monster1);
            }
        }

        if (SkillJiaDian.S.Alpha1 == SkillType.Dian3 || SkillJiaDian.S.Alpha2 == SkillType.Dian3 ||
            SkillJiaDian.S.Alpha3 == SkillType.Dian3|| SkillJiaDian.S.Alpha4 == SkillType.Dian3|| SkillJiaDian.S.Alpha5 == SkillType.Dian3)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/DianSkill/DianSkill3").GetComponent<DianSkill3>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.DianSkill3Queue.Enqueue(Monster1);
            }
        }

        if (SkillJiaDian.S.Alpha1 == SkillType.Huo3 || SkillJiaDian.S.Alpha2 == SkillType.Huo3 ||
            SkillJiaDian.S.Alpha3 == SkillType.Huo3|| SkillJiaDian.S.Alpha4 == SkillType.Huo3|| SkillJiaDian.S.Alpha5 == SkillType.Huo3)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HuoSkill/HuoSkill3").GetComponent<HuoSkill3>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HuoSkill3Queue.Enqueue(Monster1);
            }
        }

        if (SkillJiaDian.S.Alpha1 == SkillType.Ice1 || SkillJiaDian.S.Alpha2 == SkillType.Ice1 ||
            SkillJiaDian.S.Alpha3 == SkillType.Ice1|| SkillJiaDian.S.Alpha4 == SkillType.Ice1|| SkillJiaDian.S.Alpha5 == SkillType.Ice1)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/IceSkill/IceSkill1").GetComponent<IceSkill1>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.IceSkill1Queue.Enqueue(Monster1);
            }
        }
        
        if (SkillJiaDian.S.Alpha1 != SkillType.Ice4 || SkillJiaDian.S.Alpha2 == SkillType.Ice4 ||
            SkillJiaDian.S.Alpha3 == SkillType.Ice4|| SkillJiaDian.S.Alpha4 == SkillType.Ice4|| SkillJiaDian.S.Alpha5 == SkillType.Ice4)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/IceSkill/IceSkill4").GetComponent<IceSkill4>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.IceSkill4Queue.Enqueue(Monster1);
            }
        }
        
        
        if (SkillJiaDian.S.Alpha1 != SkillType.Ice5 || SkillJiaDian.S.Alpha2 == SkillType.Ice5 ||
            SkillJiaDian.S.Alpha3 == SkillType.Ice5|| SkillJiaDian.S.Alpha4 == SkillType.Ice5|| SkillJiaDian.S.Alpha5 == SkillType.Ice5)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/IceSkill/IceSkill5").GetComponent<IceSkill5>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.IceSkill5Queue.Enqueue(Monster1);
            }
        }
        
        
        
        if (SkillJiaDian.S.Alpha1 != SkillType.Huo4 || SkillJiaDian.S.Alpha2 == SkillType.Huo4 ||
            SkillJiaDian.S.Alpha3 == SkillType.Huo4|| SkillJiaDian.S.Alpha4 == SkillType.Huo4|| SkillJiaDian.S.Alpha5 == SkillType.Huo4)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HuoSkill/HuoSkill4").GetComponent<HuoSkill4>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HuoSkill4Queue.Enqueue(Monster1);
            }
        }
        
        
        
        if (SkillJiaDian.S.Alpha1 != SkillType.Huo5 || SkillJiaDian.S.Alpha2 == SkillType.Huo5 ||
            SkillJiaDian.S.Alpha3 == SkillType.Huo5|| SkillJiaDian.S.Alpha4 == SkillType.Huo5|| SkillJiaDian.S.Alpha5 == SkillType.Huo5)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HuoSkill/HuoSkill5").GetComponent<HuoSkill5>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HuoSkill5Queue.Enqueue(Monster1);
            }
        }
        
        
        
        if (SkillJiaDian.S.Alpha1 != SkillType.Dian4 || SkillJiaDian.S.Alpha2 == SkillType.Dian4 ||
            SkillJiaDian.S.Alpha3 == SkillType.Dian4|| SkillJiaDian.S.Alpha4 == SkillType.Dian4|| SkillJiaDian.S.Alpha5 == SkillType.Dian4)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/DianSkill/DianSkill4").GetComponent<DianSkill4>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.DianSkill4Queue.Enqueue(Monster1);
            }
        }
        
        
        
        if (SkillJiaDian.S.Alpha1 != SkillType.Dian5 || SkillJiaDian.S.Alpha2 == SkillType.Dian5 ||
            SkillJiaDian.S.Alpha3 == SkillType.Dian5|| SkillJiaDian.S.Alpha4 == SkillType.Dian5|| SkillJiaDian.S.Alpha5 == SkillType.Dian5)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/DianSkill/DianSkill5").GetComponent<DianSkill5>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.DianSkill5Queue.Enqueue(Monster1);
            }
        }
        
        
        
        if (SkillJiaDian.S.Alpha1 != SkillType.HeiAn4 || SkillJiaDian.S.Alpha2 == SkillType.HeiAn4 ||
            SkillJiaDian.S.Alpha3 == SkillType.HeiAn4|| SkillJiaDian.S.Alpha4 == SkillType.HeiAn4|| SkillJiaDian.S.Alpha5 == SkillType.HeiAn4)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HeiAnSkill/HeiAnSkill4").GetComponent<HeiAnSkill4>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HeiAnSkill4Queue.Enqueue(Monster1);
            }
        }
        
        
        
        if (SkillJiaDian.S.Alpha1 != SkillType.HeiAn5 || SkillJiaDian.S.Alpha2 == SkillType.HeiAn5 ||
            SkillJiaDian.S.Alpha3 == SkillType.HeiAn5|| SkillJiaDian.S.Alpha4 == SkillType.HeiAn5|| SkillJiaDian.S.Alpha5 == SkillType.HeiAn5)
        {
            for (int i = 0; i < 30; i++)
            {
                var Monster1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/HeiAnSkill/HeiAnSkill5").GetComponent<HeiAnSkill5>(),
                        GameController.S.transform);
                Monster1.gameObject.SetActive(false);
                GameController.S.HeiAnSkill5Queue.Enqueue(Monster1);
            }
        }


        if (LevelInfoConfig.CurrentGameLevel > 15)
        {

            if (LevelInfoConfig.CurrentGameLevel == 16)
            {
                for (int i = 0; i < 30; i++)
                {
                    var Monster1 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LeiShou/LeiShouSkill3")
                                .GetComponent<LeiShouSkill3>(),
                            GameController.S.transform);
                    Monster1.gameObject.SetActive(false);
                    GameController.S.LeiShouSkill3Queue.Enqueue(Monster1.GetComponent<LeiShouSkill3>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel ==17)
            {
                for (int i = 0; i < 30; i++)
                {
                    var Monster2 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/KuiJia/HeiXuanFen")
                                .GetComponent<HeiXuanFen>(),
                            GameController.S.transform);
                    Monster2.gameObject.SetActive(false);
                    GameController.S.HeiXuanFenQueue.Enqueue(Monster2.GetComponent<HeiXuanFen>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 18)
            {
                for (int i = 0; i < 30; i++)
                {
                    var Monster3 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/BaoZi/LvZhuiZong")
                                .GetComponent<LvZhuiZong>(),
                            GameController.S.transform);
                    Monster3.gameObject.SetActive(false);
                    GameController.S.LvZhuiZongQueue.Enqueue(Monster3.GetComponent<LvZhuiZong>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel ==18)
            {
                for (int i = 0; i < 30; i++)
                {
                    var Monster4 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/BaoZi/LvXuanFen")
                                .GetComponent<LvXuanFen>(),
                            GameController.S.transform);
                    Monster4.gameObject.SetActive(false);
                    GameController.S.LvXuanFenQueue.Enqueue(Monster4.GetComponent<LvXuanFen>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 18)
            {
                for (int i = 0; i < 30; i++)
                {

                    var Monster5 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/BaoZi/BaoZiSkill2")
                                .GetComponent<BaoZiSkill2>(),
                            GameController.S.transform);
                    Monster5.gameObject.SetActive(false);
                    GameController.S.BaoZiSkill2Queue.Enqueue(Monster5.GetComponent<BaoZiSkill2>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel ==19)
            {
                for (int i = 0; i < 30; i++)
                {

                    var Monster6 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/HuoLang/HuoLangSkill2")
                                .GetComponent<HuoLangSkill2>(),
                            GameController.S.transform);
                    Monster6.gameObject.SetActive(false);
                    GameController.S.HuoLangSkill2Queue.Enqueue(Monster6.GetComponent<HuoLangSkill2>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 20)
            {
                for (int i = 0; i < 30; i++)
                {

                    var Monster7 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/ShuangDao/ShuangDaoSkill2")
                                .GetComponent<ShuangDaoSkill2>(),
                            GameController.S.transform);
                    Monster7.gameObject.SetActive(false);
                    GameController.S.ShuangDaoSkill2Queue.Enqueue(Monster7.GetComponent<ShuangDaoSkill2>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel ==20)
            {
                for (int i = 0; i < 30; i++)
                {
                    var Monster8 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/ShuangDao/ShuangDaoSkill3")
                                .GetComponent<ShuangDaoSkill3>(),
                            GameController.S.transform);
                    Monster8.gameObject.SetActive(false);
                    GameController.S.ShuangDaoSkill3Queue.Enqueue(Monster8.GetComponent<ShuangDaoSkill3>());
                }
            }

        }


        //秘境怪物
       // if (LevelInfoConfig.CurrentGameLevel > 15)
        {

            //if (LevelInfoConfig.CurrentGameLevel == 18)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster1 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/DaLong").GetComponent<DaLong>(),
                            GameController.S.transform);
                    Monster1.gameObject.SetActive(false);
                    GameController.S.DaLongQueue.Enqueue(Monster1.GetComponent<DaLong>());
                    Collider2D collider2D = Monster1.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D, Monster1.GetComponent<MonsterBase>());
                }
            }
            


            if (LevelInfoConfig.CurrentGameLevel == 16)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster2 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/EMo1").GetComponent<EMo1>(),
                            GameController.S.transform);
                    Monster2.gameObject.SetActive(false);
                    GameController.S.EMo1Queue.Enqueue(Monster2.GetComponent<EMo1>());
                    Collider2D collider2D2 =
                        Monster2.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D2,
                        Monster2.GetComponent<MonsterBase>());
                }
            }
            


            if (LevelInfoConfig.CurrentGameLevel == 19)
            {
                for (int i = 0; i < 150; i++)
                {

                    var Monster3 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/EMo2").GetComponent<EMo2>(),
                            GameController.S.transform);
                    Monster3.gameObject.SetActive(false);
                    GameController.S.EMo2Queue.Enqueue(Monster3.GetComponent<EMo2>());
                    Collider2D collider2D3 =
                        Monster3.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D3,
                        Monster3.GetComponent<MonsterBase>());
                }
            }
            


            if (LevelInfoConfig.CurrentGameLevel == 22)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster4 =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Monster/MJ/EMo3").GetComponent<EMo3>(),
                            GameController.S.transform);
                    Monster4.gameObject.SetActive(false);
                    GameController.S.EMo3Queue.Enqueue(Monster4.GetComponent<EMo3>());
                    Collider2D collider2D4 = Monster4.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D4, Monster4.GetComponent<MonsterBase>());
                }
            }
            


            if (LevelInfoConfig.CurrentGameLevel == 16)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster5 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/HongLong1")
                                .GetComponent<HongLong1>(), GameController.S.transform);
                    Monster5.gameObject.SetActive(false);
                    GameController.S.HongLong1Queue.Enqueue(Monster5.GetComponent<HongLong1>());
                    Collider2D collider2D5 =
                        Monster5.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D5,
                        Monster5.GetComponent<MonsterBase>());
                }
            }
            


            if (LevelInfoConfig.CurrentGameLevel == 19)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster6 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/HongLong2")
                                .GetComponent<HongLong2>(), GameController.S.transform);
                    Monster6.gameObject.SetActive(false);
                    GameController.S.HongLong2Queue.Enqueue(Monster6.GetComponent<HongLong2>());
                    Collider2D collider2D6 =
                        Monster6.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D6,
                        Monster6.GetComponent<MonsterBase>());
                }
            }
            


            if (LevelInfoConfig.CurrentGameLevel == 22)
            {
                for (int i = 0; i < 150; i++)
                {

                    var Monster7 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/HongLong3")
                                .GetComponent<HongLong3>(), GameController.S.transform);
                    Monster7.gameObject.SetActive(false);
                    GameController.S.HongLong3Queue.Enqueue(Monster7.GetComponent<HongLong3>());
                    Collider2D collider2D7 = Monster7.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D7, Monster7.GetComponent<MonsterBase>());
                }
            }

            


            if (LevelInfoConfig.CurrentGameLevel == 17)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster8 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LanLong1")
                                .GetComponent<LanLong1>(),
                            GameController.S.transform);
                    Monster8.gameObject.SetActive(false);
                    GameController.S.LanLong1Queue.Enqueue(Monster8.GetComponent<LanLong1>());
                    Collider2D collider2D8 =
                        Monster8.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D8,
                        Monster8.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 20)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster9 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LanLong2")
                                .GetComponent<LanLong2>(),
                            GameController.S.transform);
                    Monster9.gameObject.SetActive(false);
                    GameController.S.LanLong2Queue.Enqueue(Monster9.GetComponent<LanLong2>());
                    Collider2D collider2D9 =
                        Monster9.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D9,
                        Monster9.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 23)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster10 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LanLong3").GetComponent<LanLong3>(),
                            GameController.S.transform);
                    Monster10.gameObject.SetActive(false);
                    GameController.S.LanLong3Queue.Enqueue(Monster10.GetComponent<LanLong3>());
                    Collider2D collider2D10 = Monster10.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D10, Monster10.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 18)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster11 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LvLang")
                                .GetComponent<LvLang>(),
                            GameController.S.transform);
                    Monster11.gameObject.SetActive(false);
                    GameController.S.LvLangQueue.Enqueue(Monster11.GetComponent<LvLang>());
                    Collider2D collider2D11 =
                        Monster11.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D11,
                        Monster11.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 17)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster12 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LvLong1")
                                .GetComponent<LvLong1>(),
                            GameController.S.transform);
                    Monster12.gameObject.SetActive(false);
                    GameController.S.LvLong1Queue.Enqueue(Monster12.GetComponent<LvLong1>());
                    Collider2D collider2D12 =
                        Monster12.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D12,
                        Monster12.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 20)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster13 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LvLong2")
                                .GetComponent<LvLong2>(),
                            GameController.S.transform);
                    Monster13.gameObject.SetActive(false);
                    GameController.S.LvLong2Queue.Enqueue(Monster13.GetComponent<LvLong2>());
                    Collider2D collider2D13 =
                        Monster13.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D13,
                        Monster13.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 21)
            {
                for (int i = 0; i < 150; i++)
                {
                    var huangshu =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level4/HuangShuMonster")
                                .GetComponent<HuangShu>(),
                            GameController.S.transform);
                    huangshu.gameObject.SetActive(false);
                    GameController.S.HuangShuQueue.Enqueue(huangshu.GetComponent<HuangShu>());

                    Collider2D Huangshucollider2D = huangshu.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(Huangshucollider2D,
                        huangshu.GetComponent<MonsterBase>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 21)
            {
                for (int i = 0; i < 150; i++)
                {

                    var Huangzhu =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level4/HuangZhuMonster")
                                .GetComponent<Huangzhu>(),
                            GameController.S.transform);
                    Huangzhu.gameObject.SetActive(false);
                    GameController.S.HuangZhuQueue.Enqueue(Huangzhu.GetComponent<Huangzhu>());
                    Collider2D Huangzhucollider2D = Huangzhu.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(Huangzhucollider2D, Huangzhu.GetComponent<MonsterBase>());
                }
            }



            if (LevelInfoConfig.CurrentGameLevel == 23)
            {
                for (int i = 0; i < 150; i++)
                {
                    var Monster14 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/MJ/LvLong3").GetComponent<LvLong3>(),
                            GameController.S.transform);
                    Monster14.gameObject.SetActive(false);
                    GameController.S.LvLong3Queue.Enqueue(Monster14.GetComponent<LvLong3>());
                    Collider2D collider2D14 = Monster14.GetComponent<MonsterBase>().collider2D;
                    GameController.S.MonsterColliderDic.Add(collider2D14, Monster14.GetComponent<MonsterBase>());
                }
            }
            
            


        }

        //实例化
        //FightBGController


        //Boss攻击对象池
        for (int i = 0; i < 100; i++)
        {
            PlayerHurt playerHurt = Instantiate(Resources.Load<PlayerHurt>("Prefabs/Player/PlayerHurt"));
            playerHurt.gameObject.SetActive(false);
            GameController.S.PlayerHurtQueue.Enqueue(playerHurt);

            CircleAttack circle = Instantiate(Resources.Load<CircleAttack>("Prefabs/Tool/CircleAttack"));
            circle.gameObject.SetActive(false);
            GameController.S.CircleQueue.Enqueue(circle);

            SqrtAttack sqrt = Instantiate(Resources.Load<SqrtAttack>("Prefabs/Tool/SqrtAttack"));
            sqrt.gameObject.SetActive(false);
            GameController.S.SqrtQueue.Enqueue(sqrt);

            BaoShi BaoShi = Instantiate(Resources.Load<GameObject>("Prefabs/Prop/BaoShi")).GetComponent<BaoShi>();
            BaoShi.gameObject.SetActive(false);
            GameController.S.BaoShiQueue.Enqueue(BaoShi);
        }

        //初始化装备和道具队列
       LevelInfoConfig.InitEquipQueue();
       LevelInfoConfig.InitPropQueue();
       
            for (int i = 0; i < 200; i++)
            {
                GameObject monsterHurtText = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/MonsterHurtText"));
                monsterHurtText.gameObject.SetActive(false);
                GameController.S.MonsterHurtTextQueue.Enqueue(monsterHurtText.GetComponent<MonsterHurtText>());
            }

            if (SkillJiaDian.S.Alpha1 == SkillType.Dian1 || SkillJiaDian.S.Alpha2 == SkillType.Dian1 ||
                SkillJiaDian.S.Alpha3 == SkillType.Dian1|| SkillJiaDian.S.Alpha4 == SkillType.Dian1|| SkillJiaDian.S.Alpha5 == SkillType.Dian1)
            {
                for (int i = 0; i < 10; i++)
                {
                    GameObject dianQuanPeng =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Skill/DianQuan/DianPeng"));
                    dianQuanPeng.gameObject.SetActive(false);
                    GameController.S.DianQuanPengQueue.Enqueue(dianQuanPeng);

                    var dianqian = Instantiate(Resources.Load("Prefabs/Skill/DianQuan/DianQuan"), new Vector3(0, 0, 0),
                        Quaternion.identity) as GameObject;
                    dianqian.SetActive(false);
                    GameController.S.DianQuanQueue.Enqueue(dianqian);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                var circleAttack = Instantiate(Resources.Load("Prefabs/Tool/CircleAttack"), new Vector3(0, 0, 0),
                    Quaternion.identity) as GameObject;
                circleAttack.SetActive(false);
                FightBGController.S.CircleAttackQueue.Enqueue(circleAttack.GetComponent<CircleAttack>());
                var fire = Instantiate(Resources.Load("Prefabs/Skill/TreeManFire"), new Vector3(0, 0, 0),
                    Quaternion.identity) as GameObject;
                fire.SetActive(false);
                FightBGController.S.TreeManFireQueue.Enqueue(fire.GetComponent<TreeManFire>());
                var sqrtattack = Instantiate(Resources.Load("Prefabs/Tool/SqrtAttack"), new Vector3(0, 0, 0),
                    Quaternion.identity) as GameObject;
                sqrtattack.SetActive(false);
                FightBGController.S.SqrtAttackQueue.Enqueue(sqrtattack.GetComponent<SqrtAttack>());
                var playerhit = Instantiate(Resources.Load("Prefabs/Player/PlayerHit"), new Vector3(0, 0, 0),
                    Quaternion.identity) as GameObject;
                playerhit.SetActive(false);
                FightBGController.S.PlayerHitQueue.Enqueue(playerhit.GetComponent<PlayerHit>());
            }




            //初始化技能队列

            for (int i = 0; i < 100; i++)
            {
                switch (PlayerData.S.playerWeaponType)
                {
                    case WeaponType.Primary:
                        var PuTong31 = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/Primary"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        PuTong31.SetActive(false);
                        GameController.S.PrimaryQueue.Enqueue(PuTong31);

                        var PuTong3Peng1 = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/PuTongPeng3"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        PuTong3Peng1.SetActive(false);
                        GameController.S.PuTong3PengQueue.Enqueue(PuTong3Peng1);
                        break;
                    case WeaponType.LanBao:
                        var twoNormalAttack = Instantiate(Resources.Load("Prefabs/Skill/2NormalAttackPrefab"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        twoNormalAttack.SetActive(false);
                        GameController.S.LvQuanQueue.Enqueue(twoNormalAttack);
                        break;

                    case WeaponType.HeiDong:
                        var HeiDong = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/HeiDongPro"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        HeiDong.SetActive(false);
                        GameController.S.HeiDongQueue.Enqueue(HeiDong);

                        var HeiDongNext = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/HeiDongNext"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        HeiDongNext.SetActive(false);
                        GameController.S.HeiDongNextQueue.Enqueue(HeiDongNext);

                        var HeiDongPeng = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/HeiDongPeng"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        HeiDongPeng.SetActive(false);
                        GameController.S.HeiDongPengQueue.Enqueue(HeiDongPeng);
                        break;

                    case WeaponType.HuoBaoZha:
                        var Du = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/HuoBaoZha")).GetComponent<HuoBaoZha>();
                        Du.gameObject.SetActive(false);
                        GameController.S.HuoBaoZhaQueue.Enqueue(Du);

                        var DuPeng = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/HuoBaoZhaNext")).GetComponent<HuoYanBaoZhaNext>();
                        DuPeng.gameObject.SetActive(false);
                        GameController.S.HuoYanBaoZhaNextQueue.Enqueue(DuPeng);
                        break;
                    
                    
                    case WeaponType.IceBaoZha:
                        var Du1 = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/IceBaoZha")).GetComponent<IceBaoZha>();
                        Du1.gameObject.SetActive(false);
                        GameController.S.IceBaoZhaQueue.Enqueue(Du1);

                        var DuPeng1 = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/IceBaoZhaNext")).GetComponent<IceBaoZhaNext>();
                        DuPeng1.gameObject.SetActive(false);
                        GameController.S.IceBaoZhaNextQueue.Enqueue(DuPeng1);
                        break;
                    
                    case WeaponType.DianBaoZha:
                        var Du2 = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/DianBaoZha")).GetComponent<DianBaoZha>();
                        Du2.gameObject.SetActive(false);
                        GameController.S.DianBaoZhaQueue.Enqueue(Du2);

                        var DuPeng2 = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/DianBaoZhaNext")).GetComponent<DianBaoZhaNext>();
                        DuPeng2.gameObject.SetActive(false);
                        GameController.S.DianBaoZhaNextQueue.Enqueue(DuPeng2);
                        break;

                    case WeaponType.LuoLei:
                        var LuoLei = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/LuoLei"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        LuoLei.SetActive(false);
                        GameController.S.LuoLeiQueue.Enqueue(LuoLei);
                        break;

                    case WeaponType.PuTong3:
                        var PuTong3 = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/PuTong3"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        PuTong3.SetActive(false);
                        GameController.S.PuTong3Queue.Enqueue(PuTong3);

                        var PuTong3Peng = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/PuTongPeng3"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        PuTong3Peng.SetActive(false);
                        GameController.S.PuTong3PengQueue.Enqueue(PuTong3Peng);
                        break;

                    case WeaponType.Fire:
                        var FireAttack = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/Fire"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        FireAttack.SetActive(false);
                        GameController.S.FireQueue.Enqueue(FireAttack);

                        var FirePengAttack = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/FirePeng"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        FirePengAttack.SetActive(false);
                        GameController.S.FirePengQueue.Enqueue(FirePengAttack);

                        var FireBaoZha = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/FireBaoZha"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        FireBaoZha.SetActive(false);
                        GameController.S.FireBaoZha1Queue.Enqueue(FireBaoZha);
                        break;

                    case WeaponType.XuKong:
                        var XuKongAttack = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/XuKong"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        XuKongAttack.SetActive(false);
                        GameController.S.XuKongQueue.Enqueue(XuKongAttack);

                        var XuKongPengAttack = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/XuKongPeng"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        XuKongPengAttack.SetActive(false);
                        GameController.S.XuKongPengQueue.Enqueue(XuKongPengAttack);
                        break;

                    case WeaponType.LvQuan:
                        var lvNormalAttack = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/LvQuan"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        lvNormalAttack.SetActive(false);
                        GameController.S.LvQuanQueue.Enqueue(lvNormalAttack);
                        break;

                    case WeaponType.JianQi:
                        var JianQi =
                            Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/PlayerJianQi"), new Vector3(0, 0, 0),
                                Quaternion.identity).GetComponent<PlayerJianQi>();
                        JianQi.gameObject.SetActive(false);
                        GameController.S.PlayerJianQiQueue.Enqueue(JianQi);

                        var zibaozha = Instantiate(Resources.Load("Prefabs/Skill/NormalAttack/ZiPeng"),
                            new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        zibaozha.SetActive(false);
                        GameController.S.ZiBaoZhaQueue.Enqueue(zibaozha);
                        break;

                }
            }

            if (WeaponConfig.WeaponYuanSuTypeDic[PlayerData.S.playerWeaponType] == YuanSuType.Ice ||
                SkillJiaDian.S.Alpha1 == SkillType.Ice1 || SkillJiaDian.S.Alpha1 == SkillType.Ice2 ||
                SkillJiaDian.S.Alpha1 == SkillType.Ice3 || SkillJiaDian.S.Alpha1 == SkillType.Ice4 ||
                SkillJiaDian.S.Alpha1 == SkillType.Ice5
                || SkillJiaDian.S.Alpha2 == SkillType.Ice1 || SkillJiaDian.S.Alpha2 == SkillType.Ice2 ||
                SkillJiaDian.S.Alpha2 == SkillType.Ice3 || SkillJiaDian.S.Alpha2 == SkillType.Ice4 ||
                SkillJiaDian.S.Alpha2 == SkillType.Ice5
                || SkillJiaDian.S.Alpha3 == SkillType.Ice1 || SkillJiaDian.S.Alpha3 == SkillType.Ice2 ||
                SkillJiaDian.S.Alpha3 == SkillType.Ice3 || SkillJiaDian.S.Alpha3 == SkillType.Ice4 ||
                SkillJiaDian.S.Alpha3 == SkillType.Ice5
                || SkillJiaDian.S.Alpha4 == SkillType.Ice1 || SkillJiaDian.S.Alpha4 == SkillType.Ice2 ||
                SkillJiaDian.S.Alpha4 == SkillType.Ice3 || SkillJiaDian.S.Alpha4 == SkillType.Ice4 ||
                SkillJiaDian.S.Alpha4 == SkillType.Ice5
                || SkillJiaDian.S.Alpha5 == SkillType.Ice1 || SkillJiaDian.S.Alpha5 == SkillType.Ice2 ||
                SkillJiaDian.S.Alpha5 == SkillType.Ice3 || SkillJiaDian.S.Alpha5 == SkillType.Ice4 ||
                SkillJiaDian.S.Alpha5 == SkillType.Ice5)
            {
                for (int i = 0; i < 200; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/Peng/IcePeng"));
                    IcePeng.SetActive(false);
                    GameController.S.IcePengQueue.Enqueue(IcePeng);
                }
            }
            
            
            
            if (WeaponConfig.WeaponYuanSuTypeDic[PlayerData.S.playerWeaponType] == YuanSuType.HeiAn ||
                SkillJiaDian.S.Alpha1 == SkillType.HeiAn1 || SkillJiaDian.S.Alpha1 == SkillType.HeiAn2 ||
                SkillJiaDian.S.Alpha1 == SkillType.HeiAn3 || SkillJiaDian.S.Alpha1 == SkillType.HeiAn4 ||
                SkillJiaDian.S.Alpha1 == SkillType.HeiAn5
                || SkillJiaDian.S.Alpha2 == SkillType.HeiAn1 || SkillJiaDian.S.Alpha2 == SkillType.HeiAn2 ||
                SkillJiaDian.S.Alpha2 == SkillType.HeiAn3 || SkillJiaDian.S.Alpha2 == SkillType.HeiAn4 ||
                SkillJiaDian.S.Alpha2 == SkillType.HeiAn5
                || SkillJiaDian.S.Alpha3 == SkillType.HeiAn1 || SkillJiaDian.S.Alpha3 == SkillType.HeiAn2 ||
                SkillJiaDian.S.Alpha3 == SkillType.HeiAn3 || SkillJiaDian.S.Alpha3 == SkillType.HeiAn4 ||
                SkillJiaDian.S.Alpha3 == SkillType.HeiAn5
                || SkillJiaDian.S.Alpha4 == SkillType.HeiAn1 || SkillJiaDian.S.Alpha4 == SkillType.HeiAn2 ||
                SkillJiaDian.S.Alpha4 == SkillType.HeiAn3 || SkillJiaDian.S.Alpha4 == SkillType.HeiAn4 ||
                SkillJiaDian.S.Alpha4 == SkillType.HeiAn5
                || SkillJiaDian.S.Alpha5 == SkillType.HeiAn1 || SkillJiaDian.S.Alpha5 == SkillType.HeiAn2 ||
                SkillJiaDian.S.Alpha5 == SkillType.HeiAn3 || SkillJiaDian.S.Alpha5 == SkillType.HeiAn4 ||
                SkillJiaDian.S.Alpha5 == SkillType.HeiAn5)
            {
                for (int i = 0; i < 200; i++)
                {
                    var HeiAnPeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/Peng/HeiAnPeng"));
                    HeiAnPeng.SetActive(false);
                    GameController.S.HeiAnPengQueue.Enqueue(HeiAnPeng);
                }
            }
            
            
            
            if (WeaponConfig.WeaponYuanSuTypeDic[PlayerData.S.playerWeaponType] == YuanSuType.Huo ||
                SkillJiaDian.S.Alpha1 == SkillType.Huo1 || SkillJiaDian.S.Alpha1 == SkillType.Huo2 ||
                SkillJiaDian.S.Alpha1 == SkillType.Huo3 || SkillJiaDian.S.Alpha1 == SkillType.Huo4 ||
                SkillJiaDian.S.Alpha1 == SkillType.Huo5
                || SkillJiaDian.S.Alpha2 == SkillType.Huo1 || SkillJiaDian.S.Alpha2 == SkillType.Huo2 ||
                SkillJiaDian.S.Alpha2 == SkillType.Huo3 || SkillJiaDian.S.Alpha2 == SkillType.Huo4 ||
                SkillJiaDian.S.Alpha2 == SkillType.Huo5
                || SkillJiaDian.S.Alpha3 == SkillType.Huo1 || SkillJiaDian.S.Alpha3 == SkillType.Huo2 ||
                SkillJiaDian.S.Alpha3 == SkillType.Huo3 || SkillJiaDian.S.Alpha3 == SkillType.Huo4 ||
                SkillJiaDian.S.Alpha3 == SkillType.Huo5
                || SkillJiaDian.S.Alpha4 == SkillType.Huo1 || SkillJiaDian.S.Alpha4 == SkillType.Huo2 ||
                SkillJiaDian.S.Alpha4 == SkillType.Huo3 || SkillJiaDian.S.Alpha4 == SkillType.Huo4 ||
                SkillJiaDian.S.Alpha4 == SkillType.Huo5
                || SkillJiaDian.S.Alpha5 == SkillType.Huo1 || SkillJiaDian.S.Alpha5 == SkillType.Huo2 ||
                SkillJiaDian.S.Alpha5 == SkillType.Huo3 || SkillJiaDian.S.Alpha5 == SkillType.Huo4 ||
                SkillJiaDian.S.Alpha5 == SkillType.Huo5)
            {
                for (int i = 0; i < 200; i++)
                {
                    var HuoPeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/Peng/HuoPeng"));
                    HuoPeng.SetActive(false);
                    GameController.S.HuoPengQueue.Enqueue(HuoPeng);
                }
            }
            
            
            if (WeaponConfig.WeaponYuanSuTypeDic[PlayerData.S.playerWeaponType] == YuanSuType.Dian ||
                SkillJiaDian.S.Alpha1 == SkillType.Dian1 || SkillJiaDian.S.Alpha1 == SkillType.Dian2 ||
                SkillJiaDian.S.Alpha1 == SkillType.Dian3 || SkillJiaDian.S.Alpha1 == SkillType.Dian4 ||
                SkillJiaDian.S.Alpha1 == SkillType.Dian5
                || SkillJiaDian.S.Alpha2 == SkillType.Dian1 || SkillJiaDian.S.Alpha2 == SkillType.Dian2 ||
                SkillJiaDian.S.Alpha2 == SkillType.Dian3 || SkillJiaDian.S.Alpha2 == SkillType.Dian4 ||
                SkillJiaDian.S.Alpha2 == SkillType.Dian5
                || SkillJiaDian.S.Alpha3 == SkillType.Dian1 || SkillJiaDian.S.Alpha3 == SkillType.Dian2 ||
                SkillJiaDian.S.Alpha3 == SkillType.Dian3 || SkillJiaDian.S.Alpha3 == SkillType.Dian4 ||
                SkillJiaDian.S.Alpha3 == SkillType.Dian5
                || SkillJiaDian.S.Alpha4 == SkillType.Dian1 || SkillJiaDian.S.Alpha4 == SkillType.Dian2 ||
                SkillJiaDian.S.Alpha4 == SkillType.Dian3 || SkillJiaDian.S.Alpha4 == SkillType.Dian4 ||
                SkillJiaDian.S.Alpha4 == SkillType.Dian5
                || SkillJiaDian.S.Alpha5 == SkillType.Dian1 || SkillJiaDian.S.Alpha5 == SkillType.Dian2 ||
                SkillJiaDian.S.Alpha5 == SkillType.Dian3 || SkillJiaDian.S.Alpha5 == SkillType.Dian4 ||
                SkillJiaDian.S.Alpha5 == SkillType.Dian5)
            {
                for (int i = 0; i < 200; i++)
                {
                    var DianPeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/Peng/DianPeng"));
                    DianPeng.SetActive(false);
                    GameController.S.DianPengQueue.Enqueue(DianPeng);
                }
            }
            


            if (PlayerData.S.playerWeaponType == WeaponType.HeiAnBaoZha)
            {
                for (int i = 0; i < 30; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HeiAnBaoZha"));
                    IcePeng.SetActive(false);
                    GameController.S.HeiAnBaoZhaQueue.Enqueue(IcePeng);
                    var IcePeng1 =
                        Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HeiAnBaoZhaNext"));
                    IcePeng1.SetActive(false);
                    GameController.S.HeiAnBaoZhaNextQueue.Enqueue(IcePeng1);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.Huo7)
            {
                for (int i = 0; i < 100; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/Huo7Item").GetComponent<Huo7Item>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.Huo7Queue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.Ice7)
            {
                for (int i = 0; i < 100; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/Ice7Item").GetComponent<Ice7Item>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.Ice7Queue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.DianLuoLei5)
            {
                for (int i = 0; i < 30; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/DianLuoLei").GetComponent<DianLuoLei>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.DianLuoLeiQueue.Enqueue(IcePeng);
                    
                    var IcePeng1 = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/DianLuoLeiNext").GetComponent<DianLuoLeiNext>());
                    IcePeng1.gameObject.SetActive(false);
                    GameController.S.DianLuoLeiNextQueue.Enqueue(IcePeng1);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.PrimaryDian)
            {
                for (int i = 0; i < 30; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/PrimaryDian").GetComponent<PrimaryDian>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.PrimaryDianQueue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.PrimaryHuo)
            {
                for (int i = 0; i < 30; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/PrimaryHuo").GetComponent<PrimaryHuo>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.PrimaryHuoQueue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.PrimaryHeiAn)
            {
                for (int i = 0; i < 30; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/PrimaryHeiAn").GetComponent<PrimaryHeiAn>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.PrimaryHeiAnQueue.Enqueue(IcePeng);
                }
            }
            
            
            
            
            if (PlayerData.S.playerWeaponType == WeaponType.IcePen)
            {
                for (int i = 0; i < 30; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/IcePen").GetComponent<IcePen>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.IcePenQueue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.HuoFenLie)
            {
                for (int i = 0; i < 30; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HuoFenLie").GetComponent<HuoFenLie>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.HuoFenLieQueue.Enqueue(IcePeng);
                    var IcePeng1 = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HuoFenLieDan").GetComponent<HuoFenLieDan>());
                    IcePeng1.gameObject.SetActive(false);
                    GameController.S.HuoFenLieDanQueue.Enqueue(IcePeng1);
                    var IcePeng2 = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HuoFenLieBaoZha").GetComponent<HuoFenLieBaoZha>());
                    IcePeng2.gameObject.SetActive(false);
                    GameController.S.HuoFenLieBaoZhaQueue.Enqueue(IcePeng2);

                }
            }
            
            
            if (PlayerData.S.playerWeaponType == WeaponType.Ice4BaoZha)
            {
                for (int i = 0; i < 50; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/Ice4BaoZha").GetComponent<Ice4BaoZha>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.Ice4BaoZhaQueue.Enqueue(IcePeng);
                    var IcePeng1 = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/Ice4BaoZhaItem").GetComponent<Ice4BaoZhaItem>());
                    IcePeng1.gameObject.SetActive(false);
                    GameController.S.Ice4BaoZhaItemQueue.Enqueue(IcePeng1);
                }
            }
            
            
            if (PlayerData.S.playerWeaponType == WeaponType.DianJiSu)
            {
                for (int i = 0; i < 50; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/DianJiSu").GetComponent<DianJiSu>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.DianJiSuQueue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.HeiAnHuiXuan)
            {
                for (int i = 0; i < 50; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HeiAnHuiXuan").GetComponent<HeiAnHuiXuan>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.HeiAnHuiXuanQueue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.HuoDiPen)
            {
                for (int i = 0; i < 50; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HuoDiPen").GetComponent<HuoDiPen>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.HuoDiPenQueue.Enqueue(IcePeng);
                }
            }
            
            if (PlayerData.S.playerWeaponType == WeaponType.HeiAnQuXian)
            {
                for (int i = 0; i < 50; i++)
                {
                    var IcePeng = Instantiate(Resources.Load<GameObject>("Prefabs/Skill/NormalAttack/HeiAnQuXian").GetComponent<HuoQuXian>());
                    IcePeng.gameObject.SetActive(false);
                    GameController.S.HeiAnQuXianQueue.Enqueue(IcePeng);
                }
            }

            
            

            FightBGController.S.DiLie = Instantiate(Resources.Load("Prefabs/Skill/BossGroundFissure"),
                new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            FightBGController.S.DiLie.SetActive(false);

            FightBGController.S.CircleAttack =
                Instantiate(Resources.Load<GameObject>("Prefabs/Tool/CircleAttack")).gameObject;
            FightBGController.S.CircleAttack.SetActive(false);

            //初始化怪物队列
            
            LevelInfoConfig.InitMonsterQueue();
        

            for (int i = 0; i < 100; i++)
            {
                var baoxue = Instantiate(Resources.Load<GameObject>("Prefabs/Monster/BaoXue").GetComponent<BaoXue>(),
                    GameController.S.transform);
                baoxue.gameObject.SetActive(false);
                GameController.S.BaoXueQueue.Enqueue(baoxue);
            }

            for (int i = 0; i < 100; i++)
            {
                DanMu danmu = Instantiate(Resources.Load<GameObject>("Prefabs/MonsterDanMu/DanMu"),transform).GetComponent<DanMu>();
                danmu.gameObject.SetActive(false);
                GameController.S.DanMuQueue.Enqueue(danmu);
            }

        


            if (LevelInfoConfig.CurrentGameLevel == 1 || LevelInfoConfig.CurrentGameLevel == 2 ||
                LevelInfoConfig.CurrentGameLevel == 3)
            {
                for (int i = 0; i < 5; i++)
                {
                    var DiLie = Instantiate(
                        Resources.Load<GameObject>("Prefabs/Skill/DiLie").GetComponent<TreeManDiLie>(),
                        GameController.S.transform);
                    DiLie.gameObject.SetActive(false);
                    GameController.S.TreeManDiLieQueue.Enqueue(DiLie.GetComponent<TreeManDiLie>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 3)
            {
                for (int i = 0; i < 50; i++)
                {
                    var treemanSkill =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level1/TreeManSkill")
                                .GetComponent<TreeManSkill>(),
                            GameController.S.transform);
                    treemanSkill.gameObject.SetActive(false);
                    GameController.S.TreeManSkillQueue.Enqueue(treemanSkill.GetComponent<TreeManSkill>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 6)
            {
                for (int i = 0; i < 3; i++)
                {
                    var jianqi =
                        Instantiate(Resources.Load<HuoShanJianQi>("Prefabs/Monster/Level2/HuoShanJianQi"),
                            GameController.S.transform);
                    jianqi.gameObject.SetActive(false);
                    GameController.S.HuoShanJianQiQueue.Enqueue(jianqi);
                }

                for (int i = 0; i < 51; i++)
                {
                    var huoshanskill2 =
                        Instantiate(Resources.Load<HuoShanSkill2>("Prefabs/Monster/Level2/HuoShanSkill2"),
                            GameController.S.transform);
                    huoshanskill2.gameObject.SetActive(false);
                    GameController.S.HuoShanSkill2QiQueue.Enqueue(huoshanskill2);
                }

            }


            if (LevelInfoConfig.CurrentGameLevel == 9)
            {
                for (int i = 0; i < 10; i++)
                {
                    var zhaozeSkill = Instantiate(Resources.Load<ZhaoZeSkill>("Prefabs/Monster/Level3/ZhaoZeBossSkill"),
                        GameController.S.transform);
                    zhaozeSkill.gameObject.SetActive(false);
                    GameController.S.ZhaoZeSkillQueue.Enqueue(zhaozeSkill);
                }
            }
        


            if (LevelInfoConfig.CurrentGameLevel == 13 || LevelInfoConfig.CurrentGameLevel == 14 ||
                LevelInfoConfig.CurrentGameLevel == 15)
            {
                for (int i = 0; i < 100; i++)
                {
                    var XueRenJian =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level5/XueRenJian").GetComponent<XueRenJian>(),
                            GameController.S.transform);
                    XueRenJian.gameObject.SetActive(false);
                    GameController.S.XueRenJianQueue.Enqueue(XueRenJian.GetComponent<XueRenJian>());
                }
            }

            if (LevelInfoConfig.CurrentGameLevel == 15)
            {
                var XueRenBossSkill1 =
                    Instantiate(
                        Resources.Load<GameObject>("Prefabs/Monster/Level5/XueRenBossSkill1")
                            .GetComponent<XueRenBossSkill1>(), GameController.S.transform);
                XueRenBossSkill1.gameObject.SetActive(false);
                GameController.S.XueRenBossSkill1Queue.Enqueue(XueRenBossSkill1.GetComponent<XueRenBossSkill1>());
            }


        
            
            //Boss技能队列
            if (LevelInfoConfig.CurrentGameLevel == 12)
            {
                for (int i = 0; i < 30; i++)
                {
                    var xieziskill1 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level4/XieZiSkill1")
                                .GetComponent<XieZiSkill1>(), GameController.S.transform);
                    xieziskill1.gameObject.SetActive(false);
                    GameController.S.XieZiSkill1Queue.Enqueue(xieziskill1);
                }

                for (int i = 0; i < 10; i++)
                {
                    var xieziskill4 =
                        Instantiate(
                            Resources.Load<GameObject>("Prefabs/Monster/Level4/XieZiSkill4")
                                .GetComponent<XieZiSkill4>(), GameController.S.transform);
                    xieziskill4.gameObject.SetActive(false);
                    GameController.S.XieZiSkill4Queue.Enqueue(xieziskill4);
                }
            }
            
        
            GameController.S.fightBG = Instantiate(Resources.Load<GameObject>("Prefabs/Window/FightBG"),
                GameController.S.transform);
            GameController.S.fightBG.transform.position = new Vector3(0, 0, 0.1f);
            GameController.S.monsterHpSliderPrefabs = Resources.Load<GameObject>("Prefabs/Tool/MonsterHPBloodBar");
        
            GameController.S.CreatePlayer();
        }
}
