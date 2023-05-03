using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dostkaraktertrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            this.gameObject.transform.parent.GetComponent<karakter>().can -= other.gameObject.transform.parent.gameObject.GetComponent<enemy>().hasar;
        }
        
        if (other.gameObject.tag == "silindir")
        {
            
            this.gameObject.transform.parent.gameObject.transform.LookAt(new Vector3(this.gameObject.transform.parent.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.parent.gameObject.transform.position.z));
        }
    }
}
