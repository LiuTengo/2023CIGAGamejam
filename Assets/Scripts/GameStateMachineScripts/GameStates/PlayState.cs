using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayState : IGameState
{

    public GameStateController controller;

    public PlayState(GameStateController gameStateController)
    {
        this.controller = gameStateController;
    }
    public void EnterState()
    {
        
    }

    public void UpdateState()
    {
        Debug.Log("Updating PlayState");

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            controller.fsm.SwitchState("PauseState");
        }
    }

    public void ExitState()
    {
        Debug.Log("Exit PlayState");
    }
}
