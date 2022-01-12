using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    // クリックしたときに鍵を持っていればOpenにする
    // 持っていなければログを出す

    public GameObject openObj;

    public void OnThis()
    {
        bool hasKey = ItemBox.instance.CanUseItem(ItemManager.Item.Key);
        if (hasKey)
        {
            Open();
            ItemBox.instance.UseItem(ItemManager.Item.Key); // 鍵を使用する
        }
        else
        {
            Debug.Log("鍵がかかっている");
        }
    }

    void Open()
    {
        // 開いている画像を表示
        openObj.SetActive(true);
    }
}
