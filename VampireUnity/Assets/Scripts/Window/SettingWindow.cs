using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingWindow : MonoBehaviour
{
   public Button ExitButton;
   public TextMeshProUGUI Language;
   public TextMeshProUGUI Audio;
   public TMP_Dropdown LanguageDropdown;
   public TMP_Dropdown RateDropdown;
   public TMP_Dropdown MoShiDropdown;


   private void Start()
   {
      ExitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      LanguageDropdown.onValueChanged.AddListener(OnLanguageChanged);
      RateDropdown.onValueChanged.AddListener(OnRateChanged);
      MoShiDropdown.onValueChanged.AddListener(OnMoShiChanged);

      ObserverModuleManager.S.RegisterEvent(ConstKeys.SwitchLanguage, SwitchLanguageObj);
   }

   private void OnEnable()
   {
      switch (PlayerData.S.langType)
      {
         case LanguageType.Chinese:
            LanguageDropdown.value = 0;
            break;
         case LanguageType.English:
            LanguageDropdown.value = 1;
            break;
         case LanguageType.Han:
            LanguageDropdown.value = 2;
            break;
         case LanguageType.Ri:
            LanguageDropdown.value = 3;
            break;
      }
      SwitchLanguage(PlayerData.S.langType);
   }

   public void SwitchLanguageObj(object[] obj)
   {
      LanguageType languageType = (LanguageType)obj[0];
      SwitchLanguage(languageType);
   }


   public void SwitchLanguage(LanguageType languageType)
   {
      switch (languageType)
      {
         case LanguageType.Chinese:
            Language.text = LanguageConfig.LanguageItems[LanguageType.Chinese].SettingWindowLanguage.Language;
            Audio.text = LanguageConfig.LanguageItems[LanguageType.Chinese].SettingWindowLanguage.Audio;
            LanguageDropdown.options[0].text = LanguageConfig.LanguageItems[LanguageType.Chinese].SettingWindowLanguage.ZhongWen;
            LanguageDropdown.options[1].text =LanguageConfig.LanguageItems[LanguageType.Chinese].SettingWindowLanguage.YingWen;
            LanguageDropdown.options[2].text = LanguageConfig.LanguageItems[LanguageType.Chinese].SettingWindowLanguage.HanWen;
            LanguageDropdown.options[3].text = LanguageConfig.LanguageItems[LanguageType.Chinese].SettingWindowLanguage.RiWen;
            LanguageDropdown.RefreshShownValue();
            break;
         case LanguageType.English:
            Language.text = LanguageConfig.LanguageItems[LanguageType.English].SettingWindowLanguage.Language;
            Audio.text = LanguageConfig.LanguageItems[LanguageType.English].SettingWindowLanguage.Audio;
            LanguageDropdown.options[0].text = LanguageConfig.LanguageItems[LanguageType.English].SettingWindowLanguage.ZhongWen;
            LanguageDropdown.options[1].text =LanguageConfig.LanguageItems[LanguageType.English].SettingWindowLanguage.YingWen;
            LanguageDropdown.options[2].text = LanguageConfig.LanguageItems[LanguageType.English].SettingWindowLanguage.HanWen;
            LanguageDropdown.options[3].text = LanguageConfig.LanguageItems[LanguageType.English].SettingWindowLanguage.RiWen;
            LanguageDropdown.RefreshShownValue();
            break;
         case LanguageType.Han:
            Language.text = LanguageConfig.LanguageItems[LanguageType.Han].SettingWindowLanguage.Language;
            Audio.text = LanguageConfig.LanguageItems[LanguageType.Han].SettingWindowLanguage.Audio;
            LanguageDropdown.options[0].text = LanguageConfig.LanguageItems[LanguageType.Han].SettingWindowLanguage.ZhongWen;
            LanguageDropdown.options[1].text =LanguageConfig.LanguageItems[LanguageType.Han].SettingWindowLanguage.YingWen;
            LanguageDropdown.options[2].text = LanguageConfig.LanguageItems[LanguageType.Han].SettingWindowLanguage.HanWen;
            LanguageDropdown.options[3].text = LanguageConfig.LanguageItems[LanguageType.Han].SettingWindowLanguage.RiWen;
            LanguageDropdown.RefreshShownValue();
            break;
         case LanguageType.Ri:
            Language.text = LanguageConfig.LanguageItems[LanguageType.Ri].SettingWindowLanguage.Language;
            Audio.text = LanguageConfig.LanguageItems[LanguageType.Ri].SettingWindowLanguage.Audio;
            LanguageDropdown.options[0].text = LanguageConfig.LanguageItems[LanguageType.Ri].SettingWindowLanguage.ZhongWen;
            LanguageDropdown.options[1].text =LanguageConfig.LanguageItems[LanguageType.Ri].SettingWindowLanguage.YingWen;
            LanguageDropdown.options[2].text = LanguageConfig.LanguageItems[LanguageType.Ri].SettingWindowLanguage.HanWen;
            LanguageDropdown.options[3].text = LanguageConfig.LanguageItems[LanguageType.Ri].SettingWindowLanguage.RiWen;
            LanguageDropdown.RefreshShownValue();
            break;
      }
   }
   
   private void OnMoShiChanged(int selectedIndex)
   {
      switch (selectedIndex)
      {
         case 0:
            Screen.SetResolution(PlayerData.S.RateX, PlayerData.S.RateY, false);
            PlayerData.S.IsQuanPing = false;
            break;
         case 1:
            Screen.SetResolution(PlayerData.S.RateX, PlayerData.S.RateY, true);
            PlayerData.S.IsQuanPing = true;
            break;
      }
      StoreController.S.SaveStoreData();
   }

   private void OnRateChanged(int selectedIndex)
   {
      switch (selectedIndex)
      {
         case 0:
            Screen.SetResolution(1280, 720, false);
            PlayerData.S.RateX = 1280;
            PlayerData.S.RateY = 720;
            break;
         case 1:
            Screen.SetResolution(1600, 900, false);
            PlayerData.S.RateX = 1600;
            PlayerData.S.RateY = 900;
            break;
         case 2:
            Screen.SetResolution(1920, 1080, false);
            PlayerData.S.RateX = 1920;
            PlayerData.S.RateY = 1080;
            break;
         case 3:
            Screen.SetResolution(2560, 1440, false);
            PlayerData.S.RateX = 2560;
            PlayerData.S.RateY = 1440;
            break;
      }
      StoreController.S.SaveStoreData();

   }

   
   private void OnLanguageChanged(int selectedIndex)
   {
      // selectedIndex 是当前选中的选项索引（从0开始）
      Debug.Log($"选择了第 {selectedIndex} 个选项");
        
      // 获取选中的选项文本
      string selectedOption = LanguageDropdown.options[selectedIndex].text;
      Debug.Log($"选择的语言是: {selectedOption}");
        
      // 根据索引执行相应的逻辑
      switch (selectedIndex)
      {
         case 0:
            Debug.Log("切换到中文");
            PlayerData.S.langType = LanguageType.Chinese;
            ObserverModuleManager.S.SendEvent(ConstKeys.SwitchLanguage, LanguageType.Chinese);
            StoreController.S.SaveStoreData();
            break;
         case 1:
            Debug.Log("切换到英文");
            PlayerData.S.langType = LanguageType.English;
            ObserverModuleManager.S.SendEvent(ConstKeys.SwitchLanguage, LanguageType.English);
            StoreController.S.SaveStoreData();

            break;
         case 2:
            Debug.Log("切换到韩文");
            PlayerData.S.langType = LanguageType.Han;
            ObserverModuleManager.S.SendEvent(ConstKeys.SwitchLanguage, LanguageType.Han);
            StoreController.S.SaveStoreData();

            break;
         case 3:
            Debug.Log("切换到日文");
            PlayerData.S.langType = LanguageType.Ri;
            ObserverModuleManager.S.SendEvent(ConstKeys.SwitchLanguage, LanguageType.Ri);
            StoreController.S.SaveStoreData();

            break;
         default:
            break;
      }
   }
    
   // 可选：在销毁时移除事件监听（防止内存泄漏）
   private void OnDestroy()
   {
      RateDropdown.onValueChanged.RemoveListener(OnRateChanged);
      MoShiDropdown.onValueChanged.RemoveListener(OnMoShiChanged);
      LanguageDropdown.onValueChanged.RemoveListener(OnLanguageChanged);
   }
}
