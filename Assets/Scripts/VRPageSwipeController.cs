using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRPageSwipeController : MonoBehaviour
{
    public List<GameObject> pages;           // Pages in the Canvas
    public Transform controllerTransform;     // Controller transform
    public float swipeDistanceThreshold = 0.1f;
    private Vector3 swipeStartPos;
    private bool isSwiping = false;
    private int currentPage = 0;

    void Start()
    {
        if (pages.Count > 0)
        {
            for (int i = 1; i < pages.Count; i++)
            {
                pages[i].SetActive(false);
            }
        }
    }

    void Update()
    {
        // Declare triggerPressed outside of the if statement so it can be used throughout Update
        bool triggerPressed = false;

        // Detect swipe start on trigger press
        if (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand)
            .TryGetFeatureValue(CommonUsages.triggerButton, out triggerPressed) && triggerPressed)
        {
            swipeStartPos = controllerTransform.position;
            isSwiping = true;
        }

        // Detect swipe end on trigger release
        if (!triggerPressed && isSwiping)
        {
            Vector3 swipeEndPos = controllerTransform.position;
            Vector3 swipeDelta = swipeEndPos - swipeStartPos;

            // Check if swipe distance threshold is met
            if (swipeDelta.magnitude >= swipeDistanceThreshold)
            {
                if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                {
                    if (swipeDelta.x > 0) SwipeRight();
                    else SwipeLeft();
                }
            }
            isSwiping = false;
        }
    }

    void SwipeLeft()
    {
        if (currentPage < pages.Count - 1)
        {
            pages[currentPage].SetActive(false);
            currentPage++;
            pages[currentPage].SetActive(true);
        }
    }

    void SwipeRight()
    {
        if (currentPage > 0)
        {
            pages[currentPage].SetActive(false);
            currentPage--;
            pages[currentPage].SetActive(true);
        }
    }
}
