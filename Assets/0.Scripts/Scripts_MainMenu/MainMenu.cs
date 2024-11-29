using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip bgmClip;

    [SerializeField] private GameInfoUI gameInfoUI;


    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.SetBGM(bgmClip);
    }

    public void SetGameInfo()
    {
        //icon���� �޾ƿ� ������ �̿��� 
    }
}
