using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projektil : MonoBehaviour {

    public float steta = 150f;
    public float GetDamage()
    {
        return steta;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
