﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlotIn : MonoBehaviour
{
    public GameObject objectReference;
    public UnlockDoor animationScript;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.name == objectReference.name)
        {
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;
            GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.tag = "Picked";

            if (animationScript != null)
            {
                //other.transform.parent = animationScript.transform;
                other.transform.parent = animationScript.transform.GetChild(1);
                animationScript.triggered = true;
            }
            else
            {
                other.transform.parent = null;
            }
        }
    }
}
