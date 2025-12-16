using System;
using System.Collections;
using System.Collections.Generic;
using Coffee.UIExtensions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FightBg : MonoBehaviour
{
    public Button weaponButton;
    public Joystick joystick;
    public Button normalAttackButton;
    public Button fightStopButton;
    public Button dashButton;
    public Button rageButton;
    public Button shieldButton;
    public Button iceArrowButton;
    public Button iceExButton;
    public Button iceBallButton;
    public Image iceExYellowCd;
    public Image iceBallYellowCd;
    public Image iceArrowYellowCd;
    public Slider bossEnergySlider;
    public Text fightTimeText;
    public Slider playerHpSlider;
    public Slider playerExSlider;
    public Text playerLevelText;

    public TextMeshProUGUI GameMaxHp;
    public TextMeshProUGUI GameCurrentHp;
    
    
    
    public UIParticle iceArrowUIFX;
    public UIParticle iceBallUIFX;
    public UIParticle iceExUIFX;

    public Button jiHuoButton;
    public GameObject toastContent;


    private void Update()
    {
        if (FightBGController.S.IsBossJiHuo&&!GameController.S.HaveBoss)
        {
            jiHuoButton.gameObject.SetActive(true);
        }
        else
        {
            jiHuoButton.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        //技能按钮点击特效
        ObserverModuleManager.S.RegisterEvent(ConstKeys.ShowToast, ShowTaost);
        SkillController.S.IceArrowUIFX = iceArrowUIFX;
        SkillController.S.IceBallUIFX = iceBallUIFX;
        SkillController.S.IceExUIFX = iceExUIFX;
        jiHuoButton.onClick.AddListener(() =>
        {
            GameObject boosQuan=Instantiate(Resources.Load<GameObject>("Prefabs/Tool/BossQuan"));
            boosQuan.transform.position = new Vector3(0, 0, 0);
            GameController.S.CreateBoss();
        });
    }
    
    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent(ConstKeys.ShowToast, ShowTaost);
    }

    public void ShowTaost(object[] obj)
    {
        var toast = Instantiate(Resources.Load("Prefabs/Tool/ToastInfo"), toastContent.transform);
        EquipTable equipTable = obj[0] as EquipTable;
        PropTable propTable = obj[0] as PropTable;
        if (equipTable != null)
        {
            toast.GetComponent<ToastInfo>().SetEquipToast(equipTable);
        }
        if (propTable != null)
        {
            toast.GetComponent<ToastInfo>().SetPropToast(propTable);

        }
    }
}
