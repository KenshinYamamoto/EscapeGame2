using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker0 : MonoBehaviour
{
    // �_�C�A�����N���A������A���b�J�[���I�[�v���ɂ���FOpen�I�u�W�F�N�g��\������
    public GameObject openLocker;

    public GameObject dialButton;

    private void Start()
    {
        // ���ɃN���A���Ă���Ȃ烍�b�J�[���J����
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
