using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    private GameObject player;
    private GameObject placedObj;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.GetComponent<PlayerCarry>().isCarrying)
            {
                placedObj = player.GetComponent<PlayerCarry>().objCarried;
                player.GetComponent<PlayerCarry>().objCarried = null;
                player.GetComponent<PlayerCarry>().isCarrying = false;
                placedObj.GetComponent<CollectObject>().pickedUp = false;

                Vector3 offset = new Vector3(0f, 0.5f, 0f);
                placedObj.gameObject.transform.position = this.gameObject.transform.position + offset;

                this.gameObject.GetComponent<SphereCollider>().enabled = false;
            }

        }
    }
}
