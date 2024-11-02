using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager Instance { get; private set; }
    public List<GameObject> npcPrefabs; // List of NPC prefabs to activate one at a time
    public Transform spawnPoint;         // Common spawn point for NPCs

    private int currentNPCIndex = 0;     // Tracks the current NPC to activate

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // Deactivate all NPCs at the start
        foreach (GameObject npc in npcPrefabs)
        {
            npc.SetActive(false);
        }
    }

    private void Update()
    {
        // Activate the next NPC when the "O" key is pressed, but only if the current index is valid
        if (Input.GetKeyDown(KeyCode.O) && currentNPCIndex < npcPrefabs.Count)
        {
            ActivateNextNPC();
        }
    }

    public void OnNPCDeactivated()
    {
        // Notify that the current NPC has completed its path and activate the next one
        Debug.Log($"NPC {currentNPCIndex + 1} completed its path. Activating the next NPC...");
        ActivateNextNPC();
    }

    private void ActivateNextNPC()
    {
        // Ensure there are more NPCs to activate
        if (currentNPCIndex < npcPrefabs.Count)
        {
            GameObject currentNPC = npcPrefabs[currentNPCIndex];

            if (currentNPC != null)
            {
                // Set the NPC's position to the spawn point and activate it
                currentNPC.transform.position = spawnPoint.position; 
                currentNPC.SetActive(true);
                Debug.Log($"Activating NPC {currentNPCIndex + 1}/{npcPrefabs.Count} at spawn point.");

                // Reset the path-following script on the new NPC
                NPCPath npcPathScript = currentNPC.GetComponent<NPCPath>();
                if (npcPathScript != null)
                {
                    npcPathScript.ResetPath();
                }
                else
                {
                    Debug.LogError("NPCManager: NPC does not have an NPCPath component.");
                }

                currentNPCIndex++; // Move to the next NPC in the list
            }
        }
        else
        {
            Debug.Log("All NPCs have completed their paths.");
        }
    }
}
