using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using UnityEngine;

public class XueRenBoss : MonsterBase
{
    public XueRenBoss() : base(MonsterType.Boss, "XueRenBoss", 1, 1000000, 1.2f, 1000, 300, 10, 10, 0)
    {
    }
    
    public Transform attackTrans;
    private float skill1Time = 10;
    private float skill2Time = 120;
    private float skill3Time = 80;
    private float currentSkill1Time = 0;
    private float currentSkill2Time = 0;
    private float currentSkill3Time = 0;
    
    public  void Awake()
    {
        base.Awake();
        MonsterSpineName.AttackName = "attack1";
        MonsterSpineName.HitName = "injured";
        MonsterSpineName.MoveName = "move";
        MonsterSpineName.DieName = "fail";
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
        monsterSkeletonAnimation.AnimationState.Complete += Complete;
    }
    
    
     public void Complete(TrackEntry trackEntry)
    {
        monsterSkeletonAnimation.timeScale = 1f;
        if (trackEntry.Animation.Name == "skill2")
        {
            collider2D.tag = "Bullet"; 
            var pos = GameController.S.gamePlayer.transform.position;
            GameController.S.CreateCircleAttack(pos,1);
            return;
        }
        if (trackEntry.Animation.Name == "chuchang"||trackEntry.Animation.Name == "skill1"||trackEntry.Animation.Name == "skill2"||trackEntry.Animation.Name == "skill3")
        {
            IsSkill=false;
        }
        
        if (isSkill1)
        {
            IsSkill=true;
            isSkill1=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill1", false);
        }else if (isSkill2)
        {
            IsSkill=true;
            isSkill2=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill2", false);
        }
        else if(isSkill3)
        {
            IsSkill=true;
            isSkill3=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill3", false);
        }
        else if(isAttack)
        {
            monsterSkeletonAnimation.timeScale = 1.5f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.AttackName, false);
        }
        else
        {
            monsterSkeletonAnimation.timeScale = 1.5f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.MoveName, false);
        }
    }

    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Purple, 20));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Purple, 20));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Purple, 20));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Purple, 20));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Purple, 20));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Purple, 20));
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
        CreateProp();
        FightBGController.S.PlaySuccessAnim();
        GameController.S.StartCoroutine(DelayChuanSongMen());
    }
    IEnumerator DelayChuanSongMen()
    {
        yield return new WaitForSeconds(1f);
        var chuansongmen = Instantiate(Resources.Load<GameObject>("Prefabs/Tool/ChuanSongMen"));
        chuansongmen.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    
     private void Start()
    {
        base.Start();
        size = 1.2f;
        AddMonsterEquip();
        AddMonsterProp();
    }
    
    private void OnDestroy()
    {
        monsterSkeletonAnimation.AnimationState.Event -= OnSpineEvent;
    }

    public void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "damage"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "attack1")
        {
            if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < size||Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 1.5f)
            {
                GameController.S.gamePlayer.PlayerHurt(Attack,true);
            }
        }
        
        if (e.Data.Name == "damage"&&monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "skill1")
        {
            var xuerenbossskill1 = GameController.S.XueRenBossSkill1Queue.Dequeue();
            xuerenbossskill1.Damage = Attack;
            xuerenbossskill1.transform.position=transform.position;
            xuerenbossskill1.gameObject.SetActive(true);
        }
       
    }
    
    
     public override void AddMonsterProp()
    {
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.WeaponFragment,4),10));
        MonsterPropList.Add(new MonsterProp(new PropItem(PropConfig.PropType.ChiBang,4),10));

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
        currentSkill3Time+=Time.deltaTime;
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

        if (currentSkill3Time > skill3Time)
        {
            currentSkill3Time = 0;
            isSkill3 = true;
        }
        
        if (Vector2.Distance(attackTrans.position, GameController.S.gamePlayer.transform.position) < size||Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position) < 1.5f)
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
}
