using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance;

    public int score;
    public string playerName;

    public string savedName;
    public int highScore;
    private void Awake()
    {
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string playerName;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            playerName = data.playerName;
        }
    }


}
