using UnityEngine;

public class LightState : MonoBehaviour {
    
    [Header("Color States")]
    public Color currentRoundColor;
    public Color newRoundColorOne, newRoundColorTwo;

    [Header("Color Switching Properties")]
    public float timeBetweenColorChange;
    private float counter = 0;

    Light[] lights;
    Material mat;
    public bool waveStarting;

    private void Awake()
    {
        lights = GetComponentsInChildren<Light>();
        mat = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        if(waveStarting)
        {
            counter += Time.deltaTime;

            if(counter > timeBetweenColorChange)
            {
                SwitchCountdownColors();
                counter = 0;
            }
        }
    }

    public void ChangeColor(Color color)
    {
        foreach (Light l in lights)
        {
            l.color = color;
        }

        mat.color = color;
    }

    private void SwitchCountdownColors()
    {
        if (mat.color == newRoundColorOne)
            ChangeColor(newRoundColorTwo);
        else if (mat.color == newRoundColorTwo)
            ChangeColor(newRoundColorOne);
    }

    public void SetNewRoundColor(Color c)
    {
        ChangeColor(c);
    }
}
