using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollision : MonoBehaviour {

    public Animator animator;
    private bool doorActive = false;
	
	void Update () {
		if(Input.GetKeyDown("e") && doorActive)
        {
            animator.SetTrigger("playerInteracted");
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Door")
        {
            animator = collision.collider.GetComponent<Animator>();
            doorActive = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Door")
        {
            doorActive = false;
        }
    }
}
