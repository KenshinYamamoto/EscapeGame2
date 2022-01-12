using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaServer : MonoBehaviour
{
    // �N���b�N���ꂽ����
    // �^�k�L������Γ����Ȃ�
    // �^�k�L�����Ȃ���Έړ�(������)

    public Tanuki tanuki;

    // ���ɓ������Ă��������
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
            Debug.Log("���ʂ����ז���");
        }
    }

    void Move()
    {
        // ������
        gameObject.SetActive(false);
    }
}
