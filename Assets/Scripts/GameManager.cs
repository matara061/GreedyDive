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

    public bool[] Amuleto = new bool[10];
    public bool[] AmuletoAtivo = new bool[10];


    /*   
     Amuleto 0 = marca��o o2 no tanque
    Amuleto 1 = + bolhas de cura
    Amuleto 2 = profundidade avan�a mais rapido
    Amuleto 3 = + tempo de invencibilidade
    Amuleto 4 = - dano de pressao
    Amuleto 5 = diamante x2
    Amuleto 6 = cura x2
    Amuleto 7 = - obstaculos
    Amuleto 8 = menos predadores
    Amuleto 9 = gold x2
     
     
     */

    public int BankMoney;
    public int BankDiamantes;

    // Vari�vel est�tica para a inst�ncia do GameManager
    public static GameManager instance;

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
