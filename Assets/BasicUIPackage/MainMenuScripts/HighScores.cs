using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HighScores : MonoBehaviour
{
    const string privateCode = "BPhmzLYEW0e7I5m9TFrWRA6ocV0b6-g0mLzW_6oQ6iHA";
    const string publicCode = "643088248f40bb109c0bb474";
    const string webURL = "http://dreamlo.com/lb/";

    public HighScoreStruct[] highscoreArray {get; private set;}
    DisplayHighScores displayHighScores;

    public static HighScores Instance;

    private void Awake() {

        if(Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        displayHighScores = GetComponent<DisplayHighScores>();
        DownloadHighScores();
    }

    private void Start() {
       
    }

    public static void AddNewHighScore(string username, int score)
    {
        Instance.StartCoroutine(Instance.UploadNewHighScore(username, score));
    }
    IEnumerator UploadNewHighScore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if(string.IsNullOrEmpty(www.error))
        {   
            Debug.Log("Upload Succesful");
            DownloadHighScores();
        }
        else{
            Debug.Log(www.error);
        }

    }


    public void DownloadHighScores()
    {
        StopCoroutine(DownloadHighScoresFromDatabase());
        StartCoroutine(DownloadHighScoresFromDatabase());
    }
    IEnumerator DownloadHighScoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighScores(www.text);
            displayHighScores.OnHighScoresDownloaded(highscoreArray);
        }
        else
        {
            Debug.Log(www.error);
        }
    }

    void FormatHighScores(string textStream)
    {
        string[] entries = textStream.Split(new char[]{'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        highscoreArray = new HighScoreStruct[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[]{'|'});
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoreArray[i] = new HighScoreStruct(username,score);
            Debug.Log(highscoreArray[i].username);
        }

    }

    
}

public struct HighScoreStruct{
    public string username;
    public int score;

    public HighScoreStruct(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}
