using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Xray : MonoBehaviour
{
    // References to each sprite as GameObjects
    public GameObject scan, eye, neuro, hearing, arm, blood, heart;
    public GameObject redeye, neurored, hearingred, armred, bloodgreen, heartgreen;
    
    private GameObject[] greyElements;

    public void Start()
    {
        // Assign each sprite GameObject to the greyElements array for easy management
        greyElements = new GameObject[] { eye, neuro, hearing, arm, blood, heart };
        
        // Disable initial visibility if required
        SetXrayState(false, false, false, false, false, false, false, false, false, false, false, false, false);

        // Set up interaction callbacks for each grey sprite
        SetupInteractions();
    }

    // Setup interaction callbacks for each grey element
    private void SetupInteractions()
    {
        foreach (GameObject element in greyElements)
        {
            if (element != null)
            {
                UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable = element.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
                if (interactable == null)
                {
                    Debug.LogWarning($"{element.name} is missing XRBaseInteractable component.");
                    continue;
                }

                // Add the event listener for the 'Select' action, triggered when the object is clicked
                interactable.selectEntered.AddListener((interactor) => DestroyElement(element));
            }
        }
    }

    // Method to destroy a specific element
    private void DestroyElement(GameObject element)
    {
        if (element != null)
        {
            Destroy(element);
        }
    }

    // Helper method to set the enabled state of all SpriteRenderers
    private void SetXrayState(bool scan, bool eye, bool neuro, bool hearing, bool arm, bool blood, bool heart,
                              bool redeye, bool neurored, bool hearingred, bool armred, bool bloodgreen, bool heartgreen)
    {
        if (this.scan != null) this.scan.SetActive(scan);
        if (this.eye != null) this.eye.SetActive(eye);
        if (this.neuro != null) this.neuro.SetActive(neuro);
        if (this.hearing != null) this.hearing.SetActive(hearing);
        if (this.arm != null) this.arm.SetActive(arm);
        if (this.blood != null) this.blood.SetActive(blood);
        if (this.heart != null) this.heart.SetActive(heart);
        if (this.redeye != null) this.redeye.SetActive(redeye);
        if (this.neurored != null) this.neurored.SetActive(neurored);
        if (this.hearingred != null) this.hearingred.SetActive(hearingred);
        if (this.armred != null) this.armred.SetActive(armred);
        if (this.bloodgreen != null) this.bloodgreen.SetActive(bloodgreen);
        if (this.heartgreen != null) this.heartgreen.SetActive(heartgreen);
    }

    // Method to control which sprites are active based on the NPCTrigger ID
    public void DoXray()
    {
        NPCTrigger npcTriggerScript = GameObject.Find("TriggerCube")?.GetComponent<NPCTrigger>();
        if (npcTriggerScript == null) return;

        // Adjust the enabled state of SpriteRenderers based on the NPCTrigger ID
        switch (npcTriggerScript.ID)
        {
            case 0:
                SetXrayState(true, true, false, false, true, false, false, true, false, false, true, false, false);
                break;
            case 1:
                SetXrayState(true, false, false, true, false, false, true, false, false, true, false, false, true);
                break;
            case 2:
                SetXrayState(true, false, false, false, false, false, false, false, false, false, false, false, false);
                break;
            case 3:
                SetXrayState(true, false, false, false, false, true, false, false, false, false, false, true, false);
                break;
            case 4:
                SetXrayState(true, false, true, false, false, false, false, false, true, false, false, false, false);
                break;
            case 5:
                SetXrayState(false, false, false, false, false, false, false, false, false, false, false, false, false);
                break;
        }
    }
}
