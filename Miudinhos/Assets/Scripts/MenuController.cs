using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
     public string Minigame1;
     public string Minigame2;
    
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
}


