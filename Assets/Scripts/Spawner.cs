using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool spawnFish = false, spawnObstacle = false;

    private bool canSpawn = true;

    private float obstacleTypeNumber, fishTypeNumber, initialThrow;

    public GameObject pacu, bagre, tubarao, barril;

    private void Awake()
    {
        initialThrow = Random.Range(0, 4);
    }

    // Start is called before the first frame update
    void Start()
    {
        switch (initialThrow)
        {
            case 0:
                spawnObstacle = true;
                obstacleTypeNumber = Random.Range(0, 2);
                break;
            case 1:
            case 2:
                spawnFish = true;
                fishTypeNumber = Random.Range(0, 3);
                break;
                
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            if (spawnFish)
            {
                switch (fishTypeNumber)
                {
                    case 0:
                        Instantiate(pacu, transform.position, Quaternion.identity);
                        canSpawn = false;
                        break;
                    case 1:
                        Instantiate(bagre, transform.position, Quaternion.identity);
                        canSpawn = false;
                        break;
                    case 2:
                        Instantiate(tubarao, transform.position, Quaternion.identity);
                        canSpawn = false;
                        break;
                }
            }
            if (spawnObstacle)
            {
                switch(obstacleTypeNumber)
                {
                    case 0:
                        Instantiate(barril, transform.position, Quaternion.identity);
                        canSpawn = false;
                        break;
                    case 1:
                        Debug.Log("There is a rock here, but it's invisible!");
                        canSpawn = false;
                        break;
                }
            }
        }
    }
}
