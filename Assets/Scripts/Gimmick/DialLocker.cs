using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialLocker : MonoBehaviour
{
    // 3つのボタンをそれぞれクリックして絵柄が全て一致すればクリア

    // ボタンの画像を取得
    public Image[] buttons;
    // 表示するマークを列挙
    enum Mark
    {
        Circle,
        Triangle,
        Star,
        Diamond,
    }
    // 現在のマーク
    Mark[] currentMarks = { Mark.Circle, Mark.Circle, Mark.Circle };
    // 正解のマーク
    Mark[] correctAnswerMarks = { Mark.Circle, Mark.Triangle, Mark.Star };

    // 表示する画像の素材一覧
    public Sprite[] resourceSprites;

    public UnityEvent ClearEvent;

    public void OnMarkButton(int position)
    {
        // positionのマークを変更する
        ChangeMark(position);
        // positionの画像を変更する
        ShowMark(position);

        if (IsAllClearMark())
        {
            Clear();
        }
    }

    void ChangeMark(int position)
    {
        currentMarks[position]++; // 1つ次のマーク
        if(currentMarks[position] > Mark.Diamond){
            currentMarks[position] = Mark.Circle;
        }
    }

    void ShowMark(int position)
    {
        int index = (int)currentMarks[position]; // int化
        buttons[position].sprite = resourceSprites[index]; // 対応する画像を表示
    }

    bool IsAllClearMark()
    {
        for(int i = 0;i < currentMarks.Length; i++)
        {
            if(currentMarks[i] != correctAnswerMarks[i])
            {
                // 1つでも違うものがあればクリアではない
                return false;
            }
        }
        // 全て一致していたのでクリア
        return true;
    }

    void Clear()
    {
        // ロッカーを開けたい
        Debug.Log("ロッカーが開いた");
        ClearEvent.Invoke();
    }
}
