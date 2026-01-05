using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    HashSet<int> a;

    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    // 리스트랑 유사
    // [1] [2] [3] [4]

    // 딕셔너리
    // [Button, Buttton[]] [Text, Text[]] [key, vaur] [key, vaur]

    Text _text;
    Button _button;

    enum Buttons
    {
        PointButton,
    }

    enum Texts
    {
        ScoreText,
    }

    enum GameObjects
    {
        Test,
    }

    public void Start()
    {
        Bind<Button>(typeof(Buttons)); // 어딘가에 타입을가져온뒤 그 안에 속한 이름으로 객체를 찾아서 저장해두겠다.
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));

        _text = Get<Text>((int)Texts.ScoreText);
        _button = Get<Button>((int)Buttons.PointButton);

        _button.onClick.AddListener(OnButtonClicked);

        GameObject go = Get<GameObject>((int)GameObjects.Test);
    }

    // 랩핑 함수
    // GetText(int index) <- 텍스트를 찾는 함수
    // GetButton(int index) <- 버튼를 찾는 함수
    // GetImage(int index) <- 이미지를 찾는 함수
    // GetGameObject(int index) <- 게임오브젝트를 찾는 함수

    void Bind<T>(Type type) where T : UnityEngine.Object // 컴포넌트를 물고있으려고 만드는거임
    {
        string[] names = Enum.GetNames(type); // enum 이 들고있는 모든 엘리먼트에 대한 이름을 배열로 가져오기

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length]; // 컴퍼넌트들을 저장하기 위한 배열공간 할당
        _objects.Add(typeof(T), objects); // 키 = 타입, 벨류 = 컴퍼넌트가 담겨있는 배열,  현재는 빈공간

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChild(gameObject, names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true); // 어떻게? // 여기에다가 사용할 함수를 Util 이라는 클래스를 만들어서 넣을 예정
        }
    }

    T Get<T>(int index) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[index] as T;
    }

    int _score = 0;

    public void OnButtonClicked() 
    {
        _score++;
        _text.text = $"점수 : {_score}";
    }
}
