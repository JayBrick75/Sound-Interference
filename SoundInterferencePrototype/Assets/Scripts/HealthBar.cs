using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public PlayerManager playerManager;
    private TextMeshProUGUI healthText;

    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        healthText = GetComponent<TextMeshProUGUI>();
        healthText.text = "Health : " + playerManager.playerHealth;
    }
}
