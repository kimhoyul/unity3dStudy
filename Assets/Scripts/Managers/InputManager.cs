using System;
using UnityEngine;

public class InputManager
{
    // 리스너 패턴
    public Action KeyAction = null;

    public void OnUpdate()
    {
        if (Input.anyKey == false)
            return;

        if (KeyAction != null) // KeyAction 구독한 클래스가 있다면 
            KeyAction.Invoke(); // 그럼 KeyAction을 브로드캐스트 하자!!!
    }
}
