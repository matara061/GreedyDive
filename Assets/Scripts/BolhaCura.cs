using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BolhaCura : MonoBehaviour
{

    private Player player;

    public GameObject floatingTxt; // O prefab da mensagem de aviso

    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.Cura();
            ShowMessage("mais");
            Destroy(gameObject);
        }
    }

    private void ShowMessage(string warning)
    {
        // Instancia a mensagem de aviso
        GameObject message = Instantiate(floatingTxt, this.transform);

        // Configura a mensagem
        TextMeshProUGUI text = message.GetComponent<TextMeshProUGUI>();
        text.text = warning;

        // Destrua a mensagem após alguns segundos
        Destroy(message, 3f);
    }
}
