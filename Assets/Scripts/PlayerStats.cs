using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    private GameObject player;
    [SerializeField] Text healthtext;
    [SerializeField] Slider healthSlider;
    [SerializeField] float health;
    [SerializeField] float maxHealth;
    public bool GameIs = true;

    void Awake()
    {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
             playerStats = this;
        }
        
    }
    void Start()
    {
        health = maxHealth;
        healthSlider.value = 1;
        ShowHealth();

    }

    public void DealDamage(float damage)
    {
        health -= damage;
        ShowHealth();
        CheckDeath();
       FMODUnity.RuntimeManager.PlayOneShot("event:/Hurt/PlayerHurt");
        healthSlider.value = CalculateHealth();    

    }

    public void ShowHealth()
    {
        healthSlider.value = CalculateHealth();
        healthtext.text = Mathf.Ceil(health).ToString() + "/" + Mathf.Ceil(maxHealth).ToString();  
    }
    

    public void HealCharacter(float heal)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/HEAL/HEAL");
        health += heal;
        CheckOverheal();
        ShowHealth();
    }
    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }
    
    private void CheckDeath()
    {
        if (health <= 0)
        {
            health = 0;
            Destroy(player);
            SceneManager.LoadScene("Level01");
            EnemyReceiveDamage.aliveCounter = 25;
        }
    }
}
