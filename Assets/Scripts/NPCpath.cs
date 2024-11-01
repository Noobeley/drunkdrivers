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
    private int chosenPath = 1;         // 1 for path1, 2 for path2, 3 for path3, 4 for path4
    private bool branchChosen = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // Start moving towards the first waypoint of the main path
        agent.SetDestination(path1Waypoints[currentWaypoint].position);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            // Override to send NPC to path 2 immediately when Y is pressed
            ChoosePath(2);
        }

        // Move NPC along the chosen path
        if (!branchChosen && Vector3.Distance(transform.position, branchPoint.position) < 1f)
        {
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
        if (Input.GetKeyDown(KeyCode.O))
        {
            ChoosePath(1);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            ChoosePath(2);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChoosePath(3);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ChoosePath(4);
        }
    }

    void ChoosePath(int pathNumber)
    {
        // Set the chosen path and start the NPC on that path
        chosenPath = pathNumber;
        branchChosen = true;
        currentWaypoint = 0;

        Transform[] selectedPathWaypoints = chosenPath switch
        {
            1 => path1Waypoints,
            2 => path2Waypoints,
            3 => path3Waypoints,
            4 => path4Waypoints,
            _ => null
        };

        if (selectedPathWaypoints != null && selectedPathWaypoints.Length > 0)
        {
            agent.SetDestination(selectedPathWaypoints[currentWaypoint].position);
        }
    }

    void MoveToNextWaypoint()
    {
        currentWaypoint++;

        Transform[] waypoints = chosenPath switch
        {
            1 => path1Waypoints,
            2 => path2Waypoints,
            3 => path3Waypoints,
            4 => path4Waypoints,
            _ => null
        };

        if (waypoints != null && currentWaypoint < waypoints.Length)
        {
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
        else
        {
            if (chosenPath == 2 || chosenPath == 3)
            {
                // Destroy NPC if path is 2 or 3
                Destroy(gameObject);

                // Notify NPCManager to spawn a new NPC
                NPCManager.Instance.OnNPCDestroyed();
            }
            else
            {
                // Path complete, stop NPC
                agent.isStopped = true;
            }
        }
    }
}
