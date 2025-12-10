using System.Collections;
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
    public void LvQuanShot()
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        // 原始方向
        Vector2 baseDir = (worldPos-GameController.S.gamePlayer.transform.position).normalized;

        // 两个偏移角度：+10° 和 -10°
        Vector2[] dirs =
        {
            Quaternion.AngleAxis( 10f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis(-10f, Vector3.forward) * baseDir
        };

        // 连发两颗
        foreach (Vector2 dir in dirs)
        {
            GameObject bullet = GameController.S.LvQuanQueue.Dequeue();
            bullet.transform.position = GameController.S.gamePlayer.transform.position;

            var attack = bullet.GetComponent<TwoNormalAttack>();
            attack.MoveDirection = dir;
            attack.MoveSpeed = 2f;
            bullet.SetActive(true);
        }
    }
    
    
    
    public void LanBaoShot()
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- GameController.S.gamePlayer.transform.position).normalized;
        GameObject bullet = GameController.S.FourNormalAttackQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.GetComponent<FourNormalAttack>().MoveDirection = direction;
        bullet.GetComponent<FourNormalAttack>().MoveSpeed = 7f;
        bullet.gameObject.SetActive(true);
    }
    
    public void HeiDongShot()
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- GameController.S.gamePlayer.transform.position).normalized;
        GameObject bullet = GameController.S.HeiDongQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.GetComponent<HeiDongPro>().MoveDirection = direction;
        bullet.GetComponent<HeiDongPro>().MoveSpeed = 2f;
        bullet.gameObject.SetActive(true);
    }
    
    public void DuShot()
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- GameController.S.gamePlayer.transform.position).normalized;
        GameObject bullet = GameController.S.DuQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.GetComponent<Du>().MoveDirection = direction;
        bullet.GetComponent<Du>().MoveSpeed = 7f;
        bullet.gameObject.SetActive(true);
    }
    
    public void PuTong3Shot()
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        // 原始方向
        Vector2 baseDir = (worldPos -GameController.S.gamePlayer.transform.position).normalized;

        // 两个偏移角度：+10° 和 -10°
        Vector2[] dirs =
        {
            Quaternion.AngleAxis( 5f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis( 0f, Vector3.forward) * baseDir,
            Quaternion.AngleAxis(-5f, Vector3.forward) * baseDir
        };

        // 连发两颗
        foreach (Vector2 dir in dirs)
        {
            GameObject bullet = GameController.S.PuTong3Queue.Dequeue();
            bullet.transform.position = GameController.S.gamePlayer.transform.position;

            var attack = bullet.GetComponent<PuTong3>();
            attack.MoveDirection = dir;
            attack.MoveSpeed = 7f;
            bullet.SetActive(true);
        }
        
    }
    
    public void LuoLeiShot()
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        GameObject bullet = GameController.S.LuoLeiQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
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
    public void PrimaryShot()
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- GameController.S.gamePlayer.transform.position).normalized;
        GameObject bullet = GameController.S.ThreeNormalAttackQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.gameObject.SetActive(true);
        bullet.GetComponent<ThreeNormalAttack>().MoveDirection = direction;
        bullet.GetComponent<ThreeNormalAttack>().MoveSpeed = 7f;
    }
    
    public void FireShot()
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- GameController.S.gamePlayer.transform.position).normalized;
        GameObject bullet = GameController.S.FireQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.GetComponent<FireNormalAttack>().MoveDirection = direction;
        bullet.GetComponent<FireNormalAttack>().MoveSpeed =7f;
        bullet.gameObject.SetActive(true);
    }
    
    public void XuKongShot()
    {
        Vector3 mouseScreen = Input.mousePosition;
        float depth = Mathf.Abs(Camera.main.transform.position.z - GameController.S.gamePlayer.transform.position.z);
        mouseScreen.z = depth; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        Vector2 direction = (worldPos- GameController.S.gamePlayer.transform.position).normalized;
        GameObject bullet = GameController.S.XuKongQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.GetComponent<XuKong>().MoveDirection = direction;
        bullet.GetComponent<XuKong>().MoveSpeed = 7f;
        bullet.gameObject.SetActive(true);
    }
    
}
