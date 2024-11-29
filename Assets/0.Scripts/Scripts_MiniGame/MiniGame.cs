using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

enum GameType
{
    Timer,          //�ð����� ���� �ޱ�� ����
    LimitTimer,     //���ѽð� �ȿ� ����Ʈ�� ���� �ޱ�� ����
    Point           //�ð����� ����Ʈ�� ���� �ޱ�� ����
}


public class MiniGame : MonoBehaviour
{
    [Header("�̴ϰ��� �����Ģ")]
    [SerializeField] private GameType gameType;

    [SerializeField] private TMP_Text text_Time;
    [SerializeField] private float limitTime;
    private float time;
    private int min, sec, milliSec;

    [Header("�̴ϰ��� ����")]
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
        //���� ����
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
        //���� ����, ���� ����
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
        //�ð��� ������ 00:00 �������� �ٲ��ִ� �Լ�

        min = time >= 60 ? (int)(time / 60) : 0;
        sec = (int)(time % 60);
        milliSec = Mathf.FloorToInt((time - (int)time) * 1000);

        text_Time.text = string.Format("{0:D2}:{1:D2}:{2:D3}", min, sec, milliSec);
    }
}
