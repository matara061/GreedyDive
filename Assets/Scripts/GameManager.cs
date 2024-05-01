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

    // Variável estática para a instância do GameManager
    public static GameManager instance = null;

    private void Awake()
    {

        // Se já houver uma instância do GameManager, destrua este novo GameManager
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Se não houver uma instância do GameManager, defina esta como a instância
        instance = this;

        CurrentHarpoon = "Arma1";
        CurrentDivingSuit = "Roupa1";
        CurrentDivingFins = "Pes1";
        CurrentOxygenTank = "Tank1";
        CurrentAmuleto = string.Empty;

        // Isso fará com que o GameManager não seja destruído ao carregar uma nova cena
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
