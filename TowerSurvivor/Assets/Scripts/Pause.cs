using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public Image icon;
    public Player movementScript;
    private bool paused = false;

    private void Awake()
    {
        icon = this.GetComponent<Image>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!paused)
            {
                Time.timeScale = 0;

                movementScript.enabled = false;
                icon.enabled = true;

                paused = true;
            }
            else
            {
                Time.timeScale = 1;

                movementScript.enabled = true;
                icon.enabled = false;

                paused = false;
            }
        }
    }
}
