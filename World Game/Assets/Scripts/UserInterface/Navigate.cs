using UnityEngine;
using UnityEngine.UI;

public class Navigate : MonoBehaviour {

    public State gameState;

    private void Awake()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.2f;
    }

    public void OnClick()
    {
        this.GetComponent<Animator>().SetInteger("ZoomState", 1);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && GameState.currentState == gameState)
        {
            ZoomOut(this.GetComponent<Animator>());
        }
    }

    public void ZoomOut(Animator comp)
    {
        comp.enabled = true;
        comp.SetInteger("ZoomState", 2);
    }
}
