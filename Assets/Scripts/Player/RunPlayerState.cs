﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayerState : PlayerState
{
    float _speed = 10.0f;

    float _acceleration;

    public RunPlayerState(PlayerStateMachine stateMachine):base(stateMachine)
    {}

    public override void Start(Vector2 input)
    {
        base.Start(input);

        _animator.SetTrigger("Run");

        CalculateMovementAndRotation(input);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        _stateMachine.transform.position += _stateMachine.forward * _acceleration * Time.deltaTime;
    }

    //input represents a the two input axis the x component is vertical and the y component horizontal.
    //we use horizontal for back and forth and vertical for rotation.
    public override void Move(Vector2 input)
    {
        base.Move(input);

        if(input.sqrMagnitude == 0f)
        {
            _stateMachine.ChangeState(nameof(IdlePlayerState), input);
            return;
        }

        CalculateMovementAndRotation(input);
    }

    public override void End()
    {
        base.End();
        _animator.ResetTrigger("Run");
    }

    private void CalculateMovementAndRotation(Vector2 input)
    {
        _acceleration = input.y * _speed;
    }

}