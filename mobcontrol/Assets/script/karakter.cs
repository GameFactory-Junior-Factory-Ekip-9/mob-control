using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter : MonoBehaviour
{
    public Animator animator;
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
       transform.Translate(0, 0, Time.fixedDeltaTime*speed);
       
    }
    IEnumerator slowing()
    {
        for (int i = 0; i < 100; i++)
        {
            speed -= 0.03f;
            yield return new WaitForSecondsRealtime(0.005f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "silindir")
        {
            transform.LookAt(new Vector3(other.gameObject.transform.position.x,this.gameObject.transform.position.y, other.gameObject.transform.position.z));


        }
    }
    public IEnumerator die() {
        hasar = 0;
        speed = 0;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        animator.SetBool("öldü", true);
        yield return new WaitForSecondsRealtime(1);
        Destroy(this.gameObject);
    }
}
