using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        Load();
    }

    private void OnDestroy()
    {
        Save();
    }
    public class SaveData
    {
        public float volume;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.volume = slider.value;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefileSetting.json", json);

    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefileSetting.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            slider.value = data.volume;
        }

    }

    public void Confirm()
    {
        Save();
        MusicManager.Instance.musicSource.volume = slider.value;
        SceneManager.LoadScene(0);
    }

}
