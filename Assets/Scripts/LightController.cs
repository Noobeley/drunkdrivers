using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light[] roomLights; // Array of lights to control in the room
    public bool isSabotaged = false; // Track sabotage state
    public Image warningImage;
    public GameObject breakerbox;

    void Start()
    {
        warningImage.gameObject.SetActive(false); // Initially hide the warning image
    }

    void Update()
    {
        // Call TurnOffLights() when the room is sabotaged
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
            PlayBreakerBoxSound();
            foreach (Light light in roomLights)
            {
                light.enabled = false; // Turn off each light
            }
            warningImage.gameObject.SetActive(true); // Show the warning image
            Debug.Log("Lights turned off due to sabotage.");
            isSabotaged = false; // Reset sabotage state after turning off lights
        }
    }

    // Reset lights, called by breaker box interaction
    public void ResetLights()
    {
        Debug.Log("Calling reset lights");
        if (!isSabotaged) // Check if the lights need to be reset
        {
            foreach (Light light in roomLights)
            {
                light.enabled = true; // Turn on each light
            }
            warningImage.gameObject.SetActive(false); // Hide the warning image
            Debug.Log("Lights reset by player.");
            StopBreakerBoxSound();
        }
    }

    // Method to trigger sabotage
    public void TriggerSabotage()
    {
        isSabotaged = true; // Set sabotage state to true
        Debug.Log("Sabotage triggered!");
    }

    public void PlayBreakerBoxSound()
    {
        AudioSource audioSource = breakerbox.GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopBreakerBoxSound()
    {
        AudioSource audioSource = breakerbox.GetComponent<AudioSource>();
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}

