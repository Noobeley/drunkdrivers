using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light[] roomLights; // Array of lights to control in the room
    public bool isSabotaged  = false; // Track sabotage state
    public Image warningImage;

    void Start()
    {
        warningImage.gameObject.SetActive(false);
    }
    void Update()
    {
        if (isSabotaged)
        {
            TurnOffLights();
        }
    }

    // Turn off lights to simulate sabotage
    public void TurnOffLights()
    {
        if (isSabotaged)
        {
            foreach (Light light in roomLights)
            {
                light.enabled = false;
                warningImage.gameObject.SetActive(true);
            }
            Debug.Log("Lights turned off due to sabotage.");
            isSabotaged = false;
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
                warningImage.gameObject.SetActive(false);
            }
            Debug.Log("Lights reset by player.");
            isSabotaged = false;
        }
    }
}

