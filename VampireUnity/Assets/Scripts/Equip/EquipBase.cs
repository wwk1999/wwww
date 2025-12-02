using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using Mysql;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SuitType
{
    None,
    TreeMan,
    HuoShan
}
public class EquipBase : BagObjectBase
{
    [NonSerialized]public Rigidbody2D equipRb;
   [NonSerialized]public string equipName;//装备名字
   [NonSerialized]public EquipTable EquipAttributes; // 装备属性
    [NonSerialized]public float speed = 5f; // 装备跟随的速度
    [NonSerialized]public bool isPickUp = false; // 是否被拾取
    [NonSerialized]public SpriteRenderer SpriteRenderer;
    [NonSerialized]public SuitType suitType = SuitType.None; // 装备套装类型
    
    [NonSerialized]private Coroutine floatEffectCoroutine; // 添加协程引用
    
    [NonSerialized]public List<DamageEntryInfo> damageEntryInfos=new List<DamageEntryInfo>();
    [NonSerialized]public List<DefenseEntryInfo> defenseEntryInfos=new List<DefenseEntryInfo>();


    public void InitEntry()
    {
        if (EquipAttributes.equip_type_id == 1 || EquipAttributes.equip_type_id == 4 ||
            EquipAttributes.equip_type_id == 5)
        {
            for (int i = 1; i < EquipAttributes.Quality; i++)
            {
               var damageEntryInfo=new DamageEntryInfo();
               int randomIndex = Random.Range(0, EntryConfig.DamageEntryList.Count);
               damageEntryInfo.DamageEntry = EntryConfig.DamageEntryList[randomIndex];
               float randomValue=Random.Range(EntryConfig.DamageEntryConfigs[damageEntryInfo.DamageEntry].minValue, EntryConfig.DamageEntryConfigs[damageEntryInfo.DamageEntry].maxValue);
               float value = Mathf.Round(randomValue*100)/100;
               damageEntryInfo.Value = value;
               damageEntryInfos.Add(damageEntryInfo);
            }
        }
        else
        {
            for (int i = 1; i < EquipAttributes.Quality; i++)
            {
                var DefenseEntryInfo=new DefenseEntryInfo();
                int randomIndex = Random.Range(0, EntryConfig.DefenseEntryList.Count);
                DefenseEntryInfo.DefenseEntry = EntryConfig.DefenseEntryList[randomIndex];
                float randomValue=Random.Range(EntryConfig.DefenseEntryConfigs[DefenseEntryInfo.DefenseEntry].minValue, EntryConfig.DefenseEntryConfigs[DefenseEntryInfo.DefenseEntry].maxValue);
                float value = Mathf.Round(randomValue*100)/100;
                DefenseEntryInfo.Value = value;
                defenseEntryInfos.Add(DefenseEntryInfo);
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
        var distance = Vector3.Distance(transform.position, GameController.S.gamePlayer.transform.position);
        if (distance < 1.0f)
        {
              isPickUp = true;
        }
        if (isPickUp)
        {
            transform.position = Vector3.Lerp(transform.position, GameController.S.gamePlayer.transform.position,
                Time.deltaTime * speed);
            if (floatEffectCoroutine != null)
            {
                StopCoroutine(floatEffectCoroutine);
                floatEffectCoroutine = null;
            }
        }

        if (distance < 0.2f)
        {
            Debug.Log("名字："+EquipAttributes.EquipName);
            //将这件装备的属性添加到数据库
            EquipIDData.S.SavaEquip(EquipAttributes);
            StoreController.S.SaveStoreData();
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowToast,EquipAttributes);
            

            //如果被拾取，销毁装备
            gameObject.SetActive(false);
            EnEquipQueue(EquipAttributes);
        }
    }


    public void EnEquipQueue(EquipTable equipAttributes)
    {
        switch (equipAttributes.equip_type_id)
        {
            case 1:
                switch (equipAttributes.suitid)
                {
                    case 1:
                        GameController.S.PrimaryCloakQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        GameController.S.GreenCloakQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        GameController.S.BlueCloakQueue.Enqueue(gameObject);
                        break;
                    case 4:
                        GameController.S.PurpleCloakQueue.Enqueue(gameObject);
                        break;
                    case 5:
                        GameController.S.OrangeCloakQueue.Enqueue(gameObject);
                        break;
                    case 101:
                        GameController.S.TreeManCloakQueue.Enqueue(gameObject);
                        break;
                    case 102:
                        GameController.S.HuoShanCloakQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
            case 2:
                switch (equipAttributes.suitid)
                {
                    case 1:
                        GameController.S.PrimaryClothQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        GameController.S.GreenClothQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        GameController.S.BlueClothQueue.Enqueue(gameObject);
                        break;
                    case 4:
                        GameController.S.PurpleClothQueue.Enqueue(gameObject);
                        break;
                    case 5:
                        GameController.S.OrangeClothQueue.Enqueue(gameObject);
                        break;
                    case 101:
                        GameController.S.TreeManClothQueue.Enqueue(gameObject);
                        break;
                    case 102:
                        GameController.S.HuoShanClothQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
            case 3:
                switch (equipAttributes.suitid)
                {
                    case 1:
                        GameController.S.PrimaryHelmetQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        GameController.S.GreenHelmetQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        GameController.S.BlueHelmetQueue.Enqueue(gameObject);
                        break;
                    case 4:
                        GameController.S.PurpleHelmetQueue.Enqueue(gameObject);
                        break;
                    case 5:
                        GameController.S.OrangeHelmetQueue.Enqueue(gameObject);
                        break;
                    case 101:
                        GameController.S.TreeManHelmetQueue.Enqueue(gameObject);
                        break;
                    case 102:
                        GameController.S.HuoShanHelmetQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
            case 4:
                switch (equipAttributes.suitid)
                {
                    case 1:
                        GameController.S.PrimaryNecklaceQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        GameController.S.GreenNecklaceQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        GameController.S.BlueNecklaceQueue.Enqueue(gameObject);
                        break;
                    case 4:
                        GameController.S.PurpleNecklaceQueue.Enqueue(gameObject);
                        break;
                    case 5:
                        GameController.S.OrangeNecklaceQueue.Enqueue(gameObject);
                        break;
                    case 101:
                        GameController.S.TreeManNecklaceQueue.Enqueue(gameObject);
                        break;
                    case 102:
                        GameController.S.HuoShanNecklaceQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
            case 5:
                switch (equipAttributes.suitid)
                {
                    case 1:
                        GameController.S.PrimaryRingQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        GameController.S.GreenRingQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        GameController.S.BlueRingQueue.Enqueue(gameObject);
                        break;
                    case 4:
                        GameController.S.PurpleRingQueue.Enqueue(gameObject);
                        break;
                    case 5:
                        GameController.S.OrangeRingQueue.Enqueue(gameObject);
                        break;
                    case 101:
                        GameController.S.TreeManRingQueue.Enqueue(gameObject);
                        break;
                    case 102:
                        GameController.S.HuoShanRingQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
            case 6:
                switch (equipAttributes.suitid)
                {
                    case 1:
                        GameController.S.PrimaryShoeQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        GameController.S.GreenShoeQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        GameController.S.BlueShoeQueue.Enqueue(gameObject);
                        break;
                    case 4:
                        GameController.S.PurpleShoeQueue.Enqueue(gameObject);
                        break;
                    case 5:
                        GameController.S.OrangeShoeQueue.Enqueue(gameObject);
                        break;
                    case 101:
                        GameController.S.TreeManShoeQueue.Enqueue(gameObject);
                        break;
                    case 102:
                        GameController.S.HuoShanShoeQueue.Enqueue(gameObject);
                        break;
                }
                break;
        }
    }
}
