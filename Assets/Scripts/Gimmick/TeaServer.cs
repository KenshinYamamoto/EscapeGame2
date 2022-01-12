using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaServer : MonoBehaviour
{
    // クリックされた時に
    // タヌキがいれば動けない
    // タヌキがいなければ移動(消える)

    public Tanuki tanuki;

    public void OnThis()
    {
        bool movedTanuki = tanuki.moved;
        if (movedTanuki)
        {
            // 消える
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("たぬきが邪魔だ");
        }
    }
}
