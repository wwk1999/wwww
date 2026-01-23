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

   private void Start()
   {
      ExitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      LanguageDropdown.onValueChanged.AddListener(OnLanguageChanged);
      ObserverModuleManager.S.RegisterEvent(ConstKeys.SwitchLanguage, SwitchLanguage);
   }

   public void SwitchLanguage(object[] obj)
   {
      LanguageType languageType = (LanguageType)obj[0];
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
            ObserverModuleManager.S.SendEvent(ConstKeys.SwitchLanguage, LanguageType.Chinese);
            break;
         case 1:
            Debug.Log("切换到英文");
            ObserverModuleManager.S.SendEvent(ConstKeys.SwitchLanguage, LanguageType.English);
            break;
         case 2:
            Debug.Log("切换到韩文");
            ObserverModuleManager.S.SendEvent(ConstKeys.SwitchLanguage, LanguageType.Han);
            break;
         case 3:
            Debug.Log("切换到日文");
            ObserverModuleManager.S.SendEvent(ConstKeys.SwitchLanguage, LanguageType.Ri);
            break;
         default:
            break;
      }
   }
    
   // 可选：在销毁时移除事件监听（防止内存泄漏）
   private void OnDestroy()
   {
      LanguageDropdown.onValueChanged.RemoveListener(OnLanguageChanged);
   }
}
