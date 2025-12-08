using System.Collections.Generic;
using UnityEngine;

public class GlobalPlayerAttribute 
{
   public static WeaponType CurrentWeaponType= WeaponType.Primary; //当前武器类型
   public static bool IsGame = false;
   public static int CurrentHp=0;

   public static int BloodEnergy
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

   public static int Exp
   {
         get => PlayerData.S.exp;
         set => PlayerData.S.exp = value;
   }
   public static Dictionary<int,int> ExpDic=new Dictionary<int,int>()
   {
         {1,100 },
         {2,200 },
         {3,300 },
         {4,400 },
         {5,500 },
         {6,600 },
         {7,700 },
         {8,800 },
         {9,900 },
         {10,1000 },
         {11,1200 },
         {12,1400 },
         {13,1600 },
         {14,1800 },
         {15,2000 },
         {16,2200 },
         {17,2400 },
         {18,2600 },
         {19,2800 },
         {20,3000 },
         {21,3200 },
         {22,3400 },
         {23,3600 },
         {24,3800 },
         {25,4000 },
         {26,4200 },
         {27,4400 },
         {28,46800 },
         {29,4800 },
         {30,5000 },
   };

   public static int GameLevel
   {
            get => PlayerData.S.maxGameLevel;
            set => PlayerData.S.maxGameLevel = value;
   }
   
   //人物属性,默认属性
   public static int PlayerMaxHp
   {
       get => PlayerInfoConfig.GetPlayerMaxHp();
   }

   public static int PlayerDamage
   {
       get => PlayerInfoConfig.GetPlayerAttack();
   }
   public static int PlayerMoveSpeed=3;
   public static int PlayerCRIT=0;
   public static int PlayerDefense
   {
       get => PlayerInfoConfig.GetPlayerDenfence();
   }
   
   //装备属性
   public static int EquipMaxHp
   {
       get => GetEquipMaxHp();
   }

   public static int EquipDamage
   {
       get => GetEquipDamage();
   }
   
   public static int EquipCRIT
   {
       get => GetEquipCRIT();
   }

   public static int EquipDefense
   {
       get => GetEquipDefense();
   }
   
   //总属性
   
   //基础属性
   public static int TotalMaxHp => Mathf.RoundToInt((PlayerMaxHp + EquipMaxHp)*MaxHpPercent);
   public static int TotalDamage=> Mathf.RoundToInt((PlayerDamage + EquipDamage)*MaxDefensePercent);
   public static int TotalCRIT => PlayerCRIT + EquipCRIT;
   public static int TotalDefense => PlayerDefense + EquipDefense;
   
   //附加词条属性

   public static float KillReplyHpPercent=0;
   public static float MaxHpPercent=0;
   public static float MaxDefensePercent=0;
   public static float DamageReductionPercent=0;
   public static float DamageReductionPercentForNormal=0;
   public static float DamageReductionPercentForBoss=0;
   public static float ReplyHpPercent=0;


   public static float CRITDamage = 0;
   public static float DamageSpeed = 0; 
   public static float DamageAddForNormal = 0;
   public static float DamageAddForBoss = 0;
   public static float Penetrate = 0;
   public static float DamageAddPercent = 0;
   public static float BloodSuck = 0;


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
    DamageSpeed = 0; 
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
                   DamageSpeed += item.Value;
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
   
   
   public static int GetEquipMaxHp()
   {
       int hp = 0;
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
   
   
   public static int GetEquipDamage()
   {
       int Damage = 0;
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
   
  
   
   public static int GetEquipCRIT()
   {
       int CRIT = 0;
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
   
   
   public static int GetEquipDefense()
   {
       int Defense = 0;
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
