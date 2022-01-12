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
        Max,
    }

    public Item item;

    private void Start()
    {
        // 既に取得しているなら表示しない。
        bool hasItem = SaveManager.instance.GetGetItemFlag(item);
        bool usedItem = SaveManager.instance.GetUseItemFlag(item);

        if (usedItem)
        {
            gameObject.SetActive(false);
        }
        else if (hasItem)
        {
            // ItemBoxに追加する
            SetToItemBox();
        }
    }

    // クリックされた時に消し、アイテムBoxに追加する
    public void OnThis()
    {
        SetToItemBox();
    }

    void SetToItemBox()
    {
        // 消す
        gameObject.SetActive(false);

        // アイテムボックスに追加する
        ItemBox.instance.SetItem(item);
    }
}
