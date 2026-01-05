using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Action<PointerEventData> OnBeginDragHandler = null;
    public Action<PointerEventData> OnDragHandler = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Logger.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        a.Invoke(eventData);
        // 이 함수에서 추가 작업을 통해서 이미지를 드래그 해서 이동시키는 함수를 완성해주세요.
        transform.position = eventData.position;
        Logger.Log("OnDrag");
    }
}
