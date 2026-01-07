using UnityEngine;

public class GameScene : BaseScene // Game 씬에 선봉장
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game; // 은닉성

        Managers.UI.ShowSceneUI<UI_Inven>(); // 씬에 관련된 UI니까 Scene class 에서 관리하겠다
    }

    public override void Clear() // 이 씬이 종료되었을때 삭제해야할 데이터 혹은 메모리를 청소 하는 함수
    {
        
    }
}
