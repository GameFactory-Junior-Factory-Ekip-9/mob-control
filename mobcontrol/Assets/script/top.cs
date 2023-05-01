using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top : MonoBehaviour
{
    public GameObject karakter;
    public float topspeed;
    public float firerate;
    public float firecount;
    private void Start()
    {
        InvokeRepeating("fire",0,1/firerate);
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) { }
            if (touch.phase == TouchPhase.Moved) {
                float xposition = (touch.position.x - (Screen.width / 2)) * topspeed / Screen.height;
                xposition =Mathf.Clamp(xposition,-4,4);
                transform.position = new Vector3(xposition, 0.3f,5.5f);
            }
        }
    }
    public void fire() 
    {
        for (int i = 0; i < firecount; i++)
        {
         Instantiate(karakter,transform.position+new Vector3((-firecount/2+i)/4+0.125f,0,0),Quaternion.identity);
        }
    }
}
