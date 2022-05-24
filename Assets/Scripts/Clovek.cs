using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clovek : MonoBehaviour
{
    public GameObject image;
    Animation anim;

    // Update is called once per frame
    void Start()
    {
        anim = image.GetComponent<Animation>();
    }

    public void Attack()
    {
        //play attack animation
        anim.Play("Player Attack");
        
    }
}
