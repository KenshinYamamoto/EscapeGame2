using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public enum Item{
        Leaf,
        Key,
        Card,
        Hammer,
        Paper,
    }

    public Item item;

    // クリックされた時に消し、アイテムBoxに追加する
    public void OnThis()
    {
        // 消す
        gameObject.SetActive(false);

        // アイテムボックスに追加する
        ItemBox.instance.SetItem(item);
    }
}
