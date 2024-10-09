using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class citizen : MonoBehaviour
{
    Vector3 moveDirection = Vector3.zero;
    [SerializeField] private int directionDetermined = 0;
    [SerializeField] private float direction = 1.0f;
    [SerializeField] private float speed = 1.0f;

    private InputAction moveLeftAction;
    private InputAction moveRightAction;

    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    private Coroutine moveCoroutine;

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
        if (moveDirection == Vector3.zero)
        {
            if (isMovingLeft)
            {
                moveDirection = new Vector3(0, 1, 0);
            }
            else if (isMovingRight)
            {
                moveDirection = new Vector3(0, -1, 0);
            }
        }
        else
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
    }

    private void StartMovingLeft()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = StartCoroutine(MoveLeftCoroutine());
    }

    private void StopMovingLeft()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
    }

    private IEnumerator MoveLeftCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < 3f)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        moveDirection = Vector3.zero;
    }

    private void StartMovingRight()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = StartCoroutine(MoveRightCoroutine());
    }

    private void StopMovingRight()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
    }

    private IEnumerator MoveRightCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < 3f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        moveDirection = Vector3.zero;
    }
}
