using System.Collections;
using System.Collections.Generic;
using Equip;
using UnityEngine;

public class StoneBoss : MonsterBase
{
   public StoneBoss() : base(MonsterTypeByName.ChaiLangRen2)
    {
    }
   

   public override void Hurt(float damage,bool isCrit,DamageFrom damageFrom,YuanSuType yuanSuType)
    {
        base.Hurt(damage,isCrit,damageFrom,yuanSuType);
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
        //CreateBloodEnergy();
        CreateEquip();
        CreateProp();

        // gameObject.SetActive(false);
        // GameController.S.SnotMonsterQueue.Enqueue(this);
    }

   
    private void Start()
    {
        size = 1.5f;
        
       

    }


    void Update()
    {
        if (IsDead) return;
        base.Update();
        if (!IsDead)
        {
            MonsterMove();
            SpriteFlipX(true);
        }
    }
}
