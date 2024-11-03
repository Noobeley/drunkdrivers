using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PathActivator : MonoBehaviour
{
    public int pathNumber; // Set this in the Inspector for each object (2 for Path 2, 3 for Path 3)
    private NPCManager npcManager;

    private void Awake()
    {
        npcManager = FindObjectOfType<NPCManager>();
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelectEntered);
        }
        else
        {
            Debug.LogError("XRSimpleInteractable component missing.");
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        npcManager.ContinueCurrentNPC(pathNumber); // Continue the current NPC on the chosen path
    }
}
