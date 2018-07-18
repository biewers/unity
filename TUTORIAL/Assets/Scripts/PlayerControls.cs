using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour {

    GameProperties properties;

    public Rigidbody rb;
    public Text pausedUI;

    bool paused = false;
    float ff, sf;
    Vector3 veloc;

    private void Start()
    {
        properties = FindObjectOfType<GameProperties>();
    }

    void Update () {
	    if(Input.GetKeyDown("p"))
        {
            if (!paused)
            {
                paused = true;
                pausedUI.enabled = true;    

                ff = properties.forwardForce;
                sf = properties.strafeForce;
                veloc = rb.velocity;

                properties.forwardForce = 0;
                properties.strafeForce = 0;
                rb.velocity = new Vector3(0, 0, 0);
            }
            else
            {
                paused = false;
                pausedUI.enabled = false;

                properties.forwardForce = ff;
                properties.strafeForce = sf;
                rb.velocity = veloc;
            }
        }
	}
}
