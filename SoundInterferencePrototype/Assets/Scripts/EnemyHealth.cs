using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;

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
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
