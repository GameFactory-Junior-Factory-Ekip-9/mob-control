using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemytrigger : MonoBehaviour
{
    private void FixedUpdate()
    {
        this.transform.localPosition = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "dostkarakter")
        {
            this.gameObject.transform.parent.gameObject.GetComponent<enemy>().can -= other.gameObject.transform.parent.gameObject.GetComponent<karakter>().hasar;
        }
    }
}
