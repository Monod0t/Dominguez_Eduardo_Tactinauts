using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEndState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    List<TankController> _tankPlayers;
    List<string> _winners = new List<string>();
    GameObject winnerScreen;
    TextMeshProUGUI winnerText;
    string _winnerText;

    public GameEndState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;

        _tankPlayers = controller.ReturnTankPlayers();
        winnerScreen = controller.ReturnWinnerScreen();
        winnerText = controller.ReturnWinnertext();
    }

    public override void Enter()
    {
        base.Enter();

        for (int i = 0; i < _tankPlayers.Count; i++)
        {
            _tankPlayers[i].SetActiveStatus(false);
            if (_tankPlayers[i].ReturnLifeStatus())
            {
                _winners.Add("Player " + (i+1));
            }
        }

        _winnerText = string.Join(", ", _winners);

        winnerScreen.SetActive(true);

        if (_winners.Count > 1)
        {
            winnerText.text = "Draw: " + _winnerText;

        }
        else
        {
            winnerText.text = "Winner: " + _winnerText;

        }

        _controller.DestroyLobbyData();

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
