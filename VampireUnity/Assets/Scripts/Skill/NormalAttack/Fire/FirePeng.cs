using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class FirePeng : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;

    private void OnEnable()
    {
        skeletonAnimation.AnimationState.SetAnimation(0, "action", false);
        // 监听动画完成事件
        skeletonAnimation.AnimationState.Complete += OnAnimationComplete;
    }

    private void OnDisable()
    {
        // 记得取消订阅，避免内存泄漏
        if (skeletonAnimation != null && skeletonAnimation.AnimationState != null)
        {
            skeletonAnimation.AnimationState.Complete -= OnAnimationComplete;
        }
    }

// 动画完成回调
    private void OnAnimationComplete(Spine.TrackEntry trackEntry)
    {
        // 检查是否是目标动画
        if (trackEntry.Animation.Name == "action")
        {
            Debug.Log("action 动画播放完成！");
            // 在这里处理动画结束后的逻辑
        }
    }
}
