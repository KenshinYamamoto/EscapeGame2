using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    // �N���b�N�����Ƃ��Ɍ��������Ă����Open�ɂ���
    // �����Ă��Ȃ���΃��O���o��

    public GameObject openObj;

    public void OnThis()
    {
        bool hasKey = ItemBox.instance.CanUseItem(ItemManager.Item.Key);
        if (hasKey)
        {
            Open();
            ItemBox.instance.UseItem(ItemManager.Item.Key); // �����g�p����
        }
        else
        {
            Debug.Log("�����������Ă���");
        }
    }

    void Open()
    {
        // �J���Ă���摜��\��
        openObj.SetActive(true);
    }
}
