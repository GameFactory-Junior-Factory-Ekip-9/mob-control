using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class rotateanimation : MonoBehaviour
{
    public Vector3 ilka��;
    public Vector3 ikincia��;
    [SerializeField] float speed;
    private void Start()
    {
        StartCoroutine(play());
    }
    IEnumerator play()
    {
        transform.DOLocalRotate(ilka��, 1 / speed);
        yield return new WaitForSecondsRealtime(1 / speed);
        transform.DOLocalRotate(ikincia��, 1 / speed);
        yield return new WaitForSecondsRealtime(1 / speed);
        StartCoroutine(play());

    }
}
