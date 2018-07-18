using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    GameProperties properties;
    RectTransform rt;
    float barSizeX, barSizeY;

    private void Start()
    {
        properties = FindObjectOfType<GameProperties>();
        rt = GetComponent<RectTransform>();
        barSizeX = rt.sizeDelta.x;
        barSizeY = rt.sizeDelta.y;
    }

    private void Update()
    {
        rt.sizeDelta = new Vector2(barSizeX * properties.playerHealth / properties.MAX_PLAYER_HEALTH, barSizeY);
    }

}
