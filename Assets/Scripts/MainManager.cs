using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    void Start()
    {
        SoundManager.instance.PlayBGM(SoundManager.BGM.Main);
    }
}
