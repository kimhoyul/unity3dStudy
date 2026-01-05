using UnityEngine;

public class ResourceManager 
{
    public T Load<T>(string path) where T : Object // 유니티에서 생성된 타입만 가져오겠다, 기본형식 X
    {
        return Resources.Load<T>(path); // 넘겨받은 주소를 통해서 Resources 폴더에 있는 오브젝트를 리턴하겠다.
    }

    public GameObject Instantiate(string path, Transform parent = null) // 유니티에서 만들어준 함수를 랩핑한것
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Logger.Log($"프리펩 불러오기 실패 : {path}");
            return null;
        }

        return Object.Instantiate(prefab, parent);
    }

    public void Destroy(GameObject go, float t = 0f)
    {
        if (go == null)
            return;

        Object.Destroy(go, t);
    }
}
