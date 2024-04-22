using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwimming : MonoBehaviour
{
    public float swimSpeed = 2f; // Velocidade de nata��o
    public float rotationSpeed = 5f; // Velocidade de rota��o

    private GameManager gameManager;
    private DivingSceneManager divingSceneManager;

    private Vector2 swimDirection; // Dire��o de nata��o atual

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        divingSceneManager = FindAnyObjectByType<DivingSceneManager>();
        // Inicializa a dire��o de nata��o aleatoriamente
        swimDirection = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        // Move o peixe na dire��o de nata��o
        transform.Translate(swimDirection * swimSpeed * Time.deltaTime);

        // Rotaciona o peixe suavemente na dire��o de nata��o
        RotateTowardsTarget();

        // Altera aleatoriamente a dire��o de nata��o a cada 2 segundos
        if (Time.time % 2f < 0.1f)
        {
            swimDirection = Random.insideUnitCircle.normalized;
        }
    }

    void RotateTowardsTarget()
    {
        if (swimDirection == Vector2.zero)
        {
            return;
        }

        float targetAngle = Mathf.Atan2(swimDirection.y, swimDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
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
        FishValue fishValue = GetComponent<FishValue>();
        if (fishValue != null)
        {
            divingSceneManager.Money += fishValue.moeda;
            divingSceneManager.Diamantes += fishValue.diamantes;
        }
    }
}
