using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

    enum Images
    {
        ItemIcon,
    }

    public void Start()
    {
        Bind<Button>(typeof(Buttons)); // 어딘가에 타입을가져온뒤 그 안에 속한 이름으로 객체를 찾아서 저장해두겠다.
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        _text = GetText((int)Texts.ScoreText);
        _button = Get<Button>((int)Buttons.PointButton);

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        UI_EventHandler evt = go.GetComponent<UI_EventHandler>();
        evt.OnDragHandler += ((PointerEventData data) => { go.transform.position = data.position; });


        _button.onClick.AddListener(OnButtonClicked);
    }

    int _score = 0;

    public void OnButtonClicked() 
    {
        _score++;
        _text.text = $"점수 : {_score}";
    }
}
