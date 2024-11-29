using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//모든 씬에 있는 공통 UI를 담당하는 UI스크립트
public class UIManager : Singleton<UIManager>
{
    [Header("미니게임 스코어 보드 관련 변수")]
    [SerializeField] private GameObject objScoreBoard;  //스코어보드 오브젝트
    [SerializeField] private TMP_Text textScore;        //점수를 보여줄 text
    [SerializeField] private string string_MainMenu;    //뒤로가기 버튼을 눌러서 갈 씬의 이름

    public void OnOffScoreBoard()
    {
        if (objScoreBoard != null)
            objScoreBoard.SetActive(!objScoreBoard.activeSelf);
    }

    public void OnClickBack()
    {
        //스코어보드에서 뒤로가기 버튼을 눌렀을 때 함수
        SceneManager.LoadScene(string_MainMenu);
    }

    public void OnClickRetry()
    {
        //스코어보드에서 재시작 버튼을 눌렀을 때 함수

    }
}
