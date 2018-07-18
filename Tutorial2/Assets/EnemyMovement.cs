using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.transform.position - this.transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        

        if (dir.magnitude <= 0.2f)
        {
            NextWaypoint();
        }
    }

    void NextWaypoint()
    {
        if(waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject, 0);
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
