using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRun : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    BossAI bossAI;
    public float attackRange = 2f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb = animator.GetComponent<Rigidbody2D>();

        bossAI = animator.GetComponent<BossAI>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossAI.LookAtPlayer();

        // declare and set the player to a target variable
        Vector2 target = new Vector2(player.position.x, rb.position.y);

        // set the new position for our boss to move to
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, bossAI.speed * Time.deltaTime);

        // tell our boss's rb to move to the new position
        rb.MovePosition(newPos);

        float distance = Vector2.Distance(player.position, rb.position);

        if (distance < bossAI.attackRange && !bossAI.phase2)
        {
            Debug.Log("Projectile Shot");
            animator.SetTrigger("Attack");
        }
        else if (distance < bossAI.attackRange && bossAI.phase2)
        {
            animator.SetTrigger("Phase2Attack");
        }
        else if (bossAI.isDead)
        {
            animator.SetTrigger("Death");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
