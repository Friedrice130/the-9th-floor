using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightVR : MonoBehaviour
{
    [Header("Assign in Inspector")]
    public Material lens;             // Drag the lens material here
    public Light flashlightLight;     // Drag your Light component here
    public AudioSource audioSource;   // Drag your AudioSource here

    public void LightOn()
    {
        if (audioSource != null)
            audioSource.Play();

        if (lens != null)
            lens.EnableKeyword("_EMISSION");

        if (flashlightLight != null)
            flashlightLight.enabled = true;
    }

    public void LighOff()
    {
        if (audioSource != null)
            audioSource.Play();

        if (lens != null)
            lens.DisableKeyword("_EMISSION");

        if (flashlightLight != null)
            flashlightLight.enabled = false;
    }
}
