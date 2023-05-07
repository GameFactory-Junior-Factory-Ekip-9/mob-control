using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float can;
    public float hasar;
    public float scale;
  
    private void FixedUpdate()
    {
        if (can <= 0) { StartCoroutine(die()); }
        this.gameObject.transform.Translate(0, 0, -speed * Time.fixedDeltaTime);
        scale = 0;
        if (can > 0) {  this.gameObject.transform.localScale =new Vector3(1,1,1)*(1+(can-1)*0.25f)*1.2f; }
      

    }
    public IEnumerator die()
    {
        hasar = 0;
        speed = 0;
        animator.SetBool("öldü", true);
        yield return new WaitForSecondsRealtime(1);
        this.gameObject.SetActive(false);
    }
    
    
   
}
