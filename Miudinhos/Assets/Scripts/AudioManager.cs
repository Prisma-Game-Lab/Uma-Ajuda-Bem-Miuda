using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public string s;
    private Scene scene;
    private string nameScene;
    void Awake()
    {   


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }   
    }
    //Ativa a musica tema da cena
    void Start()
    {
        scene =  SceneManager.GetActiveScene();
        nameScene = scene.name;

        if(nameScene == "Menu")
        {
            Play("Garden'sTheme");
            if (s == null)
                return;
        }
        else if(nameScene == "Minigame1")
        {
            Play("Garden'sTheme");
            if (s == null)
                return;
        }
        else
        {
            Play("Sink'sTheme");
            if(s == null)
                return;
        }
    }

    public void Play (string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
       s.source.Play();
    }
    
}
