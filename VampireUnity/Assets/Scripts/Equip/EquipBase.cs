using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Equip;
using Mysql;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SuitType
{
    None,
    Cloak,
    Cloth,
    Helmet,
    Shoe,
    Necklace,
    Ring
}

public enum OrangeEquipType
{
    None,
    BuWangChuXin,
    CloakFortureAdd,
    DuAddDuQuan,
    FireBaoZha,
    HeiDongAddSpeed,
    LvQuanAddScale,
    PuTong3ChuanTou,
    XuKongAdd2Dan,
    AddDefenseForTime,
    AllReplyAddPercent,
    ClothFortureAdd,
    FinalDamageReductionFixed,
    HpReductionReplyAdd50,
    ReplyDeath,
    AddHpForTime,
    DelayDamage,
    FinalDamageReductionPercent,
    HelmetFortureAdd,
    HpReductionAddDefense,
    Skill1AddRange,
    Skill2AddRange,
    FinalDamageAddPercent,
    NecklaceFortureAdd,
    NormalAddDamage,
    NoSkill,
    RecudeHpAddAttack,
    Skill1ReplaceNormalAttack,
    Skill2AddDan,
    Skill3Bian3,
    AddAttackForTime,
    FanPuGuiZhen,
    KillNormal,
    RingFortureAdd,
    Skill1YiDianDouble,
    Skill2RotateAdd,
    Skill3AddRange,
    DashCd,
    DashRange,
    ExAdd,
    JianSuAddAttack,
    MoveSpeedAdd,
    ShoeFortureAdd,
}
public class EquipBase : BagObjectBase
{
    [NonSerialized]public Rigidbody2D equipRb;
   [NonSerialized]public string equipName;//装备名字
   [NonSerialized]public EquipTable EquipAttributes; // 装备属性
    [NonSerialized]public float speed = 12f; // 装备跟随的速度
    [NonSerialized]public bool isPickUp = false; // 是否被拾取
    [NonSerialized]public SpriteRenderer SpriteRenderer;
    [NonSerialized]public SuitType suitType = SuitType.None; // 装备套装类型
    
    [NonSerialized]private Coroutine floatEffectCoroutine; // 添加协程引用
    [NonSerialized] private int KongCount = 0;

    public void SetKongCount()
    {
        int random =0;
        switch (EquipAttributes.Quality)
        {
            case 1:
                KongCount = 0;
                break;
            case 2:
                random=Random.Range(1, 3);
                KongCount = random;
                break;
            case 3:
                random=Random.Range(1, 4);
                KongCount = random;
                break;
            case 4:
                random=Random.Range(1, 5);
                KongCount = random;
                break;
            case 5:
                random=Random.Range(1, 6);
                KongCount = random;
                break;
        }

        for (int i = 1; i <= random; i++)
        {
            EquipAttributes.BaoShiDic.Add(i,new BaoShiInfo(){BaoShiType = BaoShiType.None});
        }
    }
    public int GetOrangeLevel()
    {
        switch (PlayerData.S.mJShowLevel)
        {
            case MJLevel.White:
                return 35;
            case MJLevel.Green:
                return 40;
            case MJLevel.Blue:
                return 45;
            case MJLevel.Purple:
                return 50;
            case MJLevel.Orange:
                return 55;
            case MJLevel.Red1:
                return 60;
            case MJLevel.Red2:
                return 65;
            case MJLevel.Red3:
                return 70;
            case MJLevel.Red4:
                return 75;
            case MJLevel.Red5:
                return 80;
            case MJLevel.Red6:
                return 85;
            case MJLevel.Red7:
                return 90;
            case MJLevel.Red8:
                return 95;
            case MJLevel.Red9:
                return 100;
        }

        return 1;
    }
    
    public void SetBaseAttribute()
    {
        SetKongCount();
        var equipBaseAttribute=EquipConfig.EquipBaseAttributeDic[EquipAttributes.EquipLevel];
        var qualityScale = EquipConfig.EquipQualityDic[EquipAttributes.Quality];
        float random1=Random.Range(0.8f, 1.2f);
        float random2=Random.Range(0.8f, 1.2f);
        if (EquipAttributes.EquipType == PlayerEquipConfig.EquipType.Cloak || EquipAttributes.EquipType == PlayerEquipConfig.EquipType.Necklace ||
            EquipAttributes.EquipType == PlayerEquipConfig.EquipType.Ring)
        {
            EquipAttributes.CRIT = equipBaseAttribute.Crit * qualityScale*random1;
            EquipAttributes.Damage= equipBaseAttribute.Attack * qualityScale*random2;
        }
        else
        {
            EquipAttributes.HP = equipBaseAttribute.Hp * qualityScale*random1;
            EquipAttributes.Defense= equipBaseAttribute.Defense * qualityScale*random2;
        }
    }

    public void InitEntry()
    {
        if (EquipAttributes.EquipType == PlayerEquipConfig.EquipType.Cloak || EquipAttributes.EquipType == PlayerEquipConfig.EquipType.Necklace ||
            EquipAttributes.EquipType == PlayerEquipConfig.EquipType.Ring)
        {
            for (int i = 1; i < EquipAttributes.Quality; i++)
            {
               var damageEntryInfo=new DamageEntryInfo();
               int randomIndex = Random.Range(0, EntryConfig.DamageEntryList.Count);
               damageEntryInfo.DamageEntry = EntryConfig.DamageEntryList[randomIndex];
               float randomValue=Random.Range(EntryConfig.DamageEntryConfigs[damageEntryInfo.DamageEntry].minValue*EquipConfig.EquipEntryQualityDic[EquipAttributes.Quality], EntryConfig.DamageEntryConfigs[damageEntryInfo.DamageEntry].maxValue*EquipConfig.EquipEntryQualityDic[EquipAttributes.Quality]);
               float value = Mathf.Round(randomValue*100)/100;
               damageEntryInfo.Value = value;
               EquipAttributes.damageEntryInfos.Add(damageEntryInfo);
            }
        }
        else
        {
            for (int i = 1; i < EquipAttributes.Quality; i++)
            {
                var DefenseEntryInfo=new DefenseEntryInfo();
                int randomIndex = Random.Range(0, EntryConfig.DefenseEntryList.Count);
                DefenseEntryInfo.DefenseEntry = EntryConfig.DefenseEntryList[randomIndex];
                float randomValue=Random.Range(EntryConfig.DefenseEntryConfigs[DefenseEntryInfo.DefenseEntry].minValue*EquipConfig.EquipEntryQualityDic[EquipAttributes.Quality], EntryConfig.DefenseEntryConfigs[DefenseEntryInfo.DefenseEntry].maxValue*EquipConfig.EquipEntryQualityDic[EquipAttributes.Quality]);
                float value = Mathf.Round(randomValue*100)/100;
                DefenseEntryInfo.Value = value;
                EquipAttributes.defenseEntryInfos.Add(DefenseEntryInfo);
            }
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public EquipBase(string equipName,SuitType suitType,EquipTable equipAttribute)
    {
        this.equipName = equipName;
        this.suitType = suitType;
        this.EquipAttributes = equipAttribute;
    }
    void OnEnable()
    {
        isPickUp = false;
        bagObjectType = BagObjectType.Equip;
        equipRb=GetComponent<Rigidbody2D>();
        equipRb.velocity = new Vector2(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(3f, 5f));

        StartCoroutine(StopVelocityAfterDelay(equipRb, 0.75f));
    }

    // Update is called once per frame
    private IEnumerator StopVelocityAfterDelay(Rigidbody2D rb, float delay)
    {
        yield return new WaitForSeconds(delay);
        if(rb == null)
            Debug.Log("rb为空");
        rb.velocity = Vector2.zero;
        //设置重力为0
        rb.gravityScale = 0;
        //开启协程通过transformer让装备上下浮动效果,lerp平滑过渡
        floatEffectCoroutine =StartCoroutine(FloatEffect());
        
    }
    
    private IEnumerator FloatEffect()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + new Vector3(0, 0.2f, 0);
        float duration = 0.8f; // 浮动持续时间

        while (true)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.PingPong(elapsedTime / duration, 1f);
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, QueueController.S.gamePlayer.transform.position);
        if (distance < 1.0f)
        {
              isPickUp = true;
        }
        if (isPickUp)
        {
            transform.position = Vector3.Lerp(transform.position, QueueController.S.gamePlayer.transform.position,
                Time.deltaTime * speed);
            if (floatEffectCoroutine != null)
            {
                StopCoroutine(floatEffectCoroutine);
                floatEffectCoroutine = null;
            }
        }

        if (distance < 0.2f)
        {
            //将这件装备的属性添加到数据库
            EquipIDData.S.SavaEquip(EquipAttributes);
            StoreController.S.SaveStoreData();
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowToast,EquipAttributes);
            QueueController.S.EquipBaseSet.Remove(this);
            //如果被拾取，销毁装备
            gameObject.SetActive(false);
            EnEquipQueue(EquipAttributes);
            if (EquipAttributes.Quality >= 5)
            {
                PlayerData.S.OrangeCount++;
            }

            if (PlayerData.S.DiaoLuo == false&&PlayerData.S.OrangeCount>=100)
            {
                ObserverModuleManager.S.SendEvent(ConstKeys.ShowToast,"激活新称号");
                PlayerData.S.DiaoLuo = true;
            }
        }
    }


    public void EnEquipQueue(EquipTable equipAttributes)
    {
        switch (equipAttributes.EquipType)
        {
            case PlayerEquipConfig.EquipType.Cloak:
                switch (equipAttributes.EquipQuality)
                {
                    case PlayerEquipConfig.EquipLevel.Primary:
                        QueueController.S.PrimaryCloakQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Green:
                        QueueController.S.GreenCloakQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Blue:
                        QueueController.S.BlueCloakQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Purple:
                        QueueController.S.PurpleCloakQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Orange:
                        QueueController.S.OrangeCloakQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.ZhaoZe:
                        QueueController.S.ZhaoZeCloakQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Purple1:
                        QueueController.S.Purple1CloakQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.TreeMan:
                        QueueController.S.TreeManCloakQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.HuoShan:
                        QueueController.S.HuoShanCloakQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.XieZi:
                        QueueController.S.XieZiCloakQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.XueRen:
                        QueueController.S.XueRenCloakQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
             case PlayerEquipConfig.EquipType.Cloth:
                switch (equipAttributes.EquipQuality)
                {
                    case PlayerEquipConfig.EquipLevel.Primary:
                        QueueController.S.PrimaryClothQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Green:
                        QueueController.S.GreenClothQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Blue:
                        QueueController.S.BlueClothQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Purple:
                        QueueController.S.PurpleClothQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Orange:
                        QueueController.S.OrangeClothQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.ZhaoZe:
                        QueueController.S.ZhaoZeClothQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Purple1:
                        QueueController.S.Purple1ClothQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.TreeMan:
                        QueueController.S.TreeManClothQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.HuoShan:
                        QueueController.S.HuoShanClothQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.XieZi:
                        QueueController.S.XieZiClothQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.XueRen:
                        QueueController.S.XueRenClothQueue.Enqueue(gameObject);
                        break;
                }
                break;
             
             
             
             
              case PlayerEquipConfig.EquipType.Helmet:
                switch (equipAttributes.EquipQuality)
                {
                    case PlayerEquipConfig.EquipLevel.Primary:
                        QueueController.S.PrimaryHelmetQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Green:
                        QueueController.S.GreenHelmetQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Blue:
                        QueueController.S.BlueHelmetQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Purple:
                        QueueController.S.PurpleHelmetQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Orange:
                        QueueController.S.OrangeHelmetQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.ZhaoZe:
                        QueueController.S.ZhaoZeHelmetQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Purple1:
                        QueueController.S.Purple1HelmetQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.TreeMan:
                        QueueController.S.TreeManHelmetQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.HuoShan:
                        QueueController.S.HuoShanHelmetQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.XieZi:
                        QueueController.S.XieZiHelmetQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.XueRen:
                        QueueController.S.XueRenHelmetQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
              
              
              
              
               case PlayerEquipConfig.EquipType.Ring:
                switch (equipAttributes.EquipQuality)
                {
                    case PlayerEquipConfig.EquipLevel.Primary:
                        QueueController.S.PrimaryRingQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Green:
                        QueueController.S.GreenRingQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Blue:
                        QueueController.S.BlueRingQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Purple:
                        QueueController.S.PurpleRingQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Orange:
                        QueueController.S.OrangeRingQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.ZhaoZe:
                        QueueController.S.ZhaoZeRingQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Purple1:
                        QueueController.S.Purple1RingQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.TreeMan:
                        QueueController.S.TreeManRingQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.HuoShan:
                        QueueController.S.HuoShanRingQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.XieZi:
                        QueueController.S.XieZiRingQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.XueRen:
                        QueueController.S.XueRenRingQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
               
               
               
               
               
                case PlayerEquipConfig.EquipType.Necklace:
                switch (equipAttributes.EquipQuality)
                {
                    case PlayerEquipConfig.EquipLevel.Primary:
                        QueueController.S.PrimaryNecklaceQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Green:
                        QueueController.S.GreenNecklaceQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Blue:
                        QueueController.S.BlueNecklaceQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Purple:
                        QueueController.S.PurpleNecklaceQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Orange:
                        QueueController.S.OrangeNecklaceQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.ZhaoZe:
                        QueueController.S.ZhaoZeNecklaceQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Purple1:
                        QueueController.S.Purple1NecklaceQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.TreeMan:
                        QueueController.S.TreeManNecklaceQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.HuoShan:
                        QueueController.S.HuoShanNecklaceQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.XieZi:
                        QueueController.S.XieZiNecklaceQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.XueRen:
                        QueueController.S.XueRenNecklaceQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
                
                
                
                
                 case PlayerEquipConfig.EquipType.Shoe:
                switch (equipAttributes.EquipQuality)
                {
                    case PlayerEquipConfig.EquipLevel.Primary:
                        QueueController.S.PrimaryShoeQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Green:
                        QueueController.S.GreenShoeQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Blue:
                        QueueController.S.BlueShoeQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Purple:
                        QueueController.S.PurpleShoeQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Orange:
                        QueueController.S.OrangeShoeQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.ZhaoZe:
                        QueueController.S.ZhaoZeShoeQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.Purple1:
                        QueueController.S.Purple1ShoeQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.TreeMan:
                        QueueController.S.TreeManShoeQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.HuoShan:
                        QueueController.S.HuoShanShoeQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.XieZi:
                        QueueController.S.XieZiShoeQueue.Enqueue(gameObject);
                        break;
                    case PlayerEquipConfig.EquipLevel.XueRen:
                        QueueController.S.XueRenShoeQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
            
        }
    }
}
