using System;
using UnityEngine;

namespace Fight.Monster.秘境.HuoGuai
{
    public class HuoXuanFen: MonoBehaviour
    {
        public Animator animator;

        private void OnEnable()
        {
            animator.Play("NewSequenceAnim");
        }
    }
}