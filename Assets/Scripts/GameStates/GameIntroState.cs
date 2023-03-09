using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameIntroState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    private bool trigger1 = false;
    GameObject introScreen;
    TextMeshProUGUI countdown;

    public GameIntroState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
        introScreen = controller.ReturnIntroScreen();
        countdown = controller.ReturnCountdown();
    }

    public override void Enter()
    {
        base.Enter();
        introScreen.SetActive(true);
        Debug.Log("Intro Sequence");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (StateDuration >= 6 & !trigger1)
        {
            trigger1 = true;
            introScreen.SetActive(false);
            Debug.Log("Initiate Countdown Sequence");
            countdown.gameObject.SetActive(true);
        }

        if (countdown.gameObject.activeSelf)
        {
            if (StateDuration >= 6 && StateDuration < 7)
            {
                countdown.text = "3";
            }
            else if (StateDuration >= 7 && StateDuration < 8)
            {
                countdown.text = "2";
            }
            else if (StateDuration >= 8 && StateDuration < 9)
            {
                countdown.text = "1";
            }
            else if (StateDuration >= 9)
            {
                countdown.text = "GO";
            }
        }

        if (StateDuration >= 10)
        {
            countdown.gameObject.SetActive(false);
            _stateMachine.ChangeState(_stateMachine.GamePlayState);
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    void StartCountdown()
    {
        
    }

}
