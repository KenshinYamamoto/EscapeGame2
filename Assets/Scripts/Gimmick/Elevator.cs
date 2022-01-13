using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject leftObj;
    public GameObject rightObj;
    Animation anim;
    bool moved = false;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    private void Start()
    {
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.OpenedElevator);
        if (clearGimmick)
        {
            Opened();
        }
    }

    // �J�[�h�������Ă���ΊJ��
    public void OnThis()
    {
        if (moved)
        {
            return;
        }
        bool hasCard = ItemBox.instance.CanUseItem(ItemManager.Item.Card);
        if (hasCard)
        {
            SaveManager.instance.SetGimmickFlag(SaveManager.Flag.OpenedElevator);
            Open();
            ItemBox.instance.UseItem(ItemManager.Item.Card);
        }
        else
        {
            MessageManager.instance.ShowMessage("�G���x�[�^�[�L�[���K�v��");
        }
    }

    void Open()
    {
        SoundManager.instance.PlaySE(SoundManager.SE.GimmickClear);
        MessageManager.instance.ShowMessage("�G���x�[�^�[���J����");
        moved = true;
        anim.Play();
    }

    void Opened()
    {
        moved = true;
        leftObj.SetActive(false);
        rightObj.SetActive(false);
    }
}
