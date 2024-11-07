using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawn : MonoBehaviour
{
    public GameObject[] immigrants; // Array to hold the immigrant game objects
    private int currentImmigrantIndex = 0; // Index of the current immigrant

    // Start is called before the first frame update
    void Start()
    {
        // Disable all immigrants initially
        foreach (GameObject immigrant in immigrants)
        {
            immigrant.SetActive(false);
        }

        // Enable the first immigrant
        immigrants[currentImmigrantIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the accept or deny button is pressed
        if (Input.GetKeyDown(KeyCode.A))
        {
            AcceptImmigrant();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            DenyImmigrant();
        }
    }

    // Method to accept the current immigrant
    void AcceptImmigrant()
    {
        // Move the current immigrant up by 1.5 on the Y axis
        immigrants[currentImmigrantIndex].transform.Translate(Vector3.up * 1.5f);

        // Move the current immigrant left by 20
        immigrants[currentImmigrantIndex].transform.Translate(Vector3.left * 20f);

        // Disable the current immigrant
        immigrants[currentImmigrantIndex].SetActive(false);

        // Increment the current immigrant index
        currentImmigrantIndex++;

        // Check if there are more immigrants
        if (currentImmigrantIndex < immigrants.Length)
        {
            // Enable the next immigrant
            immigrants[currentImmigrantIndex].SetActive(true);
        }
    }

    // Method to deny the current immigrant
    void DenyImmigrant()
    {
        // Move the current immigrant up by 1.5 on the Y axis
        immigrants[currentImmigrantIndex].transform.Translate(Vector3.up * 1.5f);

        // Move the current immigrant right by 20
        immigrants[currentImmigrantIndex].transform.Translate(Vector3.right * 20f);

        // Disable the current immigrant
        immigrants[currentImmigrantIndex].SetActive(false);

        // Increment the current immigrant index
        currentImmigrantIndex++;

        // Check if there are more immigrants
        if (currentImmigrantIndex < immigrants.Length)
        {
            // Enable the next immigrant
            immigrants[currentImmigrantIndex].SetActive(true);
        }
    }
}
