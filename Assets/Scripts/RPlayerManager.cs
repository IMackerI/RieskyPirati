using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPlayerManager : MonoBehaviour
{
    public GameObject rPlayerPrefab;
    public GameObject rPlayer;
    public GameObject enemy;

    public int health = 100;
    public int maxHealth = 100;
    public int attack = 10;
    public int coins = 100;
    public bool isDead = false;

    public void Reset()
    {
        Destroy(rPlayer);

        health = 100;
        maxHealth = 100;
        attack = 10;
        coins = 100;
        isDead = false;
    }

    public void Summon()
    {
        rPlayer = Instantiate(rPlayerPrefab);
        isDead = false;
    }

    public void Attack()
    {
        enemy.GetComponent<LPlayerManager>().TakeDamage(attack);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            isDead = true;
        }
        Debug.Log("Health R: " + health);
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }
    public void SetMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
    }
    public void SetAttack(int newAttack)
    {
        attack = newAttack;
    }
    public void SetCoins(int newCoins)
    {
        coins = newCoins;
    }
}
