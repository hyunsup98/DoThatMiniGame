using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    [SerializeField] private string strGameName;
    [Multiline]
    [SerializeField] private string strGameRule;
    [SerializeField] private string strGameSceneName;       //�� ������ �÷����� �� �ִ� ���� �̸� ����

    [SerializeField] private GameInfoUI gameInfoUI;
    public void OnClickIcon()
    {
        //���� ������ Ŭ�� �� �ش� ���� ������ ���� UI�� �Ѱ���
        if (gameInfoUI == null || strGameName == null || strGameRule == null || strGameSceneName == null)
            return;

        gameInfoUI.gameObject.SetActive(true);
        gameInfoUI.SetGameInfo(strGameName, strGameRule, strGameSceneName);
    }
}
