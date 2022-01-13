using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    // メッセージパネルの
    // ・表示
    // ・非表示
    // ・テキストの変更 = パネルの表示

    public GameObject panel;
    public Text message;

    // どこからでも使えるようにする
    public static MessageManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }

    public void ShowMessage(string msg)
    {
        message.text = msg;
        ShowPanel();
    }
}
