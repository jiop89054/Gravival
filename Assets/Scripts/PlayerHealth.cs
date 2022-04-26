using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float PlayerMaxHealth = 100;
    public float PlayerCurrentHealth;
    public Slider healthBar;


    public static PlayerHealth instance;

    public void takeDamage(float amount)
    {
        //FindObjectOfType<ShakeBehavior>().shakeDuration = 1;
        //FindObjectOfType<AudioManager>().Play("PlayerDamage");
        PlayerCurrentHealth -= amount;
        healthBar.value = PlayerCurrentHealth;
        if(PlayerCurrentHealth < 0)
        {
            FindObjectOfType<MenuScript>().LoadLevel("EndScreen");
        }
    }
    private void Awake()
    {
        PlayerCurrentHealth = PlayerMaxHealth;
        healthBar.maxValue = PlayerMaxHealth;
        healthBar.value = PlayerMaxHealth;
        instance = this;
        FindObjectOfType<AudioManager>().Play("Music");
    }
}
