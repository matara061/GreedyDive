using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField]
    private Slider barraProgresso;

    [SerializeField]
    private AudioManager audioManager;

 
    public string[] sceneName;

    private void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        sceneName[0] = "BoatScene";
        sceneName[1] = "TestesM";
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        audioManager.IsPaused = false;
        audioManager.PlaySFX(audioManager.botao);
        SceneManager.UnloadSceneAsync("Pause");
    }

    public void Desistir()
    {
        Time.timeScale = 1f;
        audioManager.IsPaused = false;
        audioManager.PlaySFX(audioManager.botao);
        StartCoroutine(CarregarCena(sceneName[0]));
    }

    public void Sair()
    {
        StartCoroutine(CarregarCena(sceneName[0]));
    }

    public void TentarDeNovo()
    {
        Time.timeScale = 1f;
        audioManager.PlaySFX(audioManager.botao);
        StartCoroutine(CarregarCena(sceneName[1]));
    }

    public void Loja1()
    {
        Debug.Log("loja");
    }

    public void Esquerda()
    {
        Debug.Log("esquerda");
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
