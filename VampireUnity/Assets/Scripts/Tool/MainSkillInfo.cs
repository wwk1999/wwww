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
            text.text = $"每一个冰系技能点可增加<color=green>1%</color>的冰霜元素伤害，并且冰霜伤害有概率冻结敌人<color=green>1</color>s，冰霜元素伤害越高，概率越大（当前概率<color=green>{GlobalPlayerAttribute.IceYuanSuBase/5+GlobalPlayerAttribute.IceYuanSuBase}%</color>%）";
            break;
      }
   }
}
