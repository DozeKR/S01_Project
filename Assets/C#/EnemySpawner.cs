using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    // ����
    public GameObject[] enemys;
    // �÷��̾� ��ġ
    public Transform playerTransform;
    // �ִ�Ÿ�
    public float maxDist = 8f;
    // �ּҰŸ�
    public float minDist = 3f;
    // �����ֱ�
    public float timeSpawnMax = 5f; // �ִ� �ֱ�
    public float timeSpawnMin = 2f; // �ּ� �ֱ�
    public float timeSpawn;
    private float lastSpawn; // ���� �ֱ� ����
    void Start()
    {
        // ���� �ֱ� �ּҿ� �ִ� ���̿��� �����ϰ� �ʱ�ȭ
        timeSpawn = Random.Range(timeSpawnMin, timeSpawnMax);
        lastSpawn = 0;
    }
    void Update()
    {
        if (Time.time >= lastSpawn + timeSpawn)
        {
            // �ֱ� ���� �ð� ����
            lastSpawn = Time.time;
            // �����ֱ� ���� ����
            timeSpawn = Random.Range(timeSpawnMin, timeSpawnMax);

            Spawn();
        }
    }
    void Spawn()
    {
        Vector2 spawnPos = GetRandomPoint(playerTransform.position, maxDist);
        GameObject selectedEnemy = enemys[Random.Range(0, enemys.Length)];
        GameObject enemy = Instantiate(selectedEnemy, spawnPos, Quaternion.identity);
        Enemy es = enemy.GetComponent<Enemy>();
        es.init(playerTransform);
      
    }
    Vector2 GetRandomPoint(Vector2 center, float distance)
    {
        // �߾��� �߽����� �������� maxDist�� �� �ȿ��� ���� ��ġ ����
        // Random.insideUnitCircle�� �������� distance����
        Vector2 randomPos = Random.insideUnitCircle * distance + center;
        return randomPos;
    }

    public void gameover()
    {
        gameObject.SetActive(false);
    }
}
