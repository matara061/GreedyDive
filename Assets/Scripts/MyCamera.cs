using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
            if (player.GetComponent<TestePlayer>().isAlive)
            {
                transform.position += speed * Time.deltaTime * Vector3.down;
            }
    }
}
