using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeixeFundo : MonoBehaviour
{

    public float swimSpeed = 2f; // Velocidade de natação
    public float rotationSpeed = 5f; // Velocidade de rotação

    private Vector2 swimDirection; // Direção de natação atual
    // Start is called before the first frame update
    void Start()
    {
        // Inicializa a direção de natação aleatoriamente
        swimDirection = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
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
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (swimDirection.x < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Limit"))
        {
            Destroy(gameObject);
        }
    }
}
