using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessState : IGameState
{
    public GameStateController controller;
    public GuessState(GameStateController controller)
    {
        this.controller = controller;
    }
    public void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}
