using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public Text timer_text;
    [HideInInspector]public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timer_text.text = string.Format("{0:00}:{1:00}", Mathf.Floor(timer / 60), timer%60);
    }
}
