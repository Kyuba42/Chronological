using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{

    public AudioMixer MainMixer;

    public AudioMixer SFXMixer;
    public AudioMixer MusicMixer;

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
        MainMixer.SetFloat("MainVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        SFXMixer.SetFloat("SFXVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        MusicMixer.SetFloat("MusicVolume", volume);
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

