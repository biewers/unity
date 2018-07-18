using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform playerTrans;
    public Text scoreDialogue;

	void Update () {
        scoreDialogue.text = Mathf.Ceil(playerTrans.position.z).ToString();
	}
}
