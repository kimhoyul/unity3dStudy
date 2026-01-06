using UnityEngine;
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
  
    public override void Init()
    {
        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));
    }

    public void SetInfo(Sprite texture, string itemName)
    {
        Init();

        _texture = texture;
        _name = itemName;

        RefreshUI();
    }

    public void RefreshUI()
    {
        Image iconImage = GetImage((int)Images.ItemIcon);
        iconImage.sprite = _texture;

        Text nameText = GetText((int)Texts.ItemNameText);
        nameText.text = _name;

    }
}
