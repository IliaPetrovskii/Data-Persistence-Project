using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public string bestScoreName;
    public int bestScore;
    public string currentPlayerName;
    public static MainManager Instance { get; set; }
            
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
    [System.Serializable]
    class SaveData
    {
        public string bestScoreName;
        public int bestScore;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScoreName = bestScoreName;
        data.bestScore = bestScore;
        
        string json = JsonUtility.ToJson(data);
          
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
        
            bestScore = data.bestScore;
            bestScoreName = data.bestScoreName;
        }
        else
        {
            bestScore = 0;
            bestScoreName = "...";
        }
    }
}