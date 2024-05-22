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
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
