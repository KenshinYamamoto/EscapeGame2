using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // どこからでも使えるようにする
    public static SaveManager instance;
    private void Awake()
    {
        Load();
        if (instance == null)
        {
            instance = this;
        }
    }

    // ギミックのフラグ列挙
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

    // saveDataをJson(文字列)化
    // PlayerPrefsで文字列を保存
    void Save()
    {
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(SAVE_KEY, json);
    }

    // PlayerPrefsで文字列を取得
    // json文字列をクラスに変換
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
    public bool[] getItems = new bool[(int)ItemManager.Item.Max]; // 取得したアイテム
    public bool[] useItems = new bool[(int)ItemManager.Item.Max]; // 使用したアイテム
    public bool[] gimmick = new bool[(int)SaveManager.Flag.Max]; // ギミック
}

