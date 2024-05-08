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
    public bool IsVitoria = false;
    public bool IsPaused = false;

    public float depthSpeed = 1f; // Velocidade de avanço da profundidade

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula a profundidade baseada no tempo
        depth += Time.deltaTime * depthSpeed;

        // Atualiza o texto da profundidade na UI
        depthText.text = depth.ToString("0.00");

        UpdateScoreText(Money, Diamantes);
        Stage();

        if (depth >= 40 && !IsVitoria)
        {
            Fim();
        }
    }

    public void Stage()
    {
        if (depth >= 0 && !Isstage1)
        {
            SceneManager.LoadScene("Stage1", LoadSceneMode.Additive);
            Isstage1 = true;
        }
    }

    // Chame este método quando o jogador pegar um item que altera a velocidade de avanço da profundidade
    public void ChangeDepthSpeed(float newSpeed)
    {
        depthSpeed = newSpeed;
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
        IsVitoria = true;
        SceneManager.LoadScene("Vitoria", LoadSceneMode.Additive);
        StartCoroutine(RemoveExtraEventSystemsAndListeners());
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

        // Chama os métodos aqui
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
