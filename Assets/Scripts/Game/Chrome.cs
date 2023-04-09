using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chrome : MonoBehaviour
{
    [SerializeField] GameObject[] browsers;


    Stack<int> lastBrowsers;

    private void Awake() {
        lastBrowsers = new Stack<int>();
    }




    public void BackPage()
    {
        ShowBrowserWithoutBack(lastBrowsers.Pop());
    }
    public void HomePage()
    {
        ShowBrowser(0);
    }

    private void OnDisable()
    {
        ShowBrowser(0);
        lastBrowsers.Clear();
    }


    public void ShowBrowser(int index)
    {
        for (int i = 0; i < browsers.Length; i++)
        {
            if(browsers[i].activeSelf)
            {
                lastBrowsers.Push(i);
            }
            browsers[i].SetActive(false);
        }
        browsers[index].SetActive(true);
    }

    public void ShowBrowserWithoutBack(int index)
    {
        for (int i = 0; i < browsers.Length; i++)
        {
            browsers[i].SetActive(false);
        }
        browsers[index].SetActive(true);
    }
}
