using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
     public string Minigame1;
     public string Minigame2;

    public GameObject panel1;
    public GameObject panel2;
    
    public void StartMinigame1()
    {   
        SceneManager.LoadScene(Minigame1);
    }
    public void  StartMinigame2()
    {
        SceneManager.LoadScene(Minigame2);
    }
    public void OpenOptions()
    {

    }
    public void CloseOptions()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("saindo");
    }

    public void OpenPanel1()
    {
        panel1.SetActive(true);
    }

    public void ClosePanel1()
    {
        panel1.SetActive(false);
    }

    public void OpenPanel2()
    {
        panel2.SetActive(true);
    }

    public void ClosePanel2()
    {
        panel2.SetActive(false);
    }
}


