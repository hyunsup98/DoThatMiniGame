using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_AvoidBullet : MonoBehaviour
{
    [Header("���� ���� ����")]
    [SerializeField] private Transform monster;         //����ü�� �߻��� ���� transform
    [SerializeField] private Transform bulletPos;       //�������� �߻� ��ġ�� ����ϴ� transform

    private float delay;
    [SerializeField] private float initDelay;           //initDelay ��ŭ ���� �ΰ� ���� 
    [SerializeField] private float reduceDelay;         //�� �� �����Ҷ����� reduceDelay��ŭ �� ���̱�
    [SerializeField] private float minDelay;            //�ּ� ���� ��(delay minDelay���� �������� ����)

    [Header("�Ѿ�")]
    [SerializeField] private Bullet_AvoidBullet bullet;

    void Start()
    {
        delay = initDelay;
        StartCoroutine(ShootFromMonster());
    }

    IEnumerator ShootFromMonster()
    {
        //���Ͱ� ������ �������� ����ü�� �߻��ϴ� �Լ�
        while (true)
        {
            Shoot();

            yield return new WaitForSeconds(delay);
            delay -= reduceDelay;
            delay = Mathf.Clamp(delay, minDelay, initDelay);

        }
    }

    private void Shoot()
    {
        //�Ѿ��� ������ƮǮ������ �����ؼ� �߻��ϴ� �Լ�
        Bullet_AvoidBullet b = BulletPool.Instance.Get(bullet, transform);
        b.SetDir(RandomPos());
        b.transform.position = bulletPos.position;
    }

    private Vector2 RandomPos()
    {
        //�Ѿ��� ���ư� ������ �������� ����ϴ� �Լ�
        Vector2 vec = Random.insideUnitCircle.normalized;
        return vec;
    }
}
