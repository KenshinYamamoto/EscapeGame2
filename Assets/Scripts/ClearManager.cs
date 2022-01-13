using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
    void Start()
    {
        SoundManager.instance.PlayBGM(SoundManager.BGM.Clear);
    }
}
