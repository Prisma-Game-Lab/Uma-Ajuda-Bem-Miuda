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
    private PlayerMove move;
    // Start is called before the first frame update
    void Start()
    {
        isRising = true;
        player = GameObject.FindGameObjectWithTag("Player");
        currentSpeed = player.GetComponent<PlayerMove>().playerSpeed;

        move = player.GetComponent<PlayerMove>();
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
            move.playerSpeed = currentSpeed / 2;
            move.gravityValue = -6f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            move.playerSpeed = currentSpeed;
            move.gravityValue = -9.81f;

        } else if (other.gameObject.CompareTag("Floor"))
        {
            isRising = false;
        }
    }
}
