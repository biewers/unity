using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody2D rb;
    public float movementSpeed;
    public float jumpAbility;
    
    private bool isGrounded;
	
	void FixedUpdate () {
        if (isGrounded && Input.GetAxis("Vertical") != 0)
            rb.velocity = new Vector2(0, jumpAbility * Time.deltaTime);

        transform.Translate(
            Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed, 0.0f,
            0.0f
        );
    }
    
    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.name == "Ground")
        {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.name == "Ground")
        {
            isGrounded = false;
        }
    }
}
