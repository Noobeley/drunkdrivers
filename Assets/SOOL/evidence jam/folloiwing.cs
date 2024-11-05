using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class folloiwing : MonoBehaviour
{
    public GameObject car; // Reference to the car object
    public float teleportOffset = 0.0f; // Offset for teleportation
    private float lastMoveTime; // Time when the camera last moved
    private float levelStartTime; // Time when the level started

    // Camera variables
    private Camera mainCamera;
    private float originalFOV;
    private float maxFOV = 90f;
    private float minFOV = 60f;
    private float fovChangeSpeed = 5f;

    // Movement variables
    private float currentOffset;
    private float targetOffset;
    private float offsetSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        lastMoveTime = Time.time; // Initialize the last move time
        levelStartTime = Time.time; // Initialize the level start time

        mainCamera = GetComponent<Camera>(); // Get the camera component
        originalFOV = mainCamera.fieldOfView; // Store the original FOV

        currentOffset = teleportOffset; // Initialize the current offset to the starting offset
        targetOffset = teleportOffset; // Initialize the target offset to the starting offset
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the teleport position based on the car's position and the teleport offset
        Vector3 teleportPosition = car.transform.position + currentOffset * transform.right;

        // Teleport the object to the calculated position
        transform.position = teleportPosition;

        // Adjust the teleport offset based on mouse location
        float mousePositionX = Input.mousePosition.x;
        float screenWidth = Screen.width;
        float normalizedMousePositionX = (mousePositionX / screenWidth) * 20f - 10f;
        targetOffset = normalizedMousePositionX;

        // Cap the target offset between -10 and 10
        targetOffset = Mathf.Clamp(targetOffset, -10f, 10f);

        // Smoothly interpolate the current offset towards the target offset
        currentOffset = Mathf.Lerp(currentOffset, targetOffset, offsetSpeed * Time.deltaTime);

        // Check if 40 seconds have passed since the level started
        //if (Time.time - levelStartTime > 40f)
        //{
        //    SceneManager.LoadScene("MainMenu"); // Restart the scene called Main Menu
        //}

        // Check if the camera has stopped moving for longer than 1 second
        if (Time.time - lastMoveTime > 1f)
        {
            lastMoveTime = Time.time; // Update the last move time
        }

        // Apply camera tricks based on teleport offset
        ApplyCameraTricks();
    }

    // Apply camera tricks based on teleport offset
    private void ApplyCameraTricks()
    {
        // Calculate the FOV change based on the teleport offset
        float fovChange = currentOffset * fovChangeSpeed;

        // Apply the FOV change to the camera's field of view
        mainCamera.fieldOfView = Mathf.Clamp(originalFOV + fovChange, minFOV, maxFOV);
    }
}
