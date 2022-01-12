using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaServer : MonoBehaviour
{
    // クリックされた時に
    // タヌキがいれば動けない
    // タヌキがいなければ移動(消える)

    public Tanuki tanuki;

    // 既に動かしていたら消す
    private void Start()
    {
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.MovedTeaServer);
        if (clearGimmick)
        {
            Move();
        }
    }

    public void OnThis()
    {
        bool movedTanuki = tanuki.moved;
        if (movedTanuki)
        {
            SaveManager.instance.SetGimmickFlag(SaveManager.Flag.MovedTeaServer);
            Move();
        }
        else
        {
            Debug.Log("たぬきが邪魔だ");
        }
    }

    void Move()
    {
        // 消える
        gameObject.SetActive(false);
    }
}
