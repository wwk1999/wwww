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
public class GlobalPlayerAttribute
{
    public static ChiBangAttribute PlayerChiBangAttribute => GetPlayerChiBang();

    public static ChiBangAttribute GetPlayerChiBang()
    {
        return ChiBangConfig.ChiBangAttributeDic[PlayerData.S.ChiBangLevel];
    }
    
   public static float WeaponAttack=>GetWeaponAttack();
   public static float WeaponDefense=>GetWeaponDefense();
   public static float WeaponCrit=>GetWeaponCrit();
   public static float WeaponHp=>GetWeaponHp();
   public static float WeaponAttackSpeed=>GetWeaponAttackSpeed();
   public static float WeaponShenJiPercent = 0.2f;

   
   
   
   
   public static bool IsGame = false;
   public static float CurrentHp=0;
   public static bool isIceBall = false;
   public static ExitType CurrentExitType = ExitType.FirstGame;

   public static HashSet<EntryConfig.OrangeEntry> PlayerOrangeEntry = new HashSet<EntryConfig.OrangeEntry>();

   public static float GetWeaponAttack()
   {
       var weaponAttribute = WeaponConfig.WeaponBaseAttributeDic[PlayerData.S.playerWeaponType];
       int level = 0;
       switch (PlayerData.S.playerWeaponType)
       {
           case WeaponType.Primary:
               level = PlayerData.S.primaryWeaponLevel;
               break;
           case WeaponType.Du:
               level = PlayerData.S.duWeaponLevel;
               break;
           case WeaponType.PuTong3:
               level = PlayerData.S.puTong3WeaponLevel;
               break;
           case WeaponType.XuKong:
               level = PlayerData.S.xuKongWeaponLevel;
               break;
           case WeaponType.Fire:
               level = PlayerData.S.fireWeaponLevel;
               break;
           case WeaponType.LvQuan:
               level = PlayerData.S.lvQuanWeaponLevel;
               break;
           case WeaponType.HeiDong:
               level = PlayerData.S.heiDongWeaponLevel;
               break;
           case WeaponType.JianQi:
               level = PlayerData.S.jianQiWeaponLevel;
               break;
       }

       return weaponAttribute.Attack * (1 + (level - 1) * WeaponShenJiPercent);
   }
   
   public static float GetWeaponDefense()
   {
       var weaponAttribute = WeaponConfig.WeaponBaseAttributeDic[PlayerData.S.playerWeaponType];
       int level = 0;
       switch (PlayerData.S.playerWeaponType)
       {
           case WeaponType.Primary:
               level = PlayerData.S.primaryWeaponLevel;
               break;
           case WeaponType.Du:
               level = PlayerData.S.duWeaponLevel;
               break;
           case WeaponType.PuTong3:
               level = PlayerData.S.puTong3WeaponLevel;
               break;
           case WeaponType.XuKong:
               level = PlayerData.S.xuKongWeaponLevel;
               break;
           case WeaponType.Fire:
               level = PlayerData.S.fireWeaponLevel;
               break;
           case WeaponType.LvQuan:
               level = PlayerData.S.lvQuanWeaponLevel;
               break;
           case WeaponType.HeiDong:
               level = PlayerData.S.heiDongWeaponLevel;
               break;
           case WeaponType.JianQi:
               level = PlayerData.S.jianQiWeaponLevel;
               break;
       }

       return weaponAttribute.Defense * (1 + (level - 1) * WeaponShenJiPercent);
   }
   
   public static float GetWeaponCrit()
   {
       var weaponAttribute = WeaponConfig.WeaponBaseAttributeDic[PlayerData.S.playerWeaponType];
       int level = 0;
       switch (PlayerData.S.playerWeaponType)
       {
           case WeaponType.Primary:
               level = PlayerData.S.primaryWeaponLevel;
               break;
           case WeaponType.Du:
               level = PlayerData.S.duWeaponLevel;
               break;
           case WeaponType.PuTong3:
               level = PlayerData.S.puTong3WeaponLevel;
               break;
           case WeaponType.XuKong:
               level = PlayerData.S.xuKongWeaponLevel;
               break;
           case WeaponType.Fire:
               level = PlayerData.S.fireWeaponLevel;
               break;
           case WeaponType.LvQuan:
               level = PlayerData.S.lvQuanWeaponLevel;
               break;
           case WeaponType.HeiDong:
               level = PlayerData.S.heiDongWeaponLevel;
               break;
           case WeaponType.JianQi:
               level = PlayerData.S.jianQiWeaponLevel;
               break;
       }

       return weaponAttribute.Crit * (1 + (level - 1) * WeaponShenJiPercent);
   }
   
   public static float GetWeaponHp()
   {
       var weaponAttribute = WeaponConfig.WeaponBaseAttributeDic[PlayerData.S.playerWeaponType];
       int level = 0;
       switch (PlayerData.S.playerWeaponType)
       {
           case WeaponType.Primary:
               level = PlayerData.S.primaryWeaponLevel;
               break;
           case WeaponType.Du:
               level = PlayerData.S.duWeaponLevel;
               break;
           case WeaponType.PuTong3:
               level = PlayerData.S.puTong3WeaponLevel;
               break;
           case WeaponType.XuKong:
               level = PlayerData.S.xuKongWeaponLevel;
               break;
           case WeaponType.Fire:
               level = PlayerData.S.fireWeaponLevel;
               break;
           case WeaponType.LvQuan:
               level = PlayerData.S.lvQuanWeaponLevel;
               break;
           case WeaponType.HeiDong:
               level = PlayerData.S.heiDongWeaponLevel;
               break;
           case WeaponType.JianQi:
               level = PlayerData.S.jianQiWeaponLevel;
               break;
       }

       return weaponAttribute.Hp * (1 + (level - 1) * WeaponShenJiPercent);
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
           if (GameController.S.GameCurrentHp <= GameController.S.GameMaxHp / 0.5f)
           {
               value *= 1.3f;
           }
       }
       GameController.S.GameCurrentHp+= value;
       GameController.S.GameCurrentHp=Math.Min(GameController.S.GameCurrentHp,GameController.S.GameMaxHp);
   }
   
   
   public static void RefreshOrangeEntry()
   {
       PlayerOrangeEntry.Clear();
       if (PlayerEquipConfig.CloakId != 0)
       {
           if (BagController.S.EquipIdList[PlayerEquipConfig.CloakId].OrangeEntry1 != EntryConfig.OrangeEntry.None)
           {
               PlayerOrangeEntry.Add(BagController.S.EquipIdList[PlayerEquipConfig.CloakId].OrangeEntry1);
           }
       }
       
       if (PlayerEquipConfig.ClothId != 0)
       {
           if (BagController.S.EquipIdList[PlayerEquipConfig.ClothId].OrangeEntry1 != EntryConfig.OrangeEntry.None)
           {
               PlayerOrangeEntry.Add(BagController.S.EquipIdList[PlayerEquipConfig.ClothId].OrangeEntry1);
           }
       }
       
       if (PlayerEquipConfig.RingId != 0)
       {
           if (BagController.S.EquipIdList[PlayerEquipConfig.RingId].OrangeEntry1 != EntryConfig.OrangeEntry.None)
           {
               PlayerOrangeEntry.Add(BagController.S.EquipIdList[PlayerEquipConfig.RingId].OrangeEntry1);
           }
       }
       if (PlayerEquipConfig.NecklaceId != 0)
       {
           if (BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId].OrangeEntry1 != EntryConfig.OrangeEntry.None)
           {
               PlayerOrangeEntry.Add(BagController.S.EquipIdList[PlayerEquipConfig.NecklaceId].OrangeEntry1);
           }
       }
       if (PlayerEquipConfig.ShoeId != 0)
       {
           if (BagController.S.EquipIdList[PlayerEquipConfig.ShoeId].OrangeEntry1 != EntryConfig.OrangeEntry.None)
           {
               PlayerOrangeEntry.Add(BagController.S.EquipIdList[PlayerEquipConfig.ShoeId].OrangeEntry1);
           }
       }
       if (PlayerEquipConfig.HelmetId != 0)
       {
           if (BagController.S.EquipIdList[PlayerEquipConfig.HelmetId].OrangeEntry1 != EntryConfig.OrangeEntry.None)
           {
               PlayerOrangeEntry.Add(BagController.S.EquipIdList[PlayerEquipConfig.HelmetId].OrangeEntry1);
           }
       }
   }
   
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

   public static float Forture => GetForture();
   public static int PlayerMaxHp
   {
       get => PlayerInfoConfig.GetPlayerMaxHp();
   }

   public static int PlayerDamage
   {
       get => PlayerInfoConfig.GetPlayerAttack();
   }
   
   private static float _baseMoveSpeed = 3f;

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
       return (weaponAttribute.AttackSpeed+PlayerChiBangAttribute.attackSpeed) * (1 + AttackSpeedNum/100.0f + FuJiaDamageSpeed/100.0f);
   }

   public static float GetTotalCrit()
   {
       return (PlayerCRIT + EquipCRIT+WeaponCrit)*(1+CritNum/100.0f);
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

       forture += PlayerChiBangAttribute.forture;
       return forture;
   }
   
   public static float GetPlayerMoveSpeed()
   {
       float speed=(_baseMoveSpeed+PlayerChiBangAttribute.moveSpeed) * (1 + MoveSpeedNum / 100f);
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.MoveSpeedAdd))
       {
           speed*=1.25f;
       }
       return speed;
   }

   public static float GetTotalCritDamage()
   {
       return CRITDamage+CritDamageNum/100.0f+PlayerChiBangAttribute.critDamage;
   }

   public static float GetTotalMaxHp()
   {
       float maxhp= Mathf.RoundToInt((PlayerMaxHp + EquipMaxHp+WeaponHp+PlayerChiBangAttribute.maxHp) * (1.0f + MaxHpPercent/100f));
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.RecudeHpAddAttack))
       {
           maxhp /= 2;
       }
       return  maxhp;
   }
   
   public static float GetTotalDamage()
   {
       float damage = Mathf.RoundToInt((PlayerDamage + EquipDamage+WeaponAttack+PlayerChiBangAttribute.attack) * (1f + DamageAddPercent / 100f));
       if (PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.RecudeHpAddAttack))
       {
           damage *=1.3f;
       }
       return damage;
   }
   
   public static float GetTotalDefense()
   {
       float defense=Mathf.RoundToInt((PlayerDefense + EquipDefense+WeaponDefense+PlayerChiBangAttribute.defense)*(1f+MaxDefensePercent/100f));
       float value = 0;

       if (isIceBall)
       {
           value += Skill2AddDefenseNum / 100.0f;
       }

       defense *= (1 + value);
       return defense;
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



   
   //技能面板

   public static int NormalAttackNum => SkillJiaDian.S.NormalAttack * 5;
   public static int AttackSpeedNum=> SkillJiaDian.S.AttackSpeed * 5;
    
   public static int CritNum=> SkillJiaDian.S.Crit * 5;//百分比
   public static int CritDamageNum=> SkillJiaDian.S.CritDamage * 5;
    
   public static int MoveSpeedNum=> SkillJiaDian.S.MoveSpeed * 30;
   public static int MoveAddAttackNum=> SkillJiaDian.S.MoveAddAttack * 5;
   public static int MoveAddDefenseNum=> SkillJiaDian.S.MoveAddDefense * 5;
    
   public static int DashNum=> SkillJiaDian.S.Dash * 5;
   public static int DashCdNum=> SkillJiaDian.S.DashCd * 5;
    
   public static int Skill1DamageNum=> 100+(SkillJiaDian.S.Skill1Damage-1) * 5;
   public static int Skill1CdNum=> SkillJiaDian.S.Skill1Cd * 5;
   public static int Skill1RangeNum=> SkillJiaDian.S.Skill1Range * 5;
   public static int Skill1YiDianNum=> SkillJiaDian.S.Skill1YiDian * 5;
    
   public static int Skill2DamageNum=> 100+(SkillJiaDian.S.Skill2Damage-1) * 5;
   public static int Skill2CdNum=> SkillJiaDian.S.Skill2Cd * 5;
   public static int Skill2TimeNum=> SkillJiaDian.S.Skill2Time * 50;//增加基础持续时候
   public static int Skill2AddDefenseNum=> SkillJiaDian.S.Skill2AddDefense * 5;
    
   public static int Skill3DamageNum=> 100+(SkillJiaDian.S.Skill3Damage-1) * 5;
   public static int Skill3CdNum=> SkillJiaDian.S.Skill3Cd * 5;
   public static int Skill3RangeNum=> SkillJiaDian.S.Skill3Range * 5;
   public static int Skill3JianSuNum=> SkillJiaDian.S.Skill3JianSu * 5;

   public static int MonsterAttackNum=> SkillJiaDian.S.MonsterAttack * 100;
   public static int MonsterCritNum=> SkillJiaDian.S.MonsterCrit * 100;
   public static int MonsterHpNum=> SkillJiaDian.S.MonsterHp * 100;
   public static int MonsterDefenseNum=> SkillJiaDian.S.MonsterDefense * 100;


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
