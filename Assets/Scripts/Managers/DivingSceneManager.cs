using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DivingSceneManager : MonoBehaviour
{
    public GameManager gameManager;
    public Player player;
    public float depth;

    public int Money;
    public int Diamantes;

    public TMP_Text scoreMoney;
    public TMP_Text scoreDiamond;
    public TMP_Text depthText;
    public Slider barraProgresso;
    public GameObject telaLoad;

    private float initialY;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        // Salva a posição Y inicial do jogador
        initialY = player.transform.position.y;
    }

   /* public void LoadData(GameData data) // jogar isso para o gameManager dps
    {
        this.Money = data.Money;
        this.Diamantes = data.Diamantes;
    }

    public void SaveData(ref GameData data) // jogar isso para o gameManager dps
    {
        data.Money = this.Money;
        data.Diamantes = this.Diamantes;
    }*/

    // Update is called once per frame
    void Update()
    {
        // Calcula a profundidade baseada na posição Y inicial e a posição Y atual
        depth = initialY - player.transform.position.y;
        // Atualiza o texto da profundidade na UI
        depthText.text = depth.ToString("0.00");

        UpdateScoreText(Money, Diamantes);
    }

    public void UpdateScoreText(int newScore, int newScore2)
    {
        scoreMoney.text = newScore.ToString();
        scoreDiamond.text = newScore2.ToString();
        
    }

    public void Fim()
    {
        gameManager.BankMoney += Money;
        gameManager.BankDiamantes += Diamantes;
        telaLoad.SetActive(true);
        StartCoroutine(CarregarCena());
    }

    public void Pause()
    {
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
    }

    private IEnumerator CarregarCena()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("BoatScene");
        while (!asyncOperation.isDone)
        {
            //Debug.Log("Carregando: " + (asyncOperation.progress * 100f) + "%");
            this.barraProgresso.value = asyncOperation.progress;
            yield return null;
        }
    }
}
