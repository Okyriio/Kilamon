using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public enum PickUp // Different health item size
    {
        Lil,
        Medium,
        Big
    };

    public PickUp healthObject;

    private void OnTriggerEnter2D(Collider2D other) //health the player
    {
        if (other.name == "Player")
        {
            if (healthObject == PickUp.Lil)
            {
                PlayerStats.playerStats.HealCharacter(10);
            }
            if (healthObject == PickUp.Medium)
            {
                PlayerStats.playerStats.HealCharacter(30);
            }
            if (healthObject == PickUp.Big)
            {
                PlayerStats.playerStats.HealCharacter(50);
            }
            Destroy(gameObject);
        }
    }
}
