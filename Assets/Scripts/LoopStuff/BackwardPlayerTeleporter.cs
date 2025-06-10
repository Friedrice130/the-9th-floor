using UnityEngine;

public class BackwardPlayerTeleporter : MonoBehaviour
{
    public Transform TeleportZoneObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Teleport player as usual
            Vector3 localOffset = transform.InverseTransformPoint(other.transform.position);
            Quaternion relativeRotation = TeleportZoneObject.rotation * Quaternion.Inverse(transform.rotation);

            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;
                other.transform.position = TeleportZoneObject.TransformPoint(localOffset);
                other.transform.rotation = relativeRotation * other.transform.rotation;
                cc.enabled = true;
            }

            // Tell GameManager about backward trigger, so it decides what to do
            GameManager.Instance.OnBackwardTrigger();
        }
    }

}