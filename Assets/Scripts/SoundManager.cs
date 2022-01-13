using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // �ǂ�����ł��g����悤�ɂ��� => �V���O���g��(static)
    public static SoundManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����ς���Ă��j�󂳂�Ȃ�
        }
        else
        {
            // ����SoundManager������Ȃ�
            Destroy(gameObject);
        }
    }

    // �X�s�[�J�[�̖���
    public AudioSource audioSourceBGM;
    public AudioSource audioSourceSE;

    public AudioClip[] bgmList;
    public enum BGM
    {
        Title,
        Main,
        Clear,
    };

    public AudioClip[] seList;
    public enum SE
    {
        OnButton,
        GimmickClear,
        GetItem,
    };

    public void PlayBGM(BGM bgm)
    {
        int index = (int)bgm;
        audioSourceBGM.clip = bgmList[index]; // �����Z�b�g����
        audioSourceBGM.Play(); //�Đ����� 
    }

    public void PlaySE(SE se)
    {
        int index = (int)se;
        AudioClip clip = seList[index];
        audioSourceSE.PlayOneShot(clip); // 1��炷����
    }
}
