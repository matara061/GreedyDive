using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredadorValues : MonoBehaviour
{
    public int HP;
    public int Damage;
    public float Speed;
    public int Moeda;
    public int Diamante;

    private Dictionary<string, Tuple<int, int, float, int, int>> tagToStatus = new Dictionary<string, Tuple<int, int, float, int, int>>
{
    { "Tubarao branco", new Tuple< int, int, float, int, int >(15, 2, 3f, 50, 0) },
    { "Piranha", new Tuple< int, int, float, int, int >(5, 2, 5f, 20, 0) },
    { "Moreia", new Tuple< int, int, float, int, int >(15, 6, 2.2f, 20, 0) },
    { "Barracuda", new Tuple< int, int, float, int, int >(20, 10, 3, 20, 0) },
    { "Lula gigante", new Tuple< int, int, float, int, int >(20, 10, 3, 20, 0) },
    { "Enguia eletrica", new Tuple< int, int, float, int, int >(20, 10, 3, 20, 0) },
    { "Peixe pedra", new Tuple< int, int, float, int, int >(20, 10, 3, 20, 0) },
    { "Caranguejo", new Tuple< int, int, float, int, int >(20, 10, 3, 20, 0) },
    { "Serpente do mar", new Tuple< int, int, float, int, int >(20, 10, 3, 20, 0) },
    { "Peixe gato", new Tuple< int, int, float, int, int >(20, 10, 3, 20, 0) },
    { "Agua viva", new Tuple< int, int, float, int, int >(20, 10, 3, 20, 0) },
    { "Tubarao martelo", new Tuple< int, int, float, int, int >(20, 10, 3, 20, 0) },
    { "Peixe leao", new Tuple< int, int, float, int, int >(60, 3, 3, 10, 0) }
};


    private void Awake()
    {
        Valor();
    }

    void Valor()
    {
        if (tagToStatus.TryGetValue(gameObject.tag, out Tuple<int, int, float, int, int> valor))
        {
            HP = valor.Item1;
            Damage = valor.Item2;
            Speed = valor.Item3;
            Moeda = valor.Item4;
            Diamante = valor.Item5;
        }
    }
}
