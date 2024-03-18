using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestePlayer : MonoBehaviour
{
    public MovimentJoystick movimentJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    public bool isAlive;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isAlive = true;
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
            }
        }
    }

    private void SetAnimationParameters(Vector2 direction)
    {
        // Define a animação para o jogador se movendo
        animator.SetBool("IsMoving", true);

        // Calcula o ângulo da direção do joystick em relação ao eixo x
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Define o parâmetro da animação para a direção do jogador com base no ângulo
        if (angle > -45 && angle <= 45)
        {
            // Direção para a direita
            animator.SetFloat("MoveX", 1f);
            animator.SetFloat("MoveY", 0f);

            spriteRenderer.flipX = false;
        }
        else if (angle > 45 && angle <= 135)
        {
            // Direção para cima
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveY", 1f);
        }
        else if (angle > 135 || angle <= -135)
        {
            // Direção para a esquerda
            animator.SetFloat("MoveX", -1f);
            animator.SetFloat("MoveY", 0f);

            spriteRenderer.flipX = true;
        }
        else if (angle > -135 && angle <= -45)
        {
            // Direção para baixo
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveY", -1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EdgeOfPlayableArea"))
        {
            isAlive = false;
            Debug.Log("You Lose");
        }
    }
}
