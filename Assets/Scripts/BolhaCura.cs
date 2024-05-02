using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolhaCura : MonoBehaviour
{

    private Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.Cura();
            Destroy(gameObject);
        }
    }
}
