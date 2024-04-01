using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatPlayerMovement : MonoBehaviour
{
    public Transform pointA, pointB, pointC;
    public float speed;
    private float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pointA.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= 5 && timer < 10)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            Debug.Log("I live in a low income housing environment that goes by the government name of Section 8. Me and a group of my allies control certain areas of this section to run our illegitimate business. We possess unregistered firearms, stolen vehicles, mind altering inhibitors and only use cash for financial purchases. If anyone would like to settle unfinished altercations, I will be more than happy to release my address. I would like to warn you, I am a very dangerous person and I regularly disobey the law.");
        }
        else if  (timer >= 10 && timer < 15)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointC.position, speed * Time.deltaTime);
        }
        else if (timer >= 15)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }
    }
}
