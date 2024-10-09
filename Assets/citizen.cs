using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class citizen : MonoBehaviour
{
    Vector3 moveDirection= Vector3.zero;
    [SerializeField] private int directionDetermined = 0;
    [SerializeField] private float direction = 1.0f;
    [SerializeField] private float speed = 1.0f;

    private InputAction moveLeftAction;
    private InputAction moveRightAction;

    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    private void OnEnable()
    {
        moveLeftAction = new InputAction("MoveLeft", binding: "<Keyboard>/j");
        moveRightAction = new InputAction("MoveRight", binding: "<Keyboard>/k");

        moveLeftAction.Enable();
        moveRightAction.Enable();

        moveLeftAction.started += _ => StartMovingLeft();
        moveLeftAction.canceled += _ => StopMovingLeft();
        moveRightAction.started += _ => StartMovingRight();
        moveRightAction.canceled += _ => StopMovingRight();
    }

    private void OnDisable()
    {
        moveLeftAction.Disable();
        moveRightAction.Disable();

        moveLeftAction.started -= _ => StartMovingLeft();
        moveLeftAction.canceled -= _ => StopMovingLeft();
        moveRightAction.started -= _ => StartMovingRight();
        moveRightAction.canceled -= _ => StopMovingRight();
    }

    private void Update()
    {
        if (moveDirection == new Vector3(0,0,0))
        {
            if (isMovingLeft)
            {
                Vector3 moveDirection = new Vector3(0,1,0);
            }
            else if (isMovingRight)
            {
                Vector3 moveDirection = new Vector3(0,-1,0);
            }
        }
        else
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
    }

    private void StartMovingLeft()
    {
        isMovingLeft = true;
    }

    private void StopMovingLeft()
    {
        isMovingLeft = false;
        StartCoroutine(DestroyAfterDelay());
    }

    private void StartMovingRight()
    {
        isMovingRight = true;
    }

    private void StopMovingRight()
    {
        isMovingRight = false;
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
}
