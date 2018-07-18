using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour {
    
    public void ChangeColor(Color color)
    {
        GetComponent<Image>().color = color;
    }

    public void BordersEnabled(bool bordersEnabled)
    {
        GetComponent<Image>().enabled = bordersEnabled;
    }
}
