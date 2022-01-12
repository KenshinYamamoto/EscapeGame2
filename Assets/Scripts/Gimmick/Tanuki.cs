using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanuki : MonoBehaviour
{
    // クリックされた時にLeafを持っていれば消える

    public bool moved = false;

    public void OnThis()
    {
        bool hasLeaf = ItemBox.instance.CanUseItem(ItemManager.Item.Leaf); // TODO：アイテムBoxの実装、アイテムの実装
        if (hasLeaf)
        {
            gameObject.SetActive(false);
            ItemBox.instance.UseItem(ItemManager.Item.Leaf);
            moved = true;
        }
    }
}
