using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FirstOpenMenuController : MonoBehaviour
{
    [SerializeField]  TMP_InputField usernameInputField;
    [SerializeField] TextMeshProUGUI warningText;
    [SerializeField] Button startBtn;


    public void DevamEtButonuOnClick()
    {
        string usernameText = usernameInputField.text;

        if(usernameText.Length <3 || usernameText.Length > 10)
        {
            warningText.text = "Kullanıcı adı 3-10 karakter uzunluğunda olmalıdır.";
            usernameInputField.text = "";
            return;
        }
        else if(usernameText.Contains(" ") || usernameText.Contains("\n") || usernameText.Contains("\t") || usernameText.Contains("\r") || usernameText.Contains("*"))
        {
            warningText.text = "Kullanıcı adı boşluk veya '*' karakteri içermemelidir.";
            usernameInputField.text = "";
            return;
        }

        bool isUsernameAlreadyExists = false;
    

        foreach (var item in HighScores.Instance.highscoreArray)
        {
            Debug.Log(item.username);
            if(usernameText == item.username)
            {
                isUsernameAlreadyExists = true;
                break;
            }
        }

        if(isUsernameAlreadyExists)
        {
            warningText.text = "Bu kullanıcı adı zaten alınmış";
            usernameInputField.text = "";
            return;
        }

        else{
            PlayerPrefs.SetInt("FirstTime", 1);
            PlayerPrefs.SetString("Username", usernameText);
            MainMenuController.Instance.ShowNormalMainMenu();
            HighScores.AddNewHighScore(usernameText,0);
        }        
    }
}
