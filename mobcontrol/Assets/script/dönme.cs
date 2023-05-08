using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dönme : MonoBehaviour
{
    public float rotatespeed;
    private void FixedUpdate()
    {
        transform.Rotate(90*Time.fixedDeltaTime,0,0);
    }
}
