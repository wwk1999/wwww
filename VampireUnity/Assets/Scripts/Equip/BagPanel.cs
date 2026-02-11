using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BagPanel : MonoBehaviour
{
    public Button detailedAttributesButton;// 详细属性按钮
    public GameObject detailedAttributesPanel;// 详细属性面板
    public Button detailedAttributesExitButton;
    
    public GameObject playerPanel;// 玩家属性面板
    public GameObject playerCloth;// 玩家属性面板
    public GameObject playerCloak;// 玩家属性面板
    public GameObject playerHelmet;// 玩家属性面板
    public GameObject playerRing;// 玩家属性面板
    public GameObject playerShoe;// 玩家属性面板
    public GameObject playerNecklace;// 玩家属性面板

    public GameObject attributePanel;// 玩家属性面板
    
    
    
    public Button leftPageButton;
    public Button rightPageButton;
    public Text pageText;
    
    public GameObject content;
    
    
    public Button equipButton; // 装备按钮
    public Button propbutton; // 道具按钮
    [NonSerialized] public int currentBagType = 1;//1是装备，2是道具

    
    public TextMeshProUGUI BagName;
    public TextMeshProUGUI EquipName;
    public TextMeshProUGUI PropName;
    public TextMeshProUGUI FenjieNane;
    public TextMeshProUGUI ShuXin;

    public GameObject ChongWuDanMask;
    public Button ChongWuDanMaskButton;

    public void SwitchLanguage()
    {
        BagName.text = LanguageConfig.LanguageItems[PlayerData.S.langType].BagWindowLanguage.Bag;
        EquipName.text = LanguageConfig.LanguageItems[PlayerData.S.langType].BagWindowLanguage.Equip;
        PropName.text = LanguageConfig.LanguageItems[PlayerData.S.langType].BagWindowLanguage.Prop;
        FenjieNane.text = LanguageConfig.LanguageItems[PlayerData.S.langType].BagWindowLanguage.FenJie;
        ShuXin.text = LanguageConfig.LanguageItems[PlayerData.S.langType].BagWindowLanguage.DetailAttribute;
    }

    private void OnEnable()
    {
        SwitchLanguage();
        currentBagType = 1;
    }

    public void ShowChongWuDanMask(object[] obj)
    {
        ChongWuDanMask.SetActive(true);
    }
    
    public void HideChongWuDanMask(object[] obj)
    {
        ChongWuDanMask.SetActive(false);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("ShowChongWuDanMask",ShowChongWuDanMask);
        ObserverModuleManager.S.UnRegisterEvent("HideChongWuDanMask",HideChongWuDanMask);    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        ObserverModuleManager.S.RegisterEvent("ShowChongWuDanMask",ShowChongWuDanMask);
        ObserverModuleManager.S.RegisterEvent("HideChongWuDanMask",HideChongWuDanMask);

        ChongWuDanMaskButton.onClick.AddListener(() =>
        {
            GameObject obj=transform.Find("ChongWuDanSwitch(Clone)").gameObject;
            if (obj != null)
            {
                Destroy(obj);
            }
            ChongWuDanMask.SetActive(false);
        });
        equipButton.onClick.AddListener(() =>
        { 
            if (BagController.S.PageNum == 1 && currentBagType == 1)
            {
                return;
            }
            BagController.S.PageNum = 1;
            currentBagType = 1;
            BagController.S.ShowEquip();
        });
        
        propbutton.onClick.AddListener(() =>
        {
            if (currentBagType == 2)
            {
                return;
            }
            BagController.S.PageNum = 1;
            currentBagType = 2;
            BagController.S.ShowProp();
        });
        
        detailedAttributesButton.onClick.AddListener(() =>
        {
            detailedAttributesPanel.SetActive(true);
        });
        detailedAttributesExitButton.onClick.AddListener(() =>
        {
            detailedAttributesPanel.SetActive(false);
        });
        
      //  pageText = transform.Find("Mask/BagBg/BagBG (1)/EquipPanel/PageNumText").GetComponent<Text>();
        leftPageButton.onClick.AddListener(() =>
        {
            if (BagController.S.PageNum==1)
            {
                return;
            }
            BagController.S.PageNum= Mathf.Max(1, BagController.S.PageNum - 1);
            if (currentBagType == 1)
            {
                BagController.S.ShowEquip();
            }
            else
            {
                BagController.S.ShowProp();
            }
            
            pageText.text = BagController.S.PageNum.ToString();
        });
        rightPageButton.onClick.AddListener(() =>
        {
            if (BagController.S.PageNum==5)
            {
                return;
            }
            BagController.S.PageNum= Mathf.Min(5, BagController.S.PageNum + 1);
            if (currentBagType == 1)
            {
                BagController.S.ShowEquip();
            }
            else
            {
                BagController.S.ShowProp();
            }
            pageText.text = BagController.S.PageNum.ToString();
        });
    }
    
}
