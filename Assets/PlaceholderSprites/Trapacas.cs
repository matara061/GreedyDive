using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class Trapacas : MonoBehaviour
{

    public GameManager gameManager;
    
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager ==  null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }
    }

    public void GoldPlus()
    {
        gameManager.BankMoney += 1000;
    }

    public void DiamondPlus()
    {
        gameManager.BankDiamantes += 1000;
    }
}
