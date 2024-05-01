using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishValue : MonoBehaviour
{
    public int moeda;
    public int diamantes;
    public int speed;

    private Dictionary<string, Tuple<int, int, int>> tagToMoeda = new Dictionary<string, Tuple<int, int, int>>
    {
        { "Bagre", new Tuple<int, int, int>(10, 0, 3) },
        { "Tilapia", new Tuple< int, int, int >(20, 0, 3) },
        { "Pacu", new Tuple< int, int, int >(0, 1, 2) }
    };

    private void Awake()
    {
        Valor();
    }

    void Start()
    {
        //Valor();
    }

    void Valor()
    {
        if (tagToMoeda.TryGetValue(gameObject.tag, out Tuple<int, int, int> valor))
        {
            moeda = valor.Item1;
            diamantes = valor.Item2;
            speed = valor.Item3;
        }
    }
}
