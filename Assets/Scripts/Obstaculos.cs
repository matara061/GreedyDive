using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    private Player player;
    public int dano;

    public float velocidadeRotacao = 50f;
    public float speed;
    public float tiltSpeed = 2f; // Velocidade de inclina��o
    public Rigidbody2D rb;

    [SerializeField] private Animator anim;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    void Update()
    {
        // Rotaciona o objeto em torno do eixo Y (vertical)
        transform.Rotate(Vector3.forward * velocidadeRotacao * Time.deltaTime);

        AccelerometerMove();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject.CompareTag("Player"))
        {
            ObstaculoDano();
            if(anim != null)
            {
                anim.SetTrigger("Hit");
                StartCoroutine(WaitForAnimation());
            }
            else
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
        // Obt�m a inclina��o do dispositivo
        Vector3 tilt = Input.acceleration;

        // Ignora a componente y (para cima e para baixo) e z
        tilt.y = 0;
        tilt.z = 0;

        // Se a inclina��o for menor que um certo limite, n�o move o peixe
        if (tilt.magnitude < 0.2f)
        {
            return;
        }

        // Normaliza a inclina��o para obter uma dire��o
        tilt.Normalize();

        // Multiplica a inclina��o pela velocidade de inclina��o para obter a quantidade de movimento
        tilt *= tiltSpeed;

        // Limita a quantidade de movimento
       // tilt = Vector3.ClampMagnitude(tilt, 1);

        // Move o peixe na dire��o da inclina��o
        transform.Translate(tilt * Time.deltaTime, Space.World);

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

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
