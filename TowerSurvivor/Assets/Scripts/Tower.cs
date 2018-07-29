using UnityEngine;

public class Tower : MonoBehaviour {

    [Header("Tower Statistics")]
    public float maxHealth = 100.0f;

    private float health;

    private void Start()
    {
        health = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponentInParent<Enemy>();
            Damage(enemy.damageToTower);
            Destroy(enemy.gameObject);
        }
    }

    public float GetHealth() { return health; }

    private void Damage(float dmg)
    {
        health -= dmg;
        CheckDeath();
        Debug.Log(health);
    }

    private void CheckDeath()
    {
        if(health <= 0)
        {
            //DEATH CODE HERE
            Debug.Log("Dead!");
        }
    }
}
