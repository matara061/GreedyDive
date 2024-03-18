using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwimming : MonoBehaviour
{
    public float swimSpeed = 2f; // Velocidade de natação
    public float rotationSpeed = 5f; // Velocidade de rotação

    private Vector3 swimDirection; // Direção de natação atual

    void Start()
    {
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
}
