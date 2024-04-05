using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerO2 : MonoBehaviour
{
    public Slider oxygenSlider; // Referência ao slider de oxigênio
    public float maxOxygen = 100f; // Quantidade máxima de oxigênio
    public float oxygenDecreaseRate = 0.5f; // Taxa de diminuição de oxigênio por segundo

    private float currentOxygen; // Quantidade atual de oxigênio

    void Start()
    {
        SetMaxOxygen(maxOxygen); // Inicializa o oxigênio no máximo
    }

    void Update()
    {
        if (currentOxygen > 0)
        {
            // Diminui o oxigênio com base na taxa de diminuição
            currentOxygen -= oxygenDecreaseRate * Time.deltaTime;
            UpdateOxygenUI(); // Atualiza a UI do oxigênio
        }
        else
        {
            // O oxigênio acabou, faça algo aqui (por exemplo, exiba uma mensagem)
        }
    }

    // Define a quantidade máxima de oxigênio
    public void SetMaxOxygen(float oxygen)
    {
        maxOxygen = oxygen;
        currentOxygen = maxOxygen; // Atualiza a quantidade atual para o máximo
        UpdateOxygenUI(); // Atualiza a UI do oxigênio
    }

    // Define a quantidade atual de oxigênio
    public void SetOxygen(float oxygen)
    {
        currentOxygen = Mathf.Clamp(oxygen, 0f, maxOxygen); // Garante que o valor esteja dentro dos limites
        UpdateOxygenUI(); // Atualiza a UI do oxigênio
    }

    // Atualiza a UI do oxigênio (pode ser um slider, imagem de preenchimento, etc.)
    void UpdateOxygenUI()
    {
        oxygenSlider.value = currentOxygen; // Atualiza o valor do slider
    }
}
