using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShiZhuangWindow : MonoBehaviour
{
  public SkeletonGraphic ske;
  public GameObject ListContent;
  public GameObject JieSuoContent;
  public GameObject AttributeContent;
  public Button ExitButton;
  public Button HuanZhuangButton;

  private ShiZhuangType _shiZhuangType=ShiZhuangType.None;

  public string GetSkinNameByType(ShiZhuangType shiZhuangType)
  {
    switch (shiZhuangType)
    {
      case ShiZhuangType.GreenDian:
        return "greendian";
      case ShiZhuangType.GreenHuo:
        return "greenhuo";
      case ShiZhuangType.GreenIce:
        return "greenbing";
      case ShiZhuangType.GreenHeiAn:
        return "greenheian";
      
      case ShiZhuangType.BlueDian:
        return "bluedian";
      case ShiZhuangType.BlueHuo:
        return "bluehuo";
      case ShiZhuangType.BlueIce:
        return "bluebing";
      case ShiZhuangType.BlueHeiAn:
        return "blueheian";
      
      case ShiZhuangType.PurpleDian:
        return "purpledian";
      case ShiZhuangType.PurpleHuo:
        return "purplehuo";
      case ShiZhuangType.PurpleIce:
        return "purplebing";
      case ShiZhuangType.PurpleHeiAn:
        return "purpleheian";
      
      case ShiZhuangType.OrangeDian:
        return "orangedian";
      case ShiZhuangType.OrangeHuo:
        return "orangehuo";
      case ShiZhuangType.OrangeIce:
        return "orangebing";
      case ShiZhuangType.OrangeHeiAn:
        return "orangeheian";
    }
    return null;
  }
  public void ShowShiZhuang(object[] obj)
  {
    ShiZhuangType shiZhuangType = (ShiZhuangType)obj[0];
    _shiZhuangType=shiZhuangType;
    ske.gameObject.SetActive(true);
    Spine.Skeleton skeleton = ske.Skeleton;
    string skinName = GetSkinNameByType(shiZhuangType);
    Spine.Skin skin = skeleton.Data.FindSkin(skinName);
    if (skin != null)
    {
      skeleton.SetSkin(skin);
      skeleton.SetupPoseSlots();
      ske.LateUpdate();
    }
    else
    {
      Debug.LogWarning("皮肤 " + skinName + " 不存在！");
    }

    foreach (Transform item in JieSuoContent.transform)
    {
      Destroy(item.gameObject);
    }
    foreach (Transform item in AttributeContent.transform)
    {
      Destroy(item.gameObject);
    }

    ShiZhuangJieSuoItem shiZhuangJieSuoItem = ShiZhuangConfig.ShiZhuangJieSuoDic[shiZhuangType];
    ShiZhuangAttributeItem shiZhuangAttributeItem = ShiZhuangConfig.ShiZhuangAttributeDic[shiZhuangType];

    var jiesuo1 = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/TiaoJianItem"),JieSuoContent.transform);
    jiesuo1.GetComponent<TextMeshProUGUI>().text = $"人物等级><color=green>{shiZhuangJieSuoItem.level}</color>";
    string jiesuo2pro = null;
    switch (shiZhuangJieSuoItem.yuanSuType)
    {
      case YuanSuType.Huo:
        jiesuo2pro = "火";
        break;
      case YuanSuType.Ice:
        jiesuo2pro = "冰";
        break;
      case YuanSuType.Dian:
        jiesuo2pro = "电";
        break;
      case YuanSuType.HeiAn:
        jiesuo2pro = "黑暗";
        break;
    }
    var jiesuo2 = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/TiaoJianItem"),JieSuoContent.transform);
    jiesuo2.GetComponent<TextMeshProUGUI>().text = jiesuo2pro+$"系武器总等级><color=green>{shiZhuangJieSuoItem.weaponLevel}</color>";
    var jiesuo3 = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/TiaoJianItem"),JieSuoContent.transform);
    jiesuo3.GetComponent<TextMeshProUGUI>().text = jiesuo2pro+$"元素伤害><color=green>{shiZhuangJieSuoItem.yuansuDamage}</color>";

    var attribute1 = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/TiaoJianItem"),AttributeContent.transform);
    attribute1.GetComponent<TextMeshProUGUI>().text = $"魔力+<color=green>{shiZhuangAttributeItem.Attack}%</color>";

    var attribute2 = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/TiaoJianItem"),AttributeContent.transform);
    attribute2.GetComponent<TextMeshProUGUI>().text = $"生命值+<color=green>{shiZhuangAttributeItem.Hp}%</color>";

    var attribute3 = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/TiaoJianItem"),AttributeContent.transform);
    attribute3.GetComponent<TextMeshProUGUI>().text = $"移速+<color=green>{shiZhuangAttributeItem.MoveSpeed}%</color>";

    var attribute4 = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/TiaoJianItem"),AttributeContent.transform);
    attribute4.GetComponent<TextMeshProUGUI>().text = $"攻击速度+<color=green>{shiZhuangAttributeItem.AttackSpeed}%</color>";

    
  }
  private void Start()
  {
    ObserverModuleManager.S.RegisterEvent("ShowShiZhuang",ShowShiZhuang);
    ExitButton.onClick.AddListener(() =>
    {
      gameObject.SetActive(false);
    });
    HuanZhuangButton.onClick.AddListener(() =>
    {
      switch (_shiZhuangType)
      {
        case ShiZhuangType.GreenHuo:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem.level ||
              PlayerData.S.HuoAllLevel < shiZhuangJieSuoItem.weaponLevel ||
              GlobalPlayerAttribute.HuoYuanSuBase < shiZhuangJieSuoItem.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        case ShiZhuangType.GreenIce:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem1 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem1.level ||
              PlayerData.S.IceAllLevel < shiZhuangJieSuoItem1.weaponLevel ||
              GlobalPlayerAttribute.IceYuanSuBase < shiZhuangJieSuoItem1.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        
        case ShiZhuangType.GreenHeiAn:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem2 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem2.level ||
              PlayerData.S.HeiAnAllLevel < shiZhuangJieSuoItem2.weaponLevel ||
              GlobalPlayerAttribute.HeiAnYuanSuBase < shiZhuangJieSuoItem2.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        
        case ShiZhuangType.GreenDian:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem3 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem3.level ||
              PlayerData.S.DianAllLevel < shiZhuangJieSuoItem3.weaponLevel ||
              GlobalPlayerAttribute.DianYuanSuBase < shiZhuangJieSuoItem3.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        
        
        
        case ShiZhuangType.BlueHuo:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem11 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem11.level ||
              PlayerData.S.HuoAllLevel < shiZhuangJieSuoItem11.weaponLevel ||
              GlobalPlayerAttribute.HuoYuanSuBase < shiZhuangJieSuoItem11.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        case ShiZhuangType.BlueIce:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem12 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem12.level ||
              PlayerData.S.IceAllLevel < shiZhuangJieSuoItem12.weaponLevel ||
              GlobalPlayerAttribute.IceYuanSuBase < shiZhuangJieSuoItem12.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        
        case ShiZhuangType.BlueHeiAn:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem23 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem23.level ||
              PlayerData.S.HeiAnAllLevel < shiZhuangJieSuoItem23.weaponLevel ||
              GlobalPlayerAttribute.HeiAnYuanSuBase < shiZhuangJieSuoItem23.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        
        case ShiZhuangType.BlueDian:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem34 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem34.level ||
              PlayerData.S.DianAllLevel < shiZhuangJieSuoItem34.weaponLevel ||
              GlobalPlayerAttribute.DianYuanSuBase < shiZhuangJieSuoItem34.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        
        
        
        case ShiZhuangType.PurpleHuo:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem6 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem6.level ||
              PlayerData.S.HuoAllLevel < shiZhuangJieSuoItem6.weaponLevel ||
              GlobalPlayerAttribute.HuoYuanSuBase < shiZhuangJieSuoItem6.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        case ShiZhuangType.PurpleIce:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem16 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem16.level ||
              PlayerData.S.IceAllLevel < shiZhuangJieSuoItem16.weaponLevel ||
              GlobalPlayerAttribute.IceYuanSuBase < shiZhuangJieSuoItem16.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        
        case ShiZhuangType.PurpleHeiAn:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem26 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem26.level ||
              PlayerData.S.HeiAnAllLevel < shiZhuangJieSuoItem26.weaponLevel ||
              GlobalPlayerAttribute.HeiAnYuanSuBase < shiZhuangJieSuoItem26.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        
        case ShiZhuangType.PurpleDian:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem36 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem36.level ||
              PlayerData.S.DianAllLevel < shiZhuangJieSuoItem36.weaponLevel ||
              GlobalPlayerAttribute.DianYuanSuBase < shiZhuangJieSuoItem36.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        
        
        
        
        
        case ShiZhuangType.OrangeHuo:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem5 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem5.level ||
              PlayerData.S.HuoAllLevel < shiZhuangJieSuoItem5.weaponLevel ||
              GlobalPlayerAttribute.HuoYuanSuBase < shiZhuangJieSuoItem5.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        case ShiZhuangType.OrangeIce:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem15 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem15.level ||
              PlayerData.S.IceAllLevel < shiZhuangJieSuoItem15.weaponLevel ||
              GlobalPlayerAttribute.IceYuanSuBase < shiZhuangJieSuoItem15.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        
        case ShiZhuangType.OrangeHeiAn:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem25 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem25.level ||
              PlayerData.S.HeiAnAllLevel < shiZhuangJieSuoItem25.weaponLevel ||
              GlobalPlayerAttribute.HeiAnYuanSuBase < shiZhuangJieSuoItem25.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
        
        case ShiZhuangType.OrangeDian:
          ShiZhuangJieSuoItem shiZhuangJieSuoItem35 = ShiZhuangConfig.ShiZhuangJieSuoDic[_shiZhuangType];
          if (PlayerData.S.level < shiZhuangJieSuoItem35.level ||
              PlayerData.S.DianAllLevel < shiZhuangJieSuoItem35.weaponLevel ||
              GlobalPlayerAttribute.DianYuanSuBase < shiZhuangJieSuoItem35.yuansuDamage / 100)
          {
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"条件不足");
            return;
          }
          PlayerData.S.shiZhuangType=_shiZhuangType;
          break;
      }
      ObserverModuleManager.S.SendEvent("PlayerHuanZhuang");
    });
  }

  private void OnEnable()
  {
    ske.gameObject.SetActive(false);
    foreach (Transform item in AttributeContent.transform)
    {
      Destroy(item.gameObject);
    }
    foreach (Transform item in JieSuoContent.transform)
    {
      Destroy(item.gameObject);
    }
    foreach (Transform item in ListContent.transform)
    {
      Destroy(item.gameObject);
    }

    foreach (var item in ShiZhuangConfig.ShiZhuangNameDic)
    {
      ShiZhuangItem shizhuangitem=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ShiZhuangItem"),ListContent.transform).GetComponent<ShiZhuangItem>();
      shizhuangitem.Type = item.Key;
      shizhuangitem.SetShiZhuangItem();
    }
  }
}
