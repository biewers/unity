using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public Material material;
    public GameProperties properties;

    private void Start()
    {
        properties = FindObjectOfType<GameProperties>();
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        rb.AddForce(new Vector3(0, 0, properties.forwardForce));

        if(Input.GetKey("a"))
        {
            rb.AddForce(new Vector3(-properties.strafeForce, 0, 0), ForceMode.VelocityChange);
        }
        if(Input.GetKey("d"))
        {
            rb.AddForce(new Vector3(properties.strafeForce, 0, 0), ForceMode.VelocityChange);
        }

        if(GetComponent<Transform>().position.y < -3)
        {
            FindObjectOfType<GameManager>().Death();
        }

        //---------------------Power Ups---------------------//

        //Jump Power Up
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(properties.jumpActivated)
            {
                Jump();
            }
        }

        //Tele Power Up
        if (Input.GetKeyDown("q"))
        {
            if (properties.teleActivated)
            {
                StartCoroutine(Teleport());
            }
        }
    }

    private void Jump()
    {
                           //Jump Power
        rb.AddForce(0, properties.jumpForce, 0, ForceMode.VelocityChange);

        FindObjectOfType<ColorChange>().BordersEnabled(false);
    }

    IEnumerator Teleport()
    {
        this.GetComponent<BoxCollider>().enabled = false;
        rb.useGravity = false;
        material.color = new Color(material.color.r, material.color.g, material.color.b, 0.5f);

                                            //Teleport Duration
        yield return new WaitForSeconds(properties.teleportDuration);

        this.GetComponent<BoxCollider>().enabled = true;
        rb.useGravity = true;
        material.color = new Color(material.color.r, material.color.g, material.color.b, 1.0f);

        ColorChange cc = FindObjectOfType<ColorChange>();
        cc.ChangeColor(properties.telePUColor);
        cc.BordersEnabled(false);
    }
}