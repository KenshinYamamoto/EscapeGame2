using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker0 : MonoBehaviour
{
    // �_�C�A�����N���A������A���b�J�[���I�[�v���ɂ���FOpen�I�u�W�F�N�g��\������
    public GameObject openLocker;

    public GameObject dialButton;

    public void Open()
    {
        openLocker.SetActive(true);
        dialButton.SetActive(false);
    }
}
