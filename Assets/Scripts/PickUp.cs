using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Header("Material")]
    public Material outlineMaterialRef;
    [Header("Animations")]
    public Animator playerAnimatior = null;

    private GameObject pickedUpObject;
    private Material[] objectMaterials;
    private bool holdItem;




    // Start is called before the first frame update
    void Start()
    {
        holdItem = false;
    }

    // Update is called once per frame
    void Update()
    { 

        RaycastHit rayHit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rayHit, 10.0f))
        {
            if (holdItem == false && pickedUpObject != null)
            {
                pickedUpObject.transform.parent = null;
                pickedUpObject.GetComponent<MeshRenderer>().material = pickedUpObject.GetComponent<MeshRenderer>().materials[1];
                pickedUpObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                pickedUpObject.GetComponent<Rigidbody>().useGravity = true;
                pickedUpObject = null;
            }

            // Object is a PickUp
            if (rayHit.collider.gameObject.tag == "PickUp")
            {
                // Turn off outline if looking at another PickUp object
                if (pickedUpObject != null && rayHit.collider.gameObject != pickedUpObject)
                {
                    playerAnimatior.SetBool("grabbing", false);
                    pickedUpObject.GetComponent<MeshRenderer>().material = pickedUpObject.GetComponent<MeshRenderer>().materials[1];
                }

                // Grab Object that collided with the ray and apply outline
                pickedUpObject = rayHit.collider.gameObject;
                pickedUpObject.GetComponent<MeshRenderer>().material = outlineMaterialRef;

                if (Input.GetMouseButtonDown(0))
                {

                    if (!holdItem)
                    {
                        holdItem = true;
                        pickedUpObject.GetComponent<Rigidbody>().useGravity = false;
                        pickedUpObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                        rayHit.collider.gameObject.transform.parent = transform;
                    }
                    else
                    {
                        holdItem = false;
                    }
                }
            }
            else
            {
                // Turn off outline if looking at other object than previous pickUp
                if (pickedUpObject != null)
                {
                    pickedUpObject.GetComponent<MeshRenderer>().material = pickedUpObject.GetComponent<MeshRenderer>().materials[1];
                }
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
        }
    }
}