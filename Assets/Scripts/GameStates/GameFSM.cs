using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the state machine works with the controller to receive data
[RequireComponent(typeof(GameFSM))]
public class GameFSM : StateMachineMB
{
    // State Instances
    public GameIntroState GameIntroState { get; private set; }
    public GameplayState GamePlayState { get; private set; }
    public GameEndState GameEndState { get; private set; }

    private GameController GameController;

    private void Awake()
    {
        // grab local components
        GameController = GetComponent<GameController>();
        // create states
        GameIntroState = new GameIntroState(this, GameController);
        GamePlayState = new GameplayState(this, GameController);
        GameEndState = new GameEndState(this, GameController);
    }

    private void Start()
    {
        ChangeState(GameIntroState);
    }

}
