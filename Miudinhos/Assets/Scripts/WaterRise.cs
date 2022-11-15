using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public bool isRising;
    public float speed;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        isRising = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRising)
        {
            this.transform.Translate(0f, (speed/3) * Time.deltaTime, 0f);
        }
    }
}
