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

    public BoxCollider2D Collider;

    public int CurrentHP;
    public int Damage;
    private int segundos = 0;
    private bool isCoroutineRunning = false;

    private void Awake()
    {
        _values = gameObject.GetComponent<PredadorValues>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
    }

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        CurrentHP = _values.HP;
        Damage = _values.Damage;    
    }

    private void Update()
    {
        if (segundos != 0 && !isCoroutineRunning)
        {
            StartCoroutine(ReativarColliderAposDelay(segundos));
        }
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if(_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(Damage);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("AttackArea"))
        {
            TakeDamage(player.playerDam);
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

    IEnumerator ReativarColliderAposDelay(int delay)
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(delay);

        // Reativa o Box Collider 2D após o atraso
        Collider.enabled = true;
        segundos = 0;
        isCoroutineRunning = false;
    }
}