using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShooting : EnemyAttack
{
    [SerializeField] GameObject projectile;
    [SerializeField] float minDamage;
    [SerializeField] float maxDamage;
    [SerializeField] float ProjectileForce;
    [SerializeField] float cooldown;
    void Start() // Projectile follows the player 
    {
        StartCoroutine(ShootPlayer());
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    IEnumerator ShootPlayer() // Projectile movement, speed
    {
        yield return new WaitForSeconds(cooldown);
        if (player != null)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Spells/EnemySpell");
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.transform.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * ProjectileForce;
            spell.GetComponent<EnemyProjectile>().EnemyDamage = Random.Range(minDamage, maxDamage);
            StartCoroutine(ShootPlayer());
        }
        
    }
}
