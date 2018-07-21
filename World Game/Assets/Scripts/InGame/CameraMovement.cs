using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform playerTransform;
    public Vector3 cameraPosOffsetLeft = new Vector3(2, 1, -10);
    public Vector3 cameraPosOffsetRight = new Vector3(0, 1, -10);
    
	void Update () {

        if (playerTransform.position.x - GetComponent<Transform>().position.x <= -2)
        {
            GetComponent<Transform>().position = playerTransform.position + cameraPosOffsetLeft;
        }
        else if (playerTransform.position.x - GetComponent<Transform>().position.x >= 0)
        {
            GetComponent<Transform>().position = playerTransform.position + cameraPosOffsetRight;
        }

	}
}
