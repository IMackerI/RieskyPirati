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

    public float delay;
    public float damageVariation;

    PlayerDisplay playerDisplay;

    public void Reset()
    {
        Destroy(rPlayer);

        health = 100;
        maxHealth = 100;
        attack = 10;
        coins = 100;
        isDead = false;
    }

    public void SetActive(bool active)
    {
        rPlayer.SetActive(active);
    }

    public void Summon()
    {
        rPlayer = Instantiate(rPlayerPrefab);
        isDead = false;
        playerDisplay = rPlayer.GetComponent<PlayerDisplay>();
        SetActive(false);
    }

    public void Attack()
    {
        playerDisplay.Attack();
        enemy.GetComponent<LPlayerManager>().TakeDamage(attack);
    }

    public void TakeDamage(int damage)
    {
        health -= (int)(Random.Range((1f - damageVariation) * damage, (1f + damageVariation) * damage));
        StartCoroutine(SetHealthDelay(health, delay));
        if (health <= 0)
        {
            health = 0;
            isDead = true;
        }
        Debug.Log("Health R: " + health);
    }

    IEnumerator SetHealthDelay(int health, float delay)
    {
        yield return new WaitForSeconds(delay);
        SetHealth(health);
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
        playerDisplay.SetHealth(health);
    }
    public void SetMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        playerDisplay.SetMaxHealth(maxHealth);
    }
    public void SetAttack(int newAttack)
    {
        attack = newAttack;
        playerDisplay.SetAttack(attack);
    }
    public void SetMaxAttack(int newMaxAttack)
    {
        playerDisplay.SetMaxAttack(newMaxAttack);
    }
    public void SetCoins(int newCoins)
    {
        coins = newCoins;
        playerDisplay.SetCoins(coins);
    }
    public void SetMaxCoins(int newMaxCoins)
    {
        playerDisplay.SetMaxCoins(newMaxCoins);
    }
}
