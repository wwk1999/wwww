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
        // 原始方向
        Vector2 baseDir = (GameController.S.nearMonsterPosition -GameController.S.gamePlayer.transform.position).normalized;

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
        Vector2 direction = (GameController.S.nearMonsterPosition- GameController.S.gamePlayer.transform.position).normalized;
        GameObject bullet = GameController.S.FourNormalAttackQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.GetComponent<FourNormalAttack>().MoveDirection = direction;
        bullet.GetComponent<FourNormalAttack>().MoveSpeed = 7f;
        bullet.gameObject.SetActive(true);
    }
    
    public void HeiDongShot()
    {
        Vector2 direction = (GameController.S.nearMonsterPosition- GameController.S.gamePlayer.transform.position).normalized;
        GameObject bullet = GameController.S.HeiDongQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.GetComponent<HeiDongPro>().MoveDirection = direction;
        bullet.GetComponent<HeiDongPro>().MoveSpeed = 2f;
        bullet.gameObject.SetActive(true);
    }
    
    public void DuShot()
    {
        Vector2 direction = (GameController.S.nearMonsterPosition- GameController.S.gamePlayer.transform.position).normalized;
        GameObject bullet = GameController.S.DuQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.GetComponent<Du>().MoveDirection = direction;
        bullet.GetComponent<Du>().MoveSpeed = 7f;
        bullet.gameObject.SetActive(true);
    }
    
    public void LuoLeiShot()
    {
        GameObject bullet = GameController.S.LuoLeiQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.GetComponent<LuoLei>().position = GameController.S.nearMonsterPosition;
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
        Vector2 direction = (GameController.S.nearMonsterPosition- GameController.S.gamePlayer.transform.position).normalized;
        GameObject bullet = GameController.S.ThreeNormalAttackQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.gameObject.SetActive(true);
        bullet.GetComponent<ThreeNormalAttack>().MoveDirection = direction;
        bullet.GetComponent<ThreeNormalAttack>().MoveSpeed = 7f;
    }
    
    public void FireShot()
    {
        Vector2 direction = (GameController.S.nearMonsterPosition- GameController.S.gamePlayer.transform.position).normalized;
        GameObject bullet = GameController.S.FireQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.GetComponent<FireNormalAttack>().MoveDirection = direction;
        bullet.GetComponent<FireNormalAttack>().MoveSpeed = 7f;
        bullet.gameObject.SetActive(true);
    }
    
    public void XuKongShot()
    {
        Vector2 direction = (GameController.S.nearMonsterPosition- GameController.S.gamePlayer.transform.position).normalized;
        GameObject bullet = GameController.S.XuKongQueue.Dequeue();
        bullet.transform.position = GameController.S.gamePlayer.transform.position;
        bullet.GetComponent<XuKong>().MoveDirection = direction;
        bullet.GetComponent<XuKong>().MoveSpeed = 7f;
        bullet.gameObject.SetActive(true);
    }
    
}
