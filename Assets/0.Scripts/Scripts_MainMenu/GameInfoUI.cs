using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInfoUI : MonoBehaviour
{
    [Header("���� ���� ����")]
    [SerializeField] private TMP_Text text_GameName;        //���� �̸� �ؽ�Ʈ ����
    [SerializeField] private TMP_Text text_GameRule;        //���� ���� �ؽ�Ʈ ����
    private string strSceneName;


    private void Awake()
    {
        text_GameName.text = text_GameRule.text = string.Empty;
        strSceneName = string.Empty;
    }

    public void SetGameInfo(string gameName, string gameRule, string gameScene)
    {
        //���� ���� ����
        text_GameName.text = gameName;
        text_GameRule.text = gameRule;
        strSceneName = gameScene;
    }

    public void OnClick_Quit()
    {
        //X ��ư�� Ŭ���ϸ� �� ������Ʈ�� ����
        gameObject.SetActive(false);
    }

    public void OnClick_Ranking()
    {
        //��ŷ���� ��ư�� Ŭ���ϸ� ��ŷ UI�� �����
    }

    public void OnClick_StartGame()
    {
        //���ӽ��� ��ư�� Ŭ���ϸ� �ش�Ǵ� ������ ������ �� �ε�
        OnClick_Quit();
        SceneManager.LoadScene(strSceneName);
    }
}
