using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishValue : MonoBehaviour
{
    public int moeda;
    public int diamantes;
    public float speed;

    private Dictionary<string, Tuple<int, int, float>> tagToMoeda = new Dictionary<string, Tuple<int, int, float>>
    {
        { "Bagre", new Tuple<int, int, float>(10, 0, 2) },
        { "Tilapia", new Tuple< int, int, float >(20, 0, 2.5f) },
        { "Pacu", new Tuple< int, int, float >(0, 1, 2) },
        { "Atum", new Tuple< int, int, float >(30, 0, 2.3f) },
        { "Bacalhau", new Tuple< int, int, float >(35, 0, 2.5f) }
    };

    private void Awake()
    {
        Valor();
    }

    void Valor()
    {
        if (tagToMoeda.TryGetValue(gameObject.tag, out Tuple<int, int, float> valor))
        {
            moeda = valor.Item1;
            diamantes = valor.Item2;
            speed = valor.Item3;
        }
    }
}
