using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInfoUI : MonoBehaviour
{
    [Header("게임 정보 변수")]
    [SerializeField] private TMP_Text text_GameName;        //게임 이름 텍스트 변수
    [SerializeField] private TMP_Text text_GameRule;        //게임 설명 텍스트 변수
    private string strSceneName;


    private void Awake()
    {
        text_GameName.text = text_GameRule.text = string.Empty;
        strSceneName = string.Empty;
    }

    public void SetGameInfo(string gameName, string gameRule, string gameScene)
    {
        //게임 정보 세팅
        text_GameName.text = gameName;
        text_GameRule.text = gameRule;
        strSceneName = gameScene;
    }

    public void OnClick_Quit()
    {
        //X 버튼을 클릭하면 이 오브젝트를 꺼줌
        gameObject.SetActive(false);
    }

    public void OnClick_Ranking()
    {
        //랭킹보기 버튼을 클릭하면 랭킹 UI를 띄워줌
    }

    public void OnClick_StartGame()
    {
        //게임시작 버튼을 클릭하면 해당되는 게임의 씬으로 씬 로드
        OnClick_Quit();
        SceneManager.LoadScene(strSceneName);
    }
}
