using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class VitoriaMenu : MonoBehaviour
{

    [SerializeField]
    private Slider barraProgresso;

    public TextMeshProUGUI gold;
    public TextMeshProUGUI diamond;

    [SerializeField]
    DivingSceneManager divingSceneManager;

    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameManager gameManager;

    private int Money = 0;
    private int Diamond = 0;

    public string[] sceneName;
    
    void Start()
    {
        divingSceneManager = FindAnyObjectByType<DivingSceneManager>();
        audioManager = FindAnyObjectByType<AudioManager>(); 
        gameManager = FindAnyObjectByType<GameManager>();

        if (divingSceneManager != null )
        {
            Money = divingSceneManager.Money;
            Diamond = divingSceneManager.Diamantes;
        }

        Vitoria();

        sceneName[0] = "BoatScene";
        sceneName[1] = "TestesM";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Vitoria()
    {
        if (divingSceneManager != null)
        {
            gold.text = Money.ToString();
            diamond.text = Diamond.ToString();
            Time.timeScale = 0f;
        }
    }

    public void Dobro()
    {
        Time.timeScale = 1f;
        Money *= Money;
        Diamond *= Diamond;
        gold.text = Money.ToString();
        diamond.text = Diamond.ToString();
        Time.timeScale = 0f;
    }

    public void Sair()
    {
        Time.timeScale = 1f;
        gameManager.BankMoney += Money;
        gameManager.BankDiamantes += Diamond;
        audioManager.PlaySFX(audioManager.botao);
        StartCoroutine(CarregarCena(sceneName[0]));
    }

    private IEnumerator CarregarCena(string name)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);
        while (!asyncOperation.isDone)
        {
            //Debug.Log("Carregando: " + (asyncOperation.progress * 100f) + "%");
            this.barraProgresso.value = asyncOperation.progress;
            yield return null;
        }
    }
}
