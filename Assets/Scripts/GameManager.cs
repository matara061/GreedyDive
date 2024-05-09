using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour,IDataPersistence
{
    public string CurrentOxygenTank;
    public string CurrentDivingSuit;
    public string CurrentHarpoon;
    public string CurrentDivingFins;
    public string CurrentAmuleto;

    public bool[] Amuleto = new bool[9];
    public bool[] AmuletoAtivo = new bool[9];

    public int BankMoney;
    public int BankDiamantes;

    // Vari�vel est�tica para a inst�ncia do GameManager
    public static GameManager instance = null;

    private void Awake()
    {

        // Se j� houver uma inst�ncia do GameManager, destrua este novo GameManager
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Se n�o houver uma inst�ncia do GameManager, defina esta como a inst�ncia
        instance = this;

        CurrentHarpoon = "Arma1";
        CurrentDivingSuit = "Roupa1";
        CurrentDivingFins = "Pes1";
        CurrentOxygenTank = "Tank1";
        CurrentAmuleto = string.Empty; // apagar dps

        for (int i = 0; i < Amuleto.Length; i++)
        {
            Amuleto[i] = false;
        }

        for (int i = 0; i < AmuletoAtivo.Length; i++)
        {
            AmuletoAtivo[i] = false;
        }

        // Isso far� com que o GameManager n�o seja destru�do ao carregar uma nova cena
        DontDestroyOnLoad(gameObject);
    }

    public void LoadData(GameData data) 
    {
        this.BankMoney = data.Money;
        this.BankDiamantes = data.Diamantes;
        this.CurrentHarpoon = data.CurrentHarpoon;
        this.CurrentDivingSuit = data.CurrentDivingSuit;
        this.CurrentDivingFins = data.CurrentDivingFins;
        this.CurrentOxygenTank = data.CurrentOxygenTank;

        this.Amuleto = data.Amuleto;
        this.AmuletoAtivo = data.AmuletoAtivo;
    }

    public void SaveData(ref GameData data) 
    {
        data.Money = this.BankMoney;
        data.Diamantes = this.BankDiamantes;
        data.CurrentHarpoon = this.CurrentHarpoon;
        data.CurrentDivingSuit = this.CurrentDivingSuit;
        data.CurrentDivingFins = this.CurrentDivingFins;
        data.CurrentOxygenTank = this.CurrentOxygenTank;

        data.Amuleto = this.Amuleto;
        data.AmuletoAtivo = this.AmuletoAtivo;
    }
}
