using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwimming : MonoBehaviour
{
    public float swimSpeed = 2f; // Velocidade de natação
    public float rotationSpeed = 5f; // Velocidade de rotação
    public int moeda;

    public GameManager gameManager;

    private Vector3 swimDirection; // Direção de natação atual

    void Start()
    {
        Valor();
        // Inicializa a direção de natação aleatoriamente
        swimDirection = Random.insideUnitSphere.normalized;
    }

    void Update()
    {
        // Move o peixe na direção de natação
        transform.Translate(swimDirection * swimSpeed * Time.deltaTime);

        // Rotaciona o peixe suavemente na direção de natação
       // Quaternion targetRotation = Quaternion.LookRotation(swimDirection);
      //  transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Altera aleatoriamente a direção de natação a cada 2 segundos
        if (Time.time % 2f < 0.1f)
        {
            swimDirection = Random.insideUnitSphere.normalized;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // mandar moeda para o game manager
            Recompensa();
            Destroy(gameObject);
        }
    }

    void Valor()
    {
        if (gameObject.CompareTag("Bagre"))
        {
            moeda = 5;
        }
        else if(gameObject.CompareTag("Tilapia"))
        {
            moeda = 10;
        }
        else if (gameObject.CompareTag("Pacu"))
        {
            moeda = 20;
        }
    }

    void Recompensa()
    {
        gameManager.Money += moeda;
    }
}
