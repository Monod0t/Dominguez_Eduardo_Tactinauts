using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    List<TankController> _tankPlayers;
    List<TankController> _winners = new List<TankController>();

    public GameEndState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;

        _tankPlayers = controller.ReturnTankPlayers();
    }

    public override void Enter()
    {
        base.Enter();
        for (int i = 0; i < _tankPlayers.Count; i++)
        {
            _tankPlayers[i].SetActiveStatus(false);
            if (_tankPlayers[i].ReturnLifeStatus())
            {
                _winners.Add(_tankPlayers[i]);
            }
        }
        string _winnerText = string.Join(", ", _winners);
        Debug.Log("The survivors are: " + _winnerText);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
