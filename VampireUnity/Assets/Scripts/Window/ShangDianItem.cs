using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShangDianItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public Image bg;
   public Image image;
   public int PropId;
   private GameObject instance;
   private Vector2 offset = new Vector2(250f, 0f);
   public PropConfig.PropType PropType;
   public int Quality;
   public TextMeshProUGUI Name1;
   public TextMeshProUGUI Name2;
   public TextMeshProUGUI Name3;
   public TextMeshProUGUI Name4;
   public TextMeshProUGUI Name5;
   public TextMeshProUGUI Name6;

   public TextMeshProUGUI Count;


   public void OnPointerEnter(PointerEventData eventData)
   {
      Spawn();
   }

   public void OnPointerExit(PointerEventData eventData)
   {
      if (instance.gameObject != null)
      {
          Destroy(instance.gameObject);
      }
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


   private void Update()
   {
      if (Input.GetMouseButtonDown(1))
      {
         Debug.Log("鼠标右键按下");
         if (IsMouseOverUIObject(bg.gameObject))
         {
            ShangDianConfig.ShangPingItem item=new ShangDianConfig.ShangPingItem(){type = PropType,quality = Quality};
            int count = ShangDianConfig.ShangPingCountDic[item];
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
               if (GlobalPlayerAttribute.BloodEnergy < count * 10)
               {
                  ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"灵魂不足");
                  return;
               }
               GlobalPlayerAttribute.BloodEnergy -= count * 10;
               if (BagController.S.PropList.ContainsKey(PropId))
               {
                  BagController.S.PropList[PropId].Count += 10;
               }
               else
               {
                  BagController.S.PropList.Add(PropId,new PropTable(){Count = 10,Desc = "",EquipName = "",PropType = PropType,Quality =  Quality});
               }
            }
            else
            {
               if (GlobalPlayerAttribute.BloodEnergy < count)
               {
                  ObserverModuleManager.S.SendEvent(ConstKeys.ShowUIToast,"灵魂不足");
                  return;
               }
               
               GlobalPlayerAttribute.BloodEnergy -= count;
               if (BagController.S.PropList.ContainsKey(PropId))
               {
                  BagController.S.PropList[PropId].Count += 1;
               }
               else
               {
                  BagController.S.PropList.Add(PropId,new PropTable(){Count = 1,Desc = "",EquipName = "",PropType = PropType,Quality =  Quality});
               }
            }
            
            StoreController.S.SaveStoreData();
         }
      }
   }


   public void ShowQuality(int quality)
   {
      instance.transform.Find("bg/quality/quality1").gameObject.SetActive(quality == 1);
      instance.transform.Find("bg/quality/quality2").gameObject.SetActive(quality == 2);
      instance.transform.Find("bg/quality/quality3").gameObject.SetActive(quality == 3);
      instance.transform.Find("bg/quality/quality4").gameObject.SetActive(quality == 4);
      instance.transform.Find("bg/quality/quality5").gameObject.SetActive(quality == 5);
      instance.transform.Find("bg/quality/quality6").gameObject.SetActive(quality == 6);
   }

   public void ShowName(int Name)
   {
      instance.transform.Find("bg/Name/Name1").gameObject.SetActive(Name == 1);
      instance.transform.Find("bg/Name/Name2").gameObject.SetActive(Name == 2);
      instance.transform.Find("bg/Name/Name3").gameObject.SetActive(Name == 3);
      instance.transform.Find("bg/Name/Name4").gameObject.SetActive(Name == 4);
      instance.transform.Find("bg/Name/Name5").gameObject.SetActive(Name == 5);
      instance.transform.Find("bg/Name/Name6").gameObject.SetActive(Name == 6);
      instance.transform.Find("bg/Name/Name1").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[PropId];
      instance.transform.Find("bg/Name/Name2").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[PropId];
      instance.transform.Find("bg/Name/Name3").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[PropId];
      instance.transform.Find("bg/Name/Name4").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[PropId];
      instance.transform.Find("bg/Name/Name5").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[PropId];
      instance.transform.Find("bg/Name/Name6").GetComponent<TextMeshProUGUI>().text = PropConfig.PropNameDic[PropId];
   }

   public void SetInstance(int prop)
   {
      switch (prop % 100)
      {
         case 1:
            ShowQuality(1);
            ShowName(1);
            instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.WhiteBg;
            instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("WhiteEdge");
            break;
         case 2:
            ShowQuality(2);
            ShowName(2);
            instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.GreenBg;
            instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("GreenEdge");
            break;
         case 3:
            ShowQuality(3);
            ShowName(3);
            instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.BlueBg;
            instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("BlueEdge");
            break;
         case 4:
            ShowQuality(4);
            ShowName(4);
            instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.PurpleBg;
            instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("PurpleEdge");
            break;
         case 5:
            ShowQuality(5);
            ShowName(5);
            instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.OrangeBg;
            instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("OrangeEdge");
            break;
         case 6:
            ShowQuality(6);
            ShowName(6);
            instance.transform.Find("bg/image/imagebg").GetComponent<Image>().sprite = ResourcesConfig.RedBg;
            instance.transform.Find("bg/image/Edge").GetComponent<Animator>().Play("RedEdge");
            break;
      }
      
      instance.transform.Find("bg/Desc").GetComponent<TextMeshProUGUI>().text = PropConfig.PropDescDic[prop];
      instance.transform.Find("bg/image/Image").GetComponent<Image>().sprite =ResourcesConfig.GetPropSprite(PropId);
   }

   public void Spawn()
   {
      if (instance != null) return;
      GameObject prefab = null;
      prefab = Resources.Load<GameObject>("Prefabs/Window/ShangDianItemInfo");
      Canvas canvas = GetComponentInParent<Canvas>();
      if (canvas == null)
      {
         Debug.LogError("PropInfoSpawner: 找不到父级 Canvas。");
         return;
      }

      RectTransform canvasRect = canvas.GetComponent<RectTransform>();
      RectTransform buttonRect = GetComponent<RectTransform>();
      instance = Instantiate(prefab, canvas.transform);

      RectTransform instRect = instance.GetComponent<RectTransform>();

      Vector3[] corners = new Vector3[4];
      buttonRect.GetWorldCorners(
         corners); // corners: 0=BL,1=TL,2=TR,3=BR for some rects; using corners[3] as bottom-right in previous code — safe to use TR depending on anchor. We'll use corners[3] to match previous behavior.

      // 使用按钮的右下角（world）转换到屏幕坐标，再加偏移（屏幕空间）
      Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, corners[3]);
      screenPoint += offset;
      //screenPoint += new Vector2(0, -instance.GetComponent<RectTransform>().sizeDelta.y);

      Vector3 worldPos;
      RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasRect, screenPoint, canvas.worldCamera,
         out worldPos);
      instance.transform.position = worldPos;
      SetInstance(PropId);

      // 设置父（保留世界坐标），把实例置于最上层
      instance.transform.SetAsLastSibling();
   }

   public void SetItem(ShangDianConfig.ShangPingItem item)
   {
      Name1.gameObject.SetActive(false);
      Name2.gameObject.SetActive(false);
      Name3.gameObject.SetActive(false);
      Name4.gameObject.SetActive(false);
      Name5.gameObject.SetActive(false);
      Name6.gameObject.SetActive(false);

      switch (item.quality)
      {
         case 1:
            bg.sprite = ResourcesConfig.WhiteBg;
            Name1.gameObject.SetActive(true);
            Name1.text= PropConfig.PropNameDic[PropId];
            break;
         case 2:
            bg.sprite = ResourcesConfig.GreenBg;
            Name2.gameObject.SetActive(true);
            Name2.text= PropConfig.PropNameDic[PropId];
            break;
         case 3:
            bg.sprite = ResourcesConfig.BlueBg;
            Name3.gameObject.SetActive(true);
            Name3.text= PropConfig.PropNameDic[PropId];
            break;
         case 4:
            bg.sprite = ResourcesConfig.PurpleBg;
            Name4.gameObject.SetActive(true);
            Name4.text= PropConfig.PropNameDic[PropId];
            break;
         case 5:
            bg.sprite = ResourcesConfig.OrangeBg;
            Name5.gameObject.SetActive(true);
            Name5.text= PropConfig.PropNameDic[PropId];
            break;
         case 6:
            bg.sprite = ResourcesConfig.RedBg;
            Name6.gameObject.SetActive(true);
            Name6.text= PropConfig.PropNameDic[PropId];
            break;
      }

      image.sprite = ShangDianConfig.GetShangPingSprite(item);
      Count.text = " " + ShangDianConfig.ShangPingCountDic[item]+"S";

   }
}
