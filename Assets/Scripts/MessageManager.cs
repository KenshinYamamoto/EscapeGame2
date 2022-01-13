using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    // ���b�Z�[�W�p�l����
    // �E�\��
    // �E��\��
    // �E�e�L�X�g�̕ύX = �p�l���̕\��

    public GameObject panel;
    public Text message;

    // �ǂ�����ł��g����悤�ɂ���
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
