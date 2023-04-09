using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float timer;

    bool isEnded = false;

    private void Update() {

        if(isEnded)
        {
            return;
        }

        timer  += Time.deltaTime;
    }


    public void SetIsEnded()
    {
        Time.timeScale = 0;
        isEnded = true;
        int bestScore = PlayerPrefs.GetInt("BestScore");
        if (bestScore< timer)
        {
            PlayerPrefs.SetInt("BestScore", (int)timer);
           
        }

        UIManager.Instance.SetEndGameText((int)timer);

        AudioSourceManager.Instance.PlayOneTime(AudioSourceManager.Instance.kaybetmeClip);
        AudioSourceManager.Instance.StopLoop();


        BaseEnemy[] enemies = GameObject.FindObjectsOfType<BaseEnemy>();

        foreach (var item in enemies)
        {
            Destroy(item.gameObject);
        }

        Destroy(gameObject);
    }

    public float GetTimer()
    {
        return timer;
    }
}
