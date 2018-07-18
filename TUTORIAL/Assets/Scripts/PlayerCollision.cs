using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

    GameProperties properties;

    public float collisionDamage = 20.0f;

    private void Start()
    {
        properties = FindObjectOfType<GameProperties>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            properties.playerHealth -= collisionDamage;

            if(properties.playerHealth <= 0)
                FindObjectOfType<GameManager>().Death();

            StartCoroutine(HealthRegenDelay());
        }
    }

    IEnumerator HealthRegenDelay()
    {
        FindObjectOfType<RegenHealth>().enabled = false;
        yield return new WaitForSeconds(properties.playerHealthRegenDelay);
        FindObjectOfType<RegenHealth>().enabled = true;
    }
}
