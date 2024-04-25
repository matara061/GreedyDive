using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatPlayerMovement : MonoBehaviour
{
    public Transform pointA, pointB, pointC;
    public SpriteRenderer sprite;
    public GameObject diveButton;
    public float speed;
    private Transform nextPoint;

    [SerializeField]
    private Slider barraProgresso;

    void Start()
    {
        transform.position = pointA.position;
        nextPoint = pointA;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != nextPoint.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, nextPoint.position, speed * Time.deltaTime);
        }

        if(transform.position == pointA.position)
        {
            diveButton.SetActive(true);
        }else
            diveButton.SetActive(false);
    }

    public void Loja1()
    {
        Debug.Log("loja");
    }

    public void Dive()
    {
        StartCoroutine(CarregarCena());
    }

    public void Direita()
    {
        if (nextPoint == pointA)
        {
            sprite.flipX = false;
            nextPoint = pointB;
        }
        else if (nextPoint == pointB)
        {
            sprite.flipX = false;
            nextPoint = pointC;
        }
    }

    public void Esquerda()
    {
        if (nextPoint == pointC)
        {
            sprite.flipX = true;
            nextPoint = pointB;
        }
        else if (nextPoint == pointB)
        {
            sprite.flipX = true;
            nextPoint = pointA;
        }
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
}
