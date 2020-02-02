using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{

    private float timer = 5.0f;
    private bool timeStart = false;
    public GameObject UI;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            timeStart = true;
        }
    }

    private void Update()
    {
        if (timeStart)
        {
            timer -= Time.deltaTime;
            Debug.Log("Timer: " + timer);
            UI.GetComponent<WonUI>().OpenEndUI();
        }

        if (timer < 0)
        {
            UI.GetComponent<WonUI>().CloseEndUI();
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
