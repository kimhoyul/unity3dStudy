
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Raycast 호출을 위한 5가지 요소
    // - 레이 시작점
    // - 레이 방향
    // - 발사된 레이에 부딛힌 물체의 정보를 담을공간
    // - 레이의 길이
    // - 레이를 정확히 탐지하기 위한 레이어 마스크
    // hitiInfo.point = 정확한 히트 지점 찾을때 (월드 좌표)
    // hitiInfo.normal = 법선 백터 (반사각 구할때)
    // hitiInfo.distance = 레이어가 감지된 지점간의 거리

    // 픽킹 = 카메라로부터 레이를 쏴서, 물체를 탐지하는 경우 == 스크린레이

    // 레이어 라는건? -> 유니티 게임오브젝트들중 같은 성질을 갖은 게임 오브젝트끼리 그룹으로 묶는걸
    // bit 로 만들어져 있음
    // 레이어 마스크는 총 32비트 == 32개의 레이어 설정 가능
    // 비트연산이 기본 

    public GameObject _markerPrefab; // 프리펩

    //1. 불리언으로 상태를 관리
    bool _isMoveState = false;

    GameObject marker;

    public float _moveSpeed;
    //public float _turnSpeed;
    CharacterController _characterController;

    public float _rayLength = 100f;

    private void OnDrawGizmos() // 그냥 디버그 그림그리기
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position + Vector3.up, transform.forward * _rayLength);
    }

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    int _layerMask = (1 << 8); // 10000000 == 256 // 우리가 레이캐스팅 대상으로 삼을 레이어


    void Update()
    {
        if (_isMoveState)
        {
            //2. 매 프레임당 이동할 거리를 구하고
            // - 이동해야 하는 목표 지점 계산
            Vector3 targetPos = marker.transform.position;
            targetPos.y = transform.position.y;

            // - 거리 계산
            Vector3 framePos = Vector3.MoveTowards(transform.position, targetPos, _moveSpeed * Time.deltaTime);

            // - 이동 방향 백터 계산
            Vector3 moveDir = framePos - transform.position;

            // 캐릭터 이동
            _characterController.Move(moveDir);

            //4. 목표지점에 다다르면 쉬기
            // - 목표 지점에 닿았는지
            if (framePos == targetPos)
            {
                // _isMoveState를 false 로 바꿔줘야함
                _isMoveState = false;
                marker.SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r, out hitInfo, _rayLength, _layerMask))
            {
                
                marker = GameObject.Find("@Maker");
                if (marker == null)
                {
                    marker = Instantiate(_markerPrefab);
                    marker.name = "@Maker";
                }
                marker.SetActive(true);
                marker.transform.position = hitInfo.point; // 생성된 오브젝트의 위치를 이동
                _isMoveState = true;
            }
            else
            {
                Logger.Log($"안맞음");
            }
        }

        //RaycastHit hitInfo; 
        //if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out hitInfo, _rayLength))
        //{
        //    Logger.LogError($"Detected GameObject : {hitInfo.distance}"); 
        //}

        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //_characterController.Move(Vector3.forward * v * _moveSpeed * Time.deltaTime);
        //transform.Rotate(0, _turnSpeed * Time.deltaTime * h, 0);
    }
}
