using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyProjectile : MonoBehaviour
{
    public float damage;
    public float TimeToLive = 3f;
    private void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
    
    void OnTriggerEnter2D(Collider2D collision) // makes the projectiles deal damage
    {
        if (collision.tag != "Enemy")
        {
            if (collision.tag == "Player")
            {
                PlayerStats.playerStats.DealDamage(damage);
            }
        }
    }
}
