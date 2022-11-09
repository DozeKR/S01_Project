using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpanwer : MonoBehaviour
{
    List<GameObject> foundEnemys;
    GameObject enemy;
    public GameObject bullet;
    public string tagName = "Enemy";
    float minDist;
    public float speed = 3f;



    void Start()
    {
        // 코루틴 시작
        StartCoroutine("attack");
    }

    IEnumerator attack()
    {
        while (true)
        {
            // 1초에 한번씩 수행
            attackBullet();
            yield return new WaitForSeconds(1.0f);
        }
    }

    void attackBullet()
    {

        foundEnemys = new List<GameObject>(GameObject.FindGameObjectsWithTag(tagName));
        // Enemy가 있을 경우에만 수행
        if (foundEnemys.Count != 0)
        {
            minDist = Vector2.Distance(gameObject.transform.position, foundEnemys[0].transform.position);

            enemy = foundEnemys[0];


            foreach (GameObject foundEnemy in foundEnemys)
            {
                // 현재 오브젝트의 위치와 적 개체의 위치를 통해 거리를 얻어오기
                float dist = Vector2.Distance(gameObject.transform.position, foundEnemy.transform.position);
                // 현재 저장된 최소 거리보다 지금 거리가 더 작다면
                if (dist < minDist)
                {
                    // 최소 거리 저장 및 최소 거리 객체 저장
                    enemy = foundEnemy;
                    minDist = dist;
                }
            }
            
            
            // 플레이어로부터 적 까지의 벡터 구하기
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            //enemy.transform.position

            // 벡터를 단위벡터화
            vec.Normalize();

            // 벡터로 각도 구하기
            float angle = Vector3.SignedAngle(transform.up, vec, transform.forward);

            // 소환 포지션 정하기
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.z = -4;
            // 생성하기
            GameObject attBullet = Instantiate(bullet, spawnPos, Quaternion.identity);

            attBullet.transform.Rotate(0, 0, angle + 45);

            attBullet.GetComponent<Rigidbody2D>().velocity = vec * speed;
        }
    }

}
