using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class ZhaoZeBossSkill2 : MonoBehaviour
{
    public MonsterBase monsterBase;
    public SkeletonAnimation monsterSkeletonAnimation;
    private float SkillTime = 10f;
    private float CurrentTime = 0f;
    private bool isRange=false;

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
            isRange=true;
            if (CurrentTime > SkillTime)
            {
                monsterBase.isSkill2 = true;
                CurrentTime = 0f;
            }
        }
    }
   
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isRange=false;
            monsterBase.isSkill2 = false;
        }
    }
}
