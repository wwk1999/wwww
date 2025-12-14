using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBallItem : MonoBehaviour
{
 
    void Start()
    {
        if (GlobalPlayerAttribute.PlayerOrangeEntry.Contains(EntryConfig.OrangeEntry.Skill2AddRange))
        {
            transform.localPosition=new Vector3(transform.localPosition.x*1.3f, transform.localPosition.y*1.3f, transform.localPosition.z*1.3f);
            transform.localScale=new Vector3(transform.localScale.x*1.3f,transform.localScale.y*1.3f,transform.localScale.z*1.3f);
        }
    }
}
