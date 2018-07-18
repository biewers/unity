using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    GameProperties properties;

    private void Start()
    {
        properties = FindObjectOfType<GameProperties>();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        properties.playerHealth = properties.MAX_PLAYER_HEALTH;
    }
}
