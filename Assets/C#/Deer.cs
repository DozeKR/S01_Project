using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    // �÷��̾� ��ġ
    public Transform playerTransform;
    // Enemy ��ġ
    Transform enemyTransform;
    Rigidbody2D enemyRigidbody;
    SpriteRenderer rend;
    public float speed = 3f;
    Vector2 vec;
    bool rotation;
    // �ʱ�ȭ �޼���
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
        // �÷��̾���� ���� ���� ���ϱ�
        vec = playerTransform.position - enemyTransform.position;
        if (vec.x > 0)
        {
            rotation = true;
        }
        else
        {
            rotation = false;
        }
        // ���͸� ��������ȭ ��Ų��.
        vec.Normalize();
    }

    void Move()
    {
        enemyRigidbody.velocity = -vec * speed;
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

