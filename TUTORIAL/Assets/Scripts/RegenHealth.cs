using UnityEngine;

public class RegenHealth : MonoBehaviour {

    GameProperties properties;

    private void Start()
    {
        properties = FindObjectOfType<GameProperties>();
    }

    void Update()
    {
        if (properties.playerHealth < properties.MAX_PLAYER_HEALTH)
        {
            properties.playerHealth += properties.playerHealthRegenPerFrame * Time.deltaTime;
        }
    }
}
