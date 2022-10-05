using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    public bool pickedUp;
    private Vector3 offset;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = new Vector3(0f, 2f, 0f);
        pickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
            this.transform.position = player.transform.position + offset;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!player.GetComponent<PlayerCarry>().isCarrying)
            {
                pickedUp = true;
                player.GetComponent<PlayerCarry>().isCarrying = true;
                player.GetComponent<PlayerCarry>().objCarried = this.gameObject;
            }

            this.gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }
}
