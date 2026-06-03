using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreWindow : MonoBehaviour
{
   public Animator animator;
   public Button exitButton;
   public GameObject ShanChuMask;
   public Button YesButton;
   public Button NoButton;
   private int shanchuIndex = 0;
   
   
   public Material shuji1bgMaterial;
   public Material shuqian1gMaterial;
   public GameObject Kong1;
   public GameObject shuqianX1;
   public GameObject shuqian1;
   public GameObject gameTime1obj;
   public GameObject level1obj;
   public GameObject linhun1obj;
   public GameObject chongwu1obj;
   public TextMeshProUGUI gameTime1;
   public TextMeshProUGUI level1;
   public TextMeshProUGUI linhun1;
   public TextMeshProUGUI chongwu1;
   public Button BgButton1;
   public Button ShanChuButton1;


   
   public Material shuji2bgMaterial;
   public Material shuqian2gMaterial;
   public GameObject Kong2;
   public GameObject shuqianX2;
   public GameObject shuqian2;
   public GameObject gameTime2obj;
   public GameObject level2obj;
   public GameObject linhun2obj;
   public GameObject chongwu2obj;
   public TextMeshProUGUI gameTime2;
   public TextMeshProUGUI level2;
   public TextMeshProUGUI linhun2;
   public TextMeshProUGUI chongwu2;
   public Button BgButton2;
   public Button ShanChuButton2;
   
   
   public Material shuji3bgMaterial;
   public Material shuqian3gMaterial;
   public GameObject Kong3;
   public GameObject shuqianX3;
   public GameObject shuqian3;
   public GameObject gameTime3obj;
   public GameObject level3obj;
   public GameObject linhun3obj;
   public GameObject chongwu3obj;
   public TextMeshProUGUI gameTime3;
   public TextMeshProUGUI level3;
   public TextMeshProUGUI linhun3;
   public TextMeshProUGUI chongwu3;
   public Button BgButton3;
   public Button ShanChuButton3;


   private void Update()
   {
      if (IsMouseOverUIObject(shuqianX1) && !StoreController.S.GetStoreIsEmpty(1))
      {
         shuqian1gMaterial.SetFloat("_OutlineThickness",0.012f);
      }
      else
      {
         shuqian1gMaterial.SetFloat("_OutlineThickness",0f);
      }
      
      if (IsMouseOverUIObject(shuqianX2) && !StoreController.S.GetStoreIsEmpty(2))
      {
         shuqian2gMaterial.SetFloat("_OutlineThickness",0.012f);
      }
      else
      {
         shuqian2gMaterial.SetFloat("_OutlineThickness",0f);
      }
      
      if (IsMouseOverUIObject(shuqianX3) && !StoreController.S.GetStoreIsEmpty(3))
      {
         shuqian3gMaterial.SetFloat("_OutlineThickness",0.012f);
      }
      else
      {
         shuqian3gMaterial.SetFloat("_OutlineThickness",0f);
      }
   }

   public void Show()
   {
       shuji1bgMaterial.SetFloat("_OutlineThickness", 0);
      shuqian1gMaterial.SetFloat("_OutlineThickness", 0);
      shuji2bgMaterial.SetFloat("_OutlineThickness", 0);
      shuqian2gMaterial.SetFloat("_OutlineThickness", 0);
      shuji3bgMaterial.SetFloat("_OutlineThickness", 0);
      shuqian3gMaterial.SetFloat("_OutlineThickness", 0);
      bool empty1 = StoreController.S.GetStoreIsEmpty(1);
      bool empty2 = StoreController.S.GetStoreIsEmpty(2);
      bool empty3 = StoreController.S.GetStoreIsEmpty(3);
      

      if (empty1)
      {
         Kong1.SetActive(true);
         shuqian1.SetActive(true);
         gameTime1obj.gameObject.SetActive(false);
         level1obj.gameObject.SetActive(false);
         linhun1obj.gameObject.SetActive(false);
         chongwu1obj.gameObject.SetActive(false);
      }
      else
      {
         StoreDefine.StoreData storeData1=StoreController.S.GetStoreData(1);
         Kong1.SetActive(false);
         shuqian1.SetActive(false);
         gameTime1obj.gameObject.SetActive(true);
         gameTime1.text = storeData1.Player.GameTime / 60 + "时" + storeData1.Player.GameTime % 60 + "分";
         level1obj.gameObject.SetActive(true);
         level1.text = storeData1.Player.level.ToString();
         linhun1obj.gameObject.SetActive(true);
         linhun1.text = storeData1.Player.bloodEnergy.ToString();
         chongwu1obj.gameObject.SetActive(true);
         chongwu1.text = storeData1.Player.ChongWuJingHua.ToString();
      }
      
      if (empty2)
      {
         Kong2.SetActive(true);
         shuqian2.SetActive(true);
         gameTime2obj.gameObject.SetActive(false);
         level2obj.gameObject.SetActive(false);
         linhun2obj.gameObject.SetActive(false);
         chongwu2obj.gameObject.SetActive(false);
      }
      else
      {
         StoreDefine.StoreData storeData2=StoreController.S.GetStoreData(2);
         Kong2.SetActive(false);
         shuqian2.SetActive(false);
         gameTime2obj.gameObject.SetActive(true);
         gameTime2.text = storeData2.Player.GameTime / 60 + "时" + storeData2.Player.GameTime % 60 + "分";
         level2obj.gameObject.SetActive(true);
         level2.text = storeData2.Player.level.ToString();
         linhun2obj.gameObject.SetActive(true);
         linhun2.text = storeData2.Player.bloodEnergy.ToString();
         chongwu2obj.gameObject.SetActive(true);
         chongwu2.text = storeData2.Player.ChongWuJingHua.ToString();
      }
      
      if (empty3)
      {
         Kong3.SetActive(true);
         shuqian3.SetActive(true);
         gameTime3obj.gameObject.SetActive(false);
         level3obj.gameObject.SetActive(false);
         linhun3obj.gameObject.SetActive(false);
         chongwu3obj.gameObject.SetActive(false);
      }
      else
      {
         StoreDefine.StoreData storeData3=StoreController.S.GetStoreData(3);
         Kong3.SetActive(false);
         shuqian3.SetActive(false);
         gameTime3obj.gameObject.SetActive(true);
         gameTime3.text = storeData3.Player.GameTime / 60 + "时" + storeData3.Player.GameTime % 60 + "分";
         level3obj.gameObject.SetActive(true);
         level3.text = storeData3.Player.level.ToString();
         linhun3obj.gameObject.SetActive(true);
         linhun3.text = storeData3.Player.bloodEnergy.ToString();
         chongwu3obj.gameObject.SetActive(true);
         chongwu3.text = storeData3.Player.ChongWuJingHua.ToString();
      }
   }

   private void OnEnable()
   {
      StoreController.S.CurrentSaveSlot = 0;
      ShanChuMask.SetActive(false);
      animator.Play("StoreAnim");
     Show();
   }
   
   private bool IsMouseOverUIObject(GameObject targetObject)
   {
      if (targetObject == null) return false;
        
      // 获取EventSystem（如果没有则返回false）
      if (EventSystem.current == null) return false;
        
      // 创建PointerEventData
      PointerEventData pointerData = new PointerEventData(EventSystem.current);
      pointerData.position = Input.mousePosition;
        
      // 执行射线检测
      var raycastResults = new System.Collections.Generic.List<RaycastResult>();
      EventSystem.current.RaycastAll(pointerData, raycastResults);
        
      // 遍历所有检测到的UI元素
      foreach (var result in raycastResults)
      {
         // 如果检测到的物体就是目标物体
         if (result.gameObject == targetObject)
         {
            return true;
         }
            
         // 可选：如果要检测子物体也算（比如点击Image，但targetObject是父级Canvas）
         // if (result.gameObject.transform.IsChildOf(targetObject.transform))
         // {
         //     return true;
         // }
      }
        
      return false;
   }
   
   

   private void Start()
   {
      
      exitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      BgButton1.onClick.AddListener(() =>
         {
            if (StoreController.S.CurrentSaveSlot != 1)
            {
                 shuji1bgMaterial.SetFloat("_OutlineThickness", 0.082f);
                 shuji2bgMaterial.SetFloat("_OutlineThickness", 0f);
                 shuji3bgMaterial.SetFloat("_OutlineThickness", 0f);
                 StoreController.S.CurrentSaveSlot = 1;
            }
            else
            {
               WindowController.S.MainWindow.gameObject.SetActive(false);
               WindowController.S.RoleWindow.gameObject.SetActive(true);
               LevelInfoConfig.InitGameLevel();
               StoreController.S.LoadStoreData();
               ObserverModuleManager.S.SendEvent("ShowTitle");
               ObserverModuleManager.S.SendEvent("ShowChiBang");
               gameObject.SetActive(false);
               StoreController.S.IsGame=true;
               Screen.SetResolution(PlayerData.S.RateX, PlayerData.S.RateY, PlayerData.S.IsQuanPing);
            }
          
         }
      );
      
      BgButton2.onClick.AddListener(() =>
         {
            if (StoreController.S.CurrentSaveSlot != 2)
            {
               shuji1bgMaterial.SetFloat("_OutlineThickness", 0f);
               shuji2bgMaterial.SetFloat("_OutlineThickness", 0.082f);
               shuji3bgMaterial.SetFloat("_OutlineThickness", 0f);
               StoreController.S.CurrentSaveSlot = 2;
            }
            else
            {
               WindowController.S.MainWindow.gameObject.SetActive(false);
               WindowController.S.RoleWindow.gameObject.SetActive(true);
               LevelInfoConfig.InitGameLevel();
               StoreController.S.LoadStoreData();
               gameObject.SetActive(false);
               StoreController.S.IsGame=true;
               Screen.SetResolution(PlayerData.S.RateX, PlayerData.S.RateY, PlayerData.S.IsQuanPing);
            }
          
         }
      );
      
      BgButton3.onClick.AddListener(() =>
         {
            if (StoreController.S.CurrentSaveSlot != 3)
            {
               shuji1bgMaterial.SetFloat("_OutlineThickness", 0f);
               shuji2bgMaterial.SetFloat("_OutlineThickness", 0f);
               shuji3bgMaterial.SetFloat("_OutlineThickness", 0.082f);
               StoreController.S.CurrentSaveSlot = 3;
            }
            else
            {
               WindowController.S.MainWindow.gameObject.SetActive(false);
               WindowController.S.RoleWindow.gameObject.SetActive(true);
               LevelInfoConfig.InitGameLevel();
               StoreController.S.LoadStoreData();
               gameObject.SetActive(false);
               StoreController.S.IsGame=true;
               Screen.SetResolution(PlayerData.S.RateX, PlayerData.S.RateY, PlayerData.S.IsQuanPing);
            }
          
         }
      );

      ShanChuButton1.onClick.AddListener(() =>
         {
            shanchuIndex = 1;
            ShanChuMask.SetActive(true);
            
         }
      );
      ShanChuButton2.onClick.AddListener(() =>
         {
            shanchuIndex = 2;
            ShanChuMask.SetActive(true);
            
         }
      );
      ShanChuButton3.onClick.AddListener(() =>
         {
            shanchuIndex = 3;
            ShanChuMask.SetActive(true);
            
         }
      );
      
      NoButton.onClick.AddListener(() =>
      {
         ShanChuMask.SetActive(false);
      });
      YesButton.onClick.AddListener(() =>
      {
         ShanChuMask.SetActive(false);
         switch (shanchuIndex)
         {
            case 1:
               var path1 = Path.Combine(Application.persistentDataPath, "store1.json");
               if (File.Exists(path1))
               {
                  File.Delete(path1);
               }
               break;
            case 2:
               var path2 = Path.Combine(Application.persistentDataPath, "store2.json");
               if (File.Exists(path2))
               {
                  File.Delete(path2);
               }
               break;
            case 3:
               var path3 = Path.Combine(Application.persistentDataPath, "store3.json");
               if (File.Exists(path3))
               {
                  File.Delete(path3);
               }
               break;
         }
         Show();
      });
   }
}
