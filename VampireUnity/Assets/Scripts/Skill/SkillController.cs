using System;
using System.Collections;
using Coffee.UIExtensions;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SkillController : XSingleton<SkillController>
{

    [NonSerialized]public bool IsDash=false;
    [NonSerialized]public int ShadowCount = 5;
    [NonSerialized]public int CurrentDashCount = 0;
    //技能相关
    [NonSerialized]public GameObject IceExTrigger;
    [NonSerialized]public float IceBallSpeed = 5f;
    [NonSerialized]public GameObject IceBallGameObject;
    //技能冷却时间
    public float IceExplosiontime => GetIceSkill3Time();
    public float IceBalltime => GetIceSkill2Time();
    public float IceSkill1Time => GetIceSkill1Time();
    public float IceSkill4Time => GetIceSkill4Time();
    public float IceSkill5Time => GetIceSkill5Time();
    
    public float HuoSkill1Time => GetHuoSkill1Time();
    public float HuoSkill2Time => GetHuoSkill2Time();
    public float HuoSkill3Time => GetHuoSkill3Time();
    public float HuoSkill4Time => GetHuoSkill4Time();
    public float HuoSkill5Time => GetHuoSkill5Time();

    
    
    public float DianQuantime =>GetDianSkill1Time();
    public float DianSkill2Time => GetDianSkill2Time();
    public float DianSkill3Time => GetDianSkill3Time();
    public float DianSkill4Time => GetDianSkill4Time();
    public float DianSkill5Time => GetDianSkill5Time();

    
    public float HeiAnSkill1Time => GetHeiAnSkill1Time();
    public float HeiAnSkill2Time => GetHeiAnSkill2Time();
    public float HeiAnSkill3Time => GetHeiAnSkill3Time();
    public float HeiAnSkill4Time => GetHeiAnSkill4Time();
    public float HeiAnSkill5Time => GetHeiAnSkill5Time();


    public float GetIceSkill1Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Ice1];
        value*=(1.0f-SkillJiaDian.S.Ice1_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillCd);
        return value;
    }
    
    public float GetIceSkill4Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Ice4];
        value*=(1.0f-SkillJiaDian.S.Ice4_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillCd);
        return value;
    }
    
    public float GetIceSkill5Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Ice5];
        value*=(1.0f-SkillJiaDian.S.Ice5_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillCd);
        return value;
    }

    
    public float GetIceSkill2Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Ice2];
        value*=(1.0f-SkillJiaDian.S.Ice2_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillCd);
        return value;
    }
    
    public float GetIceSkill3Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Ice3];
        value*=(1.0f-SkillJiaDian.S.Ice3_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.IceSkillCd);
        return value;
    }
    
    
    public float GetHuoSkill1Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Huo1];
        value*=(1.0f-SkillJiaDian.S.Huo1_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.HuoSkillCd);
        return value;
    }
    
    public float GetHuoSkill2Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Huo2];
        value*=(1.0f-SkillJiaDian.S.Huo2_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.HuoSkillCd);
        return value;
    }
    
    public float GetHuoSkill3Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Huo3];
        value*=(1.0f-SkillJiaDian.S.Huo3_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.HuoSkillCd);
        return value;
    }
    
    public float GetHuoSkill4Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Huo4];
        value*=(1.0f-SkillJiaDian.S.Huo4_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.HuoSkillCd);
        return value;
    }

    
    
    public float GetHuoSkill5Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Huo5];
        value*=(1.0f-SkillJiaDian.S.Huo5_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.HuoSkillCd);
        return value;
    }

    
    
    
    public float GetHeiAnSkill1Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.HeiAn1];
        value*=(1.0f-SkillJiaDian.S.HeiAn1_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.HeiAnSkillCd);

        return value;
    }
    
    public float GetHeiAnSkill2Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.HeiAn2];
        value*=(1.0f-SkillJiaDian.S.HeiAn2_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.HeiAnSkillCd);

        return value;
    }
    
    public float GetHeiAnSkill3Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.HeiAn3];
        value*=(1.0f-SkillJiaDian.S.HeiAn3_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.HeiAnSkillCd);

        return value;
    }
    
    public float GetHeiAnSkill4Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.HeiAn4];
        value*=(1.0f-SkillJiaDian.S.HeiAn4_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.HeiAnSkillCd);

        return value;
    }

    
    
    public float GetHeiAnSkill5Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.HeiAn5];
        value*=(1.0f-SkillJiaDian.S.HeiAn5_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.HeiAnSkillCd);

        return value;
    }

    
    
    public float GetDianSkill1Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Dian1];
        value*=(1.0f-SkillJiaDian.S.Dian1_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.DianSkillCd);

        return value;
    }
    
    public float GetDianSkill2Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Dian2];
        value*=(1.0f-SkillJiaDian.S.Dian2_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.DianSkillCd);
        return value;
    }
    
    public float GetDianSkill3Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Dian3];
        value*=(1.0f-SkillJiaDian.S.Dian3_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.DianSkillCd);
        return value;
    }
    
    
    public float GetDianSkill4Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Dian4];
        value*=(1.0f-SkillJiaDian.S.Dian4_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.DianSkillCd);
        return value;
    }
    
    
    public float GetDianSkill5Time()
    {
        float value = SkillConfig.SkillBaseTime[SkillType.Dian5];
        value*=(1.0f-SkillJiaDian.S.Dian5_1*5/100f);
        value *= (1.0f - GlobalPlayerAttribute.FinalChongWuAttribute.DianSkillCd);
        return value;
    }
    
    
    
    
    
    
    [NonSerialized]public float IceArrowCoolingtime = 0;
    [NonSerialized]public float IceExplosionCoolingtime = 0f;
    [NonSerialized]public float IceBallCoolingtime = 0f;
    [NonSerialized]public float IceSkill1Coolingtime = 0;
    [NonSerialized]public float IceSkill4Coolingtime = 0;
    [NonSerialized]public float IceSkill5Coolingtime = 0;


    
    [NonSerialized]public float HuoSkill1Coolingtime = 0;
    [NonSerialized]public float HuoSkill2Coolingtime = 0f;
    [NonSerialized]public float HuoSkill3Coolingtime = 0f;
    [NonSerialized]public float HuoSkill4Coolingtime = 0f;
    [NonSerialized]public float HuoSkill5Coolingtime = 0f;

    
    
    [NonSerialized]public float DianSkill1Coolingtime = 0;
    [NonSerialized]public float DianSkill2Coolingtime = 0f;
    [NonSerialized]public float DianSkill3Coolingtime = 0f;
    [NonSerialized]public float DianSkill4Coolingtime = 0f;
    [NonSerialized]public float DianSkill5Coolingtime = 0f;


    
    
    [NonSerialized]public float HeiAnSkill1Coolingtime = 0;
    [NonSerialized]public float HeiAnSkill2Coolingtime = 0f;
    [NonSerialized]public float HeiAnSkill3Coolingtime = 0f;
    [NonSerialized]public float HeiAnSkill4Coolingtime = 0f;
    [NonSerialized]public float HeiAnSkill5Coolingtime = 0f;


    
    
    public float IceBallDuration =>GetIceBallDuration();
    public float HuoSkill2Duration =>GetHuoSkill2Duration();
    public float DianSkill2Duration =>GetDianSkill2Duration();
    public float HeiAnSkill2Duration =>GetHeiAnSkill2Duration();
    
    public float Dashtime => GetDashCd();



    public float HuoYuanSuDamage => GetHuoDamage();
    public float DianYuanSuDamage => GetDianDamage();
    public float HeiAnYuanSuDamage => GetHeiAnDamage();
    public float IceYuanSuDamage => GetIceDamage();//小数


    public bool IsHuoSkill2=false;
    public bool IsDianSkill2=false;
    public bool IsHeiAnSkill2=false;


    public float GetIceBallDuration()
    {
        float value = 5f;
        value*=(1.0f);
        return value;
    }
    
    public float GetHuoSkill2Duration()
    {
        float value = 5f;
        value*=(1.0f);
        return value;
    }
    
    public float GetHeiAnSkill2Duration()
    {
        float value = 5f;
        value*=(1.0f);
        return value;
    }
    
    public float GetDianSkill2Duration()
    {
        float value = 5f;
        value*=(1.0f);
        return value;
    }
    
    

    public float GetHuoDamage()
    {
        float value = GlobalPlayerAttribute.HuoYuanSuBase;
        if (IsHuoSkill2)
        {
            value += (0.2f+SkillJiaDian.S.Huo2_2*2/100f);
        }
        return value;
    }
    
    
    public float GetDianDamage()
    {
        float value = GlobalPlayerAttribute.DianYuanSuBase;
        if (IsDianSkill2)
        {
            value +=(0.2f+SkillJiaDian.S.Dian2_2*2/100f);
        }
        return value;
    }
    
    public float GetHeiAnDamage()
    {
        float value =GlobalPlayerAttribute.HeiAnYuanSuBase;
        if (IsHeiAnSkill2)
        {
            value += (0.2f+SkillJiaDian.S.HeiAn2_2*2/100f);
        }
        return value;
    }
    
    public float GetIceDamage()
    {
        float value =GlobalPlayerAttribute.IceYuanSuBase;
        return value;
    }
    
    public float GetDianQuanTime()
    {
       

        return (10f * (1 ));
    }
    public float DashCoolingtime = 0;
   

    [NonSerialized]public float DianQuanCoolingtime = 0f;
    
    public SkillType LMB
    {
        get => SkillJiaDian.S.LMB;
        set => SkillJiaDian.S.LMB = value;
    }
    public SkillType RMB
    {
        get => SkillJiaDian.S.RMB;
        set => SkillJiaDian.S.RMB = value;
    }
    public SkillType Alpha1
    {
        get => SkillJiaDian.S.Alpha1;
        set => SkillJiaDian.S.Alpha1 = value;
    }
    public SkillType Alpha2
    {
        get => SkillJiaDian.S.Alpha2;
        set => SkillJiaDian.S.Alpha2 = value;
    }
    public SkillType Alpha3
    {
        get => SkillJiaDian.S.Alpha3;
        set => SkillJiaDian.S.Alpha3 = value;
    }
    
    public SkillType Alpha4
    {
        get => SkillJiaDian.S.Alpha4;
        set => SkillJiaDian.S.Alpha4 = value;
    }
    
    public SkillType Alpha5
    {
        get => SkillJiaDian.S.Alpha5;
        set => SkillJiaDian.S.Alpha5 = value;
    }


    public float GetDashCd()
    {
        float cd = (10f * (1));
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DashCd))
        {
            cd *= 0.7f;
        }

        return cd;
    }
    

    IEnumerator HuoSkill3(int count,float redis,float time)
    {
        
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - QueueController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);

        if (HuoSkill3Coolingtime >= HuoSkill3Time)
        {
            HuoSkill3Coolingtime = 0;
            for (int i = 0; i < count; i++)
            {
                float offectX = Random.Range(-0.5f, 0.5f);
                float offectY = Random.Range(-0.5f, 0.5f);
                Vector3 dir = new Vector2(offectX, offectY);
                Vector2 pos = worldPos + dir * redis;
                var dianquan = QueueController.S.HuoSkill3Queue.Dequeue();
                dianquan.gameObject.SetActive(true);
                dianquan.transform.position = pos;
                dianquan._renderer.sortingOrder = 10001 + i;
                yield return new WaitForSeconds(time);
            }
        }
    }

    IEnumerator HuoSkill5(int count, float redis, float time)
    {

        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - QueueController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        HuoSkill5Coolingtime = 0;
        for (int i = 0; i < count; i++)
        {
            float offectX = Random.Range(-0.5f, 0.5f);
            float offectY = Random.Range(-0.5f, 0.5f);
            Vector3 dir = new Vector2(offectX, offectY);
            Vector2 pos = worldPos + dir * redis;
            var dianquan = QueueController.S.HuoSkill5Queue.Dequeue();
            dianquan.gameObject.SetActive(true);
            dianquan.transform.position = pos;
            dianquan._renderer.sortingOrder = 10001 + i;
            yield return new WaitForSeconds(time);
        }
    }


    IEnumerator IceSkill4(int count, float redis, float time)
    {

        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - QueueController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        for (int i = 0; i < count; i++)
        {
            float offectX = Random.Range(-0.5f, 0.5f);
            float offectY = Random.Range(-0.5f, 0.5f);
            Vector3 dir = new Vector2(offectX, offectY);
            Vector2 pos = worldPos + dir * redis;
            var dianquan = QueueController.S.IceSkill4Queue.Dequeue();
            dianquan.gameObject.SetActive(true);
            dianquan.transform.position = pos;
            dianquan.render.sortingOrder = 10001 + i;
            yield return new WaitForSeconds(time);
        }

    }


    public void DianSkill3()
    {
        if (DianSkill3Coolingtime < DianSkill3Time)
        {
            return;
        }

        DianSkill3Coolingtime = 0;
        float waveOffset = Random.Range(0,30);
        int bulletCount = 12+SkillJiaDian.S.Dian3_2*2;
        float angleStep = 360f / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            var xieZiSkill1 = QueueController.S.DianSkill3Queue.Dequeue();
            float angle = i * angleStep + waveOffset;
            float angleRad = angle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
            xieZiSkill1.transform.position = QueueController.S.gamePlayer.transform.position;
            xieZiSkill1.MoveDirection = direction;
            xieZiSkill1.MoveSpeed = 10f;
            xieZiSkill1.gameObject.SetActive(true);
        }
    }
    
    
    public void IceSkill5()
    {
        if (IceSkill5Coolingtime < IceSkill5Time)
        {
            return;
        }

        IceSkill5Coolingtime = 0;
        float waveOffset = Random.Range(0,30);
        int bulletCount = 12+2*SkillJiaDian.S.Ice5_2;
        float angleStep = 360f / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            var xieZiSkill1 = QueueController.S.IceSkill5Queue.Dequeue();
            float angle = i * angleStep + waveOffset;
            float angleRad = angle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
            xieZiSkill1.transform.position = QueueController.S.gamePlayer.transform.position;
            xieZiSkill1.MoveDirection = direction;
            xieZiSkill1.MoveSpeed = 10f;
            xieZiSkill1.gameObject.SetActive(true);
        }
    }
    
    public void IceSkill1()
    {
        if (IceSkill1Coolingtime < IceSkill1Time)
        {
            return;
        }
        IceSkill1Coolingtime = 0;
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - QueueController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        var dianquan= QueueController.S.IceSkill1Queue.Dequeue();
        dianquan.gameObject.SetActive(true);
        dianquan.transform.position = worldPos;
        dianquan.transform.localScale = new Vector3(dianquan.transform.localScale.x*(1.0f+SkillJiaDian.S.Ice1_2*5/100f), dianquan.transform.localScale.y*(1.0f+SkillJiaDian.S.Ice1_2*5/100f), 1f);

    }


    public void HeiAnSkill4(int count)
    {
        
        if (HeiAnSkill4Coolingtime < HeiAnSkill4Time)
        {
            return;
        }

        HeiAnSkill4Coolingtime = 0;
        switch (count)
        {
            case 4:
                QueueController.S.gamePlayer.HeiAnSkill4_4.gameObject.SetActive(true);
                Invoke(nameof(HideHeiAnSkill4_4),5f);
                break;
            case 5:
                QueueController.S.gamePlayer.HeiAnSkill4_5.gameObject.SetActive(true);
                Invoke(nameof(HideHeiAnSkill4_5),5f);
                break;
            case 6:
                QueueController.S.gamePlayer.HeiAnSkill4_6.gameObject.SetActive(true);
                Invoke(nameof(HideHeiAnSkill4_6),5f);
                break;
            case 7:
                QueueController.S.gamePlayer.HeiAnSkill4_7.gameObject.SetActive(true);
                Invoke(nameof(HideHeiAnSkill4_7),5f);
                break;
            case 8:
                QueueController.S.gamePlayer.HeiAnSkill4_8.gameObject.SetActive(true);
                Invoke(nameof(HideHeiAnSkill4_8),5f);
                break;
            case 9:
                QueueController.S.gamePlayer.HeiAnSkill4_9.gameObject.SetActive(true);
                Invoke(nameof(HideHeiAnSkill4_9),5f);
                break;
        }
    }

    public void HideHeiAnSkill4_4()
    {
        QueueController.S.gamePlayer.HeiAnSkill4_4.gameObject.SetActive(false);
    }
    
    public void HideHeiAnSkill4_5()
    {
        QueueController.S.gamePlayer.HeiAnSkill4_5.gameObject.SetActive(false);
    }
    
    public void HideHeiAnSkill4_6()
    {
        QueueController.S.gamePlayer.HeiAnSkill4_6.gameObject.SetActive(false);
    }
    
    public void HideHeiAnSkill4_7()
    {
        QueueController.S.gamePlayer.HeiAnSkill4_7.gameObject.SetActive(false);
    }
    
    public void HideHeiAnSkill4_8()
    {
        QueueController.S.gamePlayer.HeiAnSkill4_8.gameObject.SetActive(false);
    }
    
    public void HideHeiAnSkill4_9()
    {
        QueueController.S.gamePlayer.HeiAnSkill4_9.gameObject.SetActive(false);
    }
    
    
    public void DianSkill4()
    {
        if (DianSkill4Coolingtime < DianSkill4Time)
        {
            return;
        }

        DianSkill4Coolingtime = 0;
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - QueueController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        var dianquan= QueueController.S.DianSkill4Queue.Dequeue();
        dianquan.gameObject.SetActive(true);
        dianquan.transform.position = worldPos;
        dianquan.transform.localPosition =
            new Vector3(dianquan.transform.localPosition.x * (1.0f + SkillJiaDian.S.Dian4_2 * 5 / 100f),
                dianquan.transform.localPosition.y * (1.0f + SkillJiaDian.S.Dian4_2 * 5 / 100f), 1f);
    }

    public void HeiAnSkill5(int count)
    {
        if (HeiAnSkill5Coolingtime < HeiAnSkill5Time)
        {
            return;
        }

        HeiAnSkill5Coolingtime = 0;
        for (int i = 0; i < count; i++)
        {
            var heianSkill5=QueueController.S.HeiAnSkill5Queue.Dequeue();
            heianSkill5.transform.position = GameController.S.GetRandomMonsterPos();
            heianSkill5.gameObject.SetActive(true);
        }
    }
    
    public void DianSkill5()
    {
        if (DianSkill5Coolingtime < DianSkill5Time)
        {
            return;
        }

        DianSkill5Coolingtime = 0;
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - QueueController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        var dianquan= QueueController.S.DianSkill5Queue.Dequeue();
        dianquan.gameObject.SetActive(true);
        dianquan.transform.position = worldPos;
        dianquan.transform.localPosition =
            new Vector3(dianquan.transform.localPosition.x * (1.0f + SkillJiaDian.S.Dian5_2 * 5 / 100f),
                dianquan.transform.localPosition.y * (1.0f + SkillJiaDian.S.Dian5_2 * 5 / 100f), 1f);
    }
    
    public void HuoSkill4()
    {
        if (HuoSkill4Coolingtime < HuoSkill4Time)
        {
            return;
        }

        HuoSkill4Coolingtime = 0;
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - QueueController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        var dianquan= QueueController.S.HuoSkill4Queue.Dequeue();
        dianquan.gameObject.SetActive(true);
        dianquan.transform.position = worldPos;
        dianquan.transform.localPosition =
            new Vector3(dianquan.transform.localPosition.x * (1.0f + SkillJiaDian.S.Huo4_2 * 5 / 100f),
                dianquan.transform.localPosition.y * (1.0f + SkillJiaDian.S.Huo4_2 * 5 / 100f), 1f);
    }

    public void HeiAnSkill1()
    {
        if (HeiAnSkill1Coolingtime < HeiAnSkill1Time)
        {
            return;
        }

        HeiAnSkill1Coolingtime = 0;
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - QueueController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        var dianquan= QueueController.S.HeiAnSkill1Queue.Dequeue();
        dianquan.gameObject.SetActive(true);
        dianquan.transform.position = worldPos;
        dianquan.transform.localPosition =
            new Vector3(dianquan.transform.localPosition.x * (1.0f + SkillJiaDian.S.HeiAn1_2 * 5 / 100f),
                dianquan.transform.localPosition.y * (1.0f + SkillJiaDian.S.HeiAn1_2 * 5 / 100f), 1f);
    }

    public void HuoSkill2()
    {
        if (HuoSkill2Coolingtime < HuoSkill2Time)
        {
            return;
        }

        HuoSkill2Coolingtime = 0;
        QueueController.S.gamePlayer.HuoSkill2.gameObject.SetActive(true);
        IsHuoSkill2 = true;
        Invoke(nameof(StopHuoSkill2),HuoSkill2Duration);
    }
    
    public void DianSkill2()
    {
        if (DianSkill2Coolingtime < DianSkill2Time)
        {
            return;
        }

        DianSkill2Coolingtime = 0;
        QueueController.S.gamePlayer.DianSkill2.gameObject.SetActive(true);
        IsDianSkill2 = true;
        Invoke(nameof(StopDianSkill2),DianSkill2Duration);
    }
    
    public void HeiAnSkill2()
    {
        if (HeiAnSkill2Coolingtime < HeiAnSkill2Time)
        {
            return;
        }
        HeiAnSkill2Coolingtime = 0;
        QueueController.S.gamePlayer.HeiAnSkill2.gameObject.SetActive(true);
        IsHeiAnSkill2 = true;
        Invoke(nameof(StopHeiAnSkill2),HeiAnSkill2Duration);
    }

    public void StopHuoSkill2()
    {
        QueueController.S.gamePlayer.HuoSkill2.gameObject.SetActive(false);
        IsHuoSkill2 = false;
    }
    
    public void StopDianSkill2()
    {
        QueueController.S.gamePlayer.DianSkill2.gameObject.SetActive(false);
        IsDianSkill2 = false;
    }
    
    public void StopHeiAnSkill2()
    {
        QueueController.S.gamePlayer.HeiAnSkill2.gameObject.SetActive(false);
        IsHeiAnSkill2 = false;
    }
    
    public void HeiAnSkill3()
    {
        if (HeiAnSkill3Coolingtime < HeiAnSkill3Time)
        {
            return;
        }
        HeiAnSkill3Coolingtime = 0;
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - QueueController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        var dianquan= QueueController.S.HeiAnSkill3Queue.Dequeue();
        dianquan.gameObject.SetActive(true);
        dianquan.transform.position = worldPos;
        dianquan.transform.localPosition =
            new Vector3(dianquan.transform.localPosition.x * (1.0f + SkillJiaDian.S.HeiAn3_2 * 5 / 100f),
                dianquan.transform.localPosition.y * (1.0f + SkillJiaDian.S.HeiAn3_2 * 5 / 100f), 1f);
    }
    
    public void HuoSkill1()
    {
        if (HuoSkill1Coolingtime < HuoSkill1Time)
        {
            return;
        }
        HuoSkill1Coolingtime = 0;
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - QueueController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        // 原始方向
        Vector2 baseDir = (worldPos -QueueController.S.gamePlayer.transform.position).normalized;

        int bulletCount = 3+SkillJiaDian.S.Huo1_2;
        // 两个偏移角度：+10° 和 -10°
        Vector2[] dirs3 =
        {
            Quaternion.AngleAxis( 0f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -3f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 3f, Vector3.forward) * baseDir,
        };
        Vector2[] dirs4 =
        {
            Quaternion.AngleAxis( 2f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -2f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 4f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -4f, Vector3.forward) * baseDir,
        };
        
        Vector2[] dirs5 =
        {
            Quaternion.AngleAxis( 0f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -3f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 3f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -5f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 5f, Vector3.forward) * baseDir,
        };
        Vector2[] dirs6 =
        {
            Quaternion.AngleAxis( -2f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -4f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 6f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 2f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 4f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 6f, Vector3.forward) * baseDir,
        };
        Vector2[] dirs7 =
        {
            Quaternion.AngleAxis( 0f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -2f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 2f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -6f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 6f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 4f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -4f, Vector3.forward) * baseDir,
        };
        Vector2[] dirs8 =
        {
            Quaternion.AngleAxis( 0f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -2f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 2f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -4f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 4f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -6f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 6f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -8f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 8f, Vector3.forward) * baseDir,
        };
        Vector2[] dirs = null;
        switch (bulletCount)
        {
            case 3:
                dirs=dirs3;
                break;
            case 4:
                dirs=dirs4;
                break;
            case 5:
                dirs=dirs5;
                break;
            case 6:
                dirs=dirs6;
                break;
            case 7:
                dirs=dirs7;
                break;
            case 8:
                dirs=dirs8;
                break;
        }
        foreach (Vector2 dir in dirs)
        {
            HuoSkill1 bullet = QueueController.S.HuoSkill1Queue.Dequeue();
            bullet.transform.position = QueueController.S.gamePlayer.transform.position;
            
            bullet.MoveDirection = dir;
            bullet.MoveSpeed = 10f;
            bullet.gameObject.SetActive(true);
        }
    }
    
    

    //普通攻击发射子弹
    public void ShotBulletInvoke(Vector3 attackTrans)
    {
        switch (PlayerData.S.playerWeaponType)
        {
            case WeaponType.Primary:
                QueueController.S.gamePlayer.currentGun.PrimaryShot(attackTrans);
                break;
            case WeaponType.LanBao:
                QueueController.S.gamePlayer.currentGun.LanBaoShot(attackTrans);
                break;
            case WeaponType.Fire:
                QueueController.S.gamePlayer.currentGun.FireShot(attackTrans);
                break;
            case WeaponType.XuKong:
                QueueController.S.gamePlayer.currentGun.XuKongShot(attackTrans);
                break;
            case WeaponType.LvQuan:
                QueueController.S.gamePlayer.currentGun.LvQuanShot(attackTrans);
                break;
            case WeaponType.HeiDong:
                QueueController.S.gamePlayer.currentGun.HeiDongShot(attackTrans);
                break;
            case WeaponType.HuoBaoZha:
                QueueController.S.gamePlayer.currentGun.HuoBaoZhaShot(attackTrans);
                break;
            case WeaponType.LuoLei:
                QueueController.S.gamePlayer.currentGun.LuoLeiShot(attackTrans);
                break;
            case WeaponType.PuTong3:
                QueueController.S.gamePlayer.currentGun.PuTong3Shot(attackTrans);
                break;
            case WeaponType.JianQi:
                QueueController.S.gamePlayer.currentGun.JianQiShot(attackTrans);
                break;
            case WeaponType.HeiAnBaoZha:
                QueueController.S.gamePlayer.currentGun.HeiAnBaoZhaShot(attackTrans);
                break;
            case WeaponType.Huo7:
                QueueController.S.gamePlayer.currentGun.Huo7Shot(attackTrans);
                break;
            case WeaponType.HuoFenLie:
                QueueController.S.gamePlayer.currentGun.HuoFenLieShot(attackTrans);
                break;
            case WeaponType.Ice4BaoZha:
                QueueController.S.gamePlayer.currentGun.Ice4BaoZhaShot(attackTrans);
                break;
            case WeaponType.Ice7:
                QueueController.S.gamePlayer.currentGun.Ice7Shot(attackTrans);
                break;
            case WeaponType.IcePen:
                QueueController.S.gamePlayer.currentGun.IcePenShot(attackTrans);
                break;
            case WeaponType.DianLuoLei5:
                QueueController.S.gamePlayer.currentGun.DianLuoLeiShot(attackTrans);
                break;
            case WeaponType.DianJiSu:
                QueueController.S.gamePlayer.currentGun.DianJiSuShot(attackTrans);
                break;
            case WeaponType.HeiAnHuiXuan:
                QueueController.S.gamePlayer.currentGun.HeiAnHuiXuanShot(attackTrans);
                break;
            case WeaponType.HeiAnQuXian:
                QueueController.S.gamePlayer.currentGun.HuoQuXianShot(attackTrans);
                break;
            case WeaponType.HuoDiPen:
                QueueController.S.gamePlayer.currentGun.HuoDiPenShot(attackTrans);
                break;
            case WeaponType.PrimaryDian:
                QueueController.S.gamePlayer.currentGun.PrimaryDianShot(attackTrans);
                break;
            case WeaponType.PrimaryHeiAn:
                QueueController.S.gamePlayer.currentGun.PrimaryHeiAnShot(attackTrans);
                break;
            case WeaponType.PrimaryHuo:
                QueueController.S.gamePlayer.currentGun.PrimaryHuoShot(attackTrans);
                break;
            case WeaponType.DianBaoZha:
                QueueController.S.gamePlayer.currentGun.DianBaoZhaShot(attackTrans);
                break;
            case WeaponType.IceBaoZha:
                QueueController.S.gamePlayer.currentGun.IceBaoZhaShot(attackTrans);
                break;
        }
    }
    

    
    //释放技能
    public void ExcuteSkill(SkillType skillType)
    {
        switch (skillType)
        {
            case SkillType.Dash:
                if (DashCoolingtime >= Dashtime)
                {
                    DashCoolingtime = 0;
                    IsDash = true;
                }
                break;
            case SkillType.Normal:
                break;
            case SkillType.Dian1:
                if (DianQuanCoolingtime>=DianQuantime)
                {
                    Vector3 mouseScreen = Input.mousePosition;
                    float depth = Mathf.Abs(Camera.main.transform.position.z - QueueController.S.gamePlayer.transform.position.z);
                    mouseScreen.z = depth; 
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
                    IceArrowCoolingtime = 0;
                    DianQuanCoolingtime = 0;
                    var dianquan= QueueController.S.DianQuanQueue.Dequeue();
                    dianquan.gameObject.SetActive(true);
                    dianquan.transform.localScale=new Vector3(dianquan.transform.localScale.x*(1+SkillJiaDian.S.Dian1_2*5/100f),dianquan.transform.localScale.y*(1+SkillJiaDian.S.Dian1_2*5/100f),1);
                    dianquan.transform.position = worldPos;
                }
                break;
            case SkillType.Ice2:
                if (IceBallCoolingtime >= IceBalltime)
                {
                    AudioController.S.PlayIceBall();
                    IceBallCoolingtime=0;
                    int count1 = 4 + SkillJiaDian.S.Ice2_2;
                    StartIceBallSkill(count1);
                }
                break;
            case SkillType.Ice3:
                if (IceExplosionCoolingtime >= IceExplosiontime)
                {
                    AudioController.S.PlayIceEx();
                    IceExplosionCoolingtime=0;
                    var iceex = QueueController.S.IceExQueue.Dequeue();
                    iceex.transform.localScale = new Vector3(iceex.transform.localScale.x*(1.0f+SkillJiaDian.S.Ice3_2*5/100f), iceex.transform.localScale.y*(1.0f+SkillJiaDian.S.Ice3_2*5/100f), 1f);
                    iceex.transform.position = QueueController.S.gamePlayer.transform.position;
                    iceex.gameObject.SetActive(true);
                }
                break;
            
            case SkillType.Ice1:
                IceSkill1();
                break;
            
            case SkillType.Ice4:
                if (IceSkill4Coolingtime < IceSkill4Time)
                {
                    return;
                }

                IceSkill4Coolingtime = 0;
                StartCoroutine(IceSkill4(4+SkillJiaDian.S.Ice4_2,1f,0.3f));
                break;
            case SkillType.Ice5:
                IceSkill5();
                break;
            case SkillType.Dian2:
                DianSkill2();
                break;
            case SkillType.Dian3:
                DianSkill3();
                break;
            case SkillType.Dian4:
                DianSkill4();
                break;
            case SkillType.Dian5:
                DianSkill5();
                break;
            case SkillType.Huo1:
                HuoSkill1();
                break;
            case SkillType.Huo2:
                HuoSkill2();
                break;
            case SkillType.Huo3:
                int count = 5;
                StartCoroutine(HuoSkill3(count,1.3f,0.2f));
                break;
            case SkillType.Huo4:
                HuoSkill4();
                break;
            case SkillType.Huo5:
                if (HuoSkill5Coolingtime < HuoSkill5Time)
                {
                    return;
                }
                StartCoroutine(HuoSkill5(4+SkillJiaDian.S.Huo5_2,1.5f,0.3f));
                break;
            case SkillType.HeiAn1:
                HeiAnSkill1();
                break;
            case SkillType.HeiAn2:
                HeiAnSkill2();
                break;
            case SkillType.HeiAn3:
                HeiAnSkill3();
                break;
            case SkillType.HeiAn4:
                HeiAnSkill4(4+SkillJiaDian.S.HeiAn4_2);
                break;
            case SkillType.HeiAn5:
                HeiAnSkill5(4+SkillJiaDian.S.HeiAn5_2);
                break;
        }
    }


    IEnumerator Skill3Bian3()
    {
        for (int i = 0; i < 3; i++)
        {
            var iceex = QueueController.S.IceExQueue.Dequeue();
            iceex.transform.localScale = new Vector3(iceex.transform.localScale.x*(1.0f+SkillJiaDian.S.Ice3_2*5/100f), iceex.transform.localScale.y*(1.0f+SkillJiaDian.S.Ice3_2*5/100f), 1f);
            iceex.transform.position = QueueController.S.gamePlayer.transform.position;
            iceex.damageCount = 0.7f;
            iceex.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
    void Update()
    {
        //技能冷却时间
        IceArrowCoolingtime+= Time.deltaTime;
        IceExplosionCoolingtime+=Time.deltaTime;
        IceBallCoolingtime+= Time.deltaTime;
        DashCoolingtime+=Time.deltaTime;
        DianQuanCoolingtime+= Time.deltaTime;
        
        IceSkill1Coolingtime+= Time.deltaTime;
        IceSkill4Coolingtime+= Time.deltaTime;
        IceSkill5Coolingtime+= Time.deltaTime;

        DianSkill3Coolingtime+= Time.deltaTime;
        DianSkill2Coolingtime+= Time.deltaTime;
        DianSkill4Coolingtime+= Time.deltaTime;
        DianSkill5Coolingtime+= Time.deltaTime;

        
        HuoSkill1Coolingtime+= Time.deltaTime;
        HuoSkill2Coolingtime+= Time.deltaTime;
        HuoSkill3Coolingtime+= Time.deltaTime;
        HuoSkill4Coolingtime+= Time.deltaTime;
        HuoSkill5Coolingtime+= Time.deltaTime;

        
        HeiAnSkill1Coolingtime+= Time.deltaTime;
        HeiAnSkill2Coolingtime+= Time.deltaTime;
        HeiAnSkill3Coolingtime+= Time.deltaTime;
        HeiAnSkill4Coolingtime+= Time.deltaTime;
        HeiAnSkill5Coolingtime+= Time.deltaTime;

        //自动
        if (DianQuanCoolingtime >= DianQuantime && SkillJiaDian.S.Dian1 >= 1&&SkillJiaDian.S.Dian1Auto)
        {
            ExcuteSkill(SkillType.Dian1);
        }
        
        if (IceBallCoolingtime >= IceBalltime && SkillJiaDian.S.Ice2 >= 1&&SkillJiaDian.S.Ice2Auto)
        {
            ExcuteSkill(SkillType.Ice2);
        }
        
        if (IceExplosionCoolingtime >= IceExplosiontime && SkillJiaDian.S.Ice3 >= 1&&SkillJiaDian.S.Ice3Auto)
        {
            ExcuteSkill(SkillType.Ice3);
        }
        
        
        //技能CD
        FightBGController.S.IceExYellowCd.GetComponent<Image>().fillAmount= IceExplosionCoolingtime / IceExplosiontime;
        FightBGController.S.iceExButton.GetComponent<Button>().image.fillAmount= IceExplosionCoolingtime / IceExplosiontime;
        FightBGController.S.IceArrowYellowCd.GetComponent<Image>().fillAmount= DianQuanCoolingtime / DianQuantime;
        FightBGController.S.iceArrowButton.GetComponent<Button>().image.fillAmount= DianQuanCoolingtime / DianQuantime;
        FightBGController.S.IceBallYellowCd.GetComponent<Image>().fillAmount= IceBallCoolingtime / IceBalltime;
        FightBGController.S.iceBallButton.GetComponent<Button>().image.fillAmount= IceBallCoolingtime / IceBalltime;


        //长按左键
        if (Input.GetMouseButton(0))
        {
            ExcuteSkill(LMB);
        }
        
        
        if (Input.GetMouseButton(1))
        {
            ExcuteSkill(RMB);
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            ExcuteSkill(Alpha1);
        }
        
        if (Input.GetKey(KeyCode.Alpha2))
        {
            ExcuteSkill(Alpha2);
        }
        
        if (Input.GetKey(KeyCode.Alpha3))
        {
            ExcuteSkill(Alpha3);
        }
        
        if (Input.GetKey(KeyCode.Alpha4))
        {
            ExcuteSkill(Alpha4);
        }
        
        if (Input.GetKey(KeyCode.Alpha5))
        {
            ExcuteSkill(Alpha5);
        }
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            QueueController.S.gamePlayer.transform.Find("Shield").gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            QueueController.S.gamePlayer.transform.Find("Rage").gameObject.SetActive(true);
        }
        
        if (IsDash )
        {
            float dashSpeed = 20;
            if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.DashRange))
            {
                dashSpeed *=1.3f;
            }
            GlobalPlayerAttribute.PlayerMoveSpeed = dashSpeed;
            GameObject playerShadow = Instantiate(Resources.Load("Prefabs/Skill/DashShadowObject"),QueueController.S.transform).GameObject().transform.Find("DashShadow").gameObject;
            playerShadow.gameObject.SetActive(true);
            playerShadow.transform.localPosition = new Vector3(QueueController.S.gamePlayer.transform.Find("Image/parent/IceMage").position.x-0.15f, QueueController.S.gamePlayer.transform.Find("Image/parent/IceMage").position.y+0.62f,QueueController.S.gamePlayer.transform.Find("Image/parent/IceMage").position.z);
            playerShadow.GetComponent<DashShadow>().StartA = 120+CurrentDashCount*10;
            CurrentDashCount++;
            if (CurrentDashCount > ShadowCount)
            {
                CurrentDashCount = 0;
                IsDash = false;
                GlobalPlayerAttribute.PlayerMoveSpeed = 3;
            }
        }
    }

    public void StartIceBallSkill(int num)
    {
        switch (num)
        {
            case 4:
                QueueController.S.gamePlayer.IceBall4.SetActive(true);
                break;
            case 5:
                QueueController.S.gamePlayer.IceBall5.SetActive(true);
                break;
            case 6:
                QueueController.S.gamePlayer.IceBall6.SetActive(true);
                break;
            case 7:
                QueueController.S.gamePlayer.IceBall7.SetActive(true);
                break;
            case 8:
                QueueController.S.gamePlayer.IceBall8.SetActive(true);
                break;
            case 9:
                QueueController.S.gamePlayer.IceBall9.SetActive(true);
                break;
        }
    }
}
