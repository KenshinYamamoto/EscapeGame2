using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // �ǂ�����ł��g����悤�ɂ���
    public static SaveManager instance;
    private void Awake()
    {
        Load();
        if (instance == null)
        {
            instance = this;
        }
    }

    // �M�~�b�N�̃t���O��
    public enum Flag
    {
        OpenedLocker01,
        MovedTanuki,
        MovedTeaServer,
        OpenedLocker,
        BrokenPig,
        OpenedFireHydrant,
        OpenedElevator,
        Max,
    }

    const string SAVE_KEY = "SaveData";
    public SavaData saveData;

    // saveData��Json(������)��
    // PlayerPrefs�ŕ������ۑ�
    void Save()
    {
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(SAVE_KEY, json);
    }

    // PlayerPrefs�ŕ�������擾
    // json��������N���X�ɕϊ�
    public void Load()
    {
        saveData = new SavaData();
        if (PlayerPrefs.HasKey(SAVE_KEY))
        {
            string json = PlayerPrefs.GetString(SAVE_KEY);
            saveData = JsonUtility.FromJson<SavaData>(json);
        }
    }

    public void CreateNewData()
    {
        PlayerPrefs.DeleteKey(SAVE_KEY);
        saveData = new SavaData();
    }

    public bool HasSaveData()
    {
        return PlayerPrefs.HasKey(SAVE_KEY);
    }

    public void SetGetItemFlag(ItemManager.Item item)
    {
        int index = (int)item;
        saveData.getItems[index] = true;
        Save();
    }

    public bool GetGetItemFlag(ItemManager.Item item)
    {
        int index = (int)item;
        return saveData.getItems[index];
    }

    public void SetUseItemFlag(ItemManager.Item item)
    {
        int index = (int)item;
        saveData.useItems[index] = true;
        Save();
    }

    public bool GetUseItemFlag(ItemManager.Item item)
    {
        int index = (int)item;
        return saveData.useItems[index];
    }

    public void SetGimmickFlag(Flag flag)
    {
        int index = (int)flag;
        saveData.gimmick[index] = true;
        Save();
    }

    public bool GetGimmickFlag(Flag flag)
    {
        int index = (int)flag;
        return saveData.gimmick[index];
    }
}

[System.Serializable]
public class SavaData
{
    public bool[] getItems = new bool[(int)ItemManager.Item.Max]; // �擾�����A�C�e��
    public bool[] useItems = new bool[(int)ItemManager.Item.Max]; // �g�p�����A�C�e��
    public bool[] gimmick = new bool[(int)SaveManager.Flag.Max]; // �M�~�b�N
}

