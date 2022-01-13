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
        Max,
    }

    public Item item;

    private void Start()
    {
        // ���Ɏ擾���Ă���Ȃ�\�����Ȃ��B
        bool hasItem = SaveManager.instance.GetGetItemFlag(item);
        bool usedItem = SaveManager.instance.GetUseItemFlag(item);

        if (usedItem)
        {
            gameObject.SetActive(false);
        }
        else if (hasItem)
        {
            // ItemBox�ɒǉ�����
            SetToItemBox();
        }
    }

    // �N���b�N���ꂽ���ɏ����A�A�C�e��Box�ɒǉ�����
    public void OnThis()
    {
        SetToItemBox();
        MessageManager.instance.ShowMessage(GetItemName(item) + "����ɓ��ꂽ");
        SoundManager.instance.PlaySE(SoundManager.SE.GetItem);
    }

    string GetItemName(Item item)
    {
        switch (item)
        {
            case Item.Leaf:
                return "�t";
            case Item.Key:
                return "���ɂ̌�";
            case Item.Card:
                return "�G���x�[�^�[�L�[";
            case Item.Hammer:
                return "�n���}�[";
            case Item.Paper:
                return "�ł�����";
        }
        return "";
    }

    void SetToItemBox()
    {
        // ����
        gameObject.SetActive(false);

        // �A�C�e���{�b�N�X�ɒǉ�����
        ItemBox.instance.SetItem(item);
    }
}
