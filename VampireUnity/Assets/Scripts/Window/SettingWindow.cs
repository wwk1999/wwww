using System;
using System.Collections;
using System.Collections.Generic;
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
            
            break;
         case 1:
            Debug.Log("切换到英文");
            break;
         case 2:
            Debug.Log("切换到日文");
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
