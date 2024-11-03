using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PathActivator : MonoBehaviour
{
    public NPCPath npcPath; // Reference to the NPCPath component
    public int pathToActivate; // Specify which path to activate (1 to 4)

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelect);
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        if (npcPath != null)
        {
            npcPath.ActivatePath(pathToActivate);
        }
    }

    private void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnSelect);
    }
}
