using UnityEngine;
using UnityEngine.UI;

public class PointsText : MonoBehaviour {

    public Text points;
    public Player player;

    private void Start()
    {
        points = this.GetComponent<Text>();
    }

    private void Update()
    {
        points.text = "Points: " + Mathf.Round(player.points);
    }
}
