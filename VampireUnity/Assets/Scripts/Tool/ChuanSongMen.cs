using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class ChuanSongMen : MonoBehaviour
{
    public SkeletonAnimation SkeletonAnimation;

    private void Start()
    {
        if (SkeletonAnimation != null)
            SkeletonAnimation.AnimationState.SetAnimation(0, "Idle", true);

        transform.localScale = Vector3.zero;
        StartCoroutine(ScaleUpCoroutine(1f));
    }


    private void Update()
    {
        if (Vector2.Distance(transform.position, QueueController.S.gamePlayer.transform.position) < 2f)
        {
            FightBGController.S.isShowAgain=true;
        }
        else
        {
            FightBGController.S.isShowAgain=false;
        }
    }

    private IEnumerator ScaleUpCoroutine(float duration)
    {
        Vector3 from = Vector3.zero;
        Vector3 to = Vector3.one;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            float eased = Mathf.SmoothStep(0f, 1f, t);
            transform.localScale = Vector3.LerpUnclamped(from, to, eased);
            yield return null;
        }

        transform.localScale = to;
    }
}