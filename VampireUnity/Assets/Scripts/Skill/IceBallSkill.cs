using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBallSkill : MonoBehaviour
{
   private void Update()
   {
      var iceBallSpeed = SkillController.S.IceBallSpeed;
      transform.Rotate(0, 0, iceBallSpeed);
   }

   private void OnEnable()
   {
      Invoke(nameof(Hide),SkillController.S.IceBallDuration);
   }

   public void Hide()
   {
      gameObject.SetActive(false);
   }
}
