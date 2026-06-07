using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiRenDiPen : MonoBehaviour
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
