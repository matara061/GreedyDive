using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DivingSceneManager : MonoBehaviour
{
    public GameManager gameManager;

    public int Money;

    public TMP_Text scoreMoney;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       /* if (gameManager.GetComponent<GameManager>().CurrentOxygenTank == 0)
        {
            Debug.Log("THY END IS NOW");
        }*/

        UpdateScoreText(Money);
    }

    public void UpdateScoreText(int newScore)
    {
        scoreMoney.text = "<rotate=90>"+ newScore.ToString();
    }

    public void Fim()
    {
        gameManager.BankMoney += Money;
    }
}
