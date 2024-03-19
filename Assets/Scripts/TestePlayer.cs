using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestePlayer : MonoBehaviour
{
    public MovimentJoystick movimentJoystick;
    public GameManager gameManager;
    public PlayerHealthBar playerHealthBar;

    public float playerSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    public bool isAlive;
    public SpriteRenderer spriteRenderer;

    
    public int CurrentHealth;
    void Start()
    {
        CurrentHealth = gameManager.PlayerMaxHealth;
        playerHealthBar.SetMaxHealth(CurrentHealth);

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isAlive = true;
    }

    private void FixedUpdate()
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
            animator.SetBool("IsMoving", false);
        }
    }

    private void SetAnimationParameters(Vector2 direction)
    {
        // Define a anima��o para o jogador se movendo
        animator.SetBool("IsMoving", true);

        // Calcula o �ngulo da dire��o do joystick em rela��o ao eixo x
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Define o par�metro da anima��o para a dire��o do jogador com base no �ngulo
        if (angle > -45 && angle <= 45)
        {
            // Dire��o para a direita
            animator.SetFloat("MoveX", 1f);
            animator.SetFloat("MoveY", 0f);

            spriteRenderer.flipX = false;
        }
        else if (angle > 45 && angle <= 135)
        {
            // Dire��o para cima
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveY", 1f);
        }
        else if (angle > 135 || angle <= -135)
        {
            // Dire��o para a esquerda
            animator.SetFloat("MoveX", -1f);
            animator.SetFloat("MoveY", 0f);

            spriteRenderer.flipX = true;
        }
        else if (angle > -135 && angle <= -45)
        {
            // Dire��o para baixo
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveY", -1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EdgeOfPlayableArea"))
        {
            isAlive = false;
            Destroy(gameObject, .5f);
            Debug.Log("You Lose");
        }

        if(collision.gameObject.CompareTag("Barril"))
        {
            TakeDamage(5);
        }
    }

    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        playerHealthBar.SetHealth(CurrentHealth);
        Imunidade(3);
    }

    void Imunidade(int time)
    {

    }
}
