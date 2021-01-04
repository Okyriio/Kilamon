using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _damage;
    private const float TimeToLive = 3f;

    public float Damage
    {
        get => _damage;
        set => _damage = value;
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
                collision.GetComponent<EnemyReceiveDamage>().DealDamage(_damage);
            }
            
        }
    }
}
