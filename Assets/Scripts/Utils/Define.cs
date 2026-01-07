using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Define
{
    public enum Scene
    {
        Unknown,
        Title,
        Lobby,
        Game,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }

    public enum MouseEvent
    {
        Press,
        Click,
    }

    //[Serializable]
    //public class InventoryData
    //{
    //    public List<Item> items;
    //}


    //[Serializable]
    //public class Item
    //{
    //    public int itemId;
    //    public Sprite itemIcon;
    //    public string itemName;
    //}
}
