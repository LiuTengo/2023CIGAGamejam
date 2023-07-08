using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : IGameState
{
    public GameStateController controller;
    public LoseState(GameStateController controller)
    {
        this.controller = controller;
    }
    public void EnterState()
    {
        Debug.Log("Enter LoseState");
    }
    public void UpdateState()
    {
        
    }

    public void ExitState()
    {
        
    }


}
