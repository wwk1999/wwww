using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfo : MonoBehaviour
{
    [NonSerialized] public SkillInfoType SkillType;
    public Image image;
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillType;
    public TextMeshProUGUI LevelUpText;
    public TextMeshProUGUI LevelUpCount;
    public TextMeshProUGUI LevelUpText1;
    public TextMeshProUGUI CurrentText;

    public TextMeshProUGUI YouJian;
    public TextMeshProUGUI ZuoJian;
    public TextMeshProUGUI LevelLimit;


    public void SetSkillInfo()
    {
        switch (SkillType)
        {
            case SkillInfoType.Ice1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice1);
                skillName.text = "冰龙啸天";
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Ice1]}%</color> 冰霜伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damageValue1 = SkillConfig.SkillBaseDamageDic[global::SkillType.Ice1] + MathF.Max(0,
                    (SkillJiaDian.S.Ice1 - 1) * SkillConfig.SkillUpDamageDic[global::SkillType.Ice1]);
                CurrentText.text = $"召唤一条冰龙砸向地面，造成<color=green>{damageValue1}%</color>的冰霜伤害";
                YouJian.gameObject.SetActive(true);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Ice2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice2);
                skillName.text = "冰晶星轮";
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Ice2]}%</color> 冰霜伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damageValue2 = SkillConfig.SkillBaseDamageDic[global::SkillType.Ice2] + MathF.Max(0,
                    (SkillJiaDian.S.Ice2 - 1) * SkillConfig.SkillUpDamageDic[global::SkillType.Ice2]);
                CurrentText.text = $"召唤4个星轮围绕自身，每次造成<color=green>{damageValue2}%</color>的冰霜伤害";
                YouJian.gameObject.SetActive(true);
                if (PlayerData.S.level < 5)
                {
                    LevelLimit.gameObject.SetActive(true);
                    LevelLimit.text = "等级要求：5";
                }
                else
                {
                    LevelLimit.gameObject.SetActive(false);
                }

                break;

            case SkillInfoType.Ice3:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice3);
                skillName.text = "极寒冲击";
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Ice3]}%</color> 冰霜伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage3 = (SkillConfig.SkillBaseDamageDic[global::SkillType.Ice3] + MathF.Max(0,
                    (SkillJiaDian.S.Ice3 - 1) * SkillConfig.SkillUpDamageDic[global::SkillType.Ice3]));
                CurrentText.text = $"以自身为中心释放极寒风暴，造成<color=green>{damage3}%</color>的冰霜伤害";
                YouJian.gameObject.SetActive(true);
                if (PlayerData.S.level < 10)
                {
                    LevelLimit.gameObject.SetActive(true);
                    LevelLimit.text = "等级要求：10";
                }
                else
                {
                    LevelLimit.gameObject.SetActive(false);
                }

                break;

            case SkillInfoType.Ice4:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice4);
                skillName.text = "极冻冰锥";
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Ice4]}%</color> 冰霜伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage4 = (SkillConfig.SkillBaseDamageDic[global::SkillType.Ice4] + MathF.Max(0,
                    (SkillJiaDian.S.Ice4 - 1) * SkillConfig.SkillUpDamageDic[global::SkillType.Ice4]));
                CurrentText.text = $"召唤4个冰锥砸向地面，每个造成<color=green>{damage4}%</color>";
                YouJian.gameObject.SetActive(true);
                if (PlayerData.S.level < 15)
                {
                    LevelLimit.gameObject.SetActive(true);
                    LevelLimit.text = "等级要求：15";
                }
                else
                {
                    LevelLimit.gameObject.SetActive(false);
                }

                break;

            case SkillInfoType.Ice5:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice5);
                skillName.text = "万里冰霜";
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Ice5]}%</color> 冰霜伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage5 = SkillConfig.SkillBaseDamageDic[global::SkillType.Ice5] + MathF.Max(0,
                    (SkillJiaDian.S.Ice5 - 1) * SkillConfig.SkillUpDamageDic[global::SkillType.Ice5]);
                CurrentText.text = $"召唤12个冰晶向四周扩散，每个造成<color=green>{damage5}%</color>的冰霜伤害";
                YouJian.gameObject.SetActive(true);
                if (PlayerData.S.level < 20)
                {
                    LevelLimit.gameObject.SetActive(true);
                    LevelLimit.text = "等级要求：20";
                }
                else
                {
                    LevelLimit.gameObject.SetActive(false);
                }

                break;

            case SkillInfoType.Ice1_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice1_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value1 = (20 + (SkillJiaDian.S.Ice1_1) * 5);
                CurrentText.text = $"减少<color=green>{value1}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Ice2_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice2_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value2 = (20 + (SkillJiaDian.S.Ice2_1) * 5);
                CurrentText.text = $"减少<color=green>{value2}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Ice3_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice3_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value3 = (20 + (SkillJiaDian.S.Ice3_1) * 5);
                CurrentText.text = $"减少<color=green>{value3}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Ice4_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice4_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value4 = (20 + (SkillJiaDian.S.Ice4_1) * 5);
                CurrentText.text = $"减少<color=green>{value4}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Ice5_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice5_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value5 = (20 + (SkillJiaDian.S.Ice5_1) * 5);
                CurrentText.text = $"减少<color=green>{value5}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Ice1_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice1_2);
                skillName.text = "效果范围";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 效果范围";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value6 = (SkillJiaDian.S.Ice1_2 * 5);
                CurrentText.text = $"当前增加<color=green>{value6}%</color>的效果范围";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Ice2_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice2_2);
                skillName.text = "魔法球数量";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级当前增加魔法弹数量：<color=green>1</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value7 = (SkillJiaDian.S.Ice2_2 * 1);
                CurrentText.text = $"当前增加<color=green>{value7}</color>个魔法弹";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Ice3_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice3_2);
                skillName.text = "效果范围";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 效果范围";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value8 = (SkillJiaDian.S.Ice3_2 * 5);
                CurrentText.text = $"当前增加<color=green>{value8}%</color>的效果范围";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Ice4_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice4_2);
                skillName.text = "冰锥数量";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级当前增加冰锥数量：<color=green>1</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value9 = (SkillJiaDian.S.Ice4_2 * 1);
                CurrentText.text = $"当前增加<color=green>{value9}</color>个冰锥";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Ice5_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice5_2);
                skillName.text = "冰晶数量";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级当前增加冰晶数量：<color=green>2</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value10 = (SkillJiaDian.S.Ice5_2 * 2);
                CurrentText.text = $"当前增加<color=green>{value10}</color>个冰晶";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.IceBei1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.IceBei1);
                skillName.text = "冰系专精1";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级当前增加冻结概率：<color=green>5%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value11 = (SkillJiaDian.S.IceBei1 * 5);
                CurrentText.text = $"当前增加<color=green>{value11}%</color>的冰冻概率";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.IceBei2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.IceBei2);
                skillName.text = "冰系专精2";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级当前增加冻结时间：<color=green>5%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value12 = (SkillJiaDian.S.IceBei2 * 5);
                CurrentText.text = $"当前增加<color=green>{value12}%</color>的冰冻时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.IceBei3:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.IceBei3);
                skillName.text = "冰系专精3";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级对冰冻敌人增加：<color=green>5%</color> 冰霜伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value13 = (SkillJiaDian.S.IceBei3 * 5);
                CurrentText.text = $"当前增加<color=green>{value13}%</color>的冰霜伤害";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.IceBei4:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.IceBei4);
                skillName.text = "冰系专精4";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 概率";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value14 = (SkillJiaDian.S.IceBei4 * 5);
                CurrentText.text = $"击杀冰冻中的敌人有<color=green>{value14}%</color>造成冰爆";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;
        }
    }
}
