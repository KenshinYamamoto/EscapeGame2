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

    // カードを持っていれば開く
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
    }

    void Open()
    {
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
