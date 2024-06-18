using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corda : MonoBehaviour
{

    public Transform corda;

    public Animator animator;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CordaDown()
    {
        //corda.transform.position = player.transform.position;
        animator.Play("Corda_desce");
    }
}
