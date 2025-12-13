using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;

public class XieZi : MonsterBase
{
    public XieZi() : base(MonsterType.Boss, "XieZi", 1, 100, 1f, 10, 5, 10, 10, 0)
    {
    }
    
     public GameObject parent;
     public Transform attackTrans;
     public Transform skill1Trans;
     private float attackRange = 1.5f;
     public float skill1Time = 10;
     public float skill2Time = 10;
     public float currentSkill1Time = 0;
     public float currentSkill2Time = 0;


    public override void AddMonsterSourceStone()
    {
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,
            WeaponSourceStoneType.Penetrate, 2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,
            WeaponSourceStoneType.Division, 2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,
            WeaponSourceStoneType.ExtremeSpeed, 2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,
            WeaponSourceStoneType.Explosion, 2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,
            WeaponSourceStoneType.Scale, 2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,
            WeaponSourceStoneType.Duration, 2));
    }

    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Blue, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Blue, 10));
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
        int randomDelay = UnityEngine.Random.Range(0, 10);
        StartCoroutine(RandomDelayDie(randomDelay));
    }

    private IEnumerator RandomDelayDie(int delay)
    {
        for (int i = 0; i < delay; i++)
        {
            yield return null;
        }

        AudioController.S.PlaySnotDie();
        GeneralDie();
        GetEx();
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy, 1);
        CreateBloodEnergy();
        CreateEquip();
        CreateWeaponSourceStone();
        CreateProp();

        // gameObject.SetActive(false);
        // GameController.S.SnotMonsterQueue.Enqueue(this);
    }

    private void Start()
    {
        base.Start();
        size = 1.5f;
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
        if (e.Data.Name == "attack_skill1"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "skill1")
        {
            Debug.LogError(1111);
            float waveOffset = Random.Range(0, 30);
            int bulletCount = 10;
            float angleStep = 360f / bulletCount; 
            
            for (int i = 0; i < bulletCount; i++)
            {
                var xieZiSkill1 = GameController.S.XieZiSkill1Queue.Dequeue();
                float angle = i * angleStep + waveOffset;
                float angleRad = angle * Mathf.Deg2Rad;
                Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
                xieZiSkill1.transform.position = skill1Trans.position;
                xieZiSkill1.MoveDirection = direction;
                xieZiSkill1.Damage = Attack;
                xieZiSkill1.gameObject.SetActive(true);
            }
        }
        
        if (e.Data.Name == "attack_skill3"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "skill3")
        {
            if (Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 2)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,true);
            }
        }
    }
    
    public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,1),100));
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
        currentSkill1Time+=Time.deltaTime;
        currentSkill2Time+=Time.deltaTime;
        if (currentSkill1Time > skill1Time)
        {
            currentSkill1Time = 0;
            isSkill1 = true;
        }
        
        if (currentSkill2Time > skill2Time)
        {
            currentSkill2Time = 0;
            isSkill2 = true;
        }
        
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
