using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UI;
using TMPro;


public class kale : MonoBehaviour
{
    public int requiredround;
    public GameObject cantext;
    public GameObject lvlcontrol;
    public GameObject düþman;
    public float can;
    public int summonwave;
    public int summoncount;
    public float summonperiod;
    public int money;
    
    public bool died;
    public GameObject kalebayraðý;
    public GameObject kalegövdesi;
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
        cantext.GetComponent<TextMeshProUGUI>().text = can.ToString();
        if (can <= 0&&!died) { died = true; StartCoroutine(die()); }
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
                        GameObject newenemy = Instantiate(düþman, transform.position + new Vector3(Random.Range(-1f, 1f), -0.25f,Random.Range(-1f,1f)) / 8, Quaternion.Euler(0, this.gameObject.transform.rotation.eulerAngles.y-180, 0));

                        yield return new WaitForSecondsRealtime(0.01f);
                    }
                    break;
                case 2:
                    for (int i = 0; i < summoncount && lvlcontrol.GetComponent<levelcontrol>().cancontrol; i++)
                    {
                        GameObject newenemy = Instantiate(düþman, transform.position + new Vector3(Random.Range(-1f, 1f), -0.25f, Random.Range(-1f, 1f)) / 8, Quaternion.Euler(0, this.gameObject.transform.rotation.eulerAngles.y-180, 0));

                        if (i - 5 == 0)
                        {
                            newenemy.GetComponent<enemy>().can = 3;
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
        cantext.SetActive(false);
        kalebayraðý.SetActive(false);
        kalegövdesi.SetActive(false);
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        lvlcontrol.GetComponent<levelcontrol>().paraarttýrtetikleyici(money);
        yield return new WaitForSecondsRealtime(1);
        this.gameObject.SetActive(false);
    }
}
