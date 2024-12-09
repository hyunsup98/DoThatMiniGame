using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AvoidBullet : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float speed;
    private float angle;
    private float dir;

    private void Start()
    {
        dir = 1;
        angle = 4.7f;
    }

    private void Update()
    {
        angle += speed * dir * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.position = new Vector2(x, y);

        /*
        if (Input.touchCount > 0)
            if (Input.GetTouch(0).phase == TouchPhase.Began)
                dir *= -1;
        */

        if (Input.GetMouseButtonDown(0))
            dir *= -1;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            UIManager.Instance.OnOffScoreBoard();
            Debug.Log("Ãæµ¹");
        }
    }
}
