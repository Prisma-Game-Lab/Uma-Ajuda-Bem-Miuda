using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public bool isRising;
    public float speed;
    private Vector3 pos;
    private GameObject player;
    private float currentSpeed;
    private float currentGravity;
    // Start is called before the first frame update
    void Start()
    {
        isRising = true;
        player = GameObject.FindGameObjectWithTag("Player");
        currentSpeed = player.GetComponent<PlayerMove>().playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRising)
        {
            this.transform.Translate(0f, (speed/3) * Time.deltaTime, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerMove>().playerSpeed = currentSpeed / 2;
            player.GetComponent<PlayerMove>().gravityValue = -6f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerMove>().playerSpeed = currentSpeed;
            player.GetComponent<PlayerMove>().gravityValue = -9.81f;

        } else if (other.gameObject.CompareTag("Floor"))
        {
            speed = 0f;
        }
    }
}
