using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHydrant : MonoBehaviour
{
    public GameObject openObj;

    // 連続入力の実装

    enum Direction
    {
        Left,
        Right,
    }
    // Playerの入力
    List<Direction> userInputs = new List<Direction>();
    // 正解の連続入力：右、左、左、右、右
    Direction[] correctAnswers = { 
        Direction.Right,
        Direction.Left, 
        Direction.Left, 
        Direction.Right, 
        Direction.Right
    };

    private void Start()
    {
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.OpenedFireHydrant);
        if (clearGimmick)
        {
            openObj.SetActive(true);
        }
    }

    // 入力
    public void OnButton(int type)
    {
        // type:0 左
        // type:1 右
        switch (type)
        {
            case 0:
                userInputs.Add(Direction.Left);
                break;
            case 1:
                userInputs.Add(Direction.Right);
                break;
        }
        Debug.Log(type);
        // ユーザーの入力を代入
        // 5回入力されたらチェックする
        if(userInputs.Count == 5)
        {
            if (IsAllClear())
            {
                Clear();
            }
            else
            {
                // 不一致の場合の実装 Reset
                ResetInput();
            }
        }
    }

    void ResetInput()
    {
        userInputs.Clear();
        Debug.Log("リセット");
    }

    // 一致しているかチェック
    bool IsAllClear()
    {
        for (int i = 0;i < userInputs.Count; i++)
        {
            if(userInputs[i] != correctAnswers[i])
            {
                return false;
            }
        }
        return true;
    }

    void Clear()
    {
        SaveManager.instance.SetGimmickFlag(SaveManager.Flag.OpenedFireHydrant);
        Debug.Log("クリア");
        openObj.SetActive(true);
    }
}
