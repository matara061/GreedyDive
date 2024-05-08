using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amuleto2 : MonoBehaviour
{
    GameManager gameManager;

    public GameObject bolhaSpawner;


    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        if(gameManager != null)
        {
            if (gameManager.AmuletoAtivo[1])
            {
                bolhaSpawner.SetActive(true);
            }

            if (gameManager.AmuletoAtivo[6]) // amuleto 7, menos obstaculos
            {
                // desativar alguns spanewrs de obstaculos 
            }

            if (gameManager.AmuletoAtivo[7]) // amuleto 8, menos predadores
            {
                // desativar alguns spanewrs de predadores 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
