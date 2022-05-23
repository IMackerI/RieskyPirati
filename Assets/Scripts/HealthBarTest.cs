using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarTest : MonoBehaviour
{
    public SliderScript slider;
    public int maxHP = 100;
    public int curHP;
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        slider.SetMaxValue(curHP);
        slider.SetValue(curHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
    void TakeDamage(int dmg)
    {
        curHP -= dmg;
        slider.SetValue(curHP);
    }
}
