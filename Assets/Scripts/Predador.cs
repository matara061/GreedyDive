using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Predador : MonoBehaviour
{
    [SerializeField]
    private int _maxHp;
    [SerializeField] 
    private float _inicialSpeed;
    [SerializeField]
    private float _speed;
  
    public int Damage;
    public int _moedas;
    public int _diamantes;

    public float tiltSpeed = 2f; // Velocidade de inclinação

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    //private PredadorValues _values;

    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;
    private Player player;
    private Vector2 _targetDirection;

    //public Animator anim;
    //public SpriteRenderer spriteRenderer;

    public BoxCollider2D Collider;
    private DivingSceneManager diveManager;
    GameManager gameManager;

    public int CurrentHP;
    private int segundos = 0;
    private bool isCoroutineRunning = false;
    public int bonusAmuleto5;
    public int bonusAmuleto9;

    public GameObject floatingGold;
    public GameObject floatingDiamond;

    // Adicionado para movimento aleatório
    private Vector2 swimDirection;

    private void Awake()
    {
       // _values = gameObject.GetComponent<PredadorValues>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
    }

    private void Start()
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

        player = FindAnyObjectByType<Player>();
        diveManager = FindAnyObjectByType<DivingSceneManager>();
       // CurrentHP = _values.HP;
       // Damage = _values.Damage;   
        _speed = _inicialSpeed;
        CurrentHP = _maxHp;

        // Inicializa a direção de natação aleatoriamente
        swimDirection = Random.insideUnitCircle.normalized;
    }

    private void Update()
    {

        AccelerometerMove();

        if (segundos != 0 && !isCoroutineRunning)
        {
            StartCoroutine(ReativarColliderAposDelay(segundos));
        }

        if (CurrentHP <= 0)
        {
            Death();
        }

        // Altera aleatoriamente a direção de natação a cada 2 segundos
        if (Time.time % 2f < 0.1f)
        {
            swimDirection = Random.insideUnitCircle.normalized;
        }
    }

    private void FixedUpdate()
    {
        if (CurrentHP > 0)
        {
            UpdateTargetDirection();
            RotateTowardsTarget();
            SetVelocity();
        }
    }

    private void UpdateTargetDirection()
    {
        if(_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            // Se o jogador não está no alcance, use a direção de natação aleatória
            _targetDirection = swimDirection;
        }
    }

    private void RotateTowardsTarget()
    {
        if(_targetDirection == Vector2.zero)
        {
            return;
        }

        float targetAngle = Mathf.Atan2(_targetDirection.y, _targetDirection.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rigidbody.velocity = Vector2.zero;
        }
        else
        {
            _rigidbody.velocity = transform.right * _speed;
        }

        Vector2 predadorToPlayer = player.transform.position - transform.position;

        if(predadorToPlayer.magnitude < _playerAwarenessController._playerMaxDistance)
        {
            _speed = 0;
        }
        else
        {
            _speed = _inicialSpeed;
        }

       /* if (Vector2.Distance(transform.position, player.transform.position) <= 1)
        {
            _speed = 0;
        }
        else
        {
            _speed = _inicialSpeed;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(Damage);
        }

        if (other.gameObject.CompareTag("PlayerAttackHitbox"))
        {
            Debug.Log("predador recebe: " + player.playerDam + " de dano");
            StartCoroutine(WaitPlayerAnimation());
            //TakeDamage(player.playerDam);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Limit"))
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        Imunidade(3);
    }

    void Imunidade(int time)
    {
        Collider.enabled = false;
        segundos = time;
    }

    void Death()
    {
        Recompensa();
        Destroy(gameObject);
    }

   /* void Recompensa()
    {
        if(_values != null)
        {
            _values.Diamante *= bonusAmuleto5;
            _values.Moeda *= bonusAmuleto9;

            diveManager.Money += _values.Moeda;
            diveManager.Diamantes += _values.Diamante;
        }
    }*/

    void Recompensa()
    {
        _moedas *= bonusAmuleto9;
        _diamantes *= bonusAmuleto5;

        diveManager.Money += _moedas;
        diveManager.Diamantes += _diamantes;

        if (_moedas > 0)
        {
            GameObject Gold = Instantiate(floatingGold, transform.position, Quaternion.identity);
            Gold.transform.GetChild(0).GetComponent<TextMeshPro>().text = _moedas.ToString();
        }
        else
                if (_diamantes > 0)
        {
            GameObject Diamond = Instantiate(floatingDiamond, transform.position, Quaternion.identity);
            Diamond.transform.GetChild(0).GetComponent<TextMeshPro>().text = _diamantes.ToString();
        }
    }

    IEnumerator ReativarColliderAposDelay(int delay)
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(delay);

        // Reativa o Box Collider 2D após o atraso
        Collider.enabled = true;
        segundos = 0;
        isCoroutineRunning = false;
    }

    IEnumerator WaitPlayerAnimation()
    {
        yield return new WaitForSeconds(3);
        TakeDamage(player.playerDam);
    }

    public void DamagePlayer()
    {
        player.TakeDamage(Damage);
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

        // Move o peixe na direção da inclinação
        transform.Translate(tilt * Time.deltaTime, Space.World);
    }
}