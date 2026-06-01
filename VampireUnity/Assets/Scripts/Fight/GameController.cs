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
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class GameController : XSingleton<GameController>
{
    [NonSerialized] public MonsterTypeByName EliteMonster = MonsterTypeByName.None;
    [NonSerialized] public List<MonsterTypeByName> NormalMonster = new List<MonsterTypeByName>();
    [NonSerialized] public MonsterTypeByName Boss = MonsterTypeByName.None;

    

    
    [NonSerialized] public int[] MonsterList = new int[2];
    
    

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

    public Vector2 GetRandomMonsterPos()
    {
        List<MonsterBase> monsters = new List<MonsterBase>(QueueController.S.MonsterColliderDic.Values);
        
        int n = monsters.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            // 交换元素
            (monsters[j], monsters[i]) = (monsters[i], monsters[j]);
        }

        foreach (var item in monsters)
        {
            if (item == null)
            {
                continue;
            }
            if (item.gameObject.activeSelf &&
                Vector2.Distance(QueueController.S.gamePlayer.transform.position, item.transform.position) < 6)
            {
                return item.transform.position;
            }
        }

        float x = Random.Range(-0.5f, 0.5f);
        float y = Random.Range(-0.5f, 0.5f);
        Vector3 dir = new Vector3(x, y,0);
        return QueueController.S.gamePlayer.transform.position+dir * 6;
    }
    
    
    

   
    //怪物数量
    [NonSerialized]public int NormalMonsterCount=0;
    [NonSerialized]public int EliteMonsterCount=0;
    [NonSerialized]public int TotalMonsterCount=0;
    [NonSerialized]public int DieNormalMonsterCount=0;
    [NonSerialized]public int DieEliteMonsterCount=0;



    public float monsterBirthTimeScale => LevelInfoConfig.LevelMonsterCreateSpeedDic[LevelInfoConfig.CurrentGameLevel]; //间隔一秒钟生成一个怪物
    public float currentTime = 0f;
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
        var dilie = QueueController.S.TreeManDiLieQueue.Dequeue();
        dilie.transform.position = pos;
        dilie.GetComponent<TreeManDiLie>().damage = damage;
        dilie.gameObject.SetActive(true);
    }

    public void CreateCircleAttack(Vector2 pos,float scale)
    {
        var circle=QueueController.S.CircleQueue.Dequeue();
        circle.transform.position = pos;
        circle.transform.localScale = new Vector3(scale, scale, scale);
        circle.gameObject.SetActive(true);
    }
    
    public void CreateSqrtAttack(Vector2 pos, Vector2 dir)
    {
        var sqrt = QueueController.S.SqrtQueue.Dequeue();
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
                ChiBangFight chiBangFight = QueueController.S.ChiBangFightQueue.Dequeue();
                chiBangFight.ChiBangType=chiBangType;
                return chiBangFight.gameObject;
            case PropConfig.PropType.WeaponFragment:
                switch (prop.Quality)
                {
                    case 1:
                        return QueueController.S.WhiteWeaponFragmengQueue.Dequeue();
                    case 2:
                        return QueueController.S.GreenWeaponFragmengQueue.Dequeue();
                    case 3:
                        return QueueController.S.BlueWeaponFragmengQueue.Dequeue();
                    case 4:
                        return QueueController.S.PurpleWeaponFragmengQueue.Dequeue();
                    case 5:
                        return QueueController.S.OrangeWeaponFragmengQueue.Dequeue();
                    case 6:
                        return QueueController.S.RedWeaponFragmengQueue.Dequeue();
                }
                break;
            case PropConfig.PropType.ShenHuaCaiLiao:
                switch (prop.Quality)
                {
                    case 1:
                        return QueueController.S.FuMoZhiGuQueue.Dequeue();
                    case 2:
                        return QueueController.S.GoldBloodQueue.Dequeue();
                    case 3:
                        return QueueController.S.JuDaYaChiQueue.Dequeue();
                    case 4:
                        return QueueController.S.ZuiEYanZhuQueue.Dequeue();
                }
                break;
            
            case PropConfig.PropType.ChiBang:
                switch (prop.Quality)
                {
                    case 1:
                        return QueueController.S.WhiteChiBangQueue.Dequeue();
                    case 2:
                        return QueueController.S.GreenChiBangQueue.Dequeue();
                    case 3:
                        return QueueController.S.BlueChiBangQueue.Dequeue();
                    case 4:
                        return QueueController.S.PurpleChiBangQueue.Dequeue();
                    case 5:
                        return QueueController.S.OrangeChiBangQueue.Dequeue();
                    case 6:
                        return QueueController.S.RedChiBangQueue.Dequeue();
                }
                break;
            case PropConfig.PropType.AA:
                BaoShi baoshi=QueueController.S.BaoShiQueue.Dequeue();
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
                BaoShi baoshi9=QueueController.S.BaoShiQueue.Dequeue();
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
                BaoShi baoshi8=QueueController.S.BaoShiQueue.Dequeue();
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
                BaoShi baoshi7=QueueController.S.BaoShiQueue.Dequeue();
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
                BaoShi baoshi6=QueueController.S.BaoShiQueue.Dequeue();
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
                BaoShi baoshi5=QueueController.S.BaoShiQueue.Dequeue();
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
                BaoShi baoshi4=QueueController.S.BaoShiQueue.Dequeue();
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
                BaoShi baoshi3=QueueController.S.BaoShiQueue.Dequeue();
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
                BaoShi baoshi2=QueueController.S.BaoShiQueue.Dequeue();
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
                BaoShi baoshi1=QueueController.S.BaoShiQueue.Dequeue();
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
                        var chongwudan = QueueController.S.ChongWuDanQueue.Dequeue();
                        chongwudan.quality = 3;
                        return chongwudan.gameObject;
                    case 5:
                        var chongwudan1 = QueueController.S.ChongWuDanQueue.Dequeue();
                        chongwudan1.quality = 5;
                        return chongwudan1.gameObject;
                }
                break;
                
                
            case PropConfig.PropType.ChongWuShiWu:
                switch (prop.Quality)
                {
                    case 1:
                        var chongwushiwu1 = QueueController.S.ChongWuShiWuQueue.Dequeue();
                        chongwushiwu1.quality = 1;
                        return chongwushiwu1.gameObject;
                    case 2:
                        var chongwushiwu2 = QueueController.S.ChongWuShiWuQueue.Dequeue();
                        chongwushiwu2.quality = 2;
                        return chongwushiwu2.gameObject;
                    case 3:
                        var chongwushiwu3 = QueueController.S.ChongWuShiWuQueue.Dequeue();
                        chongwushiwu3.quality = 3;
                        return chongwushiwu3.gameObject;
                    case 4:
                        var chongwushiwu4 = QueueController.S.ChongWuShiWuQueue.Dequeue();
                        chongwushiwu4.quality = 4;
                        return chongwushiwu4.gameObject;
                    case 5:
                        var chongwushiwu5 = QueueController.S.ChongWuShiWuQueue.Dequeue();
                        chongwushiwu5.quality = 5;
                        return chongwushiwu5.gameObject;
                    case 6:
                        var chongwushiwu6 = QueueController.S.ChongWuShiWuQueue.Dequeue();
                        chongwushiwu6.quality = 6;
                        return chongwushiwu6.gameObject;
                }
                break;
            
            
            case PropConfig.PropType.SkillShu:
                switch (prop.Quality)
                {
                    case 1:
                        var chongwuSkillShu1 = QueueController.S.ChongWuSkillShuQueue.Dequeue();
                        chongwuSkillShu1.quality = 1;
                        return chongwuSkillShu1.gameObject;
                    case 2:
                        var chongwuSkillShu2 = QueueController.S.ChongWuSkillShuQueue.Dequeue();
                        chongwuSkillShu2.quality = 2;
                        return chongwuSkillShu2.gameObject;
                    case 3:
                        var chongwuSkillShu3 = QueueController.S.ChongWuSkillShuQueue.Dequeue();
                        chongwuSkillShu3.quality = 3;
                        return chongwuSkillShu3.gameObject;
                    case 4:
                        var chongwuSkillShu4 = QueueController.S.ChongWuSkillShuQueue.Dequeue();
                        chongwuSkillShu4.quality = 4;
                        return chongwuSkillShu4.gameObject;
                    case 5:
                        var chongwuSkillShu5 = QueueController.S.ChongWuSkillShuQueue.Dequeue();
                        chongwuSkillShu5.quality = 5;
                        return chongwuSkillShu5.gameObject;
                    case 6:
                        var chongwuSkillShu6 = QueueController.S.ChongWuSkillShuQueue.Dequeue();
                        chongwuSkillShu6.quality = 6;
                        return chongwuSkillShu6.gameObject;
                }
                break;

                
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
                        return QueueController.S.PrimaryCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return QueueController.S.PrimaryClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return QueueController.S.PrimaryRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return QueueController.S.PrimaryShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return QueueController.S.PrimaryHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return QueueController.S.PrimaryNecklaceQueue.Dequeue();
                }
                break;
            case PlayerEquipConfig.EquipLevel.Green:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return QueueController.S.GreenCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return QueueController.S.GreenClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return QueueController.S.GreenRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return QueueController.S.GreenShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return QueueController.S.GreenHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return QueueController.S.GreenNecklaceQueue.Dequeue();
                }
                break;
            case PlayerEquipConfig.EquipLevel.Blue:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return QueueController.S.BlueCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return QueueController.S.BlueClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return QueueController.S.BlueRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return QueueController.S.BlueShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return QueueController.S.BlueHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return QueueController.S.BlueNecklaceQueue.Dequeue();
                }
                break;
            case PlayerEquipConfig.EquipLevel.TreeMan:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return QueueController.S.TreeManCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return QueueController.S.TreeManClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return QueueController.S.TreeManRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return QueueController.S.TreeManShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return QueueController.S.TreeManHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return QueueController.S.TreeManNecklaceQueue.Dequeue();
                }
                break;
           case PlayerEquipConfig.EquipLevel.HuoShan:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return QueueController.S.HuoShanCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return QueueController.S.HuoShanClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return QueueController.S.HuoShanRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return QueueController.S.HuoShanShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return QueueController.S.HuoShanHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return QueueController.S.HuoShanNecklaceQueue.Dequeue();
                }
               break;
           
            case PlayerEquipConfig.EquipLevel.Purple:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return QueueController.S.PurpleCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return QueueController.S.PurpleClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return QueueController.S.PurpleRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return QueueController.S.PurpleShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return QueueController.S.PurpleHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return QueueController.S.PurpleNecklaceQueue.Dequeue();
                }
                break;
            
            case PlayerEquipConfig.EquipLevel.Orange:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return QueueController.S.OrangeCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return QueueController.S.OrangeClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return QueueController.S.OrangeRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return QueueController.S.OrangeShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return QueueController.S.OrangeHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return QueueController.S.OrangeNecklaceQueue.Dequeue();
                }
                break;
            
            case PlayerEquipConfig.EquipLevel.ZhaoZe:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return QueueController.S.ZhaoZeCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return QueueController.S.ZhaoZeClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return QueueController.S.ZhaoZeRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return QueueController.S.ZhaoZeShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return QueueController.S.ZhaoZeHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return QueueController.S.ZhaoZeNecklaceQueue.Dequeue();
                }
                break;
            
            
            
            case PlayerEquipConfig.EquipLevel.XueRen:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return QueueController.S.XueRenCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return QueueController.S.XueRenClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return QueueController.S.XueRenRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return QueueController.S.XueRenShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return QueueController.S.XueRenHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return QueueController.S.XueRenNecklaceQueue.Dequeue();
                }
                break;
            
            
            
            case PlayerEquipConfig.EquipLevel.XieZi:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return QueueController.S.XieZiCloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return QueueController.S.XieZiClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return QueueController.S.XieZiRingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return QueueController.S.XieZiShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return QueueController.S.XieZiHelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return QueueController.S.XieZiNecklaceQueue.Dequeue();
                }
                break;
            
            case PlayerEquipConfig.EquipLevel.Purple1:
                switch (monsterEquip.EquipType)
                {
                    case PlayerEquipConfig.EquipType.Cloak:
                        return QueueController.S.Purple1CloakQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Cloth:
                        return QueueController.S.Purple1ClothQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Ring:
                        return QueueController.S.Purple1RingQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Shoe:
                        return QueueController.S.Purple1ShoeQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Helmet:
                        return QueueController.S.Purple1HelmetQueue.Dequeue();
                    case PlayerEquipConfig.EquipType.Necklace:
                        return QueueController.S.Purple1NecklaceQueue.Dequeue();
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
        QueueController.S.fightBG.GetComponent<FightBg>().ChuanSongZhen.SetActive(true);
    }

    public void JiHuoChuanSongZhen()
    {
        QueueController.S.fightBG.GetComponent<FightBg>().ChuanSongZhenAnimator.Play("NewSequenceAnim");
    }
    private void Start()
    {
        KillMonsterCount = 0;
        
        fightTimeText = QueueController.S.fightBG.GetComponent<FightBg>().fightTimeText;

        
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
            QueueController.S.gamePlayer.transform.Find("Rage").gameObject.SetActive(true);
        });
        //护盾技能
        FightBGController.S.shieldButton.onClick.AddListener(() =>
        {
            QueueController.S.gamePlayer.transform.Find("Shield").gameObject.SetActive(true);
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
            QueueController.S.gamePlayer.ShowArrow();
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
             QueueController.S.MonsterColliderDic.Add(treeManBoss.collider2D,treeManBoss);
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
            QueueController.S.MonsterColliderDic.Add(huoShanBoss.collider2D,huoShanBoss);
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
            QueueController.S.MonsterColliderDic.Add(ZhaoZeboss.collider2D,ZhaoZeboss);
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
            QueueController.S.MonsterColliderDic.Add(xieZiboss.collider2D,xieZiboss);

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
            QueueController.S.MonsterColliderDic.Add(XueRenBoss.collider2D,XueRenBoss);
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
                    QueueController.S.MonsterColliderDic.Add(LeiShouBoss.collider2D,LeiShouBoss);
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
                    QueueController.S.MonsterColliderDic.Add(KuiJiaBoss.collider2D,KuiJiaBoss);
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
                    QueueController.S.MonsterColliderDic.Add(BaoZiBoss.collider2D,BaoZiBoss);
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
                    QueueController.S.MonsterColliderDic.Add(HuoLangBoss.collider2D,HuoLangBoss);
                    break;
                
                case MJLevel.Orange:
                    ShuangDaoBoss ShuangDaoBoss = Instantiate(Resources.Load<ShuangDaoBoss>("Prefabs/Monster/MJ/ShuangDao/ShuangDaoBoss"));
                    ShuangDaoBoss.gameObject.SetActive(true);
                    ShuangDaoBoss.IsSkill = true;
                    ShuangDaoBoss.transform.position = new Vector3(0, 0, 0f);
                    SkeletonAnimation sk4 = ShuangDaoBoss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>();
                    sk4.AnimationState.SetAnimation(0,"chuchang",false);
                    ShuangDaoBoss.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    QueueController.S.MonsterColliderDic.Add(ShuangDaoBoss.collider2D,ShuangDaoBoss);
                    break;
                
                case MJLevel.Red1:
                    HuoShouBoss HuoShouBoss = Instantiate(Resources.Load<HuoShouBoss>("Prefabs/Monster/MJ/HuoShou/HuoShouBoss"));
                    HuoShouBoss.gameObject.SetActive(true);
                    HuoShouBoss.transform.position = new Vector3(0, 0, 0f);
                    SkeletonAnimation sk5 = HuoShouBoss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>();
                    sk5.AnimationState.SetAnimation(0,"move",false);
                    QueueController.S.MonsterColliderDic.Add(HuoShouBoss.collider2D,HuoShouBoss);
                    break;
                
                case MJLevel.Red2:
                    DaEYuBoss DaEYuBoss = Instantiate(Resources.Load<DaEYuBoss>("Prefabs/Monster/MJ/DaEYu/DaEYuBoss"));
                    DaEYuBoss.gameObject.SetActive(true);
                    DaEYuBoss.transform.position = new Vector3(0, 0, 0f);
                    SkeletonAnimation sk6 = DaEYuBoss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>();
                    sk6.AnimationState.SetAnimation(0,"move",false);
                    QueueController.S.MonsterColliderDic.Add(DaEYuBoss.collider2D,DaEYuBoss);
                    break;
                
                
                case MJLevel.Red3:
                    ShuYaoBoss ShuYaoBoss = Instantiate(Resources.Load<ShuYaoBoss>("Prefabs/Monster/MJ/ShuYao/ShuYaoBoss"));
                    ShuYaoBoss.gameObject.SetActive(true);
                    ShuYaoBoss.transform.position = new Vector3(0, 0, 0f);
                    SkeletonAnimation sk7 = ShuYaoBoss.transform.Find("parent/SkeletonAnimation").GetComponent<SkeletonAnimation>();
                    sk7.AnimationState.SetAnimation(0,"move",false);
                    QueueController.S.MonsterColliderDic.Add(ShuYaoBoss.collider2D,ShuYaoBoss);
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
        QueueController.S.gamePlayer.playerSkeleton.timeScale = 0f;
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
        QueueController.S.gamePlayer.playerSkeleton.timeScale = 1f;
    }


    public void CreatePlayer()
    {
        if (QueueController.S.gamePlayer != null)
        {
            QueueController.S.gamePlayer.gameObject.SetActive(true);
            QueueController.S.gamePlayer.transform.position=new  Vector3(0,0,0);
            QueueController.S.gamePlayer.playerSkeleton.AnimationState.SetAnimation(0, "idle", false);
            QueueController.S.gamePlayer.IsDie = false;
            return;
        }
        QueueController.S.gamePlayer = Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"),QueueController.S.transform).GetComponent<Player>();
        QueueController.S.gamePlayer.playerSkeleton.AnimationState.SetAnimation(0, "idle", false);
        QueueController.S.gamePlayer.transform.position = Vector2.zero;
        
    }

    // 获取距离玩家10单位的圆周上随机一点
    Vector2 GetRandomPointOnCircle(float radius = 10f)
    {
        Vector2 pos = Vector2.zero;
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        pos=(Vector2)QueueController.S.gamePlayer.transform.position + randomDirection * radius;
        while (pos.x <= CameraContraller.S.LeftLimit + 2 || pos.x > CameraContraller.S.RightLimit - 2 ||
               pos.y > CameraContraller.S.UpLimit - 2 || pos.y < CameraContraller.S.ButtomLimit + 2)
        {
            randomDirection = Random.insideUnitCircle.normalized;
            pos=(Vector2)QueueController.S.gamePlayer.transform.position + randomDirection * radius;
        }
        // 乘以半径并加上玩家位置
        return pos;
    }

    public void CreateEliteMonster()
    {
        if (GameOver||EliteMonster==MonsterTypeByName.None)
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
        if (SceneManager.GetActiveScene().name != "FightScene")
        {
            return;
        }
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
                if (MonsterConfig.MonsterTypeDic[item] == MonsterType.Elite)
                {
                    EliteMonster=item;
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
                    QueueController.S.GameMaxHp += 0.03f * GlobalPlayerAttribute.TotalMaxHp;
                    QueueController.S.GameCurrentHp+= 0.03f * GlobalPlayerAttribute.TotalMaxHp;
                }
                else
                {
                    QueueController.S.GameMaxHp += (GlobalPlayerAttribute.TotalMaxHp -
                                                    (TotalAddHp - 0.03f * GlobalPlayerAttribute.TotalMaxHp));
                    QueueController.S.GameCurrentHp += (GlobalPlayerAttribute.TotalMaxHp -
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
        foreach (var item in QueueController.S.EquipBaseSet)
        {
            item.speed = 4;
            item.isPickUp = true;
        }
        foreach (var item in QueueController.S.PropBaseSet)
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

        if (BossJiHuo && Vector2.Distance(QueueController.S.gamePlayer.transform.position, Vector2.zero) < 2)
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

            float distance = Vector3.Distance(QueueController.S.gamePlayer.transform.position, monster.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestMonster = monster;
            }
        }

        return nearestMonster;
    }
}