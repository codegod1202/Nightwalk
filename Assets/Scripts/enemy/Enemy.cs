using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }
    [SerializeField]
    private string currentState;
    public Path path;
    public GameObject debugSphere;
    private GameObject player;
    private Vector3 lastKnowPos;
    public Vector3 LastKnowPos { get => lastKnowPos; set => lastKnowPos = value; }
    public float enemyHP = 100;
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;
    [SerializeField]
    public LayerMask mask;
    public static bool isGameOver;
    public GameObject Player { get => player; }
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.ToString();
        debugSphere.transform.position = lastKnowPos;
        if (isGameOver)
        {
            //display game over screen
            Destroy(gameObject);
        }
    }
    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance, mask))
                    {
                        //if (hitInfo.transform.gameObject == player)
                        // {
                        return true;
                        // }
                    }
                    Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                }
            }
        }
        return false;
    }
    public void takeDamage(float damageAmount)
    {
        Debug.Log("shot");
        enemyHP -= damageAmount;
        Debug.Log(enemyHP);
        if (enemyHP <= 0)
        {
            isGameOver = true;
            player.GetComponent<EndManager>().enemyCount -= 1;
            Destroy(gameObject);
        }
    }
}
