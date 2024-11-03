using System.Collections;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject[] npcs; // Array of NPC GameObjects
    private int currentNpcIndex = 0;
    private NPCPath currentNPCPath;

    public void StartNPCSequence()
    {
        if (currentNpcIndex == 0) // Start only once
        {
            StartCoroutine(ManageNPCsSequentially());
        }
    }

    private IEnumerator ManageNPCsSequentially()
    {
        while (currentNpcIndex < npcs.Length)
        {
            GameObject currentNPC = npcs[currentNpcIndex];
            currentNPC.SetActive(true); // Activate NPC

            currentNPCPath = currentNPC.GetComponent<NPCPath>();
            if (currentNPCPath == null)
            {
                Debug.LogError("NPCPath component not found on NPC GameObject.");
                yield break;
            }

            currentNPCPath.StartInitialPath();

            // Wait for this NPC to complete the selected path
            while (!currentNPCPath.IsPathCompleted())
            {
                yield return null;
            }

            // Deactivate the NPC and move to the next
            currentNPC.SetActive(false);
            currentNpcIndex++;
        }
    }

    public void ContinueCurrentNPC(int pathNumber)
    {
        if (currentNPCPath != null)
        {
            currentNPCPath.SetPath(pathNumber); // Set the path based on player's selection
        }
    }
}
