using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] bool sfxStatusSound;
    [SerializeField] bool musicStatusSound;
    [SerializeField] AudioMixer audioMixer;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
    }
    public void ChangeSFXStatus(bool status)
    {
        if(status)
        audioMixer.SetFloat("sfxVolume",-20);
        else
            audioMixer.SetFloat("sfxVolume", -80);
    }

    public void ChangeMusicStatus(bool status)
    {
        if (status)
            audioMixer.SetFloat("musicVolume", -35);
        else
            audioMixer.SetFloat("musicVolume", -80);
    }
}
