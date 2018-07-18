using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour {

    public int remainingPU = 0;

	public void Increment()
    {
        remainingPU += 1;
    }

    private void Update()
    {
        this.GetComponent<Text>().text = remainingPU.ToString();
    }
}
