using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_AvoidBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private float disableTime;
    private Vector2 dir;

    private void Start()
    {
        Invoke("Take", disableTime);
    }

    private void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime, Space.World); //절대좌표 기준으로 이동
        transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
    }

    public void SetDir(Vector2 vec)
    {
        dir = vec;
    }

    private void Take()
    {
        BulletPool.Instance.Take(this);
    }
}
