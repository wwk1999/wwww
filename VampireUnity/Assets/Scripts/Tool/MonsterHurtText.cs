using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHurtText : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI normalText;
    public TextMeshProUGUI critText;
    [NonSerialized]public bool isCrit=false;
    private void OnEnable()
    {
        if (isCrit)
        {
            animator.Play("HurtTextCrit");
        }
        else
        {
            animator.Play("HurtText");
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        GameController.S.MonsterHurtTextQueue.Enqueue(this);
    }
}
