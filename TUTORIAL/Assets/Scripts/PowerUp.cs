using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    GameProperties properties;
    public ParticleSystem ps;

    private void Start()
    {
        properties = FindObjectOfType<GameProperties>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(ps, this.transform);

        ColorChange cc = FindObjectOfType<ColorChange>();
        cc.BordersEnabled(true);
        
        if (this.tag == "TelePU")
        {
            cc.ChangeColor(properties.telePUColor);
            properties.teleActivated = true;
        }
        else if (this.tag == "JumpPU")
        {
            cc.ChangeColor(properties.jumpPUColor);
            properties.jumpActivated = true;
        }
            

        this.GetComponent<MeshRenderer>().enabled = false;
        Destroy(this.gameObject, 2.0f);
    }
}
