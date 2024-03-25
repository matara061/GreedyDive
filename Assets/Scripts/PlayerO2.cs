using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerO2 : MonoBehaviour
{
    public Slider oxygenSlider; // Refer�ncia ao slider de oxig�nio
    public float maxOxygen = 100f; // Quantidade m�xima de oxig�nio
    public float oxygenDecreaseRate = 0.5f; // Taxa de diminui��o de oxig�nio por segundo

    private float currentOxygen; // Quantidade atual de oxig�nio

    void Start()
    {
        SetMaxOxygen(maxOxygen); // Inicializa o oxig�nio no m�ximo
    }

    void Update()
    {
        if (currentOxygen > 0)
        {
            // Diminui o oxig�nio com base na taxa de diminui��o
            currentOxygen -= oxygenDecreaseRate * Time.deltaTime;
            UpdateOxygenUI(); // Atualiza a UI do oxig�nio
        }
        else
        {
            // O oxig�nio acabou, fa�a algo aqui (por exemplo, exiba uma mensagem)
        }
    }

    // Define a quantidade m�xima de oxig�nio
    public void SetMaxOxygen(float oxygen)
    {
        maxOxygen = oxygen;
        currentOxygen = maxOxygen; // Atualiza a quantidade atual para o m�ximo
        UpdateOxygenUI(); // Atualiza a UI do oxig�nio
    }

    // Define a quantidade atual de oxig�nio
    public void SetOxygen(float oxygen)
    {
        currentOxygen = Mathf.Clamp(oxygen, 0f, maxOxygen); // Garante que o valor esteja dentro dos limites
        UpdateOxygenUI(); // Atualiza a UI do oxig�nio
    }

    // Atualiza a UI do oxig�nio (pode ser um slider, imagem de preenchimento, etc.)
    void UpdateOxygenUI()
    {
        oxygenSlider.value = currentOxygen; // Atualiza o valor do slider
    }
}
