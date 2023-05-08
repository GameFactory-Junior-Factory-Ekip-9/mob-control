using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class rotateanimation : MonoBehaviour
{
    public Vector3 ilkaçý;
    public Vector3 ikinciaçý;
    [SerializeField] float speed;
    private void Start()
    {
        StartCoroutine(play());
    }
    IEnumerator play()
    {
        transform.DOLocalRotate(ilkaçý, 1 / speed);
        yield return new WaitForSecondsRealtime(1 / speed);
        transform.DOLocalRotate(ikinciaçý, 1 / speed);
        yield return new WaitForSecondsRealtime(1 / speed);
        StartCoroutine(play());

    }
}
