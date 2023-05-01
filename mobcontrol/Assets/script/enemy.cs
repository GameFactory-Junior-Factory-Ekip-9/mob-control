using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public float can;
    public float hasar;

  
    private void FixedUpdate()
    {
        if (can <= 0) { StartCoroutine(die()); }
        transform.Translate(0, 0, -speed * Time.fixedDeltaTime);
    }
     IEnumerator die()
    {
        hasar = 0;
        speed = 0;
        yield return new WaitForSecondsRealtime(1);
        Destroy(this.gameObject);
    }
    private void OncollisionEnter(Collider collider)
    {
        if (collider.gameObject.tag == "dostkarakter")
        {
            can -= collider.gameObject.GetComponent<karakter>().hasar;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("a");
        if (other.gameObject.tag == "dostkarakter")
        {
            can -= other.gameObject.transform.parent.gameObject.GetComponent<karakter>().hasar;
        }
    }
}
