using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject ghost2020;
    public GameObject ghost1920;
    public GameObject player;
    private Transform playerTrans;

    private bool isKeyDown = false;
    private bool isInPresent = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");
        playerTrans = GameObject.Find("Character").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            player.GetComponent<CharacterController>().enabled = false;
            if (isInPresent)
            {
                ghost2020.transform.position = playerTrans.position;
                playerTrans.position = ghost1920.transform.position;
                isInPresent = false;
            }
            else
            {
                ghost1920.transform.position = playerTrans.position;
                playerTrans.position = ghost2020.transform.position;
                isInPresent = true;
            }
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
