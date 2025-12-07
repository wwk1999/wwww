using System;
using System.Collections.Generic;
using Com.Tal.Unity.Core;
using UnityEngine;


public class ObserverModuleManager : XSingleton<ObserverModuleManager>
{
    private readonly Dictionary<string, List<Action<object[]>>> _observerDic = new();

    public void RegisterEvent(string key, Action<object[]> action)
    {
        if (!_observerDic.ContainsKey(key))
        {
            _observerDic.Add(key, new List<Action<object[]>>());
        }

        _observerDic[key].Add(action);
    }

    public void UnRegisterEvent(string key, Action<object[]> action)
    {
        if (!_observerDic.ContainsKey(key)) return;
        _observerDic[key].Remove(action);
        if (_observerDic[key].Count == 0)
        {
            _observerDic.Remove(key);
        }
    }

    public void UnRegisterAllEvent(string key)
    {
        if (!_observerDic.ContainsKey(key)) return;
        _observerDic.Remove(key);
    }

    public void SendEvent(string key, params object[] args)
    {
        if (!_observerDic.ContainsKey(key)) 
        {
            Debug.LogWarning($"没有找到事件 {key} 的监听器");
            return;
        }

        // 直接遍历 List，不创建数组
        var observers = _observerDic[key];
        for (int i = 0; i < observers.Count; i++)
        {
            try
            {
                observers[i](args);
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"异常堆栈: {ex.StackTrace}");
            }
        }
    }

    public void ClearAllEvent()
    {
        _observerDic.Clear();
    }
}