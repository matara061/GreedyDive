using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishValue : MonoBehaviour
{
    public int moeda;

    private Dictionary<string, int> tagToMoeda = new Dictionary<string, int>
    {
        { "Bagre", 5 },
        { "Tilapia", 10 },
        { "Pacu", 20 }
    };

    void Start()
    {
        Valor();
    }

    void Valor()
    {
        if (tagToMoeda.TryGetValue(gameObject.tag, out int valor))
        {
            moeda = valor;
        }
    }
}
