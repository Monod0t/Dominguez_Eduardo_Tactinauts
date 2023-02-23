using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This is the primary gameplay state. Players taps begin piloting their
// tanks & complete the intended objective before their opponents
public class GameplayState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    List<TankController> tankPlayers;
    float _timeLimit;
    TextMeshProUGUI _timer;

    public GameplayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;

        tankPlayers = controller.ReturnTankPlayers();
        _timeLimit = controller.ReturnTimeLimit();
        _timer = controller.ReturnTimer();
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("GAME START");
        for (int i = 0; i < tankPlayers.Count; i++)
        {
            tankPlayers[i].SetActiveStatus(true);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        SurvivorCheck();
        TimeLimitCheck();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void SurvivorCheck()
    {
        if (_controller.ReturnLivePlayerCount() == 1)
        {
            Debug.Log("GAME OVER via Survivor");
            _stateMachine.ChangeState(_stateMachine.GameEndState);
        }
    }

    public void TimeLimitCheck()
    {
        if (_timeLimit > 0)
        {
            _timeLimit -= Time.deltaTime;
            _timer.text = _timeLimit.ToString("F1");
        }
        else
        {
            Debug.Log("GAME OVER via Time");
            _stateMachine.ChangeState(_stateMachine.GameEndState);
        }
    }

}
