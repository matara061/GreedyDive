using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    private bool floatup;

    public float velocidadeRotacao = 50f;

    void Start()
    {
        floatup = false;
    }

    void Update()
    {
        // Rotaciona o objeto em torno do eixo Y (vertical)
        transform.Rotate(Vector3.forward * velocidadeRotacao * Time.deltaTime);

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
}
