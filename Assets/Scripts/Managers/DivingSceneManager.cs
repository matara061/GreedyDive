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
    public AudioManager audioManager;
    public Player player;
    public PlayerO2 _playerO2;
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
    public bool _isUp = false;

    [SerializeField] private GameObject _limitArea;
    [SerializeField] private GameObject _playerAttackBox;

    public float depthSpeed = 1f; // Velocidade de avanço da profundidade

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();

        if (gameManager != null )
        {
            
            if (gameManager.AmuletoAtivo[2]) // Profundidade avança + rapido
            {
                ChangeDepthSpeed(1.5f);
            }

            if (gameManager.AmuletoAtivo[3]) // + tempo de invencibilidade
            {
                player.bonusAmuleto3 = 3;
            }

            if (gameManager.AmuletoAtivo[4]) // - dano pressao
            {
                player.bonusAmuleto4 = 0.5f;
            }

            if (gameManager.AmuletoAtivo[6]) // cura x2
            {
                player.CuraNum = 0.2f;
            }
        }

        if(audioManager != null)
        {
            audioManager.PlayMusic(audioManager.mergulhoCenaBG);
        }

        
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

        if (depth <= -100 && _isUp)  
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

    public void subida() // quando O2 tive baixo, aparecer botao e se apertar chamar isso
    {
        _isUp = true;

        // abrir outra cena tipo stage 1 só que com os spawners em cima 
        SceneManager.LoadScene("StageUp", LoadSceneMode.Additive);

        // rodar Cutcene do player subir na corda 

        _playerAttackBox.SetActive(false);

        /* substituir player pelo outro com novo sistema(Não ataca nem nada, na subida apenas desviar dos obstaculos
           e predadores) */

        // subida vai mais rapido (dps calcular para dar certinho 17% do O2)
        ChangeDepthSpeed(-3f);

        // desativar o collider no topo 
        _limitArea.SetActive(false);

        // aguardar alguns segundos e dar unload no stage1
        StartCoroutine(UnloadSceneDelayed());


    }

    public void UpdateScoreText(int newScore, int newScore2)
    {
        scoreMoney.text = newScore.ToString();
        scoreDiamond.text = newScore2.ToString();
        
    }

    public void Fim()
    {
       // gameManager.BankMoney += Money;
       // gameManager.BankDiamantes += Diamantes;
       _isUp = false;
        audioManager.IsPaused = true;
        IsVitoria = true;
        SceneManager.LoadScene("Vitoria", LoadSceneMode.Additive);
        StartCoroutine(RemoveExtraEventSystemsAndListeners());
    }

    public void Perdeu()
    {
        audioManager.IsPaused = true;
        Time.timeScale = 0f;
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        StartCoroutine(RemoveExtraEventSystemsAndListeners());
    }

    public void Revive()
    {
        player.Revive();
        _playerO2.Revive();
        audioManager.IsPaused = false;
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("GameOver");
    }

    public void Pause()
    {
        audioManager.IsPaused = true;
        Time.timeScale = 0f;
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
        StartCoroutine(RemoveExtraEventSystemsAndListeners());
    }

    private IEnumerator UnloadSceneDelayed()
    {
        yield return new WaitForSeconds(5);

        // Descarrega a cena pelo nome
        SceneManager.UnloadSceneAsync("Stage1");
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
