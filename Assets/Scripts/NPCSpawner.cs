using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NPCSpawner : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable;
    public NPCManager npcManager; // Reference to the NPCManager to spawn NPCs

    private void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        
        // Subscribe to the select event
        interactable.selectEntered.AddListener(OnSelect);
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        // When the box is clicked, spawn the first NPC
        npcManager.ActivateNextNPC();
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to prevent memory leaks
        interactable.selectEntered.RemoveListener(OnSelect);
    }
}
