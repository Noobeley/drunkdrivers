using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RaycastBoxColliderWithLoadAnimation : MonoBehaviour
{
    public float detectionRange = 10f;
    [SerializeField] private GameObject loadAnimation; // Reference to the loading animation GameObject
    [SerializeField] private InputActionReference[] interactAction; // Input actions for triggering the animation
    [SerializeField] private LayerMask layerMask; // Layer mask to target specific layers if needed

    private bool isAnimationPlaying = false;
    private BoxCollider currentBoxCollider;

    void Update()
    {
        DetectBoxCollider();

        // Check if either input action is triggered
        if ((interactAction[0].action.triggered || interactAction[1].action.triggered) && currentBoxCollider != null)
        {
            ToggleLoadAnimation();
        }
    }

    void DetectBoxCollider()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Perform raycast
        if (Physics.Raycast(ray, out hit, detectionRange, layerMask))
        {
            // Check if the collider is a BoxCollider
            if (hit.collider is BoxCollider)
            {
                currentBoxCollider = hit.collider as BoxCollider;
            }
            else
            {
                currentBoxCollider = null;
            }
        }
        else
        {
            currentBoxCollider = null;
        }
    }

    private void ToggleLoadAnimation()
    {
        if (!isAnimationPlaying)
        {
            loadAnimation.SetActive(true);
            isAnimationPlaying = true;
            Debug.Log("Playing Load Animation on: " + currentBoxCollider.gameObject.name);
        }
        else
        {
            loadAnimation.SetActive(false);
            isAnimationPlaying = false;
            Debug.Log("Stopped Load Animation");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * detectionRange);
    }
}