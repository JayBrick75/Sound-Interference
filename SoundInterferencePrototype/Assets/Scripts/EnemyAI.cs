using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int health;
    public float speed;
    public bool enemyPop = false;

    void Start()
    {
        
    }

    void Update()
    {
        //transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (health < 0)
        {
            Destroy(gameObject);
        }

        if (enemyPop)
        {
        
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
