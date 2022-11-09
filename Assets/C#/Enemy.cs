using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 플레이어 위치
    public Transform playerTransform;
    // Enemy 위치
    Transform enemyTransform;
    Rigidbody2D enemyRigidbody;
    SpriteRenderer rend;
    public float speed = 3f;
    Vector2 vec;
    bool rotation;
    // Enemy 종류
    public bool attack;
    // 초기화 메서드
    public void init(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
    }

    void Start()
    {
        enemyTransform = GetComponent<Transform>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoveSet();
    }

    void FixedUpdate()
    {
        Move();
    }
    void MoveSet()
    {
        // 플레이어로의 방향 벡터 구하기
        vec = playerTransform.position - enemyTransform.position;
        if (attack)
        {
            if (vec.x < 0)
            {
                rotation = true;
            }
            else
            {
                rotation = false;
            }
        }
        else
        {
            if (vec.x > 0)
            {
                rotation = true;
            }
            else
            {
                rotation = false;
            }
        }
   
        // 벡터를 단위벡터화 시킨다.
        vec.Normalize();
    }

    void Move()
    {
        if(attack)
        {
            enemyRigidbody.velocity = vec * speed;
        }
        else
        {
            enemyRigidbody.velocity = -vec * speed;
        }
        if (!rotation)
        {
            rend.flipX = true;
        }
        else
        {
            rend.flipX = false;
        }
    }
}
