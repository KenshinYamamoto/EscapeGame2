using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaServer : MonoBehaviour
{
    // �N���b�N���ꂽ����
    // �^�k�L������Γ����Ȃ�
    // �^�k�L�����Ȃ���Έړ�(������)

    public Tanuki tanuki;

    public void OnThis()
    {
        bool movedTanuki = tanuki.moved;
        if (movedTanuki)
        {
            // ������
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("���ʂ����ז���");
        }
    }
}
