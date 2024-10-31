using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;  // Required for XR interaction

public class VRControllerRaycast : MonoBehaviour
{
    public ButtonAnimationController buttonAnimationController;
    public Transform leftRaycastOrigin;
    public Transform rightRaycastOrigin;
    public float rayLength = 5.0f;

    private LineRenderer leftLineRenderer;
    private LineRenderer rightLineRenderer;

    void Start()
    {
        // Initialize LineRenderers for visual feedback (optional)
        if (leftRaycastOrigin != null)
        {
            leftLineRenderer = leftRaycastOrigin.gameObject.AddComponent<LineRenderer>();
            SetupLineRenderer(leftLineRenderer);
        }

        if (rightRaycastOrigin != null)
        {
            rightLineRenderer = rightRaycastOrigin.gameObject.AddComponent<LineRenderer>();
            SetupLineRenderer(rightLineRenderer);
        }
    }

    void Update()
    {
        // Raycasting and input detection for left controller
        if (leftRaycastOrigin != null && Input.GetButtonDown("XRInput_LeftTrigger"))  // Adjust input to your setup
        {
            PerformRaycast(leftRaycastOrigin, leftLineRenderer);
        }

        // Raycasting and input detection for right controller
        if (rightRaycastOrigin != null && Input.GetButtonDown("XRInput_RightTrigger"))  // Adjust input to your setup
        {
            PerformRaycast(rightRaycastOrigin, rightLineRenderer);
        }
    }

    void PerformRaycast(Transform rayOrigin, LineRenderer lineRenderer)
    {
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        RaycastHit hit;

        // Draw the ray (optional visual feedback)
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, rayOrigin.position);
            lineRenderer.SetPosition(1, rayOrigin.position + rayOrigin.forward * rayLength);
        }

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.collider.name == "AcceptButtonCollider")
            {
                buttonAnimationController.OnAcceptButtonClicked();
            }
            else if (hit.collider.name == "CheckButtonCollider")
            {
                buttonAnimationController.OnCheckButtonClicked();
            }
        }
    }

    private void SetupLineRenderer(LineRenderer lineRenderer)
    {
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.material = new Material(Shader.Find("Unlit/Color")) { color = Color.green };
    }
}

