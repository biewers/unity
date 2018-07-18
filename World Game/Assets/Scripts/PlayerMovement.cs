using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rb;
    public float walkSpeed = 0.1f;

	void Start () {
        rb = this.GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {

		if(Input.GetKey("d"))
        {
            rb.AddForce(walkSpeed, 0, 0, ForceMode.VelocityChange);
        }
        if(Input.GetKey("a"))
        {
            rb.AddForce(-walkSpeed, 0, 0, ForceMode.VelocityChange);
        }

    }
}
