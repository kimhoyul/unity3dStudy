using UnityEngine;

public class ResourceManager 
{
    public T Load<T>(string path) where T : Object // 유니티에서 생성된 타입만 가져오겠다, 기본형식 X
    {
        if (typeof(T) == typeof(GameObject)) // 게임오브젝트가 T라는 얘기는 프리펩을 얘가 불러오려고 하는구나
        {
            string name = path;
            int index = name.LastIndexOf('/');
            if (index >= 0)
                name = name.Substring(index + 1);

            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null)
                return go as T;
        }

        return Resources.Load<T>(path); // 넘겨받은 주소를 통해서 Resources 폴더에 있는 오브젝트를 리턴하겠다.
    }

    public GameObject Instantiate(string path, Transform parent = null) // 유니티에서 만들어준 함수를 랩핑한것
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Logger.Log($"프리펩 불러오기 실패 : {path}");
            return null;
        }

        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;
        return go;
    }

    public void Destroy(GameObject go, float t = 0f)
    {
        if (go == null)
            return;

        // 3. 삭제가아니라 풀링대상자 라면 풀매니저에게 보내버리기
        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go, t);
    }
}
