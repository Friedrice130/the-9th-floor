using GLTFast.Schema;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class FlashlightFollowOnGrab_NoRelease : XRGrabInteractable
{
    private Transform playerTransform;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        playerTransform = args.interactorObject.transform;
        gameObject.name = "flashlight_hand";


        transform.SetParent(playerTransform, true);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
    }

    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {

        if (!isSelected)
            return base.IsSelectableBy(interactor);


        return false;
    }

    private void Update()
    {
        if (playerTransform != null)
        {

        }
    }
}
