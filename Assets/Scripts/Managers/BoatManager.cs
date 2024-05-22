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
    public AudioManager audioManager;

    public TextMeshProUGUI gold;
    public TextMeshProUGUI diamond;

    public GameObject insufficientFundsPrefab; // O prefab da mensagem de aviso
    public Transform canvasTransform; // O transform do canvas onde a mensagem será exibida

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();

        UpdadeScoreText();

        if (audioManager != null)
        {
            audioManager.PlayMusic(audioManager.barcoBG);
        }
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
       // audioManager.PlaySFX(audioManager.botao);
        SceneManager.LoadScene("Loja", LoadSceneMode.Additive);
       // Invoke("RemoveExtraEventSystems", 0.1f); // Wait a bit for the scene to load
       // Invoke("RemoveExtraAudioListeners", 0.1f); // Wait a bit for the scene to load
    }

    public void Loja2()
    {
        SceneManager.LoadScene("Loja2", LoadSceneMode.Additive);
        Invoke("RemoveExtraEventSystems", 0.1f); // Wait a bit for the scene to load
        Invoke("RemoveExtraAudioListeners", 0.1f); // Wait a bit for the scene to load
    }

    public void Dive()
    {
        audioManager.PlaySFX(audioManager.mergulhoEfect);
        StartCoroutine(CarregarCena());
    }

    public void Amuleto1()
    {
        if (gameManager.Amuleto[0])
        {
            if (gameManager.AmuletoAtivo[0]) 
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[0] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[0] = true;
                ShowMessage("Amuleto ativado");
            }
        }else
            ShowMessage("Não possui o amuleto");
    }

    public void Amuleto2()
    {
        if (gameManager.Amuleto[1])
        {
            if (gameManager.AmuletoAtivo[1])
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[1] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[1] = true;
                ShowMessage("Amuleto ativado");
            }
        }
        else
            ShowMessage("Não possui o amuleto");
    }

    public void Amuleto3()
    {
        if (gameManager.Amuleto[2])
        {
            if (gameManager.AmuletoAtivo[2])
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[2] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[2] = true;
                ShowMessage("Amuleto ativado");
            }
        }
        else
            ShowMessage("Não possui o amuleto");
    }

    public void Amuleto4()
    {
        if (gameManager.Amuleto[3])
        {
            if (gameManager.AmuletoAtivo[3])
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[3] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[3] = true;
                ShowMessage("Amuleto ativado");
            }
        }
        else
            ShowMessage("Não possui o amuleto");
    }

    public void Amuleto5()
    {
        if (gameManager.Amuleto[4])
        {
            if (gameManager.AmuletoAtivo[4])
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[4] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[4] = true;
                ShowMessage("Amuleto ativado");
            }
        }
        else
            ShowMessage("Não possui o amuleto");
    }

    public void Amuleto6()
    {
        if (gameManager.Amuleto[5])
        {
            if (gameManager.AmuletoAtivo[5])
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[5] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[5] = true;
                ShowMessage("Amuleto ativado");
            }
        }
        else
            ShowMessage("Não possui o amuleto");
    }

    public void Amuleto7()
    {
        if (gameManager.Amuleto[6])
        {
            if (gameManager.AmuletoAtivo[6])
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[6] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[6] = true;
                ShowMessage("Amuleto ativado");
            }
        }
        else
            ShowMessage("Não possui o amuleto");
    }

    public void Amuleto8()
    {
        if (gameManager.Amuleto[7])
        {
            if (gameManager.AmuletoAtivo[7])
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[7] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[7] = true;
                ShowMessage("Amuleto ativado");
            }
        }
        else
            ShowMessage("Não possui o amuleto");
    }

    public void Amuleto9()
    {
        if (gameManager.Amuleto[8])
        {
            if (gameManager.AmuletoAtivo[8])
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[8] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[8] = true;
                ShowMessage("Amuleto ativado");
            }
        }
        else
            ShowMessage("Não possui o amuleto");
    }

    public void Amuleto10()
    {
        if (gameManager.Amuleto[9])
        {
            if (gameManager.AmuletoAtivo[9])
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[9] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                gameManager.AmuletoAtivo[9] = true;
                ShowMessage("Amuleto ativado");
            }
        }
        else
            ShowMessage("Não possui o amuleto");
    }



    private void ShowMessage(string warning)
    {
        // Instancia a mensagem de aviso
        GameObject message = Instantiate(insufficientFundsPrefab, canvasTransform);

        // Configura a mensagem
        TextMeshProUGUI text = message.GetComponent<TextMeshProUGUI>();
        text.text = warning;

        // Destrua a mensagem após alguns segundos
        Destroy(message, 3f);
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

    public void Creditos()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
