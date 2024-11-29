using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource BGM;     //배경음악
    public AudioSource Sound;   //효과음

    //배경음악 실행
    public void SetBGM(AudioClip bgm)
    {
        BGM.clip = bgm;
        BGM.Play();

    }

    //효과음 실행
    public void SetSoud(AudioClip sound)
    {
        Sound.clip = sound;
        Sound.PlayOneShot(sound);
    }
}
