using System;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
    // ·¦ÇÎÀÌ¶û ºñ½Á? ¶È°°Àº?
    public static void AddUIEvent(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.AddUIEvent(go, action, type);
    }
}
