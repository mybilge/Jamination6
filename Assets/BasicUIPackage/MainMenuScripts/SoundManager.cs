using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioMixer audioMixer;


    private void Start() {
        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1f);
            Load();
        }
        else{
            Load();
        }
    }
    public void ChangeVolume()
    {
        audioMixer.SetFloat("volume", volumeSlider.value);
        Save();
    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
}
