using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredadorValues : MonoBehaviour
{
    public int HP;
    public int Damage;

    private Dictionary<string, Tuple<int, int>> tagToStatus = new Dictionary<string, Tuple<int, int>>
    {
        { "Tubarao", new Tuple<int, int>(100, 10) },
        { "Piranha", new Tuple<int, int>(40, 3) },
        { "Peixe espada", new Tuple<int, int>(60, 5) }
    };

    private void Awake()
    {
        Valor();
    }

    void Valor()
    {
        if (tagToStatus.TryGetValue(gameObject.tag, out Tuple<int, int> valor))
        {
            HP = valor.Item1;
            Damage = valor.Item2;
        }
    }
}
