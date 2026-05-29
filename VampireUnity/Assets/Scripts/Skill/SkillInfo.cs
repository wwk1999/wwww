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
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.Ice1];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Ice1]}%</color> 冰霜伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damageValue1 = SkillConfig.Ice1Damage;
                CurrentText.text = $"召唤一条冰龙砸向地面，造成<color=green>{damageValue1}%</color>的冰霜伤害";
                YouJian.gameObject.SetActive(true);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Ice2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Ice2);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.Ice2];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Ice2]}%</color> 冰霜伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damageValue2 = SkillConfig.Ice2Damage;
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
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.Ice3];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Ice3]}%</color> 冰霜伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage3 = SkillConfig.Ice3Damage;
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
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.Ice4];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Ice4]}%</color> 冰霜伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage4 = SkillConfig.Ice4Damage;
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
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.Ice5];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Ice5]}%</color> 冰霜伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage5 = SkillConfig.Ice5Damage;
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
                LevelUpText.text = $"每级增加魔法弹数量：<color=green>1</color>";
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
                LevelUpText.text = $"每级增加冰锥数量：<color=green>1</color>";
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
                LevelUpText.text = $"每级增加冰晶数量：<color=green>2</color>";
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
                LevelUpText.text = $"每级当前增加减速效果：<color=green>5%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value11 = (SkillJiaDian.S.IceBei1 * 5);
                CurrentText.text = $"当前增加<color=green>{value11}%</color>的减速效果";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.IceBei3:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.IceBei3);
                skillName.text = "冰系专精3";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级当前增加减速持续时间：<color=green>5%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value12 = (SkillJiaDian.S.IceBei3 * 5);
                CurrentText.text = $"当前增加<color=green>{value12}%</color>的减速时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.IceBei2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.IceBei2);
                skillName.text = "冰系专精2";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级对减速敌人增加：<color=green>5%</color> 冰霜伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value13 = (SkillJiaDian.S.IceBei2 * 5);
                CurrentText.text = $"当前增加<color=green>{value13}%</color>的冰霜伤害";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;
            
            case SkillInfoType.IceBei4:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.IceBei4);
                skillName.text = "冰系专精4";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级对减速敌人增加：<color=green>5%</color> 冰霜伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value131 = (SkillJiaDian.S.IceBei4 * 5);
                CurrentText.text = $"当前增加<color=green>{value131}%</color>的冰霜伤害";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

           
            
            
            
            
            
            
            
            
            
            
            
            case SkillInfoType.Huo1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo1);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.Huo1];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Huo1]}%</color> 火焰伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damageValue11 = SkillConfig.Huo1Damage;
                CurrentText.text = $"向前方发射3枚爆裂弹，造成<color=green>{damageValue11}%</color>的火焰伤害";
                YouJian.gameObject.SetActive(true);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Huo2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo2);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.Huo2];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Huo2]}%</color> 火焰元素伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damageValue21 = SkillConfig.Huo2Damage;
                CurrentText.text = $"进入烈焰掌控状态，提升<color=green>{damageValue21}%</color>的火焰元素伤害";
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

            case SkillInfoType.Huo3:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo3);
                skillName.text =SkillConfig.SkillNameDic[global::SkillType.Huo3];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Huo3]}%</color> 火焰伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage31 =SkillConfig.Huo3Damage;
                CurrentText.text = $"在目标位置释放4个火焰流星砸向地面，造成<color=green>{damage31}%</color>的火焰伤害";
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

            case SkillInfoType.Huo4:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo4);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.Huo4];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Huo4]}%</color> 火焰伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage41 =SkillConfig.Huo4Damage;
                CurrentText.text = $"在指定位置召唤烈焰喷柱，每次造成<color=green>{damage41}%</color>的火焰伤害";
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

            case SkillInfoType.Huo5:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo5);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.Huo5];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Huo5]}%</color> 火焰伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage51 =SkillConfig.Huo5Damage;
                CurrentText.text = $"召唤4个陨石砸向地面，每个造成<color=green>{damage51}%</color>的火焰伤害";
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

            case SkillInfoType.Huo1_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo1_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value111 = (20 + (SkillJiaDian.S.Huo1_1) * 5);
                CurrentText.text = $"减少<color=green>{value111}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Huo2_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo2_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value211 = (20 + (SkillJiaDian.S.Huo2_1) * 5);
                CurrentText.text = $"减少<color=green>{value211}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Huo3_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo3_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value311 = (20 + (SkillJiaDian.S.Huo3_1) * 5);
                CurrentText.text = $"减少<color=green>{value311}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Huo4_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo4_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value411 = (20 + (SkillJiaDian.S.Huo4_1) * 5);
                CurrentText.text = $"减少<color=green>{value411}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Huo5_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo5_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value511 = (20 + (SkillJiaDian.S.Huo5_1) * 5);
                CurrentText.text = $"减少<color=green>{value511}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Huo1_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo1_2);
                skillName.text = "爆裂弹数量";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加爆裂弹数量：<color=green>1</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value611 = (SkillJiaDian.S.Huo1_2 * 1);
                CurrentText.text = $"当前增加<color=green>{value611}</color>个爆裂弹";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Huo2_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo2_2);
                skillName.text = "效果增幅";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升火焰元素伤害：<color=green>2%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value711 = (SkillJiaDian.S.Huo2_2 * 2);
                CurrentText.text = $"当前提升<color=green>{value711}%</color>的火焰元素伤害";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Huo3_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo3_2);
                skillName.text = "流星数量";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升流星数量：<color=green>1</color> ";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value811 = (SkillJiaDian.S.Huo3_2 * 1);
                CurrentText.text = $"当前增加<color=green>{value811}</color>个流星";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Huo4_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo4_2);
                skillName.text = "效果范围";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加效果范围：<color=green>5%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value911 = (SkillJiaDian.S.Huo4_2 * 5);
                CurrentText.text = $"当前增加<color=green>{value911}%</color>的效果范围";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Huo5_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Huo5_2);
                skillName.text = "陨石数量";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加陨石数量：<color=green>1</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value1011 = (SkillJiaDian.S.Huo5_2 * 1);
                CurrentText.text = $"当前增加<color=green>{value1011}</color>个陨石";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HuoBei1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HuoBei1);
                skillName.text = "火系专精1";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加灼烧状态最大叠加层数：<color=green>1</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value1111 = (SkillJiaDian.S.HuoBei1 * 1);
                CurrentText.text = $"当前增加<color=green>{value1111}</color>的最大灼烧层数";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HuoBei2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HuoBei2);
                skillName.text = "火系专精2";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级灼烧伤害：<color=green>5%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value1211 = (SkillJiaDian.S.HuoBei2 * 5);
                CurrentText.text = $"当前增加<color=green>{value1211}%</color>的灼烧伤害";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HuoBei3:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HuoBei3);
                skillName.text = "火系专精3";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加：<color=green>0.5s</color> 的灼烧时间";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value1311 = (SkillJiaDian.S.HuoBei3 * 0.5f);
                CurrentText.text = $"当前增加<color=green>{value1311}%</color>的灼烧时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HuoBei4:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HuoBei4);
                skillName.text = "冰系专精4";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级缩短：<color=green>5%</color> 的灼烧伤害间隔";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value1411 = (SkillJiaDian.S.HuoBei4 * 5);
                CurrentText.text = $"当前缩短<color=green>{value1411}%</color>的灼烧伤害间隔";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;
            
            
            
            
            
            
            
            
            
            
             case SkillInfoType.Dian1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian1);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.Dian1];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Dian1]}%</color> 雷电伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damageValue1122 =SkillConfig.Dian1Damage;
                CurrentText.text = $"在指定位置释放电圈，造成<color=green>{damageValue1122}%</color>的雷电伤害";
                YouJian.gameObject.SetActive(true);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Dian2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian2);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.Dian2];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Dian2]}%</color> 雷电元素伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damageValue2122 =SkillConfig.Dian2Damage;
                CurrentText.text = $"进入雷电掌控状态，提升<color=green>{damageValue2122}%</color>的雷电元素伤害";
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

            case SkillInfoType.Dian3:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian3);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.Dian3];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Dian3]}%</color> 雷电伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage3122 =SkillConfig.Dian3Damage;
                CurrentText.text = $"向周围发射12枚闪电，每个造成<color=green>{damage3122}%</color>的雷电伤害";
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

            case SkillInfoType.Dian4:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian4);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.Dian4];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Dian4]}%</color> 雷电伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage4122 =SkillConfig.Dian4Damage;
                CurrentText.text = $"在指定位置召唤雷电领域，每次造成<color=green>{damage4122}%</color>的雷电伤害";
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

            case SkillInfoType.Dian5:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian5);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.Dian5];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.Dian5]}%</color> 雷电伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage5122 =SkillConfig.Dian5Damage;
                CurrentText.text = $"在指定位置召唤灭世雷劫，每次造成<color=green>{damage5122}%</color>的雷电伤害";
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

            case SkillInfoType.Dian1_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian1_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value1113 = (20 + (SkillJiaDian.S.Dian1_1) * 5);
                CurrentText.text = $"减少<color=green>{value1113}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Dian2_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian2_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value2113 = (20 + (SkillJiaDian.S.Dian2_1) * 5);
                CurrentText.text = $"减少<color=green>{value2113}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Dian3_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian3_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value3113 = (20 + (SkillJiaDian.S.Dian3_1) * 5);
                CurrentText.text = $"减少<color=green>{value3113}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Dian4_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian4_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value4113 = (20 + (SkillJiaDian.S.Dian4_1) * 5);
                CurrentText.text = $"减少<color=green>{value4113}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Dian5_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian5_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value5113 = (20 + (SkillJiaDian.S.Dian5_1) * 5);
                CurrentText.text = $"减少<color=green>{value5113}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Dian1_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian1_2);
                skillName.text = "效果范围";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加效果范围：<color=green>5%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value6113 = (SkillJiaDian.S.Dian1_2 * 5);
                CurrentText.text = $"当前增加<color=green>{value6113}%</color>的效果范围";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Dian2_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian2_2);
                skillName.text = "效果增幅";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升雷电元素伤害：<color=green>2%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value7113 = (SkillJiaDian.S.Dian2_2 * 2);
                CurrentText.text = $"当前提升<color=green>{value7113}%</color>的雷电元素伤害";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Dian3_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian3_2);
                skillName.text = "闪电数量";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升闪电数量：<color=green>1</color> ";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value8113 = (SkillJiaDian.S.Dian3_2 * 1);
                CurrentText.text = $"当前增加<color=green>{value8113}%</color>个闪电";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Dian4_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian4_2);
                skillName.text = "效果范围";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加效果范围：<color=green>5%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value9113 = (SkillJiaDian.S.Dian4_2 * 5);
                CurrentText.text = $"当前增加<color=green>{value9113}%</color>的效果范围";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.Dian5_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.Dian5_2);
                skillName.text = "效果范围";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加效果范围：<color=green>1</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value10113 = (SkillJiaDian.S.Dian5_2 * 5);
                CurrentText.text = $"当前增加<color=green>{value10113}</color>的效果范围";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.DianBei1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.DianBei1);
                skillName.text = "电系专精1";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加落雷触发概率：<color=green>5%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value11113 = (SkillJiaDian.S.DianBei1 * 5);
                CurrentText.text = $"当前增加<color=green>{value11113}%</color>的落雷触发概率";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.DianBei2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.DianBei2);
                skillName.text = "电系专精2";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级落雷伤害：<color=green>5%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value12113 = (SkillJiaDian.S.DianBei2 * 5);
                CurrentText.text = $"当前增加<color=green>{value12113}%</color>的落雷伤害";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.DianBei3:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.DianBei3);
                skillName.text = "电系专精3";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加：<color=green>5%</color> 的落雷的效果范围";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value13113 = (SkillJiaDian.S.DianBei3 * 5f);
                CurrentText.text = $"当前增加<color=green>{value13113}%</color>的效果范围";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.DianBei4:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.DianBei4);
                skillName.text = "电系专精4";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加：<color=green>5%</color> 的落雷伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value14113 = (SkillJiaDian.S.DianBei4 * 5);
                CurrentText.text = $"当前缩短<color=green>{value14113}%</color>的落雷上海";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;
            
            
            
            
            
            
            
            
            
            
            
             case SkillInfoType.HeiAn1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn1);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.HeiAn1];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.HeiAn1]}%</color> 黑暗伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damageValue114 =SkillConfig.HeiAn1Damage;
                CurrentText.text = $"在指定位置召唤地狱黑暗灵魂吞噬一切，造成<color=green>{damageValue114}%</color>的黑暗伤害";
                YouJian.gameObject.SetActive(true);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HeiAn2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn2);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.HeiAn2];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.HeiAn2]}%</color> 黑暗元素伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damageValue214 =SkillConfig.HeiAn2Damage;
                CurrentText.text = $"进入黑暗掌控状态，提升<color=green>{damageValue214}%</color>的黑暗元素伤害";
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

            case SkillInfoType.HeiAn3:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn3);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.HeiAn3];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.HeiAn3]}%</color> 黑暗伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage314 =SkillConfig.HeiAn3Damage;
                CurrentText.text = $"在目标位置形成黑暗侵蚀领域，每次造成<color=green>{damage314}%</color>的黑暗伤害";
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

            case SkillInfoType.HeiAn4:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn4);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.HeiAn4];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.HeiAn4]}%</color> 黑暗伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage414 =SkillConfig.HeiAn4Damage;
                CurrentText.text = $"召唤4个恶意灵魂围绕自身，每次造成<color=green>{damage414}%</color>的黑暗伤害";
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

            case SkillInfoType.HeiAn5:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn5);
                skillName.text = SkillConfig.SkillNameDic[global::SkillType.HeiAn5];
                skillType.text = "主动技能";
                LevelUpText.text =
                    $"每级提升：<color=green>{SkillConfig.SkillUpDamageDic[global::SkillType.HeiAn5]}%</color> 黑暗伤害";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float damage514 =SkillConfig.HeiAn5Damage;
                CurrentText.text = $"在随机位置召唤4个黑暗漩涡，每次造成<color=green>{damage514}%</color>的黑暗伤害";
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

            case SkillInfoType.HeiAn1_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn1_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value1114 = (20 + (SkillJiaDian.S.HeiAn1_1) * 5);
                CurrentText.text = $"减少<color=green>{value1114}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HeiAn2_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn2_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value2141 = (20 + (SkillJiaDian.S.HeiAn2_1) * 5);
                CurrentText.text = $"减少<color=green>{value2141}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HeiAn3_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn3_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value3114 = (20 + (SkillJiaDian.S.HeiAn3_1) * 5);
                CurrentText.text = $"减少<color=green>{value3114}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HeiAn4_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn4_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value4114 = (20 + (SkillJiaDian.S.HeiAn4_1) * 5);
                CurrentText.text = $"减少<color=green>{value4114}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HeiAn5_1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn5_1);
                skillName.text = "冷却缩减";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升：<color=green>5%</color> 冷却缩减";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value5114 = (20 + (SkillJiaDian.S.HeiAn5_1) * 5);
                CurrentText.text = $"减少<color=green>{value5114}%</color>的冷却时间";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HeiAn1_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn1_2);
                skillName.text = "效果范围";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加效果范围：<color=green>5%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value6114 = (SkillJiaDian.S.HeiAn1_2 * 5);
                CurrentText.text = $"当前增加<color=green>{value6114}%</color>的效果范围";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HeiAn2_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn2_2);
                skillName.text = "效果增幅";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级提升黑暗元素伤害：<color=green>2%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value7114 = (SkillJiaDian.S.HeiAn2_2 * 2);
                CurrentText.text = $"当前增加<color=green>{value7114}%</color>的黑暗元素伤害";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HeiAn3_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn3_2);
                skillName.text = "效果范围";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级效果范围：<color=green>5%</color> ";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value8114 = (SkillJiaDian.S.HeiAn3_2 * 5);
                CurrentText.text = $"当前增加<color=green>{value8114}%</color>的效果范围";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HeiAn4_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn4_2);
                skillName.text = "灵魂数量";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加灵魂数量：<color=green>1</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value9114 = (SkillJiaDian.S.HeiAn4_2 * 1);
                CurrentText.text = $"当前增加<color=green>{value9114}</color>个灵魂";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HeiAn5_2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAn5_2);
                skillName.text = "漩涡数量";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加漩涡数量：<color=green>1</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value10114 = (SkillJiaDian.S.HeiAn5_2 * 1);
                CurrentText.text = $"当前增加<color=green>{value10114}</color>个漩涡";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HeiAnBei1:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAnBei1);
                skillName.text = "黑暗系专精1";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加灵魂最大层数：<color=green>5</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value11114 = (SkillJiaDian.S.HeiAnBei1 * 5);
                CurrentText.text = $"当前增加<color=green>{value11114}</color>的最大灵魂层数";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HeiAnBei2:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAnBei2);
                skillName.text = "黑暗系专精2";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加收割灵魂概率：<color=green>5%</color>";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value12114 = (SkillJiaDian.S.HeiAnBei2 * 5);
                CurrentText.text = $"当前增加<color=green>{value12114}%</color>的收割灵魂概率";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HeiAnBei3:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAnBei3);
                skillName.text = "黑暗系专精3";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加：<color=green>5%</color> 的灵魂效果";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value13114 = (SkillJiaDian.S.HeiAnBei3 * 5);
                CurrentText.text = $"当前增加<color=green>{value13114}%</color>的灵魂效果";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;

            case SkillInfoType.HeiAnBei4:
                image.sprite = ResourcesConfig.GetSkillSprite(SkillInfoType.HeiAnBei4);
                skillName.text = "黑暗系专精4";
                skillType.text = "被动技能";
                LevelUpText.text = $"每级增加：<color=green>5%</color> 的灵魂效果";
                LevelUpCount.text = "";
                LevelUpText1.text = "";
                float value14114 = (SkillJiaDian.S.HeiAnBei4 * 5);
                CurrentText.text = $"当前缩短<color=green>{value14114}%</color>的灵魂效果";
                YouJian.gameObject.SetActive(false);
                LevelLimit.gameObject.SetActive(false);
                break;
        }
    }
}
