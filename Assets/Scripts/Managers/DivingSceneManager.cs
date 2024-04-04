using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DivingSceneManager : MonoBehaviour, IDataPersistence
{
    public GameManager gameManager;

    public int Money;

    public TMP_Text scoreMoney;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void LoadData(GameData data) // jogar isso para o gameManager dps
    {
        this.Money = data.Money;
    }

    public void SaveData(ref GameData data) // jogar isso para o gameManager dps
    {
        data.Money = this.Money;
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

    public void Pause()
    {
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
    }
}
