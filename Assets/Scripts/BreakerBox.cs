using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BreakerBox : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor rightInteractor; // Assign your right interactor (Ray or Direct) here in the Inspector
    public float holdTime = 3f; // Time in seconds to hold the trigger

    private bool isHoveringOverObject = false;
    private float triggerHoldDuration = 0f;

    void OnEnable()
    {
        // Register interactor events
        rightInteractor.hoverEntered.AddListener(OnHoverEntered);
        rightInteractor.hoverExited.AddListener(OnHoverExited);
        Debug.Log("Interactor events registered.");
    }

    void OnDisable()
    {
        // Unregister interactor events
        rightInteractor.hoverEntered.RemoveListener(OnHoverEntered);
        rightInteractor.hoverExited.RemoveListener(OnHoverExited);
        Debug.Log("Interactor events unregistered.");
    }

    void Update()
    {
        if (isHoveringOverObject && IsTriggerHeld())
        {
            triggerHoldDuration += Time.deltaTime;
            Debug.Log($"Trigger held for {triggerHoldDuration} seconds.");
            if (triggerHoldDuration >= holdTime)
            {
                TriggerAction();
                triggerHoldDuration = 0f; // Reset after action is triggered
            }
        }
        else
        {
            triggerHoldDuration = 0f; // Reset if trigger is released or not hovering
        }
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        // Check if the object being hovered over is this object
        if (args.interactableObject.transform == transform)
        {
            isHoveringOverObject = true;
            Debug.Log("Hover entered.");
        }
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        // Reset hovering flag when no longer pointing at this object
        if (args.interactableObject.transform == transform)
        {
            isHoveringOverObject = false;
            Debug.Log("Hover exited.");
        }
    }

    private bool IsTriggerHeld()
    {
        // Check if the right interactor has any selected interactables
        if (rightInteractor.interactablesSelected.Count > 0)
        {
            // Get the input device from the interactor
            var xrController = rightInteractor.GetComponent<XRController>();
            if (xrController != null)
            {
                if (xrController.inputDevice.isValid)
                {
                    if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed))
                    {
                        Debug.Log($"Trigger is pressed: {isPressed}");
                        return isPressed;
                    }
                }
            }
        }
        return false;
    }

    private void TriggerAction()
    {
        // Placeholder for the method you want to run after holding the trigger
        Debug.Log("Trigger action called after holding for 3 seconds");
    }
}
