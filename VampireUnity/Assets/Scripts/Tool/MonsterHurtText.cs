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
    public TextMeshProUGUI playerText;

    [NonSerialized]public bool isCrit=false;
    [NonSerialized]public bool isPlayer=false;

    private void OnEnable()
    {
        if (isPlayer)
        {
            animator.Play("PlayerHurt");
        }
        else
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
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        GameController.S.MonsterHurtTextQueue.Enqueue(this);
    }
}
