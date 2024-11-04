using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Checkbutton : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable;
    private Renderer objectRenderer;
    private Xray xray_script;

    public void Start()
    {
        GameObject scan = GameObject.Find("base scan");
        xray_script = scan.GetComponent<Xray>();
        scan.active = false;
    }
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
        xray_script.DoXray();
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event
        interactable.selectEntered.RemoveListener(OnSelect);
    }
} 