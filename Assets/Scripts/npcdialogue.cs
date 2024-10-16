using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueUI; 

    void Start()
    {
        
        dialogueUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            dialogueUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("NPC"))
        {
            dialogueUI.SetActive(false);
        }
    }
}

