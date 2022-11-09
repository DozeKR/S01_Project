using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1.0f;
    bool isDie = false;

    GameManager instance;
    Rigidbody2D rigid;
    Animator anim;

    float h;
    float v;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        instance = GameManager.Instance;
    }

    void Update()
    {
        MoveSet();
    }

    void FixedUpdate()
    {
        Vector2 dirVec = new Vector2(h, v);
        rigid.velocity = dirVec * speed;
    }

    void MoveSet()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (!isDie)
        {
            //animation
            if (anim.GetInteger("vAxisRaw") != v)
            {
                if (anim.GetInteger("hAxisRaw") != 0 && anim.GetInteger("vAxisRaw") == 0)
                {
                    anim.SetInteger("hAxisRaw", (int)h);
                    anim.SetBool("isChange", false);
                }
                else
                {
                    anim.SetInteger("vAxisRaw", (int)v);
                    anim.SetBool("isChange", true);
                }
            }
            else if (anim.GetInteger("hAxisRaw") != h)
            {
                anim.SetInteger("hAxisRaw", (int)h);
                anim.SetBool("isChange", true);
            }
            else
            {
                anim.SetBool("isChange", false);
            }
        }

    }

    public void die()
    {
        anim.SetBool("isDie", true);

        isDie = true;

        speed = 0;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            instance.hpDown();
            Destroy(other.gameObject);
        }
    }
}
