using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region

    // public GameObject prefab;

    // SandMessage = 메서드 이름 매칭
    // 단, 지금 PlayerInput 컴퍼넌트가 속해있는 해당 오브젝트에 형제 컴퍼넌트 중에서 해당 함수를 찾아서 매칭한다.
    // 즉, 자식오브젝트에 스크립트를 만들어서 거기에 함수 만들어봤자 호출이 안됨

    // SandMessage 기반이란 문자열(메서드(함수)명)로 런타임에 탐색 후 호출 방식
    // 장점 : 세팅이 매우 빠르다 (편하니까, 선개발)
    // 단점 : 리팩터링 취약(액션의 이름, 혹은 함수의 이름에 따라 의존성이 강함)

    // 특징 

    // BroadcastMessage = 메서드 이름 매칭
    // 단, 자기 자신부터 자식까지 컴퍼넌트를 뒤져서 액션과 같은 이름의 함수를 찾아서 실행한다.

    // Unity Events = Instpector 에다가 함수를 직접 바인딩(클래스와 함수를 직접 지정)해서 해당 함수를 실행 시키는 방식
    // 장점 : 가시성 좋음, 문자열기반 탐색이 없어서 수정에 용이함
    // 단점 : 엄청나게 많은 오브젝트가 있다면 일일이 걸기가 힘들다

    //private PlayerInput playerInput;


    //private void Awake()
    //{
    //    playerInput = GetComponent<PlayerInput>();
    //}

    //private void Start()
    //{
    //    playerInput.onActionTriggered += OnActionTriggered;
    //}


    //private void OnActionTriggered(InputAction.CallbackContext context)
    //{
    //    switch (context.action.name)
    //    {
    //        case "Move" :
    //            if (context.performed)
    //            {
    //                Vector2 move = context.ReadValue<Vector2>();
    //            }
    //            if (context.canceled)
    //            {
    //                // 눌르지 않았을떄 처리
    //            }
    //            break;
    //        case "Look":
    //            break;

    //    }
    //}


    // nested prefab

    //private void Start()
    //{
    //    Instantiate(prefab);
    //}
    #endregion


    private Vector3 _moveDirection;
    public float _speed = 5f;

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        Logger.Log($"{input.x} {input.y}");   

        if (input != null)
        {
            _moveDirection = new Vector3(input.x, 0, input.y);
            Logger.Log($"SandMessage : {_moveDirection.magnitude}");
        }
    }

    private void Update()
    {
        bool hasControl = (_moveDirection != Vector3.zero);
        if (hasControl)
        {
            transform.rotation = Quaternion.LookRotation(_moveDirection);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime); 
        }
    }
}
