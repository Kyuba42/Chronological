using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    GameObject pickedUpObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if LBM pressed
        if (Input.GetMouseButtonDown(0))
        {
            if (pickedUpObject == null)
            {
                RaycastHit rayHit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rayHit, 6.0f))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayHit.distance, Color.yellow);
                    if (rayHit.collider.gameObject.tag == "PickUp")
                    {
                        pickedUpObject = rayHit.collider.gameObject;
                        rayHit.collider.gameObject.transform.parent = transform;
                        pickedUpObject.GetComponent<Rigidbody>().useGravity = false;
                        pickedUpObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                    }
                }
            }
            else
            {
                pickedUpObject.transform.parent = null;
                pickedUpObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                pickedUpObject.GetComponent<Rigidbody>().useGravity = true;
                pickedUpObject = null;
            }
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
    }
}
