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

        // �Z�[�u�f�[�^��������΁u�Â�����v�{�^����\�����Ȃ�
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
        // �f�[�^�������ĐV�K�쐬
        SaveManager.instance.CreateNewData();
        ToMainScene();
    }

    public void OnContinueButton()
    {
        // �f�[�^�����[�h
        SaveManager.instance.Load();
        ToMainScene();
    }

    void ToMainScene()
    {
        // SE��炵��Main�V�[���ֈڍs����
        SoundManager.instance.PlaySE(SoundManager.SE.OnButton);
        SceneManager.LoadScene("Main");
    }
}
