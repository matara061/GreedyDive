using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    private bool floatup;
    private Player player;
    public int dano;

    public float velocidadeRotacao = 50f;
    public float speed;
    public float tiltSpeed = 10f; // Velocidade de inclinação
    public Rigidbody2D rb;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        floatup = false;
    }

    void Update()
    {
        // Rotaciona o objeto em torno do eixo Y (vertical)
        transform.Rotate(Vector3.forward * velocidadeRotacao * Time.deltaTime);

        AccelerometerMove();

      /*  if (floatup)
        {
            StartCoroutine(floatingUp());
        }
        else
        {
            StartCoroutine(floatingDown());
        }*/
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
       /* if (gameObject.CompareTag("Barril"))
        {
            Destroy(gameObject);
        }*/

        if (collision.gameObject.CompareTag("Player"))
        {
            ObstaculoDano();
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Limit"))
        {
            Destroy(gameObject);
        }
    }

    void ObstaculoDano()
    {
        player.TakeDamage(dano);
    }

    void AccelerometerMove()
    {
        // Obtém a inclinação do dispositivo
        Vector3 tilt = Input.acceleration;

        // Ignora a componente y (para cima e para baixo)
        tilt.y = 0;

        // Se o dispositivo estiver inclinado, move o peixe na direção da inclinação
        if (tilt.magnitude > 1)
        {
            tilt.Normalize();
        }

        // Multiplica a inclinação pela velocidade de inclinação para obter a quantidade de movimento
        tilt *= tiltSpeed;

        // Move o peixe na direção da inclinação
        transform.Translate(tilt * Time.deltaTime);

        /*  float x = Input.acceleration.x;
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
          }*/
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
