using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTrigger : MonoBehaviour
{
    public Animator animator;
    public Transform playerTransform;
    public SpriteRenderer spriteRenderer;
    public GameObject topHitbox, topSideHitbox, middleHitbox, bottomHitbox, bottomSideHitbox;

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
            animator.SetLayerWeight(1, 0f);
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

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Predador"))
        {
            Attack = false;
            animator.SetBool("Attacking", false);
        }
    }


    private void SetAnimationParameters(Vector2 direction)
    {
        // Adiciona um limiar para o movimento diagonal
        //float diagonalThreshold = 0.5f;

        // Verifica a direção do joystick
        if (direction.x > 0 && direction.y < .5 && direction.y > -.5)
        {
            // Direita
            animator.SetFloat("MoveX", 1);
            animator.SetFloat("MoveY", 0);
        }
        else if (direction.x < 0 && direction.y < .5 && direction.y > -.5)
        {
            // Esquerda
            animator.SetFloat("MoveX", -1);
            animator.SetFloat("MoveY", 0);
        }
        else if (direction.y > 0 && direction.x < .5 && direction.x > -.5)
        {
            // Cima
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 1);
        }
        else if (direction.y < 0 && direction.x < .5 && direction.x > -.5)
        {
            // Baixo
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", -1);
        }
        else if (direction.x > 0 && direction.y > .5)
        {
            // Diagonal direita superior
            animator.SetFloat("MoveX", 1);
            animator.SetFloat("MoveY", 1);
        }
        else if (direction.x > 0 && direction.y < -.5)
        {
            // Diagonal direita inferior
            animator.SetFloat("MoveX", 1);
            animator.SetFloat("MoveY", -1);
        }
        else if (direction.x < 0 && direction.y > .5)
        {
            // Diagonal esquerda superior
            animator.SetFloat("MoveX", -1);
            animator.SetFloat("MoveY", 1);
        }
        else if (direction.x < .5 && direction.x > -.5 && direction.y < .5 && direction.y > -.5)
        {
            // Idle
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);
        }
    }

    //Top Hitbox
    public void TopHitboxOn()
    {
        topHitbox.SetActive(true);
    }
    public void TopHitboxOff()
    {
        topHitbox.SetActive(false);
    }

    //Bottom Hitbox
    public void BottomHitboxOn()
    {
        bottomHitbox.SetActive(true);
    }
    public void BottomHitboxOff()
    {
        bottomHitbox.SetActive(false);
    }

    //Top Side Hitbox
    public void TopSideHitboxOn()
    {
        topSideHitbox.SetActive(true);
    }
    public void TopSideHitboxOff()
    {
        topSideHitbox.SetActive(false);
    }

    //Middle Hitbox
    public void MiddleHitboxOn()
    {
        middleHitbox.SetActive(true);
    }
    public void MiddleHitboxOff()
    {
        middleHitbox.SetActive(false);
    }

    //Bottom Side Hitbox
    public void BottomSideHitboxOn()
    {
        bottomSideHitbox.SetActive(true);
    }
    public void BottomSideHitboxOff()
    {
        bottomSideHitbox.SetActive(false);
    }
}
