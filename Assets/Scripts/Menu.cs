using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class Menu : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static Menu Instance;
    public string playerName;
    public int highScore;
    public string highScorePlayerName;
    public TMP_InputField playerNameInput;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }


        Instance = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log(Application.persistentDataPath);
    }

    public void StartGameScene()
    {
        SceneManager.LoadScene(1);
        //playerNameInput.text = "aaaaa";
        playerName = playerNameInput.text;
    }

    [System.Serializable]
    public class SaveData
    {
        public string highScorePlayerName;
        public int highScore;
    }

    public void SaveHighScore(int score, string playerName)
    {
        SaveData data = new SaveData();
        data.highScorePlayerName = playerName;
        data.highScore = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
        
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScorePlayerName = data.highScorePlayerName;
        }
    }

}
