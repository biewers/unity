using UnityEngine;

public class GameProperties : MonoBehaviour {

    public float jumpForce = 7.0f;
    public float teleportDuration = 1.0f;

    public float forwardForce = 100.0f;
    public float strafeForce = 1.0f;

    public Color jumpPUColor;
    public Color telePUColor;

    public bool jumpActivated = false;
    public bool teleActivated = false;

    public float playerHealth = 100.0f;
    public float MAX_PLAYER_HEALTH = 100.0f;
    public float playerHealthRegenPerFrame = 0.5f;
    public float playerHealthRegenDelay = 1.0f;

}
