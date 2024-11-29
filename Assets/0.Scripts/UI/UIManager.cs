using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//��� ���� �ִ� ���� UI�� ����ϴ� UI��ũ��Ʈ
public class UIManager : Singleton<UIManager>
{
    [Header("�̴ϰ��� ���ھ� ���� ���� ����")]
    [SerializeField] private GameObject objScoreBoard;  //���ھ�� ������Ʈ
    [SerializeField] private TMP_Text textScore;        //������ ������ text
    [SerializeField] private string string_MainMenu;    //�ڷΰ��� ��ư�� ������ �� ���� �̸�

    public void OnOffScoreBoard()
    {
        if (objScoreBoard != null)
            objScoreBoard.SetActive(!objScoreBoard.activeSelf);
    }

    public void OnClickBack()
    {
        //���ھ�忡�� �ڷΰ��� ��ư�� ������ �� �Լ�
        SceneManager.LoadScene(string_MainMenu);
    }

    public void OnClickRetry()
    {
        //���ھ�忡�� ����� ��ư�� ������ �� �Լ�

    }
}
