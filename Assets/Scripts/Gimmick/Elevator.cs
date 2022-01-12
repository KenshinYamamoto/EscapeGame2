using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject leftObj;
    public GameObject rightObj;

    // �J�[�h�������Ă���ΊJ��

    public void OnThis()
    {
        bool hasCard = ItemBox.instance.CanUseItem(ItemManager.Item.Card);
        if (hasCard)
        {
            Open();
            ItemBox.instance.UseItem(ItemManager.Item.Card);
        }
    }

    void Open()
    {
        // ���E�̔�������
        leftObj.SetActive(false);
        rightObj.SetActive(false);
    }
}
