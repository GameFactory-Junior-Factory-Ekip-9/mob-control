using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class losing : MonoBehaviour
{
    public GameObject losescreen;
    public GameObject levelcontrol;
    public GameObject[] karakter;
    public GameObject[] enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {

            StartCoroutine(lose());
        }
    }
    IEnumerator lose()
    {
        levelcontrol.GetComponent<levelcontrol>().cancontrol = false;
        enemy = GameObject.FindGameObjectsWithTag("enemyhandler");
        karakter = GameObject.FindGameObjectsWithTag("dostkarakterhandler");
        for (int i = 0; i < karakter.Length; i++)
        {
            karakter[i].GetComponent<karakter>().speed = 0;

        }
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<enemy>().speed = 0;

        }
        yield return new WaitForSecondsRealtime(1);
        losescreen.SetActive(true);



    }
}
