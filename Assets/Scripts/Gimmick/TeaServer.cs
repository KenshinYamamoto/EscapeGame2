using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaServer : MonoBehaviour
{
    // �N���b�N���ꂽ����
    // �^�k�L������Γ����Ȃ�
    // �^�k�L�����Ȃ���Έړ�(������)

    public Tanuki tanuki;
    Animation anim;
    bool moved = false;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    // ���ɓ������Ă��������
    private void Start()
    {
        // ���ɃN���A���Ă���Ȃ�
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
            Debug.Log("���ʂ����ז���");
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
