using System;
using Spine.Unity;
using UnityEngine;
using Random = UnityEngine.Random;


public class TreeManSkill : MonoBehaviour
{
    public Animator animator;
    public float damage;
    private bool isDamaged = false;
    public SpriteRenderer spriteRenderer;
    
    private void OnEnable()
    {
        spriteRenderer.sortingOrder += (int)(transform.position.y * 100);
        animator.Play("NewSequenceAnim");
    }
    
}