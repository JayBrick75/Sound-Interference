using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileAI : MonoBehaviour
{
    Transform player;
    Transform boss;
    Vector2 shotDirection;
    Rigidbody2D rb;
    public float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GameObject.FindGameObjectWithTag("Boss").transform;
        rb = GetComponent<Rigidbody2D>();

        if (boss.position.x >= player.position.x)
        {
            shotDirection = new Vector2(-1, 0);
        }
        else
        {
            shotDirection = new Vector2(1, 0);
        }
    }

    void FixedUpdate()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Boss")
        {
            Destroy(gameObject);
        }
    }
}
