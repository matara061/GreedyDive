using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int Money;
    public int Diamantes;
    public float Profundidade;

    public bool[] Amuleto;
    public bool[] AmuletoAtivo;

    public string CurrentOxygenTank;
    public string CurrentDivingSuit;
    public string CurrentHarpoon;
    public string CurrentDivingFins;

    // the values difined in this constructor will be the default values 
    // the game starts with when there's no data to load

    public GameData()
    {
        this.Money = 0;
        this.Diamantes = 0;
        this.Profundidade = 0;
        this.CurrentHarpoon = "Arma1";
        this.CurrentDivingSuit = "Roupa1";
        this.CurrentDivingFins = "Pes1";
        this.CurrentOxygenTank = "Tank1";

        this.Amuleto = new bool[10];
        this.AmuletoAtivo = new bool[10];
    }
}
