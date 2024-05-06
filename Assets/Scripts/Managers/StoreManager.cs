using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StoreManager : MonoBehaviour
{
    public int Gold;
    public int Diamond;
    public GameManager gameManager;

    string layerName;

    public Animator anim;

    public TextMeshProUGUI goldText;
    public TextMeshProUGUI diamondText;
    public TextMeshProUGUI armaPriceText;
    public TextMeshProUGUI roupaPriceText;
    public TextMeshProUGUI pePriceText;
    public TextMeshProUGUI tankPriceText;

    public Image armaIcon;
    public Image roupaIcon;
    public Image pesIcon;
    public Image tankIcon;

    public Sprite[] armasSprites;
    public Sprite[] roupasSprites;
    public Sprite[] pesSprites;
    public Sprite[] tankSprites;

    public GameObject insufficientFundsPrefab; // O prefab da mensagem de aviso
    public Transform canvasTransform; // O transform do canvas onde a mensagem será exibida


    private Dictionary<string, Tuple<int, int>> Roupas = new Dictionary<string, Tuple<int, int>>
    {
        { "Roupa1", new Tuple<int, int>(0, 0) },
        { "Roupa2", new Tuple<int, int>(1000, 0) },
        { "Roupa3", new Tuple<int, int>(3400, 0) },
        { "Roupa4", new Tuple<int, int>(9500, 0) },
        { "Roupa5", new Tuple<int, int>(16700, 0) },
        { "Roupa6", new Tuple<int, int>(25000, 0) },
        { "Roupa7", new Tuple<int, int>(40000, 0) },
        { "Roupa8", new Tuple<int, int>(59000, 0) },
        { "Roupa9", new Tuple<int, int>(72000, 0) },
        { "Roupa10", new Tuple<int, int>(95300, 0) }
    };

    private Dictionary<string, Tuple<int, int>> Armas = new Dictionary<string, Tuple<int, int>>
    {
        { "Arma1", new Tuple<int, int>(0, 0) },
        { "Arma2", new Tuple<int, int>(2500, 0) },
        { "Arma3", new Tuple<int, int>(5000, 0) },
        { "Arma4", new Tuple<int, int>(10900, 0) },
        { "Arma5", new Tuple<int, int>(17300, 0) },
        { "Arma6", new Tuple<int, int>(26250, 0) },
        { "Arma7", new Tuple<int, int>(42600, 0) },
        { "Arma8", new Tuple<int, int>(60000, 0) },
        { "Arma9", new Tuple<int, int>(74000, 0) },
        { "Arma10", new Tuple<int, int>(100000, 0) }
    };

    private Dictionary<string, Tuple<int, int>> Pes = new Dictionary<string, Tuple<int, int>>
    {
        { "Pes1", new Tuple<int, int>(0, 0) },
        { "Pes2", new Tuple<int, int>(3000, 0) },
        { "Pes3", new Tuple<int, int>(6200, 0) },
        { "Pes4", new Tuple<int, int>(12000, 0) },
        { "Pes5", new Tuple<int, int>(20300, 0) },
        { "Pes6", new Tuple<int, int>(27900, 0) },
        { "Pes7", new Tuple<int, int>(44700, 0) },
        { "Pes8", new Tuple<int, int>(61200, 0) },
        { "Pes9", new Tuple<int, int>(79800, 0) },
        { "Pes10", new Tuple<int, int>(102000, 0) }
    };

    private Dictionary<string, Tuple<int, int>> Tanks = new Dictionary<string, Tuple<int, int>>
    {
        { "Tank1", new Tuple<int, int>(0, 0) },
        { "Tank2", new Tuple<int, int>(1500, 0) },
        { "Tank3", new Tuple<int, int>(4000, 0) },
        { "Tank4", new Tuple<int, int>(8200, 0) },
        { "Tank5", new Tuple<int, int>(15300, 0) },
        { "Tank6", new Tuple<int, int>(25000, 0) },
        { "Tank7", new Tuple<int, int>(38700, 0) },
        { "Tank8", new Tuple<int, int>(54000, 0) },
        { "Tank9", new Tuple<int, int>(73900, 0) },
        { "Tank10", new Tuple<int, int>(97000, 0) }
    };

    private Dictionary<string, Tuple<int, int>> Amuletos = new Dictionary<string, Tuple<int, int>>
    {
        { "Tank2", new Tuple<int, int>(10, 0) },
        { "Tank3", new Tuple<int, int>(20, 0) },
        { "Tank4", new Tuple<int, int>(0, 1) },
        { "Tank5", new Tuple<int, int>(0, 1) },
        { "Tank6", new Tuple<int, int>(0, 1) },
        { "Tank7", new Tuple<int, int>(0, 1) },
        { "Tank8", new Tuple<int, int>(0, 1) },
        { "Tank9", new Tuple<int, int>(0, 1) },
        { "Tank10", new Tuple<int, int>(0, 1) }
    };

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        // Obtenha o número da layer
        int layerNumber = gameObject.layer;

        // Converta o número da layer em um nome de layer
        layerName = LayerMask.LayerToName(layerNumber);

        // Verifique se o nome da layer é "loja1"
        if (layerName == "Loja1")
        {
            // Se a layer for "loja1", faça alguma ação
            ItemDisplay();
        }
    }

    private void Update()
    {
        goldText.text = gameManager.BankMoney.ToString();
        diamondText.text = gameManager.BankDiamantes.ToString();
    }

    public void ItemDisplay()
    {
        // Obtém o valor atual de CurrentHarpoon
        string currentHarpoon = gameManager.CurrentHarpoon;
        string currentDivingSuit = gameManager.CurrentDivingSuit;
        string currentDivingFins = gameManager.CurrentDivingFins;
        string currentOxygenTank = gameManager.CurrentOxygenTank;

        // Verifica se o valor atual de CurrentHarpoon está no dicionário Armas
        if (Armas.ContainsKey(currentHarpoon))
        {
            // Encontra o índice do valor atual no dicionário
            int currentIndex = new List<string>(Armas.Keys).IndexOf(currentHarpoon);

            // Verifica se há um próximo valor na lista
            if (currentIndex < Armas.Count - 1)
            {
                // Obtém o próximo valor na lista
                string nextHarpoon = new List<string>(Armas.Keys)[currentIndex + 1];

                if(Armas.TryGetValue(nextHarpoon, out Tuple<int, int> valor))
                {
                    Debug.Log("O próximo valor na lista é: " + nextHarpoon + " no preço de: " + valor.Item1 + " Golds");

                    // Troca o sprite do ícone da arma para o próximo na lista
                    armaIcon.sprite = armasSprites[currentIndex + 1];

                    armaPriceText.text = valor.Item1.ToString();
                }

                // Usa Debug.Log para expressar o próximo valor na lista
                //Debug.Log("O próximo valor na lista é: " + nextHarpoon);
            }
            else
            {
                Debug.Log("Este é o último valor na lista.");
            }
        }
        else
        {
            Debug.Log("O valor atual de CurrentHarpoon não está no dicionário Armas.");
        }

        // Verifica se o valor atual de CurrentDivingSuit está no dicionário Roupas
        if (Roupas.ContainsKey(currentDivingSuit))
        {
            // Encontra o índice do valor atual no dicionário
            int currentIndex = new List<string>(Roupas.Keys).IndexOf(currentDivingSuit);

            // Verifica se há um próximo valor na lista
            if (currentIndex < Roupas.Count - 1)
            {
                // Obtém o próximo valor na lista
                string nextDivingSuit = new List<string>(Roupas.Keys)[currentIndex + 1];

                if (Roupas.TryGetValue(nextDivingSuit, out Tuple<int, int> valor))
                {
                    Debug.Log("O próximo valor na lista é: " + nextDivingSuit + " no preço de: " + valor.Item1 + " Golds");

                    roupaIcon.sprite = roupasSprites[currentIndex + 1];

                    roupaPriceText.text = valor.Item1.ToString();
                }

                // Usa Debug.Log para expressar o próximo valor na lista
                //Debug.Log("O próximo valor na lista é: " + nextHarpoon);
            }
            else
            {
                Debug.Log("Este é o último valor na lista.");
            }
        }
        else
        {
            Debug.Log("O valor atual de CurrentHarpoon não está no dicionário Roupas.");
        }

        // Verifica se o valor atual de CurrentDivingFins está no dicionário Pes
        if (Pes.ContainsKey(currentDivingFins))
        {
            // Encontra o índice do valor atual no dicionário
            int currentIndex = new List<string>(Pes.Keys).IndexOf(currentDivingFins);

            // Verifica se há um próximo valor na lista
            if (currentIndex < Pes.Count - 1)
            {
                // Obtém o próximo valor na lista
                string nextDivingFins = new List<string>(Pes.Keys)[currentIndex + 1];

                if (Pes.TryGetValue(nextDivingFins, out Tuple<int, int> valor))
                {
                    Debug.Log("O próximo valor na lista é: " + nextDivingFins + " no preço de: " + valor.Item1 + " Golds");

                    pesIcon.sprite = pesSprites[currentIndex + 1];

                    pePriceText.text = valor.Item1.ToString();
                }

                // Usa Debug.Log para expressar o próximo valor na lista
                //Debug.Log("O próximo valor na lista é: " + nextHarpoon);
            }
            else
            {
                Debug.Log("Este é o último valor na lista.");
            }
        }
        else
        {
            Debug.Log("O valor atual de CurrentDivingFins não está no dicionário Pes.");
        }

        // Verifica se o valor atual de CurrentOxygenTank está no dicionário Tanks
        if (Tanks.ContainsKey(currentOxygenTank))
        {
            // Encontra o índice do valor atual no dicionário
            int currentIndex = new List<string>(Tanks.Keys).IndexOf(currentOxygenTank);

            // Verifica se há um próximo valor na lista
            if (currentIndex < Tanks.Count - 1)
            {
                // Obtém o próximo valor na lista
                string nextOxygenTank = new List<string>(Tanks.Keys)[currentIndex + 1];

                if (Tanks.TryGetValue(nextOxygenTank, out Tuple<int, int> valor))
                {
                    Debug.Log("O próximo valor na lista é: " + nextOxygenTank + " no preço de: " + valor.Item1 + " Golds");

                    tankIcon.sprite = tankSprites[currentIndex + 1];

                    tankPriceText.text = valor.Item1.ToString();
                }

                // Usa Debug.Log para expressar o próximo valor na lista
                //Debug.Log("O próximo valor na lista é: " + nextHarpoon);
            }
            else
            {
                Debug.Log("Este é o último valor na lista.");
            }
        }
        else
        {
            Debug.Log("O valor atual de CurrentOxygenTank não está no dicionário Tanks.");
        }
    }

    public void ComprarArma()
    {
        // Obtém o valor atual de CurrentHarpoon
        string currentHarpoon = gameManager.CurrentHarpoon;

        // Verifica se o valor atual de CurrentHarpoon está no dicionário Armas
        if (Armas.ContainsKey(currentHarpoon))
        {
            // Encontra o índice do valor atual no dicionário
            int currentIndex = new List<string>(Armas.Keys).IndexOf(currentHarpoon);

            // Verifica se há um próximo valor na lista
            if (currentIndex < Armas.Count - 1)
            {
                // Obtém o próximo valor na lista
                string nextHarpoon = new List<string>(Armas.Keys)[currentIndex + 1];

                if (Armas.TryGetValue(nextHarpoon, out Tuple<int, int> valor))
                {
                    // Verifica se o jogador tem dinheiro suficiente para comprar a arma
                    if (gameManager.BankMoney >= valor.Item1)
                    {
                        // Atualiza CurrentHarpoon para a próxima arma
                        gameManager.CurrentHarpoon = nextHarpoon;

                        // Deduz o preço da arma do dinheiro do jogador
                        gameManager.BankMoney -= valor.Item1;

                        ItemDisplay();

                        Debug.Log("Você comprou a arma: " + nextHarpoon);
                    }
                    else
                    {
                        // O jogador não tem dinheiro suficiente, mostre a mensagem de aviso
                        ShowInsufficientFundsMessage();
                    }
                }
            }
            else
            {
                Debug.Log("Esta é a última arma na lista.");
            }
        }
        else
        {
            Debug.Log("O valor atual de CurrentHarpoon não está no dicionário Armas.");
        }
    }

    public void ComprarRoupa()
    {
        // Obtém o valor atual de CurrentDivingSuit
        string currentDivingSuit = gameManager.CurrentDivingSuit;

        // Verifica se o valor atual de CurrentHarpoon está no dicionário Armas
        if (Roupas.ContainsKey(currentDivingSuit))
        {
            // Encontra o índice do valor atual no dicionário
            int currentIndex = new List<string>(Roupas.Keys).IndexOf(currentDivingSuit);

            // Verifica se há um próximo valor na lista
            if (currentIndex < Roupas.Count - 1)
            {
                // Obtém o próximo valor na lista
                string nextDivingSuit = new List<string>(Roupas.Keys)[currentIndex + 1];

                if (Roupas.TryGetValue(nextDivingSuit, out Tuple<int, int> valor))
                {
                    // Verifica se o jogador tem dinheiro suficiente para comprar a arma
                    if (gameManager.BankMoney >= valor.Item1)
                    {
                        // Atualiza CurrentHarpoon para a próxima arma
                        gameManager.CurrentDivingSuit = nextDivingSuit;

                        // Deduz o preço da arma do dinheiro do jogador
                        gameManager.BankMoney -= valor.Item1;

                        ItemDisplay();

                        Debug.Log("Você comprou a roupa: " + nextDivingSuit);
                    }
                    else
                    {
                        // O jogador não tem dinheiro suficiente, mostre a mensagem de aviso
                        ShowInsufficientFundsMessage();
                    }
                }
            }
            else
            {
                Debug.Log("Esta é a última roupa na lista.");
            }
        }
        else
        {
            Debug.Log("O valor atual de CurrentDivingSuit não está no dicionário Roupas.");
        }
    }

    public void ComprarPes()
    {
        // Obtém o valor atual de CurrentDivingSuit
        string currentDivingFins = gameManager.CurrentDivingFins;

        // Verifica se o valor atual de CurrentHarpoon está no dicionário Armas
        if (Pes.ContainsKey(currentDivingFins))
        {
            // Encontra o índice do valor atual no dicionário
            int currentIndex = new List<string>(Pes.Keys).IndexOf(currentDivingFins);

            // Verifica se há um próximo valor na lista
            if (currentIndex < Pes.Count - 1)
            {
                // Obtém o próximo valor na lista
                string nextDivingFins = new List<string>(Pes.Keys)[currentIndex + 1];

                if (Pes.TryGetValue(nextDivingFins, out Tuple<int, int> valor))
                {
                    // Verifica se o jogador tem dinheiro suficiente para comprar a arma
                    if (gameManager.BankMoney >= valor.Item1)
                    {
                        // Atualiza CurrentHarpoon para a próxima arma
                        gameManager.CurrentDivingFins = nextDivingFins;

                        // Deduz o preço da arma do dinheiro do jogador
                        gameManager.BankMoney -= valor.Item1;

                        ItemDisplay();

                        Debug.Log("Você comprou o pe: " + nextDivingFins);
                    }
                    else
                    {
                        // O jogador não tem dinheiro suficiente, mostre a mensagem de aviso
                        ShowInsufficientFundsMessage();
                    }
                }
            }
            else
            {
                Debug.Log("Esta é o último pe na lista.");
            }
        }
        else
        {
            Debug.Log("O valor atual de CurrentDivingFins não está no dicionário Pes.");
        }
    }

    public void ComprarTank()
    {
        // Obtém o valor atual de CurrentDivingSuit
        string currentOxygenTank = gameManager.CurrentOxygenTank;

        // Verifica se o valor atual de CurrentHarpoon está no dicionário Armas
        if (Tanks.ContainsKey(currentOxygenTank))
        {
            // Encontra o índice do valor atual no dicionário
            int currentIndex = new List<string>(Tanks.Keys).IndexOf(currentOxygenTank);

            // Verifica se há um próximo valor na lista
            if (currentIndex < Tanks.Count - 1)
            {
                // Obtém o próximo valor na lista
                string nextOxygenTank = new List<string>(Tanks.Keys)[currentIndex + 1];

                if (Tanks.TryGetValue(nextOxygenTank, out Tuple<int, int> valor))
                {
                    // Verifica se o jogador tem dinheiro suficiente para comprar a arma
                    if (gameManager.BankMoney >= valor.Item1)
                    {
                        // Atualiza CurrentHarpoon para a próxima arma
                        gameManager.CurrentOxygenTank = nextOxygenTank;

                        // Deduz o preço da arma do dinheiro do jogador
                        gameManager.BankMoney -= valor.Item1;

                        ItemDisplay();

                        Debug.Log("Você comprou o tank: " + nextOxygenTank);
                    }
                    else
                    {
                        // O jogador não tem dinheiro suficiente, mostre a mensagem de aviso
                        ShowInsufficientFundsMessage();
                    }
                }
            }
            else
            {
                Debug.Log("Esta é o último tank na lista.");
            }
        }
        else
        {
            Debug.Log("O valor atual de CurrentOxygenTank não está no dicionário Tanks.");
        }
    }

    public void ComprarAmuleto1()
    {

    }

    public void ComprarAmuleto2()
    {

    }

    public void ComprarAmuleto3()
    {

    }

    public void ComprarAmuleto4()
    {

    }

    public void ComprarAmuleto5()
    {

    }

    public void ComprarAmuleto6()
    {

    }

    public void ComprarAmuleto7()
    {

    }
    public void ComprarAmuleto8()
    {

    }
    public void ComprarAmuleto9()
    {

    }
    public void ComprarAmuleto10()
    {

    }

    private void ShowInsufficientFundsMessage()
    {
        // Instancia a mensagem de aviso
        GameObject message = Instantiate(insufficientFundsPrefab, canvasTransform);

        // Configura a mensagem
        TextMeshProUGUI text = message.GetComponent<TextMeshProUGUI>();
        text.text = "Dinheiro insuficiente";

        // Destrua a mensagem após alguns segundos
        Destroy(message, 3f);
    }

    public void sair()
    {
        if (layerName == "Loja1")
        {
            SceneManager.UnloadSceneAsync("Loja");
        }else
            SceneManager.UnloadSceneAsync("Loja2");

    }

    public void SetaR()
    {
        anim.Play("LojaDiamantes");
    }

    public void SetaL()
    {
        anim.Play("LojaAmuletos");
    }


}
