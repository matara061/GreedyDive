using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BoatPlayerMovement : MonoBehaviour
{
    public Transform pointA, pointB, pointC;
    public SpriteRenderer sprite;
    public GameObject diveButton;
    public GameObject loja1Button;
    public GameObject loja2Button;
    public float speed;
    private Transform nextPoint;

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

        if (transform.position == pointB.position)
        {
            loja1Button.SetActive(true);
        }
        else
            loja1Button.SetActive(false);

        if (transform.position == pointC.position)
        {
            loja2Button.SetActive(true);
        }
        else
            loja2Button.SetActive(false);
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
}
