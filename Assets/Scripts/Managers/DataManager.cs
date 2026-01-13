using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<int, Stat> StatDict { get; private set; } = new Dictionary<int, Stat>(); // 이니셜라이저 C# 7.0

  
    public void Init()
    {
        StatDict = LoadJson<StatData, int, Stat>("StatData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}"); // Text == string 데이터로 들고 있기
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
