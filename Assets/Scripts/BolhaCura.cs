using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BolhaCura : MonoBehaviour
{

    private Player player;

    public float tiltSpeed = 2f; // Velocidade de inclinação

    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    private void Update()
    {
        // Rotaciona o objeto em torno do eixo Y (vertical)
        transform.Rotate(Vector3.forward * 50f * Time.deltaTime);

        AccelerometerMove();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.Cura();
            Destroy(gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Limit"))
        {
            Destroy(gameObject);
        }
    }

    void AccelerometerMove()
    {
        // Obtém a inclinação do dispositivo
        Vector3 tilt = Input.acceleration;

        // Ignora a componente y (para cima e para baixo) e z
        tilt.y = 0;
        tilt.z = 0;

        // Se a inclinação for menor que um certo limite, não move o peixe
        if (tilt.magnitude < 0.2f)
        {
            return;
        }

        // Normaliza a inclinação para obter uma direção
        tilt.Normalize();

        // Multiplica a inclinação pela velocidade de inclinação para obter a quantidade de movimento
        tilt *= tiltSpeed;

        // Limita a quantidade de movimento
        // tilt = Vector3.ClampMagnitude(tilt, 1);

        // Move o peixe na direção da inclinação
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
}
