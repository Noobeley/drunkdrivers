using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    
    public GameObject planeObject;
    public float aimRadius = 0.5f;
    public float transparency = 0.5f;

    private void Update()
    {
        // Cast a ray from the flashlight object towards the plane
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit object is the plane
            if (hit.collider.gameObject == planeObject)
            {
                // Get the hit point and calculate the area to make transparent
                Vector3 hitPoint = hit.point;
                Vector3 planeNormal = hit.normal;
                Vector3 transparentArea = hitPoint + planeNormal * aimRadius;

                // Update the transparency of the plane material
                Renderer planeRenderer = planeObject.GetComponent<Renderer>();
                Material planeMaterial = planeRenderer.material;
                Color transparentColor = planeMaterial.color;
                transparentColor.a = transparency;
                planeMaterial.color = transparentColor;

                // Debug draw the transparent area
                Debug.DrawLine(hitPoint, transparentArea, Color.green);
            }
        }
    }
}

