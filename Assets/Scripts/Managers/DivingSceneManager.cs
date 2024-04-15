using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DivingSceneManager : MonoBehaviour, IDataPersistence
{
    public GameManager gameManager;
    public Player player;

    public int Money;

    public TMP_Text scoreMoney;
    public TMP_Text depthText;

    private float initialY;

    // Start is called before the first frame update
    void Start()
    {
        // Salva a posição Y inicial do jogador
        initialY = player.transform.position.y;
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
        // Calcula a profundidade baseada na posição Y inicial e a posição Y atual
        float depth = initialY - player.transform.position.y;
        // Atualiza o texto da profundidade na UI
        depthText.text = depth.ToString("0.00");

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
