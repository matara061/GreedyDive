using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFXSource;

    public AudioClip barcoBG;
    public AudioClip mergulhoCenaBG;
    public AudioClip andar;
    public AudioClip botao;
    public AudioClip compra;
    public AudioClip vitoria;
    public AudioClip derrota;
    public AudioClip mergulhoEfect;
    public AudioClip mordidaPredador;
    public AudioClip hit;

    public bool IsPaused = false;

    public static AudioManager instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        IsPaused = false;
    }

    private void Update()
    {
        if (IsPaused)
        {
            musicSource.Pause();
        }else
            musicSource.UnPause();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        IsPaused = false;
        musicSource.clip = clip;
        musicSource.Play();
    }
}
