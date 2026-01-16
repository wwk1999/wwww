using System.Collections;
using System.Collections.Generic;
using Equip;
using Spine;
using Spine.Unity;
using UnityEngine;

public class XueRenBoss : MonsterBase
{
    public XueRenBoss() : base(MonsterType.Boss, "XueRenBoss", 1, 400000, 1.3f, 2500, 600, 1000, 100, 0)
    {
    }
    
    public Transform attackTrans;
    private float skill1Time = 10;
    private float skill2Time = 5;
    private float skill3Time = 8;
    private float currentSkill1Time = 0;
    private float currentSkill2Time = 0;
    private float currentSkill3Time = 0;

    public GameObject skill2;
    public SkeletonAnimation skill2ske;
    public Collider2D Skill2Collider2D;
    public GameObject skill2parent;
    
    public  void Awake()
    {
        base.Awake();
        MonsterSpineName.AttackName = "attack1";
        MonsterSpineName.HitName = "injured";
        MonsterSpineName.MoveName = "move";
        MonsterSpineName.DieName = "fail";
        monsterSkeletonAnimation.AnimationState.Event += OnSpineEvent;
        monsterSkeletonAnimation.AnimationState.Complete += Complete;
        skill2ske.AnimationState.Event += Skill2OnSpineEvent;
        skill2ske.AnimationState.Complete += Skill2Complete;
    }

    public void ShowSkill2()
    {
        skill2.SetActive(true);
        var dir=(GameController.S.gamePlayer.transform.position-transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        skill2parent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        skill2parent.transform.localScale=parent.transform.localScale;
        skill2ske.AnimationState.SetAnimation(0, "animation", false);
        skill2ske.timeScale = 1.5f;
    }

    public void Skill2Complete(TrackEntry trackEntry)
    {
        skill2.gameObject.SetActive(false);
    }
    
     public void Complete(TrackEntry trackEntry)
    {
        monsterSkeletonAnimation.timeScale = 1f;
        if (trackEntry.Animation.Name == "chuchang"||trackEntry.Animation.Name == "skill1"||trackEntry.Animation.Name == "skill2"||trackEntry.Animation.Name == "skill3")
        {
            IsSkill=false;
        }
        
        if (isSkill1)
        {
            IsSkill=true;
            isSkill1 = false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill1", false);
            monsterSkeletonAnimation.timeScale = 2.5f;
        }else if (isSkill2)
        {
            IsSkill=true;
            isSkill2=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill2", false);
            monsterSkeletonAnimation.timeScale = 2f;
            Invoke(nameof(ShowSkill2),1f);
        }
        else if(isSkill3)
        {
            IsSkill=true;
            isSkill3=false;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, "skill3", false);
            monsterSkeletonAnimation.timeScale = 2f;
            Invoke(nameof(Dash),1.8f);
            Invoke(nameof(ExitDash),2.5f);
        }
        else if(isAttack)
        {
            monsterSkeletonAnimation.timeScale = 2f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.AttackName, false);
        }
        else
        {
            monsterSkeletonAnimation.timeScale = 1.5f;
            monsterSkeletonAnimation.AnimationState.SetAnimation(0, MonsterSpineName.MoveName, false);
        }
    }

    public void Dash()
    {
        IsDash = true;
        Speed = 8;
    }

    public void ExitDash()
    {
        IsDash = false;
        Speed = 1.3f;
    }

    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Purple1, 20));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Purple1, 20));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Purple1, 20));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Purple1, 20));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Purple1, 20));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Purple1, 20));
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

    public void Skill2Collider()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        Skill2Collider2D.OverlapCollider(filter, results);
    
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Player"))
            {
               GameController.S.gamePlayer.PlayerHurt(Attack,true);
            }
        }
    }

    public void Skill2OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "damage")
        {
            Skill2Collider();
        }
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
        if (monsterSkeletonAnimation.AnimationState.GetCurrent(0).Animation.Name == "move"||IsDash)
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
