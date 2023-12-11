using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public int levelMusic;
    public static AudioManager instance;
    public AudioSource[] music;
    public AudioSource[] sfx;
    public AudioMixerGroup musicMixer, sfxMixer;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PlayMusic(2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopMusic()
    {
        music[2].Stop();
    }

    public void PlayMusic(int musicToPlay)
    {
        // for(int i = 0; i < music.Length; i++){
        //     music[i].Stop();
        // }

        music[musicToPlay].Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }

    public void SetMusicLevel()
    {
        musicMixer.audioMixer.SetFloat("MusicVol", UIManager.instance.musicVolumeSlider.value);
    }

    public void SetSFXLevel()
    {
        sfxMixer.audioMixer.SetFloat("SFXVol", UIManager.instance.sfxVolumeSlider.value);
    }
}
