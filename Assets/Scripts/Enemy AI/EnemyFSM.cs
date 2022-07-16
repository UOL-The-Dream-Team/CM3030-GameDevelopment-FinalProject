﻿/*
 * 
 * Code by: 
 *      Dimitrios Vlachos
 *      djv1@student.london.ac.uk
 *      dimitri.j.vlachos@gmail.com
 *      
 * Adapted from our FSM lecture
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    #region Variables
    public BaseState currentState;

    [Header("States")]
    public SeekState seek = new SeekState();
    public BounceBackState bounceBack = new BounceBackState();

    [Header("NPC Settings")]
    [Tooltip("Maximum health")]
    public float health;

    [Header("Movement")]
    [Tooltip("The speed that the agent moves. This is identical to changing the speed in the navmesh agent")]
    public float seekSpeed;
    [Tooltip("The time, in seconds, between target position updates")]
    public float updateTime;

    [Header("Seek behaviour")]
    [Tooltip("The time, in seconds, the sphere waits after colliding before seeking again")]
    public float waitTime;
    [Tooltip("The maximum distance to retreat to after a collision")]
    public float retreatRadius;

    [HideInInspector]
    public NavMeshAgent agent;

    [HideInInspector]
    public GameObject player;

    [HideInInspector]
    public GameObject NPCgO; //NPC Game Object

    [HideInInspector]
    public bool hit_player;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        NPCgO = this.gameObject;

        hit_player = false;

        MoveToState(seek);
    }

    void Update()
    {
        
    }

    public void MoveToState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision detected!");

        if(collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player hit!");
            hit_player = true;
        }
        // Temporary destruction on hit code
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            //Debug.Log("Player hit!");
            health -= 25;

            if (health <= 0)
            {
                gameObject.SetActive(false);
            }
            
        }
    }
}
