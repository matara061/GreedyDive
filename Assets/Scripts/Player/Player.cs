using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MovimentJoystick movimentJoystick;
    public GameManager gameManager;
    public PlayerHealthBar playerHealthBar;
    public PlayerAttackTrigger trigger;

    public float playerSpeed;
    public int playerDam;
    private int segundos = 0;
    private Rigidbody2D rb;
    private Animator animator;
    public BoxCollider2D boxCollider;

    public bool isAlive;
    public bool isInvencivel = false;
    private bool isCoroutineRunning = false;
    private SpriteRenderer spriteRenderer;

    
    public int CurrentHealth;
    void Start()
    {
        playerHealthBar.SetMaxHealth(CurrentHealth);

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        isAlive = true;
    }

    private void Update()
    {
        if(CurrentHealth <= 0)
        {
            isAlive = false;
            animator.SetBool("IsDeath", true);
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
                animator.SetBool("IsMoving", false);
                animator.SetBool("IsDiag", false);
            }
        }
    }

    private void SetAnimationParameters(Vector2 direction)
    {
        // Define a animação para o jogador se movendo
        animator.SetBool("IsMoving", true);

        // Adiciona um limiar para o movimento diagonal
        float diagonalThreshold = 0.5f;

        if (!trigger.Attack)
        {
            // Verifica a direção do joystick
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y) + diagonalThreshold)
            {
                // Direção para a direita ou esquerda
                animator.SetBool("IsDiag", false);
                animator.SetFloat("MoveX", Mathf.Sign(direction.x));
                animator.SetFloat("MoveY", 0f);

                spriteRenderer.flipX = direction.x < 0;
            }
            else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x) + diagonalThreshold)
            {
                // Direção para cima ou para baixo
                animator.SetBool("IsDiag", false);
                animator.SetFloat("MoveX", 0f);
                animator.SetFloat("MoveY", Mathf.Sign(direction.y));
            }
            else
            {
                // Movimento diagonal
                animator.SetBool("IsDiag", true);
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

    public void ContinuosDamage(int damage)
    {
        CurrentHealth -= damage;
        playerHealthBar.SetHealth(CurrentHealth);
    }

    public void Imunidade(int time)
    {
        boxCollider.enabled = false;
        segundos = time;
        Debug.Log("I'm fucking invincible!");
        
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
