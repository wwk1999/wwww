using System.Collections;
using UnityEditor;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    private float _attackSpeed;
    public BulletBase _bullet;

    public SpriteRenderer gunSpriteRender;
    //构造方法
    public GunBase(float attackSpeed)
    {
        this._attackSpeed = attackSpeed;
    }
    public float AttackSpeed
    {
        get { return _attackSpeed; }
        set { _attackSpeed = value; }
    }

    /// <summary>
    /// 第二个武器普通攻击
    /// </summary>
    /// <param name="scale"></param>
    /// <param name="division"></param>
    /// <param name="extremeSpeed"></param>
    /// <param name="duration"></param>
    public void LvQuanShot(Vector3 attackTrans)
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - attackTrans.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        // 原始方向
        Vector2 baseDir = (worldPos-attackTrans).normalized;

        // 两个偏移角度：+10° 和 -10°
        Vector2[] dirs =
        {
            Quaternion.AngleAxis( 0f, Vector3.forward) * baseDir
        };

        // 连发两颗
        foreach (Vector2 dir in dirs)
        {
            GameObject bullet = GameController.S.LvQuanQueue.Dequeue();
            bullet.transform.position = attackTrans;

            var attack = bullet.GetComponent<TwoNormalAttack>();
            attack.MoveDirection = dir;
            attack.MoveSpeed = 2f;
            bullet.SetActive(true);
        }
    }
    
    
    
    public void LanBaoShot(Vector3 attackTrans)
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - attackTrans.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- attackTrans).normalized;
        GameObject bullet = GameController.S.FourNormalAttackQueue.Dequeue();
        bullet.transform.position = attackTrans;
        bullet.GetComponent<FourNormalAttack>().MoveDirection = direction;
        bullet.GetComponent<FourNormalAttack>().MoveSpeed = 7f;
        bullet.gameObject.SetActive(true);
    }
    
    public void HeiDongShot(Vector3 attackTrans)
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - attackTrans.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- attackTrans).normalized;
        GameObject bullet = GameController.S.HeiDongQueue.Dequeue();
        bullet.transform.position = attackTrans;
        bullet.GetComponent<HeiDongPro>().MoveDirection = direction;
        bullet.GetComponent<HeiDongPro>().MoveSpeed = 2f;
        bullet.gameObject.SetActive(true);
    }
    
    public void DuShot(Vector3 attackTrans)
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - attackTrans.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- attackTrans).normalized;
        GameObject bullet = GameController.S.DuQueue.Dequeue();
        bullet.transform.position =attackTrans;
        bullet.GetComponent<Du>().MoveDirection = direction;
        bullet.GetComponent<Du>().MoveSpeed = 10f;
        bullet.gameObject.SetActive(true);
    }
    
    public void HeiAnBaoZhaShot(Vector3 attackTrans)
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - attackTrans.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- attackTrans).normalized;
        GameObject bullet = GameController.S.HeiAnBaoZhaQueue.Dequeue();
        bullet.transform.position =attackTrans;
        bullet.GetComponent<HeiAnBaoZha>().MoveDirection = direction;
        bullet.GetComponent<HeiAnBaoZha>().MoveSpeed = 10f;
        bullet.gameObject.SetActive(true);
    }

    public void JianQiShot(Vector3 attackTrans)
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - attackTrans.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- attackTrans).normalized;
        PlayerJianQi bullet = GameController.S.PlayerJianQiQueue.Dequeue();
        bullet.transform.position = attackTrans;
        bullet.MoveDirection = direction;
        bullet.MoveSpeed = 10f;
        bullet.gameObject.SetActive(true);
    }
    
    public void HuoFenLieShot(Vector3 attackTrans)
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - attackTrans.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- attackTrans).normalized;
        HuoFenLie bullet = GameController.S.HuoFenLieQueue.Dequeue();
        bullet.transform.position = attackTrans;
        bullet.MoveDirection = direction;
        bullet.MoveSpeed = 10f;
        bullet.gameObject.SetActive(true);
    }
    
    public void Ice7Shot(Vector3 attackTrans)
    {
        // 方法1：直接使用鼠标世界坐标（适用于正交相机）
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 保持Z轴与攻击点一致
        mouseWorldPos.z = attackTrans.z;
    
        // 基础方向
        Vector2 baseDir = (mouseWorldPos - attackTrans).normalized;
    
        // 子弹散射角度（对称分布）
        float[] scatterAngles = { -7f, -5f, -3f, 0f, 3f, 5f, 7f };
    
        // 连发七颗子弹
        foreach (float angle in scatterAngles)
        {
            Ice7Item bullet = GameController.S.Ice7Queue.Dequeue();
            bullet.transform.position = attackTrans;
            bullet.MoveDirection = Quaternion.AngleAxis(angle, Vector3.forward) * baseDir;
            bullet.MoveSpeed = 10f;
            bullet.gameObject.SetActive(true);
        }
    }
    
    
    public void Ice4BaoZhaShot(Vector3 attackTrans)
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - attackTrans.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- attackTrans).normalized;
        Ice4BaoZha bullet = GameController.S.Ice4BaoZhaQueue.Dequeue();
        bullet.transform.position = attackTrans;
        bullet.MoveDirection = direction;
        bullet.MoveSpeed = 10f;
        bullet.gameObject.SetActive(true);
    }
    
    public void PuTong3Shot(Vector3 attackTrans)
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - attackTrans.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        // 原始方向
        Vector2 baseDir = (worldPos -attackTrans).normalized;

        // 两个偏移角度：+10° 和 -10°
        Vector2[] dirs3 =
        {
            Quaternion.AngleAxis( 5f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 0f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis(-5f, Vector3.forward) * baseDir
        };
        
        Vector2[] dirs5 =
        {
            Quaternion.AngleAxis( 3f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 0f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis(-3f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis(-5f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis(-5f, Vector3.forward) * baseDir,
        };
        int bulletCount = 3;
        Vector2[] dirs = dirs3;
        if (PlayerData.S.puTong3HunQiLevel >= 5)
        {
            dirs = dirs5;
        }

        // 连发两颗
        foreach (Vector2 dir in dirs)
        {
            GameObject bullet = GameController.S.PuTong3Queue.Dequeue();
            bullet.transform.position = attackTrans;

            var attack = bullet.GetComponent<PuTong3>();
            attack.MoveDirection = dir;
            attack.MoveSpeed = 10f;
            bullet.SetActive(true);
        }
        
    }
    
    
    public void Huo7Shot(Vector3 attackTrans)
    {
        // 方法1：直接使用鼠标世界坐标（适用于正交相机）
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 保持Z轴与攻击点一致
        mouseWorldPos.z = attackTrans.z;
    
        // 基础方向
        Vector2 baseDir = (mouseWorldPos - attackTrans).normalized;
    
        // 子弹散射角度（对称分布）
        float[] scatterAngles = { -7f, -5f, -3f, 0f, 3f, 5f, 7f };
    
        // 连发七颗子弹
        foreach (float angle in scatterAngles)
        {
            Huo7Item bullet = GameController.S.Huo7Queue.Dequeue();
            bullet.transform.position = attackTrans;
            bullet.MoveDirection = Quaternion.AngleAxis(angle, Vector3.forward) * baseDir;
            bullet.MoveSpeed = 10f;
            bullet.gameObject.SetActive(true);
        }
    }
    
    
    
    public void LuoLeiShot(Vector3 attackTrans)
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - attackTrans.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        GameObject bullet = GameController.S.LuoLeiQueue.Dequeue();
        bullet.transform.position = attackTrans;
        bullet.GetComponent<LuoLei>().position = worldPos;
        bullet.gameObject.SetActive(true);
    }


    /// <summary>
    /// 原始武器普通攻击
    /// </summary>
    /// <param name="penetrate"></param>
    /// <param name="division"></param>
    /// <param name="extremeSpeed"></param>
    /// <param name="explosion"></param>
    public void PrimaryShot(Vector3 attackTrans)
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - attackTrans.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        // 原始方向
        Vector2 baseDir = (worldPos -attackTrans).normalized;

        int bulletCount = 1;
        if (PlayerData.S.primaryHunQiLevel >= 3)
        {
            bulletCount++;
        }
        if (PlayerData.S.primaryHunQiLevel >= 5)
        {
            bulletCount++;
        }

        // 两个偏移角度：+10° 和 -10°
        Vector2[] dirs1 =
        {
            Quaternion.AngleAxis( 0f, Vector3.forward) * baseDir,
        };
        Vector2[] dirs2 =
        {
            Quaternion.AngleAxis( -3f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 3f, Vector3.forward) * baseDir,

        };
        Vector2[] dirs3 =
        {
            Quaternion.AngleAxis( 0f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( -5f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 5f, Vector3.forward) * baseDir,
        };
        Vector2[] dirs=null;
        switch (bulletCount)
        {
            case 1:
                dirs=dirs1;
                break;
            case 2:
                dirs=dirs2;
                break;
            case 3:
                dirs=dirs3;
                break;
        }
        // 连发两颗
        foreach (Vector2 dir in dirs)
        {
            GameObject bullet = GameController.S.PrimaryQueue.Dequeue();
            bullet.transform.position = attackTrans;

            var attack = bullet.GetComponent<Primary>();
            attack.MoveDirection = dir;
            attack.MoveSpeed = 10f;
            bullet.SetActive(true);
        }
    }
    
    
    
    
    
    
    
    
    
    public void FireShot(Vector3 attackTrans)
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - attackTrans.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- attackTrans).normalized;
        GameObject bullet = GameController.S.FireQueue.Dequeue();
        bullet.transform.position = attackTrans;
        bullet.GetComponent<FireNormalAttack>().MoveDirection = direction;
        bullet.GetComponent<FireNormalAttack>().MoveSpeed =10f;
        bullet.gameObject.SetActive(true);
    }
    
    public void XuKongShot(Vector3 attackTrans)
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - attackTrans.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- attackTrans).normalized;
        GameObject bullet = GameController.S.XuKongQueue.Dequeue();
        bullet.transform.position = attackTrans;
        bullet.GetComponent<XuKong>().MoveDirection = direction;
        bullet.GetComponent<XuKong>().MoveSpeed = 7f;
        bullet.gameObject.SetActive(true);
    }
    
}
