using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler
{
    public Action<PointerEventData> OnBeginDragHandler = null;
    public Action<PointerEventData> OnDragHandler = null;
    public Action<PointerEventData> OnClickHandler = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Logger.Log("OnBeginDrag");
        if (OnBeginDragHandler != null)
            OnBeginDragHandler.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Logger.Log("OnDrag");
        if (OnDragHandler != null)
            OnDragHandler.Invoke(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Logger.Log("OnPointerClick");
        if (OnClickHandler != null)
            OnClickHandler.Invoke(eventData);
    }
}
