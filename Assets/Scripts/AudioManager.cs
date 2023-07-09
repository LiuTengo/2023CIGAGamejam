using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource BGMusicPlayer;
    [HideInInspector]public AudioSource audioSource;
    public List<AudioClip> clips;
    private void Awake()
    {
        if(instance== null)
            instance= this;

        audioSource=GetComponent<AudioSource>();
    }
    private void Start()
    {
        BGMusicPlayer.clip = clips[13];
        BGMusicPlayer.Play();
    }
}
