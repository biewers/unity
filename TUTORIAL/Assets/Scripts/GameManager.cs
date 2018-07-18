using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;

	public float restartDelay = 1f;

	public GameObject completeLevelUI;
    public Image XImg;

	public void CompleteLevel ()
	{
		completeLevelUI.SetActive(true);
	}

	public void Death()
	{
		if (gameHasEnded == false)
		{
            XImg.enabled = true;

			gameHasEnded = true;
			Invoke("Restart", restartDelay);
		}
	}

	void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
