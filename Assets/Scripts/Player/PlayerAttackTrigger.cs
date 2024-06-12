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

        if (col.gameObject.layer == LayerMask.NameToLayer("Predador"))
        {
            Attack = true;
            //Debug.Log("predador");
            anim.SetBool("IsAttack", true);

            // Calcula a dire��o para o inimigo
            Vector2 direction = col.transform.position - playerTransform.position;

            // Normaliza a dire��o para obter um vetor de comprimento 1
            direction.Normalize();

            // Define os par�metros de anima��o com base na dire��o
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                // Movimento horizontal
                anim.SetFloat("MoveX", Mathf.Sign(direction.x));
                anim.SetFloat("MoveY", 0f);
            }
            else
            {
                // Movimento vertical
                anim.SetFloat("MoveX", 0f);
                anim.SetFloat("MoveY", Mathf.Sign(direction.y));
            }
        }
        else
            Attack = false;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        //Attack = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Predador"))
        {
            Attack = false;
            anim.SetBool("IsAttack", false);
        }
    }
}
