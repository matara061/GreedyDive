using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuvem : MonoBehaviour
{
    public float speed = 2f; // Velocidade de movimento para cima

    void Update()
    {
        // Move todos os filhos para cima
        foreach (Transform child in transform)
        {
            child.position += Time.deltaTime * speed * Vector3.right;
        }
    }
}
