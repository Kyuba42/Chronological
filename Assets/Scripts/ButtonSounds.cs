using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource myfx;
    public AudioClip hover;
    public AudioClip click;

    public void HoverSound()
    {
        myfx.PlayOneShot(hover);
    }

    public void ClickSound()
    {
        myfx.PlayOneShot(click);
    }

}
