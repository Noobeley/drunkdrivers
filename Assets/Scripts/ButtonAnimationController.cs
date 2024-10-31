using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    // Function to call when the Accept button is clicked
    public void OnAcceptButtonClicked()
    {
        animator.SetTrigger("AcceptPressed");  // Trigger the AcceptPressed animation
    }

    // Function to call when the Check button is clicked
    public void OnCheckButtonClicked()
    {
        animator.SetTrigger("CheckPressed");  // Trigger the CheckPressed animation
    }
}
