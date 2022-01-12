using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialLocker : MonoBehaviour
{
    // 3�̃{�^�������ꂼ��N���b�N���ĊG�����S�Ĉ�v����΃N���A

    // �{�^���̉摜���擾
    public Image[] buttons;
    // �\������}�[�N���
    enum Mark
    {
        Circle,
        Triangle,
        Star,
        Diamond,
    }
    // ���݂̃}�[�N
    Mark[] currentMarks = { Mark.Circle, Mark.Circle, Mark.Circle };
    // �����̃}�[�N
    Mark[] correctAnswerMarks = { Mark.Circle, Mark.Triangle, Mark.Star };

    // �\������摜�̑f�ވꗗ
    public Sprite[] resourceSprites;

    public UnityEvent ClearEvent;

    public void OnMarkButton(int position)
    {
        // position�̃}�[�N��ύX����
        ChangeMark(position);
        // position�̉摜��ύX����
        ShowMark(position);

        if (IsAllClearMark())
        {
            Clear();
        }
    }

    void ChangeMark(int position)
    {
        currentMarks[position]++; // 1���̃}�[�N
        if(currentMarks[position] > Mark.Diamond){
            currentMarks[position] = Mark.Circle;
        }
    }

    void ShowMark(int position)
    {
        int index = (int)currentMarks[position]; // int��
        buttons[position].sprite = resourceSprites[index]; // �Ή�����摜��\��
    }

    bool IsAllClearMark()
    {
        for(int i = 0;i < currentMarks.Length; i++)
        {
            if(currentMarks[i] != correctAnswerMarks[i])
            {
                // 1�ł��Ⴄ���̂�����΃N���A�ł͂Ȃ�
                return false;
            }
        }
        // �S�Ĉ�v���Ă����̂ŃN���A
        return true;
    }

    void Clear()
    {
        // ���b�J�[���J������
        Debug.Log("���b�J�[���J����");
        ClearEvent.Invoke();
    }
}
