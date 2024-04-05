using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTrigger : MonoBehaviour
{
    
    public Animator anim;

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("circle");
        if (col.gameObject.layer == LayerMask.NameToLayer("Predador"))
        {
            Debug.Log("predador");
            anim.SetBool("IsAttack", true);
        }
    }
}
