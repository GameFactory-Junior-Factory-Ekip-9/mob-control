using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class levelcontrol : MonoBehaviour
{
    public bool cancontrol;
    public int round;
    [Header("para")]
    public GameObject al�nm��paratext;
    public GameObject paratext;
    public int para;
    public float al�nm��para;
    [Header("roundge�i�iboollar�")]
    bool birdenikiye;
    bool ikiden��e;
    bool ��tensona;
    [Header("arrayler")]
    public GameObject[] enemies;
    public GameObject[] karakterler;
    public GameObject[] kaleler;
    [Header("objeler")]
    public GameObject kamera;
    public GameObject top;
    public GameObject toptekerleri;
    [Header("silindirler")]
    public GameObject silindir1;
    public GameObject silindir2;
    public GameObject silindir3;
    public GameObject silindir4;
    [Header("d�nmelerigerekena��lar")]
    public Vector3 round1_2;
    public Vector3 round2_3;
    [Header("sonrakiroundi�ingerekenkulesay�s�")]
    public int round1i�in;
    public int round2i�in;
    public int round3i�in;
    [Header("topalanlar�")]
    public GameObject topalan�1;
    public GameObject topalan�2;
    public GameObject topalan�3;
    [Header("Screens")]
    public GameObject winscreen;
    public GameObject losescreen;

    private void Start()
    {
        cancontrol = false;
        if (PlayerPrefs.HasKey("money"))
        {
            para = PlayerPrefs.GetInt("money");
            paratext.GetComponent<TextMeshProUGUI>().text = para.ToString();
        }
        
    }
    void Update()
    {
        kaleler = GameObject.FindGameObjectsWithTag("d��mankalesi");
        if (kaleler.Length == round1i�in) { round = 1; }
        if (kaleler.Length == round2i�in) { round = 2; }
        if (kaleler.Length == round3i�in) { round = 3; }
        
        if (round == 2 && !birdenikiye) {birdenikiye = true; StartCoroutine(roundbirdenikiyeanimasyon());  }
        if (round == 3 && !ikiden��e) { ikiden��e = true; StartCoroutine(roundikiden��eanimasyon()); }
        if(kaleler.Length==0&&!��tensona){ ��tensona = true; StartCoroutine(round��tensonaanimasyon()); }

    }
    public IEnumerator roundbirdenikiyeanimasyon() {
        cancontrol = false;
        top.transform.GetChild(0).transform.DOLocalMove(new Vector3(0,0,0),0.1f);
        
        #region karakterlerived��manlar�yoketme
        karakterler = GameObject.FindGameObjectsWithTag("dostkarakterhandler");
        enemies= GameObject.FindGameObjectsWithTag("enemyhandler"); 
        for (int i = 0; i < enemies.Length; i++)
        {
            StartCoroutine(enemies[i].gameObject.gameObject.GetComponent<enemy>().die());
        }
      
        for (int i = 0; i < karakterler.Length; i++)
        {
            StartCoroutine(karakterler[i].gameObject.GetComponent<karakter>().die());
        }
        #endregion

        yield return new WaitForSecondsRealtime(1);
        
        #region animasyon
        kamera.transform.SetParent(top.transform);
        toptekerleri.transform.DOLocalRotate(new Vector3(0, 90, 0), 1);
        top.transform.DOMove(new Vector3(silindir2.transform.position.x,top.transform.position.y, silindir2.transform.position.z),3);
        yield return new WaitForSecondsRealtime(3);
        top.transform.DORotate(new Vector3(0, round1_2.y, 0),1);
        yield return new WaitForSecondsRealtime(1);
        top.transform.DOMove(new Vector3(topalan�2.transform.position.x, top.transform.position.y, topalan�2.transform.position.z), 1);
        yield return new WaitForSecondsRealtime(1);
        toptekerleri.transform.DOLocalRotate(new Vector3(0, 0, 0), 1);
        yield return new WaitForSecondsRealtime(1);
        kamera.transform.SetParent(null);
        #endregion

        cancontrol = true;
    }
    public IEnumerator roundikiden��eanimasyon()
    {
        cancontrol = false;
        top.transform.GetChild(0).transform.DOLocalMove(new Vector3(0, 0, 0), 0.1f);

        #region karakterlerived��manlar�yoketme
        karakterler = GameObject.FindGameObjectsWithTag("dostkarakterhandler");
        enemies = GameObject.FindGameObjectsWithTag("enemyhandler");
        for (int i = 0; i < enemies.Length; i++)
        {
            StartCoroutine(enemies[i].gameObject.GetComponent<enemy>().die());
        }

        for (int i = 0; i < karakterler.Length; i++)
        {
            StartCoroutine(karakterler[i].gameObject.GetComponent<karakter>().die());
        }
        #endregion

        yield return new WaitForSecondsRealtime(1);

        #region animasyon
        kamera.transform.SetParent(top.transform);
        toptekerleri.transform.DOLocalRotate(new Vector3(0,90,0), 1);
        top.transform.DOMove(new Vector3(silindir3.transform.position.x, top.transform.position.y, silindir3.transform.position.z), 3);
        yield return new WaitForSecondsRealtime(3);
        top.transform.DORotate(new Vector3(0,round2_3.y, 0), 1);
        yield return new WaitForSecondsRealtime(1);
        top.transform.DOMove(new Vector3(topalan�3.transform.position.x, top.transform.position.y, topalan�3.transform.position.z), 1);
        yield return new WaitForSecondsRealtime(1);
        toptekerleri.transform.DOLocalRotate(new Vector3(0, 0, 0), 1);
        yield return new WaitForSecondsRealtime(1);
        kamera.transform.SetParent(null);
        #endregion

        cancontrol = true;
    }
    public IEnumerator round��tensonaanimasyon()
    {
        cancontrol = false;
        top.transform.GetChild(0).transform.DOLocalMove(new Vector3(0, 0, 0), 0.1f);

        #region karakterlerived��manlar�yoketme
        karakterler = GameObject.FindGameObjectsWithTag("dostkarakterhandler");
        enemies = GameObject.FindGameObjectsWithTag("enemyhandler");
        for (int i = 0; i < enemies.Length; i++)
        {
            StartCoroutine(enemies[i].gameObject.GetComponent<enemy>().die());
        }

        for (int i = 0; i < karakterler.Length; i++)
        {
            StartCoroutine(karakterler[i].gameObject.GetComponent<karakter>().die());
        }
        #endregion

        yield return new WaitForSecondsRealtime(1);

        #region animasyon
        kamera.transform.SetParent(top.transform);
        toptekerleri.transform.DOLocalRotate(new Vector3(0, 90, 0), 1);
        top.transform.DOMove(new Vector3(silindir4.transform.position.x, top.transform.position.y, silindir4.transform.position.z), 3);
        yield return new WaitForSecondsRealtime(4);
        kamera.transform.SetParent(null);
        #endregion



        al�nm��paratext.GetComponent<TextMeshProUGUI>().text = al�nm��para.ToString();
        PlayerPrefs.SetInt("money", para);
        winscreen.SetActive(true);
       
    }
    public void paraartt�rtetikleyici(int money)
    {
        StartCoroutine(this.GetComponent<levelcontrol>().paraartt�r(money));


    }
    public IEnumerator paraartt�r(int money) {

        for (int i = 0; i < money; i++)
        {
            al�nm��para++;
            para++;
            paratext.GetComponent<TextMeshProUGUI>().text = para.ToString();
            yield return new WaitForSecondsRealtime(0.01f);
        } 
    }
}
