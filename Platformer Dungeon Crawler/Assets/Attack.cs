using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject player;
	
	void FixedUpdate () {
        Vector3 playerPos = player.GetComponent<Transform>().position;

        this.GetComponent<Rigidbody2D>().AddForce(playerPos - this.transform.position);
        
	}
}
