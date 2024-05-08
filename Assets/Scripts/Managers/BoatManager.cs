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
