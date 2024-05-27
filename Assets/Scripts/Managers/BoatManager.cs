using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class BoatManager : MonoBehaviour, IDataPersistence
{

    [SerializeField]
    private Slider barraProgresso;

    [Header("Amuletos imagens")]
    public Image[] amuletosIcon;

    [Header("Amuletos sprites")]
    public Sprite[] _amuletosOn;
    public Sprite[] _amuletosOff;

    public GameManager gameManager;
    public AudioManager audioManager;

    public TextMeshProUGUI gold;
    public TextMeshProUGUI diamond;

    public GameObject insufficientFundsPrefab; // O prefab da mensagem de aviso
    public Transform canvasTransform; // O transform do canvas onde a mensagem será exibida

    private bool _playMusic = false;

    

    
    void Start()
    {
       // gameManager = FindAnyObjectByType<GameManager>();
       // audioManager = FindAnyObjectByType<AudioManager>();

        UpdadeScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdadeScoreText();
        PlayMusic();
    }

    public void UpdadeScoreText()
    {
        if(gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }

        gold.text = gameManager.BankMoney.ToString();
        diamond.text = gameManager.BankDiamantes.ToString();
    }

    public void DisplayAmuletos()
    {
        for (int i = 0; i < gameManager.AmuletoAtivo.Length; i++)
        {
            if (gameManager.AmuletoAtivo[i])
            {
                amuletosIcon[i].sprite = _amuletosOn[i];
            }else
                amuletosIcon[i].sprite = _amuletosOff[i];
            
                
        }
    }

    public void PlayMusic()
    {
        if (!_playMusic)
        {
            if (audioManager != null)
            {
                audioManager.IsPaused = false;
                audioManager.PlayMusic(audioManager.barcoBG);
                _playMusic = true;
            }
            else
            {
                audioManager = FindAnyObjectByType<AudioManager>();
                audioManager.IsPaused = false;
                audioManager.PlayMusic(audioManager.barcoBG);
                _playMusic = true;
            }
        }
    }

    public void LoadData(GameData data) 
    {
        
    }

    public void SaveData(ref GameData data) 
    {
        data.Money = gameManager.BankMoney;
        data.Diamantes = gameManager.BankDiamantes;
        data.CurrentHarpoon = gameManager.CurrentHarpoon;
        data.CurrentDivingSuit = gameManager.CurrentDivingSuit;
        data.CurrentDivingFins = gameManager.CurrentDivingFins;
        data.CurrentOxygenTank = gameManager.CurrentOxygenTank;

        data.Amuleto = gameManager.Amuleto;
        data.AmuletoAtivo = gameManager.AmuletoAtivo;
    }

    public void Loja1()
    {
        SceneManager.LoadScene("Loja", LoadSceneMode.Additive);
    }

    public void Loja2()
    {
        SceneManager.LoadScene("Loja2", LoadSceneMode.Additive);
    }

    public void Dive()
    {
        StartCoroutine(CarregarCena());
    }

    public void BotaoSong()
    {
        audioManager.PlaySFX(audioManager.botao);
    }

    public void MergulhoSom()
    {
        audioManager.PlaySFX(audioManager.mergulhoEfect);
    }

    public void Amuleto1()
    {
        if (gameManager.Amuleto[0])
        {
            if (gameManager.AmuletoAtivo[0]) 
            {
                // mudar sprite do botao
                amuletosIcon[0].sprite = _amuletosOff[0];
                gameManager.AmuletoAtivo[0] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                amuletosIcon[0].sprite = _amuletosOn[0];
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
                amuletosIcon[1].sprite = _amuletosOff[1];
                gameManager.AmuletoAtivo[1] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                amuletosIcon[1].sprite = _amuletosOn[1];
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
                amuletosIcon[2].sprite = _amuletosOff[2];
                gameManager.AmuletoAtivo[2] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                amuletosIcon[2].sprite = _amuletosOn[2];
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
                amuletosIcon[3].sprite = _amuletosOff[3];
                gameManager.AmuletoAtivo[3] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                amuletosIcon[3].sprite = _amuletosOn[3];
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
                amuletosIcon[4].sprite = _amuletosOff[4];
                gameManager.AmuletoAtivo[4] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                amuletosIcon[4].sprite = _amuletosOn[4];
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
                amuletosIcon[5].sprite = _amuletosOff[5];
                gameManager.AmuletoAtivo[5] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                amuletosIcon[5].sprite = _amuletosOn[5];
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
                amuletosIcon[6].sprite = _amuletosOff[6];
                gameManager.AmuletoAtivo[6] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                amuletosIcon[6].sprite = _amuletosOn[6];
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
                amuletosIcon[7].sprite = _amuletosOff[7];
                gameManager.AmuletoAtivo[7] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                amuletosIcon[7].sprite = _amuletosOn[7];
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
                amuletosIcon[8].sprite = _amuletosOff[8];
                gameManager.AmuletoAtivo[8] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                amuletosIcon[8].sprite = _amuletosOn[8];
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
                amuletosIcon[9].sprite = _amuletosOff[9];
                gameManager.AmuletoAtivo[9] = false;
                ShowMessage("Amuleto desativado");

            }
            else
            {
                // mudar sprite do botao
                amuletosIcon[9].sprite = _amuletosOn[9];
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

    public void Creditos()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
