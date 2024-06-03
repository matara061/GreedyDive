using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Load : MonoBehaviour, IDataPersistence
{
    // Start is called before the first frame update

    [SerializeField]
    private Slider barraProgresso;

    public GameManager gameManager;
    void Start()
    {
        
    }

    void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data)
    {
        gameManager.BankMoney = data.Money;
        gameManager.BankDiamantes = data.Diamantes;
        gameManager.Profundidade = data.Profundidade;
        gameManager.CurrentHarpoon = data.CurrentHarpoon;
        gameManager.CurrentDivingSuit = data.CurrentDivingSuit;
        gameManager.CurrentDivingFins = data.CurrentDivingFins;
        gameManager.CurrentOxygenTank = data.CurrentOxygenTank;

        gameManager.Amuleto = data.Amuleto;
        gameManager.AmuletoAtivo = data.AmuletoAtivo;
    }

    public void SaveData(ref GameData data)
    {
        
    }

    public void Comecar()
    {
        StartCoroutine(CarregarCena());
    }

    private IEnumerator CarregarCena()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("BoatScene");
        while (!asyncOperation.isDone)
        {
            //Debug.Log("Carregando: " + (asyncOperation.progress * 100f) + "%");
            this.barraProgresso.value = asyncOperation.progress;
            yield return null;
        }
    }
}
