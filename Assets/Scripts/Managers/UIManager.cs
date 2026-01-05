using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 0; // 가장 최근에 사용한 소트오더를 저장할 예정

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>(); // 생성된 팝업을 들고있을 자료구조, LIFO(Last In First Out)

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);
        _order++;

        return popup;
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;

        _order--;
    }
}
