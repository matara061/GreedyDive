using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestePlayer : MonoBehaviour
{
    public MovimentJoystick movimentJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    public bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
    }

    private void FixedUpdate()
    {
        if(movimentJoystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(movimentJoystick.joystickVec.x * playerSpeed, movimentJoystick.joystickVec.y * playerSpeed);
        }
        else
            rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EdgeOfPlayableArea"))
        {
            isAlive = false;
            Destroy(gameObject, .5f);
            Debug.Log("You Lose");
        }
    }

}
