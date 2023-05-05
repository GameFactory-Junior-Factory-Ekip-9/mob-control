using System.Collections;
using UnityEngine;


public class kale : MonoBehaviour
{
    [SerializeField] int requiredround;
    public GameObject lvlcontrol;
    public GameObject düþman;
    public float can;
    public int summonwave;
    public int summoncount;
    public float summonperiod;
    private void Awake()
    {
        lvlcontrol = GameObject.FindGameObjectWithTag("lvlcontrol");
    }
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
        if (requiredround == lvlcontrol.GetComponent<levelcontrol>().round&&lvlcontrol.GetComponent<levelcontrol>().cancontrol)
        {
            switch (summonwave)
            {
                case 1:
                    for (int i = 0; i < summoncount && lvlcontrol.GetComponent<levelcontrol>().cancontrol; i++)
                    {
                        GameObject newenemy = Instantiate(düþman, transform.position + new Vector3(Random.Range(-1f, 1f), -4f, Random.Range(-1f, 1f)) / 4, Quaternion.Euler(0, this.gameObject.transform.rotation.eulerAngles.y, 0));

                        yield return new WaitForSecondsRealtime(0.01f);
                    }
                    break;
                case 2:
                    for (int i = 0; i < summoncount && lvlcontrol.GetComponent<levelcontrol>().cancontrol; i++)
                    {
                        GameObject newenemy = Instantiate(düþman, transform.position + new Vector3(Random.Range(-1f, 1f), -4f, Random.Range(-1f, 1f)) / 4, Quaternion.Euler(0, this.gameObject.transform.rotation.eulerAngles.y, 0));

                        if (i - 5 == 0)
                        {
                            newenemy.transform.GetChild(0).gameObject.GetComponent<enemy>().can = 3;
                        }
                        yield return new WaitForSecondsRealtime(0.01f);
                    }
                    break;

            }
        }
        
        yield return new WaitForSecondsRealtime(summonperiod);
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
