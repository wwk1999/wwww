using System;
using System.Collections;
using System.Collections.Generic;
using Prop.BaoShi;
using UnityEngine;

public class PropBase : MonoBehaviour
{
    public Rigidbody2D equipRb;
    [NonSerialized]public float speed = 12f; // 装备跟随的速度
    [NonSerialized]public bool isPickUp = false; // 是否被拾取
    [NonSerialized]private Coroutine floatEffectCoroutine; // 添加协程引用
    [NonSerialized]public PropTable propTables;

    public void OnEnable()
    {
        equipRb.velocity = new Vector2(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(3f, 5f));
        StartCoroutine(StopVelocityAfterDelay(equipRb, 0.75f));
    }
    
    public PropBase(PropTable propTable)
    {
        this.propTables = propTable;
    }
    
    private IEnumerator StopVelocityAfterDelay(Rigidbody2D rb, float delay)
    {
        yield return new WaitForSeconds(delay);
        if(rb == null)
            Debug.Log("rb为空");
        rb.velocity = Vector2.zero;
        //设置重力为0
        rb.gravityScale = 0;
        //开启协程通过transformer让装备上下浮动效果,lerp平滑过渡
        floatEffectCoroutine =StartCoroutine(FloatEffect());
        
    }
    
    private IEnumerator FloatEffect()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + new Vector3(0, 0.2f, 0);
        float duration = 0.8f; // 浮动持续时间

        while (true)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.PingPong(elapsedTime / duration, 1f);
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
    }
    
    private void Update()
    {
        var distance = Vector3.Distance(transform.position, QueueController.S.gamePlayer.transform.position);
        if (distance < 1.0f)
        {
            isPickUp = true;
        }
        if (isPickUp)
        {
            transform.position = Vector3.Lerp(transform.position, QueueController.S.gamePlayer.transform.position,
                Time.deltaTime * speed);
            if (floatEffectCoroutine != null)
            {
                StopCoroutine(floatEffectCoroutine);
                floatEffectCoroutine = null;
            }
        }

        if (distance < 0.2f)
        {
            //将这件装备的属性添加到数据库
            EquipIDData.S.SaveProp(propTables);
            StoreController.S.SaveStoreData();
            ObserverModuleManager.S.SendEvent(ConstKeys.ShowToast,propTables);
            GameController.S.PropBaseSet.Remove(this);
            //如果被拾取，销毁装备
            gameObject.SetActive(false);
            EnEquipQueue(propTables);
        }
    }


    public void EnEquipQueue(PropTable propTable)
    {
        switch (propTable.PropType)
        {
            case PropConfig.PropType.WeaponFragment:
                switch (propTable.Quality)
                {
                    case 1:
                        QueueController.S.WhiteWeaponFragmengQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        QueueController.S.GreenWeaponFragmengQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        QueueController.S.BlueWeaponFragmengQueue.Enqueue(gameObject);
                        break;
                    case 4:
                        QueueController.S.PurpleWeaponFragmengQueue.Enqueue(gameObject);
                        break;
                    case 5:
                        QueueController.S.OrangeWeaponFragmengQueue.Enqueue(gameObject);
                        break;
                    case 6:
                        QueueController.S.RedWeaponFragmengQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
            case PropConfig.PropType.ShenHuaCaiLiao:
                switch (propTable.Quality)
                {
                    case 1:
                        QueueController.S.FuMoZhiGuQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        QueueController.S.GoldBloodQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        QueueController.S.JuDaYaChiQueue.Enqueue(gameObject);
                        break;
                    case 4:
                        QueueController.S.ZuiEYanZhuQueue.Enqueue(gameObject);
                        break;
                }
                break;
            
            case PropConfig.PropType.ChiBang:
                switch (propTable.Quality)
                {
                    case 1:
                        QueueController.S.WhiteChiBangQueue.Enqueue(gameObject);
                        break;
                    case 2:
                        QueueController.S.GreenChiBangQueue.Enqueue(gameObject);
                        break;
                    case 3:
                        QueueController.S.BlueChiBangQueue.Enqueue(gameObject);
                        break;
                    case 4:
                        QueueController.S.PurpleChiBangQueue.Enqueue(gameObject);
                        break;
                    case 5:
                        QueueController.S.OrangeChiBangQueue.Enqueue(gameObject);
                        break;
                    case6:
                        QueueController.S.RedChiBangQueue.Enqueue(gameObject);
                        break;
                }
                break;
            case PropConfig.PropType.HH:
            case PropConfig.PropType.HA:
            case PropConfig.PropType.HC:
            case PropConfig.PropType.HD:
            case PropConfig.PropType.AA:
            case PropConfig.PropType.AC:
            case PropConfig.PropType.AD:
            case PropConfig.PropType.CC:
            case PropConfig.PropType.CD:
            case PropConfig.PropType.DD:
                QueueController.S.BaoShiQueue.Enqueue(this as BaoShi);
                break;
            
            

        }
    }

}
