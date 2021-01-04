using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private float TimeToLive = 3f;
    private float _damage;
    public float EnemyDamage
    {
        get => _damage;
        set => _damage = value;
    }
    
    private void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
    
    void OnTriggerEnter2D(Collider2D collision) // makes the projectiles deal damage
    {
        if (collision.tag != "Enemy")
        {
            Destroy(gameObject);
            if (collision.tag == "Player")
            {
                PlayerStats.playerStats.DealDamage(_damage);
            }
        }
    }
}
