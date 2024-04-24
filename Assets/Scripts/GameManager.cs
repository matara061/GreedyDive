using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string CurrentOxygenTank;
    public string CurrentDivingSuit;
    public string CurrentHarpoon;
    public string CurrentDivingFins;
    public string CurrentAmuleto;

    public int BankMoney;
    public int BankDiamantes;

    private void Awake()
    {
        CurrentHarpoon = "Arma1";
        CurrentDivingSuit = "Roupa1";
        CurrentDivingFins = "Pes1";
        CurrentOxygenTank = "Tank1";
        CurrentAmuleto = string.Empty;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
