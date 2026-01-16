using System;
using System.Collections;
using System.Collections.Generic;
using Mysql;
using Spine.Unity;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FightBGController : XSingleton<FightBGController>
{
    [NonSerialized]public Button normalAttackButton;//普通攻击按钮
    [NonSerialized]public Button FightStopButton;//战斗暂停按钮
    [NonSerialized]public Button dashButton;
    [NonSerialized]public Button rageButton;
    [NonSerialized]public Button shieldButton;
    [NonSerialized]public Button iceArrowButton;
    [NonSerialized]public Button iceExButton;
    [NonSerialized]public Button iceBallButton;
    [NonSerialized] public Image IceExYellowCd;
    [NonSerialized] public Image IceBallYellowCd;
    [NonSerialized] public Image IceArrowYellowCd;
    [NonSerialized]public Slider playerHpSlider;
    [NonSerialized]public Slider playerExSlider;
    [NonSerialized]public Text playerLevelText;

    [NonSerialized]public TextMeshProUGUI GameMaxHp;
    [NonSerialized]public TextMeshProUGUI GameCurrentHp;
    
    
    
    [NonSerialized]public Button WeaponButton;
    [NonSerialized]public GameObject CircleAttack;
    [NonSerialized] public GameObject DiLie;
    [NonSerialized]public Queue<TreeManFire> TreeManFireQueue = new Queue<TreeManFire>();
    [NonSerialized]public Queue<CircleAttack> CircleAttackQueue = new Queue<CircleAttack>();
    [NonSerialized]public Queue<SqrtAttack> SqrtAttackQueue = new Queue<SqrtAttack>();
    [NonSerialized]public Queue<SpiderWeb> SpiderWebQueue = new Queue<SpiderWeb>();
    [NonSerialized]public Queue<PlayerHit> PlayerHitQueue = new Queue<PlayerHit>();
    [NonSerialized] public Queue<GameObject> PrimaryNormalAttackExQueue = new Queue<GameObject>();//初始武器普通攻击爆炸队列





    [NonSerialized] public bool HaveCircleAttack = false;
    [NonSerialized] public Slider BossEnergySlider;
    [NonSerialized] public bool IsBossJiHuo = false;


    private float RefreshEx = 0.5f;
    private float currentExTime = 0;
    private float RefreshHp = 0.1f;
    private float currentHpTime = 0;

    private float ReplyHpTime = 3f;
    private float currentReplyHpTime = 0;
    
    public bool isShowAgain = false;
    

    private void Update()
    {
        currentHpTime+=Time.deltaTime;
        currentExTime += Time.deltaTime;
        currentReplyHpTime+=Time.deltaTime;
        if (currentReplyHpTime > ReplyHpTime)
        {
            currentReplyHpTime = 0;
            float replyHp = GameController.S.GameMaxHp * GlobalPlayerAttribute.ReplyHpPercent/100f;
            GlobalPlayerAttribute.ReplyHp(replyHp);
        }
        
        if (currentHpTime > RefreshHp)
        {
            currentHpTime = 0;
            SetHp();
        }
        
        if (currentExTime > RefreshEx)
        {
            currentExTime = 0;
            if(GlobalPlayerAttribute.Exp>GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level])
            {
                //升级
                SkillJiaDian.S.CurrentSkillCount++;
                ObserverModuleManager.S.SendEvent(ConstKeys.LevelUpAnim);
                GameController.S.gamePlayer.LevelUp.SetActive(true);
                GameController.S.gamePlayer.LevelUpParticle.Play();
                GlobalPlayerAttribute.Level++;
                ObserverModuleManager.S.SendEvent("ShenJi");
                playerLevelText.text =  GlobalPlayerAttribute.Level.ToString();
                GlobalPlayerAttribute.Exp=GlobalPlayerAttribute.Exp-GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level-1];
                // PlayerInfoController.S.UpdatePlayerInfo( GlobalPlayerAttribute.Level, GlobalPlayerAttribute.Exp, GlobalPlayerAttribute.GameLevel, GlobalPlayerAttribute.BloodEnergy);
            }
            playerExSlider.maxValue=GlobalPlayerAttribute.ExpDic[GlobalPlayerAttribute.Level];
            playerExSlider.value=GlobalPlayerAttribute.Exp ;
            StoreController.S.SaveStoreData();
        }
    }

    public void SetHp()
    {
        
        if (GameController.S.GameCurrentHp < 0)
        {
            GameController.S.GameCurrentHp = 0f;
        }

        if (GameController.S.GameCurrentHp > GameController.S.GameMaxHp)
        {
            GameController.S.GameCurrentHp=GameController.S.GameMaxHp;
        }

        GameMaxHp.text = Mathf.RoundToInt(GameController.S.GameMaxHp).ToString();
        GameCurrentHp.text = Mathf.RoundToInt(GameController.S.GameCurrentHp).ToString();
        playerHpSlider.maxValue = GameController.S.GameMaxHp;
        playerHpSlider.value = GameController.S.GameCurrentHp;
    }

    
    //胜利动画
    public void PlaySuccessAnim()
    {
        var success= Instantiate(Resources.Load<GameObject>("Prefabs/Success/Success"),transform);
        SkeletonGraphic skeletonGraphic= success.transform.Find("Canvas/Content").GetComponent<SkeletonGraphic>();
        var skAnim = skeletonGraphic.GetComponent<SkeletonAnimation>();
        if (skAnim != null) {
            skAnim.AnimationName = "bui_9_1";
        }
        StartCoroutine(DelayPlaySuccessAnim(skeletonGraphic));
        if (LevelInfoConfig.CurrentGameLevel + 1 > LevelInfoConfig.MaxGameLevel)
        {
            LevelInfoConfig.MaxGameLevel= LevelInfoConfig.CurrentGameLevel + 1;
            StoreController.S.SaveStoreData();
        }

        StartCoroutine(DelayDisable(success));
    }
    IEnumerator DelayPlaySuccessAnim(SkeletonGraphic skeletonGraphic)
    {
        yield return new WaitForSeconds(1.67f);
        var skAnim = skeletonGraphic.GetComponent<SkeletonAnimation>();
        if (skAnim != null) {
            skAnim.AnimationName = "bui_9_2";
        }
    }
    
    IEnumerator DelayDisable(GameObject obj)
    {
        yield return new WaitForSeconds(5f);
        Destroy(obj);
    }
    
}