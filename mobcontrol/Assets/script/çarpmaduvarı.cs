using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class çarpmaduvarı : MonoBehaviour
{
    public GameObject multipletext;
    public GameObject karakter;
    public GameObject superkarakter;
    public GameObject top;
    public float multiple;
    public int kaçıncıduvar;
    private void Update()
    {
        multipletext.GetComponent<TextMeshProUGUI>().text = multiple.ToString()+"x";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "dostkarakterhandler")
        {
            if (kaçıncıduvar == 1 && !other.gameObject.GetComponent<karakter>().birinciçarpanaçarptı)
            {
                
                other.gameObject.GetComponent<karakter>().birinciçarpanaçarptı = true;
                for (int i = 0; i < multiple-1; i++)
                {
                    if (other.gameObject.GetComponent<karakter>().issuper)
                    {
                        GameObject newcharacter = Instantiate(superkarakter, other.gameObject.transform.position, Quaternion.Euler(0, top.gameObject.transform.rotation.eulerAngles.y + 90, 0));
                        newcharacter.GetComponent<karakter>().speedchanged = true;
                        newcharacter.gameObject.GetComponent<karakter>().speed = 2;
                        newcharacter.transform.Translate(new Vector3((multiple / 2) - i, 0, 0) / 4);
                        newcharacter.transform.localScale = new Vector3(12.5f, 12.5f, 12.5f) / 30;
                        newcharacter.GetComponent<karakter>().birinciçarpanaçarptı = true;
                    }
                    else {
                        GameObject newcharacter = Instantiate(karakter, other.gameObject.transform.position, Quaternion.Euler(0, top.gameObject.transform.rotation.eulerAngles.y + 90, 0));
                    newcharacter.GetComponent<karakter>().speedchanged = true;
                    newcharacter.gameObject.GetComponent<karakter>().speed = 2;
                    newcharacter.transform.Translate(new Vector3((multiple/2)-i, 0, 0)/4);
                    newcharacter.transform.localScale = new Vector3(12.5f, 12.5f, 12.5f) / 80;
                    newcharacter.GetComponent<karakter>().birinciçarpanaçarptı = true; 
                    }
                    
                    
                }
               
            }
            if (kaçıncıduvar == 2 && !other.gameObject.GetComponent<karakter>().ikinciçarpanaçarptı)
            {
                other.gameObject.GetComponent<karakter>().ikinciçarpanaçarptı = true;
                for (int i = 0; i < multiple - 1; i++)
                {

                    if (other.gameObject.GetComponent<karakter>().issuper)
                    {
                        GameObject newcharacter = Instantiate(superkarakter, other.gameObject.transform.position, Quaternion.Euler(0, top.gameObject.transform.rotation.eulerAngles.y + 90, 0));
                        newcharacter.GetComponent<karakter>().speedchanged = true;
                        newcharacter.gameObject.GetComponent<karakter>().speed = 2;
                        newcharacter.transform.Translate(new Vector3((multiple / 2) - i, 0, 0) / 4);
                        newcharacter.transform.localScale = new Vector3(12.5f, 12.5f, 12.5f) / 30;
                        newcharacter.GetComponent<karakter>().ikinciçarpanaçarptı = true;
                    }
                    else
                    {
                        GameObject newcharacter = Instantiate(karakter, other.gameObject.transform.position, Quaternion.Euler(0, top.gameObject.transform.rotation.eulerAngles.y + 90, 0));
                        newcharacter.GetComponent<karakter>().speedchanged = true;
                        newcharacter.gameObject.GetComponent<karakter>().speed = 2;
                        newcharacter.transform.Translate(new Vector3((multiple / 2) - i, 0, 0) / 4);
                        newcharacter.transform.localScale = new Vector3(12.5f, 12.5f, 12.5f) / 80;
                        newcharacter.GetComponent<karakter>().ikinciçarpanaçarptı = true;
                    }

                }


            }




        }
    }
}
