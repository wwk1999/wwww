using UnityEngine;

public class IceExplosion : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            bool isCrit = GameController.S.GetIsCrit();
            other.transform.parent.GetComponent<MonsterBase>().Hurt(GlobalPlayerAttribute.TotalDamage,isCrit,DamageFrom.Skill3);
            
        }
    }
}
