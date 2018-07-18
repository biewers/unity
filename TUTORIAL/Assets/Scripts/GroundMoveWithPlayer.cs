using UnityEngine;

public class GroundMoveWithPlayer : MonoBehaviour {

    public Transform playerTransform;
    public Vector3 offset;

    private void Start()
    {
        offset = this.transform.position - playerTransform.position;
    }

    private void Update()
    {
        this.transform.position = new Vector3(0, 0, playerTransform.position.z + offset.z);
    }
}
