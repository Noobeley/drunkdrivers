using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RaycastBoxColliderWithLoadAnimation : MonoBehaviour
{
    [SerializeField] private XRController controller; // Assign the controller in the inspector
    [SerializeField] private GameObject loadAnimation; // Reference to the loading animation GameObject
    [SerializeField] private float rayDistance = 10f;
    [SerializeField] private LayerMask layerMask; // Assign layer mask to target specific layers if needed

    private bool isAnimationPlaying = false;

    private void Update()
    {
        RaycastHit hit;

        // Determine the ray origin
        Vector3 rayOrigin;
        Vector3 rayDirection;

        if (controller != null && controller.inputDevice.isValid)
        {
            rayOrigin = controller.transform.position;
            rayDirection = controller.transform.forward;
        }
        else
        {
            rayOrigin = Camera.main.transform.position;
            rayDirection = Camera.main.transform.forward;
        }

        // Perform raycast
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, rayDistance, layerMask))
        {
            if (hit.collider is BoxCollider)
            {
                // Show loading animation if not already playing
                if (!isAnimationPlaying)
                {
                    loadAnimation.SetActive(true);
                    isAnimationPlaying = true;
                    Debug.Log("Playing Load Animation on: " + hit.collider.gameObject.name);
                }
            }
            else
            {
                StopLoadAnimation();
            }
        }
        else
        {
            StopLoadAnimation();
        }

        // Optional: Visualize the ray in the scene view
        Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.red);
    }

    // Stops the load animation
    private void StopLoadAnimation()
    {
        if (isAnimationPlaying)
        {
            loadAnimation.SetActive(false);
            isAnimationPlaying = false;
            Debug.Log("Stopped Load Animation");
        }
    }
}


