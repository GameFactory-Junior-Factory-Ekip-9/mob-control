using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class çarpmaduvarıanimasyonu : MonoBehaviour
{
    public Vector3 ilkkoordinat;
    public Vector3 ikincikoordinat;
    [SerializeField] float speed;
    private void Start()
    {
        StartCoroutine(play());
    }
    public IEnumerator play()
    {
        transform.DOLocalMove(ikincikoordinat,1/speed);
        yield return new WaitForSecondsRealtime(1/speed);
        transform.DOLocalMove(ilkkoordinat, 1 / speed);
        yield return new WaitForSecondsRealtime(1 / speed);
        StartCoroutine(play());
    }
}
