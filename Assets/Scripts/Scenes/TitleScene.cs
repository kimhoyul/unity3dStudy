using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Title;

        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(Managers.Resource.Instantiate("Player"));
        }

        foreach (GameObject obj in list)
        {
            Managers.Resource.Destroy(obj);
        }
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
