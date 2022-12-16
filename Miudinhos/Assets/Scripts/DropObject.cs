using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    private GameObject player;
    private GameObject placedObj;
    private GameObject gameManager;
    private Cronometro cronom;
    public string objectTag;
    private PlayerCarry carryStatus;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        carryStatus = player.GetComponent<PlayerCarry>();

        gameManager = GameObject.FindGameObjectWithTag("GameController");
        cronom = gameManager.GetComponent<Cronometro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (carryStatus.isCarrying)
            {
                if (carryStatus.objCarried.CompareTag(objectTag))
                {
                    placedObj = carryStatus.objCarried;
                    carryStatus.objCarried = null;
                    carryStatus.isCarrying = false;
                    placedObj.GetComponent<CollectObject>().pickedUp = false;

                    Vector3 offset = new Vector3(0f, 0.5f, 0f);
                    placedObj.gameObject.transform.position = this.gameObject.transform.position + offset;

                    this.gameObject.GetComponent<SphereCollider>().enabled = false;

                    cronom.AddMinigame1();
                    
                    FindObjectOfType<AudioManager>().Play("Drop");
                }
            }

        }
    }
}
