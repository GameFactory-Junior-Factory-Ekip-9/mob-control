using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class top : MonoBehaviour
{
    public GameObject ateþetmeanmasyonobjesi;
    public GameObject superbar;
    public float super;
    public GameObject karakter;
    public GameObject superkarakter;
    public float topspeed;
    public float firerate;
    public float firecount;
    public GameObject control;
    private void Start()
    {
        InvokeRepeating("fire",0,1/firerate);
    }
    void Update()
    {
        superbar.GetComponent<Image>().fillAmount =super/25;
        if (Input.touchCount > 0&& control.GetComponent<levelcontrol>().cancontrol)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended) { superfire(); }
            if (touch.phase == TouchPhase.Moved) {

                float xposition = (touch.position.x - (Screen.width / 2)) * topspeed / Screen.height;
                xposition =Mathf.Clamp(xposition,-3.5f,3.5f);
                transform.localPosition = new Vector3(xposition, 0.3f,0);
                
            }
        }
    }
    public void fire() 
    {
if (control.GetComponent<levelcontrol>().cancontrol) {
            StartCoroutine(this.gameObject.GetComponent<ateþetmeanimasyonu>().ateþetmeobjesininanimasyonu());
        if (super < 25) {super++; }
        
        
            for (int i = 0; i < firecount; i++)
        {
                GameObject newcharacter = Instantiate(karakter,this.gameObject.transform.position, Quaternion.Euler(0, this.gameObject.transform.rotation.eulerAngles.y + 90, 0));
                newcharacter.transform.Translate(new Vector3((-firecount / 2 + i) / 4 + 0.125f, 0, 1.5f));
            newcharacter.transform.localScale = new Vector3(12.5f,12.5f,12.5f)/80;
        } 
        }
        
    }
    public void superfire()
    {
       
        if (super == 25) {
            
            super =0;
            GameObject newsuper= Instantiate(superkarakter, this.gameObject.transform.position+new Vector3(0,0.5f,0), Quaternion.Euler(0, this.gameObject.transform.rotation.eulerAngles.y + 90, 0));
            newsuper.transform.localScale = new Vector3(12.5f, 12.5f, 12.5f) / 30;
        }
        




    }
}
