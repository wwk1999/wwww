using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIToast : MonoBehaviour
{
   public TextMeshProUGUI  text;
   public Animator animator;
   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent(ConstKeys.ShowUIToast, ShowUIToast);
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent(ConstKeys.ShowUIToast, ShowUIToast);
   }

   public void ShowUIToast(object[] args)
   {
      string content=args[0].ToString();
      text.text = content;
      animator.Play("UIToast",0,0);
   }
}
