using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spell : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float minDamage;
    [SerializeField] float maxDamage;
    [SerializeField] float projectileForce;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Spells/PlayerSpell");
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos).normalized;
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            projectile.GetComponent<Projectile>().Damage = Random.Range(minDamage, maxDamage);
        }
    }

}    
