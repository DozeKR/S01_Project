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
        // �ڷ�ƾ ����
        StartCoroutine("attack");
    }

    IEnumerator attack()
    {
        while (true)
        {
            // 1�ʿ� �ѹ��� ����
            attackBullet();
            yield return new WaitForSeconds(1.0f);
        }
    }

    void attackBullet()
    {

        foundEnemys = new List<GameObject>(GameObject.FindGameObjectsWithTag(tagName));
        // Enemy�� ���� ��쿡�� ����
        if (foundEnemys.Count != 0)
        {
            minDist = Vector2.Distance(gameObject.transform.position, foundEnemys[0].transform.position);

            enemy = foundEnemys[0];


            foreach (GameObject foundEnemy in foundEnemys)
            {
                // ���� ������Ʈ�� ��ġ�� �� ��ü�� ��ġ�� ���� �Ÿ��� ������
                float dist = Vector2.Distance(gameObject.transform.position, foundEnemy.transform.position);
                // ���� ����� �ּ� �Ÿ����� ���� �Ÿ��� �� �۴ٸ�
                if (dist < minDist)
                {
                    // �ּ� �Ÿ� ���� �� �ּ� �Ÿ� ��ü ����
                    enemy = foundEnemy;
                    minDist = dist;
                }
            }
            
            
            // �÷��̾�κ��� �� ������ ���� ���ϱ�
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            //enemy.transform.position

            // ���͸� ��������ȭ
            vec.Normalize();

            // ���ͷ� ���� ���ϱ�
            float angle = Vector3.SignedAngle(transform.up, vec, transform.forward);

            // ��ȯ ������ ���ϱ�
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.z = -4;
            // �����ϱ�
            GameObject attBullet = Instantiate(bullet, spawnPos, Quaternion.identity);

            attBullet.transform.Rotate(0, 0, angle + 45);

            attBullet.GetComponent<Rigidbody2D>().velocity = vec * speed;
        }
    }

}
