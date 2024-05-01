using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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

    public bool Isstage1 = false;
    public bool IsPaused = false;

    private float initialY;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        // Salva a posi��o Y inicial do jogador
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
        // Calcula a profundidade baseada na posi��o Y inicial e a posi��o Y atual
        depth = initialY - player.transform.position.y;
        // Atualiza o texto da profundidade na UI
        depthText.text = depth.ToString("0.00");

        UpdateScoreText(Money, Diamantes);
        Stage();
    }

    public void Stage()
    {
        if (depth >= 0 && !Isstage1)
        {
            SceneManager.LoadScene("Stage1", LoadSceneMode.Additive);
            Isstage1 = true;
        }
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

    public void Perdeu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        StartCoroutine(RemoveExtraEventSystemsAndListeners());
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
        StartCoroutine(RemoveExtraEventSystemsAndListeners());
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

    IEnumerator RemoveExtraEventSystemsAndListeners()
    {
        // Aguarda um pouco para a cena carregar
        yield return new WaitForSecondsRealtime(0.1f);

        // Chama os m�todos aqui
        RemoveExtraEventSystems();
        RemoveExtraAudioListeners();
    }

    private void RemoveExtraEventSystems()
    {
        EventSystem[] eventSystems = FindObjectsOfType<EventSystem>();

        for (int i = 1; i < eventSystems.Length; i++)
        {
            Destroy(eventSystems[i].gameObject);
        }
    }

    private void RemoveExtraAudioListeners()
    {
        AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();

        for (int i = 1; i < audioListeners.Length; i++)
        {
            Destroy(audioListeners[i]);
        }
    }
}
