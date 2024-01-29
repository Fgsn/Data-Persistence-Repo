using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour
{
    public static RecordManager Instance;
    [SerializeField] TextMeshProUGUI playerNameField;
    [SerializeField] TextMeshProUGUI currenRecord;
    public string playerName;
    public string recordPlayerName = "Name";
    public int record = 0;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
        currenRecord.text = "Best Score :" + recordPlayerName +" : "  + record;
    }

    [System.Serializable]

    private class SaveData
    {
        public string recordName;
        public int record;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.record = record;
        data.recordName = recordPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            recordPlayerName = data.recordName;
            record = data.record;
        }
    }
    public void SetPlayerName()
    {
        playerName = playerNameField.text;
    }
}
