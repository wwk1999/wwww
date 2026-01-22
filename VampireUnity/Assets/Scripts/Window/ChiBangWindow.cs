using System;
using Config;
using Equip;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChiBangWindow : MonoBehaviour
{
   public GameObject jieSuo;
   public Animator chiBangAnimator;
   public Slider exSlider;
   public TextMeshProUGUI maxEx;
   public TextMeshProUGUI currentEx;
   public GameObject yuMaoContent;

   public GameObject whiteName;
   public GameObject greenName;
   public GameObject blueName;
   public GameObject purpleName;
   public GameObject orangeName;
   public GameObject redName;

   public GameObject whiteQuality;
   public GameObject greenQuality;
   public GameObject blueQuality;
   public GameObject purpleQuality;
   public GameObject orangeQuality;
   public GameObject redQuality;
   
   public GameObject whiteDesc;
   public GameObject greenDesc;
   public GameObject blueDesc;
   public GameObject purpleDesc;
   public GameObject orangeDesc;
   public GameObject redDesc;
   
   public GameObject attributeContent;

   public GameObject rightPanel;
   public Button exitButton;

   public void RefreshYuMao()
   {
      foreach (Transform child in yuMaoContent.transform)
      {
         Destroy(child.gameObject);
      }

      if (BagController.S.PropList.ContainsKey(401) && BagController.S.PropList[401].Count > 0)
      {           
         var chibangGrid = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ChiBangGrid"),yuMaoContent.transform);
         chibangGrid.GetComponent<ChiBangGrid>().chibangType = 401;
         chibangGrid.transform.Find("ImageBg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
         chibangGrid.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.WhiteChiBang;
         chibangGrid.transform.Find("Edge").GetComponent<Animator>().Play("WhiteEdge");
      }
      if (BagController.S.PropList.ContainsKey(402) && BagController.S.PropList[402].Count > 0)
      {           
         var chibangGrid = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ChiBangGrid"),yuMaoContent.transform);
         chibangGrid.GetComponent<ChiBangGrid>().chibangType = 402;
         chibangGrid.transform.Find("ImageBg").GetComponent<Image>().sprite = ResourcesConfig.GreenBg;
         chibangGrid.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.GreenChiBang;
         chibangGrid.transform.Find("Edge").GetComponent<Animator>().Play("GreenEdge");
      }
      if (BagController.S.PropList.ContainsKey(403) && BagController.S.PropList[403].Count > 0)
      {           
         var chibangGrid = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ChiBangGrid"),yuMaoContent.transform);
         chibangGrid.GetComponent<ChiBangGrid>().chibangType = 403;
         chibangGrid.transform.Find("ImageBg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
         chibangGrid.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.BlueChiBang;
         chibangGrid.transform.Find("Edge").GetComponent<Animator>().Play("BlueEdge");
      }
      if (BagController.S.PropList.ContainsKey(404) && BagController.S.PropList[404].Count > 0)
      {           
         var chibangGrid = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ChiBangGrid"),yuMaoContent.transform);
         chibangGrid.GetComponent<ChiBangGrid>().chibangType = 404;
         chibangGrid.transform.Find("ImageBg").GetComponent<Image>().sprite = ResourcesConfig.PurpleBg;
         chibangGrid.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.PurpleChiBang;
         chibangGrid.transform.Find("Edge").GetComponent<Animator>().Play("PurpleEdge");
      }

      if (BagController.S.PropList.ContainsKey(405) && BagController.S.PropList[405].Count > 0)
      {
         var chibangGrid = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ChiBangGrid"), yuMaoContent.transform);
         chibangGrid.GetComponent<ChiBangGrid>().chibangType = 405;
         chibangGrid.transform.Find("ImageBg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
         chibangGrid.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.OrangeChiBang;
         chibangGrid.transform.Find("Edge").GetComponent<Animator>().Play("OrangeEdge");
      }

      if (BagController.S.PropList.ContainsKey(406) && BagController.S.PropList[406].Count > 0)
         {           
            var chibangGrid = Instantiate(Resources.Load<GameObject>("Prefabs/Equip/ChiBangGrid"),yuMaoContent.transform);
            chibangGrid.GetComponent<ChiBangGrid>().chibangType = 406;
            chibangGrid.transform.Find("ImageBg").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
            chibangGrid.transform.Find("Image").GetComponent<Image>().sprite = ResourcesConfig.RedChiBang;
            chibangGrid.transform.Find("Edge").GetComponent<Animator>().Play("RedEdge");
         }
   }
   
   public void RefreshEx()
   {
      currentEx.text = PlayerData.S.ChiBangEx.ToString();
      maxEx.text = ChiBangConfig.ChiBangExDic[PlayerData.S.ChiBangLevel].ToString();
      exSlider.maxValue = ChiBangConfig.ChiBangExDic[PlayerData.S.ChiBangLevel];
      exSlider.value = PlayerData.S.ChiBangEx;
   }

   public void ResetChiBangInfo()
   {
      whiteName.gameObject.SetActive(false);
      greenName.gameObject.SetActive(false);
      blueName.gameObject.SetActive(false);
      purpleName.gameObject.SetActive(false);
      orangeName.gameObject.SetActive(false);
      redName.gameObject.SetActive(false);
      whiteQuality.gameObject.SetActive(false);
      greenQuality.gameObject.SetActive(false);
      blueQuality.gameObject.SetActive(false);
      purpleQuality.gameObject.SetActive(false);
      orangeQuality.gameObject.SetActive(false);
      redQuality.gameObject.SetActive(false);
      whiteDesc.SetActive(false);
      greenDesc.SetActive(false);
      blueDesc.SetActive(false);
      purpleDesc.SetActive(false);
      orangeDesc.SetActive(false);
      redDesc.SetActive(false);
   }
   public void ShowChiBangInfo(int quality)
   {
      ResetChiBangInfo();
      switch (quality)
      {
         case 1:
            whiteQuality.gameObject.SetActive(true);
            whiteName.gameObject.SetActive(true);
            whiteDesc.gameObject.SetActive(true);
            break;
         case 2:
            greenQuality.gameObject.SetActive(true);
            greenName.gameObject.SetActive(true);
            greenDesc.gameObject.SetActive(true);
            break;
         case 3:
            blueQuality.gameObject.SetActive(true);
            blueName.gameObject.SetActive(true);
            blueDesc.gameObject.SetActive(true);
            break;
         case 4:
            purpleQuality.gameObject.SetActive(true);
            purpleName.gameObject.SetActive(true);
            purpleDesc.gameObject.SetActive(true);
            break;
         case 5:
            orangeQuality.gameObject.SetActive(true);
            orangeName.gameObject.SetActive(true);
            orangeDesc.gameObject.SetActive(true);
            break;
         case 6:
            redQuality.gameObject.SetActive(true);
            redName.gameObject.SetActive(true);
            redDesc.gameObject.SetActive(true);
            break;
      }

      foreach (Transform child in attributeContent.transform)
      {
         Destroy(child.gameObject);
      }
      
      var chibangAttribute=ChiBangConfig.ChiBangAttributeDic[PlayerData.S.ChiBangLevel];
      if (chibangAttribute.maxHp != 0)
      {
         var chibangitem=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChiBangItem"), attributeContent.transform);
         chibangitem.transform.Find("AttributeName").GetComponent<TextMeshProUGUI>().text="生命值：";
         chibangitem.transform.Find("AttributeCount").GetComponent<TextMeshProUGUI>().text=chibangAttribute.maxHp.ToString();
      }  
      if (chibangAttribute.defense != 0)
      {
         var chibangitem=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChiBangItem"), attributeContent.transform);
         chibangitem.transform.Find("AttributeName").GetComponent<TextMeshProUGUI>().text="防御：";
         chibangitem.transform.Find("AttributeCount").GetComponent<TextMeshProUGUI>().text=chibangAttribute.defense.ToString();
      }
      if (chibangAttribute.attack != 0)
      {
         var chibangitem=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChiBangItem"), attributeContent.transform);
         chibangitem.transform.Find("AttributeName").GetComponent<TextMeshProUGUI>().text="攻击力：";
         chibangitem.transform.Find("AttributeCount").GetComponent<TextMeshProUGUI>().text=chibangAttribute.attack.ToString();
      }
    
      if (chibangAttribute.critDamage != 0)
      {
         var chibangitem=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChiBangItem"), attributeContent.transform);
         chibangitem.transform.Find("AttributeName").GetComponent<TextMeshProUGUI>().text="暴击伤害：";
         chibangitem.transform.Find("AttributeCount").GetComponent<TextMeshProUGUI>().text=chibangAttribute.critDamage.ToString();
      }
      if (chibangAttribute.attackSpeed != 0)
      {
         var chibangitem=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChiBangItem"), attributeContent.transform);
         chibangitem.transform.Find("AttributeName").GetComponent<TextMeshProUGUI>().text="攻击速度：";
         chibangitem.transform.Find("AttributeCount").GetComponent<TextMeshProUGUI>().text=chibangAttribute.attackSpeed.ToString();
      }
      if (chibangAttribute.moveSpeed != 0)
      {
         var chibangitem=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChiBangItem"), attributeContent.transform);
         chibangitem.transform.Find("AttributeName").GetComponent<TextMeshProUGUI>().text="移动速度：";
         chibangitem.transform.Find("AttributeCount").GetComponent<TextMeshProUGUI>().text=chibangAttribute.moveSpeed.ToString();
      }
      if (chibangAttribute.forture != 0)
      {
         var chibangitem=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChiBangItem"), attributeContent.transform);
         chibangitem.transform.Find("AttributeName").GetComponent<TextMeshProUGUI>().text="掉宝值：";
         chibangitem.transform.Find("AttributeCount").GetComponent<TextMeshProUGUI>().text=chibangAttribute.forture.ToString();
      }
      if (chibangAttribute.finalDamage != 0)
      {
         var chibangitem=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChiBangItem"), attributeContent.transform);
         chibangitem.transform.Find("AttributeName").GetComponent<TextMeshProUGUI>().text="最终伤害：";
         chibangitem.transform.Find("AttributeCount").GetComponent<TextMeshProUGUI>().text=chibangAttribute.finalDamage.ToString();
      }
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("ChiBang",RefreshChiBang);
      exitButton.onClick.AddListener(() =>
      {
         Destroy(gameObject);
      });
      RefreshChiBang();
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("ChiBang",RefreshChiBang);
   }

   public void RefreshChiBang(object[] obj)
   {
      RefreshChiBang();
   }
   

   public void RefreshChiBang()
   {
      RefreshYuMao();
      RefreshEx();
      switch (PlayerData.S.ChiBangLevel)
      {
         case 0:
            rightPanel.gameObject.SetActive(false);
            jieSuo.gameObject.SetActive(true);
            chiBangAnimator.gameObject.SetActive(false);
            break;
         case 1:
            rightPanel.gameObject.SetActive(true);
            jieSuo.gameObject.SetActive(false);
            chiBangAnimator.gameObject.SetActive(true);
            chiBangAnimator.Play("ChiBangWhite");
            ShowChiBangInfo(1);
            break;
         case 2:
            rightPanel.gameObject.SetActive(true);
            jieSuo.gameObject.SetActive(false);
            chiBangAnimator.gameObject.SetActive(true);
            chiBangAnimator.Play("ChiBangGreen");
            ShowChiBangInfo(2);
            break;
         case 3:
            rightPanel.gameObject.SetActive(true);
            jieSuo.gameObject.SetActive(false);
            chiBangAnimator.gameObject.SetActive(true);
            chiBangAnimator.Play("ChiBangBlue");
            ShowChiBangInfo(3);
            break;
         case 4:
            rightPanel.gameObject.SetActive(true);
            jieSuo.gameObject.SetActive(false);
            chiBangAnimator.gameObject.SetActive(true);
            chiBangAnimator.Play("ChiBangPurple");
            ShowChiBangInfo(4);
            break;
         case 5:
            rightPanel.gameObject.SetActive(true);
            jieSuo.gameObject.SetActive(false);
            chiBangAnimator.gameObject.SetActive(true);
            chiBangAnimator.Play("ChiBangOrange");
            ShowChiBangInfo(5);
            break;
         case 6:
            rightPanel.gameObject.SetActive(true);
            jieSuo.gameObject.SetActive(false);
            chiBangAnimator.gameObject.SetActive(true);
            chiBangAnimator.Play("ChiBangRed");
            ShowChiBangInfo(6);
            break;
      }
   }
}
