using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    private bool floatup;

    public float velocidadeRotacao = 50f;
    public float speed;
    public Rigidbody2D rb;

    void Start()
    {
        floatup = false;
    }

    void Update()
    {
        // Rotaciona o objeto em torno do eixo Y (vertical)
        transform.Rotate(Vector3.forward * velocidadeRotacao * Time.deltaTime);

        AccelerometerMove();

        if (floatup)
        {
            StartCoroutine(floatingUp());
        }
        else
        {
            StartCoroutine(floatingDown());
        }
    }

    IEnumerator floatingUp()
    {
        transform.position += Vector3.up * 0.3f * Time.deltaTime;
        yield return new WaitForSeconds(1);
        floatup = false;
    }

    IEnumerator floatingDown()
    {
        transform.position -= Vector3.up * 0.3f * Time.deltaTime;
        yield return new WaitForSeconds(1);
        floatup = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica a layer do objeto colidido
        if (gameObject.CompareTag("Barril"))
        {
            Destroy(gameObject);
        }
    }

    void AccelerometerMove()
    {

        float x = Input.acceleration.x;
        //Debug.Log("X = " + x);

        if (x < -0.1f)
        {
            MoveLeft();
        }
        else if (x > 0.1f)
        {
            MoveRight();
        }
        else
        {
            SetVelocityZero();
        }
    }
    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-speed, 0);
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        transform.eulerAngles = new Vector2(0, 180);
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(speed, 0);
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        transform.eulerAngles = new Vector2(0, 0);
    }
}
