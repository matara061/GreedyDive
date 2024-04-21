using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTrigger : MonoBehaviour
{
    
    public Animator anim;
    public Transform playerTransform;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Predador"))
        {
            Debug.Log("predador");
            anim.SetBool("IsAttack", true);

            // Calcula a direção para o inimigo
            Vector2 InimigoDirection = col.transform.position - playerTransform.position;

            // Define os parâmetros de animação com base na direção
            if (Mathf.Abs(InimigoDirection.x) > Mathf.Abs(InimigoDirection.y))
            {
                // Movimento horizontal
                anim.SetFloat("MoveX", Mathf.Sign(InimigoDirection.x));
                anim.SetFloat("MoveY", 0f);
            }
            else
            {
                // Movimento vertical
                anim.SetFloat("MoveX", 0f);
                anim.SetFloat("MoveY", Mathf.Sign(InimigoDirection.y));
            }
        }
    }
}
