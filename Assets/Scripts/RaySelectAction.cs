using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RaySelectAction : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable;
    private Renderer objectRenderer;

    private void Awake()
    {
        // Get components
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        objectRenderer = GetComponent<Renderer>();

        // Subscribe to select event
        interactable.selectEntered.AddListener(OnSelect);
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        // Example action: Change the color to yellow
        objectRenderer.material.color = Color.yellow;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event
        interactable.selectEntered.RemoveListener(OnSelect);
    }
}  
