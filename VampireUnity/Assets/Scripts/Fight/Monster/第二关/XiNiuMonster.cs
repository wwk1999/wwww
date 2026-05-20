using System.Collections;
using System.Collections.Generic;
using Equip;
using UnityEngine;

public class XiNiuMonster : MonsterBase
{
    public XiNiuMonster() : base(MonsterTypeByName.ChaiLangRen2)
    {
    }
   
    
    public override void Skill()
    {
        // Implement the skill logic here
    }
    
    public override void Die()
    {
        //生成随机延迟（0-10帧，转换为秒）
        float randomDelay = UnityEngine.Random.Range(0, 10) * 0.02f; // 假设60FPS，每帧约0.02秒
        Invoke(nameof(DoRandomDelayDie), randomDelay);
    }
    
    private void DoRandomDelayDie()
    {
        AudioController.S.PlaySnotDie();
        GeneralDie();
        GetEx();
        ObserverModuleManager.S.SendEvent(ConstKeys.BossEnergy,1);
        //CreateBloodEnergy();
        CreateEquip();
        
        // gameObject.SetActive(false);
        // QueueController.S.SnotMonsterQueue.Enqueue(this);
    }
    
    public override void Hurt(float damage,bool isCrit,DamageFrom damageFrom,YuanSuType yuanSuType)
    {
        base.Hurt(damage,isCrit,damageFrom,yuanSuType);
        if (!IsDead)
        {
            AudioController.S.PlayBatHit();
        }
    }
    
    public void MonsterMove1()
    {
        float dis= Vector2.Distance(transform.position, QueueController.S.gamePlayer.transform.position);
        if (!isHit)
        {
            if (dis < QueueController.S.gamePlayer.size + size)
            {
                isMove = false;
            }
            else
            {
                isMove = true;
            }
        }
        
        // 判断是否在播放任何动画（包括过渡）
        if(isMove)
        {
            Vector3 direction = QueueController.S.gamePlayer.transform.position - transform.position;
            GetComponent<Rigidbody2D>().velocity = direction.normalized * Speed; 
        }
        else
        {
            Vector3 direction = QueueController.S.gamePlayer.transform.position - transform.position;
            GetComponent<Rigidbody2D>().velocity = direction.normalized * 0; 
        }
    }
    
    private void Start()
    {
        size = 0.3f;
        
        
        // 确保 isMove 初始化为 true（基类已初始化，这里只是确保）
        isMove = true;
        
        // OnStateExit 是 Unity 自动调用的回调方法，不需要手动注册
        // 只要脚本挂载在有 Animator 的 GameObject 上，Unity 就会自动调用它
    }
    
    void Update()
    {
        if (IsDead) return;
        base.Update();
        
        if (!IsDead)
        {
            MonsterMove1();
        }
    }
}
