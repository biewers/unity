using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;
    public float sleep = 1.0f;
    public GameObject completeLevelUI;
    public Image XImg;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

	public void Death()
    {
        if(!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Dead.");
            XImg.enabled = true;
            Invoke("Restart", sleep);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
