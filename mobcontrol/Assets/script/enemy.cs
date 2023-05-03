using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public float can;
    public float hasar;
    public float scale;
  
    private void FixedUpdate()
    {
        if (can <= 0) { StartCoroutine(die()); }
        this.gameObject.transform.parent.transform.Translate(0, 0, -speed * Time.fixedDeltaTime);
        scale = 0;
        
        this.gameObject.transform.parent.transform.localScale =new Vector3(1,1,1)*(1+(can-1)*0.25f);

    }
    public IEnumerator die()
    {
        hasar = 0;
        speed = 0;
        yield return new WaitForSecondsRealtime(1);
        Destroy(this.transform.parent.gameObject);
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "dostkarakter")
        {
            can -= other.gameObject.transform.parent.gameObject.GetComponent<karakter>().hasar;
        }
    }
}
