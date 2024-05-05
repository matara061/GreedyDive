using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiObjeto : MonoBehaviour
{
    public float delay; // O atraso antes da destrui��o, em segundos

    void Start()
    {
        // Destroi o objeto depois do atraso
        Destroy(gameObject, delay);
    }


}
