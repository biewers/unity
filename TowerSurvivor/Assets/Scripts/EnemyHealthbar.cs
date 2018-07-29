using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthbar : MonoBehaviour {

    public Enemy enemyScript;
    private float width;

    private void Start()
    {
        width = this.transform.lossyScale.y;
    }

    private void Update()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x, width * enemyScript.GetHealth() / enemyScript.maxHealth, this.transform.localScale.z);
    }

}
