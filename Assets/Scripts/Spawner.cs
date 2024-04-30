using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool spawnFish = false, spawnObstacle = false;

    private bool canSpawn = true;

    private float obstacleTypeNumber, fishTypeNumber, diceRoll;

    public GameObject pacu, bagre, tubarao, barril;

    public bool tier1Spawner, tier2Spawner, tier3Spawner, isRockSpawner;

    public float spawnerCooldown;

    private void Awake()
    {
        if (tier1Spawner)
        {
            diceRoll = Random.Range(0, 10);
        }
        if (tier2Spawner)
        {
            diceRoll = Random.Range(0, 20);
        }
        if (tier2Spawner)
        {
            diceRoll = Random.Range(0, 10);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!isRockSpawner)
        {
            switch (diceRoll)
            {
                case 0:
                case 1:
                case 2:
                    spawnObstacle = true;
                    obstacleTypeNumber = Random.Range(0, 3);
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    spawnFish = true;
                    fishTypeNumber = Random.Range(0, 2);
                    break;

            }
        }

        spawnerCooldown = Random.Range(5, 11);
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            spawnerCooldown = Random.Range(5, 11);

            if (!isRockSpawner)
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
                    }
                }
                if (spawnObstacle)
                {
                    switch (obstacleTypeNumber)
                    {
                        case 0:
                        case 1:
                            Instantiate(barril, transform.position, Quaternion.identity);
                            canSpawn = false;
                            break;
                        case 2:
                            Instantiate(tubarao, transform.position, Quaternion.identity);
                            canSpawn = false;
                            break;
                    }
                }
            }
        }
        else
        {
            spawnerCooldown -= Time.deltaTime;

            diceRoll = Random.Range(0, 10);
            obstacleTypeNumber = Random.Range(0, 3);
            fishTypeNumber = Random.Range(0, 2);

            if (spawnerCooldown <= 0)
            {
                canSpawn = true;
            }
        }
    }
}
