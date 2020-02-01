using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Dropdown dropdownres;
    // Start is called before the first frame update

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        dropdownres.ClearOptions();
        List<string> options = new List<string>();

        int currentRes = 0;
        for(int i = 0; i<resolutions.Length; i++)
        {
            string option = +resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }
        }

        dropdownres.AddOptions(options);
        dropdownres.value = currentRes;
        dropdownres.RefreshShownValue();
    }


    public void SetMainVolume(float volume)
    {
        audioMixer.SetFloat("MainVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }

    public void SetResolution(int resolution)
    {
        Resolution res = resolutions[resolution];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);

        Debug.Log("New Resolution: " + resolution);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}

