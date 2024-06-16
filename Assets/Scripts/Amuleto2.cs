using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amuleto2 : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public GameObject bolhaSpawner;

    public GameObject[] _predadorSpaw;
    public GameObject[] _obstaculosSpaw;


    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        if(gameManager != null)
        {
            if (gameManager.AmuletoAtivo[1]) // + bolhas de cura
            {
                bolhaSpawner.SetActive(true);
            }

            if (gameManager.AmuletoAtivo[7]) // menos obstaculos
            {
                Amuleto7();
            }

            if (gameManager.AmuletoAtivo[8]) // menos predadores
            {
                Amuleto8();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Amuleto7()
    {
        Spawner spawner = _obstaculosSpaw[0].GetComponent<Spawner>();
        Spawner spawner2 = _obstaculosSpaw[1].GetComponent<Spawner>();
        Spawner spawner3 = _obstaculosSpaw[2].GetComponent<Spawner>();

        spawner.seconds = spawner.seconds + 3;
        spawner2.seconds = spawner2.seconds + 3;
        spawner3.seconds = spawner3.seconds + 3;
    }

    public void Amuleto8() // se nao funcionar com obj desativado, ativar e depois desativa dnv
    {
        Spawner spawner = _predadorSpaw[0].GetComponent<Spawner>();
        Spawner spawner2 = _predadorSpaw[1].GetComponent<Spawner>();
        Spawner spawner3 = _predadorSpaw[2].GetComponent<Spawner>();

        spawner.seconds = spawner.seconds + 3;
        spawner2.seconds = spawner2.seconds + 3;
        spawner3.seconds = spawner3.seconds + 3;
    }
}
