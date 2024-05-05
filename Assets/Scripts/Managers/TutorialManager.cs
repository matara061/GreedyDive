using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    void Start()
    {
        // Verifica se � a primeira vez que o jogador entra no jogo
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            // � a primeira vez que o jogador entra no jogo
            Debug.Log("new player");

            // Aqui voc� pode fazer coisas como mostrar o tutorial

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
}
