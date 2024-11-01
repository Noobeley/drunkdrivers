using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager Instance { get; private set; }
    public List<GameObject> npcPrefabs;    // List of NPC prefabs
    public Transform spawnPoint;           // Common spawn point for NPCs

    private int currentNPCIndex = 0;       // Tracks the current NPC to spawn
    private GameObject currentNPC;         // Holds a reference to the active NPC

    private void Awake()
    {
        // Ensure only one instance of NPCManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Spawn the first NPC in the list
        SpawnNextNPC();
    }

    public void OnNPCDestroyed()
    {
        // Call this method when an NPC is destroyed to spawn the next one in sequence
        SpawnNextNPC();
    }

    private void SpawnNextNPC()
    {
        // Check if there are more NPCs to spawn
        if (currentNPCIndex < npcPrefabs.Count)
        {
            // Spawn the next NPC prefab in the list
            currentNPC = Instantiate(npcPrefabs[currentNPCIndex], spawnPoint.position, spawnPoint.rotation);
            currentNPCIndex++; // Move to the next NPC in the list
        }
        else
        {
            Debug.Log("All NPCs have been spawned.");
        }
    }
}

