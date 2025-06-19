using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio : MonoBehaviour
{
    public GameObject audio;
    public Collider collision;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audio.SetActive(true);
            collision.enabled = false;
        }
    }
}
