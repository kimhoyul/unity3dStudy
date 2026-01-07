using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
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

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons)); // 어딘가에 타입을가져온뒤 그 안에 속한 이름으로 객체를 찾아서 저장해두겠다.
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        _text = GetText((int)Texts.ScoreText);
        _button = Get<Button>((int)Buttons.PointButton);

        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);

        //GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        //AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);

        Transform a = transform.parent;
    }

    void Test(string a)
    {
        Logger.Log("키보드쳤음");
    }

    int _score = 0;

    public void OnButtonClicked(PointerEventData data) 
    {
        _score++;
        _text.text = $"점수 : {_score}";
    }
}
