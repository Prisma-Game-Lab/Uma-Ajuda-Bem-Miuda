using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    [HideInInspector]public bool isCarrying;
    [HideInInspector]public GameObject objCarried;

    private void Start()
    {
        isCarrying = false;
    }
}
