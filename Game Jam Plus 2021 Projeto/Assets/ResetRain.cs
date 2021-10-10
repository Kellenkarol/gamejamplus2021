using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRain : MonoBehaviour
{

    public IA_Boss bossScript;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 9)
        {
            bossScript.RemoveBallRain(col.gameObject);
        }
    }
}
