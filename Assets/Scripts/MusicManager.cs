using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioSource musicSource;
    public static float volumeValue = 0;

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
        musicSource = GetComponent<AudioSource>();
        musicSource.volume = volumeValue;
        musicSource.Play();
    }
    private void Start()
    {
        
    }

    public class SaveData
    {
        public float volume;
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefileSetting.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            volumeValue = data.volume;
        }
    }
}
