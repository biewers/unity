using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [Header("Required Fields")]
    public Camera playerCam;
    public Camera scopeCam;

    private Image crosshair;

    [Header("Attributes")]
    public float lookSensitivity = 5.0f;
    public float zoomLookSensitivity = 1.0f;
    public float moveSpeed = 10.0f;

    public float playerMovementRange = 2.25f;
    public float playerLookRange;

    public float points;
    public void SetPoints(float p) { points = p; }
    public void AddPoints(float p) { points += p; }

    private bool zoomed = false;

    Quaternion centerOfScreen;
    private void Awake()
    {
        this.centerOfScreen = playerCam.transform.rotation;
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
    }

    private void Update()
    {
        Move();
        Rotate();

        CheckZoomToggle();
    }

    private void Move()
    {
        float movDirX = Input.GetAxisRaw("Horizontal");
        float movDirZ = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = new Vector3(movDirX, 0.0f, movDirZ) * Time.deltaTime * moveSpeed;
        transform.Translate(moveDir);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -playerMovementRange, playerMovementRange);
        pos.z = Mathf.Clamp(pos.z, -playerMovementRange, playerMovementRange);

        transform.position = pos;
    }

    private void Rotate()
    {
        if (!zoomed)
        {
            //Horizontal Rotation
            Vector3 hRotation = new Vector3(0.0f, Input.GetAxisRaw("Mouse X"), 0.0f) * lookSensitivity;
            this.transform.rotation *= Quaternion.Euler(hRotation);

            //Vertical rotation
            Vector3 vRotation = new Vector3(Input.GetAxisRaw("Mouse Y") * -1, 0.0f, 0.0f) * lookSensitivity;
            Quaternion qRotation = Quaternion.Euler(vRotation);

            if (Quaternion.Angle(centerOfScreen, playerCam.transform.localRotation * qRotation) < playerLookRange)
                playerCam.transform.rotation *= Quaternion.Euler(vRotation);
        }
        else if (zoomed)
        {
            //Horizontal Rotation
            Vector3 hRotation = new Vector3(0.0f, Input.GetAxisRaw("Mouse X"), 0.0f) * zoomLookSensitivity;
            this.transform.rotation *= Quaternion.Euler(hRotation);

            //Vertical rotation
            Vector3 vRotation = new Vector3(Input.GetAxisRaw("Mouse Y") * -1, 0.0f, 0.0f) * zoomLookSensitivity;
            Quaternion qRotation = Quaternion.Euler(vRotation);

            if (Quaternion.Angle(centerOfScreen, playerCam.transform.localRotation * qRotation) < playerLookRange)
                playerCam.transform.rotation *= Quaternion.Euler(vRotation);
        }
    }

    private void CheckZoomToggle()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (!zoomed)
            {
                scopeCam.enabled = true;
                playerCam.enabled = false;
                crosshair.enabled = true;
                zoomed = true;
            }
            else if (zoomed)
            {

                playerCam.enabled = true;
                scopeCam.enabled = false;
                crosshair.enabled = false;
                zoomed = false;
            }
        }
    }
}
