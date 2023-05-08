using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ateşetmeanimasyonu : MonoBehaviour
{
    public GameObject torus;
    public GameObject top;
    public GameObject topunanimasyonobjesi;
   public IEnumerator ateşetmeobjesininanimasyonu()
    {
        GameObject animtop = Instantiate(topunanimasyonobjesi, topunanimasyonobjesi.transform.position,Quaternion.identity);
        
        animtop.transform.localScale =new Vector3(1f,1f,1f)/1.5f;
        animtop.transform.parent=top.transform;
        animtop.transform.DOLocalMoveX(2, 1/top.GetComponent<top>().firerate);
        torus.transform.DOLocalMoveX(1.25f,0.5f/ top.GetComponent<top>().firerate);
        yield return new WaitForSecondsRealtime(0.5f / top.GetComponent<top>().firerate);
        torus.transform.DOLocalMoveX(1.5f, 0.5f / top.GetComponent<top>().firerate);
        yield return new WaitForSecondsRealtime(0.5f / top.GetComponent<top>().firerate);
        Destroy(animtop);
    } 
}
