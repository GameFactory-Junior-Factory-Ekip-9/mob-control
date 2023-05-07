using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] GameObject menupart;
    [SerializeField] GameObject startpart;
    public GameObject levelcontrol;
    public void OpenandCloseMenu()
    {
        menupart.gameObject.SetActive(!menupart.gameObject.activeSelf);
    }
    public void CloseMenu() { menupart.gameObject.SetActive(false); }
    private void Start()
    {
        levelcontrol.GetComponent<levelcontrol>().cancontrol = false;
        startpart.SetActive(true);
    }
    public void StartGame()
    {
        levelcontrol.GetComponent<levelcontrol>().cancontrol = true;
        startpart.SetActive(false);
    }

    public void RestarttheLevel()
    {
        SceneManager.LoadScene("lvl1");
    }
    public void NexttheLevel()
    {
        SceneManager.LoadScene("lvl2");
    }
}
