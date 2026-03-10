using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainSkillInfo : MonoBehaviour
{
   public Image image;
   public TextMeshProUGUI skillName;
   public TextMeshProUGUI text;
   [NonSerialized]public SkillInfoType type;

   public void SetMainSkillInfo()
   {
      switch (type)
      {
         case SkillInfoType.IceMain:
            image.sprite=ResourcesConfig.GetSkillSprite(SkillInfoType.IceMain);
            skillName.text = "冰霜专精";
            text.text = $"每一个冰系技能点可增加<color=green>1%</color>的冰霜元素伤害，并且冰霜伤害有概率冻结敌人<color=green>1</color>s，冰霜元素伤害越高，概率越大（当前概率<color=green>{(GlobalPlayerAttribute.BingDongRate).ToString("F2")}%</color>）";
            break;
         
         case SkillInfoType.HuoMain:
            image.sprite=ResourcesConfig.GetSkillSprite(SkillInfoType.HuoMain);
            skillName.text = "火焰专精";
            text.text = $"每一个火系技能点可增加<color=green>1%</color>的火焰元素伤害，并且火焰伤害会灼烧敌人，持续<color=green>3s</color>，每秒造成一次灼烧伤害，火焰元素伤害越高，灼烧伤害越大（当前灼烧伤害<color=green>{(GlobalPlayerAttribute.HuoYuanSuBase*100).ToString("F2")}%</color>）";
            break;
         
         case SkillInfoType.DianMain:
            image.sprite=ResourcesConfig.GetSkillSprite(SkillInfoType.DianMain);
            skillName.text = "雷电专精";
            text.text = $"每一个电系技能点可增加<color=green>1%</color>的雷电元素伤害，并且雷电伤害有释放落雷，雷电元素伤害越高，概率越大（当前概率<color=green>{(GlobalPlayerAttribute.LuoLeiRate).ToString("F2")}%</color>）";
            break;
         
         case SkillInfoType.HeiAnMain:
            image.sprite=ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAnMain);
            skillName.text = "黑暗专精";
            text.text = $"每一个黑暗系技能点可增加<color=green>1%</color>的黑暗元素伤害，并且黑暗伤害击杀敌人有概率收割灵魂，每个灵魂增加1%的魔力和生命值（当前概率<color=green>{(GlobalPlayerAttribute.LingHunRate).ToString("F2")}%</color>）";
            break;
      }
   }
}
