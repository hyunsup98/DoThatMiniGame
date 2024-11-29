using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_AvoidBullet : MonoBehaviour
{
    [Header("몬스터 관련 변수")]
    [SerializeField] private Transform monster;         //투사체를 발사할 몬스터 transform
    [SerializeField] private Transform bulletPos;       //실질적인 발사 위치를 담당하는 transform

    private float delay;
    [SerializeField] private float initDelay;           //initDelay 만큼 텀을 두고 공격 
    [SerializeField] private float reduceDelay;         //한 번 공격할때마다 reduceDelay만큼 텀 줄이기
    [SerializeField] private float minDelay;            //최소 공격 텀(delay minDelay보다 내려가지 않음)

    [Header("총알")]
    [SerializeField] private Bullet_AvoidBullet bullet;

    void Start()
    {
        delay = initDelay;
        StartCoroutine(ShootFromMonster());
    }

    IEnumerator ShootFromMonster()
    {
        //몬스터가 랜덤한 방향으로 투사체를 발사하는 함수
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
        //총알을 오브젝트풀링으로 생성해서 발사하는 함수
        Bullet_AvoidBullet b = BulletPool.Instance.Get(bullet, transform);
        b.SetDir(RandomPos());
        b.transform.position = bulletPos.position;
    }

    private Vector2 RandomPos()
    {
        //총알이 날아갈 방향의 랜덤값을 계산하는 함수
        Vector2 vec = Random.insideUnitCircle.normalized;
        return vec;
    }
}
