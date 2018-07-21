using UnityEngine;
using UnityEngine.UI;

public class ToggleImage : MonoBehaviour {

    static Image[] images;
    static Image[] exce;

    public Image[] exceptions;

    private void Start()
    {
        exce = exceptions;
        images = FindObjectsOfType<Image>();
    }

    public static void Enable(string name)
    {
        foreach(Image img in images)
        {
            if(img.name == name)
            {
                if (name == "BackButton")
                {
                    img.gameObject.SetActive(true);
                }
                else
                {
                    img.enabled = true;
                    Debug.Log(img.name + " enabled.");
                }
            }
        }

        
    }

    public static void Disable(string name)
    {
        foreach (Image img in images)
        {
            if (img.name == name)
            {
                if (name == "BackButton")
                {
                    img.gameObject.SetActive(true);
                }
                else
                {
                    img.enabled = false;
                    Debug.Log(img.name + " disabled.");
                }
            }
        }
    }

    public static void DisableAllExcept(string name)
    {
        foreach (Image img in images)
        {
            if (img.name != name)
            {
                foreach(Image img2 in exce)
                {
                    if (img2.name != img.name)
                    {
                        img.enabled = false;
                    }
                }
            }
            else
            {
                img.enabled = true;
            }
        }

        Debug.Log("All disabled except " + name);
    }

    public static void EnableWorldDisableRest()
    {
        foreach (Image img in images)
        {
            if (img.name.Length == 2)
            {
                img.enabled = true;
            }
            else
            {
                img.enabled = false;
            }
        }
    }
}
