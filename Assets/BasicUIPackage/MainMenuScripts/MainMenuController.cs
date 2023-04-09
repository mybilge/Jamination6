using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject normalMainMenu;
    [SerializeField] GameObject leaderboardMenu;
    [SerializeField] GameObject firstOpenMenu;
    [SerializeField] GameObject creditsMenu;
    [SerializeField] GameObject settingsMenu;

    [SerializeField] GameObject windowsPencereMenu;

    [SerializeField] GameObject antivirusMenu;

    [SerializeField] GameObject chromeMenu;

    [SerializeField] float kapatanaKadarBekle = 4f;

   



    public static MainMenuController Instance;


    private void Awake() {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }


    private void Start() {

        normalMainMenu.SetActive(false);
        leaderboardMenu.SetActive(false);
        firstOpenMenu.SetActive(false);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        windowsPencereMenu.SetActive(false);
        antivirusMenu.SetActive(false);
        chromeMenu.SetActive(false);

        if(PlayerPrefs.GetInt("FirstTime") == 0)
        {
            ShowFirstOpenMenu();
        }

        else if(PlayerPrefs.GetInt("FirstTime") == 1)
        {
            ShowNormalMainMenu();
        }
    }


    public void ShowNormalMainMenu()
    {
        normalMainMenu.SetActive(true);
        leaderboardMenu.SetActive(false);
        firstOpenMenu.SetActive(false);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        windowsPencereMenu.SetActive(false);
        antivirusMenu.SetActive(false);
        chromeMenu.SetActive(false);
    }

    public void ShowLeaderboardMenu()
    {
        normalMainMenu.SetActive(true);
        leaderboardMenu.SetActive(true);
        firstOpenMenu.SetActive(false);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        windowsPencereMenu.SetActive(false);
        antivirusMenu.SetActive(false);
        chromeMenu.SetActive(false);
        HighScores.Instance.DownloadHighScores();
    }

    public void ShowFirstOpenMenu()
    {
        normalMainMenu.SetActive(false);
        leaderboardMenu.SetActive(false);
        firstOpenMenu.SetActive(true);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        windowsPencereMenu.SetActive(false);
        antivirusMenu.SetActive(false);
        chromeMenu.SetActive(false);
    }

    public void ShowCreditsMenu()
    {
        normalMainMenu.SetActive(true);
        leaderboardMenu.SetActive(false);
        firstOpenMenu.SetActive(false);
        creditsMenu.SetActive(true);
        settingsMenu.SetActive(false);
        windowsPencereMenu.SetActive(false);
        antivirusMenu.SetActive(false);
        chromeMenu.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Exit(){
        Invoke("HakikiExit", kapatanaKadarBekle);
    }

    public void HakikiExit()
    {
        Application.Quit();
    }

    public void ShowSettingsMenu()
    {
        normalMainMenu.SetActive(true);
        leaderboardMenu.SetActive(false);
        firstOpenMenu.SetActive(false);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(true);
        windowsPencereMenu.SetActive(false);
        antivirusMenu.SetActive(false);
        chromeMenu.SetActive(false);
    }


    public void ShowWindowsPencere()
    {
        normalMainMenu.SetActive(true);
        leaderboardMenu.SetActive(false);
        firstOpenMenu.SetActive(false);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        windowsPencereMenu.SetActive(true);
        antivirusMenu.SetActive(false);
        chromeMenu.SetActive(false);

    }

    public void ShowAntivirus()
    {
        normalMainMenu.SetActive(true);
        leaderboardMenu.SetActive(false);
        firstOpenMenu.SetActive(false);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        windowsPencereMenu.SetActive(false);
        antivirusMenu.SetActive(true);
        chromeMenu.SetActive(false);

    }

    public void ShowChrome()
    {
        normalMainMenu.SetActive(true);
        leaderboardMenu.SetActive(false);
        firstOpenMenu.SetActive(false);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        windowsPencereMenu.SetActive(false);
        antivirusMenu.SetActive(false);
        chromeMenu.SetActive(true);

    }
}
