using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValues : MonoBehaviour
{
    public float MaxHealth;
    public int Damage;
    public int Speed;

    public GameManager gameManager;
    public Player player;
    private void Awake()
    {
        SetHealth();
        SetDamage();
        SetSpeed();
    }

    void SetDamage()
    {
        if (gameManager.CurrentHarpoon != 1)
        {

        }
        else
            player.playerDam = 10;
    }

    void SetHealth()
    {
        if (gameManager.CurrentDivingSuit != 1)
        {

        }
        else
            player.CurrentHealth = 100;
    }

    void SetSpeed()
    {
        if (gameManager.CurrentDivingFins != 1)
        {

        }
        else
            player.playerSpeed = 3;
    }


    
}
