using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTrigger : MonoBehaviour
{
    public Animator anim;
    public Transform playerTransform;
    public SpriteRenderer spriteRenderer;

    public bool Attack = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        CheckPredator(col);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        CheckPredator(col);
    }

    private void CheckPredator(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Predador"))
        {
            //Debug.Log("predador");
            anim.SetBool("IsAttack", true);
            Attack = true;

            // Calcula a direção para o inimigo
            Vector2 InimigoDirection = col.transform.position - playerTransform.position;

            SetAnimationParameters(InimigoDirection);
        }
        else
        {
            Attack = false;
        }
    }

    private void SetAnimationParameters(Vector2 direction)
    {
        // Adiciona um limiar para o movimento diagonal
        float diagonalThreshold = 0.5f;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y) + diagonalThreshold)
        {
            // Direção para a direita ou esquerda
            anim.SetBool("IsDiag", false);
            anim.SetFloat("MoveX", Mathf.Sign(direction.x));
            anim.SetFloat("MoveY", 0f);

            spriteRenderer.flipX = direction.x < 0;
        }
        else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x) + diagonalThreshold)
        {
            // Direção para cima ou para baixo
            anim.SetBool("IsDiag", false);
            anim.SetFloat("MoveX", 0f);
            anim.SetFloat("MoveY", Mathf.Sign(direction.y));
        }
        else
        {
            // Movimento diagonal
            anim.SetBool("IsDiag", true);
            anim.SetFloat("MoveX", direction.x);
            anim.SetFloat("MoveY", direction.y);

            spriteRenderer.flipX = direction.x < 0;
        }
    }
}
