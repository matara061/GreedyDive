using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    private GameObject lastSpawned;
    public GameObject ItemBox;
    private int sameSpawnCount = 0;

    public int seconds;

    void Start()
    {
        StartCoroutine(SpawnRandom());
    }

    IEnumerator SpawnRandom()
    {
        while (true)
        {
            yield return new WaitForSeconds(seconds);

            GameObject toSpawn;
            do
            {
                toSpawn = prefabs[Random.Range(0, prefabs.Count)];
            }
            while (lastSpawned == toSpawn && sameSpawnCount >= 3);

            if (lastSpawned == toSpawn)
            {
                sameSpawnCount++;
            }
            else
            {
                sameSpawnCount = 0;
            }

            lastSpawned = Instantiate(toSpawn, transform.position, Quaternion.identity);
            lastSpawned.transform.parent = ItemBox.transform; // Define o objeto vazio como o pai
        }
    }
}
