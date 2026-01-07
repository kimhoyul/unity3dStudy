using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;

public class Managers : MonoBehaviour
{
    // 클래스간 데이터의 통신을 위한
    private static Managers instance; // 유일성이 보장 된다 / 클래스에 종속적이니까
    public static Managers Instance
    { 
        get 
        { 
            Init(); 
            return instance; 
        } 
    }

    private InputManager _input = new InputManager(); // 단일성을 위해서 매니저 클래스에서만 생성
    private ResourceManager _resource = new ResourceManager(); // 개체 생성
    private UIManager _ui = new UIManager();

    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } } // 개체를 접근할 수 있도록 열어줌
    public static UIManager UI { get { return Instance._ui; } }

    void Start()
    {
        

        Init();
    }

    private void Update() // 중앙에서 메인 컨트롤러를 놓고 걔를 통해서 모든걸 통제한다.
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go); // 씬이 이동되도 얘는 죽이지말고 살려놔
            instance = go.GetComponent<Managers>();
        }
    }
}
