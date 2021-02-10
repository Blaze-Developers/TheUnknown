using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float fov = 120f;
    public Transform target;
    public bool insight;
    public float AwakeDistance;
    public float AttackRange = 15; 
    public NavMeshAgent enemyAgent;
    
    
    Animator _animator;

    private void Update()
    {
        float PlayerDistance = Vector3.Distance(target.position, transform.position);

        Vector3 playerDirection = target.position - transform.position;

        float playerAngle = Vector3.Angle(transform.forward, playerDirection);

        if(playerAngle <= fov/2)
        {
            insight = true;           
        }
        if(insight == true && PlayerDistance<= AwakeDistance)
        {
            AwareofPlayer();
        }
        if(insight == true && PlayerDistance>= AwakeDistance)
        {
            NotawareofPlayer();
        }
       
    }
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void AwareofPlayer()
    {
        
        _animator.SetBool("Chase", true);
        enemyAgent.SetDestination(target.position);
    }
    void NotawareofPlayer()
    {
        _animator.SetBool("Chase", false);
        enemyAgent.SetDestination(transform.position);
    }

}
