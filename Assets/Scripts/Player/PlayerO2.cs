using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerO2 : MonoBehaviour
{
    public Slider oxygenSlider; // Refer�ncia ao slider de oxig�nio
    public PlayerValues playerValues;
    public DivingSceneManager _diveManager;
    public float maxOxygen = 100f; // Quantidade m�xima de oxig�nio
    public float oxygenDecreaseRate = 0.5f; // Taxa de diminui��o de oxig�nio por segundo
    public float O2Percentage;

    public Image fill;

    [SerializeField] private GameObject botao;

    public Color NormarColor = Color.blue;
    public Color UpColor = Color.red;

    public float currentOxygen; // Quantidade atual de oxig�nio

    void Start()
    {
        //SetMaxOxygen(maxOxygen); // Inicializa o oxig�nio no m�ximo
        SetMaxOxygen(playerValues.O2);
    }

    void Update()
    {
        // Atualiza a cor da barra de O2 com base na porcentagem de O2
         O2Percentage = oxygenSlider.value / oxygenSlider.maxValue;
        
        if(O2Percentage <= 0.2f)
        {
            fill.color = UpColor;
            botao.SetActive(true);
        }else
        {
            fill.color = NormarColor;
        } 

        if (currentOxygen > 0)
        {
            // Diminui o oxig�nio com base na taxa de diminui��o
            currentOxygen -= oxygenDecreaseRate * Time.deltaTime;
            UpdateOxygenUI(); // Atualiza a UI do oxig�nio
        }
        else
        {
            // O oxig�nio acabou, fa�a algo aqui (por exemplo, exiba uma mensagem)
            _diveManager.Perdeu();
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

    public void Revive()
    {

        if(currentOxygen <= 0 || O2Percentage <= 0.2f)
        {
            currentOxygen = maxOxygen * 0.3f;
            UpdateOxygenUI();
        }
    }
}
