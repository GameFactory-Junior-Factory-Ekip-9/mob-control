using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter : MonoBehaviour
{

    public bool birinciçarpanaçarptý;
    public bool ikinciçarpanaçarptý;
    public bool lookat;
    public bool issuper;
    public Animator animator;
    public float speed;
    public bool speedchanged;
    public float can;
    public float hasar;
    public GameObject[] kaleler;
    public GameObject levelcontrol; 
    private void Awake()
    {
        
        levelcontrol = GameObject.FindGameObjectWithTag("lvlcontrol");
    }
    private void Start()
    {
        StartCoroutine(slowing());
    }
    private void FixedUpdate()
    {
        if (issuper) { this.transform.localScale = new Vector3(12.5f, 12.5f, 12.5f) / 30; }
        if (lookat) { for (int i = 0; i < kaleler.Length; i++)
            {
                if (kaleler[i].GetComponent<kale>().requiredround == levelcontrol.GetComponent<levelcontrol>().round) 
                {transform.LookAt(new Vector3(kaleler[i].gameObject.transform.position.x,this.gameObject.transform.position.y, kaleler[i].gameObject.transform.position.z)); }
            } }
       
        kaleler = GameObject.FindGameObjectsWithTag("düþmankalesi");
       if (can <= 0) { StartCoroutine(die()); }
       transform.Translate(0, 0, Time.fixedDeltaTime*speed);
       
    }
   public  IEnumerator slowing()
    {
        
            for (int i = 0; i < 100; i++)
            {
            if (!speedchanged)
            {

                speed -= 0.03f;
                yield return new WaitForSecondsRealtime(0.005f);
                if (speed <= 0) { speed = 0; }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "silindir")
        {


            lookat = true;

        }
    }
    public IEnumerator die() {
        hasar = 0;
        speed = 0;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        animator.SetBool("öldü", true);
        yield return new WaitForSecondsRealtime(1);
        this.gameObject.SetActive(false);
    }
}
