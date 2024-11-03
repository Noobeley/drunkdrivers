using System.Collections;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject[] npcs; // Array of NPC prefabs
    private int currentNPCIndex = 0; // Index of the current NPC
    private NPCPath currentNPCPath; // Reference to the current NPC's path

    private void Start()
    {
        // Deactivate all NPCs at the start
        foreach (GameObject npc in npcs)
        {
            npc.SetActive(false);
        }
    }

    public void ActivateNextNPC()
    {
        if (currentNPCIndex < npcs.Length)
        {
            // Activate the current NPC
            GameObject npc = npcs[currentNPCIndex];
            npc.SetActive(true);

            // Get the NPCPath component and set up the NPC's movement
            currentNPCPath = npc.GetComponent<NPCPath>();
            if (currentNPCPath != null)
            {
                currentNPCPath.enabled = true; // Ensure the path component is enabled
                currentNPCPath.ResetPath(); // Reset the path to the beginning
            }

            currentNPCIndex++; // Move to the next NPC index
        }
    }

    private void Update()
    {
        // Check if the current NPC's path is completed
        if (currentNPCPath != null && currentNPCPath.IsPathCompleted())
        {
            // Deactivate the current NPC and activate the next one
            currentNPCPath.gameObject.SetActive(false); // Deactivate the current NPC
            ActivateNextNPC(); // Activate the next NPC
        }
    }
}
