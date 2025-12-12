using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;

public class ShaXiYi : MonsterBase
{
    public ShaXiYi() : base(MonsterType.Elite, "ShaXiYi", 1, 100, 0.3f, 10, 5, 10, 10, 0)
    {
    }
    public GameObject parent;
    public Transform attackTrans;
    private float attackRange = 0.7f;
    
    private float skill1Time = 30f;
    private float currentSkill1Time = 0f;
    public float hideTime = 0; 

    
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

   public override void Hurt(float damage,bool isCrit,DamageFrom damageFrom)
    {
        base.Hurt(damage,isCrit,damageFrom);
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
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy, 1);
        CreateEquip();
        CreateProp();
    }
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,1),100));
    }
    
    private void Start()
    {
        base.Start();
        size = 0.5f;
        isBeatback = false;
        AddMonsterEquip();
        AddMonsterSourceStone();
        AddMonsterProp();

        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
    }

    private void OnDestroy()
    {
        monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
    }

    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "attack_attack1"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "attack1")
        {
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < attackRange)
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
        if(dis<0.05f)
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
        hideTime-=Time.deltaTime;
        currentSkill1Time+=Time.deltaTime;
        if (hideTime > 0)
        {
            var skeleton = monsterSkeletonAnimation.Skeleton;
            skeleton.SetSkin("skin_yinshen_hou");   // 确认名字无误
            skeleton.SetSlotsToSetupPose();         // 或 skeleton.SetToSetupPose();
            monsterSkeletonAnimation.AnimationState.Apply(skeleton); // 重新应用当前动画
            collider2D.tag = "Bullet";
        }
        else
        {
            var skeleton = monsterSkeletonAnimation.Skeleton;
            skeleton.SetSkin("skin_yinshen_qian");
            skeleton.SetSlotsToSetupPose();
            monsterSkeletonAnimation.AnimationState.Apply(skeleton);
            collider2D.tag = "Monster";
        }

        if (currentSkill1Time > skill1Time)
        {
            currentSkill1Time = 0;
            isSkill1=true;
        }
        base.Update();
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < attackRange)
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
            SpriteFlipX1(true);
        }
    }
}
