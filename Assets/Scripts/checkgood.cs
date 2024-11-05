using UnityEngine;

public class CheckGood : MonoBehaviour
{
    [SerializeField] private bool checkGood = false; // Set this room to expect Good NPCs if true
    private LightController lightController;

    public void Start()
    {
        GameObject triggerBox = GameObject.Find("wall (4)"); // Find the GameObject with the LightController
        lightController = triggerBox.GetComponent<LightController>(); // Get the LightController component
    }

    public void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has an NpcIdentity component
        NpcIdentity npc = other.GetComponent<NpcIdentity>();
        if (npc)
        {
            // Check if the NPC type matches the room's requirement
            if (npc.GoodNPC == checkGood)
            {
                Debug.Log("A Good NPC has entered the correct room.");
            }
            else
            {
                Debug.Log("Warning: A Bad NPC has entered the Good NPC room!");
                TriggerWrongEntryAlert(); // Call the alert method for wrong NPC entry
            }
        }
    }

    public void TriggerWrongEntryAlert()
    {
        Debug.Log("Alert! Wrong NPC in the Good NPC room!"); // Log alert for wrong entry
    
        if (lightController != null)
        {
            Debug.Log("LightController is assigned and will trigger TurnOffLights."); // Confirm controller exists
            lightController.TriggerSabotage(); // Call the method to trigger sabotage
        }
        else
        {
            Debug.LogWarning("LightController is not assigned in CheckGood. Please assign it in the Inspector."); // Warning for missing assignment
        }
    }
}

