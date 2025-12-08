using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;

public class ShaMoElite : MonsterBase
{
    public ShaMoElite() : base(MonsterType.Normal, "ShaMoElite", 1, 100, 0.3f, 10, 5, 10, 10, 0)
    {
    }
    public GameObject parent;
    public Transform skillTrans1;
    public Transform skillTrans2;
    public Transform skillTrans3;
    public Transform attackTrans;

    private float SkillTime = 5;
    private float CurrentSkillTime = 0;
    
    public override void AddMonsterSourceStone()
    {
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,
            WeaponSourceStoneType.Penetrate, 0));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,
            WeaponSourceStoneType.Division, 0));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,
            WeaponSourceStoneType.ExtremeSpeed, 0));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,
            WeaponSourceStoneType.Explosion, 0));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,
            WeaponSourceStoneType.Scale, 0));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,
            WeaponSourceStoneType.Duration, 0));
    }

    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Blue, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Blue, 1));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Blue, 1));
    }

    public override void Hurt(int damage,bool isCrit)
    {
        base.Hurt(damage,isCrit);
        if (!IsDead)
        {
            AudioController.S.PlayBatHit();
        }
    }
    
    public override void Skill()
    {
        // Implement the skill logic here
    }

    public override void Die()
    {

        //生成随机数
        float randomDelay = UnityEngine.Random.Range(0, 20) * 0.02f;
        Invoke(nameof(RandomDelayDie),randomDelay);
    }

    private void RandomDelayDie()
    {
        AudioController.S.PlaySnotDie();
        GeneralDie();
        GetEx();
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy, 2);
        CreateEquip();
    }
    
    private void Start()
    {
        base.Start();
        size = 1f;
        isBeatback = false;
        AddMonsterEquip();
        AddMonsterSourceStone();
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;

    } private void OnDestroy()
    {
        monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
    }
    
    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "damage"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "attack1")
        {
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < 0.8f)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,false);
            }
        }
    }
    
    
     public void MonsterMove1()
    {
        Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "move")
        {
            GetComponent<Rigidbody2D>().velocity = direction.normalized * Speed; 
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = direction.normalized * 0; 
        }
    }
    
    public void SpriteFlipX1(bool isRight)
    {
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name != "move")
        {
            return;
        }
        float dis=Vector2.Distance(transform.position,GameController.S.gamePlayer.transform.position);
        if(dis<0.2f)
        {
            //如果距离小于0.2f，则不翻转
            return;
        }
        //翻转精灵
        if (isRight)
        {
            if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
            {
                parent.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                parent.transform.localScale = new Vector3(-1, 1, 1);
            }
        }else
        {
            if (GameController.S.gamePlayer.transform.position.x > transform.position.x)
            {
                parent.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                parent.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        
    }


    void Update()
    {
        if (IsDead) return;
        base.Update();
        CurrentSkillTime += Time.deltaTime;
        if (CurrentSkillTime >= SkillTime&&(Vector2.Distance(GameController.S.gamePlayer.transform.position,skillTrans1.position)<0.6f||Vector2.Distance(GameController.S.gamePlayer.transform.position,skillTrans2.position)<0.6f||Vector2.Distance(GameController.S.gamePlayer.transform.position,skillTrans3.position)<0.6f))
        {
            CurrentSkillTime = 0;
            isSkill1=true;
        }
        else if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < 0.8f)
        {
            isAttack=true;
        }
        else
        {
            isAttack=false;
        }
        
        if (!IsDead)
        {
            MonsterMove1();
            SpriteFlipX1(false);
        }
    }

    public void CheckSkill()
    {
        Invoke(nameof(CheckSkill1),1.1f);
        Invoke(nameof(CheckSkill2),1.3f);
        Invoke(nameof(CheckSkill3),1.5f);
    }

    public void CheckSkill1()
    {
        if (Vector2.Distance(GameController.S.gamePlayer.transform.position, skillTrans1.position) < 0.6f)
        {
            GameController.S.gamePlayer.PlayerHurt(Attack,false);
        }
    }
    
    public void CheckSkill2()
    {
        if (Vector2.Distance(GameController.S.gamePlayer.transform.position, skillTrans2.position) < 0.6f)
        {
            GameController.S.gamePlayer.PlayerHurt(Attack,false);
        }
    }
    
    public void CheckSkill3()
    {
        if (Vector2.Distance(GameController.S.gamePlayer.transform.position, skillTrans3.position) < 0.6f)
        {
            GameController.S.gamePlayer.PlayerHurt(Attack,false);
        }
    }
}
