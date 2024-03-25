using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingSceneManager : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<GameManager>().CurrentOxygenTank == 0)
        {
            Debug.Log("THY END IS NOW");
        }
    }
}
