using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Spine.Unity;
using UnityEngine;
using UnityEngine.EventSystems;

public class YingDiPlayer : MonoBehaviour
{
   public SkeletonAnimation playerSkeleton;
   public SkeletonAnimation ShengHuaSkeleton;

   public Rigidbody2D rg;
   public GameObject parent;
   public GameObject bodyparent;

   public string GetSkinNameByType(ShiZhuangType shiZhuangType)
   {
      switch (shiZhuangType)
      {
         case ShiZhuangType.GreenDian:
            return "greendian";
         case ShiZhuangType.GreenHuo:
            return "greenhuo";
         case ShiZhuangType.GreenIce:
            return "greenbing";
         case ShiZhuangType.GreenHeiAn:
            return "greenheian";
      
         case ShiZhuangType.BlueDian:
            return "bluedian";
         case ShiZhuangType.BlueHuo:
            return "bluehuo";
         case ShiZhuangType.BlueIce:
            return "bluebing";
         case ShiZhuangType.BlueHeiAn:
            return "blueheian";
      
         case ShiZhuangType.PurpleDian:
            return "purpledian";
         case ShiZhuangType.PurpleHuo:
            return "purplehuo";
         case ShiZhuangType.PurpleIce:
            return "purplebing";
         case ShiZhuangType.PurpleHeiAn:
            return "purpleheian";
      
         case ShiZhuangType.OrangeDian:
            return "orangedian";
         case ShiZhuangType.OrangeHuo:
            return "orangehuo";
         case ShiZhuangType.OrangeIce:
            return "orangebing";
         case ShiZhuangType.OrangeHeiAn:
            return "orangeheian";
         
         case ShiZhuangType.RedDian:
            return "reddian";
         case ShiZhuangType.RedHuo:
            return "redhuo";
         case ShiZhuangType.RedIce:
            return "redbing";
         case ShiZhuangType.RedHeiAn:
            return "redheian";
      }
      return null;
   }
  public void PlayerHuanZhuang(object[] obj)
{
    // 1. 确定使用的骨骼组件
    Spine.Skeleton skeleton = null;
    if (PlayerData.S.shiZhuangType == ShiZhuangType.RedDian ||
        PlayerData.S.shiZhuangType == ShiZhuangType.RedIce ||
        PlayerData.S.shiZhuangType == ShiZhuangType.RedHeiAn ||
        PlayerData.S.shiZhuangType == ShiZhuangType.RedHuo)
    {
        if (ShengHuaSkeleton == null)
        {
            Debug.LogError("PlayerHuanZhuang: ShengHuaSkeleton 为空，无法切换至升华皮肤");
            return;
        }
        playerSkeleton.gameObject.SetActive(false);
        ShengHuaSkeleton.gameObject.SetActive(true);
        skeleton = ShengHuaSkeleton.skeleton;
    }
    else
    {
        if (playerSkeleton == null)
        {
            Debug.LogError("PlayerHuanZhuang: playerSkeleton 为空");
            return;
        }
        playerSkeleton.gameObject.SetActive(true);
        ShengHuaSkeleton.gameObject.SetActive(false);
        skeleton = playerSkeleton.Skeleton;
    }

    // 2. 检查 skeleton 有效性
    if (skeleton == null)
    {
        Debug.LogError($"PlayerHuanZhuang: 未获取到有效的 Skeleton 对象 (当前时装类型: {PlayerData.S.shiZhuangType})");
        return;
    }

    // 3. 检查 SkeletonData
    Spine.SkeletonData skeletonData = skeleton.Data;
    if (skeletonData == null)
    {
        Debug.LogError($"PlayerHuanZhuang: skeleton.Data 为空，Spine 资源可能未加载完成。时装类型: {PlayerData.S.shiZhuangType}");
        return;
    }

    // 4. 检查 Skins 列表 (防御性)
    if (skeletonData.Skins == null)
    {
        Debug.LogError($"PlayerHuanZhuang: skeletonData.Skins 为 null，Spine 数据异常。时装类型: {PlayerData.S.shiZhuangType}");
        return;
    }

    // 5. 获取皮肤名称
    string skinName = GetSkinNameByType(PlayerData.S.shiZhuangType);
    if (skinName == null)
    {
       return;
    }
    if (string.IsNullOrEmpty(skinName))
    {
        Debug.LogError($"PlayerHuanZhuang: 无效的皮肤名称，时装类型: {PlayerData.S.shiZhuangType}");
        return;
    }

    // 6. 查找皮肤
    Spine.Skin skin = skeletonData.FindSkin(skinName);
    if (skin == null)
    {
        // 输出可用的皮肤列表，方便调试
        Debug.LogError($"PlayerHuanZhuang: 未找到皮肤 '{skinName}'。当前时装类型: {PlayerData.S.shiZhuangType}");
        return;
    }

    // 7. 应用皮肤
    skeleton.SetSkin(skin);
    skeleton.SetupPoseSlots();

    // 8. 强制刷新（如果 playerSkeleton 组件存在）
    if (playerSkeleton != null)
    {
        playerSkeleton.LateUpdate();
    }
    else if (ShengHuaSkeleton != null)
    {
        ShengHuaSkeleton.LateUpdate();
    }
    else
    {
        Debug.LogWarning("PlayerHuanZhuang: 没有可用的 SkeletonAnimation 组件调用 LateUpdate，但皮肤已更换");
    }
}

  

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("PlayerHuanZhuang",PlayerHuanZhuang);
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("PlayerHuanZhuang",PlayerHuanZhuang);
      ObserverModuleManager.S.SendEvent("PlayerHuanZhuang");
      playerSkeleton.AnimationState.SetAnimation(0, "idle",true);
   }

   public void SetWuQiRotation()
   {
      Vector3 mousePos = Input.mousePosition;
      mousePos.z = 10f; // 距离相机的距离
      Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        
      Vector2 direction = bodyparent.transform.position - worldPosition;
      
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      bodyparent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
   }

   private void Update()
   {
      SetWuQiRotation();
      PlayerMove();
   }

   public void PlayerMove()
   {
      
      Vector3 mousePos = Input.mousePosition;
      mousePos.z = 10f; // 距离相机的距离
      Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
      //获得输入
      float horizontal = Input.GetAxisRaw("Horizontal");
      float vertical = Input.GetAxisRaw("Vertical");
      if (horizontal == 0&&vertical==0)
      {
         if (playerSkeleton.AnimationState.GetCurrent(0).Animation.Name != "idle")
         {
             playerSkeleton.AnimationState.SetAnimation(0, "idle",true);
         }
      }
      else
      {
         if (playerSkeleton.AnimationState.GetCurrent(0).Animation.Name != "move")
         { 
            playerSkeleton.AnimationState.SetAnimation(0, "move",true);
         }
      }
        
      // 使用 ScaleX 的正负来表示翻转（新版 Spine runtime 移除了 FlipX 属性）
      float currentScaleX = parent.transform.localScale.x;
      float absScaleX = Mathf.Abs(currentScaleX);
      if (worldPosition.x-bodyparent.transform.position.x > 0)
      {
         parent.transform.localScale=new Vector3(-absScaleX,parent.transform.localScale.y,parent.transform.localScale.z);
      }
      if (worldPosition.x-bodyparent.transform.position.x < 0)
      {
         parent.transform.localScale=new Vector3(absScaleX,parent.transform.localScale.y,parent.transform.localScale.z);
      }
      rg.velocity = new Vector2(horizontal, vertical).normalized * 2.5f;
   }
}
