using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    public TextMeshProUGUI falaTxt;

    public Transform pointA, pointB, pointC;

    public Transform player;

    public GameObject Screen;

    public Animator anim;

    public string[] fala;
    private int falaAtual = 0; // Adiciona uma variável para rastrear a fala atual
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

    private void Update()
    {
       /* if (player.transform.position == pointA.position)
        {
            Screen.SetActive(true);
        }
        else
            Screen.SetActive(false);

        if (player.transform.position == pointB.position)
        {
            Screen.SetActive(true);
        }
        else
            Screen.SetActive(false);

        if (player.transform.position == pointC.position)
        {
            Screen.SetActive(true);
        }
        else
            Screen.SetActive(false);*/
    }

    public void ProximaFala()
    {
        if (falaAtual < fala.Length)
        {
            falaTxt.text = fala[falaAtual];
            if (falaAtual == 0)
            {
                anim.Play("Tutorial_moveAnim");
            }else
                anim.Play("Tutorial_moveIdle");

            falaAtual++;
        }
        else
        {
            Debug.Log("Fim das falas");
        }
    }

}
