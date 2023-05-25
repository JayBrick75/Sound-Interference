using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GenreManager genreManager;
    public int coinCount;
    public int playerHealth = 7;

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
            Destroy(gameObject);
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
                genreManager.isPop = false;
                Debug.Log("Rock Got");
                return true;
            case "Rock Key":
                genreManager.isRock = true;
                genreManager.isPop = false;
                Debug.Log("Rock Key Got");
                GameObject.FindGameObjectWithTag("Rock Door").SetActive(false);
                return true;
            case "Rock Key 2":
                genreManager.isRock = true;
                genreManager.isJazz = false;
                genreManager.isElectronic = false;
                Debug.Log("Rock Key 2 Got");
                GameObject.FindGameObjectWithTag("Rock Door 2").SetActive(false);
                GameObject.FindGameObjectWithTag("Rock Door 2").SetActive(false);
                return true;
            case "Pop":
                genreManager.isPop = true;
                genreManager.isRock = false;
                Debug.Log("Pop Got");
                return true;
            case "Pop Key":
                genreManager.isPop = true;
                genreManager.isRock = false;
                Debug.Log("Pop Key Got");
                GameObject.FindGameObjectWithTag("Pop Door").SetActive(false);
                return true;
            case "Epic":
                genreManager.isEpic = true;
                genreManager.isJazz = false;
                genreManager.isRock = false;
                Debug.Log("Epic Got");
                return true;
            case "Jazz":
                genreManager.isJazz = true;
                genreManager.isRock = false;
                genreManager.isElectronic = false;
                Debug.Log("Jazz Got");
                GameObject.FindGameObjectWithTag("Jazz Door").SetActive(false);
                GameObject.FindGameObjectWithTag("Jazz Door").SetActive(false);
                GameObject.FindGameObjectWithTag("Jazz Door").SetActive(false);
                return true;
            case "Electronic":
                genreManager.isElectronic = true;
                genreManager.isRock = false;
                Debug.Log("Electronic Got");
                GameObject.FindGameObjectWithTag("ElectricPlatform").SetActive(false);
                GameObject.FindGameObjectWithTag("ElectricPlatform").SetActive(false);
                GameObject.FindGameObjectWithTag("ElectricPlatform").SetActive(false);
                GameObject.FindGameObjectWithTag("ElectricPlatform").SetActive(false);
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
            Debug.Log("Player Damaged");
        }
    }
}
