using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LPlayerManager : MonoBehaviour
{
    public GameObject lPlayerPrefab;
    public GameObject lPlayer;
    public GameObject enemy;

    public int health = 100;
    public int maxHealth = 100;
    public int attack = 10;
    public int coins = 100;
    public bool isDead = false;

    public void WinCoins()
    {
        GameObject winText = GameObject.Find("WinAmmount");
        int enemyCoins = enemy.GetComponent<RPlayerManager>().coins;

        //TODO fancy function
        coins += enemyCoins;

        winText.GetComponent<Text>().text = "" + coins;
    }
    public void LoseCoins()
    {
        GameObject loseText = GameObject.Find("LoseAmmount");
        int enemyCoins = enemy.GetComponent<RPlayerManager>().coins;

        coins = Mathf.Max(coins - enemyCoins, coins/2);

        loseText.GetComponent<Text>().text = "" + coins;
    }

    public void Reset()
    {
        Destroy(lPlayer);

        health = 100;
        maxHealth = 100;
        attack = 10;
        coins = 100;
        isDead = false;
    }
    
    public void Summon()
    {
        lPlayer = Instantiate(lPlayerPrefab);
        isDead = false;
    }

    public void Attack()
    {
        enemy.GetComponent<RPlayerManager>().TakeDamage(attack);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            isDead = true;
        }
        Debug.Log("Health L: " + health);
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
