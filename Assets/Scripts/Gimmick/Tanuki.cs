using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanuki : MonoBehaviour
{
    // �N���b�N���ꂽ����Leaf�������Ă���Ώ�����

    public bool moved = false;

    public void OnThis()
    {
        bool hasLeaf = ItemBox.instance.CanUseItem(ItemManager.Item.Leaf); // TODO�F�A�C�e��Box�̎����A�A�C�e���̎���
        if (hasLeaf)
        {
            gameObject.SetActive(false);
            ItemBox.instance.UseItem(ItemManager.Item.Leaf);
            moved = true;
        }
    }
}
