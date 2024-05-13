using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTrigger : MonoBehaviour
{
    public Animator anim;
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
            anim.SetBool("Attacking", true);
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
            anim.SetBool("Attacking", false);
        }
    }


    private void SetAnimationParameters(Vector2 direction)
    {
        // Adiciona um limiar para o movimento diagonal
        float diagonalThreshold = 0.5f;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y) + diagonalThreshold)
        {
            // Direção para a direita ou esquerda
            anim.SetBool("MovingDiagonally", false);
            anim.SetFloat("MoveX", Mathf.Sign(direction.x));
            anim.SetFloat("MoveY", 0f);

            spriteRenderer.flipX = direction.x < 0;
        }
        else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x) + diagonalThreshold)
        {
            // Direção para cima ou para baixo
            anim.SetBool("MovingDiagonally", false);
            anim.SetFloat("MoveX", 0f);
            anim.SetFloat("MoveY", Mathf.Sign(direction.y));
        }
        else
        {
            // Movimento diagonal
            anim.SetBool("MovingDiagonally", true);
            anim.SetFloat("MoveX", direction.x);
            anim.SetFloat("MoveY", direction.y);

            spriteRenderer.flipX = direction.x < 0;
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
