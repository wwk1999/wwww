using System;
using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;
public class TreeManBoss : MonsterBase
{
    public TreeManBoss() : base(MonsterType.Boss, "TreeManBoss", 1, 10000, 0.7f, 80, 5, 10, 10, 0) { }
   [NonSerialized]public float FireSkillTime = 15f;
   [NonSerialized]public float FireSkillCurrentTime = 0f;
   [NonSerialized]public float DashSkillTime = 8f;
   [NonSerialized]public float DashSkillCurrentTime = 0f;
   [NonSerialized]public float GroundFissureSkillTime = 12f;
   [NonSerialized]public float GroundFissureSkillCurrentTime = 0f;
   [NonSerialized]public Vector2 Dashdirection = Vector2.zero;
   [NonSerialized]public Vector2 GroundFissurepos = Vector2.zero;
   [NonSerialized]public Vector2 BaoZhapos = Vector2.zero;
   

   public Transform AttackTrans;
   //[NonSerialized] public bool HaveCircleAttack = false;

    public  void Awake()
    {
        CurrentHp = MaxHp;
        size = 1.5f;
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
        monsterSkeletonAnimation.AnimationState.Complete += Complete;
       
       MonsterSpineName.AttackName = "attack";
       MonsterSpineName.HitName = "hit";
       MonsterSpineName.MoveName = "walk";
       MonsterSpineName.DieName = "die_02";
       MonsterSpineName.AppearName = "Exit";
       MonsterSpineName.Skill1Name = "skill_01";
       MonsterSpineName.Skill2Name = "skill_02";
       MonsterSpineName.Skill3Name = "skill_03";
    }

    public void Complete(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "Exit")
        {
            IsSkill=false;
        }

        if (trackEntry.Animation.Name == "skill_03"||trackEntry.Animation.Name == "skill_04")
        {
            IsSkill=false;
        }
        
        if (trackEntry.Animation.Name == "skill_04")
        {
            IsDash=false;
        }

        if (isSkill1)
        {
            IsSkill=true;
            isSkill1=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_01", false);
            GroundFissurepos=GameController.S.gamePlayer.transform.position;
            GameController.S.CreateCircleAttack(GroundFissurepos,1f);
        }else if (isSkill2)
        {
            IsSkill=true;
            isSkill2=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_03", false);
            Skill2();
        }else if (isSkill3)
        {
            IsSkill=true;
            isSkill3=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill_04", false);
            IsDash = true;
            Dashdirection=(GameController.S.gamePlayer.transform.position-transform.position).normalized;
            if (Dashdirection.x>0)
            {
                parent.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                parent.transform.localScale = new Vector3(-1, 1, 1);
            }
            GameController.S.CreateSqrtAttack(transform.position,Dashdirection);
        } else if(isAttack)
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.AttackName, false);
        }
        else
        {
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.MoveName, false);
        }
    }
    
    public void Zhuang(float speed, Vector2 dir, float time)
    {
        StartCoroutine(ZhuangRoutine(speed, dir, time));
    }

    private IEnumerator ZhuangRoutine(float speed, Vector2 dir, float time)
    {
        Vector2 oldVelocity = rigidbody2D.velocity;

        Vector2 v = dir.normalized * speed;
        rigidbody2D.velocity = v;

        float elapsed = 0f;
        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            rigidbody2D.velocity = v;
            yield return null;
        }

        rigidbody2D.velocity = oldVelocity;
    }

    public void Skill2()
    {
        Vector2 center = GameController.S.gamePlayer.transform.position;   // (0,0)
        float radius = 12f;

        for (int i = 0; i < 15; i++)
        {
            // 在单位圆内随机一个点，再乘以半径 -> 半径为 12 的圆内
            Vector2 randomInCircle = UnityEngine.Random.insideUnitCircle * radius;
            Vector3 pos = new Vector3(center.x + randomInCircle.x, center.y + randomInCircle.y, 0f);
            GameController.S.CreateCircleAttack(pos,0.75f);
            var treeManSkill = GameController.S.TreeManSkillQueue.Dequeue();
            treeManSkill.transform.position = pos;
            treeManSkill.damage = Attack;
            treeManSkill.gameObject.SetActive(true);
        }
    }
    

    public void Start()
    {
        size = 1.5f;
        AddMonsterEquip();
        AddMonsterProp();
    }
    
    private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        // 根据事件名称处理逻辑
        if (e.Data.Name == "chong")
        {
            Zhuang(8,Dashdirection,1.5f);
        }
        else if (e.Data.Name == "tiao")
        {
            Jump(0.6f, GroundFissurepos);
        }else if (e.Data.Name == "baozha")
        {
            GameController.S.CreateDiLie(new Vector2(transform.position.x,transform.position.y-0.5f),Attack);
        }
    }

    public void Jump(float time, Vector2 target)
    {
        StartCoroutine(JumpRoutine(time, target));
    }

    private IEnumerator JumpRoutine(float time, Vector2 target)
    {
        Vector2 startPos = rigidbody2D.position;
        Vector2 endPos   = target;

        float elapsed = 0f;
        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);

            // 线性插值移动刚体
            Vector2 newPos = Vector2.Lerp(startPos, endPos, t);
            rigidbody2D.MovePosition(newPos);

            yield return null;
        }

        // 确保最后到达精确位置
        rigidbody2D.MovePosition(endPos);
        IsSkill=false;
    }

   
    public override void Die()
    {
        GeneralDie();
        GetEx();
        CreateBloodEnergy();
        CreateEquip();
        FightBGController.S.PlaySuccessAnim();
        CreateProp();

        GameController.S.StartCoroutine(DelayChuanSongMen());
    }

    IEnumerator DelayChuanSongMen()
    {
        yield return new WaitForSeconds(1f);
        var chuansongmen = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChuanSongMen"));
        chuansongmen.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,2),50));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,2),50));
    }
    

    private void Update()
    {
        if (IsDead) return;
        DashSkillCurrentTime+=Time.deltaTime;
        FireSkillCurrentTime+=Time.deltaTime;
        GroundFissureSkillCurrentTime += Time.deltaTime;
        if (GroundFissureSkillCurrentTime > GroundFissureSkillTime&&Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position) > 3)
        {
            GroundFissureSkillCurrentTime = 0;
            isSkill1 = true;
        }
        if (FireSkillCurrentTime > FireSkillTime)
        {
            FireSkillCurrentTime = 0;
            isSkill2 = true;
        }
        if (DashSkillCurrentTime > DashSkillTime)
        {
            DashSkillCurrentTime = 0;
            isSkill3 = true;
        }

        if ( IsDash&& Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < size)
        {
            IsDash = false;
            GameController.S.gamePlayer.PlayerHurt(Attack,true);
        }
        if (Vector2.Distance(AttackTrans.position, GameController.S.gamePlayer.transform.position) < size&&!IsSkill)
        {
            isAttack = true;
            if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name != "attack")
            {
                monsterSkeletonAnimation.AnimationState.SetAnimation(0, "attack", false);
            }
        }
        else
        {
            isAttack = false;
        }

        BossMove();
        SpriteFlipX(true);
    }

    public void BossMove()
    {
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "walk" ||
            monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "hit")
        {
            Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
            rigidbody2D.velocity = direction.normalized * Speed; 
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
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
        
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.TreeMan, 5));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.TreeMan, 5));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.TreeMan, 5));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.TreeMan, 5));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.TreeMan, 5));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.TreeMan, 5));
    }
}
