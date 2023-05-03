using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top : MonoBehaviour
{
    public GameObject karakter;
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
        if (Input.touchCount > 0&& control.GetComponent<levelcontrol>().cancontrol)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) { }
            if (touch.phase == TouchPhase.Moved) {

                float xposition = (touch.position.x - (Screen.width / 2)) * topspeed / Screen.height;
                xposition =Mathf.Clamp(xposition,-4,4);
                transform.localPosition = new Vector3(xposition, 0.3f,0);
                
            }
        }
    }
    public void fire() 
    {
        if (control.GetComponent<levelcontrol>().cancontrol) {
            for (int i = 0; i < firecount; i++)
        {
                GameObject newcharacter = Instantiate(karakter,this.gameObject.transform.position, Quaternion.Euler(0, this.gameObject.transform.rotation.eulerAngles.y + 90, 0));
                newcharacter.transform.Translate(new Vector3((-firecount / 2 + i) / 4 + 0.125f, 0, 1.5f));
            newcharacter.transform.localScale = new Vector3(12.5f,12.5f,12.5f)/100;
        } 
        }
        
    }
}
