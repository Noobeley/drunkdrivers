using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NPCSpawner : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable;
    private NPCManager npcManager;

    void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();

        // Set up the event listener for VR interaction
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelect);
        }
        else
        {
            Debug.LogError("XRSimpleInteractable component not found on this GameObject.");
        }

        // Get a reference to the NPCManager in the scene
        npcManager = FindObjectOfType<NPCManager>();
        if (npcManager == null)
        {
            Debug.LogError("NPCManager component not found in the scene.");
        }
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        // Start the NPC sequence when the VR interactable is selected
        if (npcManager != null)
        {
            npcManager.StartNPCSequence();
        }
    }

    private void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelect);
        }
    }
}

