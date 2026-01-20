using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;

public class MJToast : MonoBehaviour
{
   public TextMeshProUGUI jingcuiCount;
   public TextMeshProUGUI zhuanjinCount;
   public Animator jingcuiAnimator;
   public Animator zhuanjinAnimator;

   private void Awake()
   {
      jingcuiCount.text = MJConfig.JiangLiDic[PlayerData.S.mJLevel].jingcui.ToString();
      zhuanjinCount.text = MJConfig.JiangLiDic[PlayerData.S.mJLevel].zhuanjin.ToString();
      jingcuiAnimator.Play("OrangeEdge");
      zhuanjinAnimator.Play("OrangeEdge");
   }
}
