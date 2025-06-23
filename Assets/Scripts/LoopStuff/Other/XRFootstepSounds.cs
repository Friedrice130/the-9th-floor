using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRFootstepSounds : MonoBehaviour
{
    public AudioSource footstepsWalk;
    public InputActionProperty moveAction; // Vector2 from joystick/thumbstick

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        bool isMoving = moveInput.magnitude > 0.1f;

        if (isMoving)
        {
            if (!footstepsWalk.isPlaying)
            {
                footstepsWalk.Play();
                Debug.Log("Playing walking footsteps");
            }
        }
        else
        {
            if (footstepsWalk.isPlaying)
            {
                footstepsWalk.Stop();
                Debug.Log("Stopping walking footsteps");
            }
        }
    }
}
