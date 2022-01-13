using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // どこからでも使えるようにする => シングルトン(static)
    public static SoundManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // シーンが変わっても破壊されない
        }
        else
        {
            // 既にSoundManagerがあるなら
            Destroy(gameObject);
        }
    }

    // スピーカーの役割
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
        audioSourceBGM.clip = bgmList[index]; // 音をセットする
        audioSourceBGM.Play(); //再生する 
    }

    public void PlaySE(SE se)
    {
        int index = (int)se;
        AudioClip clip = seList[index];
        audioSourceSE.PlayOneShot(clip); // 1回鳴らすもの
    }
}
