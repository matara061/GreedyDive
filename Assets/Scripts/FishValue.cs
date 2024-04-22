using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishValue : MonoBehaviour
{
    public int moeda;
    public int diamantes;

    private Dictionary<string, Tuple<int, int>> tagToMoeda = new Dictionary<string, Tuple<int, int>>
    {
        { "Bagre", new Tuple<int, int>(10, 0) },
        { "Tilapia", new Tuple<int, int>(20, 0) },
        { "Pacu", new Tuple<int, int>(0, 1) }
    };

    void Start()
    {
        Valor();
    }

    void Valor()
    {
        if (tagToMoeda.TryGetValue(gameObject.tag, out Tuple<int, int> valor))
        {
            moeda = valor.Item1;
            diamantes = valor.Item2;
        }
    }
}
