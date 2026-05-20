using System;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        if (QueueController.S.gamePlayer != null)
        {
            QueueController.S.gamePlayer.IsWuDi = true;
        }
        GetComponent<Animator>().Play("PlayerHit");
    }

    public void AnimationEnd()
    {
        gameObject.SetActive(false);
        FightBGController.S.PlayerHitQueue.Enqueue(this);
    }
}
