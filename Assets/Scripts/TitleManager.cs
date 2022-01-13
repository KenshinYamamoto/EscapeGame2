using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject continueButton;

    private void Start()
    {
        SoundManager.instance.PlayBGM(SoundManager.BGM.Title);

        // セーブデータが無ければ「つづきから」ボタンを表示しない
        bool hasSaveData = SaveManager.instance.HasSaveData();
        if (hasSaveData)
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    public void OnStartButton()
    {
        // データを消して新規作成
        SaveManager.instance.CreateNewData();
        ToMainScene();
    }

    public void OnContinueButton()
    {
        // データをロード
        SaveManager.instance.Load();
        ToMainScene();
    }

    void ToMainScene()
    {
        // SEを鳴らしてMainシーンへ移行する
        SoundManager.instance.PlaySE(SoundManager.SE.OnButton);
        SceneManager.LoadScene("Main");
    }
}
