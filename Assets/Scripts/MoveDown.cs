using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 2f; // Velocidade de movimento para cima

    void Update()
    {
        // Move todos os filhos para baixo
        foreach (Transform child in transform)
        {
            child.position += Time.deltaTime * speed * Vector3.down;
        }
    }
}
