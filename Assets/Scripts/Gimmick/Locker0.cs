using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker0 : MonoBehaviour
{
    // ダイアルをクリアしたら、ロッカーをオープンにする：Openオブジェクトを表示する
    public GameObject openLocker;

    public GameObject dialButton;

    private void Start()
    {
        // 既にクリアしているならロッカーを開ける
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.OpenedLocker01);
        if (clearGimmick)
        {
            Open();
        }
    }

    public void Open()
    {
        openLocker.SetActive(true);
        dialButton.SetActive(false);
        SaveManager.instance.SetGimmickFlag(SaveManager.Flag.OpenedLocker01);
    }
}
