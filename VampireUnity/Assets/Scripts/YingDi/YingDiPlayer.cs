using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class YingDiPlayer : MonoBehaviour
{
   public SkeletonAnimation playerSkeleton;
   public Rigidbody2D rg;

   private void Start()
   {
      playerSkeleton.AnimationState.SetAnimation(0, "idle",true);
   }

   private void Update()
   {
      PlayerMove();
   }

   public void PlayerMove()
   {
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
         if (playerSkeleton.AnimationState.GetCurrent(0).Animation.Name != "walk")
         { 
            playerSkeleton.AnimationState.SetAnimation(0, "walk",true);
         }
      }
        
      // 使用 ScaleX 的正负来表示翻转（新版 Spine runtime 移除了 FlipX 属性）
      float currentScaleX = playerSkeleton.Skeleton.ScaleX;
      float absScaleX = Mathf.Abs(currentScaleX);
      if (horizontal > 0)
      {
         playerSkeleton.Skeleton.ScaleX = absScaleX;
      }
      if (horizontal < 0)
      {
         playerSkeleton.Skeleton.ScaleX = -absScaleX;
      }
      rg.velocity = new Vector2(horizontal, vertical).normalized * 3;
   }
}
