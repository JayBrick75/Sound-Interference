using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    Transform player;
    PlayerManager playerManager;
    public bool isFlipped;
    public int bossHealth;
    public bool phase2 = false;
    public bool isDead = false;
    public int attackRange;
    public float speed;
    public Transform shotLocation;
    public Transform shotLocation2;
    public float timer;
    public float cooldown;
    public float jumpForce;
    public GameObject projectile;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (bossHealth < 6 && bossHealth > 0)
        {
            phase2 = true;
            attackRange = 6;
            speed = 3.5f;
            Debug.Log("Phase2");
        }
        else if (bossHealth <= 0)
        {
            phase2 = false;
            isDead = true;
            Destroy(gameObject);
            Debug.Log("The boss died :D");
        }

        timer += Time.deltaTime;
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
        if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
    }

    public void ProjectileShoot()
    {
        if (timer > cooldown)
        {
            GameObject clone = Instantiate(projectile, shotLocation.position, transform.rotation);
            timer = 0;
        }
        //if (timer > cooldown && phase2)
        //{
            //GameObject clone = Instantiate(projectile, shotLocation2.position, transform.rotation);
        //}
    }
    public void ProjectileSlam()
    {
        if (phase2 && timer > cooldown)
       {
            rb.AddForce(new Vector2(0f, jumpForce));
            timer = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        bossHealth -= damage;
    }
}
