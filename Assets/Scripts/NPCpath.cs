using UnityEngine;
using UnityEngine.AI;

public class NPCPath : MonoBehaviour
{
    public Transform[] path1Waypoints; // Waypoints for the first path
    public Transform[] path2Waypoints; // Waypoints for the second path
    public Transform branchPoint;       // The branching point where the player decides

    private NavMeshAgent agent;
    private int currentWaypoint = 0;
    private bool isFollowingPath1 = true;
    private bool branchChosen = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // Start moving towards the first waypoint of the main path
        agent.SetDestination(path1Waypoints[currentWaypoint].position);
    }

    void Update()
    {
        // Move NPC along the chosen path
        if (!branchChosen && Vector3.Distance(transform.position, branchPoint.position) < 1f)
        {
            // When NPC reaches the branch point, player must decide the path
            PlayerChoosePath();
        }

        if (branchChosen)
        {
            // Check if NPC has reached the current waypoint
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                MoveToNextWaypoint();
            }
        }
    }

    void PlayerChoosePath()
    {
        // This is where you take player input to choose the path
        if (Input.GetKeyDown(KeyCode.O))  // Use "O" key for Path 1
        {
            isFollowingPath1 = true;
            branchChosen = true;
            currentWaypoint = 0;
            agent.SetDestination(path1Waypoints[currentWaypoint].position);
        }
        else if (Input.GetKeyDown(KeyCode.P))  // Use "P" key for Path 2
        {
            isFollowingPath1 = false;
            branchChosen = true;
            currentWaypoint = 0;
            agent.SetDestination(path2Waypoints[currentWaypoint].position);
        }
    }

    void MoveToNextWaypoint()
    {
        currentWaypoint++;

        if (isFollowingPath1)
        {
            if (currentWaypoint < path1Waypoints.Length)
            {
                agent.SetDestination(path1Waypoints[currentWaypoint].position);
            }
            else
            {
                CompletePath();
            }
        }
        else
        {
            if (currentWaypoint < path2Waypoints.Length)
            {
                agent.SetDestination(path2Waypoints[currentWaypoint].position);
            }
            else
            {
                CompletePath();
            }
        }
    }

    void CompletePath()
    {
        agent.isStopped = true; // Stop the NPC
        Debug.Log($"NPC {gameObject.name} has completed its path.");
        gameObject.SetActive(false); // Deactivate the NPC when done
        NPCManager.Instance.OnNPCDeactivated(); // Notify NPC Manager
    }

    public void ResetPath()
    {
        currentWaypoint = 0;
        branchChosen = false;
        isFollowingPath1 = true; // Reset to default path
        agent.isStopped = false;  // Resume movement
        agent.SetDestination(path1Waypoints[currentWaypoint].position); // Set initial destination
    }
}

