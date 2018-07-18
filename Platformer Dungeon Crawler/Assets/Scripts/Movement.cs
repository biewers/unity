using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody2D rb;
    public float movementSpeed;
    public float jumpAbility;
    
	void Start () {
	    	
	}
	
	void FixedUpdate () {
		if(Input.GetKey("d"))
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }
        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }
        if ((Input.GetKey("w") || Input.GetKey(KeyCode.Space)) && rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(0, jumpAbility));
        }
    }
}
