using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRaycastController : MonoBehaviour
{
    public ButtonAnimationController buttonAnimationController; // Reference to animation controller

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect left-click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked collider belongs to the Accept button area
                if (hit.collider.name == "AcceptButtonCollider")
                {
                    buttonAnimationController.OnAcceptButtonClicked();  // Trigger Accept animation
                }
                // Check if the clicked collider belongs to the Check button area
                else if (hit.collider.name == "CheckButtonCollider")
                {
                    buttonAnimationController.OnCheckButtonClicked();  // Trigger Check animation
                }
            }
        }
    }
}

