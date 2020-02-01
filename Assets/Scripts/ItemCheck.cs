using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheck : MonoBehaviour
{
    public GameObject pickUp2020;
    public GameObject pickUp1920;

    private List<GameObject> obj2020;
    private List<GameObject> obj1920;

    private bool gameComplete;

    private void Awake()
    {

        
    }

    void Start()
    {
        obj2020 = new List<GameObject>();
        obj1920 = new List<GameObject>();

        gameComplete = false;

        pickUp2020.SetActive(true);
        pickUp1920.SetActive(true);

        for (int i = 0; i < pickUp2020.transform.childCount; i++)
        {
            obj2020.Add(pickUp2020.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < pickUp1920.transform.childCount; i++)
        {
            obj1920.Add(pickUp1920.transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        for (int i = 0; i < obj1920.Count; i++)
        {
            // If 2020 object is not within 2020 room boundaries, continue.
            if (!(obj1920[i].transform.position.z > 50 && obj1920[i].transform.position.z < 100))
            {
                break;
            }
            else
            {
                for (int j = 0; j < obj2020.Count; j++)
                {
                    // If 1920 object is not within 1920 room boundaries, continue.
                    if (!(obj2020[j].transform.position.z > -25 && obj2020[j].transform.position.z < 25))
                    {
                        break;
                    }
                    // Every object is in correct order.
                    else
                    {
                        gameComplete = true;
                    }
                }
            }
        }
    }
}