using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlotIn : MonoBehaviour
{
    public GameObject objectReference;
    public UnlockDoor animationScript;
    public GameObject parentObject;


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

            other.enabled = false;

            if (animationScript != null)
            {
                animationScript.triggered = true;
                if (parentObject != null)
                    other.transform.parent = parentObject.transform;
                else
                {
                    other.transform.parent = null;
                }
            }
            else
            {
                other.transform.parent = null;
            }
        }

        
    }
}
