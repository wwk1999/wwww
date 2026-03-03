using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.EventSystems;

public class YingDiPlayer : MonoBehaviour
{
   public SkeletonAnimation playerSkeleton;
   public Rigidbody2D rg;
   public GameObject parent;
   public GameObject bodyparent;


   private void Start()
   {
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
