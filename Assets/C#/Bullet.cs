using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameManager instance;

    void Start()
    {
        instance = GameManager.Instance;


        // 3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //빈번히 일어나는 작업에는 GetComponent를 사용하지 않는 것이 좋다고 알고있기 때문에,
            //오브젝트의 이름으로 적 개체를 구분지으려고 한다.
            instance.scoreUp(other.gameObject.name);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
