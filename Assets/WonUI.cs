using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonUI : MonoBehaviour
{
    public GameObject EndUI;
    public GameObject StaminaBar;

    public void OpenEndUI()
    {
        Debug.Log("OpenUI");
        EndUI.SetActive(true);
        StaminaBar.SetActive(false);
    }
    public void CloseEndUI()
    {
        EndUI.SetActive(false);
    }
}
