using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour {

    public int index = 0;
	
	public void SelectLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }
}
