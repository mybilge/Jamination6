using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI canText;
    [SerializeField] TextMeshProUGUI mermiText;

    [SerializeField] TextMeshProUGUI timer;

    [SerializeField] GameObject endGameObject;
    [SerializeField] TextMeshProUGUI endGameText;
    [SerializeField] Button mainMenuBtn;


    public static UIManager Instance {get;private set;}

    private void Awake() {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance =this;
        endGameObject.SetActive(false);
    }

    private void Update() {
        if(Player.Instance == null)
        {
            return;
        }

        double mainGameTimerd = (double)Player.Instance.GetComponent<TimeManager>().GetTimer();
        TimeSpan time = TimeSpan.FromSeconds(mainGameTimerd);
        string displayTime = time.ToString("mm':'ss");
        timer.text = displayTime;
    }


    public void SetCanText(int can)
    {
        canText.text = can.ToString();
    }


    public void SetMermiText(int mermi)
    {
        mermiText.text = mermi.ToString();
    }


    public void SetEndGameText(int score)
    {
        endGameObject.SetActive(true);
        double mainGameTimerd = (double)score;
        TimeSpan time = TimeSpan.FromSeconds(mainGameTimerd);
        string scoreText = time.ToString("mm':'ss");


        endGameText.text  = "GAME OVER\n\nSCORE: " + scoreText;
    }


    public void TurnMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
