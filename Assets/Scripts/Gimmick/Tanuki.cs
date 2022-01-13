using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanuki : MonoBehaviour
{
    // �N���b�N���ꂽ����Leaf�������Ă���Ώ�����

    public bool moved = false;

    private void Start()
    {
        // ���ɃN���A���Ă���Ȃ烍�b�J�[���J����
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.MovedTanuki);
        if (clearGimmick)
        {
            Move();
        }
    }

    public void OnThis()
    {
        bool hasLeaf = ItemBox.instance.CanUseItem(ItemManager.Item.Leaf); // TODO�F�A�C�e��Box�̎����A�A�C�e���̎���
        if (hasLeaf)
        {
            SoundManager.instance.PlaySE(SoundManager.SE.GimmickClear);
            Move();
            MessageManager.instance.ShowMessage("���ʂ��������Ă�����");
            ItemBox.instance.UseItem(ItemManager.Item.Leaf);
        }
        else
        {
            MessageManager.instance.ShowMessage("���ʂ��͗t�ŏ�����炵��");
        }
    }

    void Move()
    {
        moved = true;
        SaveManager.instance.SetGimmickFlag(SaveManager.Flag.MovedTanuki);
        gameObject.SetActive(false);
    }
}
