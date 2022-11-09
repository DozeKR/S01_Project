using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    // 몬스터
    public GameObject[] enemys;
    // 플레이어 위치
    public Transform playerTransform;
    // 최대거리
    public float maxDist = 8f;
    // 최소거리
    public float minDist = 3f;
    // 스폰주기
    public float timeSpawnMax = 5f; // 최대 주기
    public float timeSpawnMin = 2f; // 최소 주기
    public float timeSpawn;
    private float lastSpawn; // 가장 최근 생성
    void Start()
    {
        // 생성 주기 최소와 최대 사이에서 랜덤하게 초기화
        timeSpawn = Random.Range(timeSpawnMin, timeSpawnMax);
        lastSpawn = 0;
    }
    void Update()
    {
        if (Time.time >= lastSpawn + timeSpawn)
        {
            // 최근 생성 시간 갱신
            lastSpawn = Time.time;
            // 생성주기 랜덤 변경
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
        // 중앙을 중심으로 반지름이 maxDist인 원 안에서 랜덤 위치 저장
        // Random.insideUnitCircle은 반지름이 distance에서
        Vector2 randomPos = Random.insideUnitCircle * distance + center;
        return randomPos;
    }

    public void gameover()
    {
        gameObject.SetActive(false);
    }
}
