using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    [SerializeField] private List<Vector3> positionList = new List<Vector3>();
    [SerializeField] private List<GameObject> objectList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Randomize();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Randomize()
    {
        foreach(GameObject item in objectList)
        {
            int index = Random.Range(0, positionList.Count);
            Vector3 spawnPosition = positionList[index];
            Instantiate(item, spawnPosition, Quaternion.identity);
            positionList.Remove(positionList[index]);
        }
    }
}
