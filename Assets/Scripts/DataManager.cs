using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string Name;
    public string MaxScoreName;
    public int MaxScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
    }
    [System.Serializable]
    public class SaveData
    {
       public string MaxScoreName;
       public int MaxScore;
    }
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.MaxScoreName = MaxScoreName;
        data.MaxScore = MaxScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            MaxScoreName = data.MaxScoreName;
            MaxScore = data.MaxScore;

        }
    }
    private void OnApplicationQuit()
    {
        DataManager.Instance.SaveName();
    }
}
