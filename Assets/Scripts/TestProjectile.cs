using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage_;
    private const float TimeToLive = 3f;

    public float Damage
    {
        get => damage_;
        set => damage_ = value;
    }

    private void Start()
    {
        transform.Rotate(0, 0, -90);
        Destroy(gameObject, TimeToLive);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            if (collision.GetComponent<EnemyReceiveDamage>() != null)
            {
                collision.GetComponent<EnemyReceiveDamage>().DealDamage(damage_);
            }
            
        }
    }
}
