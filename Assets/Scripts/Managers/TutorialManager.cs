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
        // Verifica se � a primeira vez que o jogador entra no jogo
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            tutorialScreen.SetActive(true);

            // Define a chave "FirstTime" para que saibamos que o jogador j� entrou no jogo antes
            PlayerPrefs.SetInt("FirstTime", 1);
        }
        else
        {
            // N�o � a primeira vez que o jogador entra no jogo
            Debug.Log("veteran player");
            // Voc� pode continuar normalmente
        }
    }

    private void Update()
    {
       
    }

    

}
