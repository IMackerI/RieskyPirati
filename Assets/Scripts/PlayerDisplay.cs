using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    public Image LImage;
    public Slider HpSlider;
    public Slider AtkSlider;
    public Slider CoinsSlider;
    public Canvas canvas;


    public void SetCanvasLayer(int layer)
    {
        canvas.GetComponent<Canvas>().sortingOrder = layer;
    }
    public void SetImage(Sprite image)
    {
        LImage.GetComponent<Image>().sprite = image;
    }
    public void SetMaxHealth(int maxHealth)
    {
        HpSlider.maxValue = maxHealth;
        HpSlider.value = maxHealth;
    }
    public void SetHealth(int health)
    {
        HpSlider.value = health;
    }
    public void Attack()
    {
        Animation anim = LImage.GetComponent<Animation>();
        anim.Play();
    }
    public void SetMaxAttack(int maxAttack)
    {
        AtkSlider.maxValue = maxAttack;
        AtkSlider.value = maxAttack;
    }
    public void SetAttack(int attack)
    {
        AtkSlider.value = attack;
    }
    public void SetMaxCoins(int maxCoins)
    {
        CoinsSlider.maxValue = maxCoins;
        CoinsSlider.value = maxCoins;
    }
    public void SetCoins(int coins)
    {
        CoinsSlider.value = coins;
    }
}
