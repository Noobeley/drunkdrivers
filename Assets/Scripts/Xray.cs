using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Xray : MonoBehaviour
{
    public void Start()
    {
        SpriteRenderer scan = GameObject.Find("base scan").GetComponent<SpriteRenderer>();
        SpriteRenderer eye = GameObject.Find("eyebadgrey").GetComponent<SpriteRenderer>();
        SpriteRenderer neuro = GameObject.Find("neurobadgrey").GetComponent<SpriteRenderer>();
        SpriteRenderer hearing = GameObject.Find("hearingbadgrey").GetComponent<SpriteRenderer>();
        SpriteRenderer arm = GameObject.Find("armexbadgrey").GetComponent<SpriteRenderer>();
        SpriteRenderer blood = GameObject.Find("bloodpumpgrey").GetComponent<SpriteRenderer>();
        SpriteRenderer heart = GameObject.Find("heart goodgrey").GetComponent<SpriteRenderer>();

        scan.enabled = false;
        eye.enabled = false;
        neuro.enabled = false;
        hearing.enabled = false;
        arm.enabled = false;
        blood.enabled = false;
        heart.enabled = false;
    }

    public void DoXray()
    {
        Debug.Log("Doing Xray");
        SpriteRenderer scan = GameObject.Find("base scan").GetComponent<SpriteRenderer>();
        SpriteRenderer eye = GameObject.Find("eyebadgrey").GetComponent<SpriteRenderer>();
        SpriteRenderer neuro = GameObject.Find("neurobadgrey").GetComponent<SpriteRenderer>();
        SpriteRenderer hearing = GameObject.Find("hearingbadgrey").GetComponent<SpriteRenderer>();
        SpriteRenderer arm = GameObject.Find("armexbadgrey").GetComponent<SpriteRenderer>();
        SpriteRenderer blood = GameObject.Find("bloodpumpgrey").GetComponent<SpriteRenderer>();
        SpriteRenderer heart = GameObject.Find("heart goodgrey").GetComponent<SpriteRenderer>();

        NPCTrigger npcTriggerScript = GameObject.Find("TriggerCube").GetComponent<NPCTrigger>();
        if (npcTriggerScript.ID == 0)
        {
            scan.enabled = true;
            eye.enabled = false;
            neuro.enabled = true;
            hearing.enabled = false;
            arm.enabled = true;
            blood.enabled = false;
            heart.enabled = false;
        }
        if (npcTriggerScript.ID == 1)
        {
            scan.enabled = true;
            eye.enabled = false;
            neuro.enabled = false;
            hearing.enabled = false;
            arm.enabled = false;
            blood.enabled = false;
            heart.enabled = false;
        }
        if (npcTriggerScript.ID == 2)
        {
            scan.enabled = false;
            eye.enabled = false;
            neuro.enabled = false;
            hearing.enabled = false;
            arm.enabled = false;
            blood.enabled = false;
            heart.enabled = false;
        }
        if (npcTriggerScript.ID == 3)
        {
            scan.enabled = false;
            eye.enabled = false;
            neuro.enabled = false;
            hearing.enabled = false;
            arm.enabled = false;
            blood.enabled = false;
            heart.enabled = false;
        }
        if (npcTriggerScript.ID == 4)
        {
            scan.enabled = false;
            eye.enabled = false;
            neuro.enabled = false;
            hearing.enabled = false;
            arm.enabled = false;
            blood.enabled = false;
            heart.enabled = false;
        }
        if (npcTriggerScript.ID == 5)
        {
            scan.enabled = false;
            eye.enabled = false;
            neuro.enabled = false;
            hearing.enabled = false;
            arm.enabled = false;
            blood.enabled = false;
            heart.enabled = false;
        }
    }
}
