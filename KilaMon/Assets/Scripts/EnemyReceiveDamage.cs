﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnemyReceiveDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject Congratulations;
    public GameObject healthbar;
    public Slider healthbarslider;
    public GameObject HealthDropLil;
    public GameObject HealthDropMed;
    public GameObject HealthDropBig;
    const float dropChanceLil = 1f / 2f;
    const float dropChanceMed = 1f / 6f;
    const float dropChanceBig = 1f / 13f;// Set odds here
    public static int aliveCounter = 22;
    
    void Start()
    {
        health = maxHealth;
    }
    

    public void DealDamage(float damage)
    {
        healthbar.SetActive(true);
        healthbarslider.value = CalculateHealth();
        health -= damage;
        CheckDeath();
        healthbarslider.value = CalculateHealth();
    }

    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthbarslider.value = CalculateHealth();
    }

    private void CheckDeath() // Checks for enemy death, and makes loot pop up
    {
        if (health <= 0)
        {
            OnKilled();
            if(Random.Range(0f, 1f) <= dropChanceLil)
            {
                Instantiate(HealthDropLil, transform.position, Quaternion.identity); // spawn a dropped item
            }
            if(Random.Range(0f, 1f) <= dropChanceMed)
            {
                Instantiate(HealthDropMed, transform.position, Quaternion.identity); // spawn a dropped item
            }
            if(Random.Range(0f, 1f) <= dropChanceBig)
            {
                Instantiate(HealthDropBig, transform.position, Quaternion.identity); // spawn a dropped item
            }
            Destroy(gameObject);
        }
    }

    void OnKilled()
    {
        aliveCounter--;

        if (aliveCounter == 0)
        {
            Congratulations.SetActive(true);  //Scene switch when game ended
            
            SceneManager.LoadScene("MainMenu");
            
        }
    }


    private float CalculateHealth()
    {
        return (health / maxHealth);
    }
}