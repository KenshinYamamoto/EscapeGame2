using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject[] boxes;

    // ‚Ç‚±‚©‚ç‚Å‚àŽg‚¦‚é‚æ‚¤‚É‚·‚é
    public static ItemBox instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for(int i = 0;i < boxes.Length; i++)
        {
            boxes[i].SetActive(false);
        }
    }

    public void SetItem(ItemManager.Item item)
    {
        int index = (int)item;
        boxes[index].SetActive(true);
    }

    public bool CanUseItem(ItemManager.Item item)
    {
        int index = (int)item;
        if (boxes[index].activeSelf)
        {
            return true;
        }
        return false;
    }

    public void UseItem(ItemManager.Item item)
    {
        int index = (int)item;
        boxes[index].SetActive(false);
    }
}
