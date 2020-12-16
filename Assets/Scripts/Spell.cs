using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spell : ScriptableObject
{
    [SerializeField] Projectile projectilePrefab;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
           var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
           Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           Vector2 myPos = transform.position;
           Vector2 direction = (mousePos - myPos).normalized;
           spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
           spell.GetComponent<Projectile>().Damage = Random.Range(minDamage, maxDamage);
        }
    }
}
