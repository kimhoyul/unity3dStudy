using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{    
    public BaseScene CurrentScene { get { return GameObject.FindFirstObjectByType<BaseScene>(); } }

    public void LoadScene(Define.Scene type) // 래핑 함수
    {
        CurrentScene.Clear();
        SceneManager.LoadScene(type.ToString());
    }
}
