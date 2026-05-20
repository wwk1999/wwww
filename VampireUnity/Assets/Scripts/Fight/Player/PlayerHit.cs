using System;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    private void OnEnable()
    {
        GetComponent<Animator>().Play("PlayerHit");
    }

    public void AnimationEnd()
    {
        gameObject.SetActive(false);
        FightBGController.S.PlayerHitQueue.Enqueue(this);
    }
}
