using System.Collections;
using System.Collections.Generic;
using Equip;
using UnityEngine;

public class XiNiuMonster : MonsterBase
{
    public XiNiuMonster() : base(MonsterType.Normal, "XiuNiuMonster", 1, 100, 0.5f, 10, 5, 10, 10, 0)
    {
    }
    public override void AddMonsterSourceStone()
    {
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Penetrate,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Division,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.ExtremeSpeed,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Explosion,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Scale,2));
        MonsterWeaponSourceStoneList.Add(new MonsterWeaponSource(WeaponSourceStoneQuality.White,WeaponSourceStoneType.Duration,2));
    }
    public override void AddMonsterEquip()
    {
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Ring,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Necklace,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloak,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Cloth,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Shoe,PlayerEquipConfig.EquipLevel.Green, 10));
        MonsterEquipList.Add(new MonsterEquip(PlayerEquipConfig.EquipType.Helmet,PlayerEquipConfig.EquipLevel.Green, 10));
    }
    public override void Skill()
    {
        // Implement the skill logic here
    }
    
    public override void Die()
    {
        
        //生成随机数
        int randomDelay = UnityEngine.Random.Range(0, 10);
        GameController.S.StartCoroutine(RandomDelayDie(randomDelay));
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
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy,1);
        CreateBloodEnergy();
        CreateEquip();
        CreateWeaponSourceStone();
        
        // gameObject.SetActive(false);
        // GameController.S.SnotMonsterQueue.Enqueue(this);
    }
    
    public override void Hurt(int damage)
    {
        base.Hurt(damage);
        if (!IsDead)
        {
            AudioController.S.PlaySnotHit();
        }
    }
    
    public void MonsterMove1()
    {
        float dis= Vector2.Distance(transform.position, GameController.S.gamePlayer.transform.position);
        if (dis < GameController.S.gamePlayer.size + size)
        {
            monsterAnimator.Play("attack1");
        }
        
        // 判断是否在播放任何动画（包括过渡）
        if(monsterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime == 0 && !monsterAnimator.IsInTransition(0))
        {
            monsterAnimator.Play("move");
            Vector3 direction = GameController.S.gamePlayer.transform.position - transform.position;
            GetComponent<Rigidbody2D>().velocity = direction.normalized * Speed; 

        }
    }
    
    private void Start()
    {
        size = 0.3f;
        AddMonsterEquip();
        AddMonsterSourceStone();
    }
    
    void Update()
    {
        if (IsDead) return;
        base.Update();
        
        if (!IsDead)
        {
            MonsterMove1();
            SpriteFlipX1(true);
        }
    }
}
