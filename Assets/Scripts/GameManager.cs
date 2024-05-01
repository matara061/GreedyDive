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
        CurrentAmuleto = string.Empty;

        // Isso far� com que o GameManager n�o seja destru�do ao carregar uma nova cena
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data) 
    {
        this.BankMoney = data.Money;
        this.BankDiamantes = data.Diamantes;
        this.CurrentHarpoon = data.CurrentHarpoon;
        this.CurrentDivingSuit = data.CurrentDivingSuit;
        this.CurrentDivingFins = data.CurrentDivingFins;
        this.CurrentOxygenTank = data.CurrentOxygenTank;
    }

    public void SaveData(ref GameData data) 
    {
        data.Money = this.BankMoney;
        data.Diamantes = this.BankDiamantes;
        data.CurrentHarpoon = this.CurrentHarpoon;
        data.CurrentDivingSuit = this.CurrentDivingSuit;
        data.CurrentDivingFins = this.CurrentDivingFins;
        data.CurrentOxygenTank = this.CurrentOxygenTank;
    }
}
