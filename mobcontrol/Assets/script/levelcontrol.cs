using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class levelcontrol : MonoBehaviour
{
    public bool cancontrol;
    public int round;
    [Header("roundgeçiþiboollarý")]
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
    public GameObject silindir1;
    public GameObject silindir2;
    public GameObject silindir3;
    public GameObject silindir4;
    private void Start()
    {
        cancontrol = true;
    }
    void Update()
    {
        kaleler = GameObject.FindGameObjectsWithTag("düþmankalesi");
        if (kaleler.Length == 3) { round = 1; }
        if (kaleler.Length == 2) { round = 2; }
        if (kaleler.Length == 1) { round = 3; }
        if (round == 2 && !birdenikiye) {birdenikiye = true; StartCoroutine(roundbirdenikiyeanimasyon());  }

    }
    public IEnumerator roundbirdenikiyeanimasyon() {
        cancontrol = false;
        top.transform.GetChild(0).transform.position = new Vector3(0,0,5.4f);
        
        #region karakterlerivedüþmanlarýyoketme
        karakterler = GameObject.FindGameObjectsWithTag("dostkarakterhandler");
        enemies= GameObject.FindGameObjectsWithTag("enemyhandler"); 
        for (int i = 0; i < enemies.Length; i++)
        {
            StartCoroutine(enemies[i].gameObject.transform.GetChild(0).gameObject.GetComponent<enemy>().die());
        }
      
        for (int i = 0; i < karakterler.Length; i++)
        {
            StartCoroutine(karakterler[i].gameObject.GetComponent<karakter>().die());
        }
        #endregion

        yield return new WaitForSecondsRealtime(1);

        #region animasyon
        kamera.transform.SetParent(top.transform);
        top.transform.DOMove(new Vector3(silindir2.transform.position.x,top.transform.position.y, silindir2.transform.position.z),3);
        yield return new WaitForSecondsRealtime(3);
        top.transform.DORotate(new Vector3(0,45,0),1);
        yield return new WaitForSecondsRealtime(1);
        top.transform.DOMove(new Vector3(4f, top.transform.position.y, 46.67f), 1);
        yield return new WaitForSecondsRealtime(1);
        kamera.transform.SetParent(null);
        #endregion

        cancontrol = true;
    }
}
