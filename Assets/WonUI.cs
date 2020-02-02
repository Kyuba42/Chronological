using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonUI : MonoBehaviour
{
    public GameObject EndUI;

    public void OpenEndUI()
    {
        Debug.Log("OpenUI");
        EndUI.SetActive(true);
    }
    public void CloseEndUI()
    {
        EndUI.SetActive(false);
    }
}
