using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_InvenItem : UI_Base
{
    Sprite _texture;
    string _name;

    enum Images
    {
        ItemIcon,
    }

    enum Texts
    {
        ItemNameText
    }

    enum Buttons
    {
        ItemButton,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.ItemButton).gameObject.AddUIEvent(OnButtonClicked);

        RefreshUI();
    }

    public void SetInfo(Sprite texture, string itemName)
    {
        _texture = texture;
        _name = itemName;
    }

    public void RefreshUI()
    {
        Image iconImage = GetImage((int)Images.ItemIcon);
        iconImage.sprite = _texture;

        Text nameText = GetText((int)Texts.ItemNameText);
        nameText.text = _name;

    }

    public void OnButtonClicked(PointerEventData data)
    {
        Logger.Log($"{_name} Å¬¸¯");
    }
}