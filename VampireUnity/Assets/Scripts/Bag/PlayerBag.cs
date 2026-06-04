using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Spine.Unity;
using UnityEngine;

public class PlayerBag : MonoBehaviour
{
   public SkeletonAnimation playerSkeleton;
   public SkeletonAnimation ShengHuaSkeleton;
    
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

   private void OnEnable()
   {
       PlayerHuanZhuangBag();
   }

   public void PlayerHuanZhuangBag()
    {
        Spine.Skeleton skeleton = null;
        if (PlayerData.S.shiZhuangType == ShiZhuangType.RedDian || PlayerData.S.shiZhuangType == ShiZhuangType.RedIce ||
            PlayerData.S.shiZhuangType == ShiZhuangType.RedHeiAn || PlayerData.S.shiZhuangType == ShiZhuangType.RedHuo)
        {
            playerSkeleton.gameObject.SetActive(false);
            ShengHuaSkeleton.gameObject.SetActive(true);
            skeleton = ShengHuaSkeleton.skeleton;
        }
        else
        {
            playerSkeleton.gameObject.SetActive(true);
            ShengHuaSkeleton.gameObject.SetActive(false);
            skeleton = playerSkeleton.Skeleton;
        }
        string skinName = GetSkinNameByType(PlayerData.S.shiZhuangType);
        Spine.Skin skin = skeleton.Data.FindSkin(skinName);
        if (skin != null)
        {
            skeleton.SetSkin(skin);
            skeleton.SetupPoseSlots();
            playerSkeleton.LateUpdate();
        }
    }
}
