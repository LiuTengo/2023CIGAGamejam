using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class InitialState : IGameState
{

    public GameStateController controller;

    public InitialState(GameStateController gameStateController)
    {
        this.controller = gameStateController;
    }
    public void EnterState()
    {
        //controller.playManager.SetCard();
    }

    public void UpdateState()
    {



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controller.fsm.SwitchState("PauseState");
        }
    }

    public void ExitState()
    {

    }
}
