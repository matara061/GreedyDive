using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MovimentJoystick movimentJoystick;
    public GameManager gameManager;
    private DivingSceneManager diveManager;
    public PlayerHealthBar playerHealthBar;
    public PlayerAttackTrigger trigger;

    public float playerSpeed;
    public float UpSpeed = 2f;
    public int playerDam;
    private int segundos = 0;
    public int bonusAmuleto3 = 0;
    public float bonusAmuleto4 = 0f;
    private Rigidbody2D rb;
    private Animator animator;
    public BoxCollider2D boxCollider;

    public bool isAlive;
    public bool isInvencivel = false;
    private bool isCoroutineRunning = false;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public int MaxHealth;
    public float CurrentHealth;
    public float CuraNum = 0.1f;

    //public GameObject topHitbox, topSideHitbox, middleHitbox, bottomHitbox, bottomSideHitbox;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        diveManager = FindAnyObjectByType<DivingSceneManager>();
        CurrentHealth = MaxHealth;
        playerHealthBar.SetMaxHealth(MaxHealth);

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        isAlive = true;
    }

    private void Update()
    {
        //transform.position += Time.deltaTime * UpSpeed * Vector3.up;

        if (CurrentHealth <= 0 && isAlive)
        {
            isAlive = false;
            animator.SetBool("Die", true);
            //diveManager.Perdeu();
            StartCoroutine(WaitForDeathAnimation());
        }


        if(segundos != 0 && !isCoroutineRunning)
        {
            StartCoroutine(ReativarColliderAposDelay(segundos));
        }

        if(diveManager._isUp)
        {
            animator.SetBool("IsUp", true);
        }
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            // Verifica se o joystick est� sendo movido
            if (movimentJoystick.joystickVec != Vector2.zero)
            {
                // Move o jogador de acordo com a dire��o do joystick e a velocidade do jogador
                rb.velocity = movimentJoystick.joystickVec * playerSpeed;

                // Define os par�metros da anima��o com base na dire��o do joystick
                SetAnimationParameters(movimentJoystick.joystickVec);
            }
            else
            {
                // Se o joystick n�o estiver sendo movido, pare o jogador
                rb.velocity = Vector2.zero;

                // Define a anima��o para o jogador parado
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", 0);
                animator.SetBool("Moving", false);
            }
        }
    }

    private void SetAnimationParameters(Vector2 direction)
    {
        // Define a anima��o para o jogador se movendo
       // animator.SetBool("Idle", false);
        //animator.SetBool("Moving", true);

        // Adiciona um limiar para o movimento diagonal
        float diagonalThreshold = 0.5f;

        if (!trigger.Attack && direction.x != 0 && direction.y != 0)
        {
            animator.SetBool("Moving", true);

            // Verifica a dire��o do joystick
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y) + diagonalThreshold)
            {
                // Dire��o para a direita ou esquerda
                animator.SetFloat("MoveX", Mathf.Sign(direction.x));
                animator.SetFloat("MoveY", 0f);

               // spriteRenderer.flipX = direction.x < 0;
            }
            else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x) + diagonalThreshold)
            {
                // Dire��o para cima ou para baixo
                animator.SetFloat("MoveX", 0f);
                animator.SetFloat("MoveY", Mathf.Sign(direction.y));
            }
            else
            {
                // Movimento diagonal
                animator.SetFloat("MoveX", direction.x);
                animator.SetFloat("MoveY", direction.y);
            }
        }else
            animator.SetBool("Moving", false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag("EdgeOfPlayableArea"))
            {
                isAlive = false;
                Debug.Log("You Lose");
                diveManager.Perdeu();
            }
        
        
    }

    public void Cura()
    {
        CurrentHealth += Mathf.RoundToInt(MaxHealth * CuraNum);// Adiciona 10% ou 20% do MaxHealth ao CurrentHealth
        playerHealthBar.SetHealth(CurrentHealth);

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth; // Garante que CurrentHealth n�o exceda MaxHealth
            playerHealthBar.SetHealth(CurrentHealth);
        }
    }

    public void Revive()
    {
        CurrentHealth = MaxHealth;
        playerHealthBar.SetHealth(CurrentHealth);
        isAlive = true;
        animator.SetBool("Die", false);
        Imunidade(7);
    }

    public void TakeDamage(int damage)
    {
        if (isInvencivel == false)
        {
            animator.SetTrigger("Hit");
            CurrentHealth -= damage;
            playerHealthBar.SetHealth(CurrentHealth);
            Imunidade(3);
        }
    }

    public void ContinuosDamage(float damage)
    {
        damage -= bonusAmuleto4;// amuleto4
        CurrentHealth -= damage;
        playerHealthBar.SetHealth(CurrentHealth);
    }

    public void Imunidade(int time)
    {
        boxCollider.enabled = false;
        segundos = time + bonusAmuleto3;
        
        isInvencivel = true;
    }

    IEnumerator ReativarColliderAposDelay(int delay)
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(delay);

        // Reativa o Box Collider 2D ap�s o atraso
        
        isInvencivel = false;
        boxCollider.enabled = true;
        segundos = 0;
        isCoroutineRunning = false;
    }

    private IEnumerator WaitForDeathAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        diveManager.Perdeu();
    }
}
