using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BolhaCura : MonoBehaviour
{

    private Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    private void Update()
    {
        // Rotaciona o objeto em torno do eixo Y (vertical)
        transform.Rotate(Vector3.forward * 50f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.Cura();
            Destroy(gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Limit"))
        {
            Destroy(gameObject);
        }
    }
}
