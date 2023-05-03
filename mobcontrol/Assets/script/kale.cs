using System.Collections;
using UnityEngine;


public class kale : MonoBehaviour
{
    public GameObject düþman;
    public float can;
    public int summonwave;
    
    void Start()
    {
        StartCoroutine(summon());
    }

    
    void Update()
    {

        if (can <= 0) { StartCoroutine(die()); }
    }
    public IEnumerator summon()
    {
        summonwave = Random.Range(1, 3);
        switch (summonwave)
        {
            case 1:
                for (int i = 0; i < 20; i++)
                {
                    GameObject newenemy = Instantiate(düþman, transform.position + new Vector3(Random.Range(-1f, 1f), -4f, Random.Range(-1f, 1f)) / 4, Quaternion.identity);
                    
                    yield return new WaitForSecondsRealtime(0.01f);
                }
                break;
            case 2:
                for (int i = 0; i < 20; i++)
                {
                    GameObject newenemy = Instantiate(düþman, transform.position + new Vector3(Random.Range(-1f, 1f), -4f, Random.Range(-1f, 1f)) / 4, Quaternion.identity);
                    
                    if (i - 5 == 0) {
                        newenemy.transform.GetChild(0).gameObject.GetComponent<enemy>().can = 3;
                    }
                    yield return new WaitForSecondsRealtime(0.01f);
                }
                break;
               
        }
       
        
        yield return new WaitForSecondsRealtime(5f);
        StartCoroutine(summon());


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "dostkarakter")
        {
            can -= other.gameObject.transform.parent.gameObject.GetComponent<karakter>().hasar;
            other.transform.parent.gameObject.GetComponent<karakter>().can = 0;

        }
    }
    public IEnumerator die()
    {
        
        yield return new WaitForSecondsRealtime(1);
        Destroy(this.gameObject);
    }
}
