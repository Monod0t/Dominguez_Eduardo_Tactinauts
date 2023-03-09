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
    float _startTime;
    TextMeshProUGUI _countdown;
    bool warningTrigger = false;

    public GameplayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;

        tankPlayers = controller.ReturnTankPlayers();
        _countdown = controller.ReturnTimer();
    }

    public override void Enter()
    {
        base.Enter();

        _timeLimit = _controller.ReturnTimeLimit();
        _startTime = Time.time;

        Debug.Log("GAME START");
        for (int i = 0; i < tankPlayers.Count; i++)
        {
            tankPlayers[i].SetActiveStatus(true);
        }
        _countdown.enabled = true;
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
        float elapsedTime = _timeLimit - (Time.time - _startTime); // Calculate the remaining countdown time

        if (elapsedTime > 0)
        {
            // Calculate the minutes and seconds from the remaining countdown time
            int minutes = (int)(elapsedTime / 60f);
            int seconds = (int)(elapsedTime % 60);

            // Update the timer text
            if (minutes < 10)
            {
                _countdown.text = string.Format("0{0}:{1:00}", minutes, seconds);
            }
            else
            {
                _countdown.text = string.Format("{0}:{1:00}", minutes, seconds);
            }

        }
        else
        {
            Debug.Log("GAME OVER via Time");
            _stateMachine.ChangeState(_stateMachine.GameEndState);
        }

        if (elapsedTime <= 30 && !warningTrigger)
        {
            warningTrigger = true;
            Debug.Log("30 Seconds remaining!");
        }

    }

    
}
