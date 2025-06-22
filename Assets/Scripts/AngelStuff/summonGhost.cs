using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonGhost : MonoBehaviour
{
    public GameObject ghost;
    public Collider collision;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ghost.SetActive(true);
            collision.enabled = false;
        }
    }
}
