using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LPlayerManager : MonoBehaviour
{
    public GameObject lPlayerPrefab;
    public GameObject lPlayer;
    public GameObject enemy;

    public Sprite[ ] images;
    public int health = 100;
    public int maxHealth = 100;
    public int attack = 10;
    public int coins = 100;
    public bool isDead = false;
    public float delay;
    public float stretchRewardFunction;
    public float damageVariation;

    PlayerDisplay playerDisplay;

    public void WinCoins()
    {
        GameObject winText = GameObject.Find("WinAmmount");
        int enemyCoins = enemy.GetComponent<RPlayerManager>().coins;

        coins += (int)(-System.Math.Tanh((float)((coins - enemyCoins) / (enemyCoins * stretchRewardFunction)-1.3f)) * enemyCoins + enemyCoins)/2;

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

    public void SetActive(bool active)
    {
        lPlayer.SetActive(active);
    }

    public void Summon()
    {
        lPlayer = Instantiate(lPlayerPrefab);
        isDead = false;
        playerDisplay = lPlayer.GetComponent<PlayerDisplay>();
        //playerDisplay.SetImage(images[Random.Range(0, images.Length)]);
        SetActive(false);
    }

    public void Attack()
    {
        playerDisplay.Attack();
        enemy.GetComponent<RPlayerManager>().TakeDamage(attack);
        playerDisplay.SetCanvasLayer(1);
    }

    public void TakeDamage(int damage)
    {
        playerDisplay.SetCanvasLayer(0);
        health -= (int)(Random.Range((1f - damageVariation) * damage, (1f + damageVariation) * damage));
        StartCoroutine(SetHealthDelay(health, delay));
        if (health <= 0)
        {
            health = 0;
            isDead = true;
        }
        Debug.Log("Health L: " + health);
    }

    IEnumerator SetHealthDelay(int health, float delay)
    {
        yield return new WaitForSeconds(delay);
        SetHealth(health);
    }

    public void SetImage(Sprite image)
    {
        playerDisplay.SetImage(image);
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
