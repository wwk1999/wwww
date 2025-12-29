using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum YiChangState
{
    None,
    Du,
}
public class MonsterHurtText : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI normalText;
    public TextMeshProUGUI critText;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI duText;


    [NonSerialized]public bool isCrit=false;
    [NonSerialized]public bool isPlayer=false;
    [NonSerialized]public YiChangState yiChangState=YiChangState.None;

    private void OnEnable()
    {
        if (isPlayer)
        {
            animator.Play("PlayerHurt");
        }
        else if (yiChangState != YiChangState.None)
        {
            switch (yiChangState)
            {
                case YiChangState.Du:
                    animator.Play("DuText");
                    break;
            }
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
