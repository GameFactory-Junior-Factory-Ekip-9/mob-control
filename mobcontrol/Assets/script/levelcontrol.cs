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
    public GameObject alınmışparatext;
    public GameObject paratext;
    public int para;
    public float alınmışpara;
    [Header("roundgeçişiboolları")]
    bool birdenikiye;
    bool ikidenüçe;
    bool üçtensona;
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
    [Header("dönmelerigerekenaçılar")]
    public Vector3 round1_2;
    public Vector3 round2_3;
    [Header("sonrakiroundiçingerekenkulesayısı")]
    public int round1için;
    public int round2için;
    public int round3için;
    [Header("topalanları")]
    public GameObject topalanı1;
    public GameObject topalanı2;
    public GameObject topalanı3;
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
        kaleler = GameObject.FindGameObjectsWithTag("düşmankalesi");
        if (kaleler.Length == round1için) { round = 1; }
        if (kaleler.Length == round2için) { round = 2; }
        if (kaleler.Length == round3için) { round = 3; }
        
        if (round == 2 && !birdenikiye) {birdenikiye = true; StartCoroutine(roundbirdenikiyeanimasyon());  }
        if (round == 3 && !ikidenüçe) { ikidenüçe = true; StartCoroutine(roundikidenüçeanimasyon()); }
        if(kaleler.Length==0&&!üçtensona){ üçtensona = true; StartCoroutine(roundüçtensonaanimasyon()); }

    }
    public IEnumerator roundbirdenikiyeanimasyon() {
        cancontrol = false;
        top.transform.GetChild(0).transform.DOLocalMove(new Vector3(0,0,0),0.1f);
        
        #region karakterlerivedüşmanlarıyoketme
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
        top.transform.DOMove(new Vector3(topalanı2.transform.position.x, top.transform.position.y, topalanı2.transform.position.z), 1);
        yield return new WaitForSecondsRealtime(1);
        toptekerleri.transform.DOLocalRotate(new Vector3(0, 0, 0), 1);
        yield return new WaitForSecondsRealtime(1);
        kamera.transform.SetParent(null);
        #endregion

        cancontrol = true;
    }
    public IEnumerator roundikidenüçeanimasyon()
    {
        cancontrol = false;
        top.transform.GetChild(0).transform.DOLocalMove(new Vector3(0, 0, 0), 0.1f);

        #region karakterlerivedüşmanlarıyoketme
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
        top.transform.DOMove(new Vector3(topalanı3.transform.position.x, top.transform.position.y, topalanı3.transform.position.z), 1);
        yield return new WaitForSecondsRealtime(1);
        toptekerleri.transform.DOLocalRotate(new Vector3(0, 0, 0), 1);
        yield return new WaitForSecondsRealtime(1);
        kamera.transform.SetParent(null);
        #endregion

        cancontrol = true;
    }
    public IEnumerator roundüçtensonaanimasyon()
    {
        cancontrol = false;
        top.transform.GetChild(0).transform.DOLocalMove(new Vector3(0, 0, 0), 0.1f);

        #region karakterlerivedüşmanlarıyoketme
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



        alınmışparatext.GetComponent<TextMeshProUGUI>().text = alınmışpara.ToString();
        PlayerPrefs.SetInt("money", para);
        winscreen.SetActive(true);
       
    }
    public void paraarttırtetikleyici(int money)
    {
        StartCoroutine(this.GetComponent<levelcontrol>().paraarttır(money));


    }
    public IEnumerator paraarttır(int money) {

        for (int i = 0; i < money; i++)
        {
            alınmışpara++;
            para++;
            paratext.GetComponent<TextMeshProUGUI>().text = para.ToString();
            yield return new WaitForSecondsRealtime(0.01f);
        } 
    }
}
