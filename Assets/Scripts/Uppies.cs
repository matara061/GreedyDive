using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Uppies : MonoBehaviour
{
    public GameObject player;
    public GameObject[] bagre, pacu, tubarao, barril;
    public float uppiesSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pacu = GameObject.FindGameObjectsWithTag("Bagre");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FindThoseWhoWantUppies()
    {

    }
}
