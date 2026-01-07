using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown; // C# 7.0 부터 가능, 그이전에선 불가능

    void Start()
    {

    }

    protected virtual void Init()
    {

    }

    public abstract void Clear();
}
