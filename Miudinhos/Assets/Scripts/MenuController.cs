using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
     public string Minigame1;
     public string Minigame2;
     public string Configuracoes;
     public string ToMenu;
     public AudioSource audioButton;

    public GameObject panel1;
    public GameObject panel2;
    
    public void PlayButton()
    {
        audioButton.Play();
    }

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
        SceneManager.LoadScene(Configuracoes);
    }
    public void CloseOptions()
    {
        SceneManager.LoadScene(ToMenu);
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


