using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float fov = 120f;
    protected Vector3 velocity;
    public Transform _transform;
    public float distance = 5f;
    public float speed = 1f;
    Vector3 _originalPosition;
    bool isGoingLeft = false;
    public float distFromStart;
    public NavMeshAgent enemyagent;
    public Transform target;
    public bool insight;
    public float AwakeDistance = 200f;
    public bool AwareOfPlayer;
    public bool PlayerInvision;
    public void Start()
    {
        _originalPosition = gameObject.transform.position;
        _transform = GetComponent<Transform>();
        velocity = new Vector3(speed, 0, 0);
        _transform.Translate(velocity.x * Time.deltaTime, 0, 0);
    }
    private void Update()
    {
        distFromStart = transform.position.x - _originalPosition.x;

        if (isGoingLeft)
        {
            // If gone too far, switch direction
            if (distFromStart < -distance)
                SwitchDirection();

            _transform.Translate(-velocity.x * Time.deltaTime, 0, 0);
        }
        else
        {
            // If gone too far, switch direction
            if (distFromStart > distance)
                SwitchDirection();

            _transform.Translate(velocity.x * Time.deltaTime, 0, 0);
        }

        drawRay();
        float PlayerDistance = Vector3.Distance(target.position, transform.position);
        Vector3 playerDirection = target.position - transform.position;
        float playerAngle = Vector3.Angle(transform.forward, playerDirection);
        if (playerAngle <= fov / 2f)
        {
            insight = true;
            Debug.Log("Playerinsight");
        }
        else
        {
            insight = false;
        }
        if (insight == true && PlayerDistance <= AwakeDistance && PlayerInvision == true)
        {
            AwareOfPlayer = true;
        }
        if(AwareOfPlayer == true)
        {
            enemyagent.SetDestination(target.position);
        }
        
    }
    void drawRay()
    {
        Vector3 playerDirection = target.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, playerDirection, out hit))
        {
            if(hit.transform.tag == "Player")
            {
                PlayerInvision = true;
            }
            else
            {
                PlayerInvision = false;
            }
        }
    }
    void SwitchDirection()
    {
        isGoingLeft = !isGoingLeft;
        
    }
}
