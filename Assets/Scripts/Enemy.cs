using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject image;
    public int health;
    public int damage;
    public int coins;
    Animation anim;

    // Update is called once per frame
    void Start()
    {
        anim = image.GetComponent<Animation>();
    }

    public void Attack()
    {
        //play attack animation
        anim.Play("Enemy Attack");

    }
}
