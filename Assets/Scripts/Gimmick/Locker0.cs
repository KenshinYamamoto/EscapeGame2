using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker0 : MonoBehaviour
{
    // ダイアルをクリアしたら、ロッカーをオープンにする：Openオブジェクトを表示する
    public GameObject openLocker;

    public GameObject dialButton;

    public void Open()
    {
        openLocker.SetActive(true);
        dialButton.SetActive(false);
    }
}
