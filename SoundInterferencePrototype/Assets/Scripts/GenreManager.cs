using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenreManager : MonoBehaviour
{
    public SpriteRenderer Background;
    PlayerManager playerManager;
    PlayerMovement playerMovement;
    EnemyAI enemyAI;
    public bool isRock = false;
    public bool isPop = false;

    void Start()
    {
        Background = GetComponent<SpriteRenderer>();

        playerManager = GetComponent<PlayerManager>();

        playerMovement = GetComponent<PlayerMovement>();

        enemyAI = GetComponent<EnemyAI>();
    }

    void Update()
    {
        if (!isRock || !isPop)
        {
            Background.color = Color.white;
            playerMovement.moveSpeed = 5.5f;
            playerMovement.damage = 1;
        }
        if (isRock)
        {
            Background.color = Color.red;
            playerMovement.moveSpeed = 7.5f;
            playerMovement.damage = 2;
        }
        if (isPop)
        {
            Background.color = Color.magenta;
            playerMovement.moveSpeed = 6.0f;
            enemyAI.enemyPop = true;
        }
    }
}
