using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    public Transform player;
    public Transform patrolRoute;
    public List<Transform> locations;
    public int Avoiding = 1;
    public DroneBehavior drone;

    private GameBehavior gameBehavior;
    private int locationIndex = 0;
    private NavMeshAgent agent;

    private int lives = 6;
    public int EnemyLives
    {

        get { return lives; }

        private set
        {

            lives = value;

            if (lives <= 0)
            {
                if (gameObject.name == "DroneBox")
                {
                    drone.DestroyDrone();
                }
                Destroy(this.gameObject);
                Debug.Log("Enemy down.");
            }

        }

    }

    // Start is called before the first frame update
    void Start()
    {

        gameBehavior = FindObjectOfType<GameBehavior>();

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();

    }

    // Update is called once per frame
    void Update()
    {

        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {

            MoveToNextPatrolLocation();

        }

    }

    void InitializePatrolRoute()
    {

        foreach (Transform child in patrolRoute)
        {

            locations.Add(child);

        }

    }

    void MoveToNextPatrolLocation()
    {

        if (locations.Count == 0)
        {

            return;

        }

        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.name == "Player")
        {

            PlayerBehavior Player = other.gameObject.GetComponent<PlayerBehavior>();
            if (Player.Avoid)
            {

                Debug.Log("Player detected - ignoring!");

            }
            else
            {

                agent.destination = player.position;
                Debug.Log("Player detected - attack!");

            }

        }

    }

    void OnTriggerExit(Collider other)
    {

        if (other.name == "Player")
        {

            Debug.Log("Player out of range, resume patrol");

        }

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Bullet(Clone)")
        {

            LivesChange(-gameBehavior.Damage);

            Debug.Log("Damage: " + gameBehavior.Damage +  "\nCritical hit!");

        }

    }

    void LivesChange(int value)
    {

        EnemyLives += value;

    }
}
