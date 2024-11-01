using UnityEngine;

public class GoodRoomTrigger : MonoBehaviour
{
    [SerializeField] private bool checkGood = true; // Set this room to expect Good NPCs if true
    private LightController lightController;

    public void Start()
    {
        GameObject triggerBox = GameObject.Find("wall (4)");
        lightController = triggerBox.GetComponent<LightController>();
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
                TriggerWrongEntryAlert();
            }
        }
    }

    public void TriggerWrongEntryAlert()
    {
        Debug.Log("Alert! Wrong NPC in the Good NPC room!"); // Step 1: Check alert is triggered
    
        if (lightController != null)
        {
            Debug.Log("LightController is assigned and will trigger TurnOffLights."); // Step 2: Confirm controller exists
            lightController.TurnOffLights();
        }
        else
        {
            Debug.LogWarning("LightController is not assigned in GoodRoomTrigger. Please assign it in the Inspector."); // Step 3: Warning for missing assignment
        }
    }
}
