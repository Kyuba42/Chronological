using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (other.gameObject.name == "Character")
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
