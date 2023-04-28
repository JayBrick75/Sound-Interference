using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenreManager : MonoBehaviour
{
    public SpriteRenderer Background;
    PlayerManager playerManager;
    PlayerMovement playerMovement;
    public bool isRock = false;

    void Start()
    {
        Background = GetComponent<SpriteRenderer>();

        playerManager = GetComponent<PlayerManager>();

        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (isRock)
        {
            Background.color = Color.red;
            playerMovement.moveSpeed = 7.5f;
            playerMovement.damage = 2;
        }
        if (!isRock)
        {
            Background.color = Color.white;
            playerMovement.moveSpeed = 5.5f;
            playerMovement.damage = 1;
        }
    }
}
