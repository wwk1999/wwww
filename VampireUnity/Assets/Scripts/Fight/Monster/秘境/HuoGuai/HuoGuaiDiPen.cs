using UnityEngine;

namespace Fight.Monster.秘境.HuoGuai
{
    public class HuoGuaiDiPen:MonoBehaviour
    {
        public Animator animator;
        public float damage;
        public SpriteRenderer spriteRenderer;
    
        private void OnEnable()
        {
            spriteRenderer.sortingOrder += (int)(transform.position.y * 100);
            animator.Play("NewSequenceAnim");
        }
    }
}