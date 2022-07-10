﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekState : BaseState
{
    public override void EnterState(EnemyFSM npc)
    {
        base.EnterState(npc);

        Debug.Log("Seeking Player...");

        agent.speed = seekSpeed;
        SetTarget();
    }

    void SetTarget()
    {
        /*
         * Coroutines must be called from a MonoBehaviour class. Since this is not a monobehaviour,
         * we must instead call the coroutine in this code, but get the MonoBehviour script to run it for us.
         * 
         * Here we are getting the FSM MonoBehaviour to begin this coroutine.
         */
        FSM.StartCoroutine(SeekStatusCheck());
    }

    IEnumerator SeekStatusCheck()
    {
        yield return new WaitForSeconds(targetPositionUpdateTime);

        //if(some condition) 
        //{
        //    FSM.MoveToState(newState);
        //}
        //else
        //{
        Debug.Log("Setting target to:" + player.transform.position);
            agent.destination = player.transform.position;
            FSM.StartCoroutine(SeekStatusCheck());
        //}
    }
}