using System.Collections.Generic;
namespace Config
{
    public enum ShiZhuangType
    {
        None,
        GreenIce,
        GreenDian,
        GreenHeiAn,
        GreenHuo,
        
        BlueIce,
        BlueDian,
        BlueHeiAn,
        BlueHuo,
        
        PurpleIce,
        PurpleDian,
        PurpleHeiAn,
        PurpleHuo,
        
        OrangeIce,
        OrangeDian,
        OrangeHeiAn,
        OrangeHuo,
    }

    public class ShiZhuangJieSuoItem
    {
        public int level;
        public YuanSuType yuanSuType;
        public float yuansuDamage;
        public int weaponLevel;
    }
    
    public class ShiZhuangAttributeItem
    {
        public float Attack;
        public float Hp;
        public float MoveSpeed;
        public float AttackSpeed;
    }
    public class ShiZhuangConfig
    {

        public static Dictionary<ShiZhuangType, ShiZhuangAttributeItem> ShiZhuangAttributeDic =
            new Dictionary<ShiZhuangType, ShiZhuangAttributeItem>()
            {
                { ShiZhuangType.GreenHuo ,new ShiZhuangAttributeItem(){Attack = 5,Hp = 8,MoveSpeed = 5,AttackSpeed = 5}},
                { ShiZhuangType.GreenDian ,new ShiZhuangAttributeItem(){Attack = 5,Hp = 8,MoveSpeed = 5,AttackSpeed = 5}},
                { ShiZhuangType.GreenIce ,new ShiZhuangAttributeItem(){Attack = 5,Hp = 8,MoveSpeed = 5,AttackSpeed = 5}},
                { ShiZhuangType.GreenHeiAn ,new ShiZhuangAttributeItem(){Attack = 5,Hp = 8,MoveSpeed = 5,AttackSpeed = 5}},

                { ShiZhuangType.BlueHuo ,new ShiZhuangAttributeItem(){Attack = 10,Hp = 15,MoveSpeed = 10,AttackSpeed = 10}},
                { ShiZhuangType.BlueDian ,new ShiZhuangAttributeItem(){Attack = 10,Hp = 15,MoveSpeed = 10,AttackSpeed = 10}},
                { ShiZhuangType.BlueIce ,new ShiZhuangAttributeItem(){Attack = 10,Hp = 15,MoveSpeed = 10,AttackSpeed = 10}},
                { ShiZhuangType.BlueHeiAn ,new ShiZhuangAttributeItem(){Attack = 10,Hp = 15,MoveSpeed = 10,AttackSpeed = 10}},

                
                { ShiZhuangType.PurpleHuo ,new ShiZhuangAttributeItem(){Attack = 15,Hp = 25,MoveSpeed = 15,AttackSpeed = 15}},
                { ShiZhuangType.PurpleDian ,new ShiZhuangAttributeItem(){Attack = 15,Hp = 25,MoveSpeed = 15,AttackSpeed = 15}},
                { ShiZhuangType.PurpleIce ,new ShiZhuangAttributeItem(){Attack = 15,Hp = 25,MoveSpeed = 15,AttackSpeed = 15}},
                { ShiZhuangType.PurpleHeiAn ,new ShiZhuangAttributeItem(){Attack = 15,Hp = 25,MoveSpeed = 15,AttackSpeed = 15}},

                
                { ShiZhuangType.OrangeHuo ,new ShiZhuangAttributeItem(){Attack = 20,Hp = 35,MoveSpeed = 20,AttackSpeed = 20}},
                { ShiZhuangType.OrangeDian ,new ShiZhuangAttributeItem(){Attack = 20,Hp = 35,MoveSpeed = 20,AttackSpeed = 20}},
                { ShiZhuangType.OrangeIce ,new ShiZhuangAttributeItem(){Attack = 20,Hp = 35,MoveSpeed = 20,AttackSpeed = 20}},
                { ShiZhuangType.OrangeHeiAn ,new ShiZhuangAttributeItem(){Attack = 20,Hp = 35,MoveSpeed = 20,AttackSpeed = 20}},

            };
        public static Dictionary<ShiZhuangType, ShiZhuangJieSuoItem> ShiZhuangJieSuoDic =
            new Dictionary<ShiZhuangType, ShiZhuangJieSuoItem>()
            {
                {ShiZhuangType.GreenHuo ,new ShiZhuangJieSuoItem(){level = 10,yuanSuType = YuanSuType.Huo,yuansuDamage = 150,weaponLevel = 5}},
                {ShiZhuangType.GreenIce ,new ShiZhuangJieSuoItem(){level = 10,yuanSuType = YuanSuType.Ice,yuansuDamage = 150,weaponLevel = 5}},
                {ShiZhuangType.GreenDian ,new ShiZhuangJieSuoItem(){level = 10,yuanSuType = YuanSuType.Dian,yuansuDamage = 150,weaponLevel = 5}},
                {ShiZhuangType.GreenHeiAn ,new ShiZhuangJieSuoItem(){level = 10,yuanSuType = YuanSuType.HeiAn,yuansuDamage = 150,weaponLevel = 5}},
                
                {ShiZhuangType.BlueHuo ,new ShiZhuangJieSuoItem(){level = 25,yuanSuType = YuanSuType.Huo,yuansuDamage = 200,weaponLevel = 20}},
                {ShiZhuangType.BlueHeiAn ,new ShiZhuangJieSuoItem(){level = 25,yuanSuType = YuanSuType.HeiAn,yuansuDamage = 200,weaponLevel = 20}},
                {ShiZhuangType.BlueDian ,new ShiZhuangJieSuoItem(){level = 25,yuanSuType = YuanSuType.Dian,yuansuDamage = 200,weaponLevel = 20}},
                {ShiZhuangType.BlueIce ,new ShiZhuangJieSuoItem(){level = 25,yuanSuType = YuanSuType.Ice,yuansuDamage = 200,weaponLevel = 20}},

                {ShiZhuangType.PurpleIce ,new ShiZhuangJieSuoItem(){level = 50,yuanSuType = YuanSuType.Ice,yuansuDamage = 300,weaponLevel = 50}},
                {ShiZhuangType.PurpleHuo ,new ShiZhuangJieSuoItem(){level = 50,yuanSuType = YuanSuType.Huo,yuansuDamage = 300,weaponLevel = 50}},
                {ShiZhuangType.PurpleDian ,new ShiZhuangJieSuoItem(){level = 50,yuanSuType = YuanSuType.Dian,yuansuDamage = 300,weaponLevel = 50}},
                {ShiZhuangType.PurpleHeiAn ,new ShiZhuangJieSuoItem(){level = 50,yuanSuType = YuanSuType.HeiAn,yuansuDamage = 300,weaponLevel = 50}},

                {ShiZhuangType.OrangeIce ,new ShiZhuangJieSuoItem(){level = 75,yuanSuType = YuanSuType.Ice,yuansuDamage = 400,weaponLevel = 100}},
                {ShiZhuangType.OrangeHeiAn ,new ShiZhuangJieSuoItem(){level = 75,yuanSuType = YuanSuType.HeiAn,yuansuDamage = 400,weaponLevel = 100}},
                {ShiZhuangType.OrangeHuo ,new ShiZhuangJieSuoItem(){level = 75,yuanSuType = YuanSuType.Huo,yuansuDamage = 400,weaponLevel = 100}},
                {ShiZhuangType.OrangeDian ,new ShiZhuangJieSuoItem(){level = 75,yuanSuType = YuanSuType.Dian,yuansuDamage = 400,weaponLevel = 100}},

            };
        
        public static Dictionary<ShiZhuangType, string> ShiZhuangNameDic = new Dictionary<ShiZhuangType, string>()
        {
            { ShiZhuangType.GreenHuo , "余烬行者" },
            { ShiZhuangType.GreenIce , "凛冬使徒" },
            { ShiZhuangType.GreenDian , "电光游侠" },
            { ShiZhuangType.GreenHeiAn , "烛烬者" },
            
            { ShiZhuangType.BlueHuo , "燃焰支配者" },
            { ShiZhuangType.BlueIce , "霜冻守护者" },
            { ShiZhuangType.BlueDian , "风暴裁决官" },
            { ShiZhuangType.BlueHeiAn , "深渊守望者" },
            
            { ShiZhuangType.PurpleHuo , "烬天王裔" },
            { ShiZhuangType.PurpleIce , "寒渊领主" },
            { ShiZhuangType.PurpleDian , "雷霆领主" },
            { ShiZhuangType.PurpleHeiAn , "永夜君主" },
            
            { ShiZhuangType.OrangeHuo , "炼狱炎魔使" },
            { ShiZhuangType.OrangeIce , "湮灭零度" },
            { ShiZhuangType.OrangeDian , "原初闪电" },
            { ShiZhuangType.OrangeHeiAn , "终末之暗" },

        };
    }
}