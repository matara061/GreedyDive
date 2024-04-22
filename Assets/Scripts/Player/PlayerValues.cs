using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValues : MonoBehaviour
{

    public GameManager gameManager;
    public Player player;

    public int HP;
    public int Damage;
    public int Speed;
    public float O2;
    public int Amuleto;

    private Dictionary<string, int> MaxHealth = new Dictionary<string, int>
    {
        { "Roupa1", 100 },
        { "Roupa2", 200 },
        { "Roupa3", 300 }
    };

    private Dictionary<string, int> WeaponDam = new Dictionary<string, int>
    {
        { "Arma1", 10 },
        { "Arma2", 20 },
        { "Arma3", 30 }
    };

    private Dictionary<string, int> PesSpeed = new Dictionary<string, int>
    {
        { "Pes1", 2 },
        { "Pes2", 3 },
        { "Pes3", 4 }
    };

    private Dictionary<string, float> O2Tank = new Dictionary<string, float>
    {
        { "Tank1", 100f },
        { "Tank2", 200f },
        { "Tank3", 300f }
    };

    private Dictionary<string, int> AmuletoBuff = new Dictionary<string, int>
    {
        { "Amuleto1", 100 },
        { "Amuleto2", 200 },
        { "Amuleto3", 300 }
    };


    private void Awake()
    {
        SetTank();
        Debug.Log(gameManager.CurrentOxygenTank);

        /* SetHealth();
        SetDamage();
        SetSpeed();*/
    }

    void SetTank()
    {
        if(O2Tank.TryGetValue(gameManager.CurrentOxygenTank, out float valor))
        {
            O2 = valor;
        }
    }

    void Valor()
    {
       /* if (if (MaxHealth.TryGetValue(gameObject.tag, out int valor))))
        {
            moeda = valor.Item1;
            diamantes = valor.Item2;
        }*/
    }

    /* void SetDamage()
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
     }*/



}
