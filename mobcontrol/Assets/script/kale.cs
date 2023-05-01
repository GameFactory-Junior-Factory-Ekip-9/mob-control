using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kale : MonoBehaviour
{
    public GameObject düþman;
    public float can;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(summon());
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public IEnumerator summon()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(düþman, transform.position+new Vector3(Random.Range(-1f,1f),0, Random.Range(-1f, 1f))/4, Quaternion.identity);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        yield return new WaitForSecondsRealtime(10f);


    }
    
}
