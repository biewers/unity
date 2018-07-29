using UnityEngine;

public class Bullet : MonoBehaviour {

    public float dmg = 50.0f;
    public float lifetime = 10.0f;

    private void Start()
    {
        Destroy(this.gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponentInParent<Enemy>();
            enemy.DamageHealth(dmg);
        }
    }
}
