using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillSwitch : MonoBehaviour
{
    [NonSerialized]public List<MouseRightListen>  mouseRightListens = new List<MouseRightListen>();
    public Button RMB;
    public Button Alpha1;
    public Button Alpha2;
    public Button Alpha3;
    public Button Auto;
    public GameObject mask;

    public SkillWindow1 skillWindow1;
    

    
    [NonSerialized]public SkillType buttonType=SkillType.None;

    
    [NonSerialized]public MouseRightListen ClickMouseRightListen;

    

    private void Start()
    {
    }
}
