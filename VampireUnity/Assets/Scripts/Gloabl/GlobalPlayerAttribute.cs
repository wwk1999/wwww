using System;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.Rendering;

public enum ExitType
{
    None,
    FirstGame,
    Exit,
    Again
}

public class TitleAttributeAll
{
    public float Attack;
    public float Defense;
    public float Hp;
    public float Crit;
    public float FinalDamage;
    public float AllBaseAttribute;
    public float AllDamage;
    public float BaoShiTeXiao;
    public float DiaoLuo;
    public float LinHun;
    public float NormalAttackDamage;
    public float MoveSpeed;
}

public class ShouCangShiAttribute
{
    public float Attack;
    public float Defense;
    public float Hp;
    public float Crit;
}
public class GlobalPlayerAttribute
{


    public static float JianSuRate => ((IceYuanSuBase) / (5 + IceYuanSuBase))*(1.0f+SkillJiaDian.S.IceBei1*5/100f) * 100f;
    public static float JianSuTime => 1 * (1.0f + SkillJiaDian.S.IceBei3 * 5 / 100f);

    public static float HuoMaxCengShu => 1 + SkillJiaDian.S.HuoBei1;
    public static float HuoDamageJianGe => 1 * (1 - SkillJiaDian.S.HuoBei4 * 5 / 100);
    public static float HuoTime => 3.1f + (0.5f * SkillJiaDian.S.HuoBei3);
    public static float HuoZhuoShaoDamage => HuoYuanSuBase * GameController.S.GetGameAttack()*(1f+SkillJiaDian.S.HuoBei2*5/100);
    public static float LuoLeiRate =>
        (GlobalPlayerAttribute.DianYuanSuBase / (10f + GlobalPlayerAttribute.DianYuanSuBase)) * 100;

    public static float LingHunRate =>
        (GlobalPlayerAttribute.HeiAnYuanSuBase / (8f + GlobalPlayerAttribute.HeiAnYuanSuBase)) * 100;

    
    //宠物属性
    public static ChongWuConfig.ChongWuAttribute FinalChongWuAttribute => GetFinalChongWuAttribute();

    public static ChongWuConfig.ChongWuAttribute GetFinalChongWuAttribute()
    {
        if (PlayerData.S.ZhuChongWuId == 0)
        {
            ChongWuConfig.ChongWuAttribute finalAttributr1 = new ChongWuConfig.ChongWuAttribute();
            return finalAttributr1;
        }
        ChongWuConfig.ChongWuAttribute zhuchongwu =
            ChongWuConfig.GetChongWuAttribute(PlayerData.S.ChongWuDic[PlayerData.S.ZhuChongWuId]);
        ChongWuConfig.ChongWuAttribute fuchongwu1 = null;
        ChongWuConfig.ChongWuAttribute fuchongwu2 = null;
        ChongWuConfig.ChongWuAttribute fuchongwu3 = null;

        if (PlayerData.S.FuChongWuId1 != 0)
        {
            fuchongwu1 = ChongWuConfig.GetChongWuAttribute(PlayerData.S.ChongWuDic[PlayerData.S.FuChongWuId1]);
        }
        if (PlayerData.S.FuChongWuId2 != 0)
        {
            fuchongwu2 = ChongWuConfig.GetChongWuAttribute(PlayerData.S.ChongWuDic[PlayerData.S.FuChongWuId2]);
        }
        if (PlayerData.S.FuChongWuId3 != 0)
        {
            fuchongwu3 = ChongWuConfig.GetChongWuAttribute(PlayerData.S.ChongWuDic[PlayerData.S.FuChongWuId3]);
        }

        ChongWuConfig.ChongWuAttribute finalAttributr = zhuchongwu;
        if (fuchongwu1 != null)
        {
            finalAttributr.Crit += fuchongwu1.Crit * 0.3f;
            finalAttributr.Attack += fuchongwu1.Attack * 0.3f;
            finalAttributr.Hp += fuchongwu1.Hp * 0.3f;
            finalAttributr.Defence += fuchongwu1.Defence * 0.3f;
        }
        
        if (fuchongwu2 != null)
        {
            finalAttributr.Crit += fuchongwu2.Crit * 0.3f;
            finalAttributr.Attack += fuchongwu2.Attack * 0.3f;
            finalAttributr.Hp += fuchongwu2.Hp * 0.3f;
            finalAttributr.Defence += fuchongwu2.Defence * 0.3f;
        }
        
        if (fuchongwu3 != null)
        {
            finalAttributr.Crit += fuchongwu3.Crit * 0.3f;
            finalAttributr.Attack += fuchongwu3.Attack * 0.3f;
            finalAttributr.Hp += fuchongwu3.Hp * 0.3f;
            finalAttributr.Defence += fuchongwu3.Defence * 0.3f;
        }

        ChongWuConfig.CongWuTuJianAttribute congWuTuJianAttribute =
            ChongWuConfig.CongWuTuJianAttributeDic[ChongWuConfig.GetChongWuTuJianType()];

        finalAttributr.Attack += congWuTuJianAttribute.Attack;
        finalAttributr.Hp += congWuTuJianAttribute.Hp;
        finalAttributr.HuoDamage += congWuTuJianAttribute.Huo/100.0f;
        finalAttributr.IceDamage += congWuTuJianAttribute.Ice/100.0f;
        finalAttributr.DianDamage += congWuTuJianAttribute.Dian/100.0f;
        finalAttributr.HeiAnDamage += congWuTuJianAttribute.HeiAn/100.0f;

        return finalAttributr;
    }
    
    //武器属性
    
   public static float WeaponAttack=>GetWeaponAttack();
   public static float WeaponDefense=>GetWeaponDefense();
   public static float WeaponCrit=>GetWeaponCrit();
   public static float WeaponHp=>GetWeaponHp();
   public static float WeaponAttackSpeed=>GetWeaponAttackSpeed();
   public static float WeaponShenJiPercent = 0.2f;

   public static float HunQiDamage => GetHunQiDamage();
   public static float HunQiAttackSpeed => GetHunQiAttackSpeed();


   
   //专精属性
   public static float MonsterAttack => GetMonsterAttack();
   public static float MonsterDefense => GetMonsterDefense();
   public static float MonsterHp => GetMonsterHp();
   public static float MonsterCrit => GetMonsterCrit();
   
   
   
   //宝石属性
   public static float BaoShiAttack => GetBaoShiAttack();
   public static float BaoShiDefense => GetBaoShiDefense();
   public static float BaoShiHp => GetBaoShiHp();
   public static float BaoShiCrit => GetBaoShiCrit();
   
   public static int BaoShiTeXiao3Count=>GetBaoShiTeXiao3Count();

   public static float BaoShiXiaoGuo => GetBaoShiXiaoGuo();
   
   
   
   //称号属性
   public static TitleAttributeAll TitleAttributeAll => GetTitleAttributeAll();

   public static float LinHun => GetLinHun();
   public static float AllDamage => GetAllDamage();
   
   public static float FinalDamage => GetFinalDamage();


   public static int HH5Count => GetHH5Count();
   public static int HA5Count => GetHA5Count();
   public static int HC5Count => GetHC5Count();
   public static int HD5Count => GetHD5Count();
   public static int AA5Count => GetAA5Count();
   public static int AC5Count => GetAC5Count();
   public static int AD5Count => GetAD5Count();
   public static int CC5Count => GetCC5Count();
   public static int CD5Count => GetCD5Count();
   public static int DD5Count => GetDD5Count();

   
   
   
   
   
   
   
   public static bool IsGame = false;
   public static float CurrentHp=0;
   public static bool isIceBall = false;
   public static ExitType CurrentExitType = ExitType.FirstGame;

   public static HashSet<EntryConfig.OrangeEntry> PlayerOrangeEntry => GetPlayerOrangeEntry();


   public static HashSet<EntryConfig.OrangeEntry> GetPlayerOrangeEntry()
   {
     HashSet<EntryConfig.OrangeEntry> PlayerOrangeEntry1 = new HashSet<EntryConfig.OrangeEntry>();
     PlayerOrangeEntry1.Clear();
     if (PlayerEquipConfig.CloakId != 0)
     {
         if (BagController.S.EquipIdList[PlayerEquipConfig.CloakId].OrangeEntry1 != EntryConfig.OrangeEntry.None)
         {
             PlayerOrangeEntry1.Add(BagController.S.EquipIdList[PlayerEquipConfig.CloakId].OrangeEntry1);
         }
     }
       
     if (PlayerEquipConfig.ClothId != 0)
     {
         if (BagController.S.EquipIdList[PlayerEquipConfig.ClothId].OrangeEntry1 != EntryConfig.OrangeEntry.None)
         {
             PlayerOrangeEntry1.Add(BagController.S.EquipIdList[PlayerEquipConfig.ClothId].OrangeEntry1);
         }
     }
       
     if (PlayerEquipConfig.RingId != 0)
     {
         if (BagController.S.EquipIdList[PlayerEquipConfig.RingId].OrangeEntry1 != EntryConfig.OrangeEntry.None)
         {
             PlayerOrangeEntry1.Add(BagController.S.EquipIdList[PlayerEquipConfig.RingId].OrangeEntry1);
         }
     }
     if (PlayerEquipConfig.NecklaceId != 0)
     {
         if (BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId].OrangeEntry1 != EntryConfig.OrangeEntry.None)
         {
             PlayerOrangeEntry1.Add(BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId].OrangeEntry1);
         }
     }
     if (PlayerEquipConfig.ShoeId != 0)
     {
         if (BagController.S.EquipIdList[PlayerEquipConfig.ShoeId].OrangeEntry1 != EntryConfig.OrangeEntry.None)
         {
             PlayerOrangeEntry1.Add(BagController.S.EquipIdList[PlayerEquipConfig.ShoeId].OrangeEntry1);
         }
     }
     if (PlayerEquipConfig.HelmetId != 0)
     {
         if (BagController.S.EquipIdList[PlayerEquipConfig.HelmetId].OrangeEntry1 != EntryConfig.OrangeEntry.None)
         {
             PlayerOrangeEntry1.Add(BagController.S.EquipIdList[PlayerEquipConfig.HelmetId].OrangeEntry1);
         }
     }

     return PlayerOrangeEntry1;
   }
   public static float NormalAddDamage(float finalDamage)
   {
       if (PlayerEquipConfig.CloakId != 0)
       {
           if (BagController.S.EquipIdList[PlayerEquipConfig.CloakId].Quality < 5)
           {
               finalDamage += 0.3f;
           }
       }
            
       if (PlayerEquipConfig.ClothId != 0)
       {
           if (BagController.S.EquipIdList[PlayerEquipConfig.ClothId].Quality < 5)
           {
               finalDamage += 0.3f;
           }
       }
            
       if (PlayerEquipConfig.NecklaceId != 0)
       {
           if (BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId].Quality < 5)
           {
               finalDamage += 0.3f;
           }
       }
            
       if (PlayerEquipConfig.RingId != 0)
       {
           if (BagController.S.EquipIdList[PlayerEquipConfig.RingId].Quality < 5)
           {
               finalDamage += 0.3f;
           }
       }
            
       if (PlayerEquipConfig.ShoeId != 0)
       {
           if (BagController.S.EquipIdList[PlayerEquipConfig.ShoeId].Quality < 5)
           {
               finalDamage += 0.3f;
           }
       }
            
       if (PlayerEquipConfig.HelmetId != 0)
       {
           if (BagController.S.EquipIdList[PlayerEquipConfig.HelmetId].Quality < 5)
           {
               finalDamage += 0.3f;
           }
       }

       return finalDamage;
   }

   
   
   public static float GetFinalDamage()
   {
       float finalDamage = 0;//最终伤害
       int OrangeEquipCount = 0;
       int NoOrangeEquipCount = 0;
       if (PlayerData.S.clothid != 0)
       {
           if (BagController.S.EquipIdList[PlayerData.S.clothid].Quality < 5)
           {
               NoOrangeEquipCount++;
           }
           else
           {
               OrangeEquipCount++;
           }
       }
       
       if (PlayerData.S.helmetid != 0)
       {
           if (BagController.S.EquipIdList[PlayerData.S.helmetid].Quality < 5)
           {
               NoOrangeEquipCount++;
           }
           else
           {
               OrangeEquipCount++;
           }
       }
       
       if (PlayerData.S.shoeid != 0)
       {
           if (BagController.S.EquipIdList[PlayerData.S.shoeid].Quality < 5)
           {
               NoOrangeEquipCount++;
           }
           else
           {
               OrangeEquipCount++;
           }
       }
       
       if (PlayerData.S.necklaceid != 0)
       {
           if (BagController.S.EquipIdList[PlayerData.S.necklaceid].Quality < 5)
           {
               NoOrangeEquipCount++;
           }
           else
           {
               OrangeEquipCount++;
           }
       }
       
       if (PlayerData.S.ringid != 0)
       {
           if (BagController.S.EquipIdList[PlayerData.S.ringid].Quality < 5)
           {
               NoOrangeEquipCount++;
           }
           else
           {
               OrangeEquipCount++;
           }
       }
       
       if (PlayerData.S.cloakid != 0)
       {
           if (BagController.S.EquipIdList[PlayerData.S.cloakid].Quality < 5)
           {
               NoOrangeEquipCount++;
           }
           else
           {
               OrangeEquipCount++;
           }
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.FinalDamageAddPercent))
       {
           finalDamage += 0.15f;
       }

       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.FanPuGuiZhen))
       {
           if (WeaponConfig.WeaponQualityDic[PlayerData.S.playerWeaponType] < 5)
           {
               finalDamage += 0.5f;
           }
       }

       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.NormalAddDamage))
       {
           finalDamage=NormalAddDamage(finalDamage);
       }
       
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.OrangeEquip))
       {
           finalDamage += OrangeEquipCount * 0.05f;
       }
       
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.NoOrangeEquip))
       {
           finalDamage += NoOrangeEquipCount * 0.15f;
       }
      
       finalDamage += AA5Count * 0.3f;
       finalDamage += TitleAttributeAll.FinalDamage;
       finalDamage += FinalChongWuAttribute.FinalDamage;
       
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Green5)
       {
           finalDamage *= (1.05f);
       }
       if (PlayerData.S.playerChiBangType == ChiBangType.Blue6)
       {
           finalDamage *= (1.1f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Purple5)
       {
           finalDamage *= (1.15f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Orange3)
       {
           finalDamage *= (1.2f);
       }
       
       return finalDamage;
   }

   public static float GetLinHun()
   {
       float value = 0;
       value += TitleAttributeAll.LinHun;
       return value;
   }

   public static float GetAllDamage()
   {
       float value = 0;
       value += TitleAttributeAll.AllDamage;
       return value;
   }
   
   
   public static void JiHuoAttribute(TitleType titleType, TitleAttributeAll titleAttributeAll)
   {
       foreach (var Level5item1 in TitleConfig.TitleAttributeDic[titleType].JiHuoList)
       {
           switch (Level5item1.Type)
           {
               case TitleAttributeType.Attack:
                   titleAttributeAll.Attack += Level5item1.Value;
                   break;
               case TitleAttributeType.Defense:
                   titleAttributeAll.Defense += Level5item1.Value;
                   break;
               case TitleAttributeType.Crit:
                   titleAttributeAll.Crit += Level5item1.Value;
                   break;
               case TitleAttributeType.Hp:
                   titleAttributeAll.Hp += Level5item1.Value;
                   break;
               case TitleAttributeType.LinHun:
                   titleAttributeAll.LinHun += Level5item1.Value;
                   break;
               case TitleAttributeType.BaoShiTeXiao:
                   titleAttributeAll.BaoShiTeXiao += Level5item1.Value;
                   break;
               case TitleAttributeType.AllBaseAttribute:
                   titleAttributeAll.AllBaseAttribute += Level5item1.Value;
                   break;
               case TitleAttributeType.AllDamage:
                   titleAttributeAll.AllDamage += Level5item1.Value;
                   break;
               case TitleAttributeType.NormalAttackDamage:
                   titleAttributeAll.NormalAttackDamage += Level5item1.Value;
                   break;
               case TitleAttributeType.DiaoLuo:
                   titleAttributeAll.DiaoLuo += Level5item1.Value;
                   break;
               case TitleAttributeType.FinalDamage:
                   titleAttributeAll.FinalDamage += Level5item1.Value;
                   break;
               case TitleAttributeType.MoveSpeed:
                   titleAttributeAll.MoveSpeed += Level5item1.Value;
                   break;
           }
       }
   }

   public static void GetJiHuoAttribute(TitleAttributeAll titleAttributeAll)
   {
        if (PlayerData.S.Level5)
       {
           JiHuoAttribute(TitleType.Level5, titleAttributeAll);
       }
       if (PlayerData.S.Level15)
       {
           JiHuoAttribute(TitleType.Level15, titleAttributeAll);
       }
       
       if (PlayerData.S.Level30)
       {
           JiHuoAttribute(TitleType.Level30, titleAttributeAll);
       }
       if (PlayerData.S.Level50)
       {
           JiHuoAttribute(TitleType.Level50, titleAttributeAll);
       }
       if (PlayerData.S.Level75)
       {
           JiHuoAttribute(TitleType.Level75, titleAttributeAll);
       }
       if (PlayerData.S.Level100)
       {
           JiHuoAttribute(TitleType.Level100, titleAttributeAll);
       }
       if (PlayerData.S.MonsterCount1)
       {
           JiHuoAttribute(TitleType.MonsterCount1, titleAttributeAll);
       }
       if (PlayerData.S.MonsterCount2)
       {
           JiHuoAttribute(TitleType.MonsterCount2, titleAttributeAll);
       }
       if (PlayerData.S.MonsterCount3)
       {
           JiHuoAttribute(TitleType.MonsterCount3, titleAttributeAll);
       }
       if (PlayerData.S.MonsterCount4)
       {
           JiHuoAttribute(TitleType.MonsterCount4, titleAttributeAll);
       }
       if (PlayerData.S.MonsterCount5)
       {
           JiHuoAttribute(TitleType.MonsterCount5, titleAttributeAll);
       }
       if (PlayerData.S.MonsterCount6)
       {
           JiHuoAttribute(TitleType.MonsterCount6, titleAttributeAll);
       }
       if (PlayerData.S.LingHun)
       {
           JiHuoAttribute(TitleType.LinHun, titleAttributeAll);
       }
       if (PlayerData.S.BaoShi)
       {
           JiHuoAttribute(TitleType.BaoShi, titleAttributeAll);
       }
       if (PlayerData.S.HunQi3)
       {
           JiHuoAttribute(TitleType.HunQi3, titleAttributeAll);
       }
       if (PlayerData.S.HunQi4)
       {
           JiHuoAttribute(TitleType.HunQi4, titleAttributeAll);
       }
       if (PlayerData.S.HunQi5)
       {
           JiHuoAttribute(TitleType.HunQi5, titleAttributeAll);
       }

       if (PlayerData.S.GuanKa3)
       {
           JiHuoAttribute(TitleType.GuanKa3, titleAttributeAll);
       }
       if (PlayerData.S.GuanKa4)
       {
           JiHuoAttribute(TitleType.GuanKa4, titleAttributeAll);
       }
       if (PlayerData.S.GuanKa5)
       {
           JiHuoAttribute(TitleType.GuanKa5, titleAttributeAll);
       }
       
       if (PlayerData.S.ChiBang4)
       {
           JiHuoAttribute(TitleType.ChiBang5, titleAttributeAll);
       }
       
       if (PlayerData.S.ChiBang5)
       {
           JiHuoAttribute(TitleType.ChiBang5, titleAttributeAll);
       }
       
       if (PlayerData.S.DiaoLuo)
       {
           JiHuoAttribute(TitleType.DiaoLuo, titleAttributeAll);
       }
   }

   public static void InstallAttribute(TitleType titleType,TitleAttributeAll titleAttributeAll)
   {
       foreach (var installItem in TitleConfig.TitleAttributeDic[titleType].InstallList)
               {
                   switch (installItem.Type)
                   {
                       case TitleAttributeType.Attack:
                           titleAttributeAll.Attack += installItem.Value;
                           break;
                       case TitleAttributeType.Defense:
                           titleAttributeAll.Defense += installItem.Value;
                           break;
                       case TitleAttributeType.Crit:
                           titleAttributeAll.Crit += installItem.Value;
                           break;
                       case TitleAttributeType.Hp:
                           titleAttributeAll.Hp += installItem.Value;
                           break;
                       case TitleAttributeType.LinHun:
                           titleAttributeAll.LinHun += installItem.Value;
                           break;
                       case TitleAttributeType.BaoShiTeXiao:
                           titleAttributeAll.BaoShiTeXiao += installItem.Value;
                           break;
                       case TitleAttributeType.AllBaseAttribute:
                           titleAttributeAll.AllBaseAttribute += installItem.Value;
                           break;
                       case TitleAttributeType.AllDamage:
                           titleAttributeAll.AllDamage += installItem.Value;
                           break;
                       case TitleAttributeType.NormalAttackDamage:
                           titleAttributeAll.NormalAttackDamage += installItem.Value;
                           break;
                       case TitleAttributeType.DiaoLuo:
                           titleAttributeAll.DiaoLuo += installItem.Value;
                           break;
                       case TitleAttributeType.FinalDamage:
                           titleAttributeAll.FinalDamage += installItem.Value;
                           break;
                       case TitleAttributeType.MoveSpeed:
                           titleAttributeAll.MoveSpeed += installItem.Value;
                           break;
                   }
               }
   }

   public static TitleAttributeAll GetTitleAttributeAll()
   {
       TitleAttributeAll titleAttributeAll = new TitleAttributeAll();
       GetJiHuoAttribute(titleAttributeAll);
       switch (PlayerData.S.CurrentInstallTitle)
       {
           case TitleType.Level5:
               InstallAttribute(TitleType.Level5, titleAttributeAll);
               break;
           case TitleType.Level15:
               InstallAttribute(TitleType.Level15, titleAttributeAll);
               break;
           case TitleType.Level30:
               InstallAttribute(TitleType.Level30, titleAttributeAll);
               break;
           case TitleType.Level50:
               InstallAttribute(TitleType.Level50, titleAttributeAll);
               break;
           case TitleType.Level75:
               InstallAttribute(TitleType.Level75, titleAttributeAll);
               break;
           case TitleType.Level100:
               InstallAttribute(TitleType.Level100, titleAttributeAll);
               break;
           case TitleType.MonsterCount1:
               InstallAttribute(TitleType.MonsterCount1, titleAttributeAll);
               break;
           case TitleType.MonsterCount2:
               InstallAttribute(TitleType.MonsterCount2, titleAttributeAll);
               break;
           case TitleType.MonsterCount3:
               InstallAttribute(TitleType.MonsterCount3, titleAttributeAll);
               break;
           case TitleType.MonsterCount4:
               InstallAttribute(TitleType.MonsterCount4, titleAttributeAll);
               break;
           case TitleType.MonsterCount5:
               InstallAttribute(TitleType.MonsterCount5, titleAttributeAll);
               break;
           case TitleType.MonsterCount6:
               InstallAttribute(TitleType.MonsterCount6, titleAttributeAll);
               break;
           case TitleType.LinHun:
               InstallAttribute(TitleType.LinHun, titleAttributeAll);
               break;
           case TitleType.BaoShi:
               InstallAttribute(TitleType.BaoShi, titleAttributeAll);
               break;
           case TitleType.HunQi3:
               InstallAttribute(TitleType.HunQi3, titleAttributeAll);
               break;
           case TitleType.HunQi4:
               InstallAttribute(TitleType.HunQi4, titleAttributeAll);
               break;
           case TitleType.HunQi5:
               InstallAttribute(TitleType.HunQi5, titleAttributeAll);
               break;
           case TitleType.GuanKa3:
               InstallAttribute(TitleType.GuanKa3, titleAttributeAll);
               break;
           case TitleType.GuanKa4:
               InstallAttribute(TitleType.GuanKa4, titleAttributeAll);
               break;
           case TitleType.GuanKa5:
               InstallAttribute(TitleType.GuanKa5, titleAttributeAll);
               break;
           case TitleType.DiaoLuo:
               InstallAttribute(TitleType.DiaoLuo, titleAttributeAll);
               break;
           case TitleType.ChiBang4:
               InstallAttribute(TitleType.ChiBang4, titleAttributeAll);
               break;
           case TitleType.ChiBang5:
               InstallAttribute(TitleType.ChiBang5, titleAttributeAll);
               break;
       }

       return titleAttributeAll;
   }


   public static float GetHunQiDamage()
   {
       float value = 0;
       value += TitleAttributeAll.NormalAttackDamage;
       return 0;
   }
   
   
   public static float GetHunQiAttackSpeed()
   {
       return 0;
   }

   

   public static float GetBaoShiXiaoGuo()
   {
       float value=BaoShiTeXiao3Count * 0.1f;
       value += HC5Count * 0.7f;
       value += TitleAttributeAll.BaoShiTeXiao;
       return value;
   }

   public static int GetHH5Count()
   {
       int value = 0;
       if (PlayerEquipConfig.CloakId != 0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           if (Cloak.BaoShiDic.Count >= 5)
           {
               if (Cloak.BaoShiDic[1].BaoShiType == BaoShiType.HH && Cloak.BaoShiDic[2].BaoShiType == BaoShiType.HH &&
                   Cloak.BaoShiDic[3].BaoShiType == BaoShiType.HH && Cloak.BaoShiDic[4].BaoShiType == BaoShiType.HH &&
                   Cloak.BaoShiDic[5].BaoShiType == BaoShiType.HH)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.HelmetId != 0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           if (Helmet.BaoShiDic.Count >= 5)
           {
               if (Helmet.BaoShiDic[1].BaoShiType == BaoShiType.HH && Helmet.BaoShiDic[2].BaoShiType == BaoShiType.HH &&
                   Helmet.BaoShiDic[3].BaoShiType == BaoShiType.HH && Helmet.BaoShiDic[4].BaoShiType == BaoShiType.HH &&
                   Helmet.BaoShiDic[5].BaoShiType == BaoShiType.HH)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.NecklaceId != 0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           if (Necklace.BaoShiDic.Count >= 5)
           {
               if (Necklace.BaoShiDic[1].BaoShiType == BaoShiType.HH && Necklace.BaoShiDic[2].BaoShiType == BaoShiType.HH &&
                   Necklace.BaoShiDic[3].BaoShiType == BaoShiType.HH && Necklace.BaoShiDic[4].BaoShiType == BaoShiType.HH &&
                   Necklace.BaoShiDic[5].BaoShiType == BaoShiType.HH)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.RingId != 0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           if (Ring.BaoShiDic.Count >= 5)
           {
               if (Ring.BaoShiDic[1].BaoShiType == BaoShiType.HH && Ring.BaoShiDic[2].BaoShiType == BaoShiType.HH &&
                   Ring.BaoShiDic[3].BaoShiType == BaoShiType.HH && Ring.BaoShiDic[4].BaoShiType == BaoShiType.HH &&
                   Ring.BaoShiDic[5].BaoShiType == BaoShiType.HH)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ShoeId != 0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           if (Shoe.BaoShiDic.Count >= 5)
           {
               if (Shoe.BaoShiDic[1].BaoShiType == BaoShiType.HH && Shoe.BaoShiDic[2].BaoShiType == BaoShiType.HH &&
                   Shoe.BaoShiDic[3].BaoShiType == BaoShiType.HH && Shoe.BaoShiDic[4].BaoShiType == BaoShiType.HH &&
                   Shoe.BaoShiDic[5].BaoShiType == BaoShiType.HH)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ClothId != 0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           if (Cloth.BaoShiDic.Count >= 5)
           {
               if (Cloth.BaoShiDic[1].BaoShiType == BaoShiType.HH && Cloth.BaoShiDic[2].BaoShiType == BaoShiType.HH &&
                   Cloth.BaoShiDic[3].BaoShiType == BaoShiType.HH && Cloth.BaoShiDic[4].BaoShiType == BaoShiType.HH &&
                   Cloth.BaoShiDic[5].BaoShiType == BaoShiType.HH)
               {
                   value++;
               }
           }
       }

       return value;
   }
   
   
   
   public static int GetHA5Count()
   {
       int value = 0;
       if (PlayerEquipConfig.CloakId != 0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           if (Cloak.BaoShiDic.Count >= 5)
           {
               if (Cloak.BaoShiDic[1].BaoShiType == BaoShiType.HA && Cloak.BaoShiDic[2].BaoShiType == BaoShiType.HA &&
                   Cloak.BaoShiDic[3].BaoShiType == BaoShiType.HA && Cloak.BaoShiDic[4].BaoShiType == BaoShiType.HA &&
                   Cloak.BaoShiDic[5].BaoShiType == BaoShiType.HA)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.HelmetId != 0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           if (Helmet.BaoShiDic.Count >= 5)
           {
               if (Helmet.BaoShiDic[1].BaoShiType == BaoShiType.HA && Helmet.BaoShiDic[2].BaoShiType == BaoShiType.HA &&
                   Helmet.BaoShiDic[3].BaoShiType == BaoShiType.HA && Helmet.BaoShiDic[4].BaoShiType == BaoShiType.HA &&
                   Helmet.BaoShiDic[5].BaoShiType == BaoShiType.HA)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.NecklaceId != 0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           if (Necklace.BaoShiDic.Count >= 5)
           {
               if (Necklace.BaoShiDic[1].BaoShiType == BaoShiType.HA && Necklace.BaoShiDic[2].BaoShiType == BaoShiType.HA &&
                   Necklace.BaoShiDic[3].BaoShiType == BaoShiType.HA && Necklace.BaoShiDic[4].BaoShiType == BaoShiType.HA &&
                   Necklace.BaoShiDic[5].BaoShiType == BaoShiType.HA)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.RingId != 0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           if (Ring.BaoShiDic.Count >= 5)
           {
               if (Ring.BaoShiDic[1].BaoShiType == BaoShiType.HA && Ring.BaoShiDic[2].BaoShiType == BaoShiType.HA &&
                   Ring.BaoShiDic[3].BaoShiType == BaoShiType.HA && Ring.BaoShiDic[4].BaoShiType == BaoShiType.HA &&
                   Ring.BaoShiDic[5].BaoShiType == BaoShiType.HA)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ShoeId != 0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           if (Shoe.BaoShiDic.Count >= 5)
           {
               if (Shoe.BaoShiDic[1].BaoShiType == BaoShiType.HA && Shoe.BaoShiDic[2].BaoShiType == BaoShiType.HA &&
                   Shoe.BaoShiDic[3].BaoShiType == BaoShiType.HA && Shoe.BaoShiDic[4].BaoShiType == BaoShiType.HA &&
                   Shoe.BaoShiDic[5].BaoShiType == BaoShiType.HA)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ClothId != 0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           if (Cloth.BaoShiDic.Count >= 5)
           {
               if (Cloth.BaoShiDic[1].BaoShiType == BaoShiType.HA && Cloth.BaoShiDic[2].BaoShiType == BaoShiType.HA &&
                   Cloth.BaoShiDic[3].BaoShiType == BaoShiType.HA && Cloth.BaoShiDic[4].BaoShiType == BaoShiType.HA &&
                   Cloth.BaoShiDic[5].BaoShiType == BaoShiType.HA)
               {
                   value++;
               }
           }
       }

       return value;
   }
   
   
   public static int GetHC5Count()
   {
       int value = 0;
       if (PlayerEquipConfig.CloakId != 0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           if (Cloak.BaoShiDic.Count >= 5)
           {
               if (Cloak.BaoShiDic[1].BaoShiType == BaoShiType.HC && Cloak.BaoShiDic[2].BaoShiType == BaoShiType.HC &&
                   Cloak.BaoShiDic[3].BaoShiType == BaoShiType.HC && Cloak.BaoShiDic[4].BaoShiType == BaoShiType.HC &&
                   Cloak.BaoShiDic[5].BaoShiType == BaoShiType.HC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.HelmetId != 0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           if (Helmet.BaoShiDic.Count >= 5)
           {
               if (Helmet.BaoShiDic[1].BaoShiType == BaoShiType.HC && Helmet.BaoShiDic[2].BaoShiType == BaoShiType.HC &&
                   Helmet.BaoShiDic[3].BaoShiType == BaoShiType.HC && Helmet.BaoShiDic[4].BaoShiType == BaoShiType.HC &&
                   Helmet.BaoShiDic[5].BaoShiType == BaoShiType.HC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.NecklaceId != 0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           if (Necklace.BaoShiDic.Count >= 5)
           {
               if (Necklace.BaoShiDic[1].BaoShiType == BaoShiType.HC && Necklace.BaoShiDic[2].BaoShiType == BaoShiType.HC &&
                   Necklace.BaoShiDic[3].BaoShiType == BaoShiType.HC && Necklace.BaoShiDic[4].BaoShiType == BaoShiType.HC &&
                   Necklace.BaoShiDic[5].BaoShiType == BaoShiType.HC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.RingId != 0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           if (Ring.BaoShiDic.Count >= 5)
           {
               if (Ring.BaoShiDic[1].BaoShiType == BaoShiType.HC && Ring.BaoShiDic[2].BaoShiType == BaoShiType.HC &&
                   Ring.BaoShiDic[3].BaoShiType == BaoShiType.HC && Ring.BaoShiDic[4].BaoShiType == BaoShiType.HC &&
                   Ring.BaoShiDic[5].BaoShiType == BaoShiType.HC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ShoeId != 0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           if (Shoe.BaoShiDic.Count >= 5)
           {
               if (Shoe.BaoShiDic[1].BaoShiType == BaoShiType.HC && Shoe.BaoShiDic[2].BaoShiType == BaoShiType.HC &&
                   Shoe.BaoShiDic[3].BaoShiType == BaoShiType.HC && Shoe.BaoShiDic[4].BaoShiType == BaoShiType.HC &&
                   Shoe.BaoShiDic[5].BaoShiType == BaoShiType.HC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ClothId != 0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           if (Cloth.BaoShiDic.Count >= 5)
           {
               if (Cloth.BaoShiDic[1].BaoShiType == BaoShiType.HC && Cloth.BaoShiDic[2].BaoShiType == BaoShiType.HC &&
                   Cloth.BaoShiDic[3].BaoShiType == BaoShiType.HC && Cloth.BaoShiDic[4].BaoShiType == BaoShiType.HC &&
                   Cloth.BaoShiDic[5].BaoShiType == BaoShiType.HC)
               {
                   value++;
               }
           }
       }

       return value;
   }
   
   
   
   public static int GetHD5Count()
   {
       int value = 0;
       if (PlayerEquipConfig.CloakId != 0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           if (Cloak.BaoShiDic.Count >= 5)
           {
               if (Cloak.BaoShiDic[1].BaoShiType == BaoShiType.HD && Cloak.BaoShiDic[2].BaoShiType == BaoShiType.HD &&
                   Cloak.BaoShiDic[3].BaoShiType == BaoShiType.HD && Cloak.BaoShiDic[4].BaoShiType == BaoShiType.HD &&
                   Cloak.BaoShiDic[5].BaoShiType == BaoShiType.HD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.HelmetId != 0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           if (Helmet.BaoShiDic.Count >= 5)
           {
               if (Helmet.BaoShiDic[1].BaoShiType == BaoShiType.HD && Helmet.BaoShiDic[2].BaoShiType == BaoShiType.HD &&
                   Helmet.BaoShiDic[3].BaoShiType == BaoShiType.HD && Helmet.BaoShiDic[4].BaoShiType == BaoShiType.HD &&
                   Helmet.BaoShiDic[5].BaoShiType == BaoShiType.HD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.NecklaceId != 0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           if (Necklace.BaoShiDic.Count >= 5)
           {
               if (Necklace.BaoShiDic[1].BaoShiType == BaoShiType.HD && Necklace.BaoShiDic[2].BaoShiType == BaoShiType.HD &&
                   Necklace.BaoShiDic[3].BaoShiType == BaoShiType.HD && Necklace.BaoShiDic[4].BaoShiType == BaoShiType.HD &&
                   Necklace.BaoShiDic[5].BaoShiType == BaoShiType.HD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.RingId != 0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           if (Ring.BaoShiDic.Count >= 5)
           {
               if (Ring.BaoShiDic[1].BaoShiType == BaoShiType.HD && Ring.BaoShiDic[2].BaoShiType == BaoShiType.HD &&
                   Ring.BaoShiDic[3].BaoShiType == BaoShiType.HD && Ring.BaoShiDic[4].BaoShiType == BaoShiType.HD &&
                   Ring.BaoShiDic[5].BaoShiType == BaoShiType.HD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ShoeId != 0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           if (Shoe.BaoShiDic.Count >= 5)
           {
               if (Shoe.BaoShiDic[1].BaoShiType == BaoShiType.HD && Shoe.BaoShiDic[2].BaoShiType == BaoShiType.HD &&
                   Shoe.BaoShiDic[3].BaoShiType == BaoShiType.HD && Shoe.BaoShiDic[4].BaoShiType == BaoShiType.HD &&
                   Shoe.BaoShiDic[5].BaoShiType == BaoShiType.HD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ClothId != 0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           if (Cloth.BaoShiDic.Count >= 5)
           {
               if (Cloth.BaoShiDic[1].BaoShiType == BaoShiType.HD && Cloth.BaoShiDic[2].BaoShiType == BaoShiType.HD &&
                   Cloth.BaoShiDic[3].BaoShiType == BaoShiType.HD && Cloth.BaoShiDic[4].BaoShiType == BaoShiType.HD &&
                   Cloth.BaoShiDic[5].BaoShiType == BaoShiType.HD)
               {
                   value++;
               }
           }
       }

       return value;
   }
   
   
   
   
   public static int GetAA5Count()
   {
       int value = 0;
       if (PlayerEquipConfig.CloakId != 0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           if (Cloak.BaoShiDic.Count >= 5)
           {
               if (Cloak.BaoShiDic[1].BaoShiType == BaoShiType.AA && Cloak.BaoShiDic[2].BaoShiType == BaoShiType.AA &&
                   Cloak.BaoShiDic[3].BaoShiType == BaoShiType.AA && Cloak.BaoShiDic[4].BaoShiType == BaoShiType.AA &&
                   Cloak.BaoShiDic[5].BaoShiType == BaoShiType.AA)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.HelmetId != 0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           if (Helmet.BaoShiDic.Count >= 5)
           {
               if (Helmet.BaoShiDic[1].BaoShiType == BaoShiType.AA && Helmet.BaoShiDic[2].BaoShiType == BaoShiType.AA &&
                   Helmet.BaoShiDic[3].BaoShiType == BaoShiType.AA && Helmet.BaoShiDic[4].BaoShiType == BaoShiType.AA &&
                   Helmet.BaoShiDic[5].BaoShiType == BaoShiType.AA)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.NecklaceId != 0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           if (Necklace.BaoShiDic.Count >= 5)
           {
               if (Necklace.BaoShiDic[1].BaoShiType == BaoShiType.AA && Necklace.BaoShiDic[2].BaoShiType == BaoShiType.AA &&
                   Necklace.BaoShiDic[3].BaoShiType == BaoShiType.AA && Necklace.BaoShiDic[4].BaoShiType == BaoShiType.AA &&
                   Necklace.BaoShiDic[5].BaoShiType == BaoShiType.AA)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.RingId != 0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           if (Ring.BaoShiDic.Count >= 5)
           {
               if (Ring.BaoShiDic[1].BaoShiType == BaoShiType.AA && Ring.BaoShiDic[2].BaoShiType == BaoShiType.AA &&
                   Ring.BaoShiDic[3].BaoShiType == BaoShiType.AA && Ring.BaoShiDic[4].BaoShiType == BaoShiType.AA &&
                   Ring.BaoShiDic[5].BaoShiType == BaoShiType.AA)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ShoeId != 0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           if (Shoe.BaoShiDic.Count >= 5)
           {
               if (Shoe.BaoShiDic[1].BaoShiType == BaoShiType.AA && Shoe.BaoShiDic[2].BaoShiType == BaoShiType.AA &&
                   Shoe.BaoShiDic[3].BaoShiType == BaoShiType.AA && Shoe.BaoShiDic[4].BaoShiType == BaoShiType.AA &&
                   Shoe.BaoShiDic[5].BaoShiType == BaoShiType.AA)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ClothId != 0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           if (Cloth.BaoShiDic.Count >= 5)
           {
               if (Cloth.BaoShiDic[1].BaoShiType == BaoShiType.AA && Cloth.BaoShiDic[2].BaoShiType == BaoShiType.AA &&
                   Cloth.BaoShiDic[3].BaoShiType == BaoShiType.AA && Cloth.BaoShiDic[4].BaoShiType == BaoShiType.AA &&
                   Cloth.BaoShiDic[5].BaoShiType == BaoShiType.AA)
               {
                   value++;
               }
           }
       }

       return value;
   }
   
   
   
   
   public static int GetAC5Count()
   {
       int value = 0;
       if (PlayerEquipConfig.CloakId != 0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           if (Cloak.BaoShiDic.Count >= 5)
           {
               if (Cloak.BaoShiDic[1].BaoShiType == BaoShiType.AC && Cloak.BaoShiDic[2].BaoShiType == BaoShiType.AC &&
                   Cloak.BaoShiDic[3].BaoShiType == BaoShiType.AC && Cloak.BaoShiDic[4].BaoShiType == BaoShiType.AC &&
                   Cloak.BaoShiDic[5].BaoShiType == BaoShiType.AC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.HelmetId != 0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           if (Helmet.BaoShiDic.Count >= 5)
           {
               if (Helmet.BaoShiDic[1].BaoShiType == BaoShiType.AC && Helmet.BaoShiDic[2].BaoShiType == BaoShiType.AC &&
                   Helmet.BaoShiDic[3].BaoShiType == BaoShiType.AC && Helmet.BaoShiDic[4].BaoShiType == BaoShiType.AC &&
                   Helmet.BaoShiDic[5].BaoShiType == BaoShiType.AC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.NecklaceId != 0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           if (Necklace.BaoShiDic.Count >= 5)
           {
               if (Necklace.BaoShiDic[1].BaoShiType == BaoShiType.AC && Necklace.BaoShiDic[2].BaoShiType == BaoShiType.AC &&
                   Necklace.BaoShiDic[3].BaoShiType == BaoShiType.AC && Necklace.BaoShiDic[4].BaoShiType == BaoShiType.AC &&
                   Necklace.BaoShiDic[5].BaoShiType == BaoShiType.AC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.RingId != 0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           if (Ring.BaoShiDic.Count >= 5)
           {
               if (Ring.BaoShiDic[1].BaoShiType == BaoShiType.AC && Ring.BaoShiDic[2].BaoShiType == BaoShiType.AC &&
                   Ring.BaoShiDic[3].BaoShiType == BaoShiType.AC && Ring.BaoShiDic[4].BaoShiType == BaoShiType.AC &&
                   Ring.BaoShiDic[5].BaoShiType == BaoShiType.AC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ShoeId != 0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           if (Shoe.BaoShiDic.Count >= 5)
           {
               if (Shoe.BaoShiDic[1].BaoShiType == BaoShiType.AC && Shoe.BaoShiDic[2].BaoShiType == BaoShiType.AC &&
                   Shoe.BaoShiDic[3].BaoShiType == BaoShiType.AC && Shoe.BaoShiDic[4].BaoShiType == BaoShiType.AC &&
                   Shoe.BaoShiDic[5].BaoShiType == BaoShiType.AC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ClothId != 0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           if (Cloth.BaoShiDic.Count >= 5)
           {
               if (Cloth.BaoShiDic[1].BaoShiType == BaoShiType.AC && Cloth.BaoShiDic[2].BaoShiType == BaoShiType.AC &&
                   Cloth.BaoShiDic[3].BaoShiType == BaoShiType.AC && Cloth.BaoShiDic[4].BaoShiType == BaoShiType.AC &&
                   Cloth.BaoShiDic[5].BaoShiType == BaoShiType.AC)
               {
                   value++;
               }
           }
       }

       return value;
   }
   
   
   
   
   public static int GetAD5Count()
   {
       int value = 0;
       if (PlayerEquipConfig.CloakId != 0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           if (Cloak.BaoShiDic.Count >= 5)
           {
               if (Cloak.BaoShiDic[1].BaoShiType == BaoShiType.AD && Cloak.BaoShiDic[2].BaoShiType == BaoShiType.AD &&
                   Cloak.BaoShiDic[3].BaoShiType == BaoShiType.AD && Cloak.BaoShiDic[4].BaoShiType == BaoShiType.AD &&
                   Cloak.BaoShiDic[5].BaoShiType == BaoShiType.AD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.HelmetId != 0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           if (Helmet.BaoShiDic.Count >= 5)
           {
               if (Helmet.BaoShiDic[1].BaoShiType == BaoShiType.AD && Helmet.BaoShiDic[2].BaoShiType == BaoShiType.AD &&
                   Helmet.BaoShiDic[3].BaoShiType == BaoShiType.AD && Helmet.BaoShiDic[4].BaoShiType == BaoShiType.AD &&
                   Helmet.BaoShiDic[5].BaoShiType == BaoShiType.AD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.NecklaceId != 0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           if (Necklace.BaoShiDic.Count >= 5)
           {
               if (Necklace.BaoShiDic[1].BaoShiType == BaoShiType.AD && Necklace.BaoShiDic[2].BaoShiType == BaoShiType.AD &&
                   Necklace.BaoShiDic[3].BaoShiType == BaoShiType.AD && Necklace.BaoShiDic[4].BaoShiType == BaoShiType.AD &&
                   Necklace.BaoShiDic[5].BaoShiType == BaoShiType.AD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.RingId != 0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           if (Ring.BaoShiDic.Count >= 5)
           {
               if (Ring.BaoShiDic[1].BaoShiType == BaoShiType.AD && Ring.BaoShiDic[2].BaoShiType == BaoShiType.AD &&
                   Ring.BaoShiDic[3].BaoShiType == BaoShiType.AD && Ring.BaoShiDic[4].BaoShiType == BaoShiType.AD &&
                   Ring.BaoShiDic[5].BaoShiType == BaoShiType.AD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ShoeId != 0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           if (Shoe.BaoShiDic.Count >= 5)
           {
               if (Shoe.BaoShiDic[1].BaoShiType == BaoShiType.AD && Shoe.BaoShiDic[2].BaoShiType == BaoShiType.AD &&
                   Shoe.BaoShiDic[3].BaoShiType == BaoShiType.AD && Shoe.BaoShiDic[4].BaoShiType == BaoShiType.AD &&
                   Shoe.BaoShiDic[5].BaoShiType == BaoShiType.AD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ClothId != 0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           if (Cloth.BaoShiDic.Count >= 5)
           {
               if (Cloth.BaoShiDic[1].BaoShiType == BaoShiType.AD && Cloth.BaoShiDic[2].BaoShiType == BaoShiType.AD &&
                   Cloth.BaoShiDic[3].BaoShiType == BaoShiType.AD && Cloth.BaoShiDic[4].BaoShiType == BaoShiType.AD &&
                   Cloth.BaoShiDic[5].BaoShiType == BaoShiType.AD)
               {
                   value++;
               }
           }
       }

       return value;
   }
   
   
   
   
   public static int GetCC5Count()
   {
       int value = 0;
       if (PlayerEquipConfig.CloakId != 0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           if (Cloak.BaoShiDic.Count >= 5)
           {
               if (Cloak.BaoShiDic[1].BaoShiType == BaoShiType.CC && Cloak.BaoShiDic[2].BaoShiType == BaoShiType.CC &&
                   Cloak.BaoShiDic[3].BaoShiType == BaoShiType.CC && Cloak.BaoShiDic[4].BaoShiType == BaoShiType.CC &&
                   Cloak.BaoShiDic[5].BaoShiType == BaoShiType.CC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.HelmetId != 0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           if (Helmet.BaoShiDic.Count >= 5)
           {
               if (Helmet.BaoShiDic[1].BaoShiType == BaoShiType.CC && Helmet.BaoShiDic[2].BaoShiType == BaoShiType.CC &&
                   Helmet.BaoShiDic[3].BaoShiType == BaoShiType.CC && Helmet.BaoShiDic[4].BaoShiType == BaoShiType.CC &&
                   Helmet.BaoShiDic[5].BaoShiType == BaoShiType.CC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.NecklaceId != 0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           if (Necklace.BaoShiDic.Count >= 5)
           {
               if (Necklace.BaoShiDic[1].BaoShiType == BaoShiType.CC && Necklace.BaoShiDic[2].BaoShiType == BaoShiType.CC &&
                   Necklace.BaoShiDic[3].BaoShiType == BaoShiType.CC && Necklace.BaoShiDic[4].BaoShiType == BaoShiType.CC &&
                   Necklace.BaoShiDic[5].BaoShiType == BaoShiType.CC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.RingId != 0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           if (Ring.BaoShiDic.Count >= 5)
           {
               if (Ring.BaoShiDic[1].BaoShiType == BaoShiType.CC && Ring.BaoShiDic[2].BaoShiType == BaoShiType.CC &&
                   Ring.BaoShiDic[3].BaoShiType == BaoShiType.CC && Ring.BaoShiDic[4].BaoShiType == BaoShiType.CC &&
                   Ring.BaoShiDic[5].BaoShiType == BaoShiType.CC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ShoeId != 0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           if (Shoe.BaoShiDic.Count >= 5)
           {
               if (Shoe.BaoShiDic[1].BaoShiType == BaoShiType.CC && Shoe.BaoShiDic[2].BaoShiType == BaoShiType.CC &&
                   Shoe.BaoShiDic[3].BaoShiType == BaoShiType.CC && Shoe.BaoShiDic[4].BaoShiType == BaoShiType.CC &&
                   Shoe.BaoShiDic[5].BaoShiType == BaoShiType.CC)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ClothId != 0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           if (Cloth.BaoShiDic.Count >= 5)
           {
               if (Cloth.BaoShiDic[1].BaoShiType == BaoShiType.CC && Cloth.BaoShiDic[2].BaoShiType == BaoShiType.CC &&
                   Cloth.BaoShiDic[3].BaoShiType == BaoShiType.CC && Cloth.BaoShiDic[4].BaoShiType == BaoShiType.CC &&
                   Cloth.BaoShiDic[5].BaoShiType == BaoShiType.CC)
               {
                   value++;
               }
           }
       }

       return value;
   }
   
   
   
   
   public static int GetCD5Count()
   {
       int value = 0;
       if (PlayerEquipConfig.CloakId != 0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           if (Cloak.BaoShiDic.Count >= 5)
           {
               if (Cloak.BaoShiDic[1].BaoShiType == BaoShiType.CD && Cloak.BaoShiDic[2].BaoShiType == BaoShiType.CD &&
                   Cloak.BaoShiDic[3].BaoShiType == BaoShiType.CD && Cloak.BaoShiDic[4].BaoShiType == BaoShiType.CD &&
                   Cloak.BaoShiDic[5].BaoShiType == BaoShiType.CD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.HelmetId != 0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           if (Helmet.BaoShiDic.Count >= 5)
           {
               if (Helmet.BaoShiDic[1].BaoShiType == BaoShiType.CD && Helmet.BaoShiDic[2].BaoShiType == BaoShiType.CD &&
                   Helmet.BaoShiDic[3].BaoShiType == BaoShiType.CD && Helmet.BaoShiDic[4].BaoShiType == BaoShiType.CD &&
                   Helmet.BaoShiDic[5].BaoShiType == BaoShiType.CD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.NecklaceId != 0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           if (Necklace.BaoShiDic.Count >= 5)
           {
               if (Necklace.BaoShiDic[1].BaoShiType == BaoShiType.CD && Necklace.BaoShiDic[2].BaoShiType == BaoShiType.CD &&
                   Necklace.BaoShiDic[3].BaoShiType == BaoShiType.CD && Necklace.BaoShiDic[4].BaoShiType == BaoShiType.CD &&
                   Necklace.BaoShiDic[5].BaoShiType == BaoShiType.CD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.RingId != 0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           if (Ring.BaoShiDic.Count >= 5)
           {
               if (Ring.BaoShiDic[1].BaoShiType == BaoShiType.CD && Ring.BaoShiDic[2].BaoShiType == BaoShiType.CD &&
                   Ring.BaoShiDic[3].BaoShiType == BaoShiType.CD && Ring.BaoShiDic[4].BaoShiType == BaoShiType.CD &&
                   Ring.BaoShiDic[5].BaoShiType == BaoShiType.CD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ShoeId != 0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           if (Shoe.BaoShiDic.Count >= 5)
           {
               if (Shoe.BaoShiDic[1].BaoShiType == BaoShiType.CD && Shoe.BaoShiDic[2].BaoShiType == BaoShiType.CD &&
                   Shoe.BaoShiDic[3].BaoShiType == BaoShiType.CD && Shoe.BaoShiDic[4].BaoShiType == BaoShiType.CD &&
                   Shoe.BaoShiDic[5].BaoShiType == BaoShiType.CD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ClothId != 0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           if (Cloth.BaoShiDic.Count >= 5)
           {
               if (Cloth.BaoShiDic[1].BaoShiType == BaoShiType.CD && Cloth.BaoShiDic[2].BaoShiType == BaoShiType.CD &&
                   Cloth.BaoShiDic[3].BaoShiType == BaoShiType.CD && Cloth.BaoShiDic[4].BaoShiType == BaoShiType.CD &&
                   Cloth.BaoShiDic[5].BaoShiType == BaoShiType.CD)
               {
                   value++;
               }
           }
       }

       return value;
   }
   
   
   
   
   public static int GetDD5Count()
   {
       int value = 0;
       if (PlayerEquipConfig.CloakId != 0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           if (Cloak.BaoShiDic.Count >= 5)
           {
               if (Cloak.BaoShiDic[1].BaoShiType == BaoShiType.DD && Cloak.BaoShiDic[2].BaoShiType == BaoShiType.DD &&
                   Cloak.BaoShiDic[3].BaoShiType == BaoShiType.DD && Cloak.BaoShiDic[4].BaoShiType == BaoShiType.DD &&
                   Cloak.BaoShiDic[5].BaoShiType == BaoShiType.DD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.HelmetId != 0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           if (Helmet.BaoShiDic.Count >= 5)
           {
               if (Helmet.BaoShiDic[1].BaoShiType == BaoShiType.DD && Helmet.BaoShiDic[2].BaoShiType == BaoShiType.DD &&
                   Helmet.BaoShiDic[3].BaoShiType == BaoShiType.DD && Helmet.BaoShiDic[4].BaoShiType == BaoShiType.DD &&
                   Helmet.BaoShiDic[5].BaoShiType == BaoShiType.DD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.NecklaceId != 0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           if (Necklace.BaoShiDic.Count >= 5)
           {
               if (Necklace.BaoShiDic[1].BaoShiType == BaoShiType.DD && Necklace.BaoShiDic[2].BaoShiType == BaoShiType.DD &&
                   Necklace.BaoShiDic[3].BaoShiType == BaoShiType.DD && Necklace.BaoShiDic[4].BaoShiType == BaoShiType.DD &&
                   Necklace.BaoShiDic[5].BaoShiType == BaoShiType.DD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.RingId != 0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           if (Ring.BaoShiDic.Count >= 5)
           {
               if (Ring.BaoShiDic[1].BaoShiType == BaoShiType.DD && Ring.BaoShiDic[2].BaoShiType == BaoShiType.DD &&
                   Ring.BaoShiDic[3].BaoShiType == BaoShiType.DD && Ring.BaoShiDic[4].BaoShiType == BaoShiType.DD &&
                   Ring.BaoShiDic[5].BaoShiType == BaoShiType.DD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ShoeId != 0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           if (Shoe.BaoShiDic.Count >= 5)
           {
               if (Shoe.BaoShiDic[1].BaoShiType == BaoShiType.DD && Shoe.BaoShiDic[2].BaoShiType == BaoShiType.DD &&
                   Shoe.BaoShiDic[3].BaoShiType == BaoShiType.DD && Shoe.BaoShiDic[4].BaoShiType == BaoShiType.DD &&
                   Shoe.BaoShiDic[5].BaoShiType == BaoShiType.DD)
               {
                   value++;
               }
           }
       }
       
       if (PlayerEquipConfig.ClothId != 0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           if (Cloth.BaoShiDic.Count >= 5)
           {
               if (Cloth.BaoShiDic[1].BaoShiType == BaoShiType.DD && Cloth.BaoShiDic[2].BaoShiType == BaoShiType.DD &&
                   Cloth.BaoShiDic[3].BaoShiType == BaoShiType.DD && Cloth.BaoShiDic[4].BaoShiType == BaoShiType.DD &&
                   Cloth.BaoShiDic[5].BaoShiType == BaoShiType.DD)
               {
                   value++;
               }
           }
       }

       return value;
   }
   
   
   
   
   
   public static int GetBaoShiTeXiao3Count()
   {
       int value = 0;
       if (PlayerEquipConfig.CloakId != 0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           if (Cloak.BaoShiDic.Count >= 3)
           {
               int HHCount = 0;
               int HACount = 0;
               int HCCount = 0;
               int HDCount = 0;
               int AACount = 0;
               int ACCount = 0;
               int ADCount = 0;
               int CCCount = 0;
               int CDCount = 0;
               int DDCount = 0;
                foreach (var baoshi in Cloak.BaoShiDic)
                {
                    switch (baoshi.Value.BaoShiType)
                    {
                        case BaoShiType.HH:
                            HHCount++;
                            break;
                        case BaoShiType.HA:
                            HACount++;
                            break;
                        case BaoShiType.HC:
                            HCCount++;
                            break;
                        case BaoShiType.HD:
                            HDCount++;
                            break;
                        case BaoShiType.AA:
                            AACount++;
                            break;
                        case BaoShiType.AC:
                            ACCount++;
                            break;
                        case BaoShiType.AD:
                            ADCount++;
                            break;
                        case BaoShiType.CC:
                            CCCount++;
                            break;
                        case BaoShiType.CD:
                            CDCount++;
                            break;
                        case BaoShiType.DD:
                            DDCount++;
                            break;
                    }
                }

                if (HHCount >= 3 || HACount >= 3 || HCCount >= 3 || HDCount >= 3 || AACount >= 3 || ACCount >= 3 ||
                    ADCount >= 3 || CCCount >= 3 || CDCount >= 3 || DDCount >= 3)
                {
                    value++;
                }
           }
       }
       
       
       
       
       
       if (PlayerEquipConfig.HelmetId != 0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           if (Helmet.BaoShiDic.Count >= 3)
           {
               int HHCount = 0;
               int HACount = 0;
               int HCCount = 0;
               int HDCount = 0;
               int AACount = 0;
               int ACCount = 0;
               int ADCount = 0;
               int CCCount = 0;
               int CDCount = 0;
               int DDCount = 0;
                foreach (var baoshi in Helmet.BaoShiDic)
                {
                    switch (baoshi.Value.BaoShiType)
                    {
                        case BaoShiType.HH:
                            HHCount++;
                            break;
                        case BaoShiType.HA:
                            HACount++;
                            break;
                        case BaoShiType.HC:
                            HCCount++;
                            break;
                        case BaoShiType.HD:
                            HDCount++;
                            break;
                        case BaoShiType.AA:
                            AACount++;
                            break;
                        case BaoShiType.AC:
                            ACCount++;
                            break;
                        case BaoShiType.AD:
                            ADCount++;
                            break;
                        case BaoShiType.CC:
                            CCCount++;
                            break;
                        case BaoShiType.CD:
                            CDCount++;
                            break;
                        case BaoShiType.DD:
                            DDCount++;
                            break;
                    }
                }

                if (HHCount >= 3 || HACount >= 3 || HCCount >= 3 || HDCount >= 3 || AACount >= 3 || ACCount >= 3 ||
                    ADCount >= 3 || CCCount >= 3 || CDCount >= 3 || DDCount >= 3)
                {
                    value++;
                }
           }
       }
       
       
       
       
       if (PlayerEquipConfig.ClothId != 0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           if (Cloth.BaoShiDic.Count >= 3)
           {
               int HHCount = 0;
               int HACount = 0;
               int HCCount = 0;
               int HDCount = 0;
               int AACount = 0;
               int ACCount = 0;
               int ADCount = 0;
               int CCCount = 0;
               int CDCount = 0;
               int DDCount = 0;
                foreach (var baoshi in Cloth.BaoShiDic)
                {
                    switch (baoshi.Value.BaoShiType)
                    {
                        case BaoShiType.HH:
                            HHCount++;
                            break;
                        case BaoShiType.HA:
                            HACount++;
                            break;
                        case BaoShiType.HC:
                            HCCount++;
                            break;
                        case BaoShiType.HD:
                            HDCount++;
                            break;
                        case BaoShiType.AA:
                            AACount++;
                            break;
                        case BaoShiType.AC:
                            ACCount++;
                            break;
                        case BaoShiType.AD:
                            ADCount++;
                            break;
                        case BaoShiType.CC:
                            CCCount++;
                            break;
                        case BaoShiType.CD:
                            CDCount++;
                            break;
                        case BaoShiType.DD:
                            DDCount++;
                            break;
                    }
                }

                if (HHCount >= 3 || HACount >= 3 || HCCount >= 3 || HDCount >= 3 || AACount >= 3 || ACCount >= 3 ||
                    ADCount >= 3 || CCCount >= 3 || CDCount >= 3 || DDCount >= 3)
                {
                    value++;
                }
           }
       }
       
       
       
       
       if (PlayerEquipConfig.NecklaceId != 0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           if (Necklace.BaoShiDic.Count >= 3)
           {
               int HHCount = 0;
               int HACount = 0;
               int HCCount = 0;
               int HDCount = 0;
               int AACount = 0;
               int ACCount = 0;
               int ADCount = 0;
               int CCCount = 0;
               int CDCount = 0;
               int DDCount = 0;
                foreach (var baoshi in Necklace.BaoShiDic)
                {
                    switch (baoshi.Value.BaoShiType)
                    {
                        case BaoShiType.HH:
                            HHCount++;
                            break;
                        case BaoShiType.HA:
                            HACount++;
                            break;
                        case BaoShiType.HC:
                            HCCount++;
                            break;
                        case BaoShiType.HD:
                            HDCount++;
                            break;
                        case BaoShiType.AA:
                            AACount++;
                            break;
                        case BaoShiType.AC:
                            ACCount++;
                            break;
                        case BaoShiType.AD:
                            ADCount++;
                            break;
                        case BaoShiType.CC:
                            CCCount++;
                            break;
                        case BaoShiType.CD:
                            CDCount++;
                            break;
                        case BaoShiType.DD:
                            DDCount++;
                            break;
                    }
                }

                if (HHCount >= 3 || HACount >= 3 || HCCount >= 3 || HDCount >= 3 || AACount >= 3 || ACCount >= 3 ||
                    ADCount >= 3 || CCCount >= 3 || CDCount >= 3 || DDCount >= 3)
                {
                    value++;
                }
           }
       }
       
       
       
       
       
       
       
       if (PlayerEquipConfig.RingId != 0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           if (Ring.BaoShiDic.Count >= 3)
           {
               int HHCount = 0;
               int HACount = 0;
               int HCCount = 0;
               int HDCount = 0;
               int AACount = 0;
               int ACCount = 0;
               int ADCount = 0;
               int CCCount = 0;
               int CDCount = 0;
               int DDCount = 0;
                foreach (var baoshi in Ring.BaoShiDic)
                {
                    switch (baoshi.Value.BaoShiType)
                    {
                        case BaoShiType.HH:
                            HHCount++;
                            break;
                        case BaoShiType.HA:
                            HACount++;
                            break;
                        case BaoShiType.HC:
                            HCCount++;
                            break;
                        case BaoShiType.HD:
                            HDCount++;
                            break;
                        case BaoShiType.AA:
                            AACount++;
                            break;
                        case BaoShiType.AC:
                            ACCount++;
                            break;
                        case BaoShiType.AD:
                            ADCount++;
                            break;
                        case BaoShiType.CC:
                            CCCount++;
                            break;
                        case BaoShiType.CD:
                            CDCount++;
                            break;
                        case BaoShiType.DD:
                            DDCount++;
                            break;
                    }
                }

                if (HHCount >= 3 || HACount >= 3 || HCCount >= 3 || HDCount >= 3 || AACount >= 3 || ACCount >= 3 ||
                    ADCount >= 3 || CCCount >= 3 || CDCount >= 3 || DDCount >= 3)
                {
                    value++;
                }
           }
       }
       
       
       
       
       
       if (PlayerEquipConfig.ShoeId != 0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           if (Shoe.BaoShiDic.Count >= 3)
           {
               int HHCount = 0;
               int HACount = 0;
               int HCCount = 0;
               int HDCount = 0;
               int AACount = 0;
               int ACCount = 0;
               int ADCount = 0;
               int CCCount = 0;
               int CDCount = 0;
               int DDCount = 0;
                foreach (var baoshi in Shoe.BaoShiDic)
                {
                    switch (baoshi.Value.BaoShiType)
                    {
                        case BaoShiType.HH:
                            HHCount++;
                            break;
                        case BaoShiType.HA:
                            HACount++;
                            break;
                        case BaoShiType.HC:
                            HCCount++;
                            break;
                        case BaoShiType.HD:
                            HDCount++;
                            break;
                        case BaoShiType.AA:
                            AACount++;
                            break;
                        case BaoShiType.AC:
                            ACCount++;
                            break;
                        case BaoShiType.AD:
                            ADCount++;
                            break;
                        case BaoShiType.CC:
                            CCCount++;
                            break;
                        case BaoShiType.CD:
                            CDCount++;
                            break;
                        case BaoShiType.DD:
                            DDCount++;
                            break;
                    }
                }

                if (HHCount >= 3 || HACount >= 3 || HCCount >= 3 || HDCount >= 3 || AACount >= 3 || ACCount >= 3 ||
                    ADCount >= 3 || CCCount >= 3 || CDCount >= 3 || DDCount >= 3)
                {
                    value++;
                }
           }
       }

       return value;
   }
   
   public static float GetBaoShiAttack()
   {
       float value = 0;
       if(PlayerEquipConfig.CloakId!=0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
         foreach (var baoshi in Cloak.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Attack)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Attack)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.ClothId!=0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           foreach (var baoshi in Cloth.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Attack)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Attack)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.ShoeId!=0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
          foreach (var baoshi in Shoe.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Attack)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Attack)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.RingId!=0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
          foreach (var baoshi in Ring.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Attack)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Attack)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.NecklaceId!=0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
          foreach (var baoshi in Necklace.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Attack)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Attack)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.HelmetId!=0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
          foreach (var baoshi in Helmet.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Attack)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Attack)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }

       value *= (1.0f + BaoShiXiaoGuo);

       return value;
   }
   
   
   
   
   
   
   
   
   
   public static float GetBaoShiCrit()
   {
       float value = 0;
       if(PlayerEquipConfig.CloakId!=0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
         foreach (var baoshi in Cloak.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Crit)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Crit)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.ClothId!=0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           foreach (var baoshi in Cloth.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Crit)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Crit)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.ShoeId!=0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
          foreach (var baoshi in Shoe.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Crit)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Crit)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.RingId!=0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
          foreach (var baoshi in Ring.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Crit)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Crit)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.NecklaceId!=0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
          foreach (var baoshi in Necklace.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Crit)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Crit)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.HelmetId!=0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
          foreach (var baoshi in Helmet.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Crit)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Crit)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       value *= (1.0f + BaoShiXiaoGuo);


       return value;
   }
   
   
   
   
   
   
   
   public static float GetBaoShiDefense()
   {
       float value = 0;
       if(PlayerEquipConfig.CloakId!=0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
         foreach (var baoshi in Cloak.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Defense)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Defense)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.ClothId!=0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           foreach (var baoshi in Cloth.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Defense)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Defense)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.ShoeId!=0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
          foreach (var baoshi in Shoe.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Defense)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Defense)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.RingId!=0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
          foreach (var baoshi in Ring.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Defense)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Defense)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.NecklaceId!=0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
          foreach (var baoshi in Necklace.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Defense)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Defense)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.HelmetId!=0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
          foreach (var baoshi in Helmet.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Defense)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Defense)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       value *= (1.0f + BaoShiXiaoGuo);

       return value;
   }
   
   
   
   
   
   
   
   public static float GetBaoShiHp()
   {
       float value = 0;
       if(PlayerEquipConfig.CloakId!=0)
       {
           var Cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
         foreach (var baoshi in Cloak.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Hp)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Hp)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.ClothId!=0)
       {
           var Cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           foreach (var baoshi in Cloth.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Hp)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Hp)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.ShoeId!=0)
       {
           var Shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
          foreach (var baoshi in Shoe.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Hp)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Hp)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.RingId!=0)
       {
           var Ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
          foreach (var baoshi in Ring.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Hp)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Hp)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.NecklaceId!=0)
       {
           var Necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
          foreach (var baoshi in Necklace.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Hp)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Hp)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       
       if(PlayerEquipConfig.HelmetId!=0)
       {
           var Helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
          foreach (var baoshi in Helmet.BaoShiDic)
           {
               if (baoshi.Value.BaoShiType == BaoShiType.None)
               {
                   continue;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.BaseAttribute ==
                   BaseAttribute.Hp)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem1.Count;
               }
               if (BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.BaseAttribute ==
                   BaseAttribute.Hp)
               {
                   value += BaoShiConfig.BaoShiAttributeDic[baoshi.Value].BaoShiAttributeItem2.Count;
               }
           }
       }
       value *= (1.0f + BaoShiXiaoGuo);

       return value;
   }
   
   
   
   
   
   
   public static float GetMonsterAttack()
   {
       return 0;
   }
   
   public static float GetMonsterDefense()
   {
       return 0;
   }
   
   public static float GetMonsterHp()
   {
       return 0;
   }
   public static float GetWeaponLevel(WeaponType type)
   {
      switch (type)
      {
         case WeaponType.Primary:
            return PlayerData.S.primaryWeaponLevel;
         case WeaponType.PrimaryHuo:
   return PlayerData.S.primaryHuoLevel;
         case WeaponType.PrimaryDian:
            return PlayerData.S.primaryDianLevel;
         case WeaponType.PrimaryHeiAn:
            return PlayerData.S.primaryHeiAnLevel;
         case WeaponType.IceBaoZha:
            return PlayerData.S.iceBaoZhaLevel;
         case WeaponType.DianBaoZha:
            return PlayerData.S.dianBaoZhaLevel;
         case WeaponType.HuoBaoZha:
            return PlayerData.S.HuoBaoZhaWeaponLevel;
         case WeaponType.HeiAnBaoZha:
            return PlayerData.S.HeiAnBaoZhaWeaponLevel;
         case WeaponType.XuKong:
            return PlayerData.S.xuKongWeaponLevel;
         case WeaponType.PuTong3:
            return PlayerData.S.puTong3WeaponLevel;
         case WeaponType.Fire:
            return PlayerData.S.fireWeaponLevel;
         case WeaponType.LvQuan:
            return PlayerData.S.lvQuanWeaponLevel;
         case WeaponType.DianJiSu:
            return PlayerData.S.DianJiSuWeaponLevel;
         case WeaponType.DianSanShe:
            return PlayerData.S.DianSanSheWeaponLevel;
         case WeaponType.Huo7:
            return PlayerData.S.Huo7WeaponLevel;
         case WeaponType.HuoFenLie:
            return PlayerData.S.HuoFenLieWeaponLevel;
         case WeaponType.HeiAnHuiXuan:
            return PlayerData.S.HeiAnHuiXuanWeaponLevel;
         case WeaponType.HeiAnQuXian:
            return PlayerData.S.HeiAnQuXianWeaponLevel;
         case WeaponType.Ice7:
            return PlayerData.S.Ice7WeaponLevel;
         case WeaponType.Ice4BaoZha:
            return PlayerData.S.Ice4BaoZhaWeaponLevel;
         case WeaponType.JianQi:
            return PlayerData.S.jianQiWeaponLevel;
         case WeaponType.HuoDiPen:
            return PlayerData.S.HuoDiPenWeaponLevel;
         case WeaponType.IcePen:
            return PlayerData.S.IcePenWeaponLevel;
         case WeaponType.HeiDong:
            return PlayerData.S.heiDongWeaponLevel;
         case WeaponType.DianLuoLei5:
            return PlayerData.S.DianLuoLei5WeaponLevel;
      }

      return 0;
   }
   
   public static float GetMonsterCrit()
   {
       return 0;
   }
   public static float GetWeaponAttack()
   {
       var weaponAttribute = WeaponConfig.WeaponBaseAttributeDic[PlayerData.S.playerWeaponType];
       float level = GetWeaponLevel(PlayerData.S.playerWeaponType);
       return weaponAttribute.Attack * WeaponConfig.WeaponLevelAttributeDic[level];
   }
   
   public static float GetWeaponDefense()
   {
       var weaponAttribute = WeaponConfig.WeaponBaseAttributeDic[PlayerData.S.playerWeaponType];
       float level = GetWeaponLevel(PlayerData.S.playerWeaponType);
       return weaponAttribute.Defense * WeaponConfig.WeaponLevelAttributeDic[level];
   }
   
   public static float GetWeaponCrit()
   {
       var weaponAttribute = WeaponConfig.WeaponBaseAttributeDic[PlayerData.S.playerWeaponType];
       float level = GetWeaponLevel(PlayerData.S.playerWeaponType);
       return weaponAttribute.Crit * WeaponConfig.WeaponLevelAttributeDic[level];
   }
   
   public static float GetWeaponHp()
   {
       var weaponAttribute = WeaponConfig.WeaponBaseAttributeDic[PlayerData.S.playerWeaponType];
       float level = GetWeaponLevel(PlayerData.S.playerWeaponType);
       return weaponAttribute.Hp * WeaponConfig.WeaponLevelAttributeDic[level];
   }
   
   public static float GetWeaponAttackSpeed()
   {
       var weaponAttribute = WeaponConfig.WeaponBaseAttributeDic[PlayerData.S.playerWeaponType];
       return weaponAttribute.AttackSpeed;
   }
   
   public static void ReplyHp(float value)
   {
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.AllReplyAddPercent))
       {
           value *= 1.2f;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HpReductionReplyAdd50))
       {
           if (QueueController.S.GameCurrentHp <= QueueController.S.GameMaxHp / 0.5f)
           {
               value *= 1.3f;
           }
       }
       QueueController.S.GameCurrentHp+= value;
       QueueController.S.GameCurrentHp=Math.Min(QueueController.S.GameCurrentHp,QueueController.S.GameMaxHp);
   }
   
   public static float BloodEnergy
   {
       get => PlayerData.S.bloodEnergy;
       set => PlayerData.S.bloodEnergy = value;
   }
   //等级相关
   public static int Level
   {
         get => PlayerData.S.level;
         set => PlayerData.S.level = value;
   }

   public static float Exp
   {
         get => PlayerData.S.exp;
         set => PlayerData.S.exp = value;
   }
   public static Dictionary<float,int> ExpDic=new Dictionary<float,int>()
   {
         {1,100 },
         {2,200 },
         {3,300 },
         {4,400 },
         {5,500 },
         {6,700 },
         {7,900 },
         {8,1100 },
         {9,1300 },
         {10,1500 },
         
         
         {11,1800 },
         {12,2100 },
         {13,2400 },
         {14,2700 },
         {15,3000 },
         {16,3500 },
         {17,4000 },
         {18,4500 },
         {19,5000 },
         {20,5500 },
         
         
         {21,6300 },
         {22,7100 },
         {23,7900 },
         {24,8700 },
         {25,9500 },
         {26,10500 },
         {27,11500 },
         {28,12500 },
         {29,13500 },
         {30,14500 },
         
         
         {31,16000 },
         {32,17500 },
         {33,19000 },
         {34,20500 },
         {35,22000 },
         {36,24000 },
         {37,26000 },
         {38,28000 },
         {39,30000 },
         {40,32000 },
         
         {41,35000 },
         {42,38000 },
         {43,41000 },
         {44,43000 },
         {45,46000 },
         {46,50000 },
         {47,55000 },
         {48,60000 },
         {49,65000 },
         {50,70000 },
         
         {51,75000 },
         {52,80000 },
         {53,85000 },
         {54,90000 },
         {55,95000 },
         {56,100000 },
         {57,110000 },
         {58,120000 },
         {59,130000 },
         {60,140000 },
         
         {61,150000 },
         {62,160000 },
         {63,170000 },
         {64,180000 },
         {65,190000 },
         {66,200000 },
         {67,210000 },
         {68,220000 },
         {69,230000 },
         {70,240000 },
         
         {71,250000 },
         {72,260000 },
         {73,270000 },
         {74,280000 },
         {75,290000 },
         {76,300000 },
         {77,320000 },
         {78,340000 },
         {79,360000 },
         {80,380000 },
         
         {81,400000 },
         {82,420000 },
         {83,440000 },
         {84,460000 },
         {85,480000 },
         {86,500000 },
         {87,520000 },
         {88,540000 },
         {89,560000 },
         {90,580000 },
         
         {91,600000 },
         {92,650000 },
         {93,700000 },
         {94,750000 },
         {95,800000 },
         {96,850000 },
         {97,900000 },
         {98,950000 },
         {99,1000000 },
         {100,1000000 },
   };

   public static int GameLevel
   {
            get => PlayerData.S.maxGameLevel;
            set => PlayerData.S.maxGameLevel = value;
   }
   
   //人物属性,默认属性

   public static float Forture => GetForture();
   public static int PlayerMaxHp
   {
       get => PlayerInfoConfig.GetPlayerMaxHp();
   }

   public static int PlayerDamage
   {
       get => PlayerInfoConfig.GetPlayerAttack();
   }
   
   public static float _baseMoveSpeed = 2.5f;

   public static float PlayerMoveSpeed
   {
       get => GetPlayerMoveSpeed();
       set => _baseMoveSpeed = value ; 
   }

   public static int PlayerCRIT=0;
   public static int PlayerDefense
   {
       get => PlayerInfoConfig.GetPlayerDenfence();
   }
   
   //装备属性
   public static float EquipMaxHp
   {
       get => GetEquipMaxHp();
   }

   public static float EquipDamage
   {
       get => GetEquipDamage();
   }
   
   public static float EquipCRIT
   {
       get => GetEquipCRIT();
   }

   public static float EquipDefense
   {
       get => GetEquipDefense();
   }
   
   
   //收藏室属性
   public static ShouCangShiAttribute ShouCangShiAttribute=>GetShouCangShiAttribute();

   public static ShouCangShiAttribute GetShouCangShiAttribute()
   {
       ShouCangShiAttribute shouCangShiAttribute = new ShouCangShiAttribute();
       int count = 0;
       foreach (var item in PlayerData.S.ShouCangShiEquipDic)
       {
           if (item.Value)
           {
               count += ShouCangShiConfig.ShouCangShiQualityCountDic[5];
           }
       }
      
       foreach (var item in PlayerData.S.ShouCangShiChongWu)
       {
           if (item.Value)
           {
               int quality = ChongWuConfig.GetChongWuQualityByType(item.Key);
               count += ShouCangShiConfig.ShouCangShiQualityCountDic[quality];
           }
       }
      
      
       foreach (var item in PlayerData.S.ShouCangShiChiBangDic)
       {
           if (item.Value)
           {
               int quality = ChiBangConfig.GetChiBangQuality(item.Key);
               count += ShouCangShiConfig.ShouCangShiQualityCountDic[quality];
           }
       }

       int level = count / 10;
       shouCangShiAttribute.Attack = level * ShouCangShiConfig.BaseAttack;
       shouCangShiAttribute.Defense = level * ShouCangShiConfig.BaseDefense;
       shouCangShiAttribute.Hp = level * ShouCangShiConfig.BaseHp;
       shouCangShiAttribute.Crit = level * ShouCangShiConfig.BaseCrit;
       return shouCangShiAttribute;
   }
   
   
   
   
   //总属性
   
   //基础属性
   public static float TotalMaxHp => GetTotalMaxHp();
   public static float TotalCritDamage => GetTotalCritDamage();
   public static float TotalDamage => GetTotalDamage();
   
   public static float TotalCRIT =>GetTotalCrit();
   public static float TotalDefense => GetTotalDefense();
   public static float TotalAttackSpeed => GetTotalAttackSpeed();

   public static float GetTotalAttackSpeed()
   {
       var weaponAttribute = WeaponConfig.WeaponBaseAttributeDic[PlayerData.S.playerWeaponType];
       var value = (weaponAttribute.AttackSpeed  + HunQiAttackSpeed);
       value += FinalChongWuAttribute.AttackSpeed;
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.AddAttackSpeedEntry))
       {
           value += 0.3f;
       }
       value *= (1  + FuJiaDamageSpeed / 100.0f);
       value *= (1  + ShiZhuangAttackSpeed / 100.0f);
       return value;
   }

   public static float GetTotalCrit()
   {
       float value=(PlayerCRIT + EquipCRIT+WeaponCrit+MonsterCrit+TitleAttributeAll.Crit+PlayerData.S.ChiBangCrit);
       value += FinalChongWuAttribute.Crit;
       value+=ShouCangShiAttribute.Crit;
       value *= (1 ) * (1.0f + BaoShiCrit / 100) * (1.0f + TitleAttributeAll.AllBaseAttribute);
       if (CDTeXiao5Time > 0)
       {
           value *= (1.0f + CD5Count * 0.3f);
       }

       return value;
   }

   public static float GetForture()
   {
       float forture = 0;
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.CloakFortureAdd))
       {
           forture += 0.3f;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.ClothFortureAdd))
       {
           forture += 0.3f;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.ShoeFortureAdd))
       {
           forture += 0.3f;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.NecklaceFortureAdd))
       {
           forture += 0.3f;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.RingFortureAdd))
       {
           forture += 0.3f;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HelmetFortureAdd))
       {
           forture += 0.3f;
       }

       forture += HD5Count*0.3f;
       forture += TitleAttributeAll.DiaoLuo;
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Green5)
       {
           forture *= (1.1f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Blue7)
       {
           forture *= (1.15f);
       }
       return forture;
   }
   
   public static float GetPlayerMoveSpeed()
   {
       float speed=(_baseMoveSpeed+TitleAttributeAll.MoveSpeed);
       speed += FinalChongWuAttribute.MoveSpeed;
       speed *= (1+ShiZhuangMoveSpeed/100f);
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.MoveSpeedAdd))
       {
           speed*=1.25f;
       }

       speed *= (1.0f + HA5Count * 0.3f);
       if (PlayerData.S.playerChiBangType == ChiBangType.Green1)
       {
           speed *= (1.05f);
       }
       if (PlayerData.S.playerChiBangType == ChiBangType.Blue5)
       {
           speed *= (1.1f);
       }
       return speed;
   }
   [NonSerialized]public static float CDTeXiao5Time = 0;


   public static float GetTotalCritDamage()
   {
       float value= CRITDamage;
       value += (CC5Count * 50f);
       if (CDTeXiao5Time > 0)
       {
           value += (CD5Count * 30f);
       }
       return value;
   }

   public static float GetTotalMaxHp()
   {
       float maxhp= Mathf.RoundToInt((PlayerMaxHp + EquipMaxHp+WeaponHp+MonsterHp+TitleAttributeAll.Hp+PlayerData.S.ChiBangHp));
       maxhp += FinalChongWuAttribute.Hp;
       maxhp += ShouCangShiAttribute.Hp;
       maxhp *= (1.0f + MaxHpPercent / 100f) * (1.0f + BaoShiHp / 100) * (1.0f + TitleAttributeAll.AllBaseAttribute);
       maxhp *= (1.0f + ShiZhuangAttack / 100f);
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.RecudeHpAddAttack))
       {
           maxhp /= 2;
       }
       return  Mathf.RoundToInt(maxhp);
   }
   
   public static float GetTotalDamage()
   {
       float damage = PlayerDamage + EquipDamage+WeaponAttack+MonsterAttack+TitleAttributeAll.Attack+PlayerData.S.ChiBangAttack;
       damage += FinalChongWuAttribute.Attack;
       damage += ShouCangShiAttribute.Attack;
       damage *= (1f + DamageAddPercent / 100f) * (1.0f + BaoShiAttack / 100) *
                 (1.0f + TitleAttributeAll.AllBaseAttribute);
       damage *= (1.0f + ShiZhuangHp / 100f);
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.RecudeHpAddAttack))
       {
           damage *=1.3f;
       }
       return Mathf.RoundToInt(damage);
       
       
   }
   
   public static float GetTotalDefense()
   {
       float defense=PlayerDefense + EquipDefense+WeaponDefense+MonsterDefense+TitleAttributeAll.Defense+PlayerData.S.ChiBangDefense;
       defense += FinalChongWuAttribute.Defence;
       defense += ShouCangShiAttribute.Defense;
       defense *= (1.0f + MaxDefensePercent / 100f);
       defense *= (1.0f + BaoShiDefense / 100);
       defense *= (1.0f + TitleAttributeAll.AllBaseAttribute);
       defense += (AD5Count*TotalDamage*0.1f);
       return Mathf.RoundToInt(defense);
   }
   
   //附加词条属性

   public static float KillReplyHpPercent=0;
   public static float MaxHpPercent=0;
   public static float MaxDefensePercent=0;
   public static float DamageReductionPercent=0;
   public static float DamageReductionPercentForNormal=0;
   public static float DamageReductionPercentForBoss=0;
   public static float ReplyHpPercent=0;


   public static float CRITDamage = 0;
   public static float FuJiaDamageSpeed = 0; 
   public static float DamageAddForNormal = 0;
   public static float DamageAddForBoss = 0;
   public static float Penetrate = 0;
   public static float DamageAddPercent = 0;
   public static float BloodSuck = 0;
   
   //元素伤害
   public static float HuoYuanSuBase=>GetHuoYuanSuBase();
   public static float HeiAnYuanSuBase=>GetHeiAnYuanSuBase();
   public static float IceYuanSuBase=>GetIceYuanSuBase();
   public static float DianYuanSuBase=>GetDianYuanSuBase();



   public static float GetHuoYuanSuBase()
   {
       float value = 1.0f;
       value += FinalChongWuAttribute.HuoDamage;
       value += SkillJiaDian.S.HuoAll / 100f;
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.AddAllYuanSu))
       {
           value *= 0.2f;
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Green4)
       {
           value *= (1.05f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Blue3)
       {
           value *= (1.1f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Purple2||PlayerData.S.playerChiBangType == ChiBangType.Purple4)
       {
           value *= (1.15f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Purple3)
       {
           value *= (1.1f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Orange1)
       {
           value *= (1.2f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Red1)
       {
           value *= (1.25f);
       }

       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HuoAdd))
       {
           value *= (1.15f);
       }

       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.IceMaster))
       {
           value = 1;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HuoMaster))
       {
           value += (IceYuanSuBase-1);
           value += (DianYuanSuBase-1);
           value += (HeiAnYuanSuBase-1);
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DianMaster))
       {
           value = 1;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HeiAnMaster))
       {
           value = 1;
       }

       return value;
   }
   public static float GetHeiAnYuanSuBase()
   {
       float value = 1.0f;
       value += FinalChongWuAttribute.HeiAnDamage;
       value += SkillJiaDian.S.HeiAnAll / 100f;
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.AddAllYuanSu))
       {
           value *= 0.2f;
       }
       if (PlayerData.S.playerChiBangType == ChiBangType.Green2)
       {
           value *= (1.05f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Blue8||PlayerData.S.playerChiBangType == ChiBangType.Purple3)
       {
           value *= (1.1f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Purple6)
       {
           value *= (1.15f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Orange2)
       {
           value *= (1.2f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Red1)
       {
           value *= (1.25f);
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HeiAnAdd))
       {
           value *= (1.15f);
       }
       
       
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.IceMaster))
       {
           value = 1;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HuoMaster))
       {
           value = 1;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DianMaster))
       {
           value = 1;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HeiAnMaster))
       {
           value += (IceYuanSuBase-1);
           value += (DianYuanSuBase-1);
           value += (HuoYuanSuBase-1);
       }
       return value;
   }
   public static float GetIceYuanSuBase()
   {
       float value = 1.0f;
       value += FinalChongWuAttribute.IceDamage;
       value += SkillJiaDian.S.IceAll / 100f;
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.AddAllYuanSu))
       {
           value *= 0.2f;
       }
       if (PlayerData.S.playerChiBangType == ChiBangType.Green3)
       {
           value *= (1.05f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Blue4)
       {
           value *= (1.1f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Purple7)
       {
           value *= (1.15f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Orange2)
       {
           value *= (1.2f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Red1)
       {
           value *= (1.25f);
       }
       
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.IceAdd))
       {
           value *= (1.15f);
       }
       
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.IceMaster))
       {
           value += (HeiAnYuanSuBase-1);
           value += (DianYuanSuBase-1);
           value += (HuoYuanSuBase-1);
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HuoMaster))
       {
           value = 1;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DianMaster))
       {
           value = 1;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HeiAnMaster))
       {
           value = 1;
       }
       
       return value;
   }
   
   public static float GetDianYuanSuBase()
   {
       float value = 1.0f;
       value += FinalChongWuAttribute.DianDamage;
       value += SkillJiaDian.S.DianAll / 100f;

       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.AddAllYuanSu))
       {
           value *= 0.2f;
       }
       if (PlayerData.S.playerChiBangType == ChiBangType.Blue1)
       {
           value *= (1.1f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Purple1)
       {
           value *= (1.1f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Orange1)
       {
           value *= (1.2f);
       }
       
       if (PlayerData.S.playerChiBangType == ChiBangType.Red1)
       {
           value *= (1.25f);
       }
       
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DianAdd))
       {
           value *= (1.15f);
       }
       
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.IceMaster))
       {
           value = 1;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HuoMaster))
       {
           value = 1;
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DianMaster))
       {
           value += (HeiAnYuanSuBase-1);
           value += (IceYuanSuBase-1);
           value += (HuoYuanSuBase-1);
       }
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.HeiAnMaster))
       {
           value = 1;
       }
       
       return value;
   }
   

   //时装属性
   public static float ShiZhuangAttack => GetShiZhuangAttack();
   public static float ShiZhuangHp => GetShiZhuangHp();
   public static float ShiZhuangMoveSpeed => GetShiZhuangMoveSpeed();
   public static float ShiZhuangAttackSpeed => GetShiZhuangAttackSpeed();


   public static float GetShiZhuangAttack()
   {
       ShiZhuangAttributeItem shiZhuangAttributeItem =
           ShiZhuangConfig.ShiZhuangAttributeDic[PlayerData.S.shiZhuangType];
       return shiZhuangAttributeItem.Attack;
   }
   
   public static float GetShiZhuangHp()
   {
       ShiZhuangAttributeItem shiZhuangAttributeItem =
           ShiZhuangConfig.ShiZhuangAttributeDic[PlayerData.S.shiZhuangType];
       return shiZhuangAttributeItem.Hp;
   }
   
   public static float GetShiZhuangMoveSpeed()
   {
       ShiZhuangAttributeItem shiZhuangAttributeItem =
           ShiZhuangConfig.ShiZhuangAttributeDic[PlayerData.S.shiZhuangType];
       return shiZhuangAttributeItem.MoveSpeed;
   }
   
   public static float GetShiZhuangAttackSpeed()
   {
       ShiZhuangAttributeItem shiZhuangAttributeItem =
           ShiZhuangConfig.ShiZhuangAttributeDic[PlayerData.S.shiZhuangType];
       return shiZhuangAttributeItem.AttackSpeed;
   }
   

   
   //技能面板
   public static void ResetFuJiaAttribute()
   {
    KillReplyHpPercent=0;
    MaxHpPercent=0;
    MaxDefensePercent=0;
    DamageReductionPercent=0;
    DamageReductionPercentForNormal=0;
    DamageReductionPercentForBoss=0;
    ReplyHpPercent=0;


    CRITDamage = 0;
    FuJiaDamageSpeed = 0; 
    DamageAddForNormal = 0;
    DamageAddForBoss = 0;
    Penetrate = 0;
    DamageAddPercent = 0;
    BloodSuck = 0;
   }

   public static void AddFuJiaAttribute(EquipTable equipTable)
   {
       foreach (var item in equipTable.damageEntryInfos)
       {
           switch (item.DamageEntry)
           {
               case EntryConfig.DamageEntry.BloodSuck:
                   BloodSuck += item.Value;
                   break;
               case EntryConfig.DamageEntry.CRITDamage:
                   CRITDamage += item.Value;
                   break;
               case EntryConfig.DamageEntry.DamageAddForBoss:
                   DamageAddForBoss += item.Value;
                   break;
               case EntryConfig.DamageEntry.DamageAddForNormal:
                   DamageAddForNormal += item.Value;
                   break;
               case EntryConfig.DamageEntry.DamageAddPercent:
                   DamageAddPercent += item.Value;
                   break;
               case EntryConfig.DamageEntry.DamageSpeed:
                   FuJiaDamageSpeed += item.Value;
                   break;
               case EntryConfig.DamageEntry.Penetrate:
                   Penetrate += item.Value;
                   break;
           }
       }
       
       foreach (var item in equipTable.defenseEntryInfos)
       {
           switch (item.DefenseEntry)
           {
               case EntryConfig.DefenseEntry.KillReplyHpPercent:
                   KillReplyHpPercent += item.Value;
                   break;
               case EntryConfig.DefenseEntry.DamageReductionPercent:
                   DamageReductionPercent += item.Value;
                   break;
               case EntryConfig.DefenseEntry.DamageReductionPercentForBoss:
                   DamageReductionPercentForBoss += item.Value;
                   break;
               case EntryConfig.DefenseEntry.DamageReductionPercentForNormal:
                   DamageReductionPercentForNormal += item.Value;
                   break;
               case EntryConfig.DefenseEntry.MaxDefensePercent:
                   MaxDefensePercent += item.Value;
                   break;
               case EntryConfig.DefenseEntry.MaxHpPercent:
                   MaxHpPercent += item.Value;
                   break;
               case EntryConfig.DefenseEntry.ReplyHpPercent:
                   ReplyHpPercent += item.Value;
                   break;
           }
       }
   }
   public static void RefreshFuJiaAttribute()
   {
       ResetFuJiaAttribute();
       if (PlayerEquipConfig.CloakId != 0)
       {
           var cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           AddFuJiaAttribute(cloak);
       }
       if (PlayerEquipConfig.ClothId != 0)
       {
           var cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           AddFuJiaAttribute(cloth);
       }
       if (PlayerEquipConfig.HelmetId != 0)
       {
           var helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           AddFuJiaAttribute(helmet);
       }
       if (PlayerEquipConfig.RingId != 0)
       {
           var ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           AddFuJiaAttribute(ring);
       }
       if (PlayerEquipConfig.NecklaceId != 0)
       {
           var necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           AddFuJiaAttribute(necklace);
       }
       if (PlayerEquipConfig.ShoeId != 0)
       {
           var shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           AddFuJiaAttribute(shoe);
       }
   }
   
   
   public static float GetEquipMaxHp()
   {
       float hp = 0;
       if(PlayerEquipConfig.CloakId!=0)
       {
           var cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           hp+=cloak.HP;
       }
       if(PlayerEquipConfig.ClothId!=0)
       {
           var cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           hp+=cloth.HP;
       }
       if(PlayerEquipConfig.ShoeId!=0)
       {
           var shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           hp+=shoe.HP;
       }
       if(PlayerEquipConfig.RingId!=0)
       {
           var ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           hp+=ring.HP;
       }
       if(PlayerEquipConfig.NecklaceId!=0)
       {
           var necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           hp+=necklace.HP;
       }
       if(PlayerEquipConfig.HelmetId!=0)
       {
           var helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           hp+=helmet.HP;
       }

       return hp;
   }
   
   
   public static float GetEquipDamage()
   {
       float Damage = 0;
       if(PlayerEquipConfig.CloakId!=0)
       {
           var cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           Damage+=cloak.Damage;
       }
       if(PlayerEquipConfig.ClothId!=0)
       {
           var cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           Damage+=cloth.Damage;
       }
       if(PlayerEquipConfig.ShoeId!=0)
       {
           var shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           Damage+=shoe.Damage;
       }
       if(PlayerEquipConfig.RingId!=0)
       {
           var ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           Damage+=ring.Damage;
       }
       if(PlayerEquipConfig.NecklaceId!=0)
       {
           var necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           Damage+=necklace.Damage;
       }
       if(PlayerEquipConfig.HelmetId!=0)
       {
           var helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           Damage+=helmet.Damage;
       }

       return Damage;
   }
   
  
   
   public static float GetEquipCRIT()
   {
       float CRIT = 0;
       if(PlayerEquipConfig.CloakId!=0)
       {
           var cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           CRIT+=cloak.CRIT;
       }
       if(PlayerEquipConfig.ClothId!=0)
       {
           var cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           CRIT+=cloth.CRIT;
       }
       if(PlayerEquipConfig.ShoeId!=0)
       {
           var shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           CRIT+=shoe.CRIT;
       }
       if(PlayerEquipConfig.RingId!=0)
       {
           var ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           CRIT+=ring.CRIT;
       }
       if(PlayerEquipConfig.NecklaceId!=0)
       {
           var necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           CRIT+=necklace.CRIT;
       }
       if(PlayerEquipConfig.HelmetId!=0)
       {
           var helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           CRIT+=helmet.CRIT;
       }

       return CRIT;
   }
   
   
   public static float GetEquipDefense()
   {
       float Defense = 0;
       if(PlayerEquipConfig.CloakId!=0)
       {
           var cloak = BagController.S.EquipIdList[PlayerEquipConfig.CloakId];
           Defense+=cloak.Defense;
       }
       if(PlayerEquipConfig.ClothId!=0)
       {
           var cloth = BagController.S.EquipIdList[PlayerEquipConfig.ClothId];
           Defense+=cloth.Defense;
       }
       if(PlayerEquipConfig.ShoeId!=0)
       {
           var shoe = BagController.S.EquipIdList[PlayerEquipConfig.ShoeId];
           Defense+=shoe.Defense;
       }
       if(PlayerEquipConfig.RingId!=0)
       {
           var ring = BagController.S.EquipIdList[PlayerEquipConfig.RingId];
           Defense+=ring.Defense;
       }
       if(PlayerEquipConfig.NecklaceId!=0)
       {
           var necklace = BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId];
           Defense+=necklace.Defense;
       }
       if(PlayerEquipConfig.HelmetId!=0)
       {
           var helmet = BagController.S.EquipIdList[PlayerEquipConfig.HelmetId];
           Defense+=helmet.Defense;
       }

       return Defense;
   }
}
