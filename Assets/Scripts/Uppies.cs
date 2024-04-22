using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Uppies : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> uppiesList = new();
    public float uppiesInstensity, playerUppiesIntensity;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FindThoseWhoWantUppies();
        
        player.GetComponent<Rigidbody2D>().AddForce(transform.up * playerUppiesIntensity, ForceMode2D.Force);

        /*
        foreach (GameObject pacu in GameObject.FindGameObjectsWithTag("Pacu"))
        {
            pacu.GetComponent<Rigidbody2D>().AddForce(transform.up * uppiesInstensity, ForceMode2D.Force);
            //pacu.transform.Translate(transform.up * uppiesInstensity * Time.deltaTime, Space.World);
        }
        */
        foreach (GameObject bagre in GameObject.FindGameObjectsWithTag("Bagre"))
        {
            bagre.GetComponent<Rigidbody2D>().AddForce(transform.up * uppiesInstensity, ForceMode2D.Force);
        }
        foreach (GameObject tubarao in GameObject.FindGameObjectsWithTag("Tubarao"))
        {
            tubarao.GetComponent<Rigidbody2D>().AddForce(transform.up * uppiesInstensity, ForceMode2D.Force);
        }
        foreach (GameObject barril in GameObject.FindGameObjectsWithTag("Barril"))
        {
            barril.GetComponent<Rigidbody2D>().AddForce(transform.up * uppiesInstensity, ForceMode2D.Force);
        }
    }

    void FindThoseWhoWantUppies()
    {
        /*
        foreach (GameObject pacu in GameObject.FindGameObjectsWithTag("Pacu"))
        {
            if (!uppiesList.Contains(pacu))
            {
                uppiesList.Add(pacu);
            }
        }
        */
        foreach (GameObject bagre in GameObject.FindGameObjectsWithTag("Bagre"))
        {
            if (!uppiesList.Contains(bagre))
            {
                uppiesList.Add(bagre);
            }
        }
        foreach (GameObject tubarao in GameObject.FindGameObjectsWithTag("Tubarao"))
        {
            if (!uppiesList.Contains(tubarao))
            {
                uppiesList.Add(tubarao);
            }
        }
        foreach (GameObject barril in GameObject.FindGameObjectsWithTag("Barril"))
        {
            if (!uppiesList.Contains(barril))
            {
                uppiesList.Add(barril);
            }
        }
    }
}
