using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class HuoShanBoss : MonsterBase
{
    public HuoShanBoss() : base(MonsterType.Boss, "TreeManBoss", 1, 2000, 0.5f, 10, 5, 10, 10, 0) { }
    public Transform attackTrans;
    [NonSerialized]public float Skill1Time= 5f;
    [NonSerialized]public float Skill1CurrentTime = 0f;
    [NonSerialized]public float Skill2Time = 15f;
    [NonSerialized]public float Skill2CurrentTime = 0f;
    [NonSerialized]public float Skill3Time = 15f;
    [NonSerialized]public float Skill3CurrentTime = 0f;
    [NonSerialized]public State CurrentState = State.Move;


    public void Start()
    {
        base.Start();
        AddMonsterEquip();
        AddMonsterSourceStone();
        AddMonsterProp();
    }
    
    public  void Awake()
    {
        base.Awake();
        size = 1.2f;
        MonsterSpineName.AttackName = "attack";
        MonsterSpineName.HitName = "hit";
        MonsterSpineName.MoveName = "walk";
        MonsterSpineName.DieName = "die";
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
        monsterSkeletonAnimation.AnimationState.Complete += Complete;

    }
    
    public void Complete(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "Exit"||trackEntry.Animation.Name == "skill_01"||trackEntry.Animation.Name == "skill_02"||trackEntry.Animation.Name == "skill_03")
        {
            IsSkill=false;
        }
        
        if (isSkill1)
        {
            IsSkill=true;
            isSkill1=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_01", false);
        }else if (isSkill2)
        {
            IsSkill=true;
            isSkill2=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_02", false);
        }else if (isSkill3)
        {
           
        } else if(isAttack)
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.AttackName, false);
        }
        else
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.MoveName, false);
        }
    }

    public void Skill2(Vector2 pos,float dis,float  time,int count)
    {
        StartCoroutine(Skill2Coroutine(pos, dis, time, count));
    }

    private IEnumerator Skill2Coroutine(Vector2 pos, float dis, float time, int count)
    {
        for (int i = 0; i < count; i++)
        {
            // 随机点：Random.insideUnitCircle 返回单位圆内随机点，乘以 dis 后移到指定半径范围
            Vector2 randomOffset = Random.insideUnitCircle * dis;
            Vector2 spawnPos = pos + randomOffset;

            // 调用创建方法（假设 CreateCircleAttack 接受 Vector2 位置）
            GameController.S.CreateCircleAttack(spawnPos,0.6f);
            HuoShanSkill2 huoyan=GameController.S.HuoShanSkill2QiQueue.Dequeue();
            huoyan.transform.position = spawnPos;
            huoyan.damage = Attack;
            huoyan.gameObject.SetActive(true);
            // 等待下一个生成
            if (time > 0f)
                yield return new WaitForSeconds(time);
            else
                yield return null;
        }
    }

    public void ShotJianQi()
    {
        var jianqi = GameController.S.HuoShanJianQiQueue.Dequeue();
        jianqi.damage = Attack;
        jianqi.transform.position = attackTrans.position;
        jianqi.gameObject.SetActive(true);
    }
    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "huoyan"&&trackEntry.Animation.Name == "skill_01")
        {
            ShotJianQi();
        }
        if (e.Data.Name == "huoyan"&&trackEntry.Animation.Name == "skill_02")
        {
            Skill2(Vector2.zero,10,0.1f,50);
        }
    }
    
    public override void Skill() { }
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Green, 10));
        
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.HuoShan, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.HuoShan, 10));
    }
    
    public override void AddMonsterSourceStone()
    {
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Penetrate,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Division,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.ExtremeSpeed,10));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Explosion,10));
    }
    
    public override void Die()
    {
        GeneralDie();
        GetEx();
        CreateBloodEnergy();
        CreateEquip();
        CreateWeaponSourceStone();
        CreateProp();
    }
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,1),100));
    }

    void Update()
    {
        if(IsDead) return;
        base.Update();
        Skill1CurrentTime+=Time.deltaTime;
        Skill2CurrentTime+=Time.deltaTime;
        Skill3CurrentTime+=Time.deltaTime;
        if (Skill1CurrentTime > Skill1Time&&Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position) > 3)
        {
            Skill1CurrentTime = 0;
            isSkill1 = true;
        }
        if (Skill2CurrentTime > Skill2Time)
        {
            Skill2CurrentTime = 0;
            isSkill2 = true;
        }
        if (Skill3CurrentTime > Skill3Time&&Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position) < 3)
        {
            Skill3CurrentTime = 0;
            isSkill3 = true;
        }
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < size)
        {
            isAttack=true;
        }
        else
        {
            isAttack=false;
        }
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(true);
        }
    }
}
