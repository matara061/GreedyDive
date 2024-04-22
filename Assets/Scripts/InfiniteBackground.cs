using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfiniteBackground : MonoBehaviour
{
    public bool isSpecialScene;

    public GameObject nextLoop;

    public float loopSpawnTimer;

    private Transform myPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        loopSpawnTimer = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (loopSpawnTimer <= 0)
        {
            Instantiate(nextLoop, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
