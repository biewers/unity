using UnityEngine;

public class GunScript : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public float bulletSpeed = 1.0f;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire(bulletSpawn);
        }
    }

    private void Fire(Transform t)
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, t.position, t.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
    }
}
