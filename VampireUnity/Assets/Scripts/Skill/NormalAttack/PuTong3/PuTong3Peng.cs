using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class PuTong3Peng : MonoBehaviour
{
    public SkeletonAnimation skeleton;

    private void OnEnable()
    {
        var trackEntry = skeleton.AnimationState.SetAnimation(0, "action", false);
        trackEntry.Complete += OnActionAnimationComplete;
    }

    private void OnActionAnimationComplete(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "action")
        {
            gameObject.SetActive(false);
            GameController.S.PuTong3PengQueue.Enqueue(gameObject);
        }
        // 取消订阅，避免重复调用
        trackEntry.Complete -= OnActionAnimationComplete;
    }
    
}
