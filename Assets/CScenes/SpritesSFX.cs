using UnityEngine;

public class SpritesSFX : MonoBehaviour
{
    public AudioClip sound;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(AudioSource source)
    {
        if (sound != null && source != null)
        {
                source.PlayOneShot(sound);
        }
    }
}
