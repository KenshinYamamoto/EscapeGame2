using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanuki : MonoBehaviour
{
    // クリックされた時にLeafを持っていれば消える

    public bool moved = false;

    private void Start()
    {
        // 既にクリアしているならロッカーを開ける
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.MovedTanuki);
        if (clearGimmick)
        {
            Move();
        }
    }

    public void OnThis()
    {
        bool hasLeaf = ItemBox.instance.CanUseItem(ItemManager.Item.Leaf); // TODO：アイテムBoxの実装、アイテムの実装
        if (hasLeaf)
        {
            SoundManager.instance.PlaySE(SoundManager.SE.GimmickClear);
            Move();
            MessageManager.instance.ShowMessage("たぬきが消えていった");
            ItemBox.instance.UseItem(ItemManager.Item.Leaf);
        }
        else
        {
            MessageManager.instance.ShowMessage("たぬきは葉で消えるらしい");
        }
    }

    void Move()
    {
        moved = true;
        SaveManager.instance.SetGimmickFlag(SaveManager.Flag.MovedTanuki);
        gameObject.SetActive(false);
    }
}
