using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
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

        _text = GetText((int)Texts.ScoreText);
        _button = Get<Button>((int)Buttons.PointButton);

        _button.onClick.AddListener(OnButtonClicked);

        GameObject go = Get<GameObject>((int)GameObjects.Test);
    }

    int _score = 0;

    public void OnButtonClicked() 
    {
        _score++;
        _text.text = $"점수 : {_score}";
    }
}
