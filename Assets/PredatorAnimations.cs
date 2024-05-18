using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorAnimations : MonoBehaviour
{
    public Animator anim;
    private Player player;

    [SerializeField]
    private PredadorValues _values;

    public int Damage;

    private void Awake()
    {
        _values = GetComponentInParent<PredadorValues>();
    }

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Swimming", true);
        anim.SetBool("Attacking", false);

        player = FindAnyObjectByType<Player>();

        Damage = _values.Damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Swimming", false);
            anim.SetBool("Attacking", true);
        }

        if (other.gameObject.CompareTag("PlayerAttackHitbox"))
        {
            anim.SetTrigger("Hit");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Swimming", true);
            anim.SetBool("Attacking", false);
        }
    }

    public void DamagePlayer()
    {
        player.TakeDamage(Damage);
    }
}
