using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishSwimming : MonoBehaviour
{
    public float swimSpeed = 2f; // Velocidade de nata��o
    public int _moeda;
    public int _diamante;
    public float rotationSpeed = 5f; // Velocidade de rota��o
    public float tiltSpeed = 2f; // Velocidade de inclina��o
    public int bonusAmuleto5;
    public int bonusAmuleto9;

    private GameManager gameManager;
    public GameObject floatingGold;
    public GameObject floatingDiamond;
    public Animator animator;
   // public FishValue fishValue;
    private DivingSceneManager divingSceneManager;

    private Vector2 swimDirection; // Dire��o de nata��o atual

    void Start()
    {
        bonusAmuleto5 = 1;
        bonusAmuleto9 = 1;

        gameManager = FindAnyObjectByType<GameManager>();

        if (gameManager != null)
        {
            if (gameManager.AmuletoAtivo[5])
            {
                bonusAmuleto5 = 2;
            }

            if (gameManager.AmuletoAtivo[9])
            {
                bonusAmuleto9 = 2;
            }
        }

       // swimSpeed = fishValue.speed;
        divingSceneManager = FindAnyObjectByType<DivingSceneManager>();
        // Inicializa a dire��o de nata��o aleatoriamente
        swimDirection = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        // Move o peixe na dire��o de nata��o
        transform.Translate(swimDirection * swimSpeed * Time.deltaTime);

        AccelerometerMove();

        // Altera aleatoriamente a dire��o de nata��o a cada 2 segundos
        if (Time.time % 2f < 0.1f)
        {
            swimDirection = Random.insideUnitCircle.normalized;
            FlipFish();
        }
    }

    void FlipFish()
    {
        if (swimDirection.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (swimDirection.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Die");
            StartCoroutine(WaitPlayerAnimation());
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Limit"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator WaitPlayerAnimation()
    {
        yield return new WaitForSeconds(1);
        Recompensa();
        Destroy(gameObject);
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
    }

    void Recompensa()
    {
        _diamante *= bonusAmuleto5;
        _moeda *= bonusAmuleto9;

        divingSceneManager.Money += _moeda;
        divingSceneManager.Diamantes += _diamante;

        if (_moeda > 0)
        {
            GameObject Gold = Instantiate(floatingGold, transform.position, Quaternion.identity);
            Gold.transform.GetChild(0).GetComponent<TextMeshPro>().text = _moeda.ToString();
        }
        else
                if (_diamante > 0)
        {
            GameObject Diamond = Instantiate(floatingDiamond, transform.position, Quaternion.identity);
            Diamond.transform.GetChild(0).GetComponent<TextMeshPro>().text = _diamante.ToString();
        }
    }

}
