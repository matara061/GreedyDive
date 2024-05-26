using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValues : MonoBehaviour
{

    public GameManager gameManager;
    public DivingSceneManager diveManager;
    public Player player;

    public int HP;
    public int Damage;
    public float Speed;
    public float O2;
    public int Amuleto;

    private Dictionary<string, int> MaxHealth = new Dictionary<string, int>
    {
        { "Roupa1", 100 },
        { "Roupa2", 200 },
        { "Roupa3", 300 },
        { "Roupa4", 400 },
        { "Roupa5", 500 },
        { "Roupa6", 600 },
        { "Roupa7", 700 },
        { "Roupa8", 800 },
        { "Roupa9", 900 },
        { "Roupa10", 1000 }
    };

    private Dictionary<string, int> WeaponDam = new Dictionary<string, int>
    {
        { "Arma1", 5 },
        { "Arma2", 10 },
        { "Arma3", 15 },
        { "Arma4", 20 },
        { "Arma5", 25 },
        { "Arma6", 30 },
        { "Arma7", 35 },
        { "Arma8", 40 },
        { "Arma9", 45 },
        { "Arma10", 50 }
    };

    private Dictionary<string, float> PesSpeed = new Dictionary<string, float>
    {
        { "Pes1", 2f },
        { "Pes2", 2.5f },
        { "Pes3", 3f },
        { "Pes4", 3.5f },
        { "Pes5", 4f },
        { "Pes6", 4.5f },
        { "Pes7", 5f },
        { "Pes8", 5.5f },
        { "Pes9", 6f },
        { "Pes10", 6.5f }
    };

    private Dictionary<string, float> O2Tank = new Dictionary<string, float>
    {
        { "Tank1", 100f },
        { "Tank2", 285f },
        { "Tank3", 470f },
        { "Tank4", 655f },
        { "Tank5", 840f },
        { "Tank6", 1025f },
        { "Tank7", 1210f },
        { "Tank8", 1395f },
        { "Tank9", 1480f },
        { "Tank10", 1600f }
    };

    private Dictionary<string, int> AmuletoBuff = new Dictionary<string, int>
    {
        { "Amuleto1", 100 },
        { "Amuleto2", 200 },
        { "Amuleto3", 300 }
    };


    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        diveManager = FindAnyObjectByType<DivingSceneManager>();

        if (gameManager != null)
        {
            SetTank();
            SetHealth();
            SetSpeed();
            SetDamage();
        }

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

    void SetHealth()
    {
        if (MaxHealth.TryGetValue(gameManager.CurrentDivingSuit, out int valor))
        {
            HP = valor;
            player.MaxHealth = valor;
        }
    }

    void SetSpeed()
    {
        if (PesSpeed.TryGetValue(gameManager.CurrentDivingFins, out float valor))
        {
            Speed = valor;
            player.playerSpeed = valor;
        }
    }

    void SetDamage()
    {
        if (WeaponDam.TryGetValue(gameManager.CurrentHarpoon, out int valor))
        {
            Damage = valor;
            player.playerDam = valor;
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
