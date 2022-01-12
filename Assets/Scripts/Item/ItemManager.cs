using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public enum Item{
        Leaf,
        Key,
        Card,
        Hammer,
        Paper,
    }

    public Item item;

    // �N���b�N���ꂽ���ɏ����A�A�C�e��Box�ɒǉ�����
    public void OnThis()
    {
        // ����
        gameObject.SetActive(false);

        // �A�C�e���{�b�N�X�ɒǉ�����
        ItemBox.instance.SetItem(item);
    }
}
