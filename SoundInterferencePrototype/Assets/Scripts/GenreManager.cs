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
    public bool isEpic = false;
    public bool isJazz = false;
    public bool isElectronic = false;

    void Start()
    {
        Background = GetComponent<SpriteRenderer>();

        playerManager = GetComponent<PlayerManager>();

        playerMovement = GetComponent<PlayerMovement>();

        enemyAI = GetComponent<EnemyAI>();
    }

    void Update()
    {
        if (isRock)
        {
            Background.color = Color.red;
            playerMovement.moveSpeed = 7.5f;
            playerMovement.damage = 2;
            playerMovement.maxJumpCount = 2;
            isPop = false;
            isEpic = false;
            isJazz = false;
            isElectronic = false;
        }
        if (isPop)
        {
            Background.color = Color.magenta;
            playerMovement.moveSpeed = 6.0f;
            playerMovement.damage = 1;
            isRock = false;
            isEpic = false;
            isJazz = false;
            isElectronic = false;
        }
        if (isJazz)
        {
            Background.color = Color.blue;
            playerMovement.moveSpeed = 4.5f;
            playerMovement.damage = 1;
            playerMovement.maxJumpCount = 2;
            isRock = false;
            isPop = false;
            isEpic = false;
            isElectronic = false;
        }
        if (isElectronic)
        {
            Background.color = Color.green;
            isRock = false;
            isPop = false;
            isJazz = false;
            isEpic = false;
        }
        if (isEpic)
        {
            Background.color = Color.yellow;
            playerMovement.moveSpeed = 5.5f;
            playerMovement.damage = 1;
            playerMovement.maxJumpCount = 2;
            isRock = false;
            isPop = false;
            isJazz = false;
            isElectronic = false;
        }
    }
}
