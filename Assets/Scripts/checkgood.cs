using UnityEngine;

public class GoodRoomTrigger : MonoBehaviour
{
    [SerializeField] private bool checkGood = true; 

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has an NpcIdentity component
        if (other.GetComponent<NpcIdentity>())
        {
            // Detect if the correct type of NPC enters
            if (other.GetComponent<NpcIdentity>().GoodNPC == checkGood)
            {
                Debug.Log("A Good NPC has entered the correct room.");
            }
            // Detect if the wrong type of NPC enters
            else
            {
                Debug.Log("Warning: A Bad NPC has entered the Good NPC room!");
                TriggerWrongEntryAlert();
            }
        }
    }

    private void TriggerWrongEntryAlert()
    {
        // Logic to handle wrong entry
        Debug.Log("Alert! Wrong NPC in the Good NPC room!");
        // Additional code to handle the wrong entry, e.g., trigger an alarm, penalize the player, etc.
    }
}
