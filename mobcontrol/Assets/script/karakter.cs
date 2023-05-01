using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter : MonoBehaviour
{
    public float speed;
    public float can;
    public float hasar;
    private void Start()
    {
        StartCoroutine(slowing());
    }
    private void FixedUpdate()
    {
       if (can <= 0) { StartCoroutine(die()); }
        transform.Translate(0,0,speed*Time.fixedDeltaTime);
    }
    IEnumerator slowing()
    {
        for (int i = 0; i < 100; i++)
        {
            speed -= 0.06f;
            yield return new WaitForSecondsRealtime(0.005f);
        }
    }
    private void OncollisionEnter(Collider collider)
    {
        Debug.Log("a");
        if (collider.gameObject.tag== "enemy")
        {
            can -=collider.gameObject.GetComponent<enemy>().hasar;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            can -= other.gameObject.transform.parent.gameObject.GetComponent<enemy>().hasar;


        }
    }
    public IEnumerator die() {
        hasar = 0;
        speed = 0;
        yield return new WaitForSecondsRealtime(1);
        Destroy(this.gameObject);
    }
}
