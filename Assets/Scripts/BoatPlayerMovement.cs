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
    public GameObject loja1Fala;
    public GameObject loja2Fala;
    public GameObject MoveBotoes;
    public float speed;
    private Transform nextPoint;

    public Animator anim;

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

        if(transform.position != pointA.position && transform.position != pointB.position && transform.position != pointC.position)
        {
            MoveBotoes.SetActive(false);
        }else
            MoveBotoes.SetActive(true);


        if (transform.position == pointA.position)
        {
            diveButton.SetActive(true);
        }else
            diveButton.SetActive(false);

        if (transform.position == pointB.position)
        {
            loja1Button.SetActive(true);
            loja1Fala.SetActive(true);
        }
        else
        {
            loja1Button.SetActive(false);
            loja1Fala.SetActive(false);
        }
           

        if (transform.position == pointC.position)
        {
            loja2Button.SetActive(true);
            loja2Fala.SetActive(true);
        }
        else
        {
            loja2Button.SetActive(false);
            loja2Fala.SetActive(false);
        }
    }

    public void Direita()
    {
        if (nextPoint == pointA)
        {
            sprite.flipX = true;
            anim.Play("Player_Boat_Walk");
            nextPoint = pointB;
        }
        else if (nextPoint == pointB)
        {
            sprite.flipX = true;
            anim.Play("Player_Boat_Walk");
            nextPoint = pointC;
        }
    }

    public void Esquerda()
    {
        if (nextPoint == pointC)
        {
            sprite.flipX = false;
            anim.Play("Player_Boat_Walk");
            nextPoint = pointB;
        }
        else if (nextPoint == pointB)
        {
            sprite.flipX = false;
            anim.Play("Player_Boat_Walk");
            nextPoint = pointA;
        }
    }
}
