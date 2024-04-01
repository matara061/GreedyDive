using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwimming : MonoBehaviour
{
    public float swimSpeed = 2f; // Velocidade de natação
    public float rotationSpeed = 5f; // Velocidade de rotação
    public int moeda;

    public GameManager gameManager;
    public DivingSceneManager divingSceneManager;

    private Vector3 swimDirection; // Direção de natação atual

    private Dictionary<string, int> tagToMoeda = new Dictionary<string, int>
    {
        { "Bagre", 5 },
        { "Tilapia", 10 },
        { "Pacu", 20 }
    };

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
        if (tagToMoeda.TryGetValue(gameObject.tag, out int valor))
        {
            moeda = valor;
        }
    }

    void Recompensa()
    {
        divingSceneManager.Money += moeda;
    }
}
