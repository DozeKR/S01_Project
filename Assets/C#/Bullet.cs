using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameManager instance;

    void Start()
    {
        instance = GameManager.Instance;


        // 3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //����� �Ͼ�� �۾����� GetComponent�� ������� �ʴ� ���� ���ٰ� �˰��ֱ� ������,
            //������Ʈ�� �̸����� �� ��ü�� ������������ �Ѵ�.
            instance.scoreUp(other.gameObject.name);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
