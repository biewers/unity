using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header("General Properites")]
    public Transform towerTransform;
    public Transform enemyMeshTransform;
    public ParticleSystem deathParticles;

    [Header("Attributes")]
    public float minMoveSpeed = 5.0f;
    public float maxMoveSpeed = 10.0f;
    private float moveSpeed;
    public float maxHealth = 100.0f;
    private float health;
    public float damageToTower = 10.0f;
    public float pointsAwarded = 10.0f;

    private Vector3 moveDirection;

    private void Awake()
    {
        towerTransform = GameObject.Find("MainTower").transform;
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    private void Start()
    {
        health = maxHealth;
        moveDirection = (towerTransform.position - transform.position) * moveSpeed * Time.deltaTime / 100;
    }

    private void Update()
    {
        Move();
    }

    public float GetHealth() { return health; }

    private void Move()
    {
        this.GetComponent<Rigidbody>().velocity = moveDirection * 20;

        Quaternion rotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));
        Quaternion currentRotation = enemyMeshTransform.transform.rotation;
        enemyMeshTransform.transform.rotation = Quaternion.Slerp(currentRotation, rotation, Time.deltaTime);
    }

    public void DamageHealth(float dmg)
    {
        health -= dmg;
        CheckDeath();
    }

    public void CheckDeath()
    {
        if (health <= 0)
        {
            ParticleSystem particles = Instantiate(deathParticles, this.GetComponentInChildren<Transform>().position, this.GetComponentInChildren<Transform>().rotation);
            GameObject.Find("Player").GetComponent<Player>().AddPoints(pointsAwarded);
            Destroy(this.gameObject);
        }
    }

}
