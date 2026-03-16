using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBaoZhaNext : MonoBehaviour
{
    public Animator animator;
    [NonSerialized]public Vector2 direction;
    public GameObject parent;
    private void OnEnable()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        parent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        animator.Play("NewSequenceAnim");
    }
}
