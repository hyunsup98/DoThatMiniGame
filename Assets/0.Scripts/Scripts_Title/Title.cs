using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [Header("������")]
    [SerializeField] private string nextScene;

    [Header("��ġ�ϸ� ����ȭ������ �Ѿ�ٴ� �ȳ� �ؽ�Ʈ")]
    [SerializeField] private TMP_Text text_TouchScreen; //Ÿ��Ʋ �ϴܿ� ���� touch to screen �ؽ�Ʈ
    [SerializeField] private float time;
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;

    private float timer;
    private int dir;

    private void Start()
    {
        timer = 0;
        dir = 1;
    }

    private void Update()
    {
        if(Input.touchCount > 0)
            if (Input.GetTouch(0).phase == TouchPhase.Began)
                SceneManager.LoadScene(nextScene);

        if(Input.GetKeyDown(KeyCode.Mouse0))
            SceneManager.LoadScene(nextScene);

        TextFade();
    }

    private void TextFade()
    {
        timer += dir * Time.deltaTime;

        if (text_TouchScreen.alpha >= maxSize)
            dir = -1;
        else if (text_TouchScreen.alpha <= minSize)
            dir = 1;

        text_TouchScreen.alpha = Mathf.Lerp(minSize, maxSize, timer / time);
    }
}
