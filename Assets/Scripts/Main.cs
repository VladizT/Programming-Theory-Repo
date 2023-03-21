using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Main : MonoBehaviour
{

    public static Main s { get; private set; }

    public string namePlayer { get; private set; }

    public int score { get; private set; }

    public int bestScore { get; private set; }


    public PlayerData playerData;


    static string pathToSaveFile;

    private void Awake()
    {
        if ( !s )
        {
            s = this;

            pathToSaveFile = Application.persistentDataPath + "/saveData.json";

            LoadGame();

            DontDestroyOnLoad(gameObject);

        } else
        {
            Destroy(gameObject);
        }
 
    }

    /// <summary>
    /// Set name player.
    /// </summary>
    /// <param name="name"></param>
    public void SetName( string name )
    {
        namePlayer = name;
    }

    public void ResetScore()
    {
        score = 0;
    }
    public void AddScore( int _score )
    {
        if( _score > 0 )
        {
            score += _score;
        }

    }

    public void CheckBestScore()
    {
        if( score > bestScore )
        {
            bestScore = score;
            SaveGame();
        }
    }

    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public int bestScore;
    }

    void SaveGame()
    {

        playerData.name = namePlayer;
        playerData.bestScore = bestScore;

        string json = JsonUtility.ToJson(playerData);
        
       

        File.WriteAllText(pathToSaveFile, json);

    }

    void LoadGame()
    {

        if (File.Exists(pathToSaveFile))
        {
            string json = File.ReadAllText(pathToSaveFile);

            playerData = JsonUtility.FromJson<PlayerData>(json);

            namePlayer = playerData.name;
            bestScore  = playerData.bestScore;

        }

    }

}
