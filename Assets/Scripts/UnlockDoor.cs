
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject key;

    private Vector3 radius;
    private bool inRadius;

    void Start()
    {
        radius = new Vector3(4.0f, 0.0f, 5.0f);
        inRadius = false;
    }
    void Update()
    {
        // If key is in radius on door.
        if ((door.transform.position.z - radius.z < key.transform.position.z) && (key.transform.position.x < door.transform.position.x + radius.x) && (key.transform.position.x > door.transform.position.x - radius.x))
        {
            inRadius = true;
        }
    }

    public bool GetInRadius()
    {
        return inRadius;
    }
}