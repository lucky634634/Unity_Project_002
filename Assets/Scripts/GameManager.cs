using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int highsScore;

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            highsScore = LoadHighScore();
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SaveHighScore()
    {
        string path = Application.persistentDataPath + "data.txt";
        StreamWriter file = new StreamWriter(path, false);
        file.WriteLine(highsScore.ToString());
        file.Close();
    }

    public int LoadHighScore()
    {
        string path = Application.persistentDataPath + "data.txt";
        if (File.Exists(path))
        {
            StreamReader file = new StreamReader(path);
            return int.Parse(file.ReadLine());
        }
        return 0;
    }

    private void OnApplicationQuit()
    {
        SaveHighScore();
    }
}
