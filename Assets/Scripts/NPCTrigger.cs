using UnityEngine;
public class NPCTrigger : MonoBehaviour
{
    // Array of GameObjects representing the cubes to show
    public GameObject[] cubes;
    public float ID;

    // Hide all cubes initially
    void Start()
    {
        HideAllCubes();
    }

    void HideAllCubes()
    {
        foreach (GameObject cube in cubes)
        {
            cube.SetActive(false); // Hide all cubes initially
        }
    }

    // Trigger detection for NPC entering the collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the object has an NPC script
        NpcIdentity npc = other.GetComponent<NpcIdentity>();
        if (npc != null)
        {
            Debug.Log("NPC " + npc.npcID + " entered the collider.");

            // Show the correct cube based on NPC's ID
            ShowCorrectCube(npc.npcID);
            ID = npc.npcID;
        }
    }

    void ShowCorrectCube(int npcID)
    {
        HideAllCubes(); // Hide all cubes first

        // Assuming NPC ID corresponds to the index of the cube array
        if (npcID >= 0 && npcID < cubes.Length)
        {
            cubes[npcID].SetActive(true); // Show the correct cube
        }
        else
        {
            Debug.LogWarning("NPC ID is out of bounds of the cubes array.");
        }
    }
}
