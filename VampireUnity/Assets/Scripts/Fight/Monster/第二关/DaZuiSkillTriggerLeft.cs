using System;
using UnityEngine;

public class DaZuiSkillTriggerLeft : MonoBehaviour
{
    [NonSerialized]public EliteDaZuiMonster DaZuiMonster;
    
    private void Update()
    {
        if(DaZuiMonster&&gameObject.activeSelf)
            transform.position= DaZuiMonster.transform.position;
    }
}
