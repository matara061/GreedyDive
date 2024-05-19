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
            animator.SetBool("Moving", false);
            animator.SetBool("MovingDiagonally", false);
            animator.SetBool("Attacking", false);
            animator.SetBool("Dead", true);
            diveManager.Perdeu();
        }


        if(segundos != 0 && !isCoroutineRunning)
        {
            StartCoroutine(ReativarColliderAposDelay(segundos));
        }
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            // Verifica se o joystick está sendo movido
            if (movimentJoystick.joystickVec != Vector2.zero)
            {
                // Move o jogador de acordo com a direção do joystick e a velocidade do jogador
                rb.velocity = movimentJoystick.joystickVec * playerSpeed;

                // Define os parâmetros da animação com base na direção do joystick
                SetAnimationParameters(movimentJoystick.joystickVec);
            }
            else
            {
                // Se o joystick não estiver sendo movido, pare o jogador
                rb.velocity = Vector2.zero;

                // Define a animação para o jogador parado
                animator.SetBool("Moving", false);
                animator.SetBool("MovingDiagonally", false);
                animator.SetBool("Idle", true);
            }
        }
    }

    private void SetAnimationParameters(Vector2 direction)
    {
        // Define a animação para o jogador se movendo
        animator.SetBool("Idle", false);
        animator.SetBool("Moving", true);

        // Adiciona um limiar para o movimento diagonal
        float diagonalThreshold = 0.5f;

        if (!trigger.Attack)
        {
            // Verifica a direção do joystick
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y) + diagonalThreshold)
            {
                // Direção para a direita ou esquerda
                animator.SetBool("MovingDiagonally", false);
                animator.SetFloat("MoveX", Mathf.Sign(direction.x));
                animator.SetFloat("MoveY", 0f);

                spriteRenderer.flipX = direction.x < 0;
            }
            else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x) + diagonalThreshold)
            {
                // Direção para cima ou para baixo
                animator.SetBool("MovingDiagonally", false);
                animator.SetFloat("MoveX", 0f);
                animator.SetFloat("MoveY", Mathf.Sign(direction.y));
            }
            else
            {
                // Movimento diagonal
                animator.SetBool("MovingDiagonally", true);
                animator.SetFloat("MoveX", direction.x);
                animator.SetFloat("MoveY", direction.y);

                spriteRenderer.flipX = direction.x < 0;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag("EdgeOfPlayableArea"))
            {
                isAlive = false;
                Debug.Log("You Lose");
                diveManager.Perdeu();
            }

          /*  if (other.gameObject.layer == LayerMask.NameToLayer("Cura"))
            {
                Cura();

            }*/
        
        
    }

    public void Cura()
    {
        CurrentHealth += Mathf.RoundToInt(MaxHealth * CuraNum);// Adiciona 10% ou 20% do MaxHealth ao CurrentHealth
        playerHealthBar.SetHealth(CurrentHealth);

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth; // Garante que CurrentHealth não exceda MaxHealth
            playerHealthBar.SetHealth(CurrentHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvencivel == false)
        {
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

        // Reativa o Box Collider 2D após o atraso
        
        isInvencivel = false;
        boxCollider.enabled = true;
        segundos = 0;
        isCoroutineRunning = false;
    }
}
