﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public ParticleSystem ps;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(ps, this.transform);

        ColorChange cc = FindObjectOfType<ColorChange>();
        cc.BordersEnabled(true);
        
        if (this.tag == "TelePU")
        {
            cc.ChangeColor(FindObjectOfType<GameProperties>().telePUColor);
            FindObjectOfType<GameProperties>().teleActivated = true;
        }
        else if (this.tag == "JumpPU")
        {
            cc.ChangeColor(FindObjectOfType<GameProperties>().jumpPUColor);
            FindObjectOfType<GameProperties>().jumpActivated = true;
        }
            

        this.GetComponent<MeshRenderer>().enabled = false;
        Destroy(this.gameObject, 2.0f);
    }
}
