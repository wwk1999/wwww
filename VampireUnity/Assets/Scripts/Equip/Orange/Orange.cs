using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public class Orange : EquipBase
{
    private bool isSend = false; //是否发送消息

    public Orange() : base( "", SuitType.None,new EquipTable()){}

    private void Awake()
    {
        EquipAttributes.orangeid = CreateRandomOrangeId();
        EquipAttributes.OrangeEntry1 = EntryConfig.OrangeIdEntryDic[EquipAttributes.orangeid];
        EquipAttributes.EquipType = EntryConfig.OrangeIdEquipTypeDic[EquipAttributes.orangeid];
        SpriteRenderer.sprite = ResourcesConfig.GetEquipSprite(EquipAttributes);
        //暂时写死
        EquipAttributes.Quality = 5;
        EquipAttributes.EquipLevel = GetOrangeLevel();

        SetBaseAttribute();
        InitEntry();
    }
}
