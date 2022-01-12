using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHydrant : MonoBehaviour
{
    public GameObject openObj;

    // �A�����͂̎���

    enum Direction
    {
        Left,
        Right,
    }
    // Player�̓���
    List<Direction> userInputs = new List<Direction>();
    // �����̘A�����́F�E�A���A���A�E�A�E
    Direction[] correctAnswers = { 
        Direction.Right,
        Direction.Left, 
        Direction.Left, 
        Direction.Right, 
        Direction.Right
    };

    private void Start()
    {
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.OpenedFireHydrant);
        if (clearGimmick)
        {
            openObj.SetActive(true);
        }
    }

    // ����
    public void OnButton(int type)
    {
        // type:0 ��
        // type:1 �E
        switch (type)
        {
            case 0:
                userInputs.Add(Direction.Left);
                break;
            case 1:
                userInputs.Add(Direction.Right);
                break;
        }
        Debug.Log(type);
        // ���[�U�[�̓��͂���
        // 5����͂��ꂽ��`�F�b�N����
        if(userInputs.Count == 5)
        {
            if (IsAllClear())
            {
                Clear();
            }
            else
            {
                // �s��v�̏ꍇ�̎��� Reset
                ResetInput();
            }
        }
    }

    void ResetInput()
    {
        userInputs.Clear();
        Debug.Log("���Z�b�g");
    }

    // ��v���Ă��邩�`�F�b�N
    bool IsAllClear()
    {
        for (int i = 0;i < userInputs.Count; i++)
        {
            if(userInputs[i] != correctAnswers[i])
            {
                return false;
            }
        }
        return true;
    }

    void Clear()
    {
        SaveManager.instance.SetGimmickFlag(SaveManager.Flag.OpenedFireHydrant);
        Debug.Log("�N���A");
        openObj.SetActive(true);
    }
}
