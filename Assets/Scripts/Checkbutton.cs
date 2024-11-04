using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Checkbutton : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable;
    private Renderer objectRenderer;
    private Xray xray_script;

    public void Start()
    {
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
        Debug.Log("Starting Xray");
        Xray xray_script = GameObject.Find("Cube.005").GetComponent<Xray>();
        xray_script.DoXray();
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event
        interactable.selectEntered.RemoveListener(OnSelect);
    }
} 