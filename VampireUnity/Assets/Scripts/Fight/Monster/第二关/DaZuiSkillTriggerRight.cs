using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaZuiSkillTriggerRight : MonoBehaviour
{
    [NonSerialized]public EliteDaZuiMonster DaZuiMonster;
    
    private void Update()
    {
        if(DaZuiMonster&&gameObject.activeSelf)
            transform.position= DaZuiMonster.transform.position;
    }
}
