using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    public GameObject tower;
    private Tower t;

    private void Start()
    {
        t = tower.GetComponent<Tower>();
    }

    public void Update()
    {
        this.GetComponent<Slider>().value = t.GetHealth() / t.maxHealth;
    }
}
