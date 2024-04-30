using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Uppies : MonoBehaviour
{
    public GameObject[] bagre, pacu, barril, tubarao;
    public float uppiesSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        pacu = GameObject.FindGameObjectsWithTag("Pacu");
        bagre = GameObject.FindGameObjectsWithTag("Bagre");
        tubarao = GameObject.FindGameObjectsWithTag("Tubarao");
        barril = GameObject.FindGameObjectsWithTag("Barril");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * uppiesSpeed * Vector3.up;
        
        FindThoseWhoWantUppies();

        foreach (GameObject pacu in pacu) 
        {
            pacu.transform.SetParent(this.transform, true);
        }
        foreach (GameObject bagre in bagre)
        {
            bagre.transform.SetParent(this.transform, true);
        }
        foreach (GameObject tubarao in tubarao)
        {
            tubarao.transform.SetParent(this.transform, true);
        }
        foreach (GameObject barril in barril)
        {
            barril.transform.SetParent(this.transform, true);
        }
    }

    void FindThoseWhoWantUppies()
    {
        pacu = GameObject.FindGameObjectsWithTag("Pacu");
        bagre = GameObject.FindGameObjectsWithTag("Bagre");
        tubarao = GameObject.FindGameObjectsWithTag("Tubarao");
        barril = GameObject.FindGameObjectsWithTag("Barril");
    }
}
