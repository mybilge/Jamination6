using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Antivirus : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image spriteInfoImage;

    int counter = 0;


    private void Start() {
        spriteInfoImage.sprite = sprites[0];
    }


    public void CloseAntiVirus()
    {
        MainMenuController.Instance.ShowNormalMainMenu();
    }

    public void Next()
    {
        counter++;
        if(counter >= sprites.Length)
        {
            CloseAntiVirus();
            return;
        }
        spriteInfoImage.sprite = sprites[counter];
    }

    private void OnDisable() {
        counter = 0;
        spriteInfoImage.sprite = sprites[counter];
    }
}
