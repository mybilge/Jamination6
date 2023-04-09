using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
    [SerializeField] public AudioClip atisClip;
    [SerializeField] public AudioClip bounceClip;
    [SerializeField] public AudioClip donusumClip;
    [SerializeField] public AudioClip kaybetmeClip;
    [SerializeField] public AudioClip reloadClip;
    [SerializeField] public AudioClip tiklamaClip;


    [SerializeField] AudioSource loopSource;


    public static AudioSourceManager Instance {get;private set;}

    private void Awake() {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }


    public void PlayOneTime(AudioClip audioClip)
    {
        GetComponent<AudioSource>().PlayOneShot(audioClip);
    }

    public void StopLoop()
    {
        loopSource.Stop();
    }
}
