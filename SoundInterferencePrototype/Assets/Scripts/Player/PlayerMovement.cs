using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public int maxJumpCount = 1;
    private Rigidbody2D rb;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int jumpCount;
    private bool facingRight = true;
    public Animator animator;
    public PlayerManager playerManager;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask whatIsEnemies;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public int damage;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        jumpCount = maxJumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        Animate();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }
        Move();
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isGrounded = false;
            jumpCount = 0;
        }
        isJumping = false;
    }
    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
            jumpCount--;
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
        if (Input.GetKeyDown(KeyCode.E) && timeBtwAttack <= 0)
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, whatIsEnemies);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);

            foreach (Collider2D enemy in enemiesToDamage)
            {
                Debug.Log("Hit " + enemy.name);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = col.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Level 1 Ending")
        {
            transform.position = new Vector2(157.9f, 34.82f);
            playerManager.playerHealth = 7;
            Debug.Log("Level 2, Health Reset");
        }
        if (collision.gameObject.tag == "Level 2 Ending")
        {
            transform.position = new Vector2(-146.7f, -89.65f);
            playerManager.playerHealth = 7;
            Debug.Log("Level 3, Health Reset");
        }
        if (collision.gameObject.tag == "Barrier 1")
        {
            transform.position = new Vector2(-97.54f, 16.5f);
        }
        if (collision.gameObject.tag == "Barrier 2")
        {
            transform.position = new Vector2(157.9f, 34.82f);
        }
        if (collision.gameObject.tag == "Barrier 3")
        {
            transform.position = new Vector2(-146.7f, -89.65f);
        }
    }
}