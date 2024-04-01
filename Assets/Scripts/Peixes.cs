using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwimming : MonoBehaviour
{
    public float swimSpeed = 2f; // Velocidade de nata��o
    public float rotationSpeed = 5f; // Velocidade de rota��o
    public int moeda;

    public GameManager gameManager;
    public DivingSceneManager divingSceneManager;

    private Vector3 swimDirection; // Dire��o de nata��o atual

    private Dictionary<string, int> tagToMoeda = new Dictionary<string, int>
    {
        { "Bagre", 5 },
        { "Tilapia", 10 },
        { "Pacu", 20 }
    };

    void Start()
    { 
        Valor();
        // Inicializa a dire��o de nata��o aleatoriamente
        swimDirection = Random.insideUnitSphere.normalized;
    }

    void Update()
    {
        // Move o peixe na dire��o de nata��o
        transform.Translate(swimDirection * swimSpeed * Time.deltaTime);

        // Rotaciona o peixe suavemente na dire��o de nata��o
       // Quaternion targetRotation = Quaternion.LookRotation(swimDirection);
      //  transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Altera aleatoriamente a dire��o de nata��o a cada 2 segundos
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
