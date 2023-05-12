using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GenreManager genreManager;
    public int coinCount;
    public int playerHealth;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        genreManager = GetComponent<GenreManager>();
    }
    private void Update()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("Player has died");
            // Player Death
        }
    }
    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Coin":
                coinCount++;
                return true;
            case "Rock":
                genreManager.isRock = true;
                Debug.Log("Rock Got");
                return true;
            case "Pop":
                genreManager.isPop = true;
                Debug.Log("Pop Got");
                return true;
            case "Epic":
                genreManager.isEpic = true;
                Debug.Log("Epic Got");
                return true;
            case "Jazz":
                genreManager.isEpic = true;
                Debug.Log("Jazz Got");
                return true;
            case "Electronic":
                genreManager.isEpic = true;
                Debug.Log("Electronic Got");
                return true;
            case "Key":
                Destroy(GameObject.FindGameObjectWithTag("Door"));
                return true;
            default:
                Debug.Log("No tag on this game object");
                return false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike" || collision.gameObject.tag == "Enemy")
        {
            playerHealth -= 1;
        }
    }
}
