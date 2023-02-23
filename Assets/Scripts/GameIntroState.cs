using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIntroState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    private bool trigger1 = false;

    public GameIntroState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Intro Sequence");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        // wait 6 seconds before allowing gameplay with 4 seconds being a countdown
        // Way game starts is subject to change
        // Allows to view main objective, spawn points, & map layout
        // StateDuration returns how long we've been in a state
        if (StateDuration >= 2 & !trigger1)
        {
            trigger1 = true;
            Debug.Log("Initiate Countdown Sequence");
        }

        if (StateDuration >= 6)
        {
            _stateMachine.ChangeState(_stateMachine.GamePlayState);
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

}
