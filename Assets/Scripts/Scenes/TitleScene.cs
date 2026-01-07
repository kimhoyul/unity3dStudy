using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Title;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Q 를 누르면 씬 이동
        {
            Managers.Scene.LoadScene(Define.Scene.Game);
            //SceneManager.LoadScene("Game"); // 동기 방식 씬 로드
            // SceneManager.LoadSceneAsync("LobbyScene"); // 비동기 방식 씬 로드, 현재는 몰라도 됨
        }
    }

    public override void Clear()
    {
        Logger.Log("TitleScene Clear");
    }
}
