using System;
using UnityEngine;

namespace Fight.Monster.秘境.LuRen
{
    public class HuoGuaiDanPeng:MonoBehaviour
    {
        public Animator animator;
        [NonSerialized]public Vector2 MoveDirection;
        public GameObject parent;
        private void OnEnable()
        {
            animator.Play("NewSequenceAnim");
        }
    }
}