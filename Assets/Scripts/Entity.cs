using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public GameObject enemy;
    public SliderScript healthBar;
    public int maxHealth;
    public int health;
    public int damage;
    public int coins;

    // Update is called once per frame
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxValue(health);
        healthBar.SetValue(health);
    }

    public void Attack()
    {
        enemy.GetComponent<Entity>().TakeDamage(damage);
        //play attack animation
    }
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        healthBar.SetValue(health);
    }

    public bool Alive()
    {
        return health >= 0;
    }
}
