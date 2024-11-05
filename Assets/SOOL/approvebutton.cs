using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class approvebutton : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    private Vector3 originalPosition;

    private void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        originalPosition = transform.position;
    }

    private void OnEnable()
    {
        interactable.onSelectEntered.AddListener(PushButton);
        interactable.onSelectExited.AddListener(ReleaseButton);
    }

    private void OnDisable()
    {
        interactable.onSelectEntered.RemoveListener(PushButton);
        interactable.onSelectExited.RemoveListener(ReleaseButton);
    }

    private void PushButton(XRSimpleInteractor interactor)
    {
        transform.position = originalPosition - new Vector3(0f, 0.05f, 0f);
    }

    private void ReleaseButton(XRSimpleInteractor interactor)
    {
        transform.position = originalPosition;
    }
}
