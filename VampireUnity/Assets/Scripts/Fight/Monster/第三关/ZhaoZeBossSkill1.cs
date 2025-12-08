using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class ZhaoZeBossSkill1 : MonoBehaviour
{
    public MonsterBase monsterBase;
    public SkeletonAnimation monsterSkeletonAnimation;
    private bool isRange=false;

    private float SkillTime = 5f;
    private float CurrentTime = 0f;

    private void Start()
    {
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
    }

    private void OnDestroy()
    {
        monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
    }

    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "damage")
        {
            if (isRange)
            {
                GameController.S.gamePlayer.PlayerHurt(monsterBase.Attack,true);
            }
        }
    }
    private void Update()
    {
        CurrentTime+= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            isRange = true;
            if (CurrentTime > SkillTime)
            {
                monsterBase.isSkill1 = true;
                CurrentTime = 0f;
            }
        }
    }
   
    private void OnTriggerExit2D(Collider2D other)
    {
        isRange = false;
        if (other.CompareTag("Player"))
        {
            monsterBase.isSkill1 = false;
        }
    }
}
