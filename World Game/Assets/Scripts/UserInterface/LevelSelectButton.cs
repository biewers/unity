using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour {

    public string sceneName;
	
	public void SelectLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
