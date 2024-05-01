using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredadorValues : MonoBehaviour
{
    public int HP;
    public int Damage;
    public int Speed;
    public int Moeda;
    public int Diamante;

    private Dictionary<string, Tuple<int, int, int, int, int>> tagToStatus = new Dictionary<string, Tuple<int, int, int, int, int>>
{
    { "Tubarao", new Tuple< int, int, int, int, int >(15, 5, 2, 50, 0) },
    { "Piranha", new Tuple< int, int, int, int, int >(40, 3, 5, 20, 0) },
    { "Moreia", new Tuple< int, int, int, int, int >(15, 6, 3, 20, 0) },
    { "Barracuda", new Tuple< int, int, int, int, int >(20, 10, 3, 20, 0) },
    { "Peixe espada", new Tuple< int, int, int, int, int >(60, 3, 3, 10, 0) }
};


    private void Awake()
    {
        Valor();
    }

    void Valor()
    {
        if (tagToStatus.TryGetValue(gameObject.tag, out Tuple<int, int, int, int, int> valor))
        {
            HP = valor.Item1;
            Damage = valor.Item2;
            Speed = valor.Item3;
            Moeda = valor.Item4;
            Diamante = valor.Item5;
        }
    }
}
