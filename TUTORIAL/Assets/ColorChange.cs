using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour {

    Image[] images;

    private void Awake()
    {
        Debug.Log("Images added to array");
        images = GetComponentsInChildren<Image>();
    }

    public void ChangeColor(Color color)
    {
        foreach(Image img in images)
        {
            img.color = color;
        }
    }

    public void BordersEnabled(bool bordersEnabled)
    {
        if (bordersEnabled)
        {
            Debug.Log(images);

            foreach (Image img in images)
            {
                Debug.Log("Images enabling");
                img.enabled = false;
            }
            bordersEnabled = false;
        }
        else if(!bordersEnabled)
        {
            foreach(Image img in images)
            {
                img.enabled = true;
            }
            bordersEnabled = true;
        }
    }
}
