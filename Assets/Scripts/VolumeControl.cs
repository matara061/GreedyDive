using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    public AudioManager audioManager;

    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        // Define o valor inicial do controle deslizante para corresponder ao volume inicial
        volumeSlider.value = audioManager.musicSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        // Atualiza o volume para corresponder ao valor do controle deslizante
        audioManager.musicSource.volume = volumeSlider.value;
    }
}
