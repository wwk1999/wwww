using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class PlayerChiBangFight : MonoBehaviour
{
   public SpriteRenderer Sprite;
   
   
   public MeshRenderer Green1Renderer;
   public MeshRenderer Green2Renderer;
   public MeshRenderer Green3Renderer;
   public MeshRenderer Green4Renderer;
   public MeshRenderer Green5Renderer;
   public MeshRenderer Green6Renderer;

   public MeshRenderer Blue1Renderer;
   public MeshRenderer Blue2Renderer;
   public MeshRenderer Blue3Renderer;
   public MeshRenderer Blue4Renderer;
   public MeshRenderer Blue5Renderer;
   public SpriteRenderer Blue6Renderer;
   public MeshRenderer Blue7Renderer;
   public MeshRenderer Blue8Renderer;
   
   public MeshRenderer Purple1Renderer;
   public MeshRenderer Purple2Renderer;
   public MeshRenderer Purple3Renderer;
   public MeshRenderer Purple4Renderer;
   public SpriteRenderer Purple5Renderer;
   public SpriteRenderer Purple6Renderer;
   public MeshRenderer Purple7Renderer;
   
   public SpriteRenderer Orange1Renderer;
   public SpriteRenderer Orange2Renderer;
   public SpriteRenderer Orange3Renderer;
   
   public SpriteRenderer Red1Renderer;
   
   
   public SkeletonAnimation Green1;
   public SkeletonAnimation Green2;
   public SkeletonAnimation Green3;
   public SkeletonAnimation Green4;
   public SkeletonAnimation Green5;
   public SkeletonAnimation Green6;

   public SkeletonAnimation Blue1;
   public SkeletonAnimation Blue2;
   public SkeletonAnimation Blue3;
   public SkeletonAnimation Blue4;
   public SkeletonAnimation Blue5;
   public Animator Blue6;
   public SkeletonAnimation Blue7;
   public SkeletonAnimation Blue8;
   
   public SkeletonAnimation Purple1;
   public SkeletonAnimation Purple2;
   public SkeletonAnimation Purple3;
   public SkeletonAnimation Purple4;
   public Animator Purple5;
   public Animator Purple6;
   public SkeletonAnimation Purple7;
   
   public Animator Orange1;
   public Animator Orange2;
   public Animator Orange3;
   
   public Animator Red1;


   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("ShowChiBang",ShowChiBangObj);
      ShowChiBang();
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("ShowChiBang",ShowChiBangObj);
   }

   public void ShowChiBangObj(object[] obj)
   {
      ShowChiBang();
   }

   private void Update()
   {
      switch (PlayerData.S.playerChiBangType)
      {
         case ChiBangType.Green1:
            Green1Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Green2:
            Green2Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Green3:
            Green3Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Green4:
            Green4Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Green5:
            Green5Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Green6:
            Green6Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         
         
         case ChiBangType.Blue1:
            Blue1Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Blue2:
            Blue2Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Blue3:
            Blue3Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Blue4:
            Blue4Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Blue5:
            Blue5Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Blue6:
            Blue6Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Blue7:
            Blue7Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Blue8:
            Blue8Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         
         
         case ChiBangType.Purple1:
            Purple1Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Purple2:
            Purple2Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Purple3:
            Purple3Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Purple4:
            Purple4Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Purple5:
            Purple5Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Purple6:
            Purple6Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Purple7:
            Purple7Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         
         case ChiBangType.Orange1:
            Orange1Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Orange2:
            Orange2Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         case ChiBangType.Orange3:
            Orange3Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
         
         case ChiBangType.Red1:
            Red1Renderer.sortingOrder = Sprite.sortingOrder-1;
            break;
      }
   }

   public void ShowChiBang()
   {
      Green1.gameObject.SetActive(false);
      Green2.gameObject.SetActive(false);
      Green3.gameObject.SetActive(false);
      Green4.gameObject.SetActive(false);
      Green5.gameObject.SetActive(false);
      Green6.gameObject.SetActive(false);
      
      
      Blue1.gameObject.SetActive(false);
      Blue2.gameObject.SetActive(false);
      Blue3.gameObject.SetActive(false);
      Blue4.gameObject.SetActive(false);
      Blue5.gameObject.SetActive(false);
      Blue6.gameObject.SetActive(false);
      Blue7.gameObject.SetActive(false);
      Blue8.gameObject.SetActive(false);
      
      Purple1.gameObject.SetActive(false);
      Purple2.gameObject.SetActive(false);
      Purple3.gameObject.SetActive(false);
      Purple4.gameObject.SetActive(false);
      Purple5.gameObject.SetActive(false);
      Purple6.gameObject.SetActive(false);
      Purple7.gameObject.SetActive(false);
      
      Orange1.gameObject.SetActive(false);
      Orange2.gameObject.SetActive(false);
      Orange3.gameObject.SetActive(false);

      Red1.gameObject.SetActive(false);

      switch (PlayerData.S.playerChiBangType)
      {
         case ChiBangType.Green1:
            Green1.gameObject.SetActive(true);
            Green1.AnimationState.SetAnimation(0, "idle", true);
            break;
         case ChiBangType.Green2:
            Green2.gameObject.SetActive(true);
            Green2.AnimationState.SetAnimation(0, "idle", true);
            break;
         case ChiBangType.Green3:
            Green3.gameObject.SetActive(true);
            Green3.AnimationState.SetAnimation(0, "idle", true);
            break;
         case ChiBangType.Green4:
            Green4.gameObject.SetActive(true);
            Green4.AnimationState.SetAnimation(0, "animation", true);
            break;
         case ChiBangType.Green5:
            Green5.gameObject.SetActive(true);
            Green5.AnimationState.SetAnimation(0, "animation", true);
            break;
         case ChiBangType.Green6:
            Green6.gameObject.SetActive(true);
            Green6.AnimationState.SetAnimation(0, "animation", true);
            break;
         
         
         case ChiBangType.Blue1:
            Blue1.gameObject.SetActive(true);
            Blue1.AnimationState.SetAnimation(0, "animation_ui", true);
            break;
         case ChiBangType.Blue2:
            Blue2.gameObject.SetActive(true);
            Blue2.AnimationState.SetAnimation(0, "idle", true);
            break;
         case ChiBangType.Blue3:
            Blue3.gameObject.SetActive(true);
            Blue3.AnimationState.SetAnimation(0, "idle", true);
            break;
         case ChiBangType.Blue4:
            Blue4.gameObject.SetActive(true);
            Blue4.AnimationState.SetAnimation(0, "dj", true);
            break;
         case ChiBangType.Blue5:
            Blue5.gameObject.SetActive(true);
            Blue5.AnimationState.SetAnimation(0, "dj", true);
            break;
         case ChiBangType.Blue6:
            Blue6.gameObject.SetActive(true);
            Blue6.Play("NewSequenceAnimSprite");
            break;
         case ChiBangType.Blue7:
            Blue7.gameObject.SetActive(true);
            Blue7.AnimationState.SetAnimation(0, "wings", true);
            break;
         case ChiBangType.Blue8:
            Blue8.gameObject.SetActive(true);
            Blue8.AnimationState.SetAnimation(0, "idle", true);
            break;
         
         
         
         case ChiBangType.Purple1:
            Purple1.gameObject.SetActive(true);
            Purple1.AnimationState.SetAnimation(0, "standby", true);
            break;
         case ChiBangType.Purple2:
            Purple2.gameObject.SetActive(true);
            Purple2.AnimationState.SetAnimation(0, "standby", true);
            break;
         case ChiBangType.Purple3:
            Purple3.gameObject.SetActive(true);
            Purple3.AnimationState.SetAnimation(0, "animation_ui", true);
            break;
         case ChiBangType.Purple4:
            Purple4.gameObject.SetActive(true);
            Purple4.AnimationState.SetAnimation(0, "animation_ui", true);
            break;
         case ChiBangType.Purple5:
            Purple5.gameObject.SetActive(true);
            Purple5.Play("NewSequenceAnimSprite");
            break;
         case ChiBangType.Purple6:
            Purple6.gameObject.SetActive(true);
            Purple6.Play("NewSequenceAnimSprite");
            break;
         case ChiBangType.Purple7:
            Purple7.gameObject.SetActive(true);
            Purple7.AnimationState.SetAnimation(0, "animation", true);
            break;
         
         case ChiBangType.Orange1:
            Orange1.gameObject.SetActive(true);
            Orange1.Play("NewSequenceAnimSprite");
            break;
         case ChiBangType.Orange2:
            Orange2.gameObject.SetActive(true);
            Orange2.Play("NewSequenceAnimSprite");
            break;
         case ChiBangType.Orange3:
            Orange3.gameObject.SetActive(true);
            Orange3.Play("NewSequenceAnimSprite");
            break;
         
         case ChiBangType.Red1:
            Red1.gameObject.SetActive(true);
            Red1.Play("NewSequenceAnimSprite");
            break;
      }
   }
}
