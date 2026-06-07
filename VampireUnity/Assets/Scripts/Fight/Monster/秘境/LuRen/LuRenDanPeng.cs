using System;
using UnityEngine;

namespace Fight.Monster.秘境.LuRen
{
    public class LuRenDanPeng:MonoBehaviour
    {
        public Animator animator;
        [NonSerialized]public Vector2 MoveDirection;
        public GameObject parent;
        private void OnEnable()
        {
            animator.Play("NewSequenceAnim");
            float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
            parent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}