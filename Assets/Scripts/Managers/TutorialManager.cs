using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    void Start()
    {
        // Verifica se é a primeira vez que o jogador entra no jogo
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            // É a primeira vez que o jogador entra no jogo
            Debug.Log("new player");

            // Aqui você pode fazer coisas como mostrar o tutorial

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
}
