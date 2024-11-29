using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    [SerializeField] private string strGameName;
    [Multiline]
    [SerializeField] private string strGameRule;
    [SerializeField] private string strGameSceneName;       //이 게임을 플레이할 수 있는 씬의 이름 변수

    [SerializeField] private GameInfoUI gameInfoUI;
    public void OnClickIcon()
    {
        //게임 아이콘 클릭 시 해당 게임 정보를 시작 UI에 넘겨줌
        if (gameInfoUI == null || strGameName == null || strGameRule == null || strGameSceneName == null)
            return;

        gameInfoUI.gameObject.SetActive(true);
        gameInfoUI.SetGameInfo(strGameName, strGameRule, strGameSceneName);
    }
}
