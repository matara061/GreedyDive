using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject playerAttackHitbox;
    public Animator anim;
    public Transform playerTransform;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
