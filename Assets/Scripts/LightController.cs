using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light[] roomLights; // Array of lights to control in the room
    public bool isSabotaged { get; private set; } = false; // Track sabotage state

    // Turn off lights to simulate sabotage
    public void TurnOffLights()
    {
        if (!isSabotaged)
        {
            foreach (Light light in roomLights)
            {
                light.enabled = false;
            }
            Debug.Log("Lights turned off due to sabotage.");
            isSabotaged = true;
        }
    }

    // Reset lights, called by breaker box interaction
    public void ResetLights()
    {
        Debug.Log("Calling reset lights");
        if (isSabotaged)
        {
            foreach (Light light in roomLights)
            {
                light.enabled = true;
            }
            Debug.Log("Lights reset by player.");
            isSabotaged = false;
        }
    }
}

