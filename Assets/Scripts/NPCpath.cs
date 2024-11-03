using UnityEngine;
using UnityEngine.AI;

public class NPCPath : MonoBehaviour
{
    public Transform[] path1Waypoints;  // Waypoints for the first path
    public Transform[] path2Waypoints;  // Waypoints for the second path
    public Transform[] path3Waypoints;  // Waypoints for the third path
    public Transform[] path4Waypoints;  // Waypoints for the fourth path
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
            Debug.Log("Reached branch point. Waiting for player input...");
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
        // This can be removed now as we will handle paths through the PathActivator
        Debug.Log("Player has chosen the path.");
    }

    public void ActivatePath(int pathNumber)
    {
        // Method to activate the chosen path
        if (pathNumber == 1)
        {
            isFollowingPath1 = true;
            branchChosen = true;
            currentWaypoint = 0;
            agent.SetDestination(path1Waypoints[currentWaypoint].position);
        }
        else if (pathNumber == 2)
        {
            isFollowingPath1 = false;
            branchChosen = true;
            currentWaypoint = 0;
            agent.SetDestination(path2Waypoints[currentWaypoint].position);
        }
        else if (pathNumber == 3)
        {
            isFollowingPath1 = false;
            branchChosen = true;
            currentWaypoint = 0;
            agent.SetDestination(path3Waypoints[currentWaypoint].position);
        }
        else if (pathNumber == 4)
        {
            isFollowingPath1 = false;
            branchChosen = true;
            currentWaypoint = 0;
            agent.SetDestination(path4Waypoints[currentWaypoint].position);
        }
    }

    void MoveToNextWaypoint()
    {
        // Update current waypoint and set the NPC's destination to the next one
        currentWaypoint++;

        if (isFollowingPath1)
        {
            if (currentWaypoint < path1Waypoints.Length)
            {
                agent.SetDestination(path1Waypoints[currentWaypoint].position);
            }
            else
            {
                // Path complete, you can stop the NPC or trigger an event
                agent.isStopped = true;
                Debug.Log("Path 1 complete.");
            }
        }
        else
        {
            // For path 2
            if (currentWaypoint < path2Waypoints.Length)
            {
                agent.SetDestination(path2Waypoints[currentWaypoint].position);
            }
            else
            {
                // Path 2 complete, disable the NPC
                CompletePathAndDisable();
            }
        }
        
        // For path 3
        if (!isFollowingPath1 && currentWaypoint < path3Waypoints.Length)
        {
            agent.SetDestination(path3Waypoints[currentWaypoint].position);
        }
        else if (currentWaypoint >= path3Waypoints.Length)
        {
            // Path 3 complete, disable the NPC
            CompletePathAndDisable();
        }

        // For path 4
        if (!isFollowingPath1 && currentWaypoint < path4Waypoints.Length)
        {
            agent.SetDestination(path4Waypoints[currentWaypoint].position);
        }
        else if (currentWaypoint >= path4Waypoints.Length)
        {
            // Path 4 complete, you can stop the NPC or trigger an event
            agent.isStopped = true;
            Debug.Log("Path 4 complete.");
        }
    }

    private void CompletePathAndDisable()
    {
        // Disable the NPC and reset its state
        Debug.Log("Path completed. Disabling NPC.");
        gameObject.SetActive(false); // Disable the NPC object

        // Optionally: Reset the state if you plan to reactivate it later
        ResetPath();
    }

    public void ResetPath()
    {
        // Resetting the NPC to start position
        currentWaypoint = 0;
        branchChosen = false;
        isFollowingPath1 = true; // Defaulting back to path1
        agent.SetDestination(path1Waypoints[currentWaypoint].position);
        agent.isStopped = false; // Ensure the NPC is moving again
    }
    
    public bool IsPathCompleted()
    {
        // Check if the NPC has completed the path
        return !agent.pathPending && agent.remainingDistance < 0.5f && branchChosen;
    }
}
