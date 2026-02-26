using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIToast : MonoBehaviour
{
   public TextMeshProUGUI  text;
   public Animator animator;
   
   public GameObject ToastPrefab;
   private Queue<String>_queue=new Queue<String>();
   public Canvas Canvas;
   private float time = 0;
   public Animator Animator;
   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent(ConstKeys.ShowUIToast, ShowUIToast);
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent(ConstKeys.ShowUIToast, ShowUIToast);
   }

   private void Update()
   {
      time+=Time.deltaTime;
      if (_queue.Count > 0&&time>0.1f)
      {
         time = 0;
         var content = _queue.Dequeue();
         var toast = Instantiate(ToastPrefab, Canvas.transform);
         toast.gameObject.SetActive(true);
         toast.transform.Find("Bg/Text").GetComponent<TextMeshProUGUI>().text = content;
         Animator.Play("UIToast");
      }
   }

   public void ShowUIToast(object[] args)
   {
      string content=args[0].ToString();
      _queue.Enqueue(content);
   }
}
