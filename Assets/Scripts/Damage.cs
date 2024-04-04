using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;

    private Dictionary<string, int> tagToDamage = new Dictionary<string, int>
    {
        { "Tubarao", 5 },
        { "Piranha", 10 },
        { "Barril", 2 }
    };

    void Start()
    {
        Dano();
    }

    void Dano()
    {
        if (tagToDamage.TryGetValue(gameObject.tag, out int dano))
        {
            damage = dano;
        }
    }
}
