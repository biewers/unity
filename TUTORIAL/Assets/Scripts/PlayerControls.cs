using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour {

    public Rigidbody rb;
    public PlayerMovement movement;
    public Text pausedUI;

    bool paused = false;
    float ff, sf;
    Vector3 veloc;

	void Update () {
	    if(Input.GetKeyDown("p"))
        {
            if (!paused)
            {
                paused = true;
                pausedUI.enabled = true;

                ff = movement.properties.forwardForce;
                sf = movement.properties.strafeForce;
                veloc = rb.velocity;

                movement.properties.forwardForce = 0;
                movement.properties.strafeForce = 0;
                rb.velocity = new Vector3(0, 0, 0);
            }
            else
            {
                paused = false;
                pausedUI.enabled = false;

                movement.properties.forwardForce = ff;
                movement.properties.strafeForce = sf;
                rb.velocity = veloc;
            }
        }
	}
}
