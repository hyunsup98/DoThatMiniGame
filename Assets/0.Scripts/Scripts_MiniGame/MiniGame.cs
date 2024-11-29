using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

enum GameType
{
    Timer,          //시간으로 점수 메기는 형식
    LimitTimer,     //제한시간 안에 포인트로 점수 메기는 형식
    Point           //시간없이 포인트로 점수 메기는 형식
}


public class MiniGame : MonoBehaviour
{
    [Header("미니게임 공통규칙")]
    [SerializeField] private GameType gameType;

    [SerializeField] private TMP_Text text_Time;
    [SerializeField] private float limitTime;
    private float time;
    private int min, sec, milliSec;

    [Header("미니게임 점수")]
    private float point;
    public float Point
    {
        get { return point; }
        set { point = value; }
    }


    protected void Init()
    {
        GameStart();
    }

    private void GameStart()
    {
        //게임 시작
        Gamemanager.Instance.ChangeGameState(GameState.PLAY);
        Point = 0;

        if (gameType != GameType.Point)
        {
            min = sec = milliSec = 0;

            if(gameType == GameType.Timer)
            {
                time = 0;
                StartCoroutine(CoCheckTime());
            }
            else
            {
                time = limitTime;
                StartCoroutine(CoCheckLimitTime());
            }
        }
    }

    protected virtual void GameEnd()
    {
        //게임 종료, 점수 저장
        StopAllCoroutines();
        if (gameType == GameType.Timer)
            Point = time;
        Gamemanager.Instance.ChangeGameState(GameState.STOP);
    }

    private IEnumerator CoCheckTime()
    {
        while(true)
        {
            time += Time.unscaledDeltaTime;

            CheckTime(time);
            yield return null;
        }
    }

    private IEnumerator CoCheckLimitTime()
    {
        while (true)
        {
            time -= Time.unscaledDeltaTime;

            CheckTime(time);
            yield return null;
        }
    }

    private void CheckTime(float time)
    {
        //시간을 받으면 00:00 포맷으로 바꿔주는 함수

        min = time >= 60 ? (int)(time / 60) : 0;
        sec = (int)(time % 60);
        milliSec = Mathf.FloorToInt((time - (int)time) * 1000);

        text_Time.text = string.Format("{0:D2}:{1:D2}:{2:D3}", min, sec, milliSec);
    }
}
