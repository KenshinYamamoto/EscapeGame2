using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePig : MonoBehaviour
{
    // �N���b�N�����Ƃ��Ƀn���}�[�������Ă���Δj�󂷂�
    // �����Ă��Ȃ���΃��O���o��

    public GameObject pigObj;
    public GameObject brokenPigObj;

    private void Start()
    {
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.BrokenPig);
        if (clearGimmick)
        {
            Break();
        }
    }

    public void OnThis()
    {
        bool hasHammer = ItemBox.instance.CanUseItem(ItemManager.Item.Hammer);
        if (hasHammer)
        {
            SaveManager.instance.SetGimmickFlag(SaveManager.Flag.BrokenPig);
            Break();
            ItemBox.instance.UseItem(ItemManager.Item.Hammer); // �����g�p����
        }
        else
        {
            Debug.Log("�󂹂�����");
        }
    }

    void Break()
    {
        // ���ʂ̓؂��\��
        pigObj.SetActive(false);
        // ��ꂽ�؉摜��\��
        brokenPigObj.SetActive(true);
    }
}
