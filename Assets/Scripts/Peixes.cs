using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishSwimming : MonoBehaviour
{
    public float swimSpeed = 2f; // Velocidade de natação
    public float rotationSpeed = 5f; // Velocidade de rotação

    private GameManager gameManager;
    public GameObject floatingGold;
    public GameObject floatingDiamond;
    public FishValue fishValue;
    private DivingSceneManager divingSceneManager;

    private Vector2 swimDirection; // Direção de natação atual

    void Start()
    {
        swimSpeed = fishValue.speed;
        gameManager = FindAnyObjectByType<GameManager>();
        divingSceneManager = FindAnyObjectByType<DivingSceneManager>();
        // Inicializa a direção de natação aleatoriamente
        swimDirection = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        // Move o peixe na direção de natação
        transform.Translate(swimDirection * swimSpeed * Time.deltaTime);

        // Altera aleatoriamente a direção de natação a cada 2 segundos
        if (Time.time % 2f < 0.1f)
        {
            swimDirection = Random.insideUnitCircle.normalized;
            FlipFish();
        }
    }

    void FlipFish()
    {
        if (swimDirection.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (swimDirection.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Recompensa();
            Destroy(gameObject);
        }
    }

    void Recompensa()
    {
        if (fishValue != null)
        {
            divingSceneManager.Money += fishValue.moeda;
            divingSceneManager.Diamantes += fishValue.diamantes;

            if(fishValue.moeda > 0)
            {
                GameObject Gold = Instantiate(floatingGold, transform.position, Quaternion.identity);
                Gold.transform.GetChild(0).GetComponent<TextMeshPro>().text = fishValue.moeda.ToString();
            }else 
                if(fishValue.diamantes > 0)
            {
                GameObject Diamond = Instantiate(floatingDiamond, transform.position, Quaternion.identity);
                Diamond.transform.GetChild(0).GetComponent<TextMeshPro>().text = fishValue.diamantes.ToString();
            }
        }
    }
}
