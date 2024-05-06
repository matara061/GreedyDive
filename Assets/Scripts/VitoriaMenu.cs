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

    public string[] sceneName;
    
    void Start()
    {
        divingSceneManager = FindAnyObjectByType<DivingSceneManager>();

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
            gold.text = divingSceneManager.Money.ToString();
            diamond.text = divingSceneManager.Diamantes.ToString();
            Time.timeScale = 0f;
        }
    }

    public void Sair()
    {
        Time.timeScale = 1f;
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
