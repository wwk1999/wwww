using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShenJiCaiLiao : MonoBehaviour
{
   [NonSerialized] public WeaponType showType;
   public GameObject shenJiCaiLiaoContent;


   private void OnEnable()
   {
      ShowShenJiCaiLiao();
   }

   public void ShowShenJiCaiLiao()
   {
      foreach (Transform child in shenJiCaiLiaoContent.transform)
      {
         Destroy(child.gameObject);
      }

      var cailiaoList = WeaponConfig.ShenJiCaiLiaoDic[showType];
      foreach (var cailiao in cailiaoList)
      {
         var cailiaoItem = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ShenJiCaiLiaoItem"),
            shenJiCaiLiaoContent.transform);
         switch (cailiao.PropType)
         {
            case PropConfig.PropType.LingHun:
               cailiaoItem.transform.Find("prop/ImageBg").gameObject.SetActive(false);
               cailiaoItem.transform.Find("prop/Edge").gameObject.SetActive(false);
               cailiaoItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.LingHun;
               cailiaoItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = cailiao.Count.ToString();
               break;
            case PropConfig.PropType.JingCui:
               switch (cailiao.Quality)
               {
                  case 1:
                     cailiaoItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                     cailiaoItem.transform.Find("prop/Edge").GetComponent<Animator>().SetInteger("Type", 1);
                     cailiaoItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.WhiteJingCui;
                     cailiaoItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
                        cailiao.Count.ToString();
                     break;
                  case 2:
                     cailiaoItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.GreenBg;
                     cailiaoItem.transform.Find("prop/Edge").GetComponent<Animator>().SetInteger("Type", 2);
                     cailiaoItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.GreenJingCui;
                     cailiaoItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
                        cailiao.Count.ToString();
                     break;
                  case 3:
                     cailiaoItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                     cailiaoItem.transform.Find("prop/Edge").GetComponent<Animator>().SetInteger("Type", 3);
                     cailiaoItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.BlueJingCui;
                     cailiaoItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
                        cailiao.Count.ToString();
                     break;
                  case 4:
                     cailiaoItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.PurpleBg;
                     cailiaoItem.transform.Find("prop/Edge").GetComponent<Animator>().SetInteger("Type", 4);
                     cailiaoItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.PurpleJingCui;
                     cailiaoItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
                        cailiao.Count.ToString();
                     break;
                  case 5:
                     cailiaoItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                     cailiaoItem.transform.Find("prop/Edge").GetComponent<Animator>().SetInteger("Type", 5);
                     cailiaoItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.OrangeJingCui;
                     cailiaoItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
                        cailiao.Count.ToString();
                     break;
                  case 6:
                     cailiaoItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
                     cailiaoItem.transform.Find("prop/Edge").GetComponent<Animator>().SetInteger("Type", 6);
                     cailiaoItem.transform.Find("prop/Image").GetComponent<Image>().sprite = ResourcesConfig.RedJingCui;
                     cailiaoItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
                        cailiao.Count.ToString();
                     break;
               }

               break;

            case PropConfig.PropType.WeaponFragment:
               switch (cailiao.Quality)
               {
                  case 1:
                     cailiaoItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
                     cailiaoItem.transform.Find("prop/Edge").GetComponent<Animator>().SetInteger("Type", 1);
                     cailiaoItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.WhiteWeaponFragment;
                     cailiaoItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
                        cailiao.Count.ToString();
                     break;
                  case 2:
                     cailiaoItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.GreenBg;
                     cailiaoItem.transform.Find("prop/Edge").GetComponent<Animator>().SetInteger("Type", 2);
                     cailiaoItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.GreenWeaponFragment;
                     cailiaoItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
                        cailiao.Count.ToString();
                     break;
                  case 3:
                     cailiaoItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
                     cailiaoItem.transform.Find("prop/Edge").GetComponent<Animator>().SetInteger("Type", 3);
                     cailiaoItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.BlueWeaponFragment;
                     cailiaoItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
                        cailiao.Count.ToString();
                     break;
                  case 4:
                     cailiaoItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.PurpleBg;
                     cailiaoItem.transform.Find("prop/Edge").GetComponent<Animator>().SetInteger("Type", 4);
                     cailiaoItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.PurpleWeaponFragment;
                     cailiaoItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
                        cailiao.Count.ToString();
                     break;
                  case 5:
                     cailiaoItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
                     cailiaoItem.transform.Find("prop/Edge").GetComponent<Animator>().SetInteger("Type", 5);
                     cailiaoItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.OrangeWeaponFragment;
                     cailiaoItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
                        cailiao.Count.ToString();
                     break;
                  case 6:
                     cailiaoItem.transform.Find("prop/ImageBg").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
                     cailiaoItem.transform.Find("prop/Edge").GetComponent<Animator>().SetInteger("Type", 6);
                     cailiaoItem.transform.Find("prop/Image").GetComponent<Image>().sprite =
                        ResourcesConfig.RedWeaponFragment;
                     cailiaoItem.transform.Find("Count").GetComponent<TextMeshProUGUI>().text =
                        cailiao.Count.ToString();
                     break;
               }

               break;
         }
      }
   }
}
