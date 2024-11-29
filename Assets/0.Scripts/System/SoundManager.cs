using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource BGM;     //�������
    public AudioSource Sound;   //ȿ����

    //������� ����
    public void SetBGM(AudioClip bgm)
    {
        BGM.clip = bgm;
        BGM.Play();

    }

    //ȿ���� ����
    public void SetSoud(AudioClip sound)
    {
        Sound.clip = sound;
        Sound.PlayOneShot(sound);
    }
}
