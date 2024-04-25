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

    public void Resume()
    {
        SceneManager.UnloadSceneAsync("Pause");
    }

    public void Desistir()
    {
        StartCoroutine(CarregarCena());
    }

    public void Loja1()
    {
        Debug.Log("loja");
    }

    public void Esquerda()
    {
        Debug.Log("esquerda");
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
