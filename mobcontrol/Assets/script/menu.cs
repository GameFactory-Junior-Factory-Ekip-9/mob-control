using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] GameObject menupart;
    [SerializeField] GameObject startpart;


    public void OpenandCloseMenu()
    {
        menupart.gameObject.SetActive(!menupart.gameObject.activeSelf);
    }
    public void CloseMenu() { menupart.gameObject.SetActive(false); }
    private void Start()
    {
        Time.timeScale = 0;
        startpart.SetActive(true);
    }
    public void StartGame()
    {
        Time.timeScale = 1;
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
