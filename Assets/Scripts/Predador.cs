using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predador : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private PredadorValues _values;

    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;
    private Player player;
    private Vector2 _targetDirection;

    public Animator anim;
    public SpriteRenderer spriteRenderer;

    public BoxCollider2D Collider;
    private DivingSceneManager diveManager;
    GameManager gameManager;

    public int CurrentHP;
    public int Damage;
    private int segundos = 0;
    private bool isCoroutineRunning = false;
    public int bonusAmuleto5;
    public int bonusAmuleto9;

    // Adicionado para movimento aleatório
    private Vector2 swimDirection;

    private void Awake()
    {
        _values = gameObject.GetComponent<PredadorValues>();
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
        CurrentHP = _values.HP;
        Damage = _values.Damage;   
        _speed = _values.Speed;

        // Inicializa a direção de natação aleatoriamente
        swimDirection = Random.insideUnitCircle.normalized;
    }

    private void Update()
    {
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

        if (Vector2.Distance(transform.position, player.transform.position) <= 1)
        {
            _speed = 0;
        }
        else
        {
            _speed = _values.Speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //player.TakeDamage(Damage);
        }

        if (other.gameObject.CompareTag("PlayerAttackHitbox"))
        {
            TakeDamage(player.playerDam);
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
        Imunidade(2);
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

    void Recompensa()
    {
        if(_values != null)
        {
            _values.Diamante *= bonusAmuleto5;
            _values.Moeda *= bonusAmuleto9;

            diveManager.Money += _values.Moeda;
            diveManager.Diamantes += _values.Diamante;
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

    public void DamagePlayer()
    {
        player.TakeDamage(Damage);
    }
}