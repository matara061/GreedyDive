using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public bool InAttackRange { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;
    [SerializeField]
    private float _playerAttackDistance;

    public float _playerMaxDistance;

    private Transform _player;

    private void Awake()
    {
        _player = FindAnyObjectByType<Player>().transform;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 predadorToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = predadorToPlayerVector.normalized;

        if (predadorToPlayerVector.magnitude <= _playerAwarenessDistance && predadorToPlayerVector.magnitude > _playerAttackDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }

        if (predadorToPlayerVector.magnitude <= _playerAttackDistance)
        {
            InAttackRange = true;
        }
        else
        {
            InAttackRange = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _playerAwarenessDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _playerAttackDistance);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _playerMaxDistance);
    }
}
