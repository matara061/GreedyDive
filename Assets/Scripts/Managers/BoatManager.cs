using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class BoatManager : MonoBehaviour
{

    [SerializeField]
    private Slider barraProgresso;

    public GameManager gameManager;

    public TextMeshProUGUI gold;
    public TextMeshProUGUI diamond;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        UpdadeScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdadeScoreText();
    }

    public void UpdadeScoreText()
    {
        gold.text = gameManager.BankMoney.ToString();
        diamond.text = gameManager.BankDiamantes.ToString();
    }

    public void Loja1()
    {
        SceneManager.LoadScene("Loja", LoadSceneMode.Additive);
        Invoke("RemoveExtraEventSystems", 0.1f); // Wait a bit for the scene to load
        Invoke("RemoveExtraAudioListeners", 0.1f); // Wait a bit for the scene to load
    }

    public void Loja2()
    {
        SceneManager.LoadScene("Loja2", LoadSceneMode.Additive);
        Invoke("RemoveExtraEventSystems", 0.1f); // Wait a bit for the scene to load
        Invoke("RemoveExtraAudioListeners", 0.1f); // Wait a bit for the scene to load
    }

    public void Dive()
    {
        StartCoroutine(CarregarCena());
    }

    public void Amuleto1()
    {
        if (gameManager.AmuletoAtivo[0]) // dps add tb "&& gameManager.Amuleto[0] == true"
        {
            // mudar sprite do botao
            gameManager.AmuletoAtivo[0] = false;
        }
        else
        {
            // mudar sprite do botao
            gameManager.AmuletoAtivo[0] = true;
        }
    }

    public void Amuleto2()
    {
        if (gameManager.AmuletoAtivo[1]) // dps add tb "&& gameManager.Amuleto[0] == true"
        {
            // mudar sprite do botao
            gameManager.AmuletoAtivo[1] = false;
        }
        else
        {
            // mudar sprite do botao
            gameManager.AmuletoAtivo[1] = true;
        }
    }

    public void Amuleto3()
    {
        if (gameManager.AmuletoAtivo[2]) // dps add tb "&& gameManager.Amuleto[0] == true"
        {
            // mudar sprite do botao
            gameManager.AmuletoAtivo[2] = false;
        }
        else
        {
            // mudar sprite do botao
            gameManager.AmuletoAtivo[2] = true;
        }
    }

    private IEnumerator CarregarCena()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("TestesM");
        while (!asyncOperation.isDone)
        {
            //Debug.Log("Carregando: " + (asyncOperation.progress * 100f) + "%");
            this.barraProgresso.value = asyncOperation.progress;
            yield return null;
        }
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

    public void Quit()
    {
        Application.Quit();
    }
}
