using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreManager : MonoBehaviour
{
    public int Gold;
    public int Diamond;
    public GameManager gameManager;


    private Dictionary<string, Tuple<int, int>> Roupas = new Dictionary<string, Tuple<int, int>>
    {
        { "Roupa1", new Tuple<int, int>(10, 0) },
        { "Roupa2", new Tuple<int, int>(20, 0) },
        { "Roupa3", new Tuple<int, int>(30, 0) },
        { "Roupa4", new Tuple<int, int>(0, 1) },
        { "Roupa5", new Tuple<int, int>(0, 1) },
        { "Roupa6", new Tuple<int, int>(0, 1) },
        { "Roupa7", new Tuple<int, int>(0, 1) },
        { "Roupa8", new Tuple<int, int>(0, 1) },
        { "Roupa9", new Tuple<int, int>(0, 1) },
        { "Roupa10", new Tuple<int, int>(0, 1) }
    };

    private Dictionary<string, Tuple<int, int>> Armas = new Dictionary<string, Tuple<int, int>>
    {
        { "Arma1", new Tuple<int, int>(10, 0) },
        { "Arma2", new Tuple<int, int>(10, 0) },
        { "Arma3", new Tuple<int, int>(20, 0) },
        { "Arma4", new Tuple<int, int>(0, 1) },
        { "Arma5", new Tuple<int, int>(0, 1) },
        { "Arma6", new Tuple<int, int>(0, 1) },
        { "Arma7", new Tuple<int, int>(0, 1) },
        { "Arma8", new Tuple<int, int>(0, 1) },
        { "Arma9", new Tuple<int, int>(0, 1) },
        { "Arma10", new Tuple<int, int>(0, 1) }
    };

    private Dictionary<string, Tuple<int, int>> Pes = new Dictionary<string, Tuple<int, int>>
    {
        { "Pes1", new Tuple<int, int>(10, 0) },
        { "Pes2", new Tuple<int, int>(20, 0) },
        { "Pes3", new Tuple<int, int>(30, 0) },
        { "Pes4", new Tuple<int, int>(0, 1) },
        { "Pes5", new Tuple<int, int>(0, 1) },
        { "Pes6", new Tuple<int, int>(0, 1) },
        { "Pes7", new Tuple<int, int>(0, 1) },
        { "Pes8", new Tuple<int, int>(0, 1) },
        { "Pes9", new Tuple<int, int>(0, 1) },
        { "Pes10", new Tuple<int, int>(0, 1) }
    };

    private Dictionary<string, Tuple<int, int>> Tanks = new Dictionary<string, Tuple<int, int>>
    {
        { "Tank1", new Tuple<int, int>(10, 0) },
        { "Tank2", new Tuple<int, int>(20, 0) },
        { "Tank3", new Tuple<int, int>(30, 0) },
        { "Tank4", new Tuple<int, int>(0, 1) },
        { "Tank5", new Tuple<int, int>(0, 1) },
        { "Tank6", new Tuple<int, int>(0, 1) },
        { "Tank7", new Tuple<int, int>(0, 1) },
        { "Tank8", new Tuple<int, int>(0, 1) },
        { "Tank9", new Tuple<int, int>(0, 1) },
        { "Tank10", new Tuple<int, int>(0, 1) }
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
        ItemDisplay();
    }

    public void ItemDisplay()
    {
        // Obt�m o valor atual de CurrentHarpoon
        string currentHarpoon = gameManager.CurrentHarpoon;
        string currentDivingSuit = gameManager.CurrentDivingSuit;
        string currentDivingFins = gameManager.CurrentDivingFins;
        string currentOxygenTank = gameManager.CurrentOxygenTank;

        // Verifica se o valor atual de CurrentHarpoon est� no dicion�rio Armas
        if (Armas.ContainsKey(currentHarpoon))
        {
            // Encontra o �ndice do valor atual no dicion�rio
            int currentIndex = new List<string>(Armas.Keys).IndexOf(currentHarpoon);

            // Verifica se h� um pr�ximo valor na lista
            if (currentIndex < Armas.Count - 1)
            {
                // Obt�m o pr�ximo valor na lista
                string nextHarpoon = new List<string>(Armas.Keys)[currentIndex + 1];

                if(Armas.TryGetValue(nextHarpoon, out Tuple<int, int> valor))
                {
                    Debug.Log("O pr�ximo valor na lista �: " + nextHarpoon + " no pre�o de: " + valor.Item1 + " Golds");
                }

                // Usa Debug.Log para expressar o pr�ximo valor na lista
                //Debug.Log("O pr�ximo valor na lista �: " + nextHarpoon);
            }
            else
            {
                Debug.Log("Este � o �ltimo valor na lista.");
            }
        }
        else
        {
            Debug.Log("O valor atual de CurrentHarpoon n�o est� no dicion�rio Armas.");
        }

        // Verifica se o valor atual de CurrentDivingSuit est� no dicion�rio Roupas
        if (Roupas.ContainsKey(currentDivingSuit))
        {
            // Encontra o �ndice do valor atual no dicion�rio
            int currentIndex = new List<string>(Roupas.Keys).IndexOf(currentDivingSuit);

            // Verifica se h� um pr�ximo valor na lista
            if (currentIndex < Roupas.Count - 1)
            {
                // Obt�m o pr�ximo valor na lista
                string nextDivingSuit = new List<string>(Roupas.Keys)[currentIndex + 1];

                if (Roupas.TryGetValue(nextDivingSuit, out Tuple<int, int> valor))
                {
                    Debug.Log("O pr�ximo valor na lista �: " + nextDivingSuit + " no pre�o de: " + valor.Item1 + " Golds");
                }

                // Usa Debug.Log para expressar o pr�ximo valor na lista
                //Debug.Log("O pr�ximo valor na lista �: " + nextHarpoon);
            }
            else
            {
                Debug.Log("Este � o �ltimo valor na lista.");
            }
        }
        else
        {
            Debug.Log("O valor atual de CurrentHarpoon n�o est� no dicion�rio Roupas.");
        }

        // Verifica se o valor atual de CurrentDivingFins est� no dicion�rio Pes
        if (Pes.ContainsKey(currentDivingFins))
        {
            // Encontra o �ndice do valor atual no dicion�rio
            int currentIndex = new List<string>(Pes.Keys).IndexOf(currentDivingFins);

            // Verifica se h� um pr�ximo valor na lista
            if (currentIndex < Pes.Count - 1)
            {
                // Obt�m o pr�ximo valor na lista
                string nextDivingFins = new List<string>(Pes.Keys)[currentIndex + 1];

                if (Pes.TryGetValue(nextDivingFins, out Tuple<int, int> valor))
                {
                    Debug.Log("O pr�ximo valor na lista �: " + nextDivingFins + " no pre�o de: " + valor.Item1 + " Golds");
                }

                // Usa Debug.Log para expressar o pr�ximo valor na lista
                //Debug.Log("O pr�ximo valor na lista �: " + nextHarpoon);
            }
            else
            {
                Debug.Log("Este � o �ltimo valor na lista.");
            }
        }
        else
        {
            Debug.Log("O valor atual de CurrentDivingFins n�o est� no dicion�rio Pes.");
        }

        // Verifica se o valor atual de CurrentOxygenTank est� no dicion�rio Tanks
        if (Tanks.ContainsKey(currentOxygenTank))
        {
            // Encontra o �ndice do valor atual no dicion�rio
            int currentIndex = new List<string>(Tanks.Keys).IndexOf(currentOxygenTank);

            // Verifica se h� um pr�ximo valor na lista
            if (currentIndex < Tanks.Count - 1)
            {
                // Obt�m o pr�ximo valor na lista
                string nextOxygenTank = new List<string>(Tanks.Keys)[currentIndex + 1];

                if (Tanks.TryGetValue(nextOxygenTank, out Tuple<int, int> valor))
                {
                    Debug.Log("O pr�ximo valor na lista �: " + nextOxygenTank + " no pre�o de: " + valor.Item1 + " Golds");
                }

                // Usa Debug.Log para expressar o pr�ximo valor na lista
                //Debug.Log("O pr�ximo valor na lista �: " + nextHarpoon);
            }
            else
            {
                Debug.Log("Este � o �ltimo valor na lista.");
            }
        }
        else
        {
            Debug.Log("O valor atual de CurrentOxygenTank n�o est� no dicion�rio Tanks.");
        }
    }
}
