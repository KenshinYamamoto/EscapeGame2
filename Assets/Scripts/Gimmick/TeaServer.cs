using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaServer : MonoBehaviour
{
    // クリックされた時に
    // タヌキがいれば動けない
    // タヌキがいなければ移動(消える)

    public Tanuki tanuki;
    Animation anim;
    bool moved = false;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    // 既に動かしていたら消す
    private void Start()
    {
        // 既にクリアしているなら
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.MovedTeaServer);
        if (clearGimmick)
        {
            Moved();
        }
    }

    public void OnThis()
    {
        if (moved)
        {
            return;
        }
        bool movedTanuki = tanuki.moved;
        if (movedTanuki)
        {
            SaveManager.instance.SetGimmickFlag(SaveManager.Flag.MovedTeaServer);
            Move();
        }
        else
        {
            Debug.Log("たぬきが邪魔だ");
        }
    }

    void Move()
    {
        moved = true;
        anim.Play();
    }

    void Moved()
    {
        moved = true;
        transform.localPosition = new Vector3(22f, -102f, 0);
    }
}
