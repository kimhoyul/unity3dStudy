using UnityEngine;

public class UI_Inven : UI_Scene
{    
    enum GameObjects
    {
        GridPanel,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        GameObject gridPanel = GetGameObject((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform) // 그리드패널에 자식오브젝트 전체 삭제
            Managers.Resource.Destroy(child.gameObject);

        // TODO : 실제 데이터 참고해서 인벤토리 채우기
        for (int i = 0; i < 10; i++)
        {
            GameObject item = Managers.Resource.Instantiate("UI/Scene/UI_InvenItem");
            item.transform.SetParent(gridPanel.transform); // 아이템 생성후 부모설정

            // TODO : 실제 데이터 참고해서 아이템의 내요 채우기

        }

    }

    void Update()
    {
        
    }
}
