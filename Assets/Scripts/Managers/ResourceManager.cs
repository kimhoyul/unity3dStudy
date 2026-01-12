using UnityEngine;

public class ResourceManager 
{
    public T Load<T>(string path) where T : Object // 유니티에서 생성된 타입만 가져오겠다, 기본형식 X
    {
        return Resources.Load<T>(path); // 넘겨받은 주소를 통해서 Resources 폴더에 있는 오브젝트를 리턴하겠다.
    }

    public GameObject Instantiate(string path, Transform parent = null) // 유니티에서 만들어준 함수를 랩핑한것
    {
        // 1. 이미 프리펩을 들고 있다면 바로 사용
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Logger.Log($"프리펩 불러오기 실패 : {path}");
            return null;
        }

        // 2. 혹시 풀링 된 애가 있다면 역시 걔를 사용
        GameObject go = Object.Instantiate(prefab, parent);
        go.name = prefab.name;
        
        return go;
    }

    public void Destroy(GameObject go, float t = 0f)
    {
        if (go == null)
            return;

        // 3. 삭제가아니라 풀링대상자 라면 풀매니저에게 보내버리기

        Object.Destroy(go, t);
    }
}
