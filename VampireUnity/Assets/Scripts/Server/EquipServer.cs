using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RemoveEquipData
{
    public int equipid { get; set; }
}

public class WearEquipData
{
    public string equip_slot { get; set; }
    public int equipid { get; set; }
}

public class BatchRemoveEquipData
{
    public int[] equipids { get; set; }
}


public class EquipServer : XSingleton<EquipServer>
{
    /// <summary>
    /// 移除装备请求
    /// </summary>
    /// <param name="equipid"></param>
    /// <returns></returns>
    public async Task<bool> SendRemoveEquipRequest(int equipid)
    {

        var RemoveEquipRequest = new GameRequest
        {
            type = "equip",
            action = "delEquip",
            data = new RemoveEquipData
            {
                equipid = equipid
            },
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await ServerConnect.S.SendMessageAsync(RemoveEquipRequest);
        return true;
    }
    
    
    /// <summary>
    /// 获取玩家穿戴装备请求
    /// </summary>
    /// <returns></returns>
    public async Task<bool> GetPlayerEquipRequest()
    {
        var GetPlayerEquipRequest = new GameRequest
        {
            type = "userequip",
            action = "getEquippedItems",
            data = new RemoveEquipData
            { },
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await ServerConnect.S.SendMessageAsync(GetPlayerEquipRequest);
        return true;
    }
    
    
    
    /// <summary>
    /// 穿戴玩家装备请求
    /// </summary>
    /// <returns></returns>
    public async Task<bool> WearPlayerEquipRequest(string equip_slot,int equipid)
    {

        var WearPlayerEquipRequest = new GameRequest
        {
            type = "userequip",
            action = "equipItem",
            data = new WearEquipData
            {
                equip_slot = equip_slot,
                equipid = equipid
            },
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        await ServerConnect.S.SendMessageAsync(WearPlayerEquipRequest);
        return true;
    }
    
}
