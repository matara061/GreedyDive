using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    public GameObject tutorialScreen;

    
    void Start()
    {
        // Verifica se é a primeira vez que o jogador entra no jogo
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            tutorialScreen.SetActive(true);

            // Define a chave "FirstTime" para que saibamos que o jogador já entrou no jogo antes
            PlayerPrefs.SetInt("FirstTime", 1);
        }
        else
        {
            // Não é a primeira vez que o jogador entra no jogo
            Debug.Log("veteran player");
            // Você pode continuar normalmente
        }
    }

    private void Update()
    {
       
    }

    

}
