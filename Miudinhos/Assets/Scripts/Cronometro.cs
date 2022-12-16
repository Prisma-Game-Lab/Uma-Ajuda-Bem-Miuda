using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour
{
    public Image timer_text;
    public Image go;
    private bool firstfivesecs;

    public float timer;

    [Header("Tempo para as medalhas (segundos)")]
    public int timeGoldenMedal;
    public int timeSilverMedal;
    public int timeBronzeMedal;
    public GameObject GoldenMedal;
    public GameObject SilverMedal;
    public GameObject BronzeMedal;

    public GameObject EndPanel;
    public GameObject pausePanel;

    private int minigame1_placed;
    private float total_time;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        total_time = 0f;
        timer_text.gameObject.SetActive(false);
        Time.timeScale = 1f;
        firstfivesecs = true;

        minigame1_placed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        total_time += Time.deltaTime;
        setTimer();
        CheckMinigame1();
        if (firstfivesecs && timer <= 3)
        {
            go.gameObject.SetActive(true);
        }
    }

    void CheckMedal()
    {
        if (total_time < timeGoldenMedal) {
            GoldenMedal.SetActive(true);
        } else if (total_time < timeSilverMedal) {
            SilverMedal.SetActive(true);
        } else {
            BronzeMedal.SetActive(true);
        }
    }

    private void setTimer()
    {
        if (timer >= 60)
        {
            timer_text.gameObject.SetActive(true);
            timer = 0f;
        }
        else if (timer >= 5)
        {
            timer_text.gameObject.SetActive(false);
            go.gameObject.SetActive(false);
            firstfivesecs = false;
        }
    }

    public void AddMinigame1()
    {
        minigame1_placed += 1;
    }

    private void CheckMinigame1()
    {
        if (minigame1_placed >= 5)
        {
            EndPanel.SetActive(true);
            Time.timeScale = 0f;
            CheckMedal();
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void Unpause()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
